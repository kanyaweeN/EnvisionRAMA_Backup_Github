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
    public partial class frmStudyLibrary : MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();

        private DataTable dtRadStudy;

        DataTable tbTags;
        DataTable tbShareWith;
        DataTable tbBodyPart;
        DataTable tbACR;
        DataTable tbCPT;
        DataTable tbICD;
        DataTable tbConference;

        public frmStudyLibrary()
        {
            InitializeComponent();
        }
        private void frmRadStudyManagement_Load(object sender, EventArgs e)
        {
            txtDateFrom.DateTime = DateTime.Now.AddMonths(-1);
            txtDateTo.DateTime = DateTime.Now;
            laySearchCriteria.Expanded = false;

            rdoSearchMode.SelectedIndex = 0;
            tabControl.SelectedTabPage = tabPageStudyDate;

            ReloadRadStudyManagement();

            base.CloseWaitDialog();
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

            if (rdoSearchMode.SelectedIndex == 0)
            {
                ProcessGetRISStudyLibrary getStudy = new ProcessGetRISStudyLibrary();
                getStudy.RIS_STUDYLIBRARY.MODE = "StudyDate";
                getStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                getStudy.RIS_STUDYLIBRARY.DateFrom = new DateTime(df.Year, df.Month, df.Day, 0, 0, 0);
                getStudy.RIS_STUDYLIBRARY.DateTo = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                getStudy.RIS_STUDYLIBRARY.HN = txtHN.Text;
                getStudy.GetData();
                dtRadStudy = getStudy.Result.Tables[0];
            }
            else if (rdoSearchMode.SelectedIndex == 1)
            {
                ProcessGetRISStudyLibrary getStudy = new ProcessGetRISStudyLibrary();
                getStudy.RIS_STUDYLIBRARY.MODE = "HN";
                getStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                getStudy.RIS_STUDYLIBRARY.DateFrom = DateTime.Now;
                getStudy.RIS_STUDYLIBRARY.DateTo = DateTime.Now;
                getStudy.RIS_STUDYLIBRARY.HN = txtHN.Text;
                getStudy.GetData();
                dtRadStudy = getStudy.Result.Tables[0];
            }

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
            if (chkSearchStudyType.CheckedItems.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem chkItem in chkSearchStudyType.CheckedItems)
                {
                    filEx += "ADDED like '%" + chkItem.Description.Substring(0, 1) + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }

            if (chkSearchSharedWith.CheckedItems.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem chkItem in chkSearchSharedWith.CheckedItems)
                {
                    filEx += "LEVEL like '%" + chkItem.Description + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }

            if (txtTags.Text.Trim().Length > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string[] splitTags = txtTags.Text.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                string filEx = "";
                foreach (string tag in splitTags)
                    filEx += "TAGS like '%" + tag + "%' OR ";
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                try
                {
                    DataRow[] rows = dtRadStudy.Select(filEx);
                    if (rows.Length == 0)
                    {
                        dtRadStudy = tbTemp;
                        dtRadStudy.AcceptChanges();
                    }
                    else
                    {
                        dtRadStudy = tbTemp;
                        foreach (DataRow dr in rows)
                            dtRadStudy.Rows.Add(dr.ItemArray);
                    }
                }
                catch { }
            }

            if (tbBodyPart != null && tbBodyPart.Rows.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DataRow dr in tbBodyPart.Rows)
                {
                    filEx += "SUMMARY_BODYPART like '%" + dr["EXAM_SKILL_NAME"] + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }

            if (tbCPT != null && tbCPT.Rows.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DataRow dr in tbCPT.Rows)
                {
                    filEx += "SUMMARY_CPT like '%" + dr["CPT_DESC"] + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }

            if (tbICD != null && tbICD.Rows.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DataRow dr in tbICD.Rows)
                {
                    filEx += "SUMMARY_ICD like '%" + dr["ICD_DESC"] + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }

            if (tbACR != null && tbACR.Rows.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();

                string filEx = "";
                foreach (DataRow dr in tbACR.Rows)
                {
                    filEx += "SUMMARY_ACR like '%" + dr["ACR_DESC"] + "%' OR ";
                }
                if (filEx.Trim().Length > 0)
                {
                    int lastIdx = filEx.LastIndexOf("OR");
                    filEx = filEx.Substring(0, lastIdx - 1);
                }

                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }
            if (tbConference != null && tbConference.Rows.Count > 0)
            {
                DataTable tbTemp = dtRadStudy.Clone();
                string _filterConferece = "";
                foreach (DataRow dr in tbConference.Rows)
                {
                    _filterConferece += dr["CONFERENCE_ID"].ToString() + ", ";
                }

                if (_filterConferece.Length > 0)
                    _filterConferece = _filterConferece.Substring(0, _filterConferece.Length - 2);
                string filEx = @"CONFERENCE_ID like '%" + _filterConferece + "%'";
                DataRow[] rows = dtRadStudy.Select(filEx);
                if (rows.Length == 0)
                {
                    dtRadStudy = tbTemp;
                    dtRadStudy.AcceptChanges();
                }
                else
                {
                    dtRadStudy = tbTemp;
                    foreach (DataRow dr in rows)
                        dtRadStudy.Rows.Add(dr.ItemArray);
                }
            }
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
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "C", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "All", 8),
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

        //Ribbon Menu
        private void btnRipAddRemoveFavorite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipAddRemoveTeaching_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipAddRemoveResearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnRipEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gvRadStudyManageEditData();
        }
        private void btnRipClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        //Search Control
        private void rdoSearchMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoSearchMode.SelectedIndex == 0)
            {
                tabControl.SelectedTabPage = tabPageStudyDate;
                ReloadRadStudyManagement();
            }
            else
            {
                tabControl.SelectedTabPage = tabPageHN;
                ReloadRadStudyManagement();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadRadStudyManagement();
        }
        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            ReloadRadStudyManagement();
        }
        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ReloadRadStudyManagement();
            }
        }

        private void txtTags_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ReloadRadStudyManagement();
            }
        }
        private void chkSearchStudyType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            ReloadRadStudyManagement();
        }
        private void chkSearchSharedWith_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            ReloadRadStudyManagement();
        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            //frmStudyLibraryPopupAddEditLookup lookup = new frmStudyLibraryPopupAddEditLookup(ref tbTags);

            //LookUpSelect lks = new LookUpSelect();
            //lookup.DataSource = lks.SelectRadStudyManagementTags().Tables[0];
            //lookup.ColumnFirst = "ACR_ID";
            //lookup.ColumnSecond = "ACR_UID";
            //lookup.ColumnThird = "ACR_DESC";
            //lookup.FormHeaderName = "ICD";

            //if (lookup.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
        private void btnBodyPart_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup
                = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementBodyPart().Tables[0];
            lookup.ColumnFirst = "EXAM_SKILL_ID";
            lookup.ColumnSecond = "EXAM_SKILL_UID";
            lookup.ColumnThird = "EXAM_SKILL_NAME";
            lookup.FormHeaderName = "Body Part";

            lookup.retValue = tbBodyPart;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnBodyPart_Click_ValueUpdated);
            lookup.ShowDialog();
        }
        private void btnCPT_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup
                = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementCPT().Tables[0];
            lookup.ColumnFirst = "CPT_ID";
            lookup.ColumnSecond = "CPT_UID";
            lookup.ColumnThird = "CPT_DESC";
            lookup.FormHeaderName = "CPT";

            lookup.retValue = tbCPT;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnCPT_Click_ValueUpdated);
            lookup.ShowDialog();
        }
        private void btnICD_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup
                = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementICD().Tables[0];
            lookup.ColumnFirst = "ICD_ID";
            lookup.ColumnSecond = "ICD_UID";
            lookup.ColumnThird = "ICD_DESC";
            lookup.FormHeaderName = "ICD";

            lookup.retValue = tbICD;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnICD_Click_ValueUpdated);
            lookup.ShowDialog();
        }
        private void btnACR_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup
                = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementACR().Tables[0];
            lookup.ColumnFirst = "ACR_ID";
            lookup.ColumnSecond = "ACR_UID";
            lookup.ColumnThird = "ACR_DESC";
            lookup.FormHeaderName = "ICD";

            lookup.retValue = tbACR;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnACR_Click_ValueUpdated);
            lookup.ShowDialog();
        }
        private void btnConferance_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup
               = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementConference().Tables[0];
            lookup.ColumnFirst = "CONFERENCE_ID";
            lookup.ColumnSecond = "CONFERENCE_TEXT";
            lookup.ColumnThird = "CONFERENCE_DESC";
            lookup.FormHeaderName = "Conference";

            lookup.retValue = tbConference;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnConference_Click_ValueUpdated);
            lookup.ShowDialog();
        }

        private void btnBodyPart_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbBodyPart = e.NewValue;
            txtBodyPart.Text = "";

            foreach (DataRow dr in tbBodyPart.Rows)
            {
                txtBodyPart.Text += dr["EXAM_SKILL_NAME"].ToString() + ", ";
            }

            string strCut = txtBodyPart.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtBodyPart.Text = strCut;

            ReloadRadStudyManagement();
        }
        private void btnCPT_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbCPT = e.NewValue;
            txtCPT.Text = "";

            foreach (DataRow dr in tbCPT.Rows)
            {
                txtCPT.Text += dr["CPT_DESC"].ToString() + ", ";
            }

            string strCut = txtCPT.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtCPT.Text = strCut;

            ReloadRadStudyManagement();
        }
        private void btnICD_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbICD = e.NewValue;
            txtICD.Text = "";

            foreach (DataRow dr in tbICD.Rows)
            {
                txtICD.Text += dr["ICD_DESC"].ToString() + ", ";
            }

            string strCut = txtICD.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtICD.Text = strCut;

            ReloadRadStudyManagement();
        }
        private void btnACR_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbConference = e.NewValue;
            txtConferance.Text = "";

            foreach (DataRow dr in tbACR.Rows)
            {
                txtConferance.Text += dr["CONFERENCE_TEXT"].ToString() + ", ";
            }

            string strCut = txtConferance.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtConferance.Text = strCut;

            ReloadRadStudyManagement();
        }
        private void btnConference_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {

            tbConference = e.NewValue;
            txtConferance.Text = "";

            foreach (DataRow dr in tbConference.Rows)
            {
                txtConferance.Text += dr["CONFERENCE_TEXT"].ToString() + ", ";
            }

            string strCut = txtConferance.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtConferance.Text = strCut;

            ReloadRadStudyManagement();
        }

        //Grid Control
        private void gvRadStudyManage_DoubleClick(object sender, EventArgs e)
        {
            gvRadStudyManageEditData();
        }
        private void gvRadStudyManageEditData()
        {
            if (gvRadStudyManage.FocusedRowHandle < 0) return;

            DataRow row = gvRadStudyManage.GetFocusedDataRow();
            string AccessionNo = row["ACCESSION_NO"].ToString();
            string ExamName = row["EXAM_NAME"].ToString();

            frmStudyLibraryPopupAddEdit frm = new frmStudyLibraryPopupAddEdit(AccessionNo);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReloadRadStudyManagement();
            }
        }
        private void gvRadStudyManage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void linkOrder_Click(object sender, EventArgs e)
        {
            if (gvRadStudyManage.FocusedRowHandle > -1)
            {
                DataRow dr = gvRadStudyManage.GetDataRow(gvRadStudyManage.FocusedRowHandle);
                frmPopupOrderOrScheduleSummary orderSummary = new frmPopupOrderOrScheduleSummary();
                orderSummary.ShowDialog(true, dr["ACCESSION_NO"].ToString());
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


    }
}
