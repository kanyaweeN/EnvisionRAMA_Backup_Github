using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.Common.Common;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;
using DevExpress.XtraScheduler;

namespace RIS.Forms.Schedule
{
    public partial class ConfirmDialog : Form
    {
        private string id;
        private string modality_id;
        private DateTime start;
        private DateTime end;
        private Patient patient;
        private DataTable dttSession;
        private Appointment apt;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private int clinictype;

        public ConfirmDialog() {
            InitializeComponent();
        }
        public ConfirmDialog(string ID,string MODALITY_ID,DateTime DTStart,DateTime DTEnd)
        {
            InitializeComponent();
            id = ID;
            modality_id = MODALITY_ID;
            start = DTStart;
            end = DTEnd;
            cboGender.Properties.Items.Clear();
            cboGender.Properties.Items.Add("Male");
            cboGender.Properties.Items.Add("Female");
            cboGender.SelectedIndex = 0;
            initDataToCtrl();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");
        }

        private void initDataToCtrl() {
            ProcessGetRISClinictype process = new RIS.BusinessLogic.ProcessGetRISClinictype();
            process.Invoke();
            DataTable dtt = process.Result.Tables[0];
            DataRow[] dr = dtt.Select("IS_DEFAULT='Y'");

            ProcessGetRISSchedule proc=new ProcessGetRISSchedule();
            DataTable dt = proc.GetScheduleData();
            DataRow[] drSchedule = dt.Select("SCHEDULE_ID = " + id);
            string hn = drSchedule[0]["HN"].ToString();
            patient = new RIS.BusinessLogic.Patient(hn, true);
            fillDataToCtrl(drSchedule[0]);

            ProcessGetRISClinicsession prcCln = new ProcessGetRISClinicsession();
            dttSession = prcCln.GetClinicSession().Copy();
            string session_id = "";
            if (string.IsNullOrEmpty(drSchedule[0]["SESSION_ID"].ToString()))
            {
                session_id = "2";
            }
            else
            {
                session_id = drSchedule[0]["SESSION_ID"].ToString();

            }
                DataRow[] drr = dttSession.Select("SESSION_ID = " + session_id);
                if (dr.Length > 0)
                {
                    txtClinicType.Tag = drr[0]["SESSION_ID"].ToString();
                    txtClinicType.Text = drr[0]["SESSION_NAME"].ToString();
                    clinictype = Convert.ToInt32(drr[0]["CLINIC_TYPE_ID"]);

                }
            
            DataTable dttOrder = order.His_Doctor();
            if (string.IsNullOrEmpty(drSchedule[0]["RAD_ID"].ToString()))
            {
                txtRadiologist.Text = "";
            }
            else if (drSchedule[0]["RAD_ID"].ToString() == "0")
            {
                txtRadiologist.Text = "";
            }
            else
            {
                DataRow[] drOrderSelect = dttOrder.Select("EMP_ID=" + drSchedule[0]["RAD_ID"].ToString());
                        txtRadiologist.Tag = drSchedule[0]["RAD_ID"].ToString();
                        txtRadiologist.Text = drOrderSelect[0]["RadioName"].ToString();
            }
            if (string.IsNullOrEmpty(drSchedule[0]["RATE"].ToString()))
            {
                txtRate.Text = "0";
            }
            else
            {
                txtRate.Text = drSchedule[0]["RATE"].ToString();
            }
            if (string.IsNullOrEmpty(drSchedule[0]["QTY"].ToString()))
            {
                speQTY.Value = 1;
            }
            else
            {
                speQTY.Value = Convert.ToInt32(drSchedule[0]["QTY"]);
            }
            double SumTotal = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(speQTY.Value);
            txtTotal.Text = SumTotal.ToString("#,##0.00");
            if (cboGender.SelectedIndex == 0)
            {
                lblLMP.Visible = false;
                deLMP.Visible = false;
                deLMP.BackColor = Color.FromArgb(227, 239, 255);
            }
            else
            {
                lblLMP.Visible = true;
                deLMP.Visible = true;
                deLMP.Enabled = false;
                deLMP.BackColor = Color.FromArgb(227, 239, 255);

                if (string.IsNullOrEmpty(drSchedule[0]["LMP_DT"].ToString()))
                {
                    deLMP.DateTime = DateTime.Now;
                }
                else if (Convert.ToDateTime(drSchedule[0]["LMP_DT"]) == DateTime.MinValue)
                {
                    deLMP.DateTime = DateTime.Now;
                }
                else
                {
                    deLMP.DateTime = Convert.ToDateTime(drSchedule[0]["LMP_DT"]);
                }
            }
            txtModality.Text = ModalityName(modality_id);
            txtUserName.Text = env.FirstName + " " + env.LastName;
            SetLookupAllGrid();
            SetGridLookupPat();
            grdLvPatStatus.EditValue = drSchedule[0]["PAT_STATUS"];
            initGridHistory();
        }
        private void fillDemographic()
        {
            if (patient != null)
            {
                txtHN.Text = patient.Reg_UID;
                txtFName.Text = patient.FirstName;
                txtMName.Text = patient.MiddleName;
                txtLName.Text = patient.LastName;
                txtFName_Eng.Text = patient.FirstName_ENG;
                txtMName_Eng.Text = patient.MiddleName_ENG;
                txtLName_Eng.Text = patient.LastName_ENG;
                txtID.Text = patient.SocialNumber;
                dtDOB.DateTime = string.IsNullOrEmpty(patient.DateOfBirth.ToString()) ? DateTime.Now : patient.DateOfBirth;
                LookUpSelect lvS = new LookUpSelect();
                if (patient.DateOfBirth == DateTime.MinValue)
                {
                    dtDOB.DateTime = DateTime.Now;
                }
                txtAGE.Text = lvS.SelectAGE(dtDOB.DateTime).Tables[0].Rows[0]["AGE"].ToString() ;
                
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
                txtPhone.Text = patient.Phone1;
                txtMobile.Text = patient.Phone2;
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

            #region Group Exam.
            DataRow[] drExam;
            if (!string.IsNullOrEmpty(dr["EXAM_ID"].ToString()))
            {
                int exam_id = Convert.ToInt32(dr["EXAM_ID"].ToString());
                RIS.BusinessLogic.ProcessGetRISExam process = new RIS.BusinessLogic.ProcessGetRISExam(true);
                process.Invoke();

                DataTable dttExam = process.Result.Tables[0].Copy();
                drExam = dttExam.Select("EXAM_ID=" + exam_id.ToString());
                txtExamUID.Tag = drExam[0]["EXAM_ID"].ToString();
                txtExamUID.Text = drExam[0]["EXAM_UID"].ToString();
                txtExamName.Text = drExam[0]["EXAM_NAME"].ToString();
                txtRate.Text = drExam[0]["RATE"].ToString();
            }
            #endregion

            #region Group Timing.
            //DateTime start = Convert.ToDateTime(dr["START_DATETIME"].ToString());
            //DateTime end = Convert.ToDateTime(dr["END_DATETIME"].ToString());
            dtStart.DateTime = start;
            dtEnd.DateTime = end;
            timeStart.Time = start;
            timeEnd.Time = end;
            txtReason.Text = dr["REASON"].ToString();
            #endregion

            #region Group Visit.
            int id = 0;
            DataTable dtt = new DataTable();
            if (!string.IsNullOrEmpty(dr["REF_UNIT"].ToString()))
            {
                if (int.TryParse(dr["REF_UNIT"].ToString(), out id))
                {
                    RIS.BusinessLogic.ProcessGetHRUnit unit = new RIS.BusinessLogic.ProcessGetHRUnit();
                    unit.Invoke();
                    dtt = unit.Result.Tables[0].Copy();
                    drExam = dtt.Select("UNIT_ID=" + id.ToString());
                    if (drExam.Length > 0)
                    {
                        txtOrderDept.Tag = drExam[0]["UNIT_ID"].ToString();
                        txtOrderDept.Text = drExam[0]["UNIT_NAME"].ToString();
                    }
                }

            }
            id = 0;
            if (!string.IsNullOrEmpty(dr["REF_DOC"].ToString()))
            {
                if (int.TryParse(dr["REF_DOC"].ToString(), out id))
                {
                    RIS.BusinessLogic.ProcessGetHISDoctor doc = new RIS.BusinessLogic.ProcessGetHISDoctor();
                    doc.Invoke();
                    dtt = doc.Result.Tables[0].Copy();
                    drExam = dtt.Select("EMP_ID=" + id.ToString());
                    if (drExam.Length > 0)
                    {
                        txtOrderDoc.Tag = drExam[0]["EMP_ID"].ToString();
                        txtOrderDoc.Text = drExam[0]["RadioName"].ToString();
                    }
                }
            }
            #endregion

            if (dr["SCHEDULE_STATUS"].ToString().ToUpper() == "O")
            {
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;

                groupTiming.Enabled = false;

                chkBlock.Enabled = false;
                btnSave.Enabled = false;
                txtInputReason.Properties.ReadOnly = true;
                btnSave.Enabled = false;
            }
            else if((dr["IS_BLOCK"].ToString() == "Y")){
                groupPatient.Enabled = false;
                groupVisit.Enabled = false;
                groupExam.Enabled = false;
                txtExamUID.BackColor = txtModality.BackColor;
                txtExamName.BackColor = txtModality.BackColor;

                groupTiming.Enabled = false;
                txtInputReason.Properties.ReadOnly = false;
                chkBlock.Enabled = false;
                btnSave.Enabled = true;
               
            }

        }
        private void initGridHistory() {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            DataSet ds = process.GetLogSchedule(Convert.ToInt32(id));
            grdData.DataSource = ds.Tables[0];

            int i = 0;
            for (;i < view1.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["DATEEDIT"].Visible = true;
            view1.Columns["DATEEDIT"].Caption = "วันที่แก้ไข";
            view1.Columns["DATEEDIT"].Width = 100;

            view1.Columns["EDITBY"].Visible = true;
            view1.Columns["EDITBY"].Caption = "ผู้แก้ไข";
            view1.Columns["EDITBY"].Width = 200;

            view1.Columns["REASON"].Visible = true;
            view1.Columns["REASON"].Caption = "เหตุผล";
            view1.Columns["REASON"].Width = 280;

            view1.Columns["STATUS"].Visible = true;
            view1.Columns["STATUS"].Caption = "สถานะ";
            view1.Columns["STATUS"].Width = 80;
        }
        private string ModalityName(string ID)
        {
            string name = string.Empty;
            RIS.BusinessLogic.ProcessGetRISModality process = new RIS.BusinessLogic.ProcessGetRISModality(true);
            process.Invoke();
            DataTable dttModaltiy = new DataTable();
            dttModaltiy = process.Result.Tables[0].Copy();
            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + ID);
            if (dr.Length > 0)
                name = dr[0]["MODALITY_NAME"].ToString();
            return name;
        }

        public string REASON {
            get { return txtInputReason.Text.Trim(); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInputReason.Text.Trim().Length == 0) {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                txtInputReason.Focus();
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void setTextInfo() {
            txtHNInfo.Text = string.Empty;
            txtPatientNameInfo.Text = string.Empty;
            txtModalityInfo.Text = string.Empty;
            txtExamNameInfo.Text = string.Empty;
            txtStartInfo.Text = string.Empty;
            txtEndInfo.Text = string.Empty;
            txtDepartmentInfo.Text = string.Empty;
            txtDoctorInfo.Text = string.Empty;
        }

        private void view1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr= view1.GetDataRow(view1.FocusedRowHandle);
            if (dr != null) {
                txtHNInfo.Text = dr["HN"].ToString();
                txtPatientNameInfo.Text = dr["PATIENTNAME"].ToString();
                txtModalityInfo.Text = dr["MODALITY_NAME"].ToString();
                txtExamNameInfo.Text = dr["EXAM_NAME"].ToString();
                txtStartInfo.Text = dr["START_DATETIME"].ToString();
                txtEndInfo.Text = dr["END_DATETIME"].ToString();
                txtDepartmentInfo.Text = dr["UNIT_NAME"].ToString();
                txtDoctorInfo.Text = dr["DOCTORNAME"].ToString();
            }
        }

        private void btnReason_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            RIS.Forms.Lookup.LookupData lv = new RIS.Forms.Lookup.LookupData();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(reasonLookup_ValueUpdated);
            lv.AddColumn("GEN_DTL_ID", "ID", false, true);
            lv.AddColumn("GEN_TITLE", "Project Title", true, true);
            lv.AddColumn("GEN_TEXT", "Rate", true, true);
            lv.Text = "Project Search";

            lv.Data = lvS.ScheduleHaveParameter("General2", env.CurrentLanguageID).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void reasonLookup_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInputReason.Tag = retValue[0];
            txtInputReason.Text = retValue[2];
        }
        private void SetLookupAllGrid()
        {
            DataTable dtPat = order.RIS_PatStatus();
            grdLvPatStatus.Properties.DataSource = dtPat;
            grdLvPatStatus.Properties.DisplayMember = "STATUS_TEXT";
            grdLvPatStatus.Properties.ValueMember = "STATUS_ID";
            if (dtPat.Rows.Count > 0)
            {
                grdLvPatStatus.EditValue = dtPat.Rows[0]["STATUS_ID"].ToString();
            }
            SetGridLookupPat();
        }
        private void SetGridLookupPat()
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
    }
}