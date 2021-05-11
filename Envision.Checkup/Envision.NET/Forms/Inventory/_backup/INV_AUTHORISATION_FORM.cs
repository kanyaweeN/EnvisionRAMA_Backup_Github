using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Forms.GBLMessage;
using RIS.BusinessLogic;
using RIS.Common;

namespace RIS.Forms.Inventory
{
    public partial class INV_AUTHORISATION_FORM : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();

        public INV_AUTHORISATION_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            using (ProcessGetInvAuthorisation select = new ProcessGetInvAuthorisation())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();

                Grid_Columns_BestFit();
            }

            EnableProp_Setting(false);
        }

        private void Grid_Columns_BestFit()
        {

            foreach (DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn col in gridView1.Columns)
            {
                col.BestFit();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnAdd.Text = "Save";

                EnableProp_Setting(true);
            }
            else
            {
                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            txtUnitID1.Focus();

            using (ProcessAddInvAuthorisation insert = new ProcessAddInvAuthorisation())
            {
                INV_AUTHORISATION common = new INV_AUTHORISATION();



                insert.INV_AUTHORISATION = common;
                insert.Invoke();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {


                btnEdit.Text = "Save";
            }
            else
            {
                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        { 
        
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text.Equals("Delete"))
            {


                btnDelete.Text = "Save";
            }
            else
            {
                btnDelete_Process();
                btnCancel_Process();
                btnCancel.Text = "Delete";
            }
        }

        private void btnDelete_Process()
        { 
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";

            using (ProcessGetInvUnitReOrderLevel select = new ProcessGetInvUnitReOrderLevel())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();

                Grid_Columns_BestFit();
           }

            gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnableProp_Setting(bool enable)
        {
            txtReorderDays.Enabled = enable;
            txtReorderQty.Enabled = enable;

            btnUnitId.Enabled = enable;
            btnItemId.Enabled = enable;
            btnOrgId.Enabled = enable;

        }

        private void btnOrgId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnOrgId_Clicks);

            string qry = @"
                            select
                                ORG_ID,ORG_UID,ORG_NAME,ORG_ALIAS
                            from
                                GBL_ENV
                            where 
                                ORG_ID like '%%' OR ORG_UID like '%%' OR
                                ORG_NAME like '%%' OR ORG_ALIAS like '%%'
                            order by ORG_ID asc;
                        ";

            string fields = "ID, Code, Name, Alias";
            string con = "";
            lv.getData(qry, fields, con, "Global Environtment");
            lv.Show();
        }

        private void btnOrgId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtOrgID1.Tag = retValue[0];
            txtOrgID1.Text = retValue[1];
            txtOrgID2.Text = retValue[2];
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataTable table = (DataTable)gridControl1.DataSource;
            DataRow row = table.Rows[e.FocusedRowHandle];

            AddNewText(row);
        }

        private void gridView1_FocusedRowChanged(int focusRowHandle)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs param
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(focusRowHandle, focusRowHandle);

            gridView1_FocusedRowChanged(new object(),param);
        }

        private void AddNewText(DataRow row)
        {
            txtReorderDays.Text = row["REORDER_DAYS"].ToString();
            txtReorderQty.Text = row["REORDER_QTY"].ToString();

            txtUnitID1.Tag = row["UNIT_ID"].ToString();
            txtUnitID1.Text = row["UNIT_UID"].ToString();
            txtUnitID2.Text = row["UNIT_NAME"].ToString();

            txtItemID1.Tag = row["ITEM_ID"].ToString();
            txtItemID1.Text = row["ITEM_UID"].ToString();
            txtItemID2.Text = row["ITEM_NAME"].ToString();

            txtOrgID1.Tag = row["ORG_ID"].ToString();
            txtOrgID1.Text = row["ORG_UID"].ToString();
            txtOrgID2.Text = row["ORG_NAME"].ToString();

        }

        private void btnUnitId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnUnitId_Clicks);

            string qry = @"
                            select
                                UNIT_ID,UNIT_UID,UNIT_NAME,UNIT_DESC
                            from
                                INV_UNIT
                            where 
                                UNIT_ID like '%%' OR UNIT_UID like '%%' OR
                                UNIT_NAME like '%%' OR UNIT_DESC like '%%'
                            order by UNIT_ID asc;
                        ";

            string fields = "ID, Code, Name, Description";
            string con = "";
            lv.getData(qry, fields, con, "Inventory Unit");
            lv.Show();
        }

        private void btnUnitId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtUnitID1.Tag = retValue[0];
            txtUnitID1.Text = retValue[1];
            txtUnitID2.Text = retValue[2];
        }

        private void btnItemId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnItemId_Clicks);

            string qry = @"
                            select
                                ITEM_ID,ITEM_UID,ITEM_NAME,ITEM_DESC
                            from
                                INV_ITEM
                            where 
                                ITEM_ID like '%%' OR ITEM_UID like '%%' OR
                                ITEM_NAME like '%%' OR ITEM_DESC like '%%'
                            order by ITEM_ID asc;
                        ";

            string fields = "ID, Code, Name, Description";
            string con = "";
            lv.getData(qry, fields, con, "Inventory Item");
            lv.Show();
        }

        private void btnItemId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtItemID1.Tag = retValue[0];
            txtItemID1.Text = retValue[1];
            txtItemID2.Text = retValue[2];
        }

    }
}