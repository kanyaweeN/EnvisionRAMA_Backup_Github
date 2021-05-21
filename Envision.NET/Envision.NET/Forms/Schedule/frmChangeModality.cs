using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracle.Util;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;

using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic.ProcessCreate;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmChangeModality : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable dttAppointment;
        private int scheduleID;
        private int modalityID;
        private bool isblock;
        private DateTime start_session, end_session;
        private DataTable dttExam;
        private DataTable dataAllExam = RISBaseData.Ris_Exam();
        private DataTable dttModality;
        private DataTable dttSession;
        private DataTable dttExamFlag, dtExamFlagDTL;
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private string sessionID;
        private bool IS_FOREIGNER;
        private int CLINIC_TYPE_ID;
        public frmChangeModality()
        {
            InitializeComponent();
        }
        public frmChangeModality(int ScheduleID, DataTable DataAppointment)
        {
            InitializeComponent();
            scheduleID = ScheduleID;
            dttAppointment = DataAppointment;
        }

        private void frmChangeModality_Load(object sender, EventArgs e)
        {
            initiateData();
            initiateGrid();
            initiatePossibleModaltiy();
            setTrauma();
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.SCHEDULE_ID = scheduleID == 0 ? -1 : scheduleID;
            prc.InvokeSchedule();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();
        }
        private void doTimerValidated()
        {
            if (isblock) return;
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
            if (isblock) return;
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
        private string ModalityName(int ID)
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
        private void initiateData() {
            ProcessGetRISClinicsession prcCln = new ProcessGetRISClinicsession();
            dttSession = prcCln.GetClinicSession().Copy();

            ProcessGetRISSchedule process = new ProcessGetRISSchedule(scheduleID);
            process.Invoke();
            if (Utilities.IsHaveData(process.Result))
            {
                DataRow row = process.Result.Tables[0].Rows[0];
                txtHN.EditValue = row["HN"].ToString().Trim();
                modalityID = Convert.ToInt32(row["MODALITY_ID"].ToString());
                DateTime dtStart = Convert.ToDateTime(row["START_DATETIME"]);
                DateTime dtEnd = Convert.ToDateTime(row["END_DATETIME"]);
                txtName.EditValue = row["NAME"].ToString();
                txtModality.EditValue = ModalityName(modalityID);
                txtStart.EditValue = dtStart.ToShortDateString() + " " + dtStart.ToLongTimeString();
                txtEnd.EditValue = dtEnd.ToShortDateString() + " " + dtEnd.ToLongTimeString();
                isblock = row["IS_BLOCKED"].ToString() == "Y" ? true : false;
                IS_FOREIGNER = row["IS_FOREIGNER"].ToString() == "Y" ? true : false;
                CLINIC_TYPE_ID = Convert.ToInt32(row["CLINIC_TYPE_ID"]);
                start_session = Convert.ToDateTime(row["START_TIME"]);
                end_session = Convert.ToDateTime(row["END_TIME"]);
                sessionID = row["SESSION_ID"].ToString();
                txtAddTextInBlock.Text = row["TEXT_SHOW"].ToString();
                //txtSession.Tag = row["SESSION_ID"].ToString();
                //txtSession.Text = row["SESSION_NAME"].ToString();

                dtEnd = dtEnd.AddSeconds(1);
                this.dtStart.DateTime = dtStart;
                this.dtEnd.DateTime = dtEnd;
                this.timeStart.EditValue = dtStart;
                this.timeEnd.EditValue = dtEnd;
                dttExam = new DataTable();
                dttExam = process.Result.Tables[1].Copy();
            }
            else
                barSave.Enabled = false;
        }
        private void initiateGrid() {
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
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EXAM_NAME", "Exam Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
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
            rleBPView.DataSource = RISBaseData.BP_View();
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

            #region Repository Avg req min
            DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit rpsReq = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            rpsReq.AutoHeight = false;
            rpsReq.IsFloatValue = false;
            rpsReq.Mask.EditMask = "N00";
            rpsReq.MinValue = 0;
            rpsReq.MaxValue = 2000;
            #endregion
            viewExam.Columns["AVG_REQ_MIN"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["AVG_REQ_MIN"].Caption = "Avg(Minute)";
            viewExam.Columns["AVG_REQ_MIN"].Width = 90;
            viewExam.Columns["AVG_REQ_MIN"].VisibleIndex = 7;
            viewExam.Columns["AVG_REQ_MIN"].ColumnEdit = rpsReq;

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
            rpsRadio.DataSource = RISBaseData.Ris_Radiologist();
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

            #region Repository Delete
            RepositoryItemButtonEdit btnDel = new RepositoryItemButtonEdit();
            btnDel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            btnDel.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete;
            btnDel.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            #endregion
            viewExam.Columns["DELETE"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            viewExam.Columns["DELETE"].Caption = " ";
            viewExam.Columns["DELETE"].Width = 30;
            viewExam.Columns["DELETE"].VisibleIndex = 10;
            viewExam.Columns["DELETE"].ColumnEdit = btnDel;
        }
        private void initiatePossibleModaltiy()
        {
            if (isblock)
            {
                ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                dttModality = new DataTable();
                dttModality = process.GetModality();

                #region OLDCODE.
                //ProcessGetRISModality moProc = new ProcessGetRISModality();
                //moProc.Invoke();
                //dttModality = new DataTable();
                //dttModality= moProc.Result.Tables[0].Copy(); 
                #endregion

                AutoCompleteStringCollection molCollection = new AutoCompleteStringCollection();
                for (int i = 0; i < dttModality.Rows.Count; i++)
                    molCollection.Add(dttModality.Rows[i]["MODALITY_NAME"].ToString().Trim());
                txtNewModality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNewModality.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNewModality.AutoCompleteCustomSource = molCollection;
            }
            else
            {
                #region Find Right Modality.
                ProcessGetRISModalityexam proc = new ProcessGetRISModalityexam(true);
                proc.Invoke();
                DataTable dtAll = proc.Result.Tables[0].Copy();

                DataTable dtt = new DataTable();
                dtt.Columns.Add("ID");
                dtt.AcceptChanges();
                DataRow[] rows;
                foreach (DataRow dr in dttExam.Rows)
                {
                    rows = dtAll.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    for (int i = 0; i < rows.Length; i++)
                    {
                        DataRow nw = dtt.NewRow();
                        nw[0] = rows[i]["MODALITY_ID"].ToString();
                        dtt.Rows.Add(nw);
                    }
                }
                dtt.AcceptChanges();
                DataView view = new DataView(dtt);
                DataTable distinctValues = view.ToTable(true, "ID");

                //List<int> molID = new List<int>();
                //int count = dttExam.Rows.Count;
                //foreach (DataRow row in dtt.Rows)
                //{
                //    DataView dv = dtt.DefaultView;
                //    dv.RowFilter = "ID=" + row[0];
                //    DataTable dtTemp = dv.ToTable();
                //    if (dtTemp.Rows.Count == count)
                //    {
                //        if (molID.IndexOf(Convert.ToInt32(row[0].ToString())) == -1)
                //            molID.Add(Convert.ToInt32(row[0].ToString()));
                //    }
                //    //rows = dtt.Select("ID=" + row[0]);
                //    //if (rows.Length == count)
                //    //{
                //    //    if (molID.IndexOf(Convert.ToInt32(row[0].ToString())) == -1)
                //    //        molID.Add(Convert.ToInt32(row[0].ToString()));
                //    //}
                //}
                #endregion

                #region Modality DataTable.
                ProcessGetRISModality moProc = new ProcessGetRISModality();
                moProc.Invoke();
                dtt = new DataTable();
                dtt = moProc.Result.Tables[0].Copy();
                dttModality = new DataTable();
                dttModality = dtt.Clone();
                foreach (DataRow mol in distinctValues.Rows)
                {
                    rows = dtt.Select("MODALITY_ID=" + mol["ID"].ToString());
                    if (rows.Length == 0) continue;
                    DataRow nw = dttModality.NewRow();
                    for (int i = 0; i < dtt.Columns.Count; i++) nw[i] = rows[0][i];
                    dttModality.Rows.Add(nw);
                }
                dttModality.AcceptChanges();
                AutoCompleteStringCollection molCollection = new AutoCompleteStringCollection();
                for (int i = 0; i < dttModality.Rows.Count; i++)
                    molCollection.Add(dttModality.Rows[i]["MODALITY_NAME"].ToString().Trim());
                txtNewModality.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtNewModality.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNewModality.AutoCompleteCustomSource = molCollection;
                #endregion
            }
        }
        private bool requireCheckFreeTime()
        {

            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            int max_app = 0;
            int curr_app = 0;
            DateTime dtsTmp = DateTime.Today;
            DateTime dteTmp = DateTime.Today;
            DataRow[] drs;
            #region ตรวจสอบว่าช่วงเวลาที่เลือกตรงกับ Session หรือไม่
                if (sessionID != null)
                {
                    if (!string.IsNullOrEmpty(sessionID))
                    {
                        drs = dttSession.Select("SESSION_ID=" + sessionID);
                        if (drs.Length > 0)
                        {
                            dtsTmp = Convert.ToDateTime(drs[0]["START_TIME"]);
                            dtsTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dtsTmp.Hour, dtsTmp.Minute, 0);
                            dteTmp = Convert.ToDateTime(drs[0]["END_TIME"]);
                            dteTmp = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, dteTmp.Hour, dteTmp.Minute, 0);
                            if (!((start >= dtsTmp && start <= dteTmp) && (end >= dtsTmp && end <= dteTmp)))
                            {
                                string s = msg.ShowAlert("UID1112", env.CurrentLanguageID);
                                if (s == "1")
                                    return false;
                            }
                            #region ตรวจสอบดูว่าช่วงเวลาที่เลือกเกิน Max appointment หรือยัง

                            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                            process.RIS_CLINICSESSION.MODALITY_ID = Convert.ToInt32(txtNewModality.Tag.ToString());
                            process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
                            process.RIS_CLINICSESSION.WEEKDAYS = Convert.ToInt32(start.DayOfWeek);
                            process.Invoke();
                            DataTable dtmp = process.GetClinicSession();
                            drs = dtmp.Select("SESSION_ID=" + sessionID);
                            max_app = Convert.ToInt32(drs[0]["MAX_APP"].ToString());
                            DateTime dtStartApp = Convert.ToDateTime(drs[0]["START_TIME"].ToString());
                            DateTime dtEndApp = Convert.ToDateTime(drs[0]["END_TIME"].ToString());

                            DateTime dtSt = new DateTime(start.Year, start.Month, start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                            DateTime dtEn = new DateTime(start.Year, start.Month, start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);

                            ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
                            procSC.RIS_SCHEDULE.MODALITY_ID = process.RIS_CLINICSESSION.MODALITY_ID;
                            procSC.RIS_SCHEDULE.START_DATETIME = dtSt;
                            procSC.RIS_SCHEDULE.END_DATETIME = dtEn;
                            dtmp = new DataTable();
                            dtmp = procSC.GetSessionCount();
                            curr_app = 0;
                            if (curr_app > max_app)
                            {
                                if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                                    return false;
                            }
                            #endregion
                        }
                    }
                }
                #endregion
            return true;
        }
        private bool isDuplicateAppointment(RIS_SCHEDULE dataSchedule)
        {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            proc.RIS_SCHEDULE = dataSchedule;
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            edt = edt.Subtract(ts);
            proc.RIS_SCHEDULE.START_DATETIME = start;
            proc.RIS_SCHEDULE.END_DATETIME = edt;
            if (proc.CheckFreeTime())
                return false;
            else
                return true;
        }
        private bool requereCheckAppointment() {
            bool flag = true;
            RIS_SCHEDULE sc = new RIS_SCHEDULE();
            sc.MODALITY_ID = Convert.ToInt32(txtNewModality.Tag.ToString());
            sc.SCHEDULE_ID = scheduleID;
            sc.HN = txtHN.EditValue.ToString().Trim();
            if (isDuplicateAppointment(sc))
            {
                msg.ShowAlert("UID1111", env.CurrentLanguageID);
                return false;
            }

            return flag;
        }
        private bool updateAppointmentData()
        {
            bool flag = true;
            //if (requereCheckAppointment())
            //{
                DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
                DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
                DateTime edt = (DateTime)timeEnd.EditValue;
                edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
                TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                edt = edt.Subtract(ts);
            
                DataTable dataExam = new DataTable();
                dataExam = RISBaseData.Ris_Exam();
                Patient patient = new Patient(txtHN.EditValue.ToString().Trim(), true);
                string _schedule_data = "";
                string patient_id_label = string.IsNullOrEmpty(patient.PATIENT_ID_LABEL) ? "" : "[" + patient.PATIENT_ID_LABEL + "]";
                if (dttExam.Rows.Count == 1)
                {
                    _schedule_data = "HN : " + txtHN.EditValue.ToString().Trim() + patient_id_label + " " + patient.Title + patient.FirstName.Trim() + " " + patient.LastName.Trim();
                    DataRow[] rs = dataExam.Select("EXAM_ID=" + dttExam.Rows[0]["EXAM_ID"].ToString());
                    _schedule_data += "; " + rs[0]["EXAM_NAME"].ToString().Trim();
                    if (!string.IsNullOrEmpty(dttExam.Rows[0]["EMP_ID"].ToString()))
                        _schedule_data += " (" + getRadilogyName(dttExam.Rows[0]["EMP_ID"].ToString()) + ") ";
                }
                else
                {
                    _schedule_data = "HN : " + txtHN.EditValue.ToString().Trim() + patient_id_label + " " + patient.Title + patient.FirstName.Trim() + " " + patient.LastName.Trim();
                    _schedule_data += "; ";
                    foreach (DataRow dr in dttExam.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["EXAM_ID"].ToString())) break;
                        DataRow[] rs = dataExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                        _schedule_data += rs[0]["EXAM_NAME"].ToString().Trim();// +"; ";
                        if (!string.IsNullOrEmpty(dr["EMP_ID"].ToString()))
                            _schedule_data += " (" + getRadilogyName(dr["EMP_ID"].ToString()) + ") ; ";
                        else
                            _schedule_data += "; ";
                    }
                    _schedule_data = _schedule_data.Remove(_schedule_data.LastIndexOf(';'), 1);
                }

                if (txtAddTextInBlock.Text.Trim().Length != 0)
                {
                    string log_msg = txtAddTextInBlock.Text.Trim();
                    log_msg = " (" + log_msg + ") ";

                    _schedule_data += log_msg;
                }

                ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(txtNewModality.Tag.ToString());
                proc.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(txtSession.Tag.ToString());
                proc.RIS_SCHEDULE.START_DATETIME = start;
                proc.RIS_SCHEDULE.END_DATETIME = edt;
                proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                proc.RIS_SCHEDULE.REASON = txtInputReason.Text;
                proc.RIS_SCHEDULE.SCHEDULE_DATA = _schedule_data;
                proc.RIS_SCHEDULE.TEXT_SHOW = txtAddTextInBlock.Text.Trim();
                proc.UpdateModality();
                #region Update Exam.
                foreach (DataRow dr in dttExam.Rows)
                {
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
                    procUp.RIS_SCHEDULEDTL.SCHEDULE_ID = scheduleID;
                    procUp.RIS_SCHEDULEDTL.OLD_EXAM_ID = Convert.ToInt32(dr["OLD_EXAM_ID"].ToString());
                    procUp.RIS_SCHEDULEDTL.REASON = txtInputReason.Text.Trim();
                    procUp.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(dr["SCHEDULE_PRIORITY"].ToString().Trim()) ? "R" : dr["SCHEDULE_PRIORITY"].ToString().Trim();
                    procUp.Invoke();
                }
                #endregion

                #region insert schedule logs
                ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
                schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = scheduleID;
                schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
                schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'U';
                schLogs.RIS_SCHEDULELOGS.LOGS_DESC = "Changed Modality Envision";
                schLogs.Invoke();
                #endregion

                if (proc.RIS_SCHEDULE.SCHEDULE_ID > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (proc.RIS_SCHEDULE.SCHEDULE_ID == -2)
                {
                    string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);//Check double Exam
                    dtStart.Focus();
                    return false;
                }
                else
                {
                    ProcessGetRISSchedule procBlock = new ProcessGetRISSchedule();
                    procBlock.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                    procBlock.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(txtNewModality.Tag.ToString());
                    procBlock.RIS_SCHEDULE.START_DATETIME = start;
                    procBlock.RIS_SCHEDULE.END_DATETIME = edt;
                    DataTable dtblock = procBlock.GetScheduleBlock();

                    if (dtblock.Rows.Count > 0)
                    {
                        MyMessageBoxBlock msgBlock = new MyMessageBoxBlock();
                        string s = msgBlock.ShowAlertAddText("UID1101", env.CurrentLanguageID,
                            "\r\n\r\n" +
                            dtblock.Rows[0]["SCHEDULE_DATA"].ToString());
                    }
                    else
                    {
                        string s = msg.ShowAlert("UID1101", env.CurrentLanguageID);//Check block
                    }
                    dtStart.Focus();
                    return false;
                }
            //}
            return flag;
        }
        private bool updateBlockData()
        {
            DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
            DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);
            DateTime edt = (DateTime)timeEnd.EditValue;
            edt = new DateTime(end.Year, end.Month, end.Day, edt.Hour, edt.Minute, edt.Second);
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            edt = edt.Subtract(ts);
            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
            proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(txtNewModality.Tag.ToString());
            proc.RIS_SCHEDULE.START_DATETIME = start;
            proc.RIS_SCHEDULE.END_DATETIME = edt;
            proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            proc.UpdateModality();
            if (proc.RIS_SCHEDULE.SCHEDULE_ID > 0)
            {
                #region Update AppointmentData.
                //for (int i = 0; i < dttAppointment.Rows.Count; i++)
                //{
                //    if (dttAppointment.Rows[i]["SCHEDULE_ID"].ToString() == scheduleID.ToString())
                //    {
                //        DataRow nw = dttAppointment.Rows[i];
                //        nw["MODALITY_ID"] = proc.RIS_SCHEDULE.MODALITY_ID;
                //        nw["START_DATETIME"] = proc.RIS_SCHEDULE.START_DATETIME;
                //        nw["END_DATETIME"] = proc.RIS_SCHEDULE.END_DATETIME;
                //        nw["IS_BLOCKED"] = 'Y';
                //        nw["CommandType"] = "N";
                //        dttAppointment.AcceptChanges();
                //        break;
                //    }
                //}
                #endregion
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                dtStart.Focus();
                return false;
            }
            return true;
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Common Check.
            if (dxErrorProvider1.HasErrors) return;
            if (txtNewModality.Tag == null)
            {
                msg.ShowAlert("UID1018", env.CurrentLanguageID);
                txtNewModality.Focus();
                return;
            }
            if (dtStart.DateTime == DateTime.MinValue)
            {
                dtStart.Focus();
                return ;
            }
            if (dtEnd.DateTime == DateTime.MinValue)
            {
                dtEnd.Focus();
                return ;
            }
            if (txtSession.Text.Trim().Length == 0)
            {
                dxErrorProvider1.SetError(txtSession, "Please select session", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                txtSession.Focus();
                return;
            }
            if (txtInputReason.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                txtInputReason.Focus();
                return;
            }
            #endregion
            if (isblock)
                updateBlockData();
            else
                updateAppointmentData();
           
        }
        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region KeyDown and Lookup.
        private void txtNewModality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
        }
        private void txtNewModality_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewModality.Text.Trim() != string.Empty)
            {
                bool flag = true;
                foreach (DataRow dr in dttModality.Rows)
                {
                    if (txtNewModality.Text.Trim().ToUpper() == dr["MODALITY_NAME"].ToString().Trim().ToUpper())
                    {
                        txtNewModality.Tag = dr["MODALITY_ID"].ToString();
                        txtNewModality.Text = dr["MODALITY_NAME"].ToString();
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    msg.ShowAlert("UID1018", env.CurrentLanguageID);
                    txtNewModality.Focus();
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            else
            {
                txtNewModality.Text = string.Empty;
                txtNewModality.Tag = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();
            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("MODALITY_UID", "Code", true, true);
            lv.AddColumn("MODALITY_NAME", "NAME", true, true);
            lv.Text = "Modality Search";

            lv.Data = dttModality;
            lv.Size = new Size(400, 200);
            lv.ShowBox();
        }
        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            if (retValue != null)
            {
                txtNewModality.Tag = retValue[0];
                txtNewModality.Text = retValue[2];
            }
        } 
        #endregion

        #region DateTime Session.
        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void dtStart_Enter(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }

        private void dtEnd_Enter(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
        }
        
        private void timeStart_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }
        private void timeStart_EditValueChanged(object sender, EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false) doDateValidated();
        }

        private void timeEnd_Enter(object sender, EventArgs e)
        {
            doTimerValidated();
        }
        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            doTimerValidated();
        } 
        #endregion

        private void btnBrowseReason_Click(object sender, EventArgs e)
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
        private void reasonLookup_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtInputReason.Tag = retValue[0];
            txtInputReason.Text = retValue[2];
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
                ProcessGetRISExam chkPort = new ProcessGetRISExam();
                DataTable dtPort = chkPort.GetExamPanelPortable(Convert.ToInt32(row["EXAM_ID"]), CLINIC_TYPE_ID);
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

            txtSession.Tag = retValue[0];
            txtSession.Text = retValue[2];
            CLINIC_TYPE_ID = Convert.ToInt32(retValue[3].ToString());

            start_session = Convert.ToDateTime(retValue[4]);
            end_session = Convert.ToDateTime(retValue[5]);

            object obj = txtSession.Tag;
            if (obj == null) return;
            DataRow[] ctName = RISBaseData.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + CLINIC_TYPE_ID.ToString());
            string clinictypeName = ctName[0]["CLINIC_TYPE_UID"].ToString();
            foreach (DataRow row in dttExam.Rows)
            {
                if (string.IsNullOrEmpty(row["EXAM_ID"].ToString())) continue;
                DataRow[] rs = dataAllExam.Select("EXAM_ID=" + row["EXAM_ID"].ToString());
                switch (clinictypeName.ToUpper())
                {
                    case "SPECIAL":
                        row["RATE"] = IS_FOREIGNER ? rs[0]["FOREIGN_SPCIAL_RATE"].ToString() : rs[0]["SPECIAL_RATE"].ToString();
                        break;
                    case "VIP":
                        row["RATE"] = IS_FOREIGNER ? rs[0]["FOREIGN_VIP_RATE"].ToString() : rs[0]["VIP_RATE"].ToString();
                        break;
                    default:
                        row["RATE"] = IS_FOREIGNER ? rs[0]["FOREIGN_RATE"].ToString() : rs[0]["RATE"].ToString();
                        break;
                }

            }
            dttExam.AcceptChanges();
            calTotal();

            doDateValidated();
            if (dxErrorProvider1.HasErrors == false) doTimerValidated();
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

        private string getRadilogyName(string EMP_ID)
        {
            string name = string.Empty;
            DataTable dtt = RISBaseData.His_Doctor();
            DataRow[] rs = dtt.Select("EMP_ID=" + EMP_ID);
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
