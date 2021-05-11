using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class INV_VENDOR_FORM : MasterForm
    {
        DataTable gbltable = new DataTable();
        MyMessageBox mymsb = new MyMessageBox();
        int rowIndex;

        public INV_VENDOR_FORM()
        {
            InitializeComponent();

            ProcessGetInvVendor select = new ProcessGetInvVendor();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            //gridControl1.DataSource = gbltable.Copy();
            gridControl1.DataSource = gbltable.Copy();

            Grid_Columns_BestFit();
        }
        private void INV_VENDOR_FORM_Load(object sender, EventArgs e)
        {
            this.CloseWaitDialog();
        }

        private void Grid_Columns_BestFit()
        {
            gridView1.BestFitColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                btnAdd.Text = "Save";

                EnablePropertySetup(true);

                ClearText();

                rowIndex = gridView1.FocusedRowHandle;
            }
            else
            {
                if (!Control_Cheking()) return;

                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            if (!Control_Cheking()) return;

            INV_VENDOR common = new INV_VENDOR();
            common.VENDOR_UID = txtUID.Text;
            common.VENDOR_NAME = txtName.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;

            ProcessAddInvVendor insert = new ProcessAddInvVendor();
            insert.INV_VENDOR = common;
            insert.Invoke();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                EnablePropertySetup(true);

                btnEdit.Text = "Save";

                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                rowIndex = gridView1.FocusedRowHandle;
            }
            else
            {
                if (!Control_Cheking()) return;

                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        {
            if (!Control_Cheking()) return;

            INV_VENDOR common = new INV_VENDOR();
            //common.VENDOR_ID = int.Parse(txtID.Text);
            common.VENDOR_ID = Convert.ToInt32(txtUID.Tag);
            common.VENDOR_NAME = txtName.Text;
            common.VENDOR_UID = txtUID.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;

            ProcessUpdateInvVendor update = new ProcessUpdateInvVendor();
            update.INV_VENDOR = common;
            update.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUID.Tag.ToString().Length < 1) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_VENDOR common = new INV_VENDOR();
                common.VENDOR_ID = Convert.ToInt32(txtUID.Tag);

                ProcessDeleteInvVendor delete = new ProcessDeleteInvVendor();
                delete.INV_VENDOR = common;
                delete.Invoke();

                btnCancel_Process();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Process();
        }

        private void btnCancel_Process()
        {
            ClearText();

            ProcessGetInvVendor select = new ProcessGetInvVendor();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            gridControl1.DataSource = gbltable.Copy();

            Grid_Columns_BestFit();

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnDelete.Text = "Delete";

            EnablePropertySetup(false);

            gridView1.FocusedRowHandle = rowIndex;
            try
            {
                gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            { 
            
            }

            gridView1.BestFitColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnablePropertySetup(bool enable)
        {
            //txtID.Enabled = enable;
            txtUID.Enabled = enable;
            txtName.Enabled = enable;
            //btnOrgId.Enabled = enable;
            //gridControl1.Enabled = enable;
           
        }

        //private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    if (e.FocusedRowHandle > -1)
        //    {
        //        DataTable table = (DataTable)gridControl1.DataSource;
        //        DataRow row = table.Rows[e.FocusedRowHandle];

        //        AddText(row);
        //    }
        //}

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                DataTable table = (DataTable)gridControl1.DataSource;
                DataRow row = table.Rows[e.FocusedRowHandle];

                AddText(row);
            }
        }

        private void AddText(DataRow row)
        {
            //txtID.Text = row["VENDOR_ID"].ToString();
            txtUID.Tag = row["VENDOR_ID"].ToString();
            txtUID.Text = row["VENDOR_UID"].ToString();
            txtName.Text = row["VENDOR_NAME"].ToString();
            //txtOrdID1.Text = row["ORG_UID"].ToString();
            //txtOrdID2.Text = row["ORG_NAME"].ToString();
            //txtOrdID1.Tag = row["ORG_ID"];
        }

        private void ClearText()
        {
            //txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
            //txtOrdID1.Text = "";
            //txtOrdID2.Text = "";
        }

        private void btnOrgId_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnOrgId_Clicks);

//            string qry = @"
//                            select
//                                ORG_ID,ORG_UID,ORG_NAME,ORG_ALIAS
//                            from
//                                GBL_ENV
//                            where 
//                                ORG_ID like '%%' OR ORG_UID like '%%' OR
//                                ORG_NAME like '%%' OR ORG_ALIAS like '%%'
//                            order by ORG_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Alias";
//            string con = "";
//            lv.getData(qry, fields, con, "Global Environtment");
//            lv.Show();
        }

        private void btnOrgId_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });

            //txtOrdID1.Tag = retValue[0];
            //txtOrdID1.Text = retValue[1];
            //txtOrdID2.Text = retValue[2];
        }

        private void gridView1_FocusedRowChanged(int rowindex)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs args
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(rowindex, rowindex);

            gridView1_FocusedRowChanged(this.gridView1, args);
        }

        private bool Control_Cheking()
        {
            if (//txtID.Text.Trim() == "" ||
                txtUID.Text.Trim() == "" ||
                txtName.Text.Trim() == "")
            {
                //MessageBox.Show("Infor. incomplete.");
                mymsb.ShowAlert("UID1024", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }

            return true;
        }

    }
}