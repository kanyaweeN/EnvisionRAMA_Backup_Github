using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Admin
{
    public partial class INV_ITEMSTATUS_FORM : Form
    {
        DataTable gbltable = new DataTable();
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        int rowIndex;

        public INV_ITEMSTATUS_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            ProcessGetInvItemstatus select = new ProcessGetInvItemstatus();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            gridControl1.DataSource = gbltable.Copy();

            Grid_Columns_BestFit();
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

            INV_ITEMSTATUS common = new INV_ITEMSTATUS();
            common.ITEMSTATUS_UID = txtUID.Text;
            common.ITEMSTATUS_NAME = txtName.Text;
            common.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

            ProcessAddInvItemstatus insert = new ProcessAddInvItemstatus();
            insert.INV_ITEMSTATUS = common;
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

            INV_ITEMSTATUS common = new INV_ITEMSTATUS();
            common.ITEMSTATUS_ID = int.Parse(txtID.Text);
            common.ITEMSTATUS_UID = txtUID.Text;
            common.ITEMSTATUS_NAME = txtName.Text;
            common.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

            ProcessUpdateInvItemstatus update = new ProcessUpdateInvItemstatus();
            update.INV_ITEMSTATUS = common;
            update.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_ITEMSTATUS common = new INV_ITEMSTATUS();
                common.ITEMSTATUS_ID = int.Parse(txtID.Text);

                ProcessDeleteInvItemstatus delete = new ProcessDeleteInvItemstatus();
                delete.INV_ITEMSTATUS = common;
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

            ProcessGetInvItemstatus select = new ProcessGetInvItemstatus();
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnablePropertySetup(bool enable)
        {
            //txtID.Enabled = enable;
            txtUID.Enabled = enable;
            txtName.Enabled = enable;
            btnOrgId.Enabled = enable;
            //txtDescription.Enabled = enable;
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
            try
            {
                txtID.Text = row["ITEMSTATUS_ID"].ToString();
                txtUID.Text = row["ITEMSTATUS_UID"].ToString();
                txtName.Text = row["ITEMSTATUS_NAME"].ToString();
                //txtDescription.Text = row["ITEMTYPE_DESC"].ToString();
                txtOrdID1.Text = row["ORG_UID"].ToString();
                txtOrdID2.Text = row["ORG_NAME"].ToString();
                txtOrdID1.Tag = row["ORG_ID"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
            txtOrdID1.Text = "";
            txtOrdID2.Text = "";

            //txtDescription.Text = "";

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

        private void gridView1_FocusedRowChanged(int rowindex)
        {
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs args 
                = new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(rowindex,rowindex);

            gridView1_FocusedRowChanged(this.gridView1, args);
        }

        private bool Control_Cheking()
        {
            if (//txtID.Text.Trim() == "" ||
                txtUID.Text.Trim() == "" ||
                txtName.Text.Trim() == "")
            {
                MessageBox.Show("Infor. incomplete.");
                return false;
            }

            return true;
        }

    }
}