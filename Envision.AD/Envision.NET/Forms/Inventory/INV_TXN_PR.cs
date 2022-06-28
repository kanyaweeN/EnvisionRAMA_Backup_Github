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
    public partial class INV_TXN_PR : Envision.NET.Forms.Main.MasterForm
    {
        private InventoryManagement inv = new InventoryManagement();
        private MyMessageBox msb = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private int _prid;
        private GuiMode _mode;

        public INV_TXN_PR()
        {
            InitializeComponent();
        }
        private void INV_TXN_PR_Load(object sender, EventArgs e)
        {
            FillAllData();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            ribMasterMenu.Minimized = true;
            base.CloseWaitDialog();
        }
        private void FillAllData()
        {
            DataSet ds = inv.PR.SelectAll();
            grdPRData.DataSource = ds.Tables[0];
            grdFilterPR.DataSource = ds.Tables[0];
            grdFilterPR.Focus();

            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;

            ProcessGetInvItem prc = new ProcessGetInvItem();
            prc.Invoke();
            grdItem.DataSource = prc.ResultTable;
            ribMasterMenu.Visible = true;
        }
        private void advBandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["PR_ID"].ToString()));
        }

        private void advBandedGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["PR_ID"].ToString()));
            }
        }

        private void layoutView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            FillDetailData(Convert.ToInt32(dr["PR_ID"].ToString()));
        }

        private void layoutView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                DataRow dr = advBandedGridView1.GetDataRow(advBandedGridView1.FocusedRowHandle);
                FillDetailData(Convert.ToInt32(dr["PR_ID"].ToString()));
            }
        }
        private void FillDetailData(int PR_ID)
        {
            xtraTabControl1.SelectedTabPageIndex = 1;
            inv.PR.SelectPR(PR_ID);
            _prid = PR_ID;
            txtPR_UID.Text = inv.PR.PR_Data.PR_UID;
            txGenerateBy.Text = inv.PR.PR_Data.GENERATED_BY_TEXT;
            try
            {
                txtGenerateOn.Text = inv.PR.PR_Data.GENERATED_ON.Value.ToLongDateString() + " " + inv.PR.PR_Data.GENERATED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }
            try
            {
                txtModifiedOn.Text = inv.PR.PR_Data.LAST_MODIFIED_ON.Value.ToLongDateString() + " " + inv.PR.PR_Data.LAST_MODIFIED_ON.Value.ToShortTimeString();
            }
            catch { txtGenerateOn.Text = ""; }
            txtModifiedBy.Text = inv.PR.PR_Data.LAST_MODIFIED_BY_TEXT;
            txtStatus.Text = inv.PR.PR_Data.STATUS;

            grdPR_Detail.DataSource = inv.PR.PRDTL_InsertUpdate.Tables[0];
            grdPRDetailShow.DataSource = inv.PR.PRDTL_InsertUpdate.Tables[0];

            
            setForm(GuiMode.Normal);
        }

        private void btnColDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = grdvPrdetail.GetDataRow(grdvPrdetail.FocusedRowHandle);
            DataRow[] drDel = inv.PR.PRDTL_dsDelete.Tables[0].Select("PR_ID = " + dr["PR_ID"].ToString() + "AND ITEM_ID = " + dr["ITEM_ID"].ToString());
            if (dr["PR_ID"].ToString() == "0")
            {
                inv.PR.PRDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.PR.PRDTL_InsertUpdate.Tables[0].AcceptChanges();
            }
            else
            {
                inv.PR.dsDeleteAdd(dr);
                inv.PR.PRDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.PR.PRDTL_InsertUpdate.Tables[0].AcceptChanges();
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
                    DataRow[] dr = inv.PR.PRDTL_InsertUpdate.Tables[0].Select("ITEM_ID = " + drItem["ITEM_ID"].ToString());
                    if (dr.Length > 0)
                    {
                        dr[0]["QTY"] = Convert.ToDecimal(dr[0]["QTY"].ToString()) + Convert.ToDecimal(delForm.ResultValue);
                        inv.PR.PRDTL_InsertUpdate.Tables[0].AcceptChanges();
                    }
                    else
                    {
                        inv.PR.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(delForm.ResultValue), "", new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                        inv.PR.PRDTL_InsertUpdate.Tables[0].AcceptChanges();
                        grdPR_Detail.DataSource = inv.PR.PRDTL_InsertUpdate.Tables[0];
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

                    txtPR_UID.Properties.ReadOnly = true; ;
                    if (inv.PR.PR_Data.PR_STATUS != 'N')
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
                    ribMasterMenu.Visible = false;
                    txtPR_UID.Properties.ReadOnly = false;
                    txtPR_UID.Text = "Auto";
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

                    txtPR_UID.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribBack.Visible = false;
                    btnribDelete.Visible = false;
                    btnribSavePrint.Visible = true;
                    btnribPrint.Visible = false;
                    break;
                case GuiMode.Edit:
                    ribMasterMenu.Visible = false;
                    if (inv.PR.PR_Data.PR_STATUS != 'N')
                    {
                        grpShow.GroupBordersVisible = true;
                        grpShow.Expanded = true;
                        grpPRdetail.GroupBordersVisible = false;
                        grpPRdetail.Expanded = false;
                        grpItem.GroupBordersVisible = false;
                        grpItem.Expanded = false;

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
            if (inv.PR.PR_Data.PR_ID > 0)
            {
                FillDetailData(inv.PR.PR_Data.PR_ID);
                setForm(GuiMode.Normal);
            }
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
                    inv.PR.PR_Data.PR_ID = 0;
                    inv.PR.PR_Data.PR_UID = txtPR_UID.Text;
                    inv.PR.PR_Data.ORG_ID = new GBLEnvVariable().OrgID;
                    inv.PR.PR_Data.GENERATED_BY = new GBLEnvVariable().UserID;
                    inv.PR.PR_Data.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.PR.PR_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PR.prManagement(DataManageType.Insert);
                    break;
                case GuiMode.Edit:
                    inv.PR.PR_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.PR.prManagement(DataManageType.InsertUpdate);
                    break;
                case GuiMode.Remove:
                    inv.PR.prManagement(DataManageType.Delete);
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
            ribMasterMenu.Visible = true;
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            inv.PR.prManagement(DataManageType.Delete);
            FillAllData();
            xtraTabControl1.SelectedTabPageIndex = 0;
            setForm(GuiMode.Normal);
        }

        private void grdvItem_DoubleClick(object sender, EventArgs e)
        {
            AddItem();
        }

        private void grdvItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                AddItem();
            }
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

        private void btnSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msb.ShowAlert("UID5005", env.CurrentLanguageID) == "2")
            {
                switch (_mode)
                {
                    case GuiMode.Normal:
                        break;
                    case GuiMode.Add:
                        inv.PR.PR_Data.PR_ID = 0;
                        inv.PR.PR_Data.PR_UID = txtPR_UID.Text;
                        inv.PR.PR_Data.ORG_ID = new GBLEnvVariable().OrgID;
                        inv.PR.PR_Data.GENERATED_BY = new GBLEnvVariable().UserID;
                        inv.PR.PR_Data.CREATED_BY = new GBLEnvVariable().UserID;
                        inv.PR.PR_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        inv.PR.prManagement(DataManageType.Insert);
                        break;
                    case GuiMode.Edit:
                        inv.PR.PR_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        inv.PR.prManagement(DataManageType.InsertUpdate);
                        break;
                    case GuiMode.Remove:
                        inv.PR.prManagement(DataManageType.Delete);
                        break;
                    default:
                        break;
                }
                FillAllData();
                xtraTabControl1.SelectedTabPageIndex = 0;
                setForm(GuiMode.Normal);

                Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                print.PR_Report(inv.PR.PR_Data.PR_ID);
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
            print.PR_Report(inv.PR.PR_Data.PR_ID);
        }

    }
}