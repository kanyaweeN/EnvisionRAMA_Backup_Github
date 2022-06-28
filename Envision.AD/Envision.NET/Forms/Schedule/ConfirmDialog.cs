using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraScheduler;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraEditors.Repository;

using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Controls;
using Envision.Common.Common;
using Miracle.Util;
using Envision.BusinessLogic.ProcessUpdate;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;

namespace Envision.NET.Forms.Schedule
{
    public partial class ConfirmDialog :DevExpress.XtraBars.Ribbon.RibbonForm //Form 
    {
        private int scheduleId;
        private string modality_id;
        private DateTime start, start_session;
        private DateTime end, end_session;
        private Patient patient;
        private DataTable dttSession;
        private DataTable dttExam;
        private DataTable dataAllExam = RISBaseData.Ris_Exam();
        public DataTable dttBpview { get; set; }
        public DataTable dttDoctor { get; set; }
        public DataTable dttRadiologist { get; set; }
        public DataTable dtInsu { get; set; }
        private DataTable dttExamFlag, dtExamFlagDTL;

        private DataSet dsHistorySchedule;
        private Appointment apt;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private int clinictype;
        private bool is_blocked = false;
        private string session_id = "";
        public string REASON
        {
            get { return txtInputReason.Text.Trim(); }
        }
        public string TextINBlock { get; set; }

