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
    public partial class INV_TXN_Transfer : Envision.NET.Forms.Main.MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private MyMessageBox msg = new MyMessageBox();
        private InventoryManagement inv = new InventoryManagement();
        private MyMessageBox msb = new MyMessageBox();
        private int _requesitionid;
        private GuiMode _mode;
        List<string> listUnit = new List<string>();

        DataSet dsMaster;
        DataSet dsDetail;
        DataSet dsUnion;
        GridView gv;
        bool chkBalance = true;

        public INV_TXN_Transfer()
        {
            InitializeComponent();
        }

        private void FillAllData()
        {
            DataSet ds = inv.Request.SelectForTranfer();
            grdRequestData.DataSource = ds.Tables[0];
            grdFilterRQ.DataSource = ds.Tables[0];
            grdFilterRQ.Focus();


            DataTable dtUnit = new DataTable();
            ProcessGetInvUnit prcUnit = new ProcessGetInvUnit();
            prcUnit.Invoke();
            dtUnit = prcUnit.ResultTable;
            listUnit.Clear();
            cmbFromUnit.Properties.Items.Clear();
            cmbToUnit.Properties.Items.Clear();
            foreach (DataRow dr in dtUnit.Rows)
            {
                listUnit.Add(dr["UNIT_ID"].ToString());
                cmbFromUnit.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
                cmbToUnit.Properties.Items.Add(dr["UNIT_UID"].ToString() + ":" + dr["UNIT_NAME"].ToString());
            }
            cmbFromUnit.SelectedIndex = 0;
            cmbToUnit.SelectedIndex = 0;
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["REQUISITION_ID"].ToString()));
        }

        private void advBandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["REQUISITION_ID"].ToString()));
            }
        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["REQUISITION_ID"].ToString()));
        }

        private void layoutView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["REQUISITION_ID"].ToString()));
            }
        }
        private void FillDetailData(int REQUISITION_ID)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;

            inv.Request.SelectRequest(REQUISITION_ID);
            _requesitionid = REQUISITION_ID;
            txtREQUISITION_UID.Text = inv.Request.Request_Data.REQUISITION_UID;
            txGenerateBy.Text = inv.Request.Request_Data.GENERATED_BY_TEXT;
            try
            {
                txtGenerateOn.Text = inv.Request.Request_Data.GENERATED_ON.Value.ToLongDateString() + " " + inv.Request.Request_Data.GENERATED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }
            txtModifiedBy.Text = inv.Request.Request_Data.LAST_MODIFIED_BY_TEXT;
            try
            {
                txtModifiedOn.Text = inv.Request.Request_Data.LAST_MODIFIED_ON.Value.ToLongDateString() + " " + inv.Request.Request_Data.LAST_MODIFIED_ON.Value.ToShortTimeString();
            }
            catch { txtModifiedOn.Text = ""; }
            txtStatus.Text = inv.Request.Request_Data.RQ_STATUS;

            cmbFromUnit.SelectedIndex = listUnit.IndexOf(inv.Request.Request_Data.FROM_UNIT.ToString());
            cmbToUnit.SelectedIndex = listUnit.IndexOf(inv.Request.Request_Data.TO_UNIT.ToString());
            cmbFromUnit.Properties.ReadOnly = true;
            cmbToUnit.Properties.ReadOnly = true;
            dsMaster = inv.InventoryStock.GetREQMaster(REQUISITION_ID, inv.Request.Request_Data.FROM_UNIT.Value).Copy();
            dsMaster.Tables[0].TableName = "Master";
            dsDetail = inv.InventoryStock.GetREQDetail(REQUISITION_ID, inv.Request.Request_Data.FROM_UNIT.Value).Copy();
            dsDetail.Tables[0].TableName = "Detail";
            dsUnion = new DataSet();
            dsUnion.Tables.Add(dsMaster.Tables[0].Copy());
            dsUnion.Tables.Add(dsDetail.Tables[0].Copy());
            dsUnion.AcceptChanges();

            if (inv.Request.Request_Data.STATUS.ToString() == "F" || inv.Request.Request_Data.STATUS.ToString() == "C")
            {
                if (inv.Request.Request_Data.STATUS.ToString() == "F")
                {
                    chkForceCompleted.Checked = true;
                }
                chkForceCompleted.Properties.ReadOnly = true;
            }
            else
            {
                DataColumn keyColumn = dsUnion.Tables[0].Columns["ITEM_ID"];
                DataColumn foreignKeyColumn = dsUnion.Tables[1].Columns["ITEM_ID"];
                dsUnion.Relations.Add("ItemRecieve", keyColumn, foreignKeyColumn);
                chkForceCompleted.Properties.ReadOnly = false;
            }

            grdTranfer.DataSource = dsUnion.Tables[0];
            grdTranfer.ForceInitialize();

            //gridView1.BestFitColumns();
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView(grdTranfer);
            //// gridView gridView1 = new CardView(gridControl1);
            grdTranfer.LevelTree.Nodes.Add("ItemRecieve", gridView1);

            //Hide the CategoryID column for the master view
            grdvMaster.Columns["ITEM_ID"].VisibleIndex = -1;
            ////Create columns for the pattern view
            gridView1.PopulateColumns(dsUnion.Tables["Detail"]);
            ////Hide the CategoryID column for the pattern view

            gridView1.Columns["ITEM_STOCK_ID"].VisibleIndex = -1;
            gridView1.Columns["ITEM_ID"].VisibleIndex = -1;
            gridView1.Columns["UNIT_ID"].VisibleIndex = -1;
            gridView1.Columns["ORG_ID"].VisibleIndex = -1;
            gridView1.Columns["TXN_UNIT_ID"].VisibleIndex = -1;
            //gridView1.Columns["TXN_UNIT_NAME"].VisibleIndex = -1;
            //gridView1.Columns["ITEM_NAME"].VisibleIndex = -1;

            //gridView1.Columns["ITEM_UID"].Caption = "Item Code";
            gridView1.Columns["ITEM_NAME"].Caption = "Item Name";
            gridView1.Columns["TXN_UNIT_NAME"].Caption = "Item Unit";
            gridView1.Columns["ITEM_TRANFER"].Caption = "Item Tranfer";
            gridView1.Columns["STOCK_QTY"].Caption = "Stock Quanitity";
            gridView1.Columns["BATCH"].Caption = "Batch";
            gridView1.Columns["EXPIRY_DT"].Caption = "Expire";
            gridView1.Columns["CREATED_ON"].Caption = "Recieve Date";
            // gridView1.Columns["COMMENTS"].Caption = "Comment";
            //gridView1.Columns["ITEM_RECIEVE_STATUS"].Caption = "Status";

            gridView1.Columns["ITEM_NAME"].Width = 150;

            //gridView1.Columns["RECIEVE_SUCCESS"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // gridView1.Columns["RECIEVE_SUCCESS"].DisplayFormat.FormatString = "#,##0";
            //gridView1.Columns["PRICE"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //gridView1.Columns["PRICE"].DisplayFormat.FormatString = "#,##0.00";

            gridView1.Columns["ITEM_NAME"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["TXN_UNIT_NAME"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["STOCK_QTY"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["BATCH"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["EXPIRY_DT"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["CREATED_ON"].OptionsColumn.ReadOnly = true;

            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;

            gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanged);
            gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView1_CellValueChanging);
            gridView1.RowCellStyle += new RowCellStyleEventHandler(gridView1_RowCellStyle);
            setForm(GuiMode.Edit);
        }

        private void btnColDelete_Click(object sender, EventArgs e)
        {
            //DataRow dr = grdvREQUISITIONdetail.GetDataRow(grdvREQUISITIONdetail.FocusedRowHandle);
            //DataRow[] drDel = inv.Request.RequestDTL_dsDelete.Tables[0].Select("REQUISITION_ID = " + dr["REQUISITION_ID"].ToString() + "AND ITEM_ID = " + dr["ITEM_ID"].ToString());
            //if (dr["REQUISITION_ID"].ToString() == "0")
            //{
            //    inv.Request.RequestDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
            //    inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
            //}
            //else
            //{
            //    inv.Request.dsDeleteAdd(dr);
            //    inv.Request.RequestDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
            //    inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
            //}
        }

        private void btnGridbtnAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        private void AddItem()
        {
            //try
            //{
            //    INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
            //    delForm.ShowDialog();
            //    if (delForm.DialogResult == DialogResult.OK)
            //    {
            //        DataRow drItem = grdvItem.GetDataRow(grdvItem.FocusedRowHandle);
            //        DataRow[] dr = inv.Request.RequestDTL_InsertUpdate.Tables[0].Select("ITEM_ID = " + drItem["ITEM_ID"].ToString());
            //        if (dr.Length > 0)
            //        {
            //            dr[0]["QTY"] = Convert.ToDecimal(dr[0]["QTY"].ToString()) + Convert.ToDecimal(delForm.ResultValue);
            //            inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
            //        }
            //        else
            //        {
            //            inv.Request.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(delForm.ResultValue), "", new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
            //            inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
            //            grdREQUISITION_Detail.DataSource = inv.Request.RequestDTL_InsertUpdate.Tables[0];
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message);
            //}
        }
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillDetailData(0);
            setForm(GuiMode.Add);
        }
        private void setForm(GuiMode Mode)
        {
            _mode = Mode;
            switch (Mode)
            {
                case GuiMode.Normal:
                    //grpShow.GroupBordersVisible = true;
                    //grpShow.Expanded = true;
                    //grpRequestdetail.GroupBordersVisible = false;
                    //grpRequestdetail.Expanded = false;
                    //grpItem.GroupBordersVisible = false;
                    //grpItem.Expanded = false;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribBack.Visible = true;
                    btnribbonAdd.Visible = true;
                    //btnribSavePrint.Visible = false;
                    // btnribPrint.Visible = true;
                    cmbFromUnit.Properties.ReadOnly = true;
                    cmbToUnit.Properties.ReadOnly = true;

                    txtREQUISITION_UID.Properties.ReadOnly = true; ;
                    if (inv.Request.Request_Data.STATUS != 'N')
                    {
                        btnribbonUpdate.Visible = false;
                        btnribDelete.Visible = false;
                    }
                    else
                    {
                        btnribbonUpdate.Visible = true;
                        btnribDelete.Visible = true;
                    }
                    break;
                case GuiMode.Add:
                    txtREQUISITION_UID.Properties.ReadOnly = false;
                    txtREQUISITION_UID.Text = "Auto";
                    txtStatus.Text = "New";
                    txtModifiedBy.Text = "Waiting...";
                    txtModifiedOn.Text = "Waiting...";
                    txGenerateBy.Text = "Waiting...";
                    txtGenerateOn.Text = "Waiting...";

                    //grpShow.GroupBordersVisible = false;
                    //grpShow.Expanded = false;
                    //grpRequestdetail.GroupBordersVisible = true;
                    //grpRequestdetail.Expanded = true;
                    //grpItem.GroupBordersVisible = true;
                    //grpItem.Expanded = true;

                    txtREQUISITION_UID.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribBack.Visible = false;
                    btnribDelete.Visible = false;
                    // btnribSavePrint.Visible = true;
                    // btnribPrint.Visible = false;

                    cmbFromUnit.Properties.ReadOnly = true;
                    cmbToUnit.Properties.ReadOnly = true;

                    cmbFromUnit.SelectedIndex = 0;
                    cmbToUnit.SelectedIndex = 0;
                    break;
                case GuiMode.Edit:
                    if (inv.Request.Request_Data.STATUS != 'N')
                    {
                        btnribbonSave.Visible = false;
                        btnribbonCancel.Visible = true;
                        btnribBack.Visible = true;
                        btnribbonAdd.Visible = false;
                        btnribbonUpdate.Visible = false;
                        btnribDelete.Visible = false;

                    }
                    else
                    {
                        btnribbonSave.Visible = true;
                        btnribbonCancel.Visible = false;
                        btnribBack.Visible = true;
                        btnribbonAdd.Visible = false;
                        btnribbonUpdate.Visible = false;
                        btnribDelete.Visible = false;
                    }
                    cmbFromUnit.Properties.ReadOnly = true;
                    cmbToUnit.Properties.ReadOnly = true;
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
                if (inv.Request.Request_Data.REQUISITION_ID > 0)
                {
                    inv.ItemTransation.INVTransaction.REQUISITION_ID = inv.Request.Request_Data.REQUISITION_ID;
                    inv.ItemTransation.INVTransaction.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.ItemTransation.InsertTransactionRQCancel();
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
            foreach (DataRow dr in dsUnion.Tables[0].Rows)
            {
                if (Convert.ToDouble(dr["ITEM_TRANFER"].ToString()) < Convert.ToDouble(dr["QTY"].ToString()))
                {
                    if (msg.ShowAlert("UID5007", env.CurrentLanguageID) == "2")
                    {
                        chkForceCompleted.Checked = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (msg.ShowAlert("UID5005", env.CurrentLanguageID) != "2")
            {
                return;
            }
            decimal sum = 0;

            inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.T.ToString());
            inv.ItemTransation.INVTransaction.REQUISITION_ID = inv.Request.Request_Data.REQUISITION_ID;
            inv.ItemTransation.INVTransaction.PO_ID = 0;
            inv.ItemTransation.INVTransaction.FROM_UNIT = inv.Request.Request_Data.FROM_UNIT;
            inv.ItemTransation.INVTransaction.TO_UNIT = inv.Request.Request_Data.TO_UNIT;
            inv.ItemTransation.INVTransaction.COMMENTS = "";
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
                    DataRow[] drchkDetail = dsUnion.Tables[1].Select("ITEM_ID = " + dr["ITEM_ID"].ToString());
                    for (int i = 0; i < drchkDetail.Length; i++)
                    {
                        if (Convert.ToDouble(drchkDetail[i]["ITEM_TRANFER"].ToString()) > 0)
                        {
                            sum = sum + Convert.ToDecimal(drchkDetail[i]["ITEM_TRANFER"].ToString());
                        }
                    }
                    if (sum >= Convert.ToDecimal(dr["SUCCESS_QTY"].ToString()))
                    {
                        inv.ItemTransation.INVTransaction.STATUS = Envision.Common.Status.C.ToString();
                    }
                    else
                    {
                        return;
                    }
                    sum = 0;
                }
            }

            foreach (DataRow dr in dsUnion.Tables[1].Rows)
            {
                if (Convert.ToDouble(dr["ITEM_TRANFER"].ToString()) > 0)
                {
                    if (dr["EXPIRY_DT"].ToString() != "")
                    {
                        inv.ItemTransation.AddTransactionDtl(Convert.ToInt32(dr["ITEM_ID"].ToString()), Convert.ToInt32(dr["ITEM_ID"].ToString()), Convert.ToInt32(dr["TXN_UNIT_ID"].ToString()), dr["BATCH"].ToString(), Convert.ToDateTime(dr["EXPIRY_DT"].ToString())
                        , Convert.ToDouble(dr["ITEM_TRANFER"].ToString()), Convert.ToDouble(dr["PRICE"].ToString()), "", Convert.ToInt32(dr["ITEM_STOCK_ID"].ToString()));
                    }
                    //Convert.ToDouble(dr["PRICE"].ToString())
                }
            }
            if (inv.ItemTransation.InsertTransaction())
            {

            }

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
            inv.Request.RequestManagement(DataManageType.Delete);
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
        }
        private void layoutControl1_GroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {

        }

        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (_mode)
            {
                case GuiMode.Normal:
                    break;
                case GuiMode.Add:
                    inv.Request.Request_Data.REQUISITION_ID = 0;
                    inv.Request.Request_Data.REQUISITION_UID = txtREQUISITION_UID.Text;
                    inv.Request.Request_Data.ORG_ID = new GBLEnvVariable().OrgID;
                    inv.Request.Request_Data.GENERATED_BY = new GBLEnvVariable().UserID;
                    inv.Request.Request_Data.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.Request.Request_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.Request.RequestManagement(DataManageType.Insert);
                    break;
                case GuiMode.Edit:
                    inv.Request.RequestManagement(DataManageType.InsertUpdate);
                    break;
                case GuiMode.Remove:
                    inv.Request.RequestManagement(DataManageType.Delete);
                    break;
                default:
                    break;
            }
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
        }

        private void grdvItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                AddItem();
            }
        }

        private void grdvItem_DoubleClick(object sender, EventArgs e)
        {
            AddItem();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            double sum = 0;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            int i = e.RowHandle;

            gv = (GridView)(sender);
            DataRow drd = gv.GetDataRow(i);
            foreach (DataRow dr in dsUnion.Tables[1].Rows)
            {
                if (Convert.ToDecimal(dr["ITEM_TRANFER"].ToString()) > Convert.ToDecimal(dr["STOCK_QTY"].ToString()))
                {
                    DataRow[] drDetail = dsDetail.Tables[0].Select("ITEM_STOCK_ID = " + dr["ITEM_STOCK_ID"].ToString());
                    dr["ITEM_TRANFER"] = drDetail[0]["STOCK_QTY"];
                    dr.AcceptChanges();
                }

            }
            foreach (DataRow dr in dsUnion.Tables[0].Rows)
            {
                DataRow[] drDetail2 = dsUnion.Tables[1].Select("ITEM_ID = " + dr["ITEM_ID"].ToString());
                for (int j = 0; j < drDetail2.Length; j++)
                {
                    sum = sum + Convert.ToDouble(drDetail2[j]["ITEM_TRANFER"].ToString());
                }
                dr["ITEM_TRANFER"] = sum;
                dr.AcceptChanges();
                sum = 0;
            }

        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.Caption == "Item Tranfer")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void INV_TXN_Transfer_Load(object sender, EventArgs e)
        {
            FillAllData();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            base.CloseWaitDialog();
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillAllData();
        }
    }
}