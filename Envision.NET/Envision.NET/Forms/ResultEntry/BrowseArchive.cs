using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Envision.Common;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class BrowseArchive : DevExpress.XtraBars.Ribbon.RibbonForm//Form
    {
        
        string HN = "";
        int mode = 1;
        DataTable dtWL = new DataTable();
        DataTable dtLGCY = null;

        public BrowseArchive()
        {
            InitializeComponent();
            mode = 1; // Browse Archive Mode
            txtFromDT.DateTime = txtToDT.DateTime = DateTime.Now;
        }
        public BrowseArchive(string hn)
        {
            InitializeComponent();
            HN = hn.ToString();
            this.Text = "History : " + HN;
            txtHN.Text = HN;
            mode = 2; // History Browsing Mode
            txtFromDT.DateTime = txtToDT.DateTime = DateTime.Now;
            lgSearch.Expanded = false;
            lgSearch.GroupBordersVisible = false;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        private void BrowseArchive_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGrid();
        }

        private void LoadData()
        {
            if (rdoDateHN.SelectedIndex == 0)
            {
                Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
                proGet.RISExamresult.MODE = 1;
                proGet.RISExamresult.EMP_ID = new GBLEnvVariable().UserID;
                proGet.RISExamresult.FROM_DATE = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                proGet.RISExamresult.TO_DATE = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                dtWL = proGet.GetBrowseArchive().Copy();
            }
            else
            {
                Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
                proGet.RISExamresult.MODE = 2;
                proGet.RISExamresult.EMP_ID = new GBLEnvVariable().UserID;
                proGet.RISExamresult.FROM_DATE = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                proGet.RISExamresult.TO_DATE = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                proGet.RISExamresult.HN = txtHN.Text;
                dtWL = proGet.GetBrowseArchive().Copy();
            }
        }
        private void LoadGrid()
        {
            gridControl1.DataSource = dtWL.Copy();

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            #region setColumn

            //gridView1.Columns["Priority"].Width = 50;
            //gridView1.Columns["Priority"].VisibleIndex = 1;

            gridView1.Columns["Status"].Width = 50;
            gridView1.Columns["Status"].VisibleIndex = 1;

            gridView1.Columns["HN"].Width = 75;
            gridView1.Columns["HN"].VisibleIndex = 2;

            gridView1.Columns["Accession No"].Width = 100;
            gridView1.Columns["Accession No"].VisibleIndex = 3;

            gridView1.Columns["Exam Code"].Width = 50;
            gridView1.Columns["Exam Code"].VisibleIndex = 4;

            gridView1.Columns["Exam Name"].Width = 150;
            gridView1.Columns["Exam Name"].VisibleIndex = 5;

            gridView1.Columns["Patient Name"].Width = 150;
            gridView1.Columns["Patient Name"].VisibleIndex = 6;

            gridView1.Columns["Radiologist"].Width = 100;
            gridView1.Columns["Radiologist"].VisibleIndex = 7;

            gridView1.Columns["Result Time"].Width = 75;
            gridView1.Columns["Result Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Result Time"].DisplayFormat.FormatString = "g";
            gridView1.Columns["Result Time"].VisibleIndex = 8;

            gridView1.Columns["Released by"].Width = 100;
            gridView1.Columns["Released by"].VisibleIndex = 9;

            gridView1.Columns["Released Time"].Width = 100;
            gridView1.Columns["Released Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Released Time"].DisplayFormat.FormatString = "g";
            gridView1.Columns["Released Time"].VisibleIndex = 10;

            gridView1.Columns["Finalized by"].Width = 100;
            gridView1.Columns["Finalized by"].VisibleIndex = 11;

            gridView1.Columns["Finalized Time"].Width = 100;
            gridView1.Columns["Finalized Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Finalized Time"].DisplayFormat.FormatString = "g";
            gridView1.Columns["Finalized Time"].VisibleIndex = 12;

            #endregion

            #region setRepoItem

            //DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2
            //    = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            //repositoryItemImageComboBox2.AutoHeight = false;
            //repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            //new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            //new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 2, 7),
            //new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent ", 3, 8)});
            //repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            //repositoryItemImageComboBox2.SmallImages = this.imageList1;
            //repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            //gridView1.Columns["Priority"].ColumnEdit = repositoryItemImageComboBox2;

            #endregion column edit

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Status"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView1.FormatConditions.Clear();
            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

            #endregion

        }

        private void LoadDataLGCY()
        {
            if (rdoDateHN.SelectedIndex == 0)
            {
                Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
                proGet.RISExamresultlegacy.MODE = 1;
                proGet.RISExamresultlegacy.HN = "";
                proGet.RISExamresultlegacy.FROM_DATE = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                proGet.RISExamresultlegacy.TO_DATE = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                dtLGCY = proGet.GetBrowseArchiveLegacy().Copy();
            }
            else
            {
                Envision.BusinessLogic.ResultEntry proGet = new Envision.BusinessLogic.ResultEntry();
                proGet.RISExamresultlegacy.MODE = 2;
                proGet.RISExamresultlegacy.HN = txtHN.Text;
                proGet.RISExamresultlegacy.FROM_DATE = new DateTime(txtFromDT.DateTime.Year, txtFromDT.DateTime.Month, txtFromDT.DateTime.Day, 0, 0, 0);
                proGet.RISExamresultlegacy.TO_DATE = new DateTime(txtToDT.DateTime.Year, txtToDT.DateTime.Month, txtToDT.DateTime.Day, 23, 59, 59);
                dtLGCY = proGet.GetBrowseArchiveLegacy().Copy();
            }
        }
        private void LoadGridLGCY()
        {
            gridControl2.DataSource = dtLGCY.Copy();

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].Visible = false;
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            #region setColumn

            gridView2.Columns["Status"].Width = 75;
            gridView2.Columns["Status"].VisibleIndex = 1;

            gridView2.Columns["Accession No"].Width = 100;
            gridView2.Columns["Accession No"].VisibleIndex = 2;

            gridView2.Columns["HN"].Width = 75;
            gridView2.Columns["HN"].VisibleIndex = 3;

            //gridView2.Columns["Order Code"].Width = 75;
            //gridView2.Columns["Order Code"].VisibleIndex = 3;

            gridView2.Columns["Exam Code"].Width = 50;
            gridView2.Columns["Exam Code"].VisibleIndex = 4;

            gridView2.Columns["Exam Name"].Width = 150;
            gridView2.Columns["Exam Name"].VisibleIndex = 4;

            gridView2.Columns["Radiologist"].Width = 100;
            gridView2.Columns["Radiologist"].VisibleIndex = 5;

            gridView2.Columns["Result Time"].Width = 75;
            gridView2.Columns["Result Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["Result Time"].DisplayFormat.FormatString = "g";
            gridView2.Columns["Result Time"].VisibleIndex = 6;

            gridView2.Columns["Released by"].Width = 100;
            gridView2.Columns["Released by"].VisibleIndex = 7;

            gridView2.Columns["Released Time"].Width = 100;
            gridView2.Columns["Released Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["Released Time"].DisplayFormat.FormatString = "g";
            gridView2.Columns["Released Time"].VisibleIndex = 8;

            gridView2.Columns["Finalized by"].Width = 100;
            gridView2.Columns["Finalized by"].VisibleIndex = 9;

            gridView2.Columns["Finalized Time"].Width = 100;
            gridView2.Columns["Finalized Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["Finalized Time"].DisplayFormat.FormatString = "g";
            gridView2.Columns["Finalized Time"].VisibleIndex = 10;

            #endregion

            #region setStyleCon

            //Alive
            DevExpress.XtraGrid.StyleFormatCondition stylCon1
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Status"], null, "New");
            stylCon1.Appearance.ForeColor = Color.Red;

            //Complete
            DevExpress.XtraGrid.StyleFormatCondition stylCon2
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Status"], null, "Complete");
            stylCon2.Appearance.ForeColor = Color.Red;

            //Prelim
            DevExpress.XtraGrid.StyleFormatCondition stylCon3
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Status"], null, "Prelim");
            stylCon3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            DevExpress.XtraGrid.StyleFormatCondition stylCon4
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Status"], null, "Draft");
            stylCon4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            DevExpress.XtraGrid.StyleFormatCondition stylCon5
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Status"], null, "Finalized");
            stylCon5.Appearance.ForeColor = Color.Green;

            gridView2.FormatConditions.Clear();
            gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon1, stylCon2, stylCon3, stylCon4, stylCon5 });

            #endregion 
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                ResultText.Rtf = dr["RESULT_TEXT_RTF"].ToString();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                ResultText.Rtf = dr["RESULT_TEXT_RTF"].ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageArchive)
            {
                LoadData();
                LoadGrid();
            }
            else
            {
                LoadDataLGCY();
                LoadGridLGCY();
            }
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageLegacy)
            {
                if (dtLGCY == null)
                {
                    LoadDataLGCY();
                    LoadGridLGCY();
                }
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                ResultText.Text = Miracle.Translator.ConvertToText.HtmlToTextFormat(row["RESULT_TEXT_HTML"].ToString());
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                ResultText.Text = Miracle.Translator.ConvertToText.HtmlToTextFormat(row["RESULT_TEXT_HTML"].ToString());
            }
        }

        private void radioGroup1_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDateHN.SelectedIndex == 0)
            {
                pageDate.Visible = true;
                pageHN.Visible = false;
            }
            else
            {
                pageDate.Visible = false;
                pageHN.Visible = true;   
            }
        }

        private void txtHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (xtraTabControl1.SelectedTabPage == pageArchive)
                {
                    LoadData();
                    LoadGrid();
                }
                else
                {
                    LoadDataLGCY();
                    LoadGridLGCY();
                }
            }
        }

    }
}