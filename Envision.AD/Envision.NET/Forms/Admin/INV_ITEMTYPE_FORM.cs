using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.DataAccess.Select;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class INV_ITEMTYPE_FORM : MasterForm
    {
        DataTable gbltable = new DataTable();
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        int rowIndex;

        public INV_ITEMTYPE_FORM()//(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            //CloseControl = closecontrol;

            ProcessGetInvItemtype select = new ProcessGetInvItemtype();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            gridControl1.DataSource = gbltable.Copy();

            Grid_Columns_BestFit();
        }
        private void INV_ITEMTYPE_FORM_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
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

            INV_ITEMTYPE common = new INV_ITEMTYPE();
            //common.CATEGORY_ID = int.Parse(txtID.Text);
            common.ITEMTYPE_UID = txtUID.Text;
            common.ITEMTYPE_NAME = txtName.Text;
            common.ITEMTYPE_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;

            ProcessAddInvItemtype insert = new ProcessAddInvItemtype();
            insert.INV_ITEMTYPE = common;
            insert.Invoke();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                if (gridView1.RowCount == 0) return;

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

            INV_ITEMTYPE common = new INV_ITEMTYPE();
            common.ITEMTYPE_ID = int.Parse(txtID.Text);
            common.ITEMTYPE_UID = txtUID.Text;
            common.ITEMTYPE_NAME = txtName.Text;
            common.ITEMTYPE_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;

            ProcessUpdateInvItemtype update = new ProcessUpdateInvItemtype();
            update.INV_ITEMTYPE = common;
            update.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_ITEMTYPE common = new INV_ITEMTYPE();
                common.ITEMTYPE_ID = int.Parse(txtID.Text);

                ProcessDeleteInvItemtype delete = new ProcessDeleteInvItemtype();
                delete.INV_ITEMTYPE = common;
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

            ProcessGetInvItemtype select = new ProcessGetInvItemtype();
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
            txtID.Text = row["ITEMTYPE_ID"].ToString();
            txtUID.Text = row["ITEMTYPE_UID"].ToString();
            txtName.Text = row["ITEMTYPE_NAME"].ToString();
            txtDescription.Text = row["ITEMTYPE_DESC"].ToString();
            //txtOrdID1.Text = row["ORG_UID"].ToString();
            //txtOrdID2.Text = row["ORG_NAME"].ToString();
            //txtOrdID1.Tag = row["ORG_ID"];
        }

        private void ClearText()
        {
            txtID.Text = "";
            txtUID.Text = "";
            txtName.Text = "";
            //txtOrdID1.Text = "";
            //txtOrdID2.Text = "";

            txtDescription.Text = "";

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
                txtName.Text.Trim() == "" ||
                txtDescription.Text.Trim() == "")
            {
                //MessageBox.Show("Infor. incomplete");
                mymsb.ShowAlert("UID4006", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }

            return true;
        }

    }
}