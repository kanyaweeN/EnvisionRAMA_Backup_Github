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

namespace Envision.NET.Forms.Inventory
{
    public partial class INV_TXN_PO : Envision.NET.Forms.Main.MasterForm
    {
        private InventoryManagement inv = new InventoryManagement();
        private MyMessageBox msb = new MyMessageBox();
        private int _poid,_prid;
        private GuiMode _mode;
        List<string> listVendor = new List<string>();

        public INV_TXN_PO()
        {
            InitializeComponent();
        }
        private void INV_TXN_PO_Load(object sender, EventArgs e)
        {
            FillAllData();
            ribMasterMenu.Minimized = true;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            //ribbonControl2.Update();
            base.CloseWaitDialog();
        }
        private void FillAllData()
        {
            DataSet ds = inv.PO.SelectAll();

            grdPOData.DataSource = ds.Tables[0];
            grdFilterPO.DataSource = ds.Tables[0];
            grdFilterPO.Focus();

            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;

            ProcessGetInvItem prc = new ProcessGetInvItem();
            prc.Invoke();
            grdItem.DataSource = prc.ResultTable;

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
            ribMasterMenu.Visible = true;
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["PO_ID"].ToString()));
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
            _poid = PO_ID;
            txtPO_UID.Text = inv.PO.PO_Data.PO_UID;
            txGenerateBy.Text = inv.PO.PO_Data.GENERATED_BY_TEXT;
            cmbVendor.SelectedIndex = listVendor.IndexOf(inv.PO.PO_Data.VENDOR_ID.ToString());
            try
            {
                txtGenerateOn.Text = inv.PO.PO_Data.GENERATED_ON.Value.ToLongDateString() + " " + inv.PO.PO_Data.GENERATED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }
            txtModifiedBy.Text = inv.PO.PO_Data.LAST_MODIFIED_BY_TEXT;
            try
            {
                txtModifiedOn.Text = inv.PO.PO_Data.LAST_MODIFIED_ON.Value.ToLongDateString() + " " + inv.PO.PO_Data.LAST_MODIFIED_ON.Value.ToShortTimeString();
            }
            catch { txtModifiedOn.Text = ""; }
            txtStatus.Text = inv.PO.PO_Data.STATUS;
            txtPR_UID.Text = inv.PO.PO_Data.PR_UID;

