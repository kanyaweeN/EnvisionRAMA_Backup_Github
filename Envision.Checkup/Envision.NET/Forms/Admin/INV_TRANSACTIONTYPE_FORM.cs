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

namespace RIS.Forms.Admin
{
    public partial class INV_TRANSACTIONTYPE_FORM : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        int rowIdex;

        public INV_TRANSACTIONTYPE_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            using (ProcessGetInvTransactionType select = new ProcessGetInvTransactionType())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();
            }

            EnableProp_Setting(false);

            gridView1.BestFitColumns();
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

                Cleartext();

                rowIdex = gridView1.FocusedRowHandle;
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

            using (ProcessAddInvTransactionType insert = new ProcessAddInvTransactionType())
            {
                INV_TRANSACTIONTYPE common = new INV_TRANSACTIONTYPE();

                //common.TRANSACTIONTYPE_ID = int.Parse(txtID.Text);                
                common.TRANSACTIONTYPE_UID = txtUID.Text;
                common.TRANSACTIONTYPE_NAME = txtName.Text;
                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                insert.INV_TRANSACTIONTYPE = common;
                insert.Invoke();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                EnableProp_Setting(true);

                btnEdit.Text = "Save";

                rowIdex = gridView1.FocusedRowHandle;
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

            using (ProcessUpdateInvTransactionType update = new ProcessUpdateInvTransactionType())
            {
                INV_TRANSACTIONTYPE common = new INV_TRANSACTIONTYPE();

                common.TRANSACTIONTYPE_ID = int.Parse(txtID.Text);                
                common.TRANSACTIONTYPE_UID = txtUID.Text;
                common.TRANSACTIONTYPE_NAME = txtName.Text;
                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                update.INV_TRANSACTIONTYPE = common;
                update.Invoke();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_TRANSACTIONTYPE common = new INV_TRANSACTIONTYPE();
                common.TRANSACTIONTYPE_ID = int.Parse(txtID.Text);

                ProcessDeleteInvTransactionType delete = new ProcessDeleteInvTransactionType();
                delete.INV_TRANSACTIONTYPE = common;
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
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = false;

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";

            using (ProcessGetInvTransactionType select = new ProcessGetInvTransactionType())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();
            }

            Cleartext();

            gridView1.FocusedRowHandle = rowIdex;
            try
            {
                gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gridView1.BestFitColumns();

            EnableProp_Setting(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnableProp_Setting(bool enable)
        {
            //txtID.Enabled = enable;
            txtUID.Enabled = enable;
            txtName.Enabled = enable;
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

            txtOrdID1.Tag = retValue[0];
            txtOrdID1.Text = retValue[1];
            txtOrdID2.Text = retValue[2];
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                DataTable table = (DataTable)gridControl1.DataSource;
                DataRow row = table.Rows[e.FocusedRowHandle];


                AddNewText(row);
            }
        }

        private void gridView1_FocusedRowChanged(int focusRowHandle)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs param
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(focusRowHandle, focusRowHandle);

            gridView1_FocusedRowChanged(new object(),param);
        }

        private void AddNewText(DataRow row)
        {
            try
            {
                txtID.Text = row["TRANSACTIONTYPE_ID"].ToString();
                txtUID.Text = row["TRANSACTIONTYPE_UID"].ToString();
                txtName.Text = row["TRANSACTIONTYPE_NAME"].ToString();

                txtOrdID1.Tag = row["ORG_ID"].ToString();
                txtOrdID1.Text = row["ORG_UID"].ToString();
                txtOrdID2.Text = row["ORG_NAME"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Cleartext()
        {
            txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
        }

        private bool Control_Checking()
        {
            if (//txtID.Text.Trim().Equals("") ||
                txtUID.Text.Trim().Equals("") ||
                txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Infor. incomplete");
                return false;
            }

            return true;
        }
    }
}