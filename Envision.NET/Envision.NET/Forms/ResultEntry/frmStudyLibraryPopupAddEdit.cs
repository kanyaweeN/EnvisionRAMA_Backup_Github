using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.NET.Forms.Dialog;

using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Columns;
using Envision.NET.Forms.ResultEntry;


namespace Envision.NET.Forms.Dialog
{
    public partial class frmStudyLibraryPopupAddEdit : DevExpress.XtraBars.Ribbon.RibbonForm//  Form
    {
        GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        DataTable tbStudyLib;

        DataTable tbTags;
        DataTable tbShareWith;
        DataTable tbBodyPart;
        DataTable tbACR;
        DataTable tbCPT;
        DataTable tbICD;
        DataTable tbTagsAll;
        DataTable tbConferenceAdd;
        DataTable tbConferenceDelete;

        string ACCESSION_NO;
        string TagKeyword;

        public frmStudyLibraryPopupAddEdit(string ACCESSION_NO)
        {
            InitializeComponent();
            this.ACCESSION_NO = ACCESSION_NO;
        }
        public frmStudyLibraryPopupAddEdit(string ACCESSION_NO, string STATUS)
        {
            InitializeComponent();
            this.ACCESSION_NO = ACCESSION_NO;

            if (STATUS == "F")
                chkAddTo.Items[0].CheckState = CheckState.Checked;           
            else if (STATUS == "T")
                chkAddTo.Items[1].CheckState = CheckState.Checked;
            else if (STATUS == "R")
                chkAddTo.Items[2].CheckState = CheckState.Checked;
            else if (STATUS == "C")
                chkAddTo.Items[3].CheckState = CheckState.Checked;
        }
        private void frmPopupRadstudyGroup_Load(object sender, EventArgs e)
        {
            ReloadRadStudyGroup();

            if (chkAddTo.Items[1].CheckState == CheckState.Checked || chkAddTo.Items[3].CheckState == CheckState.Checked)
                EnableDisableShareWithControl(true);
            else
                EnableDisableShareWithControl(false);
        }

