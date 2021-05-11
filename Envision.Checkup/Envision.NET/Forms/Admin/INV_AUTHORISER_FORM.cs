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
    public partial class INV_AUTHORISER_FORM : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        MyMessageBox mymsb = new MyMessageBox();
        int rowindex;

        public INV_AUTHORISER_FORM(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            using (ProcessGetInvAuthoriser select = new ProcessGetInvAuthoriser())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();

                Grid_Columns_BestFit();

            }

            EnableProp_Setting(false);
        }

        private void Grid_Columns_BestFit()
        {
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

                rowindex = gridView1.FocusedRowHandle;

                Clear_ALLText();
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
            if (!Control_Cheking()) return;
            if (!EmpID_AlreadyHas()) return;

            using (ProcessAddInvAuthoriser insert = new ProcessAddInvAuthoriser())
            {
                INV_AUTHORISER common = new INV_AUTHORISER();

                //common.AUTHORISER_ID = int.Parse(txtAuthorID.Text);
                common.EMP_ID = Convert.ToInt32(txtEmpID1.Tag);
                common.SERIAL = Convert.ToInt32(txtSerialNum.Value);
                common.AUTH_TYPE = txtAuthorType.SelectedIndex.ToString();
                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                insert.INV_AUTHORISER = common;
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

                btnEdit.Text = "Save";

                EnableProp_Setting(true);

                rowindex = gridView1.FocusedRowHandle;

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
            if (!Control_Cheking()) return;

            using(ProcessUpdateInvAuthoriser update = new ProcessUpdateInvAuthoriser())
            {
                INV_AUTHORISER common = new INV_AUTHORISER();

                common.AUTHORISER_ID = int.Parse(txtAuthorID.Text);
                common.EMP_ID = Convert.ToInt32(txtEmpID1.Tag);
                common.SERIAL = Convert.ToInt32(txtSerialNum.Value);
                common.AUTH_TYPE = txtAuthorType.SelectedIndex.ToString();
                common.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                common.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;

                update.INV_AUTHORISER = common;
                update.Invoke();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtAuthorID.Text.Trim().Equals("")) return;

            if (mymsb.ShowAlert("UID2003", 1) == "2")
            {
                using (ProcessDeleteInvAuthoriser delete = new ProcessDeleteInvAuthoriser())
                {
                    INV_AUTHORISER common = new INV_AUTHORISER();

                    common.AUTHORISER_ID = int.Parse(txtAuthorID.Text);

                    delete.INV_AUTHORISER = common;
                    delete.Invoke();
                }
            }

            btnCancel_Process();
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

            using (ProcessGetInvAuthoriser select = new ProcessGetInvAuthoriser())
            {
                select.Invoke();
                gridControl1.DataSource = select.ResultTable.Copy();

                Grid_Columns_BestFit();
           }

            gridView1.FocusedRowHandle = rowindex;
            try
            {
                gridView1_FocusedRowChanged(gridView1.FocusedRowHandle);
            }
            catch
            { 
                
            }

            EnableProp_Setting(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = CloseControl.SelectedIndex;
            CloseControl.TabPages.RemoveAt(index);
        }

        private void EnableProp_Setting(bool enable)
        {
            //txtAuthorID.Enabled = enable;
            txtAuthorType.Enabled = enable;
            txtSerialNum.Enabled = enable;


            btnEmpId.Enabled = enable;
            btnOrgId.Enabled = enable;

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                Clear_ALLText();
                return;
            }

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
            try
            {
                txtAuthorID.Text = row["AUTHORISER_ID"].ToString();
                txtAuthorType.SelectedIndex = Convert.ToInt32(row["AUTH_TYPE"]);
                txtSerialNum.Text = row["SERIAL"].ToString();

                txtEmpID1.Tag = row["EMP_ID"].ToString();
                txtEmpID1.Text = row["EMP_UID"].ToString();
                txtEmpID2.Text = row["USER_NAME"].ToString();

                txtOrgID1.Tag = row["ORG_ID"].ToString();
                txtOrgID1.Text = row["ORG_UID"].ToString();
                txtOrgID2.Text = row["ORG_NAME"].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void btnEmpId_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(btnEmpId_Clicks);

            string qry = @"
                            select
                                EMP_ID,EMP_UID,USER_NAME,FNAME,LNAME
                            from
                                HR_EMP
                            where 
                                EMP_ID like '%%' OR EMP_UID like '%%' OR
                                USER_NAME like '%%' OR FNAME like '%%' OR LNAME like '%%'
                            order by EMP_ID asc;
                        ";

            string fields = "ID, Code, User Name, First Name, Last Name";
            string con = "";
            lv.getData(qry, fields, con, "HR_EMP USER LIST");
            lv.Show();
        }

        private void btnEmpId_Clicks(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            txtEmpID1.Tag = retValue[0];
            txtEmpID1.Text = retValue[1];
            txtEmpID2.Text = retValue[2];
        }

        private void gridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable table = (DataTable)gridControl1.DataSource;

            table.Columns.Add(new DataColumn("TYPE_NAME",typeof(string)));

            foreach (DataRow row in table.Rows)
            {
                int index = Convert.ToInt32(row["AUTH_TYPE"]);

                switch (index)
                {
                    case 0: row["TYPE_NAME"] = "PR";
                        break;
                    case 1: row["TYPE_NAME"] = "PO";
                        break;
                    case 2: row["TYPE_NAME"] = "BOTH";
                        break;
                }
            }
        }

        private bool Control_Cheking()
        {
            if (//txtAuthorID.Text.Trim() == "" ||
                txtAuthorType.Text.Trim() == "" ||
                txtSerialNum.Text.Trim() == "" ||
                txtEmpID1.Tag == null)
            {
                MessageBox.Show("Infor. not completed");
                return false;
            }

            return true;
        }

        private void Clear_ALLText()
        {
            try
            {
                txtAuthorID.Text = "";
                txtAuthorType.SelectedIndex = -1;
                txtSerialNum.Text = "";

                txtEmpID1.Tag = null;
                txtEmpID1.Text = "";
                txtEmpID2.Text = "";

                txtOrgID1.Tag = new global::RIS.Common.Common.GBLEnvVariable().OrgID;
                txtOrgID1.Text = "";
                txtOrgID2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool EmpID_AlreadyHas()
        {
            int empid = Convert.ToInt32(txtEmpID1.Tag);
            DataTable table = (DataTable)gridControl1.DataSource;

            foreach (DataRow row in table.Rows)
            {
                int EMP_ID = Convert.ToInt32(row["EMP_ID"]);
                if (empid == EMP_ID)
                {
                    MessageBox.Show("Database already has this Employee !!");
                    return false;
                }
            }

            return true;
        }

    }
}