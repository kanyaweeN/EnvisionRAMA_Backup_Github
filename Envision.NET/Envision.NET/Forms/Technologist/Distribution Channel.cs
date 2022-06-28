using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

using System.Globalization;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.NET.Forms.Main;
using Envision.NET.Forms.EMR;
using Envision.BusinessLogic;
using DevExpress.XtraEditors.Controls;
using Miracle.Util;
using Envision.Common.Common;
using DevExpress.XtraGrid.Views.Base;

namespace Envision.NET.Forms.Technologist
{
    public partial class Distribution_Channel : MasterForm
    {
        MyMessageBox msg = new MyMessageBox();
        private frmPopupOrderOrScheduleSummary _orderSummary;
        private int SearchEMPID, ReDisExmpid;
        private string Tab = "Dis";
        private DataTable dtgDrag;
        private DataTable KeepAcc;
        private DataTable dtAssignTo;
        private DataTable dttExamFlag, dtExamFlagDTL;
        bool ItemFlag = false;
        private Graphics Grp;
        private Rectangle Rta;
        private string GridChoose;
        private RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();
        GBLEnvVariable env = new GBLEnvVariable();

        private string _filterKeep = "";
        //private RepositoryItemCheckEdit chk = new RepositoryItemCheckEdit();

        private DateTime dateTryParse = new DateTime();

        public Distribution_Channel()
        {
            InitializeComponent();
            this._orderSummary = new frmPopupOrderOrScheduleSummary();
        }

        private void Distribution_Channel_Load(object sender, EventArgs e)
        {
            setTrauma();
            txtAssignSearch.Enabled = false;
            SetShowGrid("All");
            SetNullGrid();
            chkAutoaddtolist.Checked = true;
            bindData();
            initLocFilter();
            base.CloseWaitDialog();
        }
        private void SetNullGrid()
        {
            dtAssignTo = new DataTable();
            ProcessGetDistributeNew dis = new ProcessGetDistributeNew();
            dis.DistributionNew.selectcase = 19;
            dis.Invoke();
            dtAssignTo = dis.ResultSet.Tables[0];

            SearchInSearchCriteria();
            SetColumnGrid();
        }
        private void bindData()
        {
            txtAssignSearch.Text = "Rad. ID/Rad. Name";
            txtAssignDis.Text = "Rad. ID/Rad. Name";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";

            txtAccessionDis.Enabled = false;
            txtHnDis.Enabled = false;

            //btnDistribution.Enabled = false;
            //btnDelete.Enabled = false;


            gridControl1.DataSource = null;

            grdHNMain.DataSource = null;
            grdHNselect.DataSource = null;
            SetShowGrid("All");

        }

        #region LookUp

        private void btnSearchS_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;

            txtAccessionDis.Enabled = false;
            txtHnDis.Enabled = false;