        private void LoadRadStudyGroupData()
        {
            ProcessGetRISStudyLibrary getStudy = new ProcessGetRISStudyLibrary();
            getStudy.RIS_STUDYLIBRARY.MODE = "AccessionNo";
            getStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            getStudy.RIS_STUDYLIBRARY.DateFrom = DateTime.Now;
            getStudy.RIS_STUDYLIBRARY.DateTo = DateTime.Now;
            getStudy.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            getStudy.GetData();
            tbStudyLib = getStudy.Result.Tables[0];

            ProcessGetRISStudyLibrary getACR = new ProcessGetRISStudyLibrary();
            getACR.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbACR = getACR.GetDataACR();

            ProcessGetRISStudyLibrary getBodtPart = new ProcessGetRISStudyLibrary();
            getBodtPart.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbBodyPart = getBodtPart.GetDataBodyPart();

            ProcessGetRISStudyLibrary getCPT = new ProcessGetRISStudyLibrary();
            getCPT.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbCPT = getCPT.GetDataCPT();

            ProcessGetRISStudyLibrary getICD = new ProcessGetRISStudyLibrary();
            getICD.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbICD = getICD.GetDataICD();

            ProcessGetRISStudyLibrary getShare = new ProcessGetRISStudyLibrary();
            getShare.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbShareWith = getShare.GetDataShareWith();

            ProcessGetRISStudyLibrary getTags = new ProcessGetRISStudyLibrary();
            getTags.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            tbTags = getTags.GetDataTags();

            LookUpSelect getTagsAll = new LookUpSelect();
            tbTagsAll = getTagsAll.SelectRadStudyManagementTags(new GBLEnvVariable().UserID).Tables[0];

            ProcessGetRISStudyLibrary conference = new ProcessGetRISStudyLibrary();
            conference.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            conference.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            tbConferenceAdd = conference.GetDataConference();
        }
        private void LoadRadStudyGroupFilter()
        {

        }
        private void LoadRadStudyGroupGrid()
        {

        }
        private void LoadRadStudyGroupControl()
        {
            DataRow row = tbStudyLib.Rows[0];

            #region Add Main Control
            txtStudy.Text = row["STUDY_TEXT"].ToString();

            //if (tbTagsAll != null && tbTagsAll.Rows.Count > 0)
            //{
            //    txtTagsList.Text = "";
            //    txtTagsList.Links.Clear();

            //    foreach (DataRow dr in tbTagsAll.Rows)
            //    {
            //        txtTagsList.Text += dr["TAGS"].ToString() + ", ";
            //    }

            //    foreach (DataRow dr in tbTagsAll.Rows)
            //    {
            //        int start = txtTagsList.Text.IndexOf(dr["TAGS"].ToString());
            //        int length = dr["TAGS"].ToString().Length;
            //        txtTagsList.Links.Add(start, length, dr["TAGS"].ToString());
            //    }
            //}
            LoadRadStudyGroupControlTag();
            #endregion

            if (row["HAS_DATA"].ToString() == "Y")
            {
                if(row["IS_FAVOURITE"].ToString() == "True")
                    chkAddTo.Items[0].CheckState = CheckState.Checked;
                if (row["IS_TEACHING"].ToString() == "True")
                    chkAddTo.Items[1].CheckState = CheckState.Checked;
                if (row["IS_RESEARCH"].ToString() == "True")
                    chkAddTo.Items[2].CheckState = CheckState.Checked;
                if (row["IS_OTHERS"].ToString() == "True")
                    chkAddTo.Items[3].CheckState = CheckState.Checked;

                txtTags.Text = row["TAGS"].ToString();

                switch (row["SHARE_TYPE"].ToString())
                {
                    case "P": rdoSharing.SelectedIndex = 0; break;
                    case "S": rdoSharing.SelectedIndex = 1; break;
                    case "G": rdoSharing.SelectedIndex = 2; break;
                }
                txtShareWith.Text = row["SUMMARY_SHARED_WITH"].ToString();

                if (row["DIFFICULTY_LEVEL"].ToString() == "B")
                    rdoDifficulty.SelectedIndex = 0;
                else if (row["DIFFICULTY_LEVEL"].ToString() == "I")
                    rdoDifficulty.SelectedIndex = 1;
                else if (row["DIFFICULTY_LEVEL"].ToString() == "A")
                    rdoDifficulty.SelectedIndex = 2;

                txtBodyPart.Text = row["SUMMARY_BODYPART"].ToString();
                txtACR.Text = row["SUMMARY_ACR"].ToString();
                txtICD.Text = row["SUMMARY_ICD"].ToString();
                txtCPT.Text = row["SUMMARY_CPT"].ToString();

                createConferenceText();
            }
        }
        private void LoadRadStudyGroupControlTag()
        {
            DataTable tbTagTemp;
            //TagKeyword = txtTags.Text;
            //TagKeyword = TagKeyword.Replace(",","");
            //int lastIdx = TagKeyword.LastIndexOf(" ");
            //if (lastIdx > 0)
            //    TagKeyword = TagKeyword.Substring(lastIdx);
            //else
            //    TagKeyword = string.Empty;

            if (!string.IsNullOrEmpty(TagKeyword))
            {
                tbTagTemp = tbTagsAll.Copy();
                DataView dv = new DataView(tbTagTemp);
                dv.RowFilter = "TAGS like '" + TagKeyword.Trim() + "%'";
                tbTagTemp = dv.ToTable();
            }
            else
                tbTagTemp = tbTagsAll.Copy();


            //DataRow row = tbStudyLib.Rows[0];
            if (tbTagsAll != null && tbTagsAll.Rows.Count > 0)
            {
                txtTagsList.Text = "";
                txtTagsList.Links.Clear();

                foreach (DataRow dr in tbTagTemp.Rows)
                {
                    txtTagsList.Text += dr["TAGS"].ToString() + ", ";
                }

                foreach (DataRow dr in tbTagTemp.Rows)
                {
                    int start = txtTagsList.Text.IndexOf(dr["TAGS"].ToString() + ",");
                    int length = dr["TAGS"].ToString().Length;
                    txtTagsList.Links.Add(start, length, dr["TAGS"].ToString());
                }
            }
        }
        private void ReloadRadStudyGroup()
        {
            LoadRadStudyGroupData();
            LoadRadStudyGroupFilter();
            LoadRadStudyGroupGrid();
            LoadRadStudyGroupControl();
        }