            grdPO_Detail.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];
            grdPODetailShow.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];


            setForm(GuiMode.Normal);
        }
        private void FillDetailData(int PO_ID,int PR_ID)
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
            catch
            {
                txtGenerateOn.Text = "";
            }
            txtModifiedBy.Text = inv.PO.PO_Data.LAST_MODIFIED_BY_TEXT;
            try
            {
                txtModifiedOn.Text = inv.PO.PO_Data.LAST_MODIFIED_ON.Value.ToLongDateString() + " " + inv.PO.PO_Data.LAST_MODIFIED_ON.Value.ToShortTimeString();
            }
            catch
            {
                txtModifiedOn.Text = "";
            }
            txtStatus.Text = inv.PO.PO_Data.STATUS;
            txtPR_UID.Text = inv.PO.PO_Data.PR_UID;

            foreach (DataRow drItem in inv.PR.PRDTL_InsertUpdate.Tables[0].Rows)
            {
                inv.PO.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(drItem["QTY"].ToString()), 0, new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
            }

            grdPO_Detail.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];
            grdPODetailShow.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];


            setForm(GuiMode.Normal);
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
                INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
                delForm.ShowDialog();
                if (delForm.DialogResult == DialogResult.OK)
                {
                    DataRow drItem = grdvItem.GetDataRow(grdvItem.FocusedRowHandle);
                    DataRow[] dr = inv.PO.PODTL_InsertUpdate.Tables[0].Select("ITEM_ID = " + drItem["ITEM_ID"].ToString());
                    if (dr.Length > 0)
                    {
                        dr[0]["QTY"] = Convert.ToDecimal(dr[0]["QTY"].ToString()) + Convert.ToDecimal(delForm.ResultValue);
                        inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
                    }
                    else
                    {
                        inv.PO.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(delForm.ResultValue), 0, new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                        inv.PO.PODTL_InsertUpdate.Tables[0].AcceptChanges();
                        grdPO_Detail.DataSource = inv.PO.PODTL_InsertUpdate.Tables[0];
                    }
                }
                else
                {
                    return;
                }
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
                    ribMasterMenu.Visible = false;
                    grpShow.GroupBordersVisible = true;
                    grpShow.Expanded = true;
                    grpPRdetail.GroupBordersVisible = false;
                    grpPRdetail.Expanded = false;
                    grpItem.GroupBordersVisible = false;
                    grpItem.Expanded = false;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribBack.Visible = true;
                    btnribbonAdd.Visible = true;
                    btnribSavePrint.Visible = false;
                    btnribPrint.Visible = true;
                    btnribbonFromPR.Visible = true;

                    cmbVendor.Properties.ReadOnly = true;

                    txtPO_UID.Properties.ReadOnly = true; ;
                    if (inv.PO.PO_Data.PO_STATUS != 'N')
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
                    txtPO_UID.Properties.ReadOnly = false;
                    txtPO_UID.Text = "Auto";
                    txtStatus.Text = "New";
                    txtModifiedBy.Text = "Waiting...";
                    txtModifiedOn.Text = "Waiting...";
                    txGenerateBy.Text = "Waiting...";
                    txtGenerateOn.Text = "Waiting...";

                    grpShow.GroupBordersVisible = false;
                    grpShow.Expanded = false;
                    grpPRdetail.GroupBordersVisible = true;
                    grpPRdetail.Expanded = true;
                    grpItem.GroupBordersVisible = true;
                    grpItem.Expanded = true;

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

                    ribMasterMenu.Visible = false;
                    break;
                case GuiMode.Edit:
                    if (inv.PO.PO_Data.PO_STATUS != 'N')
                    {
                        grpShow.GroupBordersVisible = true;
                        grpShow.Expanded = true;
                        grpPRdetail.GroupBordersVisible = false;
                        grpPRdetail.Expanded = false;
                        grpItem.GroupBordersVisible = false;
                        grpItem.Expanded = false;
                        cmbVendor.Properties.ReadOnly = false;
                    }
                    else
                    {
                        grpShow.GroupBordersVisible = false;
                        grpShow.Expanded = false;
                        grpPRdetail.GroupBordersVisible = true;
                        grpPRdetail.Expanded = true;
                        grpItem.GroupBordersVisible = true;
                        grpItem.Expanded = true;
                    }

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribBack.Visible = false;
                    btnribDelete.Visible = false;
                    btnribSavePrint.Visible = true;
                    btnribPrint.Visible = false;
                    btnribbonFromPR.Visible = false;

                    ribMasterMenu.Visible = false;
                    cmbVendor.Properties.ReadOnly = false;
                    //grpShow.GroupBordersVisible = false;
                    //grpShow.Expanded = false;
                    //grpPRdetail.GroupBordersVisible = true;
                    //grpPRdetail.Expanded = true;
                    //grpItem.GroupBordersVisible = true;
                    //grpItem.Expanded = true;
                    //txtPR_UID.Properties.ReadOnly = true;
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
                setForm(GuiMode.Normal);
            else
            {
                xtraTabControl1.SelectedTabPageIndex = 0;
                setForm(GuiMode.Normal);
                ribMasterMenu.Visible = true;
            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (_mode)
            {
                case GuiMode.Normal:
                    break;
                case GuiMode.Add:
                    inv.PO.PO_Data.PO_ID = 0;
                    inv.PO.PO_Data.PO_UID = txtPO_UID.Text;
                    inv.PO.PO_Data.PR_ID = _prid;
                    inv.PO.PO_Data.VENDOR_ID = Convert.ToInt32(listVendor[cmbVendor.SelectedIndex]);
                    inv.PO.PO_Data.TOC = txtTOC.Text;
                    inv.PO.PO_Data.ORG_ID = new GBLEnvVariable().OrgID;
                    inv.PO.PO_Data.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.PO.PO_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PO.poManagement(DataManageType.Insert);
                    break;
                case GuiMode.Edit:
                    inv.PO.PO_Data.VENDOR_ID = Convert.ToInt32(listVendor[cmbVendor.SelectedIndex]);
                    inv.PO.PO_Data.TOC = txtTOC.Text;
                    inv.PO.PO_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PO.poManagement(DataManageType.InsertUpdate);
                    break;
                case GuiMode.Remove:
                    inv.PO.poManagement(DataManageType.Delete);
                    break;
                default:
                    break;
            }
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
        }

        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            ribMasterMenu.Visible = true;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            inv.PO.poManagement(DataManageType.Delete);
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
        }

        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (_mode)
            {
                case GuiMode.Normal:
                    break;
                case GuiMode.Add:
                    inv.PO.PO_Data.PO_ID = 0;
                    inv.PO.PO_Data.PO_UID = txtPO_UID.Text;
                    inv.PO.PO_Data.PR_ID = _prid;
                    inv.PO.PO_Data.VENDOR_ID = Convert.ToInt32(listVendor[cmbVendor.SelectedIndex]);
                    inv.PO.PO_Data.TOC = txtTOC.Text;
                    inv.PO.PO_Data.ORG_ID = new GBLEnvVariable().OrgID;
                    inv.PO.PO_Data.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.PO.PO_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PO.poManagement(DataManageType.Insert);
                    break;
                case GuiMode.Edit:
                    inv.PO.PO_Data.VENDOR_ID = Convert.ToInt32(listVendor[cmbVendor.SelectedIndex]);
                    inv.PO.PO_Data.TOC = txtTOC.Text;
                    inv.PO.PO_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PO.poManagement(DataManageType.InsertUpdate);
                    break;
                case GuiMode.Remove:
                    inv.PO.poManagement(DataManageType.Delete);
                    break;
                default:
                    break;
            }
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);

            Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
            print.PO_Report(inv.PO.PO_Data.PO_ID);
        }

        private void grdvItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                AddItem();
            }
        }

        private void grdvPodetail_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

        }

        private void grdvPodetail_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

        }

        private void grdvPodetail_HiddenEditor(object sender, EventArgs e)
        {
            DataTable dtt = (DataTable)grdPO_Detail.DataSource;
            foreach (DataRow dr in dtt.Rows)
            {
                dr["TOTAL_PRICE"] = Convert.ToDecimal(dr["QTY"].ToString()) * Convert.ToDecimal(dr["UNITPRICE"].ToString());
            }

        }

        private void grdvPodetail_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void grdvPodetail_ShownEditor(object sender, EventArgs e)
        {

        }

        private void grdvPodetail_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
           // e.Value
        }

        private void grdvPodetail_GotFocus(object sender, EventArgs e)
        {

        }

        private void grdvPodetail_LostFocus(object sender, EventArgs e)
        {
            
        }

        private void btnFromPR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(lvNo_ValueUpdated);
            lv.AddColumn("PR_ID", "PR_ID", false, true);
            lv.AddColumn("PR_UID", "PR No.", true, true);
            lv.AddColumn("STATUS", "Status No", true, true);
            lv.Text = "PR Search";

            lv.Data = lvS.SelectPRforPO().Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void lvNo_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            _prid = Convert.ToInt32(retValue[0]);
            FillDetailData(0, _prid);
            setForm(GuiMode.Add);
            txtPR_UID.Text = retValue[1];
        }

        private void grdvItem_DoubleClick(object sender, EventArgs e)
        {
            AddItem();
        }

        private void layoutControl1_GroupExpandChanged(object sender, DevExpress.XtraLayout.Utils.LayoutGroupEventArgs e)
        {
            if (grpItem.Expanded == true)
            {
                grpItem.TextLocation = DevExpress.Utils.Locations.Top;
            }
            else
            {
                grpItem.TextLocation = DevExpress.Utils.Locations.Right;
            }
            grpItem.Update();
        }

        private void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillAllData();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
            print.PO_Report(inv.PO.PO_Data.PO_ID);
        }
    }
}