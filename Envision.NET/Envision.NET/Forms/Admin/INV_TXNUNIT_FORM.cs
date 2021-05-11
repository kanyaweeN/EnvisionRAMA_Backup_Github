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
    public partial class INV_TXNUNIT_FORM : MasterForm
    {
        DataTable gbltable = new DataTable();
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        int rowIndex;
        int org_id;

        public INV_TXNUNIT_FORM()
        {
            InitializeComponent();

            ProcessGetInvTxnunit select = new ProcessGetInvTxnunit();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            try
            {
                gridControl1.DataSource = gbltable.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Grid_Columns_BestFit();
        }
        private void INV_TXNUNIT_FORM_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
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
                if (!Control_Checking()) return;

                btnAdd_Process();
                btnCancel_Process();
                btnAdd.Text = "Add";
            }
        }

        private void btnAdd_Process()
        {
            if (!Control_Checking()) return;

            INV_TXNUNIT common = new INV_TXNUNIT();
            //common.CATEGORY_ID = int.Parse(txtID.Text);
            common.TXN_UNIT_UID = txtUID.Text;
            common.TXN_UNIT_NAME = txtName.Text;
            common.TXN_UNIT_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;
            //common.EXTERNAL_UNIT = Convert.ToInt32(txtHRUnit1.Tag);

            ProcessAddInvTxnunit insert = new ProcessAddInvTxnunit();

            insert.INV_TXNUNIT = common;
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
                if (!Control_Checking()) return;

                btnEdit_Process();
                btnCancel_Process();
                btnEdit.Text = "Edit";
            }
        }

        private void btnEdit_Process()
        {
            if (!Control_Checking()) return;

            INV_TXNUNIT common = new INV_TXNUNIT();
            common.TXN_UNIT_ID = int.Parse(txtID.Text);
            common.TXN_UNIT_UID = txtUID.Text;
            common.TXN_UNIT_NAME = txtName.Text;
            common.TXN_UNIT_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;
            //common.EXTERNAL_UNIT = Convert.ToInt32(txtHRUnit1.Tag);

            ProcessUpdateInvTxnunit update = new ProcessUpdateInvTxnunit();

            update.INV_TXNUNIT = common;
            update.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_TXNUNIT common = new INV_TXNUNIT();
                common.TXN_UNIT_ID = int.Parse(txtID.Text);

                ProcessDeleteInvTxnunit delete = new ProcessDeleteInvTxnunit();
                delete.INV_TXNUNIT = common;
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

            ProcessGetInvTxnunit select = new ProcessGetInvTxnunit();
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
            catch { }

            gridView1.BestFitColumns();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //int index = CloseControl.SelectedIndex;
            //CloseControl.TabPages.RemoveAt(index);
            this.Close();
        }

        private void EnablePropertySetup(bool enable)
        {
            //txtID.Enabled = enable;
            txtUID.Enabled = enable;
            txtName.Enabled = enable;
            //btnOrgId.Enabled = enable;
            txtDescription.Enabled = enable;
            //btnHRUnit.Enabled = enable;
            //gridControl1.Enabled = enable;
           
        }

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
            txtID.Text = row["TXN_UNIT_ID"].ToString();
            txtUID.Text = row["TXN_UNIT_UID"].ToString();
            txtName.Text = row["TXN_UNIT_NAME"].ToString();
            txtDescription.Text = row["TXN_UNIT_DESC"].ToString();
            //txtOrdID1.Text = row["ORG_UID"].ToString();
            //txtOrdID2.Text = row["ORG_NAME"].ToString();
            //txtOrdID1.Tag = row["ORG_ID"];
            //org_id = Convert.ToInt32(row["ORG_ID"]);
            //txtHRUnit1.Tag = row["HR_UNIT_ID"];
            //txtHRUnit1.Text = row["HR_UNIT_UID"].ToString();
            //txtHRUnit2.Text = row["HR_UNIT_NAME"].ToString();
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
            //txtOrdID1.Text = "";
            //txtOrdID2.Text = "";

            txtDescription.Text = "";

            //txtHRUnit1.Text = "";
            //txtHRUnit2.Text = "";
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
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            //txtOrdID1.Tag = retValue[0];
            //txtOrdID1.Text = retValue[1];
            //txtOrdID2.Text = retValue[2];
            //org_id = Convert.ToInt32(retValue[0]);
        }

        private void gridView1_FocusedRowChanged(int rowindex)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs args
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(rowindex, rowindex);

            gridView1_FocusedRowChanged(this.gridView1, args);
        }

//        private void btnHRUnit_Click(object sender, EventArgs e)
//        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnHRUnit_Clicks);

//            string qry = @"
//                            select
//                                UNIT_ID,UNIT_UID,UNIT_NAME,UNIT_ALIAS
//                            from
//                                HR_UNIT
//                            where 
//                                UNIT_ID like '%%' OR UNIT_UID like '%%' OR
//                                UNIT_NAME like '%%' OR UNIT_ALIAS like '%%'
//                            order by UNIT_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Alias";
//            string con = "";
//            lv.getData(qry, fields, con, "HR Unit List");
//            lv.Show();
//        }

//        private void btnHRUnit_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
//        {
//            string[] retValue = e.NewValue.Split(new Char[] { '^' });

//            txtHRUnit1.Tag = retValue[0];
//            txtHRUnit1.Text = retValue[1];
//            txtHRUnit2.Text = retValue[2];
//        }

        private bool Control_Checking()
        {
            if (//txtID.Text.Trim().Equals("") ||
                txtUID.Text.Trim().Equals("") ||
                txtName.Text.Trim().Equals("")//||
                //txtDescription.Text.Trim().Equals("")
                )
            {
                //MessageBox.Show("Infor. incomplete");
                mymsb.ShowAlert("UID1024", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }

            return true;
        }
    }
}