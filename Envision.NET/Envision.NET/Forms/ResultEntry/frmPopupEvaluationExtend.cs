using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using System.Linq;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmPopupEvaluationExtend : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private int[] assignmentIds = new int[] { };
        private int EvaBy = 0;
        private string aaccessionNo = string.Empty;
        private string rreportText = string.Empty;
        private string rreportType = string.Empty;
        private string rresultStatus = string.Empty;
        //BackUp parameters
        private int backupGradeId = 0;
        private int backupLangId = 0;
        private string backupGradeComment = string.Empty;
        private string backupLangComment = string.Empty;
        private string backupIsLikely = string.Empty;
        private string reportText;

        private GuiMode gui;
        public frmPopupEvaluationExtend(List<int> AssignmentId, bool ForWork)
        {
            env = new GBLEnvVariable();
            gui = GuiMode.Show;
            InitializeComponent();
            assignmentIds = AssignmentId.ToArray();
            this.Load += fromPopupEvaluation_Load;
            btnCancel.Enabled = true;
            btnChange.Enabled = false;
            btnSave.Enabled = false;
            //layoutControl1.Enabled = ForWork;
            gridViewGrade.OptionsBehavior.Editable = ForWork;
            gridViewLangaugeOfReport.OptionsBehavior.Editable = ForWork;
            rdoClinicSign.Properties.ReadOnly = !ForWork;
            txtComment.Properties.ReadOnly = !ForWork;
            txtComment.BackColor = Color.White;
            tbLangComment.Properties.ReadOnly = !ForWork;
            tbLangComment.BackColor = Color.White;
        }
        public frmPopupEvaluationExtend(int[] assign_id, int evalutionby, string accessionNo, string report_text, string report_type)
        {
            env = new GBLEnvVariable();
            gui = GuiMode.Normal;
            assignmentIds = assign_id;
            EvaBy = evalutionby;
            aaccessionNo = accessionNo;
            rreportText = report_text;
            rreportType = report_type;
            rresultStatus = report_type;
            InitializeComponent();
            this.Load += fromPopupEvaluation_Load;

            this.panelEvaluationReport.Click += new EventHandler(panelEvaluationReport_Click);
            this.Size = new Size(800, 590);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panelEvaluationReport.Expanded = false;
            reportText = report_text;
        }
        public frmPopupEvaluationExtend(int[] assign_id, int evalutionby, string accessionNo, string report_text, string report_type, string result_status)
        {
            env = new GBLEnvVariable();
            gui = GuiMode.Normal;
            assignmentIds = assign_id;
            EvaBy = evalutionby;
            aaccessionNo = accessionNo;
            rreportText = report_text;
            rreportType = report_type;
            rresultStatus = result_status;
            InitializeComponent();
            this.Load += fromPopupEvaluation_Load;

            this.panelEvaluationReport.Click += new EventHandler(panelEvaluationReport_Click);
            this.Size = new Size(800, 590);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.panelEvaluationReport.Expanded = false;
            reportText = report_text;
        }

        void panelEvaluationReport_Click(object sender, EventArgs e)
        {
            if (panelEvaluationReport.Expanded)
                this.Size = new Size(800,700);
            else
                this.Size = new Size(800, 590);
        }

        private void fromPopupEvaluation_Load(object sender, EventArgs e)
        {
            msg = new MyMessageBox();
            InitializeData();
            //if (rdoClinicSign.SelectedIndex == 0)
            //{
            //    txtComment.Enabled = true;
            //}
            //else
            //{
            //    txtComment.Enabled = false;
            //}
            //base.CloseWaitDialog();
            if (env.IsDent) btnChange.Enabled = false;
              
        }
        private void InitializeData()
        {
            // Get grade info.
            ProcessGetACGrade _grade = new ProcessGetACGrade();
            _grade.Invoke();
            gridControlGrade.DataSource = _grade.ResultSet.Tables[0].Copy();

            // Get Reporting Language info.
            ProcessGetACReportingLanguage _processGetACReportingLanaguage = new ProcessGetACReportingLanguage();
            _processGetACReportingLanaguage.ORG_ID = env.OrgID;
            _processGetACReportingLanaguage.Invoke();
            this.gridControlLangaugeOfReport.DataSource = _processGetACReportingLanaguage.Result.Tables[0];

            // Get Evaluation info.
            DataSet ds = new DataSet();
            ProcessGetACEvaluation _prc = new ProcessGetACEvaluation();
            _prc.Invoke(assignmentIds[0]);
            ds = _prc.ResultSet.Copy();

            try
            {
                if (Miracle.Util.Utilities.IsHaveData(ds))
                    reportText = ds.Tables[0].Rows[0]["REPORT_TEXT"].ToString();
            }
            catch { }

            txtEvaluationReport.Text = reportText;

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["GRADE_ID"].ToString() != "")
                {
                    this.Backup(ds.Tables[0].Rows[0]); // backup data
                    // set value
                    this.Restore();
                    //txtGrade.Properties.ReadOnly = true;
                    rdoClinicSign.Properties.ReadOnly = true;
                    txtComment.Properties.ReadOnly = true;
                    gridControlGrade.Enabled = false;
                    if (env.IsFellow || env.IsDent) 
                        btnChange.Enabled = false;
                    else
                        btnChange.Enabled = true;
                    gridControlLangaugeOfReport.Enabled = false;
                    tbLangComment.Properties.ReadOnly = true;
                    gui = GuiMode.Normal;
                }
                else
                {
                    gui = GuiMode.Add;
                    //txtGrade.Properties.ReadOnly = true;
                    rdoClinicSign.Properties.ReadOnly = false;
                    txtComment.Properties.ReadOnly = false;
                    gridControlGrade.Enabled = true;
                    gridControlLangaugeOfReport.Enabled = true;
                    tbLangComment.Properties.ReadOnly = false;
                    btnChange.Enabled = false;
                    this.gridViewLangaugeOfReport.FocusedRowHandle = -1;
                    this.gridViewGrade.FocusedRowHandle = -1;
                }
            }
            else
            {
                gui = GuiMode.Add;
                //txtGrade.Properties.ReadOnly = true;
                rdoClinicSign.Properties.ReadOnly = false;
                txtComment.Properties.ReadOnly = false;
                gridControlGrade.Enabled = true;
                gridControlLangaugeOfReport.Enabled = true;
                tbLangComment.Properties.ReadOnly = false;
                btnChange.Enabled = false;
                this.gridViewLangaugeOfReport.FocusedRowHandle = -1;
                this.gridViewGrade.FocusedRowHandle = -1;                
            }
        }

        private void rdoClinicSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rdoClinicSign.SelectedIndex == 0)
            //{
            //    txtComment.Enabled = true;
            //}
            //else
            //{
            //    txtComment.Enabled = false;
            //}
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            //check mandatory field
            DataRow[] selectedGradeRows = (this.gridControlGrade.DataSource as DataTable).Select("IS_SELECTED='Y'");
            DataRow[] selectedLangRows = (this.gridControlLangaugeOfReport.DataSource as DataTable).Select("IS_SELECTED='Y'");
            if (selectedGradeRows.Length == 0 || selectedLangRows.Length == 0)
            {
                // SHOW MESSAGE ::
                MessageBox.Show("Please select 'Opinion of Clinical Report' and 'Language of Report'."
                    , "Feedback not complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {   
                if (gui == GuiMode.Edit)
                {
                    foreach (int eachId in assignmentIds)
                    {
                        // update old evaluation
                        //AcademicModule Academic = new AcademicModule();
                        AcademicManagement.AC_EVALUATION.ASSIGNMENT_ID = eachId;
                        AcademicManagement.AC_EVALUATION.EVALUATED_BY = EvaBy;
                        AcademicManagement.AC_EVALUATION.GRADE_ID = Convert.ToInt32(selectedGradeRows[0]["GRADE_ID"]);
                        if (rdoClinicSign.SelectedIndex == 0)
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "Y";
                        else if (rdoClinicSign.SelectedIndex == 1)
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "N";
                        else
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "";
                        AcademicManagement.AC_EVALUATION.COMMENTS = txtComment.Text;
                        AcademicManagement.AC_EVALUATION.LAST_MODIFIED_BY = EvaBy;
                        AcademicManagement.AC_EVALUATION.LANGUAGE_OF_REPORT = Convert.ToInt32(selectedLangRows[0]["REPORT_LANG_ID"]);
                        AcademicManagement.AC_EVALUATION.LANGUAGE_OF_REPORT_COMMENTS = tbLangComment.Text;
                        AcademicManagement.AC_EVALUATION.ORG_ID = env.OrgID;
                        AcademicManagement.AC_EVALUATION.RESULT_STATUS = rresultStatus;
                        AcademicManagement.UpdateEvaluation();
                    }
                }
                else
                {
                    foreach (int eachId in assignmentIds)
                    {
                        //AcademicModule Academic = new AcademicModule();
                        AcademicManagement.AC_EVALUATION.ASSIGNMENT_ID = eachId;
                        AcademicManagement.AC_EVALUATION.EVALUATED_BY = EvaBy;
                        AcademicManagement.AC_EVALUATION.GRADE_ID = Convert.ToInt32(selectedGradeRows[0]["GRADE_ID"]);
                        if (rdoClinicSign.SelectedIndex == 0)
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "Y";
                        else if (rdoClinicSign.SelectedIndex == 1)
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "N";
                        else
                            AcademicManagement.AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT = "";
                        AcademicManagement.AC_EVALUATION.REPORT_TEXT = rreportText;
                        AcademicManagement.AC_EVALUATION.REPORT_TYPE = rreportType;
                        AcademicManagement.AC_EVALUATION.COMMENTS = txtComment.Text;
                        AcademicManagement.AC_EVALUATION.CREATED_BY = EvaBy;
                        AcademicManagement.AC_EVALUATION.LAST_MODIFIED_BY = EvaBy;
                        AcademicManagement.AC_EVALUATION.LANGUAGE_OF_REPORT = Convert.ToInt32(selectedLangRows[0]["REPORT_LANG_ID"]);
                        AcademicManagement.AC_EVALUATION.LANGUAGE_OF_REPORT_COMMENTS = tbLangComment.Text;
                        AcademicManagement.AC_EVALUATION.ORG_ID = env.OrgID;
                        AcademicManagement.AC_EVALUATION.RESULT_STATUS = rresultStatus;
                        AcademicManagement.AddEvaluation();
                    }
                }
                
                // : SEND INTERNAL MESSAGE :
                if (selectedLangRows[0]["SEND_MESSAGE"].ToString() == "Y" || selectedGradeRows[0]["SEND_MESSAGE"].ToString() == "Y")
                {
                    try
                    {
                        string _subject = "Feedback Findings";
                        string _message = AcademicManagement
                            .GenarateInternalMessage(selectedGradeRows[0]["GRADE_LABEL"].ToString()
                            , selectedLangRows[0]["REPORT_LANG_LABEL"].ToString()
                            , this.aaccessionNo
                            , rdoClinicSign.SelectedIndex == 0 ? true : false
                            , txtComment.Text
                            , tbLangComment.Text
                            , this.env.FirstName
                            , this.env.LastName
                            , this.env.OrgID);

                        int[] radGroupEmpIds = AcademicManagement.GetRadEmpIdGroup(this.aaccessionNo, this.env.OrgID).Where(elm => elm != env.UserID).ToArray();
                        if (radGroupEmpIds.Length == 0)
                            return;
                        Envision.NET.Forms.InternalMessage.frmSend _frmSend = new Envision.NET.Forms.InternalMessage.frmSend();
                        _frmSend.SendAutoMessage(radGroupEmpIds, _subject, _message, env.UserID); //send auto message
                        _frmSend.Dispose();
                    }
                    catch { }
                    finally { }
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnChange_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gui == GuiMode.Normal)
            {
                gui = GuiMode.Edit;
                //txtGrade.Properties.ReadOnly = true;
                rdoClinicSign.Properties.ReadOnly = false;
                txtComment.Properties.ReadOnly = false;
                gridControlGrade.Enabled = true;
                btnChange.Caption = "Default";
                gridControlLangaugeOfReport.Enabled = true;
                tbLangComment.Properties.ReadOnly = false;
            }
            else
            {
                gui = GuiMode.Normal;
                this.Restore(); //restore data
                //txtGrade.Properties.ReadOnly = true;
                rdoClinicSign.Properties.ReadOnly = true;
                txtComment.Properties.ReadOnly = true;
                gridControlGrade.Enabled = false;
                //txtGrade.Text = _GradeTextDefault;
                //_GradeId = _GradeIdDefault;
                //_langId = _langDefaultId;
                btnChange.Caption = "Edit";
                gridControlLangaugeOfReport.Enabled = false;
                tbLangComment.Properties.ReadOnly = true;
            }
        }

        private void btnCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        #region [ Grid Row Double Click ]
        /// <summary>
        /// Grade Grid double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlGrade_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridViewGrade.FocusedRowHandle >= 0)
            {
                DataRow selectedRow = this.gridViewGrade.GetFocusedDataRow();
                foreach (DataRow eachRow in (this.gridControlGrade.DataSource as DataTable).Rows)
                {
                    if(selectedRow["GRADE_ID"].Equals(eachRow["GRADE_ID"]))
                        eachRow["IS_SELECTED"] = "Y";
                    else
                        eachRow["IS_SELECTED"] = "N";
                }
            }
        }

        /// <summary>
        /// Language Of Report double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControlLangaugeOfReport_DoubleClick(object sender, EventArgs e)
        {
            if (this.gridViewLangaugeOfReport.FocusedRowHandle >= 0)
            {
                DataRow selectedRow = this.gridViewLangaugeOfReport.GetFocusedDataRow();
                foreach (DataRow eachRow in (this.gridControlLangaugeOfReport.DataSource as DataTable).Rows)
                {
                    if(selectedRow["REPORT_LANG_ID"].Equals(eachRow["REPORT_LANG_ID"]))
                        eachRow["IS_SELECTED"] = "Y";
                    else
                        eachRow["IS_SELECTED"] = "N";
                }
            }
        }
        #endregion

        #region [ Check Box on Grid Click ]
        /// <summary>
        /// Opinion check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repChkOpinion_Click(object sender, EventArgs e)
        {
            if (this.gridViewGrade.FocusedRowHandle >= 0)
            {
                DataRow selectedRow = this.gridViewGrade.GetFocusedDataRow();
                foreach (DataRow eachRow in (this.gridControlGrade.DataSource as DataTable).Rows)
                {
                    if (selectedRow["GRADE_ID"].Equals(eachRow["GRADE_ID"]))
                        eachRow["IS_SELECTED"] = "Y";
                    else
                        eachRow["IS_SELECTED"] = "N";
                }
            }
        }
        /// <summary>
        /// Reporting language check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repChkReport1_Click(object sender, EventArgs e)
        {
            if (this.gridViewLangaugeOfReport.FocusedRowHandle >= 0)
            {
                DataRow selectedRow = this.gridViewLangaugeOfReport.GetFocusedDataRow();
                foreach (DataRow eachRow in (this.gridControlLangaugeOfReport.DataSource as DataTable).Rows)
                {
                    if (selectedRow["REPORT_LANG_ID"].Equals(eachRow["REPORT_LANG_ID"]))
                        eachRow["IS_SELECTED"] = "Y";
                    else
                        eachRow["IS_SELECTED"] = "N";
                }
            }
        }
        #endregion

        #region [ Back up & Restore ]
        /// <summary>
        /// This method use to set backup parameters
        /// </summary>
        /// <param name="dataRow"></param>
        private void Backup(DataRow dataRow)
        {
            this.backupGradeComment = dataRow["COMMENTS"].ToString();
            this.backupGradeId = Convert.ToInt32(dataRow["GRADE_ID"]);
            this.backupLangComment = dataRow["LANGUAGE_OF_REPORT_COMMENTS"].ToString();
            this.backupLangId = Convert.ToInt32(dataRow["LANGUAGE_OF_REPORT"]);
            this.backupIsLikely = dataRow["IS_CLINICALLY_SIGNIFICANT"].ToString();
        }
        /// <summary>
        /// This method use to restore parameters
        /// </summary>
        private void Restore()
        {
            if (this.backupIsLikely.ToString() == "Y")
                rdoClinicSign.SelectedIndex = 0;
            else if (this.backupIsLikely.ToString() == "N")
                rdoClinicSign.SelectedIndex = 1;
            else
                rdoClinicSign.SelectedIndex = -1;

            this.txtComment.Text = this.backupGradeComment;
            this.tbLangComment.Text = this.backupLangComment;

            foreach (DataRow eachRow in (this.gridControlGrade.DataSource as DataTable).Rows)
            {
                if (backupGradeId.ToString() == eachRow["GRADE_ID"].ToString())
                    eachRow["IS_SELECTED"] = "Y";
                else
                    eachRow["IS_SELECTED"] = "N";
            }

            foreach (DataRow eachRow in (this.gridControlLangaugeOfReport.DataSource as DataTable).Rows)
            {
                if (backupLangId.ToString() == eachRow["REPORT_LANG_ID"].ToString())
                    eachRow["IS_SELECTED"] = "Y";
                else
                    eachRow["IS_SELECTED"] = "N";
            }
        }
        #endregion
    }
}