        //private void txtTags_TextChanged(object sender, EventArgs e)
        //{
        //    LoadRadStudyGroupControlTag();
        //}
        private void txtTags_KeyDown(object sender, KeyEventArgs e)
        {
            bool isLetterOrDigit = char.IsLetterOrDigit((char)e.KeyCode);
            if (isLetterOrDigit)
                TagKeyword += ((char)e.KeyCode);
            else
                TagKeyword = string.Empty;

            LoadRadStudyGroupControlTag();
        }
        private void txtTagsList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtTags.Text.Trim().Length == 0)
            {
                txtTags.Text += e.Link.LinkData.ToString();
            }
            else
            {
                txtTags.Text += ", "+e.Link.LinkData.ToString();
                
            }
        }
        private void btnShareWith_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupAddEditLookup lookup 
                = new frmStudyLibraryPopupAddEditLookup();

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectRadStudyManagementShareWith().Tables[0];
            lookup.ColumnFirst = "EMP_ID";
            lookup.ColumnSecond = "EMP_UID";
            lookup.ColumnThird = "EMP_NAME";
            lookup.ColumnFourth = "JOBTITLE_NAME";
            lookup.FormHeaderName = "Radiologist";

            lookup.retValue = tbShareWith;
            lookup.ValueUpdated += new ValueDataTableEventHandler(btnShareWith_Click_ValueUpdated);
            lookup.ShowDialog();
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
        private void btnConference_Click(object sender, EventArgs e)
        {
            frmStudyLibraryPopupConferenceManagement frm = new frmStudyLibraryPopupConferenceManagement(ACCESSION_NO);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            tbConferenceAdd = frm.dataAdd;
            tbConferenceDelete = frm.dataDelete;
            createConferenceText();
            
        }
        private void createConferenceText()
        {
            txtConference.Text = "";
            foreach (DataRow dr in tbConferenceAdd.Rows)
            {
                txtConference.Text += dr["CONFERENCE_TEXT"].ToString() + ", ";
            }
            string strCut = txtConference.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtConference.Text = strCut;
        }

        private void btnShareWith_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbShareWith = e.NewValue;
            txtShareWith.Text = "";

            foreach (DataRow dr in tbShareWith.Rows)
            {
                txtShareWith.Text += dr["EMP_NAME"].ToString() + ", ";
            }

            string strCut = txtShareWith.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtShareWith.Text = strCut;
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
        }
        private void btnACR_Click_ValueUpdated(object sender, ValueDataTableEventArgs e)
        {
            tbACR = e.NewValue;
            txtACR.Text = "";

            foreach (DataRow dr in tbACR.Rows)
            {
                txtACR.Text += dr["ACR_DESC"].ToString() + ", ";
            }

            string strCut = txtACR.Text;
            if (strCut.Length > 0)
                strCut = strCut.Substring(0, strCut.Length - 2);
            txtACR.Text = strCut;
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
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkAddTo.CheckedItems.Count <= 0)
            {
                msg.ShowAlert("UID4047", env.CurrentLanguageID);
            }
            else {
                SaveStudyLibrary();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void chkAddTo_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (chkAddTo.Items[1].CheckState == CheckState.Checked || chkAddTo.Items[3].CheckState == CheckState.Checked)
                EnableDisableShareWithControl(true);
            else
                EnableDisableShareWithControl(false);
        }

        private void EnableDisableShareWithControl(bool IsEnable)
        {
            switch (rdoSharing.SelectedIndex)
            {
                case 1:
                    btnShareWith.Enabled = true;
                    txtShareWith.Enabled = true;
                    break;
                default:
                    btnShareWith.Enabled = false;
                    txtShareWith.Enabled = false;
                    break;
            }

            rdoSharing.Enabled = IsEnable;
            btnShareWith.Enabled = IsEnable;
            txtShareWith.Enabled = IsEnable;
        }
        private void rdoSharing_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoSharing.SelectedIndex)
            {
                case 1: 
                    btnShareWith.Enabled = true;
                    txtShareWith.Enabled = true; 
                    break;
                default:
                    btnShareWith.Enabled = false;
                    txtShareWith.Enabled = false;
                    break;
            }
        }

        private void SaveStudyLibrary()
        {
            
            GBLEnvVariable env = new GBLEnvVariable();

            ProcessAddRISStudyLibrary addStudy = new ProcessAddRISStudyLibrary();
            addStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            addStudy.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            addStudy.RIS_STUDYLIBRARY.IS_FAVOURITE 
                = chkAddTo.Items[0].CheckState == CheckState.Checked ? true : false;
            addStudy.RIS_STUDYLIBRARY.IS_TEACHING 
                = chkAddTo.Items[1].CheckState == CheckState.Checked ? true : false;
            addStudy.RIS_STUDYLIBRARY.IS_RESEARCH
                = chkAddTo.Items[2].CheckState == CheckState.Checked ? true : false;
            addStudy.RIS_STUDYLIBRARY.IS_OTHERS
                = chkAddTo.Items[3].CheckState == CheckState.Checked ? true : false;
            addStudy.RIS_STUDYLIBRARY.TAGS = txtTags.Text.Trim();
            addStudy.RIS_STUDYLIBRARY.DIFFICULTY_LEVEL = rdoDifficulty.EditValue.ToString();
            addStudy.RIS_STUDYLIBRARY.SUMMARY_ACR = txtACR.Text;
            addStudy.RIS_STUDYLIBRARY.SUMMARY_BODYPART = txtBodyPart.Text;
            addStudy.RIS_STUDYLIBRARY.SUMMARY_CPT = txtCPT.Text;
            addStudy.RIS_STUDYLIBRARY.SUMMARY_ICD = txtICD.Text;
            addStudy.RIS_STUDYLIBRARY.SUMMARY_SHARED_WITH = txtShareWith.Text;
            switch (rdoSharing.SelectedIndex)
            {
                case 0: addStudy.RIS_STUDYLIBRARY.SHARE_TYPE = 'P'; break;
                case 1: addStudy.RIS_STUDYLIBRARY.SHARE_TYPE = 'S'; break;
                case 2: addStudy.RIS_STUDYLIBRARY.SHARE_TYPE = 'G'; break;
            }
            addStudy.Invoke();

            ProcessDeleteRISStudyLibrarydtlDelete delStudydetl = new ProcessDeleteRISStudyLibrarydtlDelete();
            delStudydetl.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
            delStudydetl.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
            delStudydetl.Invoke();

            if(txtTags.Text.Trim().Length > 0)
            {
                string[] splitTags = txtTags.Text.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string tag in splitTags)
                {
                    ProcessAddRISStudyLibraryTags addTags = new ProcessAddRISStudyLibraryTags();
                    addTags.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addTags.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addTags.RIS_STUDYLIBRARY.TAGS = tag;
                    addTags.Invoke();
                }
            }

            if (tbShareWith != null && tbShareWith.Rows.Count > 0)
            {
                foreach (DataRow dr in tbShareWith.Rows)
                {
                    ProcessAddRISStudyLibraryShareWith addShare = new ProcessAddRISStudyLibraryShareWith();
                    addShare.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addShare.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addShare.RIS_STUDYLIBRARY.EMP_ID = Convert.ToInt32(dr["EMP_ID"]);
                    addShare.Invoke();
                }
            }

            if (tbBodyPart != null && tbBodyPart.Rows.Count > 0)
            {
                foreach (DataRow dr in tbBodyPart.Rows)
                {
                    ProcessAddRISStudyLibraryBodyPart addBody = new ProcessAddRISStudyLibraryBodyPart();
                    addBody.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addBody.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addBody.RIS_STUDYLIBRARY.EXAM_SKILL_ID = Convert.ToInt32(dr["EXAM_SKILL_ID"]);
                    addBody.Invoke();
                }
            }

            if (tbCPT != null && tbCPT.Rows.Count > 0)
            {
                foreach (DataRow dr in tbCPT.Rows)
                {
                    ProcessAddRISStudyLibraryCPT addCPT = new ProcessAddRISStudyLibraryCPT();
                    addCPT.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addCPT.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addCPT.RIS_STUDYLIBRARY.CPT_ID = Convert.ToInt32(dr["CPT_ID"]);
                    addCPT.Invoke();
                }
            }

            if (tbICD != null && tbICD.Rows.Count > 0)
            {
                foreach (DataRow dr in tbICD.Rows)
                {
                    ProcessAddRISStudyLibraryICD addICD = new ProcessAddRISStudyLibraryICD();
                    addICD.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addICD.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addICD.RIS_STUDYLIBRARY.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                    addICD.Invoke();
                }
            }

            if (tbACR != null && tbACR.Rows.Count > 0)
            {
                foreach (DataRow dr in tbACR.Rows)
                {
                    ProcessAddRISStudyLibraryACR addACR = new ProcessAddRISStudyLibraryACR();
                    addACR.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                    addACR.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addACR.RIS_STUDYLIBRARY.ACR_ID = Convert.ToInt32(dr["ACR_ID"]);
                    addACR.Invoke();
                }
            }
            if (tbConferenceAdd != null && tbConferenceAdd.Rows.Count > 0)
            {
                foreach (DataRow dr in tbConferenceAdd.Rows)
                {
                    if (string.IsNullOrEmpty(dr["LIBRARY_CONFERENCE_ID"].ToString()))
                    {
                        ProcessAddRISStudyLibraryConference addConference = new ProcessAddRISStudyLibraryConference();
                        addConference.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                        addConference.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                        addConference.RIS_STUDYLIBRARY.CONFERENCE_ID = Convert.ToInt32(dr["CONFERENCE_ID"]);
                        addConference.RIS_STUDYLIBRARY.CONFERENCE_DATE = Convert.ToDateTime(dr["CONFERENCE_DATE"]);
                        addConference.Invoke();
                    }
                }
            }
            if (tbConferenceDelete != null && tbConferenceDelete.Rows.Count > 0)
            {
                foreach (DataRow dr in tbConferenceDelete.Rows)
                {
                    ProcessDeleteRISStudyLibraryConference delConference = new ProcessDeleteRISStudyLibraryConference();
                    delConference.RIS_STUDYLIBRARY.LIBRARY_CONFERENCE_ID = Convert.ToInt32(dr["LIBRARY_CONFERENCE_ID"]);
                    delConference.Invoke();
                }
            }

            if (chkAddTo.Items[3].CheckState == CheckState.Unchecked)
            {
                ProcessGetRISStudyLibrary conference = new ProcessGetRISStudyLibrary();
                conference.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                conference.RIS_STUDYLIBRARY.RADIOLOGIST_ID = env.UserID;
                DataTable dtDel = conference.GetDataConference();

                foreach (DataRow dr in dtDel.Rows)
                {
                    ProcessDeleteRISStudyLibraryConference delConference = new ProcessDeleteRISStudyLibraryConference();
                    delConference.RIS_STUDYLIBRARY.LIBRARY_CONFERENCE_ID = Convert.ToInt32(dr["LIBRARY_CONFERENCE_ID"]);
                    delConference.Invoke();
                }
            }

            if (chkAddTo.Items[1].CheckState == CheckState.Checked
                && rdoSharing.SelectedIndex == 1)
            {
                SaveStudyLibraryToShareWith();
            }
        }
        private void SaveStudyLibraryToShareWith()
        {
            if (tbShareWith != null & tbShareWith.Rows.Count > 0)
            {
                foreach (DataRow dr in tbShareWith.Rows)
                {
                    int EMP_ID = Convert.ToInt32(dr["EMP_ID"]);
                    if (EMP_ID == 0) continue;

                    ProcessAddRISStudyLibrary addStudy = new ProcessAddRISStudyLibrary();
                    addStudy.RIS_STUDYLIBRARY.RADIOLOGIST_ID = EMP_ID;
                    addStudy.RIS_STUDYLIBRARY.ACCESSION_NO = ACCESSION_NO;
                    addStudy.RIS_STUDYLIBRARY.IS_FAVOURITE = false;
                    addStudy.RIS_STUDYLIBRARY.IS_TEACHING = true;
                    addStudy.RIS_STUDYLIBRARY.IS_RESEARCH = false;
                    addStudy.RIS_STUDYLIBRARY.TAGS = "";
                    addStudy.RIS_STUDYLIBRARY.DIFFICULTY_LEVEL = rdoDifficulty.EditValue.ToString();
                    addStudy.RIS_STUDYLIBRARY.SUMMARY_ACR = "";
                    addStudy.RIS_STUDYLIBRARY.SUMMARY_BODYPART = "";
                    addStudy.RIS_STUDYLIBRARY.SUMMARY_CPT = "";
                    addStudy.RIS_STUDYLIBRARY.SUMMARY_ICD = "";
                    addStudy.RIS_STUDYLIBRARY.SUMMARY_SHARED_WITH = "";
                    addStudy.RIS_STUDYLIBRARY.SHARE_TYPE = 'S';
                    addStudy.Invoke();
                }
            }
        }

        
    }
}
