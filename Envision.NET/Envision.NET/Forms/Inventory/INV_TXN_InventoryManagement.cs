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
    public partial class INV_TXN_InventoryManagement : Envision.NET.Forms.Main.MasterForm
    {
        private InventoryManagement inv = new InventoryManagement();
        private MyMessageBox msb = new MyMessageBox();
        private int _poid,_prid;
        private GuiMode _mode;
        List<string> listVendor = new List<string>();

        DataSet dsMaster;
        DataSet dsDetail;
        DataSet dsUnion;
        DataRow drGridDetail;
        DataTable dttItem;
        GridView gv;
        string GridLocation = "Master";
        List<string> listUnit = new List<string>();

        public INV_TXN_InventoryManagement()
        {
            InitializeComponent();
        }
        private void FillGridView()
        {
            dsMaster = inv.InventoryStock.GetItemStockMaster(Convert.ToInt32(listUnit[cmbUnit.SelectedIndex])).Copy();
            dsMaster.Tables[0].TableName = "Master";
            dsDetail = inv.InventoryStock.GetItemStockDetail(Convert.ToInt32(listUnit[cmbUnit.SelectedIndex])).Copy();
            dsDetail.Tables[0].TableName = "Detail";
            dsUnion = new DataSet();
            dsUnion.Tables.Add(dsMaster.Tables[0].Copy());
            dsUnion.Tables.Add(dsDetail.Tables[0].Copy());
            dsUnion.AcceptChanges();

            DataColumn keyColumn = dsUnion.Tables[0].Columns["ITEM_ID"];
            DataColumn foreignKeyColumn = dsUnion.Tables[1].Columns["ITEM_ID"];
            dsUnion.Relations.Add("ItemRecieve", keyColumn, foreignKeyColumn);

            grdStock.DataSource = dsUnion.Tables[0];
            grdStock.ForceInitialize();

            //grdvDetail.BestFitColumns();
            DevExpress.XtraGrid.Views.Grid.GridView grdvDetail = new DevExpress.XtraGrid.Views.Grid.GridView(grdStock);
            //// gridView gridView1 = new CardView(gridControl1);
            grdStock.LevelTree.Nodes.Add("ItemRecieve", grdvDetail);

            //Hide the CategoryID column for the master view
            //grdvMaster.Columns["ITEM_ID"].VisibleIndex = -1;
            ////Create columns for the pattern view
            grdvDetail.PopulateColumns(dsUnion.Tables["Detail"]);
            ////Hide the CategoryID column for the pattern view

            //grdvDetail.Columns["TXNDTL_ID"].VisibleIndex = -1;
            grdvDetail.Columns["ITEM_ID"].VisibleIndex = -1;
            grdvDetail.Columns["ITEM_NAME"].VisibleIndex = -1;
            grdvDetail.Columns["ITEM_STOCK_ID"].VisibleIndex = -1;
            grdvDetail.Columns["UNIT_ID"].VisibleIndex = -1;
            grdvDetail.Columns["TXN_UNIT_ID"].VisibleIndex = -1;

            grdvDetail.Columns["TXN_UNIT_NAME"].Caption = "Item Unit";
            grdvDetail.Columns["CREATED_ON"].Caption = "Recieve Date";
            grdvDetail.Columns["QTY"].Caption = "Quantity";
            grdvDetail.Columns["EXPIRY_DT"].Caption = "Expire";
            grdvDetail.Columns["BATCH"].Caption = "Batch";
            grdvDetail.Columns["PRICE"].Caption = "Price";

            //grdvDetail.Columns["ITEM_NAME"].Width = 150;

            grdvDetail.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdvDetail.Columns["QTY"].DisplayFormat.FormatString = "#,##0";
            grdvDetail.Columns["PRICE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdvDetail.Columns["PRICE"].DisplayFormat.FormatString = "#,##0.00";

            grdvDetail.Columns["BATCH"].OptionsColumn.ReadOnly = true;
            grdvDetail.Columns["QTY"].OptionsColumn.ReadOnly = true;
            grdvDetail.Columns["TXN_UNIT_NAME"].OptionsColumn.ReadOnly = true;


            grdvDetail.OptionsView.ColumnAutoWidth = false;
            grdvDetail.OptionsView.ShowGroupPanel = false;

            grdvDetail.GotFocus += new EventHandler(grdvDetail_GotFocus);
            grdvDetail.LostFocus += new EventHandler(grdvDetail_LostFocus);
            grdvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);

            setForm(GuiMode.Edit);
          
        }
        private void FillAllData()
        {
            DataTable dtUnit = new DataTable();
            ProcessGetInvUnit prcUnit = new ProcessGetInvUnit();
            prcUnit.Invoke();
            dtUnit = prcUnit.ResultTable;
            listUnit.Clear();
            cmbUnit.Properties.Items.Clear();
            
            foreach (DataRow dr in dtUnit.Rows)
            {
                listUnit.Add(dr["UNIT_ID"].ToString());
                cmbUnit.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
            }
            cmbUnit.SelectedIndex = 0;
            FillGridView();
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void advBandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
               
            }
        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void layoutView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {

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

            grdStock.DataSource = dsUnion.Tables[0];
            grdStock.ForceInitialize();

            //grdvDetail.BestFitColumns();
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView(grdStock);
           //// gridView gridView1 = new CardView(gridControl1);
            grdStock.LevelTree.Nodes.Add("ItemRecieve", gridView1);

            //Hide the CategoryID column for the master view
            grdvMaster.Columns["ITEM_ID"].VisibleIndex = -1;
            ////Create columns for the pattern view
            grdvDetail.PopulateColumns(dsUnion.Tables["Detail"]);
            ////Hide the CategoryID column for the pattern view

            grdvDetail.Columns["ITEM_STOCK_ID"].VisibleIndex = -1;
            grdvDetail.Columns["ITEM_ID"].VisibleIndex = -1;
            grdvDetail.Columns["UNIT_ID"].VisibleIndex = -1;
            grdvDetail.Columns["ITEM_NAME"].VisibleIndex = -1;
            
            //grdvDetail.Columns["ITEM_UID"].Caption = "Item Code";
            //grdvDetail.Columns["ITEM_NAME"].Caption = "Item Name";
           // grdvDetail.Columns["TXN_UNIT_NAME"].Caption = "Item Unit";
            grdvDetail.Columns["QTY"].Caption = "Quantity";
            grdvDetail.Columns["EXPIRY_DT"].Caption = "Expire";
            grdvDetail.Columns["BATCH"].Caption = "Batch";
            grdvDetail.Columns["PRICE"].Caption = "Price";
            //grdvDetail.Columns["COMMENTS"].Caption = "Comment";
           // grdvDetail.Columns["ITEM_RECIEVE_STATUS"].Caption = "Status";

           // grdvDetail.Columns["ITEM_NAME"].Width = 150;

            grdvDetail.Columns["QTY"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdvDetail.Columns["QTY"].DisplayFormat.FormatString = "#,##0";
            grdvDetail.Columns["PRICE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdvDetail.Columns["PRICE"].DisplayFormat.FormatString = "#,##0.00";

            grdvDetail.Columns["BATCH"].OptionsColumn.ReadOnly = true;
            grdvDetail.Columns["ITEM_RECIEVE_STATUS"].OptionsColumn.ReadOnly = true;
            grdvDetail.Columns["TXN_UNIT_NAME"].OptionsColumn.ReadOnly = true;

            

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
            grdvDetail.Columns["ITEM_NAME"].ColumnEdit = repositoryItemLookUpEdit2;
            grdvDetail.Columns["ITEM_NAME"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


            grdvDetail.OptionsView.ColumnAutoWidth = false;
            grdvDetail.OptionsView.ShowGroupPanel = false;
            grdvDetail.OptionsBehavior.Editable = false;

            grdvDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
            grdvDetail.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);

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
            if (e.AcceptValue)
            {
                DataRow dr = grdvDetail.GetDataRow(grdvDetail.FocusedRowHandle);
                int row = grdvDetail.FocusedRowHandle;
                if (e.Value != null)
                {
                    if (e.Value.ToString() != string.Empty)
                    {
                        bool flag = updateItemName(e.Value.ToString());
                    }
                }
            }
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
                drGridDetail["TXN_UNIT_NAME"] = drItem[0]["TXN_UNIT_NAME"];
                return true;
            }
            else
                return false;
            //return true;
        }
        private void FillDetailData(int PO_ID,int PR_ID)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            inv.PO.SelectPO(PO_ID);
            inv.PR.SelectPR(PR_ID);
            _poid = PO_ID;
         
            setForm(GuiMode.Edit);
        }
        private void btnColDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = grdvMaster.GetDataRow(grdvMaster.FocusedRowHandle);
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

                    break;
                case GuiMode.Add:

                    break;
                case GuiMode.Edit:


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

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
          
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
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
            //grdvDetail.Columns[1].Visible = false;
            //grdvDetail.Columns[2].Visible = false;
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
            foreach (DataRow dr in dsUnion.Tables[1].Rows)
            {
                if (dr["ITEM_RECIEVE_STATUS"].ToString() == "Complete")
                {
                    DataRow[] drDetail = dsDetail.Tables[0].Select("TXNDTL_ID = " + dr["TXNDTL_ID"].ToString());
                    dr.ItemArray = drDetail[0].ItemArray;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int i = e.FocusedRowHandle;
                gv = (GridView)(sender);
                string strqty = gv.FocusedColumn.FieldName;
                if (gv.FocusedRowHandle > -1)
                {
                    drGridDetail = gv.GetDataRow(gv.FocusedRowHandle);
                }
            }
            catch { }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {

           DataRow drHandle = gv.GetDataRow(gv.FocusedRowHandle);
           INV_Delete_Lookup lk = new INV_Delete_Lookup(drHandle,dsDetail.Tables[0].Copy());
           if (lk.ShowDialog() == DialogResult.OK)
           {
               FillGridView();
           }
        }

        private void menuWL_Opening(object sender, CancelEventArgs e)
        {
            if (GridLocation == "Master")
            {
                toolDelete.Enabled = false;
            }
            else
            {
                toolDelete.Enabled = true;
            }
        }

        private void grdvMaster_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = grdvMaster.GetDataRow(e.RowHandle);
                if (Convert.ToDecimal(dr["QTY"].ToString()) < Convert.ToDecimal(dr["WARNING_EMPTY"].ToString()))
                {
                    if (Convert.ToDecimal(dr["QTY"].ToString()) < Convert.ToDecimal(dr["DANGEROUS_EMPTY"].ToString()))
                        e.Appearance.BackColor = Color.Red;
                    else
                        e.Appearance.BackColor = Color.Yellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }

            }
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void grdvDetail_GotFocus(object sender, EventArgs e)
        {
            GridLocation = "Detail";
            gv = (GridView)sender;
        }

        private void grdvDetail_LostFocus(object sender, EventArgs e)
        {
            GridLocation = "Master";
        }

        private void INV_TXN_InventoryManagement_Load(object sender, EventArgs e)
        {
            FillAllData();
            FillGridView();
            base.CloseWaitDialog();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillAllData();
            FillGridView();
        }
    }
}