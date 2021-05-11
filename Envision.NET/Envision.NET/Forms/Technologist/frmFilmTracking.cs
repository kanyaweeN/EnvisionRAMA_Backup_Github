using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;

using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Technologist
{
    public partial class frmFilmTracking : MasterForm
    {
        DataTable RADIOLOGIST;

        DataRow SELECTED_HN;

        DataTable ISSUE;

        DateTime ISSUED_ON;

        DataTable RETURN;

        DataView view_ISSUE;
        DataView view_RETURN;

        public frmFilmTracking()
        {
            InitializeComponent();
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            //tabControl = clsCtl;
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
        }

        private void frmFilmTracking_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            ISSUED_ON = DateTime.Now;

            #region select radiologist list
            ProcessGetHREmp getData = new ProcessGetHREmp();
            getData.HR_EMP.MODE = "select_all_radiologist";
            getData.Invoke();
            RADIOLOGIST = getData.Result.Tables[0];

            txtIssuedTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            txtIssuedTo.Properties.DataSource = RADIOLOGIST;
            txtIssuedTo.Properties.DisplayMember = "RadioName";
            txtIssuedTo.Properties.ValueMember = "EMP_ID";
            txtIssuedTo.Properties.View.OptionsView.ShowAutoFilterRow = true;
            txtIssuedTo.Properties.View.OptionsView.ShowGroupPanel = false;

            int k = 0;
            while(k<txtIssuedTo.Properties.View.Columns.Count)
            {
                txtIssuedTo.Properties.View.Columns[k].OptionsColumn.AllowEdit = false;
                txtIssuedTo.Properties.View.Columns[k].Visible =false;
                ++k;
            }

            txtIssuedTo.Properties.View.Columns["EMP_UID"].VisibleIndex = 0;
            txtIssuedTo.Properties.View.Columns["EMP_UID"].Caption = "Rad. Code";

            txtIssuedTo.Properties.View.Columns["EMP_NAME"].VisibleIndex = 1;
            txtIssuedTo.Properties.View.Columns["EMP_NAME"].Caption = "Rad. Name";

            txtIssuedTo.Properties.View.BestFitColumns();

            #endregion

            GBLEnvVariable gbl = new GBLEnvVariable();
            txtIssuedBy.Text = gbl.UserUID+ " " +gbl.UserName;

            txtIssuedTo.EditValue = null;

            txtHN.Focus();

            //ReloadIssue();
            #region initail data
            ProcessGetRISFilmtracker initData = new ProcessGetRISFilmtracker(0);
            initData.RISFilmtracker.HN = "#EMPTY#";
            initData.Invoke();
            DataTable table = initData.Result.Tables[0];
            table.Columns.Add("colChecked");
            ISSUE = table;
            view_ISSUE = new DataView(table);
            LoadIssueFilter();
            LoadIssueGrid();
            #endregion
        }

        private void LoadIssueData()
        {
            string hn = SELECTED_HN["HN"].ToString();

            ProcessGetRISFilmtracker getData = new ProcessGetRISFilmtracker(0);
            getData.RISFilmtracker.HN = hn;
            getData.Invoke();
            DataTable table = getData.Result.Tables[0];
            table.Columns.Add("colChecked");

            foreach (DataRow dr in table.Rows)
            {
                dr["colChecked"] = "N";
            }

            ISSUE = table;
            view_ISSUE = new DataView(table);

            string name = SELECTED_HN["FNAME"].ToString() + " " + SELECTED_HN["LNAME"].ToString();
            txtPatientName.Text = name;
        }
        private void LoadIssueFilter()
        {

        }
        private void LoadIssueGrid()
        {
            gridControl1.DataSource = ISSUE;
            //gridControl1.DataSource = view_ISSUE;

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                gridView1.Columns[k].Visible = false;
                ++k;
            }

            gridView1.Columns["colChecked"].ColVIndex = 1;
            gridView1.Columns["colChecked"].Caption = "";
            gridView1.Columns["colChecked"].OptionsColumn.ShowCaption = false;
            gridView1.Columns["colChecked"].OptionsColumn.AllowEdit = true;
            gridView1.Columns["colChecked"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["colChecked"].Width = 50;

            gridView1.Columns["ORDER_DT"].ColVIndex = 2;
            gridView1.Columns["ORDER_DT"].Caption = "Study Date";
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";

            gridView1.Columns["PRIORITY"].ColVIndex = 3;
            gridView1.Columns["PRIORITY"].Caption = "Priority";

            gridView1.Columns["ACCESSION_NO"].ColVIndex = 4;
            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";

            gridView1.Columns["STATUS"].ColVIndex = 5;
            gridView1.Columns["STATUS"].Caption = "Status";

            gridView1.Columns["EXAM_UID"].ColVIndex = 6;
            gridView1.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView1.Columns["EXAM_NAME"].ColVIndex = 7;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";

            gridView1.Columns["REF_DOC"].ColVIndex = 8;
            gridView1.Columns["REF_DOC"].Caption = "Ordering Phycician";

            #region Edit Columns Items

            RepositoryItemCheckEdit item_chk = new RepositoryItemCheckEdit();
            item_chk.ValueChecked = "Y";
            item_chk.ValueGrayed = "N";
            item_chk.ValueUnchecked = "N";
            item_chk.AllowGrayed = false;
            gridView1.Columns["colChecked"].ColumnEdit = item_chk;

            RepositoryItemImageComboBox item_image_combobox = new RepositoryItemImageComboBox();
            item_image_combobox.SmallImages = this.imgWL;
            item_image_combobox.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", "R", 0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent", "U", 1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", "S", 2)});
            gridView1.Columns["PRIORITY"].ColumnEdit = item_image_combobox;

            #endregion

            #region Style Condition

            //Alive
            StyleFormatCondition styl_condition_1
                = new StyleFormatCondition
                    (FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "New");
            styl_condition_1.Appearance.ForeColor = Color.Red;

            //Complete
            StyleFormatCondition styl_condition_2
                = new StyleFormatCondition
                    (FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "Complete");
            styl_condition_2.Appearance.ForeColor = Color.Red;

            //Prelim
            StyleFormatCondition styl_condition_3
                = new StyleFormatCondition
                    (FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "Prelim");
            styl_condition_3.Appearance.ForeColor = Color.Goldenrod;

            //Draft
            StyleFormatCondition styl_condition_4
                = new StyleFormatCondition
                    (FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "Draft");
            styl_condition_4.Appearance.ForeColor = Color.Goldenrod;

            //Finalize
            StyleFormatCondition styl_condition_5
                = new StyleFormatCondition
                    (FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "Finalized");
            styl_condition_5.Appearance.ForeColor = Color.Green;

            gridView1.FormatConditions.Clear();
            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] 
                { styl_condition_1
                    , styl_condition_2
                    , styl_condition_3
                    , styl_condition_4
                    , styl_condition_5 });

            #endregion

            gridView1.BestFitColumns();
        }
        private void ReloadIssue()
        {
            string hn = txtHN.Text;
            ProcessGetHISRegistration geHis = new ProcessGetHISRegistration(hn);
            geHis.Invoke();
            if (geHis.Result.Tables[0] != null
                && geHis.Result.Tables[0].Rows.Count > 0)
            {
                SELECTED_HN = geHis.Result.Tables[0].Rows[0];

                LoadIssueData();
                LoadIssueFilter();
                LoadIssueGrid();
            }
            else
            {
                //MessageBox.Show("Your HN not see in our database.");
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID4024", new GBLEnvVariable().CurrentLanguageID);
                txtHN.Text = "";
                txtPatientName.Text = "";
                txtHN.Focus();

                if (ISSUE != null)
                {
                    ISSUE = ISSUE.Clone();
                    LoadIssueFilter();
                    LoadIssueGrid();
                }
                return;
            }
        }

        #region ISSUE PAGE
        private void btnOKIssue_Click(object sender, EventArgs e)
        {
            int row_count = gridView1.RowCount;
            if (row_count == 0) return;

            int focus_index = txtIssuedTo.Properties.View.FocusedRowHandle;
            if(focus_index<0)return;

            DataTable chk_table = (DataTable)gridControl1.DataSource;
            DataRow[] chk_rows = chk_table.Select("colChecked='Y'");
            if (chk_rows.Length > 0)
            {
                MyMessageBox msg = new MyMessageBox();
                string result = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
                if (result == "1") return;

                foreach (DataRow dr in chk_rows)
                {
                    try
                    {
                        ProcessAddRISFilmtracker addData = new ProcessAddRISFilmtracker();
                        addData.RISFilmtracker.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        addData.RISFilmtracker.ISSUE_TYPE = "";
                        addData.RISFilmtracker.ISSUED_BY = new GBLEnvVariable().UserID;
                        object emp_id = txtIssuedTo.EditValue;
                        if (emp_id == null)
                            addData.RISFilmtracker.ISSUED_TO = null;
                        else
                            addData.RISFilmtracker.ISSUED_TO = Convert.ToInt32(emp_id);
                        addData.RISFilmtracker.ISSUED_ON = ISSUED_ON;
                        addData.RISFilmtracker.ORG_ID = new GBLEnvVariable().OrgID;
                        addData.RISFilmtracker.CREATED_BY = new GBLEnvVariable().UserID;
                        addData.Invoke();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                ISSUED_ON = DateTime.Now;
                ReloadIssue();
            }
            else
            {
                //MessageBox.Show("Please select at least one row.");        
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
                gridView1.Focus();
                return;
            }
        }
        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReloadIssue();
            }
        }
        private void btnSearchHN_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnSearchHN_Clicks);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("FNAME", "First name", true, true);
            lv.AddColumn("LNAME", "Last Name", true, true);
            lv.Text = "HN Search";

            lv.Data = lvS.SelectOrderFrom("HN").Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnSearchHN_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            string hn = retValue[0].ToString();
            if (hn.Trim().Length > 0)
            {
                txtHN.Text = hn;
                ReloadIssue();
            }
        }

        private void btnDeleteIssuedTo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtIssuedTo.EditValue = null;
        }
        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            AdvBandedGridView advGrid = (AdvBandedGridView)sender;
            GridColumn column = advGrid.FocusedColumn;

            if (column.FieldName == "colChecked")
            {
                string value = column.FilterInfo.Value == null ? "" : column.FilterInfo.Value.ToString();
                DataTable table = ISSUE;

                if (value == "N")
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["colChecked"] = "N";
                    }
                }
                else if (value == "Y")
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["colChecked"] = "Y";
                    }
                }

                table.AcceptChanges();
                column.FilterInfo = new ColumnFilterInfo(ColumnFilterType.None, "");
                advGrid.OptionsCustomization.AllowFilter = false;
            }
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int row_select = gridView1.FocusedRowHandle;
            if (row_select < 0) return;

            DataRow row = gridView1.GetDataRow(row_select);
            DataTable table = ISSUE;
            int index = table.Rows.IndexOf(row);

            string value = table.Rows[index]["colChecked"].ToString();
            if (value == "Y")
            {
                table.Rows[index]["colChecked"] = "N";
            }
            else if (value == "N")
            {
                table.Rows[index]["colChecked"] = "Y";
            }

            table.AcceptChanges();    
        }
        #endregion

        private void LoadReturnData()
        {
            ProcessGetRISFilmtracker getData = new ProcessGetRISFilmtracker(1);
            getData.Invoke();
            DataTable table = getData.Result.Tables[0];
            table.Columns.Add("colChecked");
            foreach(DataRow dr in table.Rows)
            {
                dr["colChecked"] = "N";
            }

            RETURN = table.Copy();
            view_RETURN = new DataView(table);
        }
        private void LoadReturnFilter()
        {

        }
        private void LoadReturnGrid()
        {
            gridControl2.DataSource = RETURN;
            //gridControl2.DataSource = view_RETURN;

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                gridView2.Columns[k].Visible = false;
                ++k;
            }

            gridView2.Columns["colChecked"].ColVIndex = 1;
            gridView2.Columns["colChecked"].Caption = "";
            gridView2.Columns["colChecked"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["colChecked"].OptionsColumn.ShowCaption = false;
            gridView2.Columns["colChecked"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["colChecked"].Width = 50;

            gridView2.Columns["HN"].ColVIndex = 2;
            gridView2.Columns["HN"].Caption = "HN";

            gridView2.Columns["PATIENT_NAME"].ColVIndex = 3;
            gridView2.Columns["PATIENT_NAME"].Caption = "Patient Name";

            gridView2.Columns["ACCESSION_NO"].ColVIndex = 4;
            gridView2.Columns["ACCESSION_NO"].Caption = "Accession No.";

            gridView2.Columns["EXAM_UID"].ColVIndex = 5;
            gridView2.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView2.Columns["EXAM_NAME"].ColVIndex = 6;
            gridView2.Columns["EXAM_NAME"].Caption = "Exam Name";

            gridView2.Columns["ISSUED_TO_NAME"].ColVIndex = 7;
            gridView2.Columns["ISSUED_TO_NAME"].Caption = "Issued To";

            gridView2.Columns["ISSUED_ON"].ColVIndex = 8;
            gridView2.Columns["ISSUED_ON"].Caption = "Issued On";
            gridView2.Columns["ISSUED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["ISSUED_ON"].DisplayFormat.FormatString = "G";

            RepositoryItemCheckEdit item_chk = new RepositoryItemCheckEdit();
            item_chk.ValueChecked = "Y";
            item_chk.ValueGrayed = "N";
            item_chk.ValueUnchecked = "N";
            item_chk.AllowGrayed = false;
            gridView2.Columns["colChecked"].ColumnEdit = item_chk;

            gridView2.BestFitColumns();
        }
        private void ReloadReturn()
        {
            LoadReturnData();
            LoadReturnFilter();
            LoadReturnGrid();
        }

        #region RETURN PAGE
        private void btnOKReturn_Click(object sender, EventArgs e)
        {
            int row_count = gridView2.RowCount;
            if (row_count == 0) return;

            DataTable chk_table = (DataTable)gridControl2.DataSource;
            DataRow[] chk_rows = chk_table.Select("colChecked='Y'");
            if (chk_rows.Length > 0)
            {
                MyMessageBox msg = new MyMessageBox();
                string result = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
                if (result == "1") return;

                foreach (DataRow dr in chk_rows)
                {
                    ProcessUpdateRISFilmtracker updateData = new ProcessUpdateRISFilmtracker();
                    updateData.RISFilmtracker.TRACKING_ID = Convert.ToInt32(dr["TRACKING_ID"]);
                    updateData.RISFilmtracker.RETURNED_ON = ISSUED_ON;
                    updateData.RISFilmtracker.RETURNED_BY = new GBLEnvVariable().UserID;
                    updateData.RISFilmtracker.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    updateData.Invoke();
                }

                ISSUED_ON = DateTime.Now;
                ReloadReturn();
            }
            else
            {
                //MessageBox.Show("Please select at least one row.");
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID006", new GBLEnvVariable().CurrentLanguageID);
                gridView2.Focus();
                return;
            }
        }
        private void gridView2_ColumnFilterChanged(object sender, EventArgs e)
        {
            AdvBandedGridView advGrid = (AdvBandedGridView)sender;
            GridColumn column = advGrid.FocusedColumn;

            if (column.FieldName == "colChecked")
            {
                string value = column.FilterInfo.Value == null ? "" : column.FilterInfo.Value.ToString();
                DataTable table = RETURN;

                if (value == "N")
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["colChecked"] = "N";
                    }
                }
                else if (value == "Y")
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["colChecked"] = "Y";
                    }
                }

                table.AcceptChanges();
                column.FilterInfo = new ColumnFilterInfo(ColumnFilterType.None, "");
                advGrid.OptionsCustomization.AllowFilter = false;
            }
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            int row_select = gridView2.FocusedRowHandle;
            if (row_select < 0) return;

            DataRow row = gridView2.GetDataRow(row_select);
            DataTable table = RETURN;
            int index = table.Rows.IndexOf(row);
            if (index < 0) return;

            string value = table.Rows[index]["colChecked"].ToString();
            if (value == "Y")
            {
                table.Rows[index]["colChecked"] = "N";
            }
            else if (value == "N")
            {
                table.Rows[index]["colChecked"] = "Y";
            }

            table.AcceptChanges();
        }
        #endregion

        private void btnIssue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl1.SelectedTabPage = tabPageIssue;
        }
        private void btnReturn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraTabControl1.SelectedTabPage = tabPageReturn;
        }
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            PageRefresh();
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageRefresh();
        }
        private void PageRefresh()
        {
            if (xtraTabControl1.SelectedTabPage == tabPageIssue)
            {
                ReloadIssue();
            }
            else if (xtraTabControl1.SelectedTabPage == tabPageReturn)
            {
                ReloadReturn();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (xtraTabControl1.SelectedTabPage == tabPageIssue)
                table = ISSUE;
            else if (xtraTabControl1.SelectedTabPage == tabPageReturn)
                table = RETURN;

            foreach (DataRow dr in table.Rows)
                dr["colChecked"] = "Y";
        }
        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            if (xtraTabControl1.SelectedTabPage == tabPageIssue)
                table = ISSUE;
            else if (xtraTabControl1.SelectedTabPage == tabPageReturn)
                table = RETURN;

            foreach (DataRow dr in table.Rows)
                dr["colChecked"] = "N";
        }
        private void menuPopup_Opening(object sender, CancelEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == tabPageIssue)
                if (gridView1.RowCount == 0)
                    e.Cancel = true;
            else if (xtraTabControl1.SelectedTabPage == tabPageReturn)
                if (gridView2.RowCount == 0)
                    e.Cancel = true;
        }

    }
}
