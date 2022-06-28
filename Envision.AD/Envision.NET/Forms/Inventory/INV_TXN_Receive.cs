using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Operational;
using Envision.Common;
using System.Data.SqlClient;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace Envision.NET.Forms.Inventory
{
    public partial class INV_TXN_Receive : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private InventoryManagement inv = new InventoryManagement();
        private MyMessageBox msb = new MyMessageBox();
        private int _poid, _prid;
        private GuiMode _mode;
        List<string> listVendor = new List<string>();

        DataSet dsMaster;
        DataSet dsDetail;
        DataSet dsUnion;
        DataRow drGridDetail;
        DataTable dttItem;
        GridView gv;
        string GridLocation = "";

        public INV_TXN_Receive()
        {
            InitializeComponent();
        }
        private void INV_TXN_Receive_Load(object sender, EventArgs e)
        {
            FillAllData();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            base.CloseWaitDialog();
        }
        private void FillAllData()
        {
            gv = new GridView();
            DataSet ds = inv.PO.SelectForRecieve().Copy();
            grdPOData.DataSource = ds.Tables[0];
            grdFilterPO.DataSource = ds.Tables[0];
            grdFilterPO.Focus();

            ProcessGetInvItem prc = new ProcessGetInvItem();
            prc.Invoke();
            dttItem = prc.ResultTable;

            DataTable dtVendor = new DataTable();
            ProcessGetInvVendor prcVendor = new ProcessGetInvVendor();
            prcVendor.Invoke();
            dtVendor = prcVendor.ResultTable;
            listVendor.Clear();
            cmbVendor.Properties.Items.Clear();
            foreach (DataRow dr in dtVendor.Rows)
            {
                listVendor.Add(dr["VENDOR_ID"].ToString());
                cmbVendor.Properties.Items.Add(dr["VENDOR_UID"].ToString() + ":" + dr["VENDOR_NAME"].ToString());
            }
            cmbVendor.SelectedIndex = 0;
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["PO_ID"].ToString()));
            }
            catch { }
        }

        private void advBandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["PO_ID"].ToString()));
            }
        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["PO_ID"].ToString()));
        }

        private void layoutView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["PO_ID"].ToString()));
            }
        }
        private void FillDetailData(int PO_ID)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            inv.PO.SelectPO(PO_ID);

            dsMaster = inv.InventoryStock.GetPOMaster(PO_ID).Copy();
            dsMaster.Tables[0].TableName = "Master";
            dsDetail = inv.InventoryStock.GetPODetail(PO_ID).Copy();
            dsDetail.Tables[0].TableName = "Detail";
            dsUnion = new DataSet();
            dsUnion.Tables.Add(dsMaster.Tables[0].Copy());
            dsUnion.Tables.Add(dsDetail.Tables[0].Copy());
            dsUnion.AcceptChanges();


            DataColumn keyColumn = dsUnion.Tables[0].Columns["ITEM_ID"];
            DataColumn foreignKeyColumn = dsUnion.Tables[1].Columns["REF_ITEM_ID"];
            dsUnion.Relations.Add("ItemRecieve", keyColumn, foreignKeyColumn);


            //dsUnion.Relations.Add(dsUnion.Tables[0].Columns["ITEM_ID"], dsUnion.Tables[1].Columns["ITEM_ID"]);

            _poid = PO_ID;
            txtPO_UID.Text = inv.PO.PO_Data.PO_UID;
            txGenerateBy.Text = inv.PO.PO_Data.GENERATED_BY_TEXT;

            cmbVendor.SelectedIndex = listVendor.IndexOf(inv.PO.PO_Data.VENDOR_ID.ToString());
            cmbVendor.Properties.ReadOnly = true;
            try
            {
                txtGenerateOn.Text = inv.PO.PO_Data.GENERATED_ON.Value.ToLongDateString() + " " + inv.PO.PO_Data.GENERATED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }

            txtStatus.Text = inv.PO.PO_Data.STATUS;
            txtPR_UID.Text = inv.PO.PO_Data.PR_UID;
            if (inv.PO.PO_Data.PO_STATUS.ToString() == "F" || inv.PO.PO_Data.PO_STATUS.ToString() == "C")
            {
                if (inv.PO.PO_Data.PO_STATUS.ToString() == "F")
                {
                    chkForceCompleted.Checked = true;
                }
                chkForceCompleted.Properties.ReadOnly = true;
            }
            else
            {
                chkForceCompleted.Properties.ReadOnly = false;
            }

            grdPO_Detail.DataSource = dsUnion.Tables[0];
            grdPO_Detail.ForceInitialize();

            //gridView1.BestFitColumns();
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView(grdPO_Detail);
            //// gridView gridView1 = new CardView(gridControl1);
            grdPO_Detail.LevelTree.Nodes.Add("ItemRecieve", gridView1);

            //Hide the CategoryID column for the master view
            grdvPodetail.Columns["ITEM_ID"].VisibleIndex = -1;
            ////Create columns for the pattern view
            gridView1.PopulateColumns(dsUnion.Tables["Detail"]);
            ////Hide the CategoryID column for the pattern view

            gridView1.Columns["TXNDTL_ID"].VisibleIndex = -1;
            gridView1.Columns["ITEM_ID"].VisibleIndex = -1;
            gridView1.Columns["REF_ITEM_ID"].VisibleIndex = -1;
            gridView1.Columns["ITEM_UID"].VisibleIndex = -1;
            gridView1.Columns["TXN_UNIT_ID"].VisibleIndex = -1;
            //gridView1.Columns["TXN_UNIT_NAME"].VisibleIndex = -1;

            gridView1.Columns["ITEM_UID"].Caption = "Item Code";
            gridView1.Columns["ITEM_NAME"].Caption = "Item Name";
            gridView1.Columns["TXN_UNIT_NAME"].Caption = "Item Unit";
            gridView1.Columns["RECIEVE_SUCCESS"].Caption = "Quantity";
            gridView1.Columns["EXPIRY_DT"].Caption = "Expire";
            gridView1.Columns["BATCH"].Caption = "Batch";
            gridView1.Columns["PRICE"].Caption = "Price";
            gridView1.Columns["COMMENTS"].Caption = "Comment";
            gridView1.Columns["ITEM_RECIEVE_STATUS"].Caption = "Status";

            gridView1.Columns["ITEM_NAME"].Width = 150;

            gridView1.Columns["RECIEVE_SUCCESS"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["RECIEVE_SUCCESS"].DisplayFormat.FormatString = "#,##0";
            gridView1.Columns["PRICE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["PRICE"].DisplayFormat.FormatString = "#,##0.00";

            gridView1.Columns["BATCH"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["ITEM_RECIEVE_STATUS"].OptionsColumn.ReadOnly = true;
            //gridView1.Columns["TXN_UNIT_NAME"].OptionsColumn.ReadOnly = true;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit2 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit2.ImmediatePopup = true;
            repositoryItemLookUpEdit2.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit2.AutoHeight = false;
            repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ITEM_NAME", "Item Name", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit2.DisplayMember = "ITEM_NAME";
            repositoryItemLookUpEdit2.ValueMember = "ITEM_NAME";
            repositoryItemLookUpEdit2.DropDownRows = 5;
            repositoryItemLookUpEdit2.DataSource = dttItem;
            repositoryItemLookUpEdit2.NullText = string.Empty;
            repositoryItemLookUpEdit2.KeyUp += new KeyEventHandler(itemName_KeyUp);
            repositoryItemLookUpEdit2.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(itemName_CloseUp);
            gridView1.Columns["ITEM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            gridView1.Columns["ITEM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;

            gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
            gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(gridView1_FocusedColumnChanged);
            gridView1.Click += new EventHandler(gridView1_Click);
            gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanging);
            gridView1.GotFocus += new EventHandler(gridView1_GotFocus);
            gridView1.LostFocus += new EventHandler(gridView1_LostFocus);
            gridView1.RowCellStyle += new RowCellStyleEventHandler(gridView1_RowCellStyle);
            setForm(GuiMode.Edit);
        }
        void itemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //if (view1.FocusedColumn.VisibleIndex != view1.VisibleColumns.Count - 1)
                //    view1.FocusedColumn = view1.VisibleColumns[view1.FocusedColumn.VisibleIndex + 1];
                //else
                //{
                //    view1.FocusedColumn = view1.VisibleColumns[0];
                //    view1.MoveNext();
                //}
            }
        }
        void itemName_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            //if (e.AcceptValue)
            //{
            //    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //    int row = gridView1.FocusedRowHandle;
            //    if (e.Value != null)
            //    {
            //        if (e.Value.ToString() != string.Empty)
            //        {
            //            bool flag = updateItemName(e.Value.ToString());
            //        }
            //    }
            //}
        }
        private bool updateItemName(string strSearch)
        {
            DataRow[] drItem = dttItem.Select("ITEM_NAME = '" + strSearch + "'");

            if (drGridDetail == null)
                return false;
            if (drItem.Length > 0)
            {
                drGridDetail["ITEM_ID"] = drItem[0]["ITEM_ID"];
                drGridDetail["ITEM_UID"] = drItem[0]["ITEM_UID"];
                drGridDetail["ITEM_NAME"] = drItem[0]["ITEM_NAME"];
                drGridDetail["TXN_UNIT_NAME"] = drItem[0]["TXN_UNIT_NAME"].ToString();
                drGridDetail["TXN_UNIT_ID"] = drItem[0]["TXN_UNIT_ID"];
                drGridDetail.AcceptChanges();
                return true;
            }
            else
                return false;
            //return true;
        }
        private void FillDetailData(int PO_ID, int PR_ID)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            inv.PO.SelectPO(PO_ID);
            inv.PR.SelectPR(PR_ID);
            _poid = PO_ID;
            txtPO_UID.Text = inv.PO.PO_Data.PO_UID;
            txGenerateBy.Text = inv.PO.PO_Data.GENERATED_BY_TEXT;
            try
            {
                txtGenerateOn.Text = inv.PO.PO_Data.GENERATED_ON.Value.ToLongDateString() + " " + inv.PO.PO_Data.GENERATED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }
            txtStatus.Text = inv.PO.PO_Data.STATUS;
            txtPR_UID.Text = inv.PO.PO_Data.PR_UID;

            foreach (DataRow drItem in inv.PR.PRDTL_InsertUpdate.Tables[0].Rows)
            {
                inv.PO.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(drItem["QTY"].ToString()), 0, new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
            }

            grdPO_Detail.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];

            setForm(GuiMode.Edit);
        }
        private void btnColDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = grdvPodetail.GetDataRow(grdvPodetail.FocusedRowHandle);
            DataRow[] drDel = inv.PO.PODTL_dsDelete.Tables[0].Select("PO_ID = " + dr["PO_ID"].ToString() + "AND ITEM_ID = " + dr["ITEM_ID"].ToString());
            if (dr["PO_ID"].ToString() == "0")
            {
                inv.PO.PODTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
            }
            else
            {
                inv.PO.dsDeleteAdd(dr);
                inv.PO.PODTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
            }
        }

        private void btnGridbtnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        private void AddItem()
        {
            try
            {
                //INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
                //delForm.ShowDialog();
                //if (delForm.DialogResult == DialogResult.OK)
                //{
                //    DataRow drItem = grdvItem.GetDataRow(grdvItem.FocusedRowHandle);
                //    DataRow[] dr = inv.PO.PODTL_InsertUpdate.Tables[0].Select("ITEM_ID = " + drItem["ITEM_ID"].ToString());
                //    if (dr.Length > 0)
                //    {
                //        dr[0]["QTY"] = Convert.ToDecimal(dr[0]["QTY"].ToString()) + Convert.ToDecimal(delForm.ResultValue);
                //        inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
                //    }
                //    else
                //    {
                //        inv.PO.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(delForm.ResultValue), 0, new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                //        inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
                //        grdPO_Detail.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];
                //    }
                //}
                //else
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillDetailData(0);
            setForm(GuiMode.Add);
            _prid = 0;
        }
        private void setForm(GuiMode Mode)
        {
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:


                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribBack.Visible = true;
                    btnribbonAdd.Visible = true;
                    btnribSavePrint.Visible = false;
                    btnribPrint.Visible = true;
                    btnribbonFromPR.Visible = true;

                    cmbVendor.Properties.ReadOnly = true;

                    txtPO_UID.Properties.ReadOnly = true; ;
                    break;
                case GuiMode.Add:
                    txtPO_UID.Properties.ReadOnly = false;
                    txtPO_UID.Text = "Auto";
                    txtStatus.Text = "New";
                    txGenerateBy.Text = "Waiting...";
                    txtGenerateOn.Text = "Waiting...";

                    grpPRdetail.GroupBordersVisible = true;
                    grpPRdetail.Expanded = true;

                    txtPO_UID.Properties.ReadOnly = false;
                    cmbVendor.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribBack.Visible = false;
                    btnribDelete.Visible = false;
                    btnribSavePrint.Visible = true;
                    btnribPrint.Visible = false;
                    btnribbonFromPR.Visible = false;
                    break;
                case GuiMode.Edit:
                    if (inv.PO.PO_Data.PO_STATUS == 'F' || inv.PO.PO_Data.PO_STATUS == 'C')
                    {
                        btnribbonSave.Visible = false;
                        btnribbonCancel.Visible = true;
                        btnribbonAdd.Visible = false;
                        btnribbonUpdate.Visible = false;
                        btnribBack.Visible = true;
                        btnribDelete.Visible = false;
                        btnribSavePrint.Visible = false;
                        btnribPrint.Visible = false;
                        btnribbonFromPR.Visible = false;

                        cmbVendor.Properties.ReadOnly = true;
                    }
                    else
                    {
                        if (inv.PO.PO_Data.PO_STATUS == 'R')
                        {
                            btnribbonSave.Visible = true;
                            btnribbonCancel.Visible = true;
                            btnribbonAdd.Visible = false;
                            btnribbonUpdate.Visible = false;
                            btnribBack.Visible = true;
                            btnribDelete.Visible = false;
                            btnribSavePrint.Visible = false;
                            btnribPrint.Visible = false;
                            btnribbonFromPR.Visible = false;

                            cmbVendor.Properties.ReadOnly = true;
                        }
                        else
                        {
                            btnribbonSave.Visible = true;
                            btnribbonCancel.Visible = false;
                            btnribbonAdd.Visible = false;
                            btnribbonUpdate.Visible = false;
                            btnribBack.Visible = true;
                            btnribDelete.Visible = false;
                            btnribSavePrint.Visible = false;
                            btnribPrint.Visible = false;
                            btnribbonFromPR.Visible = false;

                            cmbVendor.Properties.ReadOnly = false;
                        }
                    }
                    break;
                case GuiMode.Remove:
                    break;
                default:
                    break;
            }
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setForm(GuiMode.Edit);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msg.ShowAlert("UID5006", env.CurrentLanguageID) == "2")
            {
                if (inv.PO.PO_Data.PO_ID > 0)
                {
                    inv.ItemTransation.INVTransaction.PO_ID = inv.PO.PO_Data.PO_ID;
                    inv.ItemTransation.INVTransaction.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.ItemTransation.InsertTransactionPOCancel();
                    FillAllData();
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    setForm(GuiMode.Normal);
                }
                else
                {
                    xtraTabControl1.SelectedTabPageIndex = 0;
                    setForm(GuiMode.Normal);
                }
            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msg.ShowAlert("UID5005", env.CurrentLanguageID) == "2")
            {
                decimal sum = 0;

                inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.R.ToString());
                inv.ItemTransation.INVTransaction.REQUISITION_ID = 0;
                inv.ItemTransation.INVTransaction.PO_ID = inv.PO.PO_Data.PO_ID;
                inv.ItemTransation.INVTransaction.FROM_UNIT = 23;
                inv.ItemTransation.INVTransaction.TO_UNIT = 23;
                inv.ItemTransation.INVTransaction.COMMENTS = "Test";
                inv.ItemTransation.INVTransaction.ORG_ID = 1;
                inv.ItemTransation.INVTransaction.CREATED_BY = new GBLEnvVariable().UserID;
                inv.ItemTransation.INVTransaction.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;

                if (chkForceCompleted.Checked == true)
                {
                    inv.ItemTransation.INVTransaction.STATUS = Envision.Common.Status.F.ToString();
                }
                else
                {
                    foreach (DataRow dr in dsUnion.Tables[0].Rows)
                    {
                        //ITEMS_RECIEVE_REQ
                        DataRow[] drchkDetail = dsUnion.Tables[1].Select("REF_ITEM_ID = " + dr["ITEM_ID"].ToString());
                        for (int i = 0; i < drchkDetail.Length; i++)
                        {
                            if (Convert.ToDouble(drchkDetail[i]["RECIEVE_SUCCESS"].ToString()) > 0)
                            {
                                if (drchkDetail[i]["EXPIRY_DT"].ToString() != "")
                                {
                                    sum = sum + Convert.ToDecimal(drchkDetail[i]["RECIEVE_SUCCESS"].ToString());
                                }

                            }
                        }
                        if (sum >= Convert.ToDecimal(dr["QTY"].ToString()))
                        {
                            inv.ItemTransation.INVTransaction.STATUS = Envision.Common.Status.C.ToString();
                        }
                        else
                        {
                            inv.ItemTransation.INVTransaction.STATUS = Envision.Common.Status.R.ToString();
                            break;
                        }
                        sum = 0;
                    }
                }

                foreach (DataRow dr in dsUnion.Tables[1].Rows)
                {
                    if (dr["ITEM_RECIEVE_STATUS"].ToString() != "Complete")
                    {
                        if (Convert.ToDouble(dr["RECIEVE_SUCCESS"].ToString()) > 0)
                        {
                            if (dr["EXPIRY_DT"].ToString() != "")
                            {

                                inv.ItemTransation.AddTransactionDtl(Convert.ToInt32(dr["ITEM_ID"].ToString()), Convert.ToInt32(dr["REF_ITEM_ID"].ToString()), Convert.ToInt32(dr["TXN_UNIT_ID"].ToString()), dr["BATCH"].ToString(), Convert.ToDateTime(dr["EXPIRY_DT"].ToString())
                                , Convert.ToDouble(dr["RECIEVE_SUCCESS"].ToString()), Convert.ToDouble(dr["PRICE"].ToString()), dr["COMMENTS"].ToString(), 0);
                            }
                        }
                    }
                }
                if (inv.ItemTransation.InsertTransaction())
                {

                }

                FillAllData();
                xtraTabControl1.SelectedTabPageIndex = 0;
                setForm(GuiMode.Normal);
            }
        }

        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //inv.PO.poManagement(DataManageType.Delete);
            //FillAllData();
            //xtraTabControl1.SelectedTabPageIndex = 0;
            //setForm(GuiMode.Normal);
            DataSet ds = dsUnion.Copy();
            //gridView1.Columns[1].Visible = false;
            //gridView1.Columns[2].Visible = false;
        }

        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grdvItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                AddItem();
            }
        }


        private void grdvPodetail_HiddenEditor(object sender, EventArgs e)
        {
            //DataTable dtt = (DataTable)grdPO_Detail.DataSource;
            //foreach (DataRow dr in dtt.Rows)
            //{
            //    dr["TOTAL_PRICE"] = Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["UNITPRICE"].ToString());
            //}

        }

        private void grdvItem_DoubleClick(object sender, EventArgs e)
        {
            AddItem();
        }

        private void grdvPodetail_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int i = e.RowHandle;

            gv = (GridView)(sender);
            DataRow drd = gv.GetDataRow(i);
            foreach (DataRow dr in dsUnion.Tables[1].Rows)
            {
                if (dr["ITEM_RECIEVE_STATUS"].ToString() == "Complete")
                {
                    DataRow[] drDetail = dsDetail.Tables[0].Select("TXNDTL_ID = " + dr["TXNDTL_ID"].ToString());
                    dr.ItemArray = drDetail[0].ItemArray;
                }
            }
            drGridDetail = gv.GetDataRow(i);
            int row = gridView1.FocusedRowHandle;
            if (e.Value != null)
            {
                if (e.Value.ToString() != string.Empty)
                {
                    bool flag = updateItemName(e.Value.ToString());
                }
            }
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void toolsAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = dsUnion.Tables[1].NewRow();
            DataRow drHandle = null;
            if (GridLocation == "Master")
            {
                drHandle = grdvPodetail.GetDataRow(grdvPodetail.FocusedRowHandle);
            }
            else if (GridLocation == "Detail")
            {
                drHandle = gv.GetDataRow(gv.FocusedRowHandle);
            }
            DataRow[] drDetail = dsDetail.Tables[0].Select("ITEM_ID =" + drHandle["ITEM_ID"].ToString());
            DataRow[] drMaster = dsMaster.Tables[0].Select("ITEM_ID =" + drHandle["ITEM_ID"].ToString());
            DataRow[] drUnion = dsUnion.Tables[1].Select("ITEM_ID =" + drHandle["ITEM_ID"].ToString());

            dr.ItemArray = drDetail[0].ItemArray;
            dr["TXNDTL_ID"] = DBNull.Value;
            dr["ITEM_ID"] = drMaster[0]["ITEM_ID"];
            dr["ITEM_UID"] = drMaster[0]["ITEM_UID"];
            dr["ITEM_NAME"] = drMaster[0]["ITEM_NAME"];
            dr["EXPIRY_DT"] = DBNull.Value;
            dr["BATCH"] = drUnion.Length + 1;//Convert.ToInt32(drMaster[0]["BATCH"].ToString()) + 1;
            dr["PRICE"] = 0;
            dr["RECIEVE_SUCCESS"] = 0;

            dr["ITEM_RECIEVE_STATUS"] = "Loading";

            dsUnion.Tables[1].Rows.Add(dr);
            dsUnion.AcceptChanges();
        }

        private void grdvPodetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GridLocation = "Master";
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            DataRow drHandle = null;
            if (GridLocation == "Master")
            {
                drHandle = grdvPodetail.GetDataRow(grdvPodetail.FocusedRowHandle);
            }
            else if (GridLocation == "Detail")
            {
                drHandle = gv.GetDataRow(gv.FocusedRowHandle);
            }
            DataRow[] drUnion = dsUnion.Tables[1].Select("ITEM_ID =" + drHandle["ITEM_ID"].ToString());
            if (drUnion[drUnion.Length - 1]["ITEM_RECIEVE_STATUS"].ToString() != "Complete")
            {
                drUnion[drUnion.Length - 1].Delete();
                dsUnion.AcceptChanges();
            }
        }

        private void menuWL_Opening(object sender, CancelEventArgs e)
        {
            DataRow drHandle = null;
            if (GridLocation == "Master")
            {
                drHandle = grdvPodetail.GetDataRow(grdvPodetail.FocusedRowHandle);
                if (Convert.ToDecimal(drHandle["ITEMS_RECIEVE_REQ"].ToString()) == 0)
                {
                    toolsAdd.Enabled = false;
                    toolDelete.Enabled = false;
                }
                else
                {
                    toolsAdd.Enabled = true;
                    toolDelete.Enabled = true;
                }
            }
            else if (GridLocation == "Detail")
            {
                toolsAdd.Enabled = false;
                toolDelete.Enabled = false;
            }
        }

        private void grdvPodetail_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = grdvPodetail.GetDataRow(e.RowHandle);
                if (Convert.ToDecimal(dr["ITEMS_RECIEVE_REQ"].ToString()) == 0)
                {
                    e.Appearance.BackColor = Color.Pink;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            GridLocation = "Detail";
        }

        private void gridView1_LostFocus(object sender, EventArgs e)
        {
            GridLocation = "Master";
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.Caption == "Item Name")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (e.Column.Caption == "Quantity")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (e.Column.Caption == "Expire")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (e.Column.Caption == "Price")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (e.Column.Caption == "Comment")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillAllData();
        }
    }
}