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
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Dialog;
using Envision.Operational.PACS;
namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmWorkBookNew : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env;
        private DataTable dttData;
        private DataTable dttSeverity;
        private MyMessageBox msg;

        public frmWorkBookNew()
        {
            InitializeComponent();
            dttData = null;
            env = new GBLEnvVariable();
            msg = new MyMessageBox();
        }
        private void frmWorkBook_Load(object sender, EventArgs e)
        {
            visibleHN(false);
            visibleStudyDate(true);
            
            DateTime from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
            DateTime to = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59);
            from = from.AddDays(-7);
            dtFrom.DateTime = from;
            dtTo.DateTime = to;
            
            loadSeverity();
            loadStudyDateData();
            loadExamType();
            lyDemo.Expanded = false;
            
            base.CloseWaitDialog();
        }

        private void btnWorkList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            tabCtrl.SelectedTabPage = pageWL;
            ribbonControl1.SelectedPage = ribWL;
            return;

            if (chkExam.Checked)
            {
                grdData.Enabled = false;
                rdoDate.Enabled = false;
                rdoExamType.Enabled = false;
                pnSearch.Enabled = false;
                btnSearch.Enabled = false;
                loadAllExamData();
                grdData.Enabled = true;
            }
            else if (rdoDate.Checked)
            {
                visibleStudyDate(true);
                visibleHN(false);
                DateTime from = new DateTime(dtFrom.DateTime.Year, dtFrom.DateTime.Month, dtFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(dtTo.DateTime.Year, dtTo.DateTime.Month, dtTo.DateTime.Day, 23, 59, 59);
                dtFrom.DateTime = from;
                dtTo.DateTime = to;

                grdData.Enabled = false;
                loadStudyDateData();
                grdData.Enabled = true;
            }
            else if (rdoExamType.Checked)
            {
                grdData.Enabled = false;
                grdData.DataSource = null;
                loadByExamTypeData();
                visibleHN(true);
                visibleStudyDate(false);
                grdData.Enabled = true;
            }
        }
        private void btnPeerReview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            List<int> assignment = new List<int>();
            assignment.Add(Convert.ToInt32(rowHandle["ASSIGNEMENT_ID"].ToString()));
            //assignment.Add(38782);
            frmPopupEvaluationExtend frm = new frmPopupEvaluationExtend(assignment, false);
            frm.ShowDialog();
            frm.Dispose();
        }
        private void btnServirity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //}
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (string.IsNullOrEmpty(rowHandle["SEVERITY_ID"].ToString())) return;

            ProcessGetRISExamresultseverity prc = new ProcessGetRISExamresultseverity();
            prc.RIS_EXAMRESULTSEVERITY.UNIT_ID = env.UnitID;
            prc.Invoke();
            DataView dv = new DataView(prc.Result.Tables[0]);
            dv.RowFilter = "SEVERITY_ID=" + prc.Result.Tables[0].Rows[0]["SEVERITY_ID"].ToString();
            DataTable dtt = dv.ToTable();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("SEVERITY_ID", "SEVERITY_ID", false, true);
            lv.AddColumn("SEVERITY_NAME", "SEVERITY_NAME", true, true);
            lv.AddColumn("SEVERITY_LABEL", "SEVERITY_LABEL", true, true);
            lv.Text = "Severity List";
            lv.Data = dtt;

            Size ss = new Size(510, 300);
            lv.Size = ss;
            lv.StartPosition = FormStartPosition.CenterScreen;
            lv.ShowBox();
        }
        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view1.FocusedRowHandle < dttData.Rows.Count)
                view1.FocusedRowHandle = view1.FocusedRowHandle + 1;
            updateAckOn();
            bindDataControl();

        }
        private void btnPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view1.FocusedRowHandle > 0)
                view1.FocusedRowHandle = view1.FocusedRowHandle - 1;
            updateAckOn();
            bindDataControl();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnPacs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            //if (txtAcc.EditValue == null || string.IsNullOrEmpty(txtAcc.EditValue.ToString())) return;
            //string str = env.PacsUrl + txtAcc.EditValue.ToString().Trim();
            //System.Diagnostics.Process.Start(str);

            string str = env.PacsUrl + view1.GetFocusedDataRow()["ACCESSION_NO"].ToString();
            Miracle.PACS.IECompatible ie = new Miracle.PACS.IECompatible();
            if (!ie.OpenSynapseLink(str))
                msg.ShowAlert("UID4053", env.CurrentLanguageID);

            //// UpdatePacs
            //new OpenPACS(env.PacsUrl).OpenIE(view1.GetFocusedDataRow()["ACCESSION_NO"].ToString(), env.UserName, env.PasswordAD, "", env.LoginType);

        }

        private void rdoDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDate.Checked)
            {
                visibleStudyDate(true);
                visibleHN(false);
            }
        }
        private void rdoHN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExamType.Checked)
            {
                grdData.Enabled = false;
                grdData.DataSource = null;
                loadByExamTypeData();
                visibleHN(true);
                visibleStudyDate(false);
                grdData.Enabled = true;
            }
        }
        private void chkExam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExam.Checked)
            {
                grdData.Enabled = false;
                rdoDate.Enabled = false;
                rdoExamType.Enabled = false;
                pnSearch.Enabled = false;
                btnSearch.Enabled = false;
                loadAllExamData();
                grdData.Enabled = true;
            }
            else
            {
                rdoDate.Enabled = true;
                rdoExamType.Enabled = true;
                pnSearch.Enabled = true;
                btnSearch.Enabled = true;
                grdData.Enabled = true;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdoDate.Checked)
            {
                DateTime from = new DateTime(dtFrom.DateTime.Year, dtFrom.DateTime.Month, dtFrom.DateTime.Day, 0, 0, 0);
                DateTime to = new DateTime(dtTo.DateTime.Year, dtTo.DateTime.Month, dtTo.DateTime.Day, 23, 59, 59);

                dtFrom.DateTime = from;
                dtTo.DateTime = to;

                grdData.Enabled = false;
                loadStudyDateData();
                grdData.Enabled = true;
            }
            else if (rdoExamType.Checked)
            {
                grdData.Enabled = false;
                loadByExamTypeData();
                grdData.Enabled = true;

            }
        }
        private void toolbarFavorite_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (msg.ShowAlert("UID5003", new GBLEnvVariable().CurrentLanguageID) == "2")
            {
                LookUpSelect ls = new LookUpSelect();
                ls.SelectRIS_RADSTUDYGROUP(new GBLEnvVariable().UserID, rowHandle["ACCESSION_NO"].ToString(), true, false, false, "F");
            }
        }       

        private void view1_Click(object sender, EventArgs e)
        {
            bindDataControl();
        }
        private void view1_DoubleClick(object sender, EventArgs e)
        {
            bindDataControl();
            ribbonControl1.SelectedPage = ribReport;
            if (view1.FocusedRowHandle > -1)
                updateAckOn();
        }
        private void view1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = this.view1.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (string.IsNullOrEmpty(dr["ACK_ON"].ToString()))
                        e.Appearance.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                }
            }
        }
        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ribbonControl1.SelectedPage == ribWL)
                tabCtrl.SelectedTabPageIndex = 0;
            else
            {
                bindDataControl();
                tabCtrl.SelectedTabPageIndex = 1;
            }
        }

        private void loadSeverity() 
        {
            ProcessGetRISExamresultseverity proc = new ProcessGetRISExamresultseverity();
            proc.RIS_EXAMRESULTSEVERITY.UNIT_ID = 1;
            proc.Invoke();
            dttSeverity = proc.Result.Tables[0].Copy();
        }
        private void loadExamType()
        {
            cboExamType.Properties.Items.Clear();
            ProcessGetRISExamType get = new ProcessGetRISExamType();
            get.Invoke();
            DataTable dttExamType = get.Result.Tables[0];
            foreach (DataRow dr in dttExamType.Rows)
            {
                cboExamType.Properties.Items.Add(dr["EXAM_TYPE_ID"], dr["EXAM_TYPE_TEXT"].ToString());//, CheckState.Checked, true);
            }
            cboExamType.EditValue = null;
            for (int i = 0; i < cboExamType.Properties.Items.Count; i++) cboExamType.Properties.Items[i].CheckState = CheckState.Unchecked;
            cboExamType.RefreshEditValue();
        }
        private void loadByExamTypeData()
        {
            if (string.IsNullOrEmpty(cboExamType.EditValue.ToString()))
            {
                grdData.DataSource = null;
                return;
            }
            loadAllExamData();
            DataView dv = new DataView(dttData);
            dv.RowFilter = "EXAM_TYPE in (" + cboExamType.EditValue.ToString() + ")";
            dttData = dv.ToTable();
            grdData.DataSource = dttData;
            setGridColumns();
            bindDataControl();
        }

        private void loadStudyDateData()
        {
            try
            {
                dttData = new DataTable();
                dttData = AcademicManagement.GetAcademicWorkListNew(env.UserID, dtFrom.DateTime, dtTo.DateTime);
                //dttData = AcademicManagement.GetAcademicWorkListNew(7310, dtFrom.DateTime, dtTo.DateTime);
                grdData.DataSource = dttData;
                setGridColumns();
                bindDataControl();
            }
            catch
            {
                try
                {
                    dttData = new DataTable();
                    dttData = AcademicManagement.GetAcademicWorkListNew(env.UserID, dtFrom.DateTime, dtTo.DateTime);
                    //dttData = AcademicManagement.GetAcademicWorkListNew(7310, dtFrom.DateTime, dtTo.DateTime);
                    grdData.DataSource = dttData;
                    setGridColumns();
                    bindDataControl();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
        }
        private void loadAllExamData()
        {
            try
            {
                dttData = new DataTable();
                dttData = AcademicManagement.GetAcademicWorkListNew(env.UserID);
                //dttData = AcademicManagement.GetAcademicWorkListNew(7310);
                grdData.DataSource = dttData;
                setGridColumns();
                bindDataControl();
            }
            catch
            {
                try
                {
                    dttData = new DataTable();
                    dttData = AcademicManagement.GetAcademicWorkListNew(env.UserID);
                    //dttData = AcademicManagement.GetAcademicWorkListNew(7310);
                    grdData.DataSource = dttData;
                    setGridColumns();
                    bindDataControl();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source);
                }
            }
        }
        private void setGridColumns() 
        {
            if (dttData == null) return;
            for (int i = 0; i < dttData.Columns.Count; i++)
            {
                view1.Columns[i].OptionsColumn.AllowEdit = false;
                view1.Columns[i].Visible = false;
            }
            #region Columns Edit.
             DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine","R", 6),
                    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent","U", 7),
                    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat","S", 8)});

            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgWL;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            #endregion
            view1.Columns["PRIORITY"].Visible = true;
            view1.Columns["PRIORITY"].Caption = "Priority";
            view1.Columns["PRIORITY"].ColumnEdit = repositoryItemImageComboBox2;
            view1.Columns["PRIORITY"].BestFit();
            view1.Columns["PRIORITY"].ColVIndex = 1;

            view1.Columns["EXAM_UID"].Visible = true;
            view1.Columns["EXAM_UID"].Caption = "Exam Code";
            view1.Columns["EXAM_UID"].Width = 74;
            view1.Columns["EXAM_UID"].ColVIndex = 2;

            view1.Columns["EXAM_NAME"].Visible = true;
            view1.Columns["EXAM_NAME"].Caption = "Exam Name";
            view1.Columns["EXAM_NAME"].Width = 120;
            view1.Columns["EXAM_NAME"].ColVIndex = 3;

            view1.Columns["ACCESSION_NO"].Visible = true;
            view1.Columns["ACCESSION_NO"].Caption = "Accession No.";
            view1.Columns["ACCESSION_NO"].BestFit();
            view1.Columns["ACCESSION_NO"].ColVIndex = 4;

            view1.Columns["STATUS"].Visible = true;
            view1.Columns["STATUS"].Caption = "Status";
            view1.Columns["STATUS"].BestFit();
            view1.Columns["STATUS"].ColVIndex = 5;

            view1.Columns["HN"].Visible = true;
            view1.Columns["HN"].Caption = "HN";
            view1.Columns["HN"].Width = 50;
            view1.Columns["HN"].ColVIndex = 6;

            view1.Columns["PATIENT_NAME"].Visible = true;
            view1.Columns["PATIENT_NAME"].Caption = "Patient Name";
            view1.Columns["PATIENT_NAME"].Width = 120;
            view1.Columns["PATIENT_NAME"].ColVIndex = 7;

            view1.Columns["AGE"].Visible = true;
            view1.Columns["AGE"].Caption = "Age";
            view1.Columns["AGE"].BestFit();
            view1.Columns["AGE"].ColVIndex = 8;

            view1.Columns["FINALIZED_NAME"].Visible = true;
            view1.Columns["FINALIZED_NAME"].Caption = "Finalized By";
            view1.Columns["FINALIZED_NAME"].Width = 100;
            view1.Columns["FINALIZED_NAME"].ColVIndex = 9;

            view1.Columns["FINALIZED_ON"].Visible = true;
            view1.Columns["FINALIZED_ON"].Caption = "Finalized On";
            view1.Columns["FINALIZED_ON"].DisplayFormat.FormatString = "d";
            view1.Columns["FINALIZED_ON"].BestFit();
            view1.Columns["FINALIZED_ON"].ColVIndex = 10;


            view1.Columns["GRADE_VALUE"].Visible = true;
            view1.Columns["GRADE_VALUE"].Caption = "Grade";
            view1.Columns["GRADE_VALUE"].BestFit();
            view1.Columns["GRADE_VALUE"].ColVIndex = 11;

            view1.Columns["REPORT_LANG_VALUE"].Visible = true;
            view1.Columns["REPORT_LANG_VALUE"].Caption = "Language";
            view1.Columns["REPORT_LANG_VALUE"].BestFit();
            view1.Columns["REPORT_LANG_VALUE"].ColVIndex = 12;

            view1.Columns["EVALUATED_NAME"].Visible = true;
            view1.Columns["EVALUATED_NAME"].Caption = "Evaluated By";
            view1.Columns["EVALUATED_NAME"].Width = 100;
            view1.Columns["EVALUATED_NAME"].ColVIndex = 13;

            view1.Columns["EVALUATED_ON"].Visible = true;
            view1.Columns["EVALUATED_ON"].Caption = "Evaluated On";
            view1.Columns["EVALUATED_ON"].DisplayFormat.FormatString = "d";
            view1.Columns["EVALUATED_ON"].BestFit();
            view1.Columns["EVALUATED_ON"].ColVIndex = 14;

            if (Miracle.Util.Utilities.IsHaveData(dttData))
            {
                txtTotal.Text = dttData.Rows.Count.ToString();
                int count = 0;
                foreach (DataRow rowHandle in dttData.Rows)
                    if (!string.IsNullOrEmpty(rowHandle["EVALUATED_BY"].ToString())) count++;
                txtEvaluate.Text = count.ToString();

                //txtAverage.Text = count.ToString();
            }
            else
            {
                txtTotal.Text = "0";
                //txtAverage.Text = "0";
                txtEvaluate.Text = "0";
            }
        }
        private void bindDataControl()
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            DataRow rowBind = AcademicManagement.GetBindData(rowHandle["ACCESSION_NO"].ToString()).Rows[0];

            txtResult.Text = rowBind["RESULT_TEXT_PLAIN"].ToString();
            txtStudy.Text = rowHandle["REPORT_TEXT"].ToString();

            txtInfoHn.Text = rowHandle["HN"].ToString();
            txtInfoPatientName.Text = rowHandle["PATIENT_NAME"].ToString();
            string gender = rowBind["GENDER"].ToString();
            if (!string.IsNullOrEmpty(gender))
                txtInfoGender.Text = gender == "M" || gender == "ช" ? "Male" : "Female";
            txtInfoAge.Text = rowHandle["AGE"].ToString();

            txtInfoPriority.Text = rowHandle["PRIORITY"].ToString() == "R" ? "Routine" : rowHandle["PRIORITY"].ToString() == "S" ? "Stat" : rowHandle["PRIORITY"].ToString() == "U" ? "Urgent" : string.Empty;
            txtInfoExamName.Text = rowHandle["EXAM_NAME"].ToString();
            txtInfoFinalizedBy.Text = rowHandle["FINALIZED_NAME"].ToString();
            txtInfoFinalizedOn.Text = rowHandle["FINALIZED_ON"].ToString();
            txtInfoAccessionNo.Text = rowHandle["ACCESSION_NO"].ToString();
            txtInfoStatus.Text = rowHandle["STATUS"].ToString();

            if (dttSeverity != null)
            {
                DataRow[] rows = dttSeverity.Select("SEVERITY_ID= " + rowBind["SEVERITY_ID"].ToString());
                if (rows != null && rows.Length > 0) grpResult.Text = "Result Report (Severity : " + rows[0]["SEVERITY_LABEL"].ToString() + ")";
                rows = dttSeverity.Select("SEVERITY_ID= " + rowHandle["SVID"].ToString());
                if (rows != null && rows.Length > 0) grpResident.Text = "My Report (Severity : " + rows[0]["SEVERITY_LABEL"].ToString() + ")";
            }
        }

        private void updateAckOn() 
        {
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (string.IsNullOrEmpty(rowHandle["ACK_ON"].ToString()))
            {
                int Id = Convert.ToInt32(rowHandle["ASSIGNEMENT_ID"].ToString());
                rowHandle["ACK_ON"] = DateTime.Now;
                ProcessUpdateACEnrollment proc = new ProcessUpdateACEnrollment();
                proc.UpdateAck(Id);
            }
        }
        private void visibleStudyDate(bool flag) {
            lblFrom.Visible = flag;
            dtFrom.Visible = flag;
            lblTo.Visible = flag;
            dtTo.Visible = flag;
        }
        private void visibleHN(bool flag) {
            cboExamType.Text = string.Empty;
            cboExamType.Visible = flag;
        }
    }
}
