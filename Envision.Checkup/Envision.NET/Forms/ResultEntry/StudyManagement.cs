using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.ResultEntry
{
    public partial class RadStudyManagement : Form
    {
        private UUL.ControlFrame.Controls.TabControl tabControl;
        private int[] focusRow = new int[] { 0, 0 };
        private bool InThePreProcess = false;

        public RadStudyManagement(UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InThePreProcess = true;

            InitializeComponent();

            tabControl = clsCtl;

            xtraTabControl1.SelectedTabPageIndex = 0;

            //LoadData_ExamResult();
            LoadData_Favorites();
            LoadData_Teaching();

            InThePreProcess = false;

            layoutControlGroup3.Expanded = false;
            layoutControlGroup6.Expanded = false;
        }

        #region Global
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            InThePreProcess = true;

            int index = xtraTabControl1.SelectedTabPageIndex;

            if (index > -1)
            {
                if (index == 0)
                {
                    LoadData_Favorites();
                }
                else if (index == 1)
                {
                    LoadData_Teaching();
                }
            }

            InThePreProcess = false;
        }
        
        private void dataNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Close")
            {
                int index = tabControl.SelectedIndex;
                tabControl.TabPages.RemoveAt(index);
            }
            else
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    switch (e.Button.Tag.ToString())
                    {
                        case "First"
                            : gridView1.MoveFirst(); break;
                        case "PrevPage"
                            : gridView1.MovePrevPage(); break;
                        case "Prev"
                            : gridView1.MovePrev(); break;
                        case "Next"
                            : gridView1.MoveNext(); break;
                        case "NextPage"
                            : gridView1.MoveNextPage(); break;
                        case "Last"
                            : gridView1.MoveLast(); break;
                    }
                }
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    switch (e.Button.Tag.ToString())
                    {
                        case "First"
                            : gridView2.MoveFirst(); break;
                        case "PrevPage"
                            : gridView2.MovePrevPage(); break;
                        case "Prev"
                            : gridView2.MovePrev(); break;
                        case "Next"
                            : gridView2.MoveNext(); break;
                        case "NextPage"
                            : gridView2.MoveNextPage(); break;
                        case "Last"
                            : gridView2.MoveLast(); break;
                    }
                }
            }
        }
        
        private void BestFitColumns(DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridview)
        {
            gridview.Columns["Selected"].Width = 50;
            gridview.Columns["Exam Code"].Width = 50;
            gridview.Columns["Exam Name"].Width = 100;
            gridview.Columns["Study Date Time"].Width = 100;
            gridview.Columns["Last Saved By"].Width = 150;
            gridview.Columns["Accession No"].Width = 100;
            gridview.Columns["View Image"].Width = 100;
            gridview.Columns["Order Detail"].Width = 100;
            gridview.Columns["HN"].Width = 100;
            gridview.Columns["Patient Name"].Width = 150;
            gridview.Columns["Priority"].Width = 70;
            gridview.Columns["Status"].Width = 70;
            gridview.Columns["Added"].Width = 70;
            //gridview.Columns["RESULT_TEXT_PLAIN"].Width = 100;
        }
        
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int tabIndex = xtraTabControl1.SelectedTabPageIndex;
            if (tabIndex == 0)
            {
                int rowFocus = gridView1.FocusedRowHandle;
                if (rowFocus > -1 && rowFocus < gridView1.RowCount)
                {
                    //if (gridView1.FocusedColumn.FieldName == "Selected")
                    //    e.Cancel = false;
                    //else
                    //    e.Cancel = true;
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if (tabIndex == 1)
            {
                int rowFocus = gridView2.FocusedRowHandle;
                if (rowFocus > -1 && rowFocus < gridView2.RowCount)
                {
                    //if (gridView2.FocusedColumn.FieldName == "Selected")
                    //    e.Cancel = false;
                    //else
                    //    e.Cancel = true;
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tabIndex = xtraTabControl1.SelectedTabPageIndex;
            if (tabIndex == 0)
                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                    row["Selected"] = 'Y';
            else if (tabIndex == 1)
                foreach (DataRow row in ((DataTable)gridControl2.DataSource).Rows)
                    row["Selected"] = 'Y';
        }
        private void uncheckAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int tabIndex = xtraTabControl1.SelectedTabPageIndex;
            if (tabIndex == 0)
                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                    row["Selected"] = 'N';
            else if (tabIndex == 1)
                foreach (DataRow row in ((DataTable)gridControl2.DataSource).Rows)
                    row["Selected"] = 'N';
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData_Favorites();
            LoadData_Teaching();
        }
        #endregion Global

        #region Favorites
        private void LoadData_Favorites()
        {
            RIS.BusinessLogic.ProcessGetRISRadstudygroup getRISRadstudygroup
                = new RIS.BusinessLogic.ProcessGetRISRadstudygroup();
            getRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            getRISRadstudygroup.RISRadstudygroup.MODE = "Favorites";
            getRISRadstudygroup.Invoke();

            gridControl1.DataSource = getRISRadstudygroup.Result.Tables[0].Copy();

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                //gridView1.Columns[k].OptionsColumn.ReadOnly = true;
                ++k;
            }

            GetStyleFormatCondition_Favorites();
            GetPriorityEdit_Favorites();
            GetSeletedEdit_Favorites();
            GetViewImageEdit_Favorites();
            GetOrderDetailEdit_Favorites();

            gridView1.Columns["View Image"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["View Image"].Width = 50;

            gridView1.Columns["Order Detail"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["Order Detail"].Width = 50;

            gridView1.Columns["RESULT_TEXT_PLAIN"].Visible = false;
            gridView1.Columns["RESULT_TEXT_RTF"].Visible = false;
            gridView1.Columns["IS_FAVOURITE"].Visible = false;
            gridView1.Columns["IS_TEACHING"].Visible = false;
            gridView1.Columns["IS_OTHERS"].Visible = false;

            gridView1.Columns["Selected"].Width = 50;
            gridView1.Columns["Selected"].OptionsColumn.FixedWidth = true;
            gridView1.Columns["Selected"].OptionsColumn.AllowSize = false;
            gridView1.Columns["Selected"].OptionsColumn.AllowMove = false;

            gridView1.Columns["Study Date Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Study Date Time"].DisplayFormat.FormatString = "g";

            gridView1.Columns["Added"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["Added"].DisplayFormat.FormatString = "g";

            //gridView3.BestFitColumns();
            BestFitColumns(gridView1);
        }

        private void GetStyleFormatCondition_Favorites()
        {
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

            DevExpress.XtraGrid.StyleFormatCondition stylCon6
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Added"], null, "Not Added");
            stylCon6.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon7
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView1.Columns["Added"], null, "Was Added");
            stylCon7.Appearance.ForeColor = Color.Green;

            gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon6, stylCon7 });
        }
        private void GetPriorityEdit_Favorites()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2
                = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent ", 3, 8)});
            repositoryItemImageComboBox2.SmallImages = this.imageList1;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            gridView1.Columns["Priority"].ColumnEdit = repositoryItemImageComboBox2;
            //gridView1.Columns["Priority"].OptionsColumn.AllowEdit = false;
        }
        private void GetSeletedEdit_Favorites()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            repositoryItemCheckEdit1.NullText = "N";
            repositoryItemCheckEdit1.ValueChecked = "Y";
            repositoryItemCheckEdit1.ValueUnchecked = "N";

            gridView1.Columns["Selected"].ColumnEdit = repositoryItemCheckEdit1;
            gridView1.Columns["Selected"].OptionsColumn.AllowEdit = true;
        }

        private void GetViewImageEdit_Favorites()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.Clear();
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Pacs Image", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            repositoryItemButtonEdit1.ReadOnly = true;
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEdit1.Click += new EventHandler(btnViewImage_Favorites_Click);

            gridView1.Columns["View Image"].ColumnEdit = repositoryItemButtonEdit1;
            gridView1.Columns["View Image"].OptionsColumn.AllowEdit = true;
        }
        private void GetOrderDetailEdit_Favorites()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.Clear();
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Order DTL", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            repositoryItemButtonEdit1.ReadOnly = true;
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEdit1.Click += new EventHandler(btnOrderDetail_Favorites_Click);

            gridView1.Columns["Order Detail"].ColumnEdit = repositoryItemButtonEdit1;
            gridView1.Columns["Order Detail"].OptionsColumn.AllowEdit = true;
        }

        private void btnViewImage_Favorites_Click(object sender, EventArgs e)
        {
            int focusRow = gridView1.FocusedRowHandle;

            if (focusRow > -1 && focusRow < gridView1.RowCount)
            {
                DataRow row = gridView1.GetDataRow(focusRow);
                string targetURL = row["View Image"].ToString();
                System.Diagnostics.Process.Start(targetURL);
            }
        }
        private void btnOrderDetail_Favorites_Click(object sender, EventArgs e)
        {
            int focusRow = gridView1.FocusedRowHandle;

            if (focusRow > -1 && focusRow < gridView1.RowCount)
            {
                DataRow row = gridView1.GetDataRow(focusRow);
                string value = row["Order Detail"].ToString();

                //RIS.Forms.Technologist.frmPatientData frmPatientdata
                //    = new RIS.Forms.Technologist.frmPatientData(value);
                //frmPatientdata.StartPosition = FormStartPosition.CenterParent;
                //frmPatientdata.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                //frmPatientdata.ShowDialog(this);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (InThePreProcess == false)
            {
                int focusRow = gridView1.FocusedRowHandle;
                if (focusRow > -1 && focusRow < gridView1.RowCount)
                {
                    DataRow row = gridView1.GetDataRow(focusRow);
                    memoEdit1.Rtf = row["RESULT_TEXT_RTF"].ToString();
                    string tn = "HN:(" + row["HN"].ToString() + ")" + row["Patient Name"].ToString() + " ExamCode:(" + row["Exam Code"].ToString() + ")" + row["Exam Name"].ToString() + " StudyDateTime:" + Convert.ToDateTime(row["Study Date Time"]).ToString("g") + "";
                    layoutControlGroup3.Text = tn;
                    this.focusRow[0] = focusRow;
                }
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (InThePreProcess == false)
            {
                int focusRow = e.FocusedRowHandle;
                if (focusRow > -1 && focusRow < gridView1.RowCount)
                {
                    DataRow row = gridView1.GetDataRow(focusRow);
                    memoEdit1.Rtf = row["RESULT_TEXT_RTF"].ToString();
                    string tn = "HN:(" + row["HN"].ToString() + ")" + row["Patient Name"].ToString() + " ExamCode:(" + row["Exam Code"].ToString() + ")" + row["Exam Name"].ToString() + " StudyDateTime:" + Convert.ToDateTime(row["Study Date Time"]).ToString("g")+"";
                    layoutControlGroup3.Text = tn;
                    this.focusRow[0] = focusRow;
                }
            }
        }

        private void btnAddTeachingFiles_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
            DataRow[] ArrRow = ((DataTable)gridControl1.DataSource).Select("Selected='Y'");
            if (ArrRow.Length > 0)
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                string str = msgBox.ShowAlert("UID2107", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    foreach (DataRow row in ArrRow)
                    {
                        RIS.BusinessLogic.ProcessGetRISRadstudygroup getRISRadstudygroup
                            = new RIS.BusinessLogic.ProcessGetRISRadstudygroup();
                        getRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
                        getRISRadstudygroup.RISRadstudygroup.ACCESSION_NO = row["Accession No"].ToString();
                        getRISRadstudygroup.RISRadstudygroup.MODE = "Exist";
                        getRISRadstudygroup.Invoke();

                        if (getRISRadstudygroup.Result.Tables[0].Rows.Count > 0)
                        {
                            RIS.BusinessLogic.ProcessUpdateRISRadstudygroup updateRISRadstudygroup
                                = new RIS.BusinessLogic.ProcessUpdateRISRadstudygroup();

                            updateRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            updateRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                                = row["Accession No"].ToString();

                            updateRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                                = false;

                            updateRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                                = true;

                            updateRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                                = false;

                            updateRISRadstudygroup.RISRadstudygroup.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            updateRISRadstudygroup.RISRadstudygroup.CREATED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            updateRISRadstudygroup.RISRadstudygroup.MODE
                                = "Teaching";

                            updateRISRadstudygroup.Invoke();
                        }
                        else
                        {
                            RIS.BusinessLogic.ProcessAddRISRadstudygroup addRISRadstudygroup
                                = new RIS.BusinessLogic.ProcessAddRISRadstudygroup();

                            addRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            addRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                                = row["Accession No"].ToString();

                            addRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                                = false;

                            addRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                                = true;

                            addRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                                = false;

                            addRISRadstudygroup.RISRadstudygroup.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            addRISRadstudygroup.RISRadstudygroup.CREATED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            addRISRadstudygroup.RISRadstudygroup.MODE
                                = "Teaching";

                            addRISRadstudygroup.Invoke();
                        }
                    }
                    //msgBox.ShowAlert("UID005", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                    LoadData_Favorites();
                }
            }
            else
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                msgBox.ShowAlert("UID2101", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            }
        }
        private void btnRemoveFavorites_Click(object sender, EventArgs e)
        {
            gridView1.RefreshData();
            DataRow[] ArrRow = ((DataTable)gridControl1.DataSource).Select("Selected='Y'");
            if (ArrRow.Length > 0)
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                string str = msgBox.ShowAlert("UID2104", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    foreach (DataRow row in ArrRow)
                    {
                        RIS.BusinessLogic.ProcessUpdateRISRadstudygroup updateRISRadstudygroup
                            = new RIS.BusinessLogic.ProcessUpdateRISRadstudygroup();

                        updateRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                            = new RIS.Common.Common.GBLEnvVariable().UserID;

                        updateRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                            = row["Accession No"].ToString();

                        updateRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.ORG_ID
                            = new RIS.Common.Common.GBLEnvVariable().OrgID;

                        updateRISRadstudygroup.RISRadstudygroup.CREATED_BY
                            = new RIS.Common.Common.GBLEnvVariable().UserID;

                        updateRISRadstudygroup.RISRadstudygroup.MODE
                            = "Favorites";

                        updateRISRadstudygroup.Invoke();
                    }

                    //msgBox.ShowAlert("UID005", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                    LoadData_Favorites();

                    memoEdit1.Text = "";
                }

            }
            else
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                msgBox.ShowAlert("UID2101", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            }
        }
        #endregion

        #region Teaching
        private void LoadData_Teaching()
        {
            RIS.BusinessLogic.ProcessGetRISRadstudygroup getRISRadstudygroup
                = new RIS.BusinessLogic.ProcessGetRISRadstudygroup();
            getRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
            getRISRadstudygroup.RISRadstudygroup.MODE = "Teaching";
            getRISRadstudygroup.Invoke();

            gridControl2.DataSource = getRISRadstudygroup.Result.Tables[0].Copy();

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                //gridView1.Columns[k].OptionsColumn.ReadOnly = true;
                ++k;
            }

            GetStyleFormatCondition_Teaching();
            GetPriorityEdit_Teaching();
            GetSeletedEdit_Teaching();
            GetViewImageEdit_Teaching();
            GetOrderDetailEdit_Teaching();

            gridView2.Columns["RESULT_TEXT_PLAIN"].Visible = false;
            gridView2.Columns["RESULT_TEXT_RTF"].Visible = false;
            gridView2.Columns["View Image"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["View Image"].Width = 50;
            gridView2.Columns["Order Detail"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["Order Detail"].Width = 50;

            gridView2.Columns["IS_FAVOURITE"].Visible = false;
            gridView2.Columns["IS_TEACHING"].Visible = false;
            gridView2.Columns["IS_OTHERS"].Visible = false;

            gridView2.Columns["Selected"].Width = 50;
            gridView2.Columns["Selected"].OptionsColumn.FixedWidth = true;
            gridView2.Columns["Selected"].OptionsColumn.AllowSize = false;
            gridView2.Columns["Selected"].OptionsColumn.AllowMove = false;

            gridView2.Columns["Study Date Time"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["Study Date Time"].DisplayFormat.FormatString = "g";

            gridView2.Columns["Added"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView2.Columns["Added"].DisplayFormat.FormatString = "g";

            gridView2.FocusedRowHandle = focusRow[1];

            //gridView2.BestFitColumns();
            BestFitColumns(gridView2);
        }

        private void GetStyleFormatCondition_Teaching()
        {
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

            DevExpress.XtraGrid.StyleFormatCondition stylCon6
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Added"], null, "Not Added");
            stylCon6.Appearance.ForeColor = Color.Red;

            DevExpress.XtraGrid.StyleFormatCondition stylCon7
                = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, gridView2.Columns["Added"], null, "Was Added");
            stylCon7.Appearance.ForeColor = Color.Green;

            gridView2.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] { stylCon6, stylCon7 });
        }
        private void GetPriorityEdit_Teaching()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2
                = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repositoryItemImageComboBox2.AutoHeight = false;
            repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Routine", 1, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Stat", 2, 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgent ", 3, 8)});
            repositoryItemImageComboBox2.SmallImages = this.imageList1;
            repositoryItemImageComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            gridView2.Columns["Priority"].ColumnEdit = repositoryItemImageComboBox2;
            //gridView1.Columns["Priority"].OptionsColumn.AllowEdit = false;
        }
        private void GetSeletedEdit_Teaching()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            repositoryItemCheckEdit1.NullText = "N";
            repositoryItemCheckEdit1.ValueChecked = "Y";
            repositoryItemCheckEdit1.ValueUnchecked = "N";

            gridView2.Columns["Selected"].ColumnEdit = repositoryItemCheckEdit1;
            gridView2.Columns["Selected"].OptionsColumn.AllowEdit = true;
        }
        private void GetViewImageEdit_Teaching()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.Clear();
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Pacs Image", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            repositoryItemButtonEdit1.ReadOnly = true;
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEdit1.Click += new EventHandler(btnViewImage_Teaching_Click);

            gridView2.Columns["View Image"].ColumnEdit = repositoryItemButtonEdit1;
            gridView2.Columns["View Image"].OptionsColumn.AllowEdit = true;
        }
        private void GetOrderDetailEdit_Teaching()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1
                = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.Clear();
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Order DTL", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null)});
            repositoryItemButtonEdit1.ReadOnly = true;
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEdit1.Click += new EventHandler(btnOrderDetail_Teaching_Click);

            gridView2.Columns["Order Detail"].ColumnEdit = repositoryItemButtonEdit1;
            gridView2.Columns["Order Detail"].OptionsColumn.AllowEdit = true;
        }

        private void btnViewImage_Teaching_Click(object sender, EventArgs e)
        {
            int focusRow = gridView2.FocusedRowHandle;

            if (focusRow > -1 && focusRow < gridView2.RowCount)
            {
                DataRow row = gridView2.GetDataRow(focusRow);
                string targetURL = row["View Image"].ToString();
                System.Diagnostics.Process.Start(targetURL);
            }
        }
        private void btnOrderDetail_Teaching_Click(object sender, EventArgs e)
        {
            int focusRow = gridView2.FocusedRowHandle;

            if (focusRow > -1 && focusRow < gridView2.RowCount)
            {
                DataRow row = gridView2.GetDataRow(focusRow);
                string value = row["Order Detail"].ToString();

                //RIS.Forms.Technologist.frmPatientData frmPatientdata
                //    = new RIS.Forms.Technologist.frmPatientData(value);
                //frmPatientdata.StartPosition = FormStartPosition.CenterParent;
                //frmPatientdata.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                //frmPatientdata.ShowDialog(this);
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            if (InThePreProcess == false)
            {
                int focusRow = gridView2.FocusedRowHandle;
                if (focusRow > -1 && focusRow < gridView2.RowCount)
                {
                    DataRow row = gridView2.GetDataRow(focusRow);
                    memoEdit2.Rtf = row["RESULT_TEXT_RTF"].ToString();
                    string tn = "HN:(" + row["HN"].ToString() + ")" + row["Patient Name"].ToString() + " ExamCode:(" + row["Exam Code"].ToString() + ")" + row["Exam Name"].ToString() + " StudyDateTime:" + Convert.ToDateTime(row["Study Date Time"]).ToString("g") + "";
                    layoutControlGroup6.Text = tn;
                    this.focusRow[1] = focusRow;
                }
            }
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (InThePreProcess == false)
            {
                int focusRow = e.FocusedRowHandle;
                if (focusRow > -1 && focusRow < gridView2.RowCount)
                {
                    DataRow row = gridView2.GetDataRow(focusRow);
                    memoEdit2.Rtf = row["RESULT_TEXT_RTF"].ToString();
                    string tn = "HN:(" + row["HN"].ToString() + ")" + row["Patient Name"].ToString() + " ExamCode:(" + row["Exam Code"].ToString() + ")" + row["Exam Name"].ToString() + " StudyDateTime:" + Convert.ToDateTime(row["Study Date Time"]).ToString("g") + "";
                    layoutControlGroup6.Text = tn;
                    this.focusRow[1] = focusRow;
                }
            }
        }

        private void btnAddFavorites_Click(object sender, EventArgs e)
        {
            gridView2.RefreshData();
            DataRow[] ArrRow = ((DataTable)gridControl2.DataSource).Select("Selected='Y'");
            if (ArrRow.Length > 0)
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                string str = msgBox.ShowAlert("UID2106", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    foreach (DataRow row in ArrRow)
                    {
                        RIS.BusinessLogic.ProcessGetRISRadstudygroup getRISRadstudygroup
                            = new RIS.BusinessLogic.ProcessGetRISRadstudygroup();
                        getRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
                        getRISRadstudygroup.RISRadstudygroup.ACCESSION_NO = row["Accession No"].ToString();
                        getRISRadstudygroup.RISRadstudygroup.MODE = "Exist";
                        getRISRadstudygroup.Invoke();

                        if (getRISRadstudygroup.Result.Tables[0].Rows.Count > 0)
                        {
                            RIS.BusinessLogic.ProcessUpdateRISRadstudygroup updateRISRadstudygroup
                                = new RIS.BusinessLogic.ProcessUpdateRISRadstudygroup();

                            updateRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            updateRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                                = row["Accession No"].ToString();

                            updateRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                                = true;

                            updateRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                                = false;

                            updateRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                                = false;

                            updateRISRadstudygroup.RISRadstudygroup.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            updateRISRadstudygroup.RISRadstudygroup.CREATED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            updateRISRadstudygroup.RISRadstudygroup.MODE
                                = "Favorites";

                            updateRISRadstudygroup.Invoke();
                        }
                        else
                        {
                            RIS.BusinessLogic.ProcessAddRISRadstudygroup addRISRadstudygroup
                                = new RIS.BusinessLogic.ProcessAddRISRadstudygroup();

                            addRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            addRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                                = row["Accession No"].ToString();

                            addRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                                = true;

                            addRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                                = false;

                            addRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                                = false;

                            addRISRadstudygroup.RISRadstudygroup.ORG_ID
                                = new RIS.Common.Common.GBLEnvVariable().OrgID;

                            addRISRadstudygroup.RISRadstudygroup.CREATED_BY
                                = new RIS.Common.Common.GBLEnvVariable().UserID;

                            addRISRadstudygroup.RISRadstudygroup.MODE
                                = "Favorites";

                            addRISRadstudygroup.Invoke();
                        }

                    }
                    //msgBox.ShowAlert("UID005", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                    LoadData_Teaching();
                }
            }
            else
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                msgBox.ShowAlert("UID2101", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            }
        }
        private void btnRemoveTeachingFiles_Click(object sender, EventArgs e)
        {
            gridView2.RefreshData();
            DataRow[] ArrRow = ((DataTable)gridControl2.DataSource).Select("Selected='Y'");
            if (ArrRow.Length > 0)
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                string str = msgBox.ShowAlert("UID2105", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                if (str == "2")
                {
                    foreach (DataRow row in ArrRow)
                    {
                        RIS.BusinessLogic.ProcessUpdateRISRadstudygroup updateRISRadstudygroup
                            = new RIS.BusinessLogic.ProcessUpdateRISRadstudygroup();

                        updateRISRadstudygroup.RISRadstudygroup.RADIOLOGIST_ID
                            = new RIS.Common.Common.GBLEnvVariable().UserID;

                        updateRISRadstudygroup.RISRadstudygroup.ACCESSION_NO
                            = row["Accession No"].ToString();

                        updateRISRadstudygroup.RISRadstudygroup.IS_FAVOURITE
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.IS_TEACHING
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.IS_OTHERS
                            = false;

                        updateRISRadstudygroup.RISRadstudygroup.ORG_ID
                            = new RIS.Common.Common.GBLEnvVariable().OrgID;

                        updateRISRadstudygroup.RISRadstudygroup.CREATED_BY
                            = new RIS.Common.Common.GBLEnvVariable().UserID;

                        updateRISRadstudygroup.RISRadstudygroup.MODE
                            = "Teaching";

                        updateRISRadstudygroup.Invoke();

                    }

                    //msgBox.ShowAlert("UID005", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
                    LoadData_Teaching();

                    memoEdit2.Text = "";
                }

            }
            else
            {
                RIS.Forms.GBLMessage.MyMessageBox msgBox = new RIS.Forms.GBLMessage.MyMessageBox();
                msgBox.ShowAlert("UID2101", new RIS.Common.Common.GBLEnvVariable().CurrentLanguageID);
            }
        }
        #endregion

        private void RadStudyManagement_Load(object sender, EventArgs e)
        {

        }


    }
}