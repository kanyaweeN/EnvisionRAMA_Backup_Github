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
    public partial class frmPopupRadstudyGroupNew : DevExpress.XtraBars.Ribbon.RibbonForm//  Form
    {
        int RADIOLOGIST_ID { get; set; }
        string ACCESSION_NO { get; set; }
        bool IS_FAVOURITE { get; set; }
        bool IS_TEACHING { get; set; }
        bool IS_RESEARCH { get; set; }
        
        public string EXAM_NAME { get; set; }

        public frmPopupRadstudyGroupNew()
        {
            InitializeComponent();
        }
        public frmPopupRadstudyGroupNew
            (
                int RADIOLOGIST_ID
                , string ACCESSION_NO
                , bool IS_FAVOURITE
                , bool IS_TEACHING
                , bool IS_RESEARCH
                , string EXAM_NAME
            )
        {
            InitializeComponent();
            this.RADIOLOGIST_ID = RADIOLOGIST_ID;
            this.ACCESSION_NO = ACCESSION_NO;
            this.IS_FAVOURITE = IS_FAVOURITE;
            this.IS_TEACHING = IS_TEACHING;
            this.IS_RESEARCH = IS_RESEARCH;
            this.EXAM_NAME = EXAM_NAME;
        }
        private void frmPopupRadstudyGroup_Load(object sender, EventArgs e)
        {
            txtStudy.Text = EXAM_NAME;
            if (IS_FAVOURITE)
            {
                rdoAddTo.SelectedIndex = 0;
                this.Text = "Add Study to Favorites";
            }
            else if (IS_TEACHING)
            {
                rdoAddTo.SelectedIndex = 1;
                this.Text = "Add Study to Teaching Files";
            }
            else if (IS_RESEARCH)
            {
                rdoAddTo.SelectedIndex = 2;
                this.Text = "Add Study to Research";
            }

            rdoSharing.SelectedIndex = -1;
            ReloadRadStudyGroup();
        }

        private void LoadRadStudyGroupData()
        {
            ProcessGetRISRadstudygroup getStudy = new ProcessGetRISRadstudygroup();
        }
        private void LoadRadStudyGroupFilter()
        {

        }
        private void LoadRadStudyGroupGrid()
        {

        }
        private void LoadRadStudyGroupControl()
        {
            string tags = "HISTORY,  PULMONARY,  IMPRESSION,  CHANGE,  PLEURAL,  UNREMARKABLE,  MASS,  THERE,  EFFUSION,  CHEST,  STUDY,  EVIDENCE,  BREAST,  LESION,  NODULE,  NOTED,  PRIOR,  SMALL,  MILD,  UNCHANGED,  HEART,  TISSUE,  FILM,  COMPARISON,  COULD,  BILATERAL";
            txtTagsList.Text = tags;
            txtTagsList.Links.Clear();

            string[] strTags = txtTagsList.Text.Split(new string[] { "," }, StringSplitOptions.None);

            foreach (string tag in strTags)
            {
                int start = txtTagsList.Text.IndexOf(tag);
                int length = tag.Length;
                txtTagsList.Links.Add(start, length, tag);
            }
        }
        private void ReloadRadStudyGroup()
        {
            LoadRadStudyGroupData();
            LoadRadStudyGroupFilter();
            LoadRadStudyGroupGrid();
            LoadRadStudyGroupControl();
        }

        private void AddRadStudyGroup()
        { 
            
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
            DataTable dtResult = new DataTable();
            frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup(ref dtResult);

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectACR_CPT_ICD().Tables[4];
            lookup.ColumnFirst = "EMP_ID";
            lookup.ColumnSecond = "EMP_UID";
            lookup.ColumnThird = "EMP_NAME";
            lookup.ColumnFourth = "JOBTITLE_NAME";
            lookup.FormHeaderName = "Radiologist";

            if (lookup.ShowDialog() == DialogResult.OK)
            {
                txtSharedTo.Text = "";
            }
        }
        private void btnBodyPart_Click(object sender, EventArgs e)
        {
            //DataTable dtResult = new DataTable();
            //frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup(ref dtResult);

            //LookUpSelect lks = new LookUpSelect();
            //lookup.DataSource = lks.SelectACR_CPT_ICD().Tables[0];
            //lookup.ColumnFirst = "CPT_ID";
            //lookup.ColumnSecond = "CPT_UID";
            //lookup.ColumnThird = "CPT_DESC";
            //lookup.FormHeaderName = "CPT";

            //if (lookup.ShowDialog() == DialogResult.OK)
            //{

            //}
        }
        private void btnACR_Click(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable();
            frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup(ref dtResult);

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectACR_CPT_ICD().Tables[0];
            lookup.ColumnFirst = "ACR_ID";
            lookup.ColumnSecond = "ACR_UID";
            lookup.ColumnThird = "ACR_DESC";
            lookup.FormHeaderName = "ACR";

            if (lookup.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void btnCPT_Click(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable();
            frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup(ref dtResult);
            
            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectACR_CPT_ICD().Tables[1];
            lookup.ColumnFirst = "CPT_ID";
            lookup.ColumnSecond = "CPT_UID";
            lookup.ColumnThird = "CPT_DESC";
            lookup.FormHeaderName = "CPT";

            if (lookup.ShowDialog() == DialogResult.OK)
            {

            }
        }
        private void btnICD_Click(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable();
            frmPopupRadstudyGroupLookup lookup = new frmPopupRadstudyGroupLookup(ref dtResult);

            LookUpSelect lks = new LookUpSelect();
            lookup.DataSource = lks.SelectACR_CPT_ICD().Tables[2];
            lookup.ColumnFirst = "ICD_ID";
            lookup.ColumnSecond = "ICD_UID";
            lookup.ColumnThird = "ICD_DESC";
            lookup.FormHeaderName = "ICD";

            if (lookup.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void SaveData()
        {

        }
    }
}
