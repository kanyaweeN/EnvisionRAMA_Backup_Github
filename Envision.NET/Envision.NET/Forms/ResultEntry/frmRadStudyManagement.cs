using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using Envision.Common;
using Envision.NET.Forms.EMR;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.Plugin.ReportManager;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmRadStudyManagement : MasterForm
    {
        private DataTable dtRadStudy;

        private DataTable dtComboTags;
        private DataTable dtComboBodyPart;
        private DataTable dtComboCPT;
        private DataTable dtComboICD;
        private DataTable dtComboACR;

        private GBLEnvVariable env = new GBLEnvVariable();

        private DataTable tbTags = new DataTable();
        private DataTable tbACR = new DataTable();
        private DataTable tbBodyPart = new DataTable();
        private DataTable tbCPT = new DataTable();
        private DataTable tbICD = new DataTable();

        public frmRadStudyManagement()
        {
            InitializeComponent();
        }
        private void frmRadStudyManagement_Load(object sender, EventArgs e)
        {
            txtDateFrom.DateTime = DateTime.Now.AddMonths(-3);
            txtDateTo.DateTime = DateTime.Now;
            laySearchCriteria.Expanded = false;

            ReloadMultiCheckedCombobox();
            ReloadRadStudyManagement();

            base.CloseWaitDialog();
        }

        private void LoadMultiCheckedComboboxData()
        {
            LookUpSelect lkp = new LookUpSelect();

            dtComboTags = lkp.SelectRadStudyManagementTags().Tables[0];
            dtComboBodyPart = lkp.SelectRadStudyManagementBodyPart().Tables[0];
            dtComboCPT = lkp.SelectRadStudyManagementCPT().Tables[0];
            dtComboICD = lkp.SelectRadStudyManagementICD().Tables[0];
            dtComboACR = lkp.SelectRadStudyManagementACR().Tables[0];
        }
        private void LoadMultiCheckedComboboxFilter()
        {

        }
        private void LoadMultiCheckedComboboxGrid()
        {
            //Tags
            txtTags.Text = string.Empty;
            tbTags.Rows.Clear();
            
            //Body Part
            txtBodyPart.Text = string.Empty;
            tbBodyPart.Rows.Clear();

            //CPT
            txtCPT.Text = string.Empty;
            tbCPT.Rows.Clear();

            //ICD
            txtICD.Text = string.Empty;
            tbICD.Rows.Clear();

            //ACR
            txtACR.Text = string.Empty;
            tbACR.Rows.Clear();
        }
        private void ReloadMultiCheckedCombobox()
        {
            LoadMultiCheckedComboboxData();
            LoadMultiCheckedComboboxFilter();
            LoadMultiCheckedComboboxGrid();
        }

        private void LoadRadStudyManagementData()
        {
            DateTime df;
            DateTime dt;

            if (chkShowAll.CheckState == CheckState.Unchecked)
            {
                df = txtDateFrom.DateTime;
                dt = txtDateTo.DateTime;
            }
            else
            {
                df = new DateTime(1900, 01, 01);
                dt = new DateTime(2100, 01, 01);
            }

            ProcessGetRISStudyLibrary getStudy = new ProcessGetRISStudyLibrary();
            getStudy.RIS_STUDYLIBRARY.MODE = "StudyDate";
            getStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            getStudy.RIS_STUDYLIBRARY.DateFrom = new DateTime(df.Year, df.Month, df.Day, 0, 0, 0);
            getStudy.RIS_STUDYLIBRARY.DateTo = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            getStudy.GetData();
            dtRadStudy = getStudy.Result.Tables[0];

            dtRadStudy.Columns.Add("VIEW_IMAGE");
            dtRadStudy.Columns.Add("VIEW_ORDER");
            dtRadStudy.Columns.Add("VIEW_REPORT");

            foreach (DataRow dr in dtRadStudy.Rows)
            {
                dr["VIEW_IMAGE"] = "";
                dr["VIEW_ORDER"] = "";
                dr["VIEW_REPORT"] = "";
            }

            dtRadStudy.AcceptChanges();
        }
        private void LoadRadStudyManagementFilter()
        {
            //DataTable dtTmp = dtRadStudy.Clone();
            //DataRow[] rows = dtRadStudy.Select("LAST_MODIFIED_BY=" + new GBLEnvVariable().UserID);

            //foreach (DataRow dr in rows)
            //    dtTmp.Rows.Add(dr.ItemArray);

            //dtRadStudy = dtTmp.Copy();
        }
        private void LoadRadStudyManagementGrid()
        {
            gcRadStudyManage.DataSource = dtRadStudy;

            foreach (BandedGridColumn col in gvRadStudyManage.Columns)
            {
                col.OptionsColumn.AllowEdit = false;
                col.Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox
                repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Buttons.Clear();
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] 
            {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "F, T, R", 0),

                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "F, T", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "F, R", 2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "T, R", 3),

                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "F", 4),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "T", 5),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
            });
            repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            repositoryItemImageComboBox2.SmallImages = imgType;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 1 AND RIS_STUDYLIBRARY.IS_TEACHING = 1 AND RIS_STUDYLIBRARY.IS_RESEARCH = 1
            //then 'F, T, R'

            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 1 AND RIS_STUDYLIBRARY.IS_TEACHING = 1 AND RIS_STUDYLIBRARY.IS_RESEARCH = 0
            //then 'F, T'
            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 1 AND RIS_STUDYLIBRARY.IS_TEACHING = 0 AND RIS_STUDYLIBRARY.IS_RESEARCH = 1
            //then 'F, R'
            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 0 AND RIS_STUDYLIBRARY.IS_TEACHING = 1 AND RIS_STUDYLIBRARY.IS_RESEARCH = 1
            //then 'T, R'

            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 1 AND RIS_STUDYLIBRARY.IS_TEACHING = 0 AND RIS_STUDYLIBRARY.IS_RESEARCH = 0
            //then 'F'		
            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 0 AND RIS_STUDYLIBRARY.IS_TEACHING = 1 AND RIS_STUDYLIBRARY.IS_RESEARCH = 0
            //then 'T'
            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 0 AND RIS_STUDYLIBRARY.IS_TEACHING = 0 AND RIS_STUDYLIBRARY.IS_RESEARCH = 1
            //then 'R'

            //when RIS_STUDYLIBRARY.IS_FAVOURITE = 0 AND RIS_STUDYLIBRARY.IS_TEACHING = 0 AND RIS_STUDYLIBRARY.IS_RESEARCH = 0
            //then ''

            //gvRadStudyManage.Columns["LOCATION"].ColVIndex = 1;
            //gvRadStudyManage.Columns["LOCATION"].Caption = "Location";

            gvRadStudyManage.Columns["ADDED"].ColVIndex = 1;
            gvRadStudyManage.Columns["ADDED"].Caption = "Type";
            gvRadStudyManage.Columns["ADDED"].ColumnEdit = repositoryItemImageComboBox2;
            gvRadStudyManage.Columns["ADDED"].Width = 40;

            gvRadStudyManage.Columns["HN"].ColVIndex = 2;
            gvRadStudyManage.Columns["HN"].Caption = "HN";

            gvRadStudyManage.Columns["PATIENT_NAME"].ColVIndex = 3;
            gvRadStudyManage.Columns["PATIENT_NAME"].Caption = "Patient name";

            gvRadStudyManage.Columns["EXAM_UID"].ColVIndex = 4;
            gvRadStudyManage.Columns["EXAM_UID"].Caption = "Exam Code";

            gvRadStudyManage.Columns["EXAM_NAME"].ColVIndex = 5;
            gvRadStudyManage.Columns["EXAM_NAME"].Caption = "Exam Name";

            gvRadStudyManage.Columns["ORDER_DT"].ColVIndex = 6;
            gvRadStudyManage.Columns["ORDER_DT"].Caption = "Study datetime";

            gvRadStudyManage.Columns["LAST_MODIFIED_NAME"].ColVIndex = 7;
            gvRadStudyManage.Columns["LAST_MODIFIED_NAME"].Caption = "Last saved by";

            gvRadStudyManage.Columns["ACCESSION_NO"].ColVIndex = 8;
            gvRadStudyManage.Columns["ACCESSION_NO"].Caption = "Accession No.";

            gvRadStudyManage.Columns["VIEW_IMAGE"].ColVIndex = 9;
            gvRadStudyManage.Columns["VIEW_IMAGE"].Caption = "View image";
            gvRadStudyManage.Columns["VIEW_IMAGE"].OptionsColumn.AllowEdit = true;
            gvRadStudyManage.Columns["VIEW_IMAGE"].Width = 40;

            gvRadStudyManage.Columns["VIEW_ORDER"].ColVIndex = 10;
            gvRadStudyManage.Columns["VIEW_ORDER"].Caption = "View order";
            gvRadStudyManage.Columns["VIEW_ORDER"].OptionsColumn.AllowEdit = true;
            gvRadStudyManage.Columns["VIEW_ORDER"].Width = 40;

            gvRadStudyManage.Columns["VIEW_REPORT"].ColVIndex = 11;
            gvRadStudyManage.Columns["VIEW_REPORT"].Caption = "View report";
            gvRadStudyManage.Columns["VIEW_REPORT"].OptionsColumn.AllowEdit = true;
            gvRadStudyManage.Columns["VIEW_REPORT"].Width = 40;

            gvRadStudyManage.Columns["PRIORITY"].ColVIndex = 12;
            gvRadStudyManage.Columns["PRIORITY"].Caption = "Priority";

            gvRadStudyManage.Columns["TAGS"].ColVIndex = 13;
            gvRadStudyManage.Columns["TAGS"].Caption = "Tags";

            gvRadStudyManage.Columns["LEVEL"].ColVIndex = 14;
            gvRadStudyManage.Columns["LEVEL"].Caption = "Difficulty";

            gvRadStudyManage.Columns["BODY_PART"].ColVIndex = 15;
            gvRadStudyManage.Columns["BODY_PART"].Caption = "Body Part";

            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
            link.Image = imgHIS.Images[3];
            link.Click += new EventHandler(linkPacs_Click);
            gvRadStudyManage.Columns["VIEW_IMAGE"].ColumnEdit = link;

            RepositoryItemHyperLinkEdit linkOrder = new RepositoryItemHyperLinkEdit();
            linkOrder.Image = imgHIS.Images[4];
            linkOrder.Click += new EventHandler(linkOrder_Click);
            gvRadStudyManage.Columns["VIEW_ORDER"].ColumnEdit = linkOrder;

            RepositoryItemHyperLinkEdit linkReport = new RepositoryItemHyperLinkEdit();
            linkReport.Image = imgHIS.Images[5];
            linkReport.Click += new EventHandler(linkReport_Click);
            gvRadStudyManage.Columns["VIEW_REPORT"].ColumnEdit = linkReport;
        }
        private void ReloadRadStudyManagement()
        {
            LoadRadStudyManagementData();
            LoadRadStudyManagementFilter();
            LoadRadStudyManagementGrid();
        }

        private void linkOrder_Click(object sender, EventArgs e)
        {
            if (gvRadStudyManage.FocusedRowHandle > -1)
            {
                DataRow dr = gvRadStudyManage.GetDataRow(gvRadStudyManage.FocusedRowHandle);
                frmPopupOrderOrScheduleSummary orderSummary = new frmPopupOrderOrScheduleSummary(); 
                orderSummary.ShowDialog(dr["ACCESSION_NO"].ToString());
            }
        }
        private void linkPacs_Click(object sender, EventArgs e)
        {
            if (gvRadStudyManage.FocusedRowHandle > -1)
            {
                DataRow dr = gvRadStudyManage.GetDataRow(gvRadStudyManage.FocusedRowHandle);
                openPACS(dr["ACCESSION_NO"].ToString().Trim(), false);
            }
        }
        private void linkReport_Click(object sender, EventArgs e)
        {
            if (gvRadStudyManage.FocusedRowHandle > -1)
            {
                //DataRow dr = gvRadStudyManage.GetDataRow(gvRadStudyManage.FocusedRowHandle);
                //string AccessionNo = dr["ACCESSION_NO"].ToString().Trim();
                //string ExamName = dr["ACCESSION_NO"].ToString().Trim();
                //int OrderID = Convert.ToInt32(dr["ORDER_ID"].ToString().Trim());
                //string HN = dr["HN"].ToString().Trim();
                //frmAddendum frmAdden = new frmAddendum(AccessionNo, ExamName, OrderID, HN);
                //frmAdden.ShowDialog();

                PrintPreview();

            }
        }
        private string openPACS(string AccessionNumber, bool is_blank)
        {
            GBLEnvVariable env = new GBLEnvVariable();
            string str = env.PacsUrl + AccessionNumber;
            if (env.LoginType == "W")
            {
                str = env.PacsUrl;
                str = str.Replace("http://", string.Empty);
                str = "http://radiology%5C" + env.UserName + ":" + env.PasswordAD + "@" + str + AccessionNumber;
            }

            if (is_blank)
                System.Diagnostics.Process.Start(str, "_blank");
            else
                System.Diagnostics.Process.Start(str);
            return str;
        }
        private void PrintPreview()
        {
            DataRow dr = gvRadStudyManage.GetDataRow(gvRadStudyManage.FocusedRowHandle);

            string _accno = dr["ACCESSION_NO"].ToString();
            string _status = dr["RESULT_STATUS"].ToString();
            int auth = 0;
            if (_status == "Draft")
            {
                auth = 2;
            }
            else if (_status == "Prelim")
            {
                auth = 3;
            }
            else
            {
                auth = 4;
            }

            ReportMangager rptMng = new ReportMangager();

            switch (dr["PAT_DEST"].ToString()) //Considering from Patient Destination Label
            {
                case "DIAG":
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
                case "AIMC":
                    rptMng.ResultEntryDirectPrintA4AIMC(_accno);
                    break;
                case "MAMMO":
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
                case "SDMC":
                    rptMng.ResultEntryDirectPrintA4SDMC(_accno);
                    break;
                case "ER":
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
                default:
                    rptMng.ResultEntryDirectPrintA4(_accno);
                    break;
            }
        }

        private void btnRipRemoveFavorite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipRemoveTeaching_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipAddFavorite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipAddTeaching_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvRadStudyManage_DoubleClick();
        }
        private void btnRipClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadRadStudyManagement();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControlData();
        }
        private void ClearControlData()
        {
            txtHN.Text = "";

            txtDateFrom.DateTime = DateTime.Now.AddMonths(-3);
            txtDateTo.DateTime = DateTime.Now;

            txtACR.Text = "";
            txtBodyPart.Text = "";
            txtCPT.Text = "";
            txtICD.Text = "";
            txtTags.Text = "";
        }
        private void rdoSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoSearchMode.SelectedIndex == 0)
            {
                ClearControlData();
                ReloadRadStudyManagement();
                laySearchCriteria.Expanded = false;
                laySearchCriteria.Enabled = false;
            }
            else
            {
                laySearchCriteria.Expanded = true;
                laySearchCriteria.Enabled = true;
            }
        }

        private void gvRadStudyManage_DoubleClick(object sender, EventArgs e)
        {
            gvRadStudyManage_DoubleClick();
        }
        private void gvRadStudyManage_DoubleClick()
        {
            if (gvRadStudyManage.FocusedRowHandle < 0) return;

            DataRow row = gvRadStudyManage.GetFocusedDataRow();
            string AccessionNo = row["ACCESSION_NO"].ToString();
            string ExamName = row["EXAM_NAME"].ToString();

            //frmPopupRadstudyGroup frm = new frmPopupRadstudyGroup(new GBLEnvVariable().UserID, AccessionNo, true, false, false, ExamName);
            //frm.ShowDialog();

            frmPopupRadstudyGroup frm = new frmPopupRadstudyGroup(new GBLEnvVariable().UserID, AccessionNo, true, false, false, "F", ExamName);
            frm.ShowDialog();
        }
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            ReloadRadStudyManagement();
        }
        
        //private void btnTags_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnACR_Click(object sender, EventArgs e)
        //{
        //    DataTable dtResult = new DataTable();
        //    frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup();

        //    LookUpSelect lks = new LookUpSelect();
        //    lookup.DataSource = lks.SelectRadStudyManagementACR().Tables[0];
        //    lookup.ColumnFirst = "ACR_ID";
        //    lookup.ColumnSecond = "ACR_UID";
        //    lookup.ColumnThird = "ACR_DESC";
        //    lookup.FormHeaderName = "ACR";
        //    lookup.ValueUpdated += new Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventHandler(ACR_ValueUpdated);
        //    lookup.ShowDialog();
        //}
        //private void ACR_ValueUpdated(object sender, Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventArgs e)
        //{
        //    tbACR = e.NewValue.Copy();
        //    txtACR.Text = string.Empty;

        //    foreach (DataRow dr in tbACR.Rows)
        //    {
        //        txtACR.Text += dr["ACR_DESC"].ToString() + ",";
        //    }

        //    if (txtACR.Text.Trim().Length != 0)
        //        txtACR.Text = txtACR.Text.Remove(txtACR.Text.LastIndexOf(","));
        //}

        //private void btnBodyPart_Click(object sender, EventArgs e)
        //{
        //    DataTable dtResult = new DataTable();
        //    frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup();

        //    LookUpSelect lks = new LookUpSelect();
        //    lookup.DataSource = lks.SelectRadStudyManagementBodyPart().Tables[0];
        //    lookup.ColumnFirst = "EXAM_SKILLTYPE_ID";
        //    lookup.ColumnSecond = "EXAM_SKILLTYPE_UID";
        //    lookup.ColumnThird = "EXAM_SKILLTYPE_NAME";
        //    lookup.FormHeaderName = "Body Part";
        //    lookup.ValueUpdated += new Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventHandler(BodyPart_ValueUpdated);
        //    lookup.ShowDialog();
        //}
        //private void BodyPart_ValueUpdated(object sender, Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventArgs e)
        //{
        //    tbBodyPart = e.NewValue.Copy();
        //    txtBodyPart.Text = string.Empty;

        //    foreach (DataRow dr in tbBodyPart.Rows)
        //    {
        //        txtBodyPart.Text += dr["EXAM_SKILLTYPE_NAME"].ToString() + ",";
        //    }

        //    if (txtBodyPart.Text.Trim().Length != 0)
        //        txtBodyPart.Text = txtBodyPart.Text.Remove(txtBodyPart.Text.LastIndexOf(","));
        //}

        //private void btnCPT_Click(object sender, EventArgs e)
        //{
        //    DataTable dtResult = new DataTable();
        //    frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup();

        //    LookUpSelect lks = new LookUpSelect();
        //    lookup.DataSource = lks.SelectRadStudyManagementCPT().Tables[0];
        //    lookup.ColumnFirst = "CPT_ID";
        //    lookup.ColumnSecond = "CPT_UID";
        //    lookup.ColumnThird = "CPT_DESC";
        //    lookup.FormHeaderName = "CPT";
        //    lookup.ValueUpdated += new Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventHandler(CPT_ValueUpdated);
        //    lookup.ShowDialog();
        //}
        //private void CPT_ValueUpdated(object sender, Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventArgs e)
        //{
        //    tbCPT = e.NewValue.Copy();
        //    txtCPT.Text = string.Empty;

        //    foreach (DataRow dr in tbCPT.Rows)
        //    {
        //        txtCPT.Text += dr["CPT_DESC"].ToString() + ",";
        //    }

        //    if (txtCPT.Text.Trim().Length != 0)
        //        txtCPT.Text = txtCPT.Text.Remove(txtCPT.Text.LastIndexOf(","));
        //}

        //private void btnICD_Click(object sender, EventArgs e)
        //{
        //    DataTable dtResult = new DataTable();
        //    frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup();

        //    LookUpSelect lks = new LookUpSelect();
        //    lookup.DataSource = lks.SelectRadStudyManagementICD().Tables[0];
        //    lookup.ColumnFirst = "ICD_ID";
        //    lookup.ColumnSecond = "ICD_UID";
        //    lookup.ColumnThird = "ICD_DESC";
        //    lookup.FormHeaderName = "ICD";
        //    lookup.ValueUpdated += new Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventHandler(ICD_ValueUpdated);
        //    lookup.ShowDialog();
        //}
        //private void ICD_ValueUpdated(object sender, Envision.NET.Forms.ResultEntry.Lookup.ValueUpdatedEventArgs e)
        //{
        //    tbICD = e.NewValue.Copy();
        //    txtICD.Text = string.Empty;

        //    foreach (DataRow dr in tbICD.Rows)
        //    {
        //        txtICD.Text += dr["ICD_DESC"].ToString() + ",";
        //    }

        //    if (txtICD.Text.Trim().Length != 0)
        //        txtICD.Text = txtICD.Text.Remove(txtICD.Text.LastIndexOf(","));
        //}
    }
}