        public ConfirmDialog() {
            InitializeComponent();
        }
        public ConfirmDialog(int ID,string MODALITY_ID,DateTime DTStart,DateTime DTEnd)
        {
            InitializeComponent();
            scheduleId = ID;
            modality_id = MODALITY_ID;
            start = DTStart;
            end = DTEnd;
            
        }
        private void ConfirmDialog_Load(object sender, EventArgs e)
        {
            cboGender.Properties.Items.Clear();
            cboGender.Properties.Items.Add("Male");
            cboGender.Properties.Items.Add("Female");
            cboGender.SelectedIndex = 0;
            initDataToCtrl();
            initGridExam();
            setTrauma();
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = scheduleId == 0 ? -1 : scheduleId;
            prc.InvokeSchedule();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();
        }
        private void initDataToCtrl() {
            ProcessGetRISClinictype process = new ProcessGetRISClinictype();
            process.Invoke();
            DataTable dtt = process.Result.Tables[0];
            DataRow[] dr = dtt.Select("IS_DEFAULT='Y'");

            ProcessGetRISSchedule proc = new ProcessGetRISSchedule(scheduleId);
            proc.Invoke();
            DataTable dt = proc.Result.Tables[0].Copy();
            string hn = dt.Rows[0]["HN"].ToString();
            patient = new Patient(hn, true);
            fillDataToCtrl(dt.Rows[0]);


            ProcessGetRISClinicsession prcCln = new ProcessGetRISClinicsession();
            dttSession = prcCln.GetClinicSession().Copy();
            
            if (string.IsNullOrEmpty(dt.Rows[0]["SESSION_ID"].ToString()))
                session_id = "2";
            else
                session_id = dt.Rows[0]["SESSION_ID"].ToString();

            DataRow[] drr = dttSession.Select("SESSION_ID = " + session_id);
            if (drr.Length > 0)
            {
                //txtClinicType.Tag = drr[0]["SESSION_ID"].ToString();
                //txtClinicType.Text = drr[0]["SESSION_NAME"].ToString();
                clinictype = Convert.ToInt32(drr[0]["CLINIC_TYPE_ID"]);
                start_session = Convert.ToDateTime(drr[0]["START_TIME"]);
                end_session = Convert.ToDateTime(drr[0]["END_TIME"]);
            }
            if (cboGender.SelectedIndex == 0)
            {
                lblLMP.Visible = false;
                deLMP.Visible = false;
            }
            else
            {
                lblLMP.Visible = true;
                deLMP.Visible = true;
                deLMP.Enabled = false;

                if (string.IsNullOrEmpty(dt.Rows[0]["LMP_DT"].ToString()))
                    deLMP.DateTime = DateTime.Now;
                else if (Convert.ToDateTime(dt.Rows[0]["LMP_DT"]) == DateTime.MinValue)
                    deLMP.DateTime = DateTime.Now;
                else
                    deLMP.DateTime = Convert.ToDateTime(dt.Rows[0]["LMP_DT"]);
            }
            txtModality.Text = ModalityName(modality_id);
            txtUserName.Text = env.FirstName + " " + env.LastName;
            setLookupAllGrid();
            grdLvPatStatus.EditValue = dt.Rows[0]["PAT_STATUS"];
            if (string.IsNullOrEmpty(dt.Rows[0]["INSURANCE_TYPE_ID"].ToString()) || dt.Rows[0]["INSURANCE_TYPE_ID"].ToString() == "0")
                grdLvInsurance.EditValue = 11;//เงินสด
            else
                grdLvInsurance.EditValue = Convert.ToInt32(dt.Rows[0]["INSURANCE_TYPE_ID"]);

            initGridHistory();

            deLMP.BackColor = txtHN.BackColor;
            grdLvPatStatus.BackColor = txtHN.BackColor;
            cboGender.BackColor = txtHN.BackColor;
        }
        private void initEmptyRows()
        {
            bool flag = true;
            foreach (DataRow row in dttExam.Rows)
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString().Trim()))
                {
                    flag = false;
                    break;
                }
            if (flag)
            {
                DataRow row = dttExam.NewRow();
                row["QTY"] = 1;
                row["RATE"] = 0.0;
                dttExam.Rows.Add(row);
                dttExam.AcceptChanges();
            }
        }
        private void initGridExam()
        {
            
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule(scheduleId);
            proc.Invoke();
            dttExam = new DataTable();
            dttExam = proc.Result.Tables[1].Copy();

            initEmptyRows();
            grdExam.DataSource = dttExam;

            for (int i = 0; i < viewExam.Columns.Count; i++)
            {
                viewExam.Columns[i].Visible = false;
            }
            #region Reposity Exam Flag
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repExamFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repExamFlag.AutoHeight = false;
            repExamFlag.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0)
            });
            repExamFlag.Name = "repExamFlag";
            repExamFlag.SmallImages = img16;
            repExamFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repExamFlag.Buttons[0].Visible = false;
            #endregion
            viewExam.Columns["FLAG_ICON"].ColumnEdit = repExamFlag;
            viewExam.Columns["FLAG_ICON"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;
            viewExam.Columns["FLAG_ICON"].Caption = " ";
            viewExam.Columns["FLAG_ICON"].Width = -1;
            viewExam.Columns["FLAG_ICON"].VisibleIndex = 1;

            #region Reposity ExamCode.
            RepositoryItemLookUpEdit repositoryItemLookUpEdit1 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit1.ImmediatePopup = true;
            repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit1.DisplayMember = "EXAM_UID";
            repositoryItemLookUpEdit1.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit1.DropDownRows = 5;
            repositoryItemLookUpEdit1.DataSource = dataAllExam;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.BestFit();
            repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_UID"].ColumnEdit = repositoryItemLookUpEdit1;
            viewExam.Columns["EXAM_UID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_UID"].Caption = "Exam Code";
            viewExam.Columns["EXAM_UID"].Width = 80;
            viewExam.Columns["EXAM_UID"].VisibleIndex = 2;

            #region Reposity ExamName.
            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_UID", "Exam Code", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "EXAM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "EXAM_ID";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dataAllExam;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.BestFit();
            repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            viewExam.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewExam.Columns["EXAM_NAME"].Width = 180;
            viewExam.Columns["EXAM_NAME"].VisibleIndex = 3;

            #region Reposity BodyPartView.
            RepositoryItemLookUpEdit rleBPView = new RepositoryItemLookUpEdit();
            rleBPView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rleBPView.ImmediatePopup = true;
            rleBPView.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rleBPView.AutoHeight = false;
            rleBPView.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BPVIEW_NAME", "Sides", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rleBPView.DisplayMember = "BPVIEW_NAME";
            rleBPView.ValueMember = "BPVIEW_ID";
            rleBPView.DropDownRows = 5;
            rleBPView.DataSource = dttBpview;
            rleBPView.NullText = string.Empty;
            rleBPView.BestFit();
            rleBPView.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["BPVIEW_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["BPVIEW_ID"].ColumnEdit = rleBPView;
            viewExam.Columns["BPVIEW_ID"].Caption = "Sides";
            viewExam.Columns["BPVIEW_ID"].VisibleIndex = 4;

            viewExam.Columns["QTY"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["QTY"].Caption = "Qty";
            viewExam.Columns["QTY"].Width = 50;
            viewExam.Columns["QTY"].VisibleIndex = 5;
            viewExam.Columns["QTY"].OptionsColumn.ReadOnly = true;

            viewExam.Columns["RATE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["RATE"].Caption = "Rate";
            viewExam.Columns["RATE"].Width = 80;
            viewExam.Columns["RATE"].VisibleIndex = 6;
            viewExam.Columns["RATE"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["RATE"].DisplayFormat.FormatString = "#,##0";
            viewExam.Columns["RATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            viewExam.Columns["AVG_REQ_MIN"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["AVG_REQ_MIN"].Caption = "Avg(Minute)";
            viewExam.Columns["AVG_REQ_MIN"].Width = 90;
            viewExam.Columns["AVG_REQ_MIN"].VisibleIndex = 7;

            //viewExam.Columns["TOTAL"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            //viewExam.Columns["TOTAL"].Caption = "Total";
            //viewExam.Columns["TOTAL"].Width = 90;
            //viewExam.Columns["TOTAL"].VisibleIndex = 9;
            //viewExam.Columns["TOTAL"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //viewExam.Columns["TOTAL"].SummaryItem.DisplayFormat = "{0:N0}";
            //viewExam.Columns["TOTAL"].OptionsColumn.ReadOnly = true;
            //viewExam.Columns["TOTAL"].DisplayFormat.FormatString = "#,##0";
            //viewExam.Columns["TOTAL"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            #region Reposity Prepation
            LookUpSelect lvS = new LookUpSelect();
            DataTable dttPre = lvS.ScheduleNotParameter("Prepation").Tables[0];
            RepositoryItemLookUpEdit rlePre = new RepositoryItemLookUpEdit();
            rlePre.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rlePre.ImmediatePopup = true;
            rlePre.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rlePre.AutoHeight = false;
            rlePre.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PREPARATION_UID", "Prepation", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rlePre.DisplayMember = "PREPARATION_UID";
            rlePre.ValueMember = "PREPARATION_ID";
            rlePre.DropDownRows = 5;
            rlePre.DataSource = dttPre;
            rlePre.NullText = string.Empty;
            rlePre.BestFit();
            rlePre.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["PREPATION_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["PREPATION_ID"].ColumnEdit = rlePre;
            viewExam.Columns["PREPATION_ID"].Caption = "Prepation";
            viewExam.Columns["PREPATION_ID"].Width = 100;
            viewExam.Columns["PREPATION_ID"].VisibleIndex = 8;

            #region Repository Radiologist
            RepositoryItemLookUpEdit rpsRadio = new RepositoryItemLookUpEdit();
            rpsRadio.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rpsRadio.ImmediatePopup = true;
            rpsRadio.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            rpsRadio.AutoHeight = false;
            rpsRadio.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UIDAndRadioName", "Radiologist", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            rpsRadio.DisplayMember = "UIDAndRadioName";
            rpsRadio.ValueMember = "EMP_ID";
            rpsRadio.DropDownRows = 5;
            rpsRadio.NullText = string.Empty;
            rpsRadio.DataSource = dttRadiologist;
            rpsRadio.BestFit();
            rpsRadio.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            viewExam.Columns["EMP_ID"].ColumnEdit = rpsRadio;
            viewExam.Columns["EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["EMP_ID"].Caption = "Radiologist";
            viewExam.Columns["EMP_ID"].Width = 150;
            viewExam.Columns["EMP_ID"].VisibleIndex = 9;

            viewExam.Columns["EMP_ID"].SummaryItem.FieldName = "TOTAL";
            viewExam.Columns["EMP_ID"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewExam.Columns["EMP_ID"].SummaryItem.DisplayFormat = "Total : {0}";

            viewExam.Columns["DELETE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["DELETE"].Caption = " ";
            viewExam.Columns["DELETE"].Width = 30;
            viewExam.Columns["DELETE"].VisibleIndex = 10;

        }
        private void fillDemographic()
        {
            if (patient != null)
            {
                txtHN.Text = patient.Reg_UID;
                txtFName.Text = patient.FirstName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;
                LookUpSelect lvS = new LookUpSelect();
                cboGender.SelectedIndex = patient.Gender == "M" ? 0 : 1;
                deLMP.ResetText();
                if (cboGender.SelectedIndex == 0)
                {
                    deLMP.BackColor = Color.FromArgb(227, 239, 255);
                    lblLMP.Visible = false;
                    deLMP.Visible = false;

                }
                else
                {
                    deLMP.BackColor = Color.White;
                    deLMP.DateTime = DateTime.Today;
                    lblLMP.Visible = true;
                    deLMP.Visible = true;
                }
                if (string.IsNullOrEmpty(patient.Phone1))
                    txtPhone.Text = patient.Phone2;
                else
                    txtPhone.Text = patient.Phone1 + "," + patient.Phone2;
                
                dtLastVisit.DateTime = string.IsNullOrEmpty(patient.Last_Modified_ON.ToString()) ? DateTime.Now : patient.Last_Modified_ON;
                dtNextVisit.DateTime = DateTime.Now.AddDays(1);
            }
            else
            {
                txtHN.Text = string.Empty;
             
            }
        }
        private void fillDataToCtrl(DataRow dr)
        {
            fillDemographic();
            DataRow[] rows;
            
            if (dr["SCHEDULE_STATUS"].ToString().ToUpper() == "O")
            {
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                groupTiming.Enabled = false;

                chkBlock.Enabled = false;
                txtInputReason.Properties.ReadOnly = true;
                barSave.Enabled = false;
            }
            else if((dr["IS_BLOCKED"].ToString() == "Y")){
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;

                dtStart.Enabled = false;
                dtEnd.Enabled = false;
                timeEnd.Enabled = false;
                timeStart.Enabled = false;

                txtInputReason.Properties.ReadOnly = false;
                chkBlock.Enabled = false;
                barSave.Enabled = true;
                is_blocked = true;
            }
            #region Group Visit.
            int id = 0;
            DataTable dtt = new DataTable();
            if (!string.IsNullOrEmpty(dr["REF_UNIT"].ToString()))
            {
                if (int.TryParse(dr["REF_UNIT"].ToString(), out id))
                {
                    ProcessGetHRUnit unit = new ProcessGetHRUnit();
                    unit.GetDataByID(id);
                    if (Utilities.IsHaveData(unit.Result))
                    {
                        txtOrderDept.Tag = unit.Result.Tables[0].Rows[0]["UNIT_ID"].ToString();
                        txtOrderDept.Text = unit.Result.Tables[0].Rows[0]["UNIT_UID"].ToString() + ":" + unit.Result.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                    }
                }

            }
            id = 0;
            if (!string.IsNullOrEmpty(dr["REF_DOC"].ToString()))
            {
                if (int.TryParse(dr["REF_DOC"].ToString(), out id))
                {
                    ProcessGetHISDoctor doc = new ProcessGetHISDoctor();
                    doc.getDataByID(id);
                    if (Utilities.IsHaveData(doc.Result))
                    {
                        txtOrderDoc.Tag = doc.Result.Tables[0].Rows[0]["EMP_ID"].ToString();
                        txtOrderDoc.Text = doc.Result.Tables[0].Rows[0]["EMP_UID"].ToString() + ":" + doc.Result.Tables[0].Rows[0]["RadioName"].ToString();
                    }
                }
            }
            #endregion

            #region Group Timing.
            dtStart.DateTime = start;
            dtEnd.DateTime = end;
            timeStart.Time = start;
            timeEnd.Time = end;
            txtAddTextInBlock.Text = dr["TEXT_SHOW"].ToString();
            #endregion
        }
        private void initGridHistory() {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dsHistorySchedule = process.GetLogSchedule(scheduleId);

            grdData.DataSource = dsHistorySchedule.Tables[0];

            int i = 0;
            for (; i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["LOGS_MODIFIED_ON"].ColVIndex = 1;
            view1.Columns["LOGS_MODIFIED_ON"].Caption = "วันที่แก้ไข";
            view1.Columns["LOGS_MODIFIED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            view1.Columns["LOGS_MODIFIED_ON"].Width = 120;

            view1.Columns["LOGS_MODIFIED_NAME"].ColVIndex = 2;
            view1.Columns["LOGS_MODIFIED_NAME"].Caption = "ผู้แก้ไข";
            view1.Columns["LOGS_MODIFIED_NAME"].Width = 170;

            view1.Columns["REASON"].ColVIndex = 3;
            view1.Columns["REASON"].Caption = "เหตุผล";
            view1.Columns["REASON"].Width = 260;

            view1.Columns["LOGS_DESC"].ColVIndex = 4;
            view1.Columns["LOGS_DESC"].Caption = "สถานะ";
            view1.Columns["LOGS_DESC"].Width = 120;

        }
        private void setLookupAllGrid()
        {
            DataTable dtPat = RISBaseData.RIS_PatStatus();
            grdLvPatStatus.Properties.DataSource = dtPat;
            grdLvPatStatus.Properties.DisplayMember = "STATUS_TEXT";
            grdLvPatStatus.Properties.ValueMember = "STATUS_ID";
            if (dtPat.Rows.Count > 0)
            {
                grdLvPatStatus.EditValue = dtPat.Rows[0]["STATUS_ID"].ToString();
            }
            setGridLookupPat();

            
            grdLvInsurance.Properties.DataSource = dtInsu;
            grdLvInsurance.Properties.DisplayMember = "INSURANCE_TYPE_DESC";
            grdLvInsurance.Properties.ValueMember = "INSURANCE_TYPE_ID";
            setGridLookupInsu();
        }
        private void setGridLookupPat()
        {
            viewPat.OptionsView.ShowAutoFilterRow = true;

            viewPat.Columns["STATUS_ID"].Visible = false;
            viewPat.Columns["STATUS_UID"].Visible = false;
            viewPat.Columns["STATUS_TEXT"].Visible = true;
            viewPat.Columns["IS_ACTIVE"].Visible = false;
            viewPat.Columns["ORG_ID"].Visible = false;
            viewPat.Columns["CREATED_BY"].Visible = false;
            viewPat.Columns["CREATED_ON"].Visible = false;
            viewPat.Columns["LAST_MODIFIED_BY"].Visible = false;
            viewPat.Columns["LAST_MODIFIED_ON"].Visible = false;
            viewPat.Columns["IS_DEFAULT"].Visible = false;


            viewPat.Columns["STATUS_TEXT"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewPat.Columns["STATUS_TEXT"].Caption = "Status";

        }
        private void setGridLookupInsu()
        {
            viewInsu.OptionsView.ShowAutoFilterRow = true;

            viewInsu.Columns["INSURANCE_TYPE_ID"].Visible = false;
            viewInsu.Columns["INSURANCE_TYPE_UID"].Visible = false;
            viewInsu.Columns["INSURANCE_TYPE_DESC"].Visible = true;
            viewInsu.Columns["ORG_ID"].Visible = false;
            viewInsu.Columns["CREATED_BY"].Visible = false;
            viewInsu.Columns["CREATED_ON"].Visible = false;
            viewInsu.Columns["LAST_MODIFIED_BY"].Visible = false;
            viewInsu.Columns["LAST_MODIFIED_ON"].Visible = false;

            viewInsu.Columns["INSURANCE_TYPE_DESC"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewInsu.Columns["INSURANCE_TYPE_DESC"].Caption = "Insurance";
        }
        private void setTextInfo() {
            txtHNInfo.Text = string.Empty;
            txtPatientNameInfo.Text = string.Empty;
            txtModalityInfo.Text = string.Empty;
            cmbExam.Text = string.Empty;
            txtStartInfo.Text = string.Empty;
            txtEndInfo.Text = string.Empty;
            txtDepartmentInfo.Text = string.Empty;
            txtDoctorInfo.Text = string.Empty;
        }
        private string ModalityName(string ID)
        {
            string name = string.Empty;
            ProcessGetRISModality process = new ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            if (dr.Length > 0)
                name = dr[0]["MODALITY_NAME"].ToString();
            return name;
        }

        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                txtHNInfo.Text = dr["HN"].ToString();
                txtPatientNameInfo.Text = dr["PATIENT_NAME"].ToString();
                txtModalityInfo.Text = dr["MODALITY_NAME"].ToString();
                txtStartInfo.Text = dr["START_DATETIME"].ToString();
                txtEndInfo.Text = dr["END_DATETIME"].ToString();
                txtDepartmentInfo.Text = dr["REF_UNIT_NAME"].ToString();
                txtDoctorInfo.Text = dr["REF_DOC_NAME"].ToString();

                cmbExam.Properties.Items.Clear();
                ComboBoxItemCollection colls = cmbExam.Properties.Items;
                colls.BeginUpdate();
                try
                {
                    DataRow[] rowsExam = dsHistorySchedule.Tables[1].Select("SCHEDULELOG_ID=" + dr["SCHEDULELOG_ID"].ToString());
                    foreach (DataRow drr in rowsExam)
                        colls.Add(new Exam_items(string.IsNullOrEmpty(drr["EXAM_ID"].ToString()) ? 0 : Convert.ToInt32(drr["EXAM_ID"])
                            , string.IsNullOrEmpty(drr["EXAM_UID"].ToString()) ? "" : drr["EXAM_UID"].ToString()
                            , string.IsNullOrEmpty(drr["EXAM_NAME"].ToString()) ? "" : drr["EXAM_NAME"].ToString()));
                }
                finally
                {
                    colls.EndUpdate();
                }
                cmbExam.SelectedIndex = 0;


            }
        }
        private void reasonLookup_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInputReason.Tag = retValue[0];
            txtInputReason.Text = retValue[2];
        }

        private bool checkConflict(DataTable all_Exam, DateTime datetime_start)
        {
            bool flag = false;
            ScheduleInfo schCheckConflictTime = new ScheduleInfo();
            DataTable dataConflictTime = new DataTable();
            DataTable dataConflictAll = new DataTable();
            foreach (DataRow row in all_Exam.Rows)
            {
                if (row["EXAM_ID"].ToString().Trim() != string.Empty)
                {
                    schCheckConflictTime.IsHaveAppointment(patient.Reg_UID, Convert.ToInt32(row["EXAM_ID"]), datetime_start, out dataConflictTime);
                    dataConflictAll.Merge(dataConflictTime);
                }
            }
            // popup Conflict form
            //if (dataConflictTime.Rows.Count > 0)
            //{
            //    flag = true;
            //    frmScheduleConflictDetail frmConflictDetail = new frmScheduleConflictDetail(dataConflictTime);
            //    frmConflictDetail.ShowDialog();
            //}
            return flag;
        }
        private void btnReason_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(reasonLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General2", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dxErrorProvider1.HasErrors) return;
            if (txtInputReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                txtInputReason.Focus();
                return;
            }
            if (txtClinicType.Text.Trim().Length == 0)
            {
                if (!is_blocked && this.Text != "ลบข้อมูล")
                {
                    dxErrorProvider1.SetError(txtClinicType, "Please select session", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    txtClinicType.Focus();
                    return;
                }
            }

            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
            proc.UpdateSessionID(txtClinicType.Tag == null ? Convert.ToInt32(session_id) : Convert.ToInt32(txtClinicType.Tag), scheduleId);
            proc.UpdateTextShow(txtAddTextInBlock.Text.Trim(), scheduleId);

            string patient_id_label = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "" : "[" + patient.PATIENT_ID_LABEL + "]";
            if (dttExam.Rows.Count == 1)
            {
                if (!string.IsNullOrEmpty(dttExam.Rows[0]["EXAM_ID"].ToString()))
                {
                    TextINBlock = "HN : " + txtHN.Text + patient_id_label + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                    DataRow[] rs = dataAllExam.Select("EXAM_ID=" + dttExam.Rows[0]["EXAM_ID"].ToString());
                    TextINBlock += "; " + rs[0]["EXAM_NAME"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dttExam.Rows[0]["EMP_ID"].ToString()))
                        TextINBlock += " (" + getRadilogyName(dttExam.Rows[0]["EMP_ID"].ToString()) + ") ";
                }
            }
            else
            {
                TextINBlock = "HN : " + txtHN.Text + patient_id_label + " " + patient.Title + txtFName.Text.Trim() + " " + txtLName.Text.Trim();
                TextINBlock += "; ";
                foreach (DataRow dr in dttExam.Rows)
                {
                    if (string.IsNullOrEmpty(dr["EXAM_ID"].ToString())) break;
                    DataRow[] rs = dataAllExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    TextINBlock += rs[0]["EXAM_NAME"].ToString().Trim();// +"; ";
                    if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()))
                        TextINBlock += " (" + getRadilogyName(dr["EMP_ID"].ToString()) + ") ; ";
                    else
                        TextINBlock += "; ";
                }
                TextINBlock = TextINBlock.Remove(TextINBlock.LastIndexOf(';'), 1);
            }

            if (txtAddTextInBlock.Text.Trim().Length != 0)
            {
                string log_msg = txtAddTextInBlock.Text.Trim();
                log_msg = " (" + log_msg + ") ";

                TextINBlock += log_msg;
            }

            #region Update Exam.
            foreach (DataRow dr in dttExam.Rows)
            {
                if (string.IsNullOrEmpty(dr["EXAM_ID"].ToString())) break;
                ProcessUpdateRISScheduledtl procUp = new ProcessUpdateRISScheduledtl();
                procUp.RIS_SCHEDULEDTL.AVG_REQ_MIN = Convert.ToInt32(dr["AVG_REQ_MIN"].ToString());
                procUp.RIS_SCHEDULEDTL.BPVIEW_ID = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["BPVIEW_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.LAST_MODIFIED_BY = env.UserID;
                procUp.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.GEN_DTL_ID = string.IsNullOrEmpty(dr["GEN_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["GEN_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                procUp.RIS_SCHEDULEDTL.PREPARATION_ID = string.IsNullOrEmpty(dr["PREPATION_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["PREPATION_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.QTY = Convert.ToInt32(dr["QTY"].ToString());
                procUp.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(dr["EMP_ID"].ToString().Trim()) ? 0 : Convert.ToInt32(dr["EMP_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(dr["RATE"].ToString());
                procUp.RIS_SCHEDULEDTL.SCHEDULE_ID = scheduleId;
                procUp.RIS_SCHEDULEDTL.OLD_EXAM_ID = Convert.ToInt32(dr["OLD_EXAM_ID"].ToString());
                procUp.RIS_SCHEDULEDTL.REASON = txtInputReason.Text.Trim();
                procUp.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = dr["SCHEDULE_PRIORITY"].ToString();
                procUp.Invoke();
            }
            #endregion

            //if (checkConflict(dttExam, start))
            //    return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(clicnicLookup_ValueUpdated);
            lv.AddColumn("SESSION_ID", "SESSION_ID", false, true);
            lv.AddColumn("SESSION_UID", "Code", true, true);
            lv.AddColumn("SESSION_NAME", "Session Name", true, true);
            lv.AddColumn("CLINIC_TYPE_ID", "CLINIC_TYPE_ID", false, true);
            lv.AddColumn("START_TIME", "START_TIME", false, true);
            lv.AddColumn("END_TIME", "END_TIME", false, true);
            lv.Text = "Session Search";

            lv.Data = lvS.SelectSession().Tables[0].Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }
        private void clicnicLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            #region Check Portable
            foreach (DataRow row in dttExam.Rows)
            {
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString())) break;
                ProcessGetRISExam chkPort = new ProcessGetRISExam();
                DataTable dtPort = chkPort.GetExamPanelPortable(Convert.ToInt32(row["EXAM_ID"]), clinictype);
                if (Utilities.IsHaveData(dtPort))
                {
                    DataRow[] rowChk = dttExam.Select("EXAM_ID=" + dtPort.Rows[0]["AUTO_EXAM_ID"].ToString());
                    if (rowChk.Length > 0)
                    {
                        DataTable dtPortUpdate = chkPort.GetExamPanelPortable(Convert.ToInt32(row["EXAM_ID"]), Convert.ToInt32(retValue[3].ToString()));
                        if (Utilities.IsHaveData(dtPortUpdate))
                        {
                            rowChk[0]["EXAM_ID"] = dtPortUpdate.Rows[0]["AUTO_EXAM_ID"];
                            rowChk[0]["EXAM_UID"] = dtPortUpdate.Rows[0]["AUTO_EXAM_ID"];
                            rowChk[0]["EXAM_NAME"] = dtPortUpdate.Rows[0]["AUTO_EXAM_ID"];
                        }
                    }
                }
            }
            #endregion
            txtClinicType.Tag = retValue[0];
            txtClinicType.Text = retValue[2];
            clinictype = Convert.ToInt32(retValue[3].ToString());

            start_session = Convert.ToDateTime(retValue[4]);
            end_session = Convert.ToDateTime(retValue[5]);

            #region Check time
                doDateValidated();
                if (dxErrorProvider1.HasErrors == false) doTimerValidated();
            #endregion

            object obj = txtClinicType.Tag;
            if (obj == null) return;
            DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + clinictype.ToString());
            string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
            foreach (DataRow row in dttExam.Rows)
            {
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString())) continue;
                DataRow[] rs = dataAllExam.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL":
                        row["RATE"] = patient.NON_RESIDENCE == "Y" ? rs[0]["FOREIGN_SPCIAL_RATE"].ToString() : rs[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        row["RATE"] = patient.NON_RESIDENCE == "Y" ? rs[0]["FOREIGN_VIP_RATE"].ToString() : rs[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        row["RATE"] = patient.NON_RESIDENCE == "Y" ? rs[0]["FOREIGN_RATE"].ToString() : rs[0]["RATE"].ToString();
                        break;
                }

            }
            dttExam.AcceptChanges();
            calTotal();

        }
        private void calTotal()
        {
            decimal total = 0.0M;
            DataTable dtt = (DataTable)grdExam.DataSource;
            foreach (DataRow dr in dtt.Rows)
            {
                decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);
                total = taxTemp * qty;
                dr["TOTAL"] = total;
            }
        }

        private void timeStart_EditValueChanged(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }

        private void doTimerValidated()
        {
            if (is_blocked) return;
            if (this.Text == "ลบข้อมูล") return;
            DateTime tsStart = (DateTime)timeStart.EditValue;
            tsStart = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, tsStart.Hour, tsStart.Minute, tsStart.Second);

            DateTime tsEnd = (DateTime)timeEnd.EditValue;
            tsEnd = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, tsEnd.Hour, tsEnd.Minute, tsEnd.Second);

            timeStart.EditValue = tsStart;
            timeEnd.EditValue = tsEnd;
            if ((timeStart.Time > timeEnd.Time) || (timeEnd.Time < timeStart.Time))
            {
                dxErrorProvider1.SetError(timeStart, "more than end time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(timeEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
                dxErrorProvider1.ClearErrors();

            #region Check time
            if (timeStart.Time.TimeOfDay.TotalMilliseconds < start_session.TimeOfDay.TotalMilliseconds ||
                timeStart.Time.TimeOfDay.TotalMilliseconds > end_session.TimeOfDay.TotalMilliseconds)
            {
                dxErrorProvider1.SetError(timeStart, "time over session time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(timeEnd, "time over session time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
            {
                dxErrorProvider1.ClearErrors();
                if (timeStart.Time.TimeOfDay.TotalMilliseconds > timeEnd.Time.TimeOfDay.TotalMilliseconds)
                    dxErrorProvider1.SetError(timeEnd, "time over session time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            #endregion
        }
        private void doDateValidated()
        {
            if (is_blocked) return;
            if (this.Text == "ลบข้อมูล") return;
            if (string.IsNullOrEmpty(dtStart.Text))
            {
                dxErrorProvider1.SetError(dtStart, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dtStart.ErrorText = string.Empty;
            if (string.IsNullOrEmpty(dtEnd.Text))
            {
                dxErrorProvider1.SetError(dtEnd, "cannot empty", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dtEnd.ErrorText = string.Empty;

            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day);  //dtStart.DateTime;
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day);    //dtEnd.DateTime;
            if (start > end)
            {
                dxErrorProvider1.SetError(dtStart, "date start more than end date", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(dtEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                return;
            }
            else
                dxErrorProvider1.ClearErrors();



        }

        private string getRadilogyName(string EMP_ID)
        {
            string name = string.Empty;

            DataRow[] rs = dttDoctor.Select("EMP_ID=" + EMP_ID);
            if (rs.Length > 0)
                name = rs[0]["FNAME"].ToString() + " " + rs[0]["LNAME"].ToString();
            return name;
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdExam)
                {
                    GridView view = grdExam.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "FLAG_ICON":
                                    if (rowDetail["FLAG_ICON"].ToString() == "1")
                                    {
                                        DataRow[] rowFlag = dtExamFlagDTL.Select("GEN_DTL_ID=" + rowDetail["EXAMFLAG_ID"].ToString());
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowFlag[0]["GEN_TEXT"].ToString());
                                        return;
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            case "PRIORITY": info = new ToolTipControlInfo(hi.HitTest, "Priority"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }

        

    }
}