            txtAccessionSearch.Text = "";
            txtHnSearch.Text = "";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";
            //dateEdit1.Focus();
            btnSearch.Focus();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnSearchS_Clicks);
            lv.AddColumn("EMP_UID", "EMP NAME", true, true);
            lv.AddColumn("FULLNAME", "Name", true, true);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.Text = "Radiologist Detail List";
            lv.Size = new Size(600, 400);
            ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
            geD.DistributionNew.selectcase = 19;
            geD.Invoke();
            DataTable dtt = geD.ResultSet.Tables[0];
            lv.Data = dtt;
            //lv.Data = RIS.BusinessLogic.Order.SelectHNAll();
            lv.ShowBox();
        }
        private void btnSearchS_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAssignSearch.Text = retValue[1];
            SearchEMPID = Convert.ToInt32(retValue[2]);
            dateEdit1.Focus();
        }
        private void btnSearchD_Click(object sender, EventArgs e)
        {
            txtHnDis.Enabled = true;
            txtAccessionDis.Enabled = true;
            txtHnDis.Text = "";
            txtAccessionDis.Text = "";
            txtAccessionDis.Focus();
            ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
            geD.DistributionNew.selectcase = 19;
            geD.Invoke();
            DataTable dtt = geD.ResultSet.Tables[0];

            gridControl1.DataSource = null;
            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnSearchD_Clicks);
            lv.AddColumn("EMP_UID", "EMP NAME", true, true);
            lv.AddColumn("FULLNAME", "Name", true, true);
            lv.AddColumn("EMP_ID", "ID", false, true);
            lv.Text = "Radiologist Detail List";
            lv.Size = new Size(600, 400);
            lv.Data = dtt;
            lv.ShowBox();
        }
        private void btnSearchD_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            this.txtHnDis.Text = "";
            gridControl1.DataSource = null;
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAssignDis.Text = retValue[1];
            SearchEMPID = Convert.ToInt32(retValue[2]);

            txtAccessionDis.Focus();
        }

        #endregion

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        private void ClearSearch()
        {
            gridControl1.DataSource = null;
            txtAssignSearch.Text = "Rad. ID/Rad. Name";
            dateEdit1.Text = "DD/MM/YYYY";
            dateEdit2.Text = "DD/MM/YYYY";
            txtHnSearch.Text = "";
            txtAccessionSearch.Text = "";
            advBandedGridView1.ActiveFilterString = _filterKeep;
            txtAssignSearch.Focus();
            SearchEMPID = 0;
        }
        private void btnClearDistribute_Click(object sender, EventArgs e)
        {
            ClearDis();
        }
        private void ClearDis()
        {
            txtAccessionDis.Text = "";
            txtAssignDis.Text = "Rad. ID/Rad. Name";
            txtHnDis.Text = "";
            chkAutoaddtolist.Checked = true;
            advBandedGridView1.ActiveFilterString = "";

            bindData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAssignSearch.Text == "" || txtAssignSearch.Text == "Rad. ID/Rad. Name" && txtHnSearch.Text == "" && txtAccessionSearch.Text == "" && dateEdit1.Text == "DD/MM/YYYY" && dateEdit2.Text == "DD/MM/YYYY")
            {
                msg.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
            }
            else
            {
                SearchInSearchCriteria();
            }
        }
        private string setFormatSearchDate(DateTime date)
        {
            string _date = "";
            _date += date.Year.ToString();
            _date += "-";
            _date += date.Month.ToString().Length == 1 ? "0" + date.Month.ToString() : date.Month.ToString();
            _date += "-";
            _date += date.Day.ToString().Length == 1 ? "0" + date.Day.ToString() : date.Day.ToString();
            _date += " 0:00:00";
            return _date;
        }
        private void SearchInSearchCriteria()
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Loading Data", s);

            ProcessGetDistribution getData = new ProcessGetDistribution();
            getData.DistributionCommon.datefrom = dateEdit1.Text == "DD/MM/YYYY" ? "" : setFormatSearchDate(dateEdit1.DateTime);
            getData.DistributionCommon.todate = dateEdit2.Text == "DD/MM/YYYY" ? "" : setFormatSearchDate(dateEdit2.DateTime.AddDays(1));
            getData.DistributionCommon.accessionno = txtAccessionSearch.Text.Trim();
            getData.DistributionCommon.assignedTo = SearchEMPID.ToString() == "0" ? "" : SearchEMPID.ToString();
            getData.DistributionCommon.hn = txtHnSearch.Text.Trim();
            getData.Invoke();
            gridControl1.DataSource = getData.ResultSet.Tables[0];
            dlg.Close();
        }

        private void chkAutoaddtolist_EditValueChanged(object sender, EventArgs e)
        {
            if (chkAutoaddtolist.Checked == true)
            {
                btnAddtolist.Enabled = false;
            }
            else if (chkAutoaddtolist.Checked == false)
            {
                btnAddtolist.Enabled = true;
            }
        }

        private void initLocFilter()
        {
            ProcessGetRISExamresultFilterworklist filterData = new ProcessGetRISExamresultFilterworklist();
            filterData.Invoke();

            cmbLocFilter.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbLocFilter.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in filterData.Result.Tables[0].Rows)
                    colls.Add(new Filter_WLLOC_Mode(Convert.ToInt32(dr["FILTER_ID"]), dr["FILTER_NAME"].ToString(), dr["FILTER_DETAIL"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbLocFilter.SelectedIndex = 0;
        }
        private void cmbLocFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilterGrid("FILTER");
        }
        private void setFilterGrid(string filterFrom)
        {
            Filter_WLLOC_Mode filterMode = cmbLocFilter.SelectedItem as Filter_WLLOC_Mode;
            if (filterMode != null)
            {
                DataSet getXML = new DataSet();
                System.IO.MemoryStream mem = null;
                char[] chr = filterMode.Loc_Filter().ToCharArray();
                byte[] data = new byte[chr.Length];
                for (int i = 0; i < chr.Length; i++)
                    data[i] = (byte)chr[i];
                mem = new System.IO.MemoryStream(data);

                getXML.ReadXml(mem);

                if (Utilities.IsHaveData(getXML))
                {
                    string valueExamtype = "";
                    string valueOrderingDept = "";
                    string valueFilter = "";

                    if (filterFrom == "FILTER")
                    {
                        valueFilter = getXML.Tables[0].Rows[0]["FILTER_COLUMNS"].ToString();
                        valueExamtype = getXML.Tables[0].Rows[0]["EXAM_TYPE"].ToString();
                        valueOrderingDept = getXML.Tables[0].Rows[0]["REF_UNIT"].ToString();
                    }

                    string strFilter = "";

                    if (!string.IsNullOrEmpty(valueExamtype))
                        strFilter += "EXAM_TYPE IN (" + valueExamtype + ")";
                    if (!string.IsNullOrEmpty(valueOrderingDept))
                        strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND" + " REF_UNIT IN (" + valueOrderingDept + ")";
                    if (!string.IsNullOrEmpty(valueFilter))
                        strFilter += string.IsNullOrEmpty(strFilter) ? "" : " AND " + valueFilter;

                    advBandedGridView1.ActiveFilterString = _filterKeep = strFilter;
                    advBandedGridView1.ActiveFilterEnabled = true;
                }
            }

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = (DataTable)gridControl1.DataSource;
                if (dtt.Rows.Count > 0)
                {
                    advBandedGridView1.DeleteSelectedRows();
                }
                else
                {
                    viewHNMain.DeleteSelectedRows();
                }


                //dtt.AcceptChanges();

                //for (int i = 0; i < dtt.Rows.Count; i++)
                //{
                //    dtt.AcceptChanges();
                //    if (dtt.Rows[i]["All"].ToString() == "Y")
                //    {
                //        advBandedGridView1.SelectRow(i);
                //        advBandedGridView1.DeleteRow(i);
                //    }
                //    dtt.AcceptChanges();
                //    advBandedGridView1.RefreshData();
                //    //advBandedGridView1.DeleteSelectedRows();
                //}

                //dtt.AcceptChanges();

                DataTable dtTemp = new DataTable();
                dtt = dtTemp.Copy();
                //viewHNMain.DeleteSelectedRows();
            }
            catch (Exception exp)
            {
            }


        }
        private void SelectAll(string flag)
        {
            if (flag == "AC")
            {
                txtAccessionDis.SelectionStart = 0;
                txtAccessionDis.SelectionLength = txtAccessionDis.Text.Length;
                txtAccessionDis.Focus();
            }
            else if (flag == "HN")
            {
                txtHnDis.SelectionStart = 0;
                txtHnDis.SelectionLength = txtHnDis.Text.Length;
                txtHnDis.Focus();
            }
            else if (flag == "HNS")
            {
                txtHnSearch.SelectionStart = 0;
                txtHnSearch.SelectionLength = txtHnSearch.Text.Length;
                txtHnSearch.Focus();
            }
            else if (flag == "ACS")
            {
                txtAccessionSearch.SelectionStart = 0;
                txtAccessionSearch.SelectionLength = txtAccessionSearch.Text.Length;
                txtAccessionSearch.Focus();
            }

        }
        private void btnAddtolist_Click(object sender, EventArgs e)
        {
            GetAccesionPageDistribute();
        }

        private void btnDistribution_Click(object sender, EventArgs e)
        {
            //if (xtraTabControl1.SelectedTabPage == pageSearchCriteria)
            //    return;

            if (xtraTabControl2.SelectedTabPage == xtabGridAll)
            {
                if (gridControl1.DataSource == null)
                {
                    return;
                }
            }
            else if (xtraTabControl2.SelectedTabPage == xtabGridHN)
            {
                if (grdHNMain.DataSource == null)
                {
                    return;
                }
            }
            //gridControl1.DataSource = null;
            txtAssignDis.Text = "";
            txtAccessionDis.Text = "";
            txtHnDis.Text = "";
            txtAccessionSearch.Text = "";
            txtAssignSearch.Text = "";
            txtHnSearch.Text = "";
            UpdateData();
            bindData();

        }
        private void UpdateData()
        {
            GBLEnvVariable env = new GBLEnvVariable();


            if (Tab == "Search")
            {
                DataTable dtG = (DataTable)gridControl1.DataSource;
                DataRow[] drG = dtG.Select("All='Y'");
                if (drG.Length >= 1)
                {
                    Dialog.frmConfirmDistributeChannel frm = new Dialog.frmConfirmDistributeChannel(drG);
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        SearchInSearchCriteria();
                        bindData();

                    }
                }

                //DataTable dtg = (DataTable)gridControl1.DataSource;
                //DataTable dtt = dtg.Copy();

                //dtt.AcceptChanges();

                //for (int i = 0; i < dtt.Rows.Count; i++)
                //{
                //    ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                //    upd.DistributionNew.accessionno = dtt.Rows[i]["Accession NO."].ToString();
                //    if (string.IsNullOrEmpty(dtt.Rows[i]["Assigned Rad."].ToString()))
                //    {
                //        upd.DistributionNew.assignedTo = 0;

                //        //upd.DistributionNew.PRIORITY = dtt.Rows[i]["Priority"].ToString();
                //        //upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                //        //upd.Invoke();
                //    }
                //    else
                //    {
                //        if (KeepAcc != null)
                //        {


                //            foreach (DataRow drTemp in KeepAcc.Rows)
                //            {
                //                if (dtt.Rows[i]["Accession NO."].ToString() == drTemp["Accession"].ToString())
                //                {
                //                    upd.DistributionNew.assignedTo = Convert.ToInt32(dtt.Rows[i]["Assigned Rad."]);

                //                    upd.DistributionNew.PRIORITY = dtt.Rows[i]["Priority"].ToString();
                //                    upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                //                    upd.Invoke();
                //                }

                //            }
                //        }
                //    }
                //}
            }
            else if (Tab == "Dis")
            {
                if (grdHNMain.DataSource != null)
                {
                    DataTable dtgHN = (DataTable)grdHNMain.DataSource;
                    DataTable dttHN = dtgHN.Copy();
                    dttHN.AcceptChanges();


                    for (int i = 0; i < dttHN.Rows.Count; i++)
                    {
                        ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                        upd.DistributionNew.accessionno = dttHN.Rows[i]["Accession NO."].ToString();
                        upd.DistributionNew.assignedTo = SearchEMPID;
                        upd.DistributionNew.PRIORITY = dttHN.Rows[i]["Priority"].ToString();
                        upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upd.Invoke();
                    }
                }
                else if (gridControl1.DataSource != null)
                {
                    DataTable dtgAC = (DataTable)gridControl1.DataSource;
                    DataTable dttAC = dtgAC.Copy();
                    dttAC.AcceptChanges();

                    for (int z = 0; z < dttAC.Rows.Count; z++)
                    {
                        ProcessUpdateDistributionNew upd = new ProcessUpdateDistributionNew();
                        upd.DistributionNew.accessionno = dttAC.Rows[z]["Accession NO."].ToString();
                        upd.DistributionNew.assignedTo = SearchEMPID;
                        upd.DistributionNew.PRIORITY = dtgAC.Rows[z]["Priority"].ToString();
                        upd.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upd.Invoke();
                    }
                }
            }
        }
        private void SetColumnGrid()
        {
            GridChoose = "Main";
            //---Focus row---//
            advBandedGridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            //--------------------------//
            advBandedGridView1.OptionsSelection.MultiSelect = true;
            advBandedGridView1.OptionsView.ShowGroupPanel = false;
            //advBandedGridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            advBandedGridView1.OptionsView.AutoCalcPreviewLineCount = true;
            advBandedGridView1.OptionsView.ShowAutoFilterRow = true;
            advBandedGridView1.OptionsView.ShowBands = false;
            advBandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;

            for (int i = 0; i < advBandedGridView1.Columns.Count; i++)
            {
                advBandedGridView1.Columns[i].Visible = false;
            }

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGrid = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkGrid.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkGrid.ValueChecked = "Y";
            chkGrid.ValueUnchecked = "N";
            chkGrid.Click += new EventHandler(chkGrid_Click);

            advBandedGridView1.Columns["All"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["All"].Caption = "";
            advBandedGridView1.Columns["All"].Visible = true;
            advBandedGridView1.Columns["All"].ColumnEdit = chkGrid;
            advBandedGridView1.Columns["All"].Width = 10;
            advBandedGridView1.Columns["All"].ColVIndex = 0;

            advBandedGridView1.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["HN"].Visible = true;
            advBandedGridView1.Columns["HN"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["HN"].Width = 50;

            advBandedGridView1.Columns["Pat.Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Pat.Name"].Visible = true;
            advBandedGridView1.Columns["Pat.Name"].Caption = "Pat.Name";
            advBandedGridView1.Columns["Pat.Name"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Pat.Name"].Width = 150;

            advBandedGridView1.Columns["Exam Code"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Code"].Visible = true;
            advBandedGridView1.Columns["Exam Code"].Caption = "Exam Code";
            advBandedGridView1.Columns["Exam Code"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Exam Code"].Width = 80;

            advBandedGridView1.Columns["Exam Name"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Exam Name"].Visible = true;
            advBandedGridView1.Columns["Exam Name"].Caption = "Exam Name";
            advBandedGridView1.Columns["Exam Name"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Exam Name"].Width = 150;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtDate = new RepositoryItemTextEdit();

            advBandedGridView1.Columns["Order Date Time"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Order Date Time"].Visible = true;
            advBandedGridView1.Columns["Order Date Time"].ColumnEdit = txtDate;
            advBandedGridView1.Columns["Order Date Time"].Caption = "Order Date Time";
            advBandedGridView1.Columns["Order Date Time"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Order Date Time"].Width = 80;

            advBandedGridView1.Columns["Accession No."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Accession No."].Visible = true;
            advBandedGridView1.Columns["Accession No."].Caption = "Accession No.";
            advBandedGridView1.Columns["Accession No."].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Accession No."].Width = 80;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            advBandedGridView1.Columns["Priority"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Priority"].Visible = true;
            advBandedGridView1.Columns["Priority"].ColumnEdit = imCmb;
            advBandedGridView1.Columns["Priority"].Caption = "Priority";
            advBandedGridView1.Columns["Priority"].ColVIndex = 1;
            advBandedGridView1.Columns["Priority"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Priority"].Width = 10;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repFlag = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            repFlag.AutoHeight = false;
            foreach (DataRow rowFlag in dtExamFlagDTL.Rows)
            {
                repFlag.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    rowFlag["GEN_TEXT"].ToString()
                    , Convert.ToInt32(rowFlag["SL_NO"].ToString())
                    , Convert.ToInt32(rowFlag["SL_NO"].ToString()) - 1
                    ));
            }
            repFlag.Name = "repFlag";
            repFlag.SmallImages = this.img16;
            repFlag.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repFlag.Buttons[0].Visible = false;

            advBandedGridView1.Columns["FLAG_ICON"].ColVIndex = 2;
            advBandedGridView1.Columns["FLAG_ICON"].Caption = " ";
            advBandedGridView1.Columns["FLAG_ICON"].Width = -1;
            advBandedGridView1.Columns["FLAG_ICON"].ColumnEdit = repFlag;
            advBandedGridView1.Columns["FLAG_ICON"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["FLAG_ICON"].OptionsColumn.AllowEdit = false;
            advBandedGridView1.Columns["FLAG_ICON"].OptionsFilter.AllowFilter = false;

            advBandedGridView1.Columns["PATIENT_ID_LABEL"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["PATIENT_ID_LABEL"].Visible = true;
            advBandedGridView1.Columns["PATIENT_ID_LABEL"].Caption = " ";
            advBandedGridView1.Columns["PATIENT_ID_LABEL"].ColVIndex = 3;
            advBandedGridView1.Columns["PATIENT_ID_LABEL"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["PATIENT_ID_LABEL"].Width = 30;

            advBandedGridView1.Columns["Result Status"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Result Status"].Visible = true;
            advBandedGridView1.Columns["Result Status"].Caption = "Result Status";
            advBandedGridView1.Columns["Result Status"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Result Status"].Width = 80;

            advBandedGridView1.Columns["Result By."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Result By."].Visible = true;
            advBandedGridView1.Columns["Result By."].Caption = "Result By.";
            advBandedGridView1.Columns["Result By."].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Result By."].Width = 130;

            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtRequestResult = new RepositoryItemDateEdit();
            dtRequestResult.CloseUp += new CloseUpEventHandler(dtRequestResult_CloseUp);
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy";
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].ColumnEdit = dtRequestResult;
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].Visible = true;
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].Caption = "Request Result Datetime";
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["REQUEST_RESULT_DATETIME"].Width = 130;

            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdCmd = new RepositoryItemGridLookUpEdit();
            grdCmd.DataSource = dtAssignTo;

            #region SetGrdLookup
            grdCmd.View.OptionsView.ShowAutoFilterRow = true;
            grdCmd.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            grdCmd.View.Columns["EMP_UID"].Visible = true;
            grdCmd.View.Columns["EMP_UID"].Caption = "Code";


            grdCmd.View.Columns["FULLNAME"].Visible = true;
            grdCmd.View.Columns["EMP_ID"].Visible = false;

            #endregion

            grdCmd.ValueMember = "EMP_ID";
            grdCmd.DisplayMember = "FULLNAME";
            grdCmd.NullText = "";
            grdCmd.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(grdCmd_CloseUp);

            advBandedGridView1.Columns["Assigned Rad."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Assigned Rad."].Visible = true;
            advBandedGridView1.Columns["Assigned Rad."].ColumnEdit = grdCmd;
            advBandedGridView1.Columns["Assigned Rad."].Caption = "Assigned Rad.";
            advBandedGridView1.Columns["Assigned Rad."].OptionsColumn.ReadOnly = false;
            advBandedGridView1.Columns["Assigned Rad."].Width = 130;

            advBandedGridView1.Columns["Distributed By."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Distributed By."].Visible = true;
            advBandedGridView1.Columns["Distributed By."].Caption = "Distributed By.";
            advBandedGridView1.Columns["Distributed By."].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Distributed By."].Width = 130;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textDis = new RepositoryItemTextEdit();
            advBandedGridView1.Columns["Distributed ON."].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["Distributed ON."].Visible = true;
            advBandedGridView1.Columns["Distributed ON."].Caption = "Distributed ON.";
            advBandedGridView1.Columns["Distributed ON."].ColumnEdit = textDis;
            advBandedGridView1.Columns["Distributed ON."].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["Distributed ON."].Width = 80;

            advBandedGridView1.Columns["AGE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["AGE"].Visible = true;
            advBandedGridView1.Columns["AGE"].Caption = "AGE";
            advBandedGridView1.Columns["AGE"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["AGE"].Width = 80;

            advBandedGridView1.Columns["OPD"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["OPD"].Visible = true;
            advBandedGridView1.Columns["OPD"].Caption = "Order Dept.";
            advBandedGridView1.Columns["OPD"].OptionsColumn.ReadOnly = true;
            advBandedGridView1.Columns["OPD"].Width = 80;

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                   chkTemplate = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkTemplate.ValueChecked = "Y";
            chkTemplate.ValueUnchecked = "N";
            chkTemplate.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chkTemplate.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.InactiveChecked;
            chkTemplate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chkTemplate.Click += new EventHandler(chkTemplate_Click);

            advBandedGridView1.Columns["IS_DF"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["IS_DF"].Visible = true;
            advBandedGridView1.Columns["IS_DF"].Caption = "DF";
            advBandedGridView1.Columns["IS_DF"].ColumnEdit = chkTemplate;
            advBandedGridView1.Columns["IS_DF"].OptionsColumn.ReadOnly = false;
            advBandedGridView1.Columns["IS_DF"].Width = 10;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit6 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit6.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit6.ImmediatePopup = true;
            repositoryItemLookUpEdit6.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit6.AutoHeight = false;
            repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLINIC_TYPE_TEXT", "Clinic Type", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit6.DisplayMember = "CLINIC_TYPE_TEXT";
            repositoryItemLookUpEdit6.ValueMember = "CLINIC_TYPE_ID";
            repositoryItemLookUpEdit6.DropDownRows = 5;
            repositoryItemLookUpEdit6.NullText = string.Empty;
            repositoryItemLookUpEdit6.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(clinic_CloseUp);
            repositoryItemLookUpEdit6.DataSource = RISBaseData.RIS_ClinicType();
            repositoryItemLookUpEdit6.BestFit();
            repositoryItemLookUpEdit6.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

            advBandedGridView1.Columns["CLINIC_TYPE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["CLINIC_TYPE"].Visible = true;
            advBandedGridView1.Columns["CLINIC_TYPE"].Caption = "Clinic Type";
            advBandedGridView1.Columns["CLINIC_TYPE"].ColumnEdit = repositoryItemLookUpEdit6;
            advBandedGridView1.Columns["CLINIC_TYPE"].OptionsColumn.ReadOnly = false;
            advBandedGridView1.Columns["CLINIC_TYPE"].Width = 50;

            advBandedGridView1.Columns["MODALITY_NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["MODALITY_NAME"].Visible = true;
            advBandedGridView1.Columns["MODALITY_NAME"].Caption = "Modality";
            advBandedGridView1.Columns["MODALITY_NAME"].OptionsColumn.ReadOnly = false;
            advBandedGridView1.Columns["MODALITY_NAME"].Width = 50;

            advBandedGridView1.Columns["AppointmentDatetime"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            advBandedGridView1.Columns["AppointmentDatetime"].Visible = true;
            advBandedGridView1.Columns["AppointmentDatetime"].Caption = "Appointment Datetime";
            advBandedGridView1.Columns["AppointmentDatetime"].OptionsColumn.ReadOnly = false;
            advBandedGridView1.Columns["AppointmentDatetime"].Width = 50;
        }
        private void setTrauma()
        {
            ProcessGetRISOrderexamflag prc = new ProcessGetRISOrderexamflag();
            prc.RIS_ORDEREXAMFLAG.ORDER_ID = -1;
            prc.Invoke();
            dttExamFlag = prc.Result.Tables[0]; //Set template table.
            dtExamFlagDTL = prc.resultDetail();

            //contextcmb.Items.Clear();
            //contextcmbSchedule.Items.Clear();
            //System.Windows.Forms.ComboBox.ObjectCollection colls = contextcmb.Items;
            //System.Windows.Forms.ComboBox.ObjectCollection collSch = contextcmbSchedule.Items;
            //try
            //{
            //    foreach (DataRow row in dtExamFlagDTL.Rows)
            //    {
            //        colls.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
            //        collSch.Add(new TraumaItems(Convert.ToInt32(row["GEN_DTL_ID"]), row["GEN_TEXT"].ToString(), Convert.ToInt32(row["SL_NO"])));
            //    }
            //}
            //finally
            //{
            //}
            //contextcmb.SelectedIndex = 0;
            //contextcmbSchedule.SelectedIndex = 0;
        }
        private void dtRequestResult_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (advBandedGridView1.FocusedRowHandle >= 0)
                {
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    ProcessUpdateRISOrder ord = new ProcessUpdateRISOrder();
                    ord.RIS_ORDER.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
                    ord.RIS_ORDER.REQUEST_RESULT_DATETIME = Convert.ToDateTime(e.Value);
                    ord.UpdateRequestResult();
                    SearchInSearchCriteria();
                }
            }
            else
            {
                if (advBandedGridView1.FocusedRowHandle >= 0)
                {
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    ProcessUpdateRISOrder ord = new ProcessUpdateRISOrder();
                    ord.RIS_ORDER.ORDER_ID = Convert.ToInt32(dr["ORDER_ID"]);
                    ord.RIS_ORDER.REQUEST_RESULT_DATETIME = DateTime.MinValue;
                    ord.UpdateRequestResult();
                    SearchInSearchCriteria();
                }
            }
        }

        private void chkTemplate_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (advBandedGridView1.FocusedRowHandle >= 0)
            {

                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                ProcessUpdateRISOrderdtl upDF = new ProcessUpdateRISOrderdtl();
                upDF.UpdateIsDF(chk.Checked ? "N" : "Y", dr["Accession No."].ToString(), env.UserID);
            }
        }

        public void grdCmd_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (advBandedGridView1.FocusedRowHandle < 0)
                return;
            DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            if (e.AcceptValue)
            {


                if (dr["Result Status"].ToString() != "Finalize")
                {
                    string _id = msg.ShowAlert("UID4008", env.CurrentLanguageID);
                    if (_id == "3")
                    {
                        KeepAcc = new DataTable();
                        KeepAcc.Columns.Add("Accession");
                        KeepAcc.AcceptChanges();

                        DataRow drNew = KeepAcc.NewRow();
                        drNew["Accession"] = dr["Accession No."];

                        KeepAcc.Rows.Add(drNew);

                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["Accession No."].ToString();
                        upDis.DistributionNew.assignedTo = (int)e.Value;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                    }
                    else if (_id == "2")
                    {
                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["Accession No."].ToString();
                        upDis.DistributionNew.assignedTo = 0;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                        e.Value = 0;
                    }
                    else
                    {
                        e.Value = dr["Assigned Rad."];
                    }

                }
                else
                {
                    string _id = msg.ShowAlert("UID4021", env.CurrentLanguageID);
                    e.Value = 0;
                }
            }
            SearchInSearchCriteria();


            //Clear filter in LookupEdit
            DevExpress.XtraEditors.GridLookUpEdit grdCmd = (DevExpress.XtraEditors.GridLookUpEdit)sender;
            grdCmd.Properties.View.ActiveFilterString = "";
        }
        private void clinic_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.AcceptValue)
            {
                if (advBandedGridView1.FocusedRowHandle >= 0)
                {
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    ProcessUpdateRISClinicType update = new ProcessUpdateRISClinicType();
                    update.UpdateByAccession(dr["Accession No."].ToString(), Convert.ToInt32(e.Value), env.UserID);
                }
            }
        }

        private void chkGrid_Click(object sender, EventArgs e)
        {
            //DataTable dtt = (DataTable)gridControl1.DataSource;

            //if (advBandedGridView1.FocusedRowHandle <0)
            //{
            //    return;
            //}
            //if (chk.ValueChecked == "Y")
            //{
            //    dtt.Rows[advBandedGridView1.FocusedRowHandle]["All"] = "N";  
            //}
            //else
            //{
            //    dtt.Rows[advBandedGridView1.FocusedRowHandle]["All"] = "Y";
            //}
            //advBandedGridView1.SelectRow(advBandedGridView1.FocusedRowHandle);

            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (advBandedGridView1.FocusedRowHandle >= 0)
            {

                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                dr["All"] = chk.Checked ? "N" : "Y";
                //PreItemflag = false;
            }

        }
        private void SetColumnGridHN()
        {
            GridChoose = "HN";
            viewHNselect.Columns["All"].Visible = false;
            viewHNselect.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewHNselect.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewHNselect.OptionsSelection.InvertSelection = false;
            //viewHNselect.OptionsSelection.MultiSelect = true;
            viewHNselect.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            ProcessGetDistributeNew dis = new ProcessGetDistributeNew();
            dis.DistributionNew.selectcase = 19;
            dis.Invoke();
            DataSet dstt = dis.ResultSet;
            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdCmd = new RepositoryItemGridLookUpEdit();
            grdCmd.DataSource = dstt.Tables[0];

            #region SetGrdLookup
            grdCmd.View.OptionsView.ShowAutoFilterRow = true;
            grdCmd.View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;

            grdCmd.View.Columns["EMP_UID"].Visible = true;
            grdCmd.View.Columns["EMP_UID"].Caption = "Code";


            grdCmd.View.Columns["FULLNAME"].Visible = true;
            grdCmd.View.Columns["EMP_ID"].Visible = false;

            viewHNselect.Columns["Assigned Rad."].ColumnEdit = grdCmd;
            #endregion

            grdCmd.ValueMember = "EMP_ID";
            grdCmd.DisplayMember = "FULLNAME";
            grdCmd.NullText = "";

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textDis = new RepositoryItemTextEdit();
            viewHNselect.Columns["Distributed ON."].ColumnEdit = textDis;
            /*---------------------------------------------------------------*/



            viewHNMain.Columns["All"].Visible = false;
            viewHNMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            viewHNMain.OptionsSelection.EnableAppearanceFocusedRow = true;
            viewHNMain.OptionsSelection.InvertSelection = false;
            viewHNMain.OptionsSelection.MultiSelect = true;
            viewHNMain.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            viewHNMain.Columns["Priority"].ColumnEdit = imCmb;
            viewHNMain.Columns["Priority"].ColVIndex = 0;
            viewHNMain.Columns["Assigned Rad."].ColumnEdit = grdCmd;
            viewHNMain.Columns["Distributed ON."].ColumnEdit = textDis;

            viewHNselect.Columns["Priority"].ColumnEdit = imCmb;
            viewHNselect.Columns["Priority"].ColVIndex = 0;

        }
        private void GetAccesionPageDistribute()
        {
            if (txtAccessionDis.Text.Trim() != "")
            {
                SelectAll("AC");

                ProcessGetDistributeNew ge = new ProcessGetDistributeNew();
                ge.DistributionNew.selectcase = 20;
                ge.DistributionNew.accessionno = txtAccessionDis.Text;
                ge.Invoke();
                DataSet dsSearch = ge.ResultSet;

                DataTable dtTemp = new DataTable();

                if (gridControl1.DataSource != null)
                {
                    DataTable dtSearch = new DataTable();
                    dtSearch = dsSearch.Tables[0];
                    dtTemp = (DataTable)gridControl1.DataSource;

                    DataRow[] drs = dtTemp.Select("[Accession No.]='" + txtAccessionDis.Text + "'");
                    if (drs.Length > 0) return;


                    for (int y = 0; y < dtSearch.Rows.Count; y++)
                    {
                        DataRow Newdr = dtTemp.NewRow();

                        Newdr["HN"] = dtSearch.Rows[y]["HN"];
                        Newdr["Pat.Name"] = dtSearch.Rows[y]["Pat.Name"];
                        Newdr["AGE"] = dtSearch.Rows[y]["AGE"];
                        Newdr["Exam Code"] = dtSearch.Rows[y]["Exam Code"];
                        Newdr["Exam Name"] = dtSearch.Rows[y]["Exam Name"];
                        Newdr["Accession No."] = dtSearch.Rows[y]["Accession No."];
                        Newdr["Order Date Time"] = dtSearch.Rows[y]["Order Date Time"];
                        Newdr["Priority"] = dtSearch.Rows[y]["Priority"];
                        Newdr["Result Status"] = dtSearch.Rows[y]["Result Status"];
                        Newdr["Assigned Rad."] = dtSearch.Rows[y]["Assigned Rad."];
                        Newdr["Distributed By."] = dtSearch.Rows[y]["Distributed By."];
                        Newdr["OPD"] = dtSearch.Rows[y]["OPD"];
                        Newdr["CLINIC_TYPE"] = dtSearch.Rows[y]["CLINIC_TYPE"];

                        dtTemp.Rows.Add(Newdr);
                    }
                }
                else
                {
                    dtTemp = dsSearch.Tables[0];
                }
                gridControl1.DataSource = dtTemp;
                DataTable dtCount = (DataTable)gridControl1.DataSource;
            }
            else if (txtHnDis.Text.Trim() != "")
            {
                SetShowGrid("HN");

                ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
                geD.DistributionNew.selectcase = 21;
                geD.DistributionNew.hn = txtHnDis.Text.Trim();
                geD.Invoke();

                DataSet dsDHN = geD.ResultSet;

                SelectAll("HN");

                grdHNselect.DataSource = dsDHN.Tables[0];
                grdHNMain.DataSource = dsDHN.Tables[0].Clone();

                SetColumnGridHN();

            }

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageSearchCriteria)
            {
                gridControl1.DataSource = null;
                Tab = "Search";
                ClearSearch();
                SetShowGrid("All");
                txtAssignSearch.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;

            }
            else if (xtraTabControl1.SelectedTabPage == pageDistributeCriteria)
            {
                gridControl1.DataSource = null;
                Tab = "Dis";
                ClearDis();
                SetShowGrid("All");
                txtAssignDis.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;
            }
            else if (xtraTabControl1.SelectedTabPage == pageDistributionWorklist)
            {
                gridControl1.DataSource = null;
                Tab = "Worklist";
                xtraTabControl2.SelectedTabPage = xtabGridDisList;
                deFromDate.DateTime = DateTime.Now;
                deToDate.DateTime = DateTime.Now;
                Populate(1);
                SetGridWorklist();
                btnDistribution.Visible = false;
                btnClearDistribute.Visible = false; ;
                btnDelete.Visible = false;

            }
        }

        #region When hit Enter on S Page

        private void txtAssignSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnSearchS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }


        private void dateEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateEdit2.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void dateEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHnSearch.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void txtHnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectAll("HNS");
                btnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void txtAccessionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectAll("ACS");
                btnSearch_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }
        private void btnClearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        #endregion

        #region When hit Enter on D Page

        private void txtAssignDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchD.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void txtAccessionDis_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                GetAccesionPageDistribute();
            }
        }


        private void txtHnDis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetShowGrid("HN");

                ProcessGetDistributeNew geD = new ProcessGetDistributeNew();
                geD.DistributionNew.selectcase = 21;
                geD.DistributionNew.hn = txtHnDis.Text.Trim();
                geD.Invoke();

                DataSet dsDHN = geD.ResultSet;

                SelectAll("HN");

                grdHNselect.DataSource = dsDHN.Tables[0];
                grdHNMain.DataSource = dsDHN.Tables[0].Clone();

                SetColumnGridHN();

            }
        }
        #endregion

        private void SetShowGrid(string flag)
        {
            if (flag == "All")
            {
                xtraTabControl2.SelectedTabPage = xtabGridAll;
            }
            else if (flag == "HN")
            {
                xtraTabControl2.SelectedTabPage = xtabGridHN;
            }
        }

        #region Drag & Drop
        //private void BindGridDrag()
        //{
        //    grdHNselect.DataSource =
        //    gridControl1.DataSource = dataTable1;
        //    gridControl2.DataSource = dataTable1.Clone();
        //}

        GridHitInfo downHitInfo = null;

        private void View_MouseDown(object sender, MouseEventArgs e)
        {
            GridView View = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = View.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                downHitInfo = hitInfo;
        }

        private void View_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void grid_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grid_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                row.Delete();
            }
        }

        #endregion

        #region Check All
        private void advBandedGridView1_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null) return;
            if (e.Column.Caption == "")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                //DrawCheckBox(e.Graphics, e.Bounds, ItemFlag);
                e.Handled = true;
                Grp = e.Graphics;
                Rta = e.Bounds;

            }
        }

        private void DrawCheckBox(Graphics g, Rectangle r, bool chk)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;

            info = (DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)edit.CreateViewInfo();
            painter = (DevExpress.XtraEditors.Drawing.CheckEditPainter)edit.CreatePainter();
            info.EditValue = chk;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);

            painter.Draw(args);
            args.Cache.Dispose();
        }

        private void advBandedGridView1_Click(object sender, EventArgs e)
        {
            GridHitInfo info;

            Point pt = advBandedGridView1.GridControl.PointToClient(Control.MousePosition);
            info = advBandedGridView1.CalcHitInfo(pt);
            if (info.InColumn)
            {
                if (info.Column == null) return;
                if (info.Column.Caption == "")
                {
                    if (ItemFlag == false)
                    {
                        DataTable dtt = (DataTable)gridControl1.DataSource;
                        dtt.AcceptChanges();
                        for (int z = 0; z < dtt.Rows.Count; z++)
                        {
                            dtt.Rows[z]["All"] = "Y";
                        }
                        dtt.AcceptChanges();
                        gridControl1.DataSource = dtt;
                        ItemFlag = true;
                    }
                    else
                    {
                        DataTable dtt = (DataTable)gridControl1.DataSource;
                        dtt.AcceptChanges();
                        for (int z = 0; z < dtt.Rows.Count; z++)
                        {
                            dtt.Rows[z]["All"] = "N";
                        }
                        dtt.AcceptChanges();
                        gridControl1.DataSource = dtt;
                        ItemFlag = false;
                    }
                }
            }
        }
        #endregion

        #region PopulateGrid

        public void Populate(int sp)
        {

            //CultureInfo culture = new CultureInfo("en-US", true);
            //DateTime _fromdate = Convert.ToDateTime(deFromDate.DateTime,culture);
            //DateTime _todate = Convert.ToDateTime(deToDate.DateTime,culture);
            //DateTime _fromdate = Convert.ToDateTime(dateTimePicker1.Value, culture);
            //DateTime _todate = Convert.ToDateTime(dateTimePicker2.Value, culture);
            try
            {
                ResultEntryWorkList channeldata = new ResultEntryWorkList();
                channeldata.SpType = sp;
                channeldata.FromDate = deFromDate.DateTime;
                channeldata.ToDate = deToDate.DateTime;
                channeldata.OrgID = new GBLEnvVariable().OrgID;
                ProcessGetDistributionChannel prcdist = new ProcessGetDistributionChannel();
                prcdist.ResultEntryWorkList = channeldata;
                prcdist.Invoke();
                DataTable dt = prcdist.ResultSet.Tables[0];

                grdDisWorklist.DataSource = dt;
                //UltraGrid1.Refresh();


                //UltraGrid1.DataSource = dt;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }


            //Radiologist();
        }

        #endregion PopulateGrid

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 1)
            {
                Populate(2);
                SetGridWorklist();
            }
            else
            {
                Populate(3);
                SetGridWorklist();
            }
        }
        private void SetGridWorklist()
        {
            GridChoose = "Work";
            viewDisWorklist.OptionsView.ShowAutoFilterRow = true;

            viewDisWorklist.Columns["PRIORITY"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["HN"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["PATIENT NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["EXAM CODE"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["EXAM NAME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ORDER TIME"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ORDER ID"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ACCESSION NO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            viewDisWorklist.Columns["ASSIGNED TO"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

            viewDisWorklist.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["HN"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["PATIENT NAME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["EXAM CODE"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["EXAM NAME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ORDER TIME"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ORDER ID"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ACCESSION NO"].OptionsColumn.ReadOnly = true;
            viewDisWorklist.Columns["ASSIGNED TO"].OptionsColumn.ReadOnly = false;


            ProcessGetDistributeNew geDis = new ProcessGetDistributeNew();
            geDis.DistributionNew.selectcase = 19;
            geDis.Invoke();
            DataTable dtLv = geDis.ResultSet.Tables[0];


            DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit grdLookup = new RepositoryItemGridLookUpEdit();
            grdLookup.DataSource = dtLv;

            #region SetGrdLookup

            grdLookup.View.OptionsView.ShowAutoFilterRow = true;

            grdLookup.View.Columns["EMP_UID"].Visible = false;
            grdLookup.View.Columns["FULLNAME"].Visible = true;
            grdLookup.View.Columns["EMP_ID"].Visible = false;

            #endregion

            grdLookup.ValueMember = "EMP_ID";
            grdLookup.DisplayMember = "FULLNAME";
            grdLookup.NullText = "";
            grdLookup.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(grdLookup_CloseUp);

            viewDisWorklist.Columns["ASSIGNED TO"].ColumnEdit = grdLookup;

            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imCmb = new RepositoryItemImageComboBox();
            imCmb.SmallImages = this.imgWL;
            imCmb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "R", 6),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "U", 7),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "S", 8)});

            imCmb.Buttons.Clear();

            viewDisWorklist.Columns["PRIORITY"].ColumnEdit = imCmb;
            viewDisWorklist.Columns["PRIORITY"].OptionsColumn.ReadOnly = true;



        }

        private void grdLookup_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            try
            {
                if (e.AcceptValue)
                {


                    DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                    //if (dr["Result Status"].ToString() != "Finalize")
                    //{
                    string _id = msg.ShowAlert("UID4008", env.CurrentLanguageID);
                    if (_id == "3")
                    {
                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["ACCESSION NO"].ToString();
                        upDis.DistributionNew.assignedTo = (int)e.Value;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                    }
                    else if (_id == "2")
                    {
                        ProcessUpdateDistributionNew upDis = new ProcessUpdateDistributionNew();
                        upDis.DistributionNew.accessionno = dr["ACCESSION NO"].ToString();
                        upDis.DistributionNew.assignedTo = 0;//dtGW.Rows[viewDisWorklist.FocusedRowHandle]["ASSIGNED TO"];
                        upDis.DistributionNew.PRIORITY = dr["Priority"].ToString();
                        upDis.DistributionNew.LAST_MODIFIED_BY = env.UserID;
                        upDis.Invoke();
                        e.Value = 0;
                    }
                    else
                    {
                        e.Value = dr["ASSIGNED TO"];
                    }
                    //}
                    //else
                    //{
                    //    e.Value = 0;
                    //}
                }
            }
            catch (Exception ex)
            { }
        }

        private void tsmR_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmR.Image = Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "R";
                    advBandedGridView1.RefreshData();


                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RIS_ORDERDTL.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"]);
                    upPri.RIS_ORDERDTL.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }
            }
            else if (GridChoose == "HN")
            {
                if (viewHNMain.FocusedRowHandle < 0) return;

                tsmR.Image = Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "R";
                viewHNMain.RefreshData();
            }
            else if (GridChoose == "Work")
            {
                if (viewDisWorklist.FocusedRowHandle < 0) return;

                tsmR.Image = Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "R";
                viewDisWorklist.RefreshData();
            }
        }

        private void tsmU_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmU.Image = Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "U";
                    advBandedGridView1.RefreshData();

                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RIS_ORDERDTL.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"]);
                    upPri.RIS_ORDERDTL.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }
            }
            else if (GridChoose == "HN")
            {
                tsmU.Image = Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "U";
                viewHNMain.RefreshData();
            }
            else if (GridChoose == "Work")
            {
                tsmU.Image = Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "U";
                viewDisWorklist.RefreshData();
            }
        }

        private void tsmS_Click(object sender, EventArgs e)
        {
            if (GridChoose == "Main")
            {
                if (advBandedGridView1.FocusedRowHandle < 0) return;

                MyMessageBox msg = new MyMessageBox();
                string strMsg = msg.ShowAlert("UID2123", env.CurrentLanguageID);

                if (strMsg == "2")
                {
                    tsmS.Image = Properties.Resources.QA;
                    DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                    dr["PRIORITY"] = "S";
                    advBandedGridView1.RefreshData();

                    ProcessUpdateRISOrderdtl upPri = new ProcessUpdateRISOrderdtl();
                    upPri.RIS_ORDERDTL.ACCESSION_NO = dr["ACCESSION NO."].ToString();
                    upPri.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"]);
                    upPri.RIS_ORDERDTL.LAST_MODIFIED_BY = env.UserID;
                    upPri.UpdatePriority();
                }
            }
            else if (GridChoose == "HN")
            {
                tsmS.Image = Properties.Resources.QA;
                DataRow dr = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                dr["PRIORITY"] = "S";
                viewHNMain.RefreshData();
            }
            else if (GridChoose == "Work")
            {
                tsmS.Image = Properties.Resources.QA;
                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                dr["PRIORITY"] = "S";
                viewDisWorklist.RefreshData();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (advBandedGridView1.FocusedRowHandle >= 0 || viewDisWorklist.FocusedRowHandle >= 0 || viewHNMain.FocusedRowHandle >= 0)
            {
                string Priority = "";
                DataRow drView = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                DataRow drViewWL = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                DataRow drViewHN = viewHNMain.GetDataRow(viewHNMain.FocusedRowHandle);
                if (drView != null)
                {
                    Priority = drView["PRIORITY"].ToString();
                }
                if (drViewHN != null)
                {
                    Priority = drViewHN["PRIORITY"].ToString();
                }
                if (drViewWL != null)
                {
                    Priority = drViewWL["PRIORITY"].ToString();
                }
                switch (Priority)
                {
                    case "R":
                        tsmS.Image = null;
                        tsmU.Image = null;
                        tsmR.Image = Properties.Resources.QA;
                        break;
                    case "U":
                        tsmS.Image = null;
                        tsmU.Image = Properties.Resources.QA;
                        tsmR.Image = null;
                        break;
                    case "S":
                        tsmS.Image = Properties.Resources.QA;
                        tsmU.Image = null;
                        tsmR.Image = null;
                        break;
                    default:
                        break;
                }
            }
        }
        private void barDistributeCriteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabMain.SelectedTabPage = tabDistribute;
            if (xtraTabControl1.SelectedTabPage != pageDistributeCriteria)
            {
                xtraTabControl1.SelectedTabPage = pageDistributeCriteria;
                gridControl1.DataSource = null;
                Tab = "Dis";
                ClearDis();
                SetShowGrid("All");
                txtAssignDis.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;
            }
        }
        private void barSearchCriteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabMain.SelectedTabPage = tabDistribute;
            if (xtraTabControl1.SelectedTabPage != pageSearchCriteria)
            {
                xtraTabControl1.SelectedTabPage = pageSearchCriteria;
                gridControl1.DataSource = null;
                Tab = "Search";
                ClearSearch();
                SetShowGrid("All");
                txtAssignSearch.Focus();
                btnDistribution.Visible = true;
                btnClearDistribute.Visible = true;
                btnDelete.Visible = true;
            }
        }
        private void barDistributionWorklist_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabMain.SelectedTabPage = tabDistribute;
            if (xtraTabControl1.SelectedTabPage != pageDistributionWorklist)
            {
                xtraTabControl1.SelectedTabPage = pageDistributionWorklist;
                gridControl1.DataSource = null;
                Tab = "Worklist";
                xtraTabControl2.SelectedTabPage = xtabGridDisList;
                deFromDate.DateTime = DateTime.Now;
                deToDate.DateTime = DateTime.Now;
                Populate(1);
                SetGridWorklist();
                btnDistribution.Visible = false;
                btnClearDistribute.Visible = false; ;
                btnDelete.Visible = false;
            }
        }
        private void barTransferLogs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabMain.SelectedTabPage = tabTransfer;
            getTransferData();
        }
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnOrderSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OrderSummaryProcess();
        }
        private void OrderSummaryProcess()
        {
            if (xtraTabControl2.SelectedTabPage == xtabGridAll)
            {

                if (advBandedGridView1.FocusedRowHandle < -1) return;

                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                //Envision.NET.Forms.Technologist.frmPatientData ordimg = new Envision.NET.Forms.Technologist.frmPatientData(dr["Accession No."].ToString());
                //ordimg.Text = "Order Summary";
                //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                //ordimg.StartPosition = FormStartPosition.CenterScreen;
                //ordimg.MaximizeBox = false;
                //ordimg.MinimizeBox = false;
                //ordimg.ShowDialog();
                this._orderSummary.ShowDialog(true, dr["Accession No."].ToString());
            }
            else if (xtraTabControl2.SelectedTabPage == xtabGridDisList)
            {
                if (viewDisWorklist.FocusedRowHandle < -1) return;

                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                //Envision.NET.Forms.Technologist.frmPatientData ordimg = new Envision.NET.Forms.Technologist.frmPatientData(dr["Accession No"].ToString());
                //ordimg.Text = "Order Summary";
                //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                //ordimg.StartPosition = FormStartPosition.CenterScreen;
                //ordimg.MaximizeBox = false;
                //ordimg.MinimizeBox = false;
                //ordimg.ShowDialog();
                this._orderSummary.ShowDialog(true, dr["ACCESSION NO"].ToString());

            }
            else if (xtraTabControl2.SelectedTabPage == xtabGridHN)
            {
                if (viewDisWorklist.FocusedRowHandle < -1) return;

                DataRow dr = viewDisWorklist.GetDataRow(viewDisWorklist.FocusedRowHandle);
                //Envision.NET.Forms.Technologist.frmPatientData ordimg = new Envision.NET.Forms.Technologist.frmPatientData(dr["Accession No."].ToString());
                //ordimg.Text = "Order Summary";
                //ordimg.FormBorderStyle = FormBorderStyle.Sizable;
                //ordimg.StartPosition = FormStartPosition.CenterScreen;
                //ordimg.MaximizeBox = false;
                //ordimg.MinimizeBox = false;
                //ordimg.ShowDialog();
                this._orderSummary.ShowDialog(true, dr["Accession No."].ToString());

            }
        }

        private void orderSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSummaryProcess();
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == gridControl1)
                {
                    GridView view = gridControl1.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "PATIENT_ID_LABEL":
                                    if (!string.IsNullOrEmpty(rowDetail["PATIENT_ID_LABEL"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["PATIENT_ID_DETAIL"].ToString());
                                        return;
                                    }
                                    break;
                                case "READER":
                                    if (!string.IsNullOrEmpty(rowDetail["READER"].ToString()))
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["READER"].ToString());
                                        return;
                                    }
                                    break;
                                case "SCANIMAGES":
                                    if (rowDetail["SCANIMAGES"].ToString() == "0")
                                    {
                                        info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), "No document.");
                                        return;
                                    }
                                    break;
                                case "FLAG_ICON":
                                    if (!string.IsNullOrEmpty(rowDetail["FLAG_ICON"].ToString()))
                                        if (rowDetail["FLAG_ICON"].ToString() != "0")
                                        {
                                            info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), rowDetail["FLAG_DESC"].ToString());
                                            return;
                                        }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.GroupPanel)
                    {
                        info = new ToolTipControlInfo(hi.HitTest, "Group panel");
                        return;
                    }

                    if (hi.HitTest == GridHitTest.RowIndicator)
                    {
                        info = new ToolTipControlInfo(GridHitTest.RowIndicator.ToString() + hi.RowHandle.ToString(), "Row Handle: " + hi.RowHandle.ToString());
                        return;
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "SCANIMAGES": info = new ToolTipControlInfo(hi.HitTest, "Document"); break;
                            case "READER": info = new ToolTipControlInfo(hi.HitTest, "Comments"); break;
                            case "PATIENT_ID_LABEL": info = new ToolTipControlInfo(hi.HitTest, "Patient Detail"); break;
                            case "FLAG_ICON": info = new ToolTipControlInfo(hi.HitTest, "Exam Flag"); break;
                            default: info = new ToolTipControlInfo(hi.HitTest, hi.Column.Caption); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }

        #region Transfer Logs
        private void btnGoTransfer_Click(object sender, EventArgs e)
        {
            getTransferData();
        }
        private void txtAccessionNoTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getTransferData();
        }
        private void txtHNTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                getTransferData();
        }
        private void getTransferData()
        {
            grdTransfer.DataSource = null;
            viewTransfer.Columns.Clear();
            if (tabSearchTransfer.SelectedTabPage == pageAccessionTransfer)
            {
                ProcessGetRISExamtransferlog data = new ProcessGetRISExamtransferlog();
                data.RIS_EXAMTRANSFERLOG.ACCESSION_NO = txtAccessionNoTransfer.Text.Trim();
                grdTransfer.DataSource = data.getTransferByAccession();

                txtAccessionNoTransfer.SelectionStart = 0;
                txtAccessionNoTransfer.SelectionLength = txtAccessionNoTransfer.Text.Length;
                txtAccessionNoTransfer.Focus();
            }
            else
            {
                ProcessGetRISExamtransferlog data = new ProcessGetRISExamtransferlog();
                data.RIS_EXAMTRANSFERLOG.HN = txtHNTransfer.Text.Trim();
                grdTransfer.DataSource = data.getTransferByHN();

                txtHNTransfer.SelectionStart = 0;
                txtHNTransfer.SelectionLength = txtAccessionNoTransfer.Text.Length;
                txtHNTransfer.Focus();
            }
        }
        #endregion

    }
}