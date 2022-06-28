using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.Xml;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleSummary : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string hn;
        private DataSet dsSchSummary;
        public int SCHEDULE_ID { get; set; }

        public frmScheduleSummary(string HN)
        {
            InitializeComponent();
            hn = HN;
            pageAppoint.PageVisible = false;

            dsSchSummary = new DataSet();
            ProcessGetRISSchedule prc = new ProcessGetRISSchedule(hn);
            prc.RIS_SCHEDULE.TYPE = 4;
            prc.RIS_SCHEDULE.HN = hn;
            dsSchSummary = prc.GetByHN().Copy();

            initiateAllergy();
            initiateDemographic(dsSchSummary.Tables[3]);
            initiateCommentData();
            initiateHistory();
        }
        public frmScheduleSummary(string HN,int scheduleId)
        {
            InitializeComponent();
            hn = HN;
            SCHEDULE_ID = scheduleId;

            dsSchSummary = new DataSet();
            ProcessGetRISSchedule prc = new ProcessGetRISSchedule(hn);
            prc.RIS_SCHEDULE.TYPE = 4;
            prc.RIS_SCHEDULE.HN = hn;
            dsSchSummary = prc.GetByHN().Copy();

            initiateAppointment();
            initiateAllergy();
            initiateDemographic(dsSchSummary.Tables[3]);
            initiateCommentData();
            initiateHistory();
        }

        private void initiateDemographic(DataTable dtt) {
            hn = dtt.Rows[0]["HN"].ToString();
            txtHN.EditValue = dtt.Rows[0]["HN"].ToString();
            txtName.EditValue = dtt.Rows[0]["PATIENT_NAME"].ToString();
            txtAge.EditValue = dtt.Rows[0]["AGE"].ToString();
            txtPhone.Text = dtt.Rows[0]["PHONE1"].ToString();
        }
        private void initiateAppointment() {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule(SCHEDULE_ID);
            proc.Invoke();
            DataTable dttInfo = proc.Result.Tables[0];
            DataTable dttExam = proc.Result.Tables[1].Copy();
            if (dttInfo == null) return;
            DataTable dtt = RISBaseData.RIS_PatStatus();
            DataView dv = null;
            if (Miracle.Util.Utilities.IsHaveData(dtt)) {
                dv = new DataView(dtt);
                dv.RowFilter = "STATUS_ID=" + dttInfo.Rows[0]["PAT_STATUS"].ToString();
                dtt=dv.ToTable();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                    txtStatus.Text = dtt.Rows[0]["STATUS_TEXT"].ToString();
            }
            dtt = RISBaseData.His_Department();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                dv = new DataView(dtt);
                dv.RowFilter = "UNIT_ID=" + dttInfo.Rows[0]["REF_UNIT"].ToString();
                dtt = dv.ToTable();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                    txtOrderDept.Text = dtt.Rows[0]["UNIT_NAME"].ToString();
            }
            dtt = RISBaseData.His_Doctor();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                dv = new DataView(dtt);
                dv.RowFilter = "EMP_ID=" + dttInfo.Rows[0]["REF_DOC"].ToString();
                dtt = dv.ToTable();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                    txtOrderDoc.Text = dtt.Rows[0]["FNAME"].ToString() + " " + dtt.Rows[0]["FNAME"].ToString();
            }
            dtt = RISBaseData.Ris_Modality();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                dv = new DataView(dtt);
                dv.RowFilter = "MODALITY_ID=" + dttInfo.Rows[0]["MODALITY_ID"].ToString();
                dtt = dv.ToTable();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                    txtModality.Text = dtt.Rows[0]["MODALITY_NAME"].ToString();
            }
            txtClinical.Text = dttInfo.Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            ProcessGetRISClinicsession clinic = new ProcessGetRISClinicsession();
            clinic.Invoke();
            dtt = clinic.GetClinicSession();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                dv = new DataView(dtt);
                dv.RowFilter = "SESSION_ID=" + dttInfo.Rows[0]["SESSION_ID"].ToString();
                dtt = dv.ToTable();
                if (Miracle.Util.Utilities.IsHaveData(dtt))
                    txtSession.Text = dtt.Rows[0]["SESSION_NAME"].ToString();
            }
            txtStart.Text = dttInfo.Rows[0]["START_DATETIME"].ToString();
            txtEnd.Text = dttInfo.Rows[0]["END_DATETIME"].ToString();

            if (dttExam == null) return;
            grdSchedule.DataSource = dttExam;
            for (int i = 0; i < dttExam.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            dtt = RISBaseData.Ris_Exam();

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
            repositoryItemLookUpEdit1.DataSource = dtt;
            repositoryItemLookUpEdit1.NullText = string.Empty;
            repositoryItemLookUpEdit1.BestFit();
            repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            view1.Columns["EXAM_ID"].ColumnEdit = repositoryItemLookUpEdit1;
            view1.Columns["EXAM_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_ID"].Visible = true;
            view1.Columns["EXAM_ID"].Caption = "Exam Code";
            view1.Columns["EXAM_ID"].Width = 80;
            view1.Columns["EXAM_ID"].VisibleIndex = 1;

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
            repositoryItemLookUpEdit2.DataSource = dtt;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.BestFit();
            repositoryItemLookUpEdit2.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            #endregion
            view1.Columns["EXAM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            view1.Columns["EXAM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].Width = 150;
            view1.Columns["EXAM_NAME"].VisibleIndex = 2;

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
            view1.Columns["EMP_ID"].ColumnEdit = rpsRadio;
            view1.Columns["EMP_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["EMP_ID"].Visible = true;
            view1.Columns["EMP_ID"].Caption = "Radiologist";
            view1.Columns["EMP_ID"].Width = 150;
            view1.Columns["EMP_ID"].VisibleIndex = 8;
        }
        private void initiateAllergy()
        {
            DataTable dtt=null;
            try
            {
                HIS_Patient HIS_p = new HIS_Patient();
                DataSet dsHIS = HIS_p.Get_Adr(hn);
                dtt = dsHIS.Tables[0].Copy();
            }
            catch(Exception ex) {
                dtt = new DataTable();
                dtt.Columns.Add("drugname", typeof(string));
                dtt.Columns.Add("side_effect", typeof(string));
                dtt.Columns.Add("naranjo", typeof(string));
                dtt.AcceptChanges();
            }
            grdAllergy.DataSource = dtt;
            viewAllergy.Columns[0].Width = 250;
            viewAllergy.Columns[1].Width = 250;
            viewAllergy.Columns[2].Width = 250;
        }
        private void initiateCommentData()
        {
            grdApp.DataSource = dsSchSummary.Tables[1].Copy();
            for (int i = 0; i < dsSchSummary.Tables[1].Columns.Count; i++)
                viewApp.Columns[i].Visible = false;

            viewApp.Columns["APPOINT_DATE"].Visible = true;
            viewApp.Columns["APPOINT_DATE"].VisibleIndex = 0;
            viewApp.Columns["APPOINT_DATE"].Caption = "Appoint Date";
            viewApp.Columns["APPOINT_DATE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["APPOINT_DATE"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            viewApp.Columns["APPOINT_DATE"].BestFit();

            viewApp.Columns["EXAM_NAME"].Visible = true;
            viewApp.Columns["EXAM_NAME"].VisibleIndex = 1;
            viewApp.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewApp.Columns["EXAM_NAME"].Width = 120;

            viewApp.Columns["COMMENT_DT"].Visible = true;
            viewApp.Columns["COMMENT_DT"].VisibleIndex = 2;
            viewApp.Columns["COMMENT_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["COMMENT_DT"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            viewApp.Columns["COMMENT_DT"].Caption = "Comment On";
            viewApp.Columns["COMMENT_DT"].BestFit();

            viewApp.Columns["COMMENT_FROM"].Visible = true;
            viewApp.Columns["COMMENT_FROM"].VisibleIndex = 3;
            viewApp.Columns["COMMENT_FROM"].Caption = "Comment From";
            viewApp.Columns["COMMENT_FROM"].Width = 120;

            viewApp.Columns["COMMENT_TO"].Visible = true;
            viewApp.Columns["COMMENT_TO"].VisibleIndex = 4;
            viewApp.Columns["COMMENT_TO"].Caption = "Comment To";
            viewApp.Columns["COMMENT_TO"].Width = 120;

            viewApp.Columns["COMMENT_SUBJECT"].Visible = true;
            viewApp.Columns["COMMENT_SUBJECT"].VisibleIndex = 5;
            viewApp.Columns["COMMENT_SUBJECT"].Caption = "Subject";
            viewApp.Columns["COMMENT_SUBJECT"].Width = 130;

            viewApp.Columns["COMMENT_BODY"].Visible = true;
            viewApp.Columns["COMMENT_BODY"].VisibleIndex = 6;
            viewApp.Columns["COMMENT_BODY"].Caption = "Comment detail";
            viewApp.Columns["COMMENT_BODY"].Width = 150;
            
        }
        private void initiateHistory() {
            //dsUnion = new DataSet();
            //dsUnion.Tables.Add(dsSchSummary.Tables[0].Copy());
            //dsUnion.Tables.Add(dsSchSummary.Tables[1].Copy());
            //dsUnion.AcceptChanges();


            //DataColumn keyColumn = dsUnion.Tables[0].Columns["SCHEDULE_ID"];
            //DataColumn foreignKeyColumn = dsUnion.Tables[1].Columns["SCHEDULE_ID"];
            //dsUnion.Relations.Add("ItemRecieve", keyColumn, foreignKeyColumn);
            grdHis.DataSource = dsSchSummary.Tables[0].Copy();
            for (int i = 0; i < dsSchSummary.Tables[0].Columns.Count; i++)
                viewHis.Columns[i].Visible = false;

            viewHis.Columns["SCH_CREATED_ON"].Visible = true;
            viewHis.Columns["SCH_CREATED_ON"].VisibleIndex = 0;
            viewHis.Columns["SCH_CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["SCH_CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            viewHis.Columns["SCH_CREATED_ON"].Caption = "Schedule Date";
            viewHis.Columns["SCH_CREATED_ON"].BestFit();

            viewHis.Columns["START_DATETIME"].Visible = true;
            viewHis.Columns["START_DATETIME"].VisibleIndex = 1;
            viewHis.Columns["START_DATETIME"].Caption = "Appoint Date";
            viewHis.Columns["START_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            viewHis.Columns["START_DATETIME"].BestFit();

            viewHis.Columns["ORD_CREATED_ON"].Visible = true;
            viewHis.Columns["ORD_CREATED_ON"].VisibleIndex = 2;
            viewHis.Columns["ORD_CREATED_ON"].Caption = "Orders Date";
            viewHis.Columns["ORD_CREATED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["ORD_CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            viewHis.Columns["ORD_CREATED_ON"].BestFit();

            viewHis.Columns["EXAM_NAME"].Visible = true;
            viewHis.Columns["EXAM_NAME"].VisibleIndex = 3;
            viewHis.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewHis.Columns["EXAM_NAME"].Width = 120;

            viewHis.Columns["REF_UNIT"].Visible = true;
            viewHis.Columns["REF_UNIT"].VisibleIndex = 4;
            viewHis.Columns["REF_UNIT"].Caption = "Ref. Unit";
            viewHis.Columns["REF_UNIT"].Width = 120;

            viewHis.Columns["REF_DOC"].Visible = true;
            viewHis.Columns["REF_DOC"].VisibleIndex = 5;
            viewHis.Columns["REF_DOC"].Caption = "Ref. Doc.";
            viewHis.Columns["REF_DOC"].Width = 120;

            viewHis.Columns["REASON"].Visible = true;
            viewHis.Columns["REASON"].VisibleIndex = 6;
            viewHis.Columns["REASON"].Caption = "Reasons";
            viewHis.Columns["REASON"].Width = 120;

            viewHis.Columns["ASSIGNED_RAD"].Visible = true;
            viewHis.Columns["ASSIGNED_RAD"].VisibleIndex = 7;
            viewHis.Columns["ASSIGNED_RAD"].Caption = "Assigned Rad.";
            viewHis.Columns["ASSIGNED_RAD"].Width = 130;
            
            
        }
        
        private void frmScheduleSummary_Load(object sender, EventArgs e)
        {
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
