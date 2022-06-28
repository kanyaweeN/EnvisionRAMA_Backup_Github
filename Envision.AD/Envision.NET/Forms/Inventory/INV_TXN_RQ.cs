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
    public partial class INV_TXN_RQ : Envision.NET.Forms.Main.MasterForm
    {
        private InventoryManagement inv = new InventoryManagement();
        
        private MyMessageBox msb = new MyMessageBox();
        private int _requesitionid;
        private GuiMode _mode;
        List<string> listUnit = new List<string>();

        public INV_TXN_RQ()
        {
            InitializeComponent();
        }
        private void INV_TXN_RQ_Load(object sender, EventArgs e)
        {
            FillAllData();
            ribMasterMenu.Minimized = true;
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            base.CloseWaitDialog();
        }
        private void FillAllData()
        {
            DataSet ds = inv.Request.SelectAll();
            grdRequestData.DataSource = ds.Tables[0];
            grdFilterRQ.DataSource = ds.Tables[0];
            grdFilterRQ.Focus();

            layoutView1.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Carousel;

            ProcessGetInvItem prc = new ProcessGetInvItem();
            prc.Invoke();
            grdItem.DataSource = prc.ResultTable;

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
            cmbToUnit.SelectedIndex = 1;
            ribMasterMenu.Visible = true;
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
            try
            {
                txtStatus.Text = inv.Request.Request_Data.RQ_STATUS.ToString();
            }
            catch { txtStatus.Text = ""; }

            cmbFromUnit.SelectedIndex = listUnit.IndexOf(inv.Request.Request_Data.FROM_UNIT.ToString());
            cmbToUnit.SelectedIndex = listUnit.IndexOf(inv.Request.Request_Data.TO_UNIT.ToString());

            grdREQUISITION_Detail.DataSource = inv.Request.RequestDTL_InsertUpdate.Tables[0];
            grdREQUISITIONDetailShow.DataSource = inv.Request.RequestDTL_InsertUpdate.Tables[0];

            
            setForm(GuiMode.Normal);
        }

        private void btnColDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = grdvREQUISITIONdetail.GetDataRow(grdvREQUISITIONdetail.FocusedRowHandle);
            DataRow[] drDel = inv.Request.RequestDTL_dsDelete.Tables[0].Select("REQUISITION_ID = " + dr["REQUISITION_ID"].ToString() + "AND ITEM_ID = " + dr["ITEM_ID"].ToString());
            if (dr["REQUISITION_ID"].ToString() == "0")
            {
                inv.Request.RequestDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
            }
            else
            {
                inv.Request.dsDeleteAdd(dr);
                inv.Request.RequestDTL_InsertUpdate.Tables[0].Rows.Remove(dr);
                inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
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
                    DataRow[] dr = inv.Request.RequestDTL_InsertUpdate.Tables[0].Select("ITEM_ID = " + drItem["ITEM_ID"].ToString());
                    if (dr.Length > 0)
                    {
                        dr[0]["QTY"] = Convert.ToDecimal(dr[0]["QTY"].ToString()) + Convert.ToDecimal(delForm.ResultValue);
                        inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
                    }
                    else
                    {
                        inv.Request.dsInsertUpdateAdd(0, Convert.ToInt32(drItem["ITEM_ID"].ToString()), drItem["ITEM_NAME"].ToString(), Convert.ToDecimal(delForm.ResultValue), "", new GBLEnvVariable().OrgID, new GBLEnvVariable().UserID, new GBLEnvVariable().UserID);
                        inv.Request.RequestDTL_InsertUpdate.Tables[0].AcceptChanges();
                        grdREQUISITION_Detail.DataSource = inv.Request.RequestDTL_InsertUpdate.Tables[0];
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
                    grpRequestdetail.GroupBordersVisible = false;
                    grpRequestdetail.Expanded = false;
                    grpItem.GroupBordersVisible = false;
                    grpItem.Expanded = false;

                    btnribbonSave.Visible = false;
                    btnribbonCancel.Visible = false;
                    btnribBack.Visible = true;
                    btnribbonAdd.Visible = true;
                    btnribSavePrint.Visible = false;
                    btnribPrint.Visible = true;
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
                    ribMasterMenu.Visible = false;
                    txtREQUISITION_UID.Properties.ReadOnly = false;
                    txtREQUISITION_UID.Text = "Auto";
                    txtStatus.Text = "New";
                    txtModifiedBy.Text = "Waiting...";
                    txtModifiedOn.Text = "Waiting...";
                    txGenerateBy.Text = "Waiting...";
                    txtGenerateOn.Text = "Waiting...";

                    grpShow.GroupBordersVisible = false;
                    grpShow.Expanded = false;
                    grpRequestdetail.GroupBordersVisible = true;
                    grpRequestdetail.Expanded = true;
                    grpItem.GroupBordersVisible = true;
                    grpItem.Expanded = true;

                    txtREQUISITION_UID.Properties.ReadOnly = false;

                    btnribbonSave.Visible = true;
                    btnribbonCancel.Visible = true;
                    btnribbonAdd.Visible = false;
                    btnribbonUpdate.Visible = false;
                    btnribBack.Visible = false;
                    btnribDelete.Visible = false;
                    btnribSavePrint.Visible = true;
                    btnribPrint.Visible = false;

                    cmbFromUnit.Properties.ReadOnly = false;
                    cmbToUnit.Properties.ReadOnly = false;

                    cmbFromUnit.SelectedIndex = 0;
                    cmbToUnit.SelectedIndex = 1;
                    break;
                case GuiMode.Edit:
                    ribMasterMenu.Visible = false;
                    if (inv.Request.Request_Data.STATUS != 'N')
                    {
                        grpShow.GroupBordersVisible = true;
                        grpShow.Expanded = true;
                        grpRequestdetail.GroupBordersVisible = false;
                        grpRequestdetail.Expanded = false;
                        grpItem.GroupBordersVisible = false;
                        grpItem.Expanded = false;

                    }
                    else
                    {
                        grpShow.GroupBordersVisible = false;
                        grpShow.Expanded = false;
                        grpRequestdetail.GroupBordersVisible = true;
                        grpRequestdetail.Expanded = true;
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

                    cmbFromUnit.Properties.ReadOnly = false;
                    cmbToUnit.Properties.ReadOnly = false;
                    //grpShow.GroupBordersVisible = false;
                    //grpShow.Expanded = false;
                    //grpPRdetail.GroupBordersVisible = true;
                    //grpPRdetail.Expanded = true;
                    //grpItem.GroupBordersVisible = true;
                    //grpItem.Expanded = true;
                    //txtREQUISITION_UID.Properties.ReadOnly = true;
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
            if (inv.Request.Request_Data.REQUISITION_ID > 0)
            {
                FillDetailData(inv.Request.Request_Data.REQUISITION_ID);
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
                    inv.Request.Request_Data.REQUISITION_ID = 0;
                    inv.Request.Request_Data.REQUISITION_UID = txtREQUISITION_UID.Text;
                    inv.Request.Request_Data.FROM_UNIT = Convert.ToInt32(listUnit[cmbFromUnit.SelectedIndex]);
                    inv.Request.Request_Data.TO_UNIT = Convert.ToInt32(listUnit[cmbToUnit.SelectedIndex]);
                    inv.Request.Request_Data.ORG_ID = new GBLEnvVariable().OrgID;
                    inv.Request.Request_Data.GENERATED_BY = new GBLEnvVariable().UserID;
                    inv.Request.Request_Data.CREATED_BY = new GBLEnvVariable().UserID;
                    inv.Request.Request_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                    inv.Request.RequestManagement(DataManageType.Insert);
                    break;
                case GuiMode.Edit:
                    inv.Request.Request_Data.FROM_UNIT = Convert.ToInt32(listUnit[cmbFromUnit.SelectedIndex]);
                    inv.Request.Request_Data.TO_UNIT = Convert.ToInt32(listUnit[cmbToUnit.SelectedIndex]);
                    inv.Request.Request_Data.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
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

        private void btnBack_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FillAllData();
            ribMasterMenu.Visible = true;
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

        private void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FillAllData();
        }
    }
}