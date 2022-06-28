using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Admin
{
    public partial class INV_CATEGORY_FORM : MasterForm
    {
        DataTable gbltable = new DataTable();
        //private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();

        public INV_CATEGORY_FORM()//UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            //CloseControl = closecontrol;

            ProcessGetInvCategory select = new ProcessGetInvCategory();
            select.Invoke();
            gbltable = select.ResultTable.Copy();

            gridControl1.DataSource = gbltable.Copy();

            Grid_Columns_BestFit();
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

                EnablePropertySetup(true);

                ClearText();
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

            INV_CATEGORY common = new INV_CATEGORY();
            //common.CATEGORY_ID = int.Parse(txtID.Text);
            common.CATEGORY_UID = txtUID.Text;
            common.CATEGORY_NAME = txtName.Text;
            common.CATEGORY_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;
            try { common.PARENT = Convert.ToInt32(txtParent1.Tag); }
            catch (Exception) { common.PARENT = 0; }

            ProcessAddInvCategory insert = new ProcessAddInvCategory();
            insert.INV_CATEGORY = common;
            insert.Invoke();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                EnablePropertySetup(true);

                btnEdit.Text = "Save";

                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;
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

            INV_CATEGORY common = new INV_CATEGORY();
            common.CATEGORY_ID = int.Parse(txtID.Text);
            common.CATEGORY_UID = txtUID.Text;
            common.CATEGORY_NAME = txtName.Text;
            common.CATEGORY_DESC = txtDescription.Text;
            common.ORG_ID = new GBLEnvVariable().OrgID;
            try { common.PARENT = Convert.ToInt32(txtParent1.Tag); }
            catch (Exception) { common.PARENT = 0; }

            ProcessUpdateInvCategory update = new ProcessUpdateInvCategory();
            update.INV_CATEGORY = common;
            update.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                INV_CATEGORY common = new INV_CATEGORY();
                common.CATEGORY_ID = int.Parse(txtID.Text);

                ProcessDeleteInvCategory delete = new ProcessDeleteInvCategory();
                delete.INV_CATEGORY = common;

                try
                {
                    delete.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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

            ProcessGetInvCategory select = new ProcessGetInvCategory();
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

            gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
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
            btnOrgId.Enabled = enable;
            txtDescription.Enabled = enable;
            //gridControl1.Enabled = enable;

            btnParent.Enabled = enable;
           
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
                txtID.Text = row["CATEGORY_ID"].ToString();
                txtUID.Text = row["CATEGORY_UID"].ToString();
                txtName.Text = row["CATEGORY_NAME"].ToString();
                txtDescription.Text = row["CATEGORY_DESC"].ToString();

                txtOrdID1.Tag = row["ORG_ID"];
                txtOrdID1.Text = row["ORG_UID"].ToString();
                txtOrdID2.Text = row["ORG_NAME"].ToString();

                txtParent1.Tag = row["PARENT_ID"];
                txtParent1.Text = row["PARENT_UID"].ToString();
                txtParent2.Text = row["PARENT_NAME"].ToString();
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

            txtDescription.Text = "";

            txtParent1.Text = "";
            txtParent2.Text = "";
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

        private void btnParent_Click(object sender, EventArgs e)
        {
//            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
//            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnParent_Clicks);

//            string qry = @"
//                            select
//                                CATEGORY_ID,CATEGORY_UID,CATEGORY_NAME,PARENT
//                            from
//                                INV_CATEGORY
//                            where 
//                                CATEGORY_ID like '%%' OR CATEGORY_UID like '%%' OR
//                                CATEGORY_NAME like '%%' OR PARENT like '%%'
//                            order by CATEGORY_ID asc;
//                        ";

//            string fields = "ID, Code, Name, Parent";
//            string con = "";
//            lv.getData(qry, fields, con, "Inventory Category");
//            lv.Show();

            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnParent_Clicks);
            lv.AddColumn("CATEGORY_ID", "ID", false, true);
            lv.AddColumn("CATEGORY_UID", "Code", true, true);
            lv.AddColumn("CATEGORY_NAME", "Name", true, true);
            lv.AddColumn("CATEGORY_DESC", "Description", true, true);
            lv.Text = "Category List";

            ProcessGetInvCategory getData = new ProcessGetInvCategory();
            getData.Invoke();
            lv.Data = getData.ResultTable;
            lv.Size = new Size(600, 400);
            lv.ShowBox();

        }

        private void btnParent_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtParent1.Tag = retValue[0];
            txtParent1.Text = retValue[1];
            txtParent2.Text = retValue[2];
        }

        private bool Control_Cheking()
        {
            if (//txtID.Text.Trim() == "" ||
                txtUID.Text.Trim() == "" ||
                txtName.Text.Trim() == "" 
                //||txtDescription.Text.Trim() == "" 
                //||txtParent1.Tag == null
                )
            {
                MessageBox.Show("Infor. incomplete");
                return false;
            }

            return true;
        }

        private void INV_CATEGORY_FORM_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}