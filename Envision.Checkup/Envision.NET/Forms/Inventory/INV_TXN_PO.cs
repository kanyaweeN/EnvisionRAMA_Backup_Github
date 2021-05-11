using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Operational.Inventory;
using System.Data.SqlClient;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Inventory
{
    public partial class INV_TXN_PO : Form
    {
        InventoryStockMan invm;
        bool newInsert;
        UUL.ControlFrame.Controls.TabControl tabcontrol;
        MyMessageBox msb = new MyMessageBox();

        public INV_TXN_PO(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();

            Select_INV_ITEM();

            invm = new InventoryStockMan();

            gridControl1.DataSource = invm.PO.dsInsert.Tables[0].Clone();

            tabcontrol = closecontrol;

            txtAuth_GenOn.DateTime = txtGenOn.DateTime = DateTime.Now;
            txtAuth_GenBy.Text = txtGenBy.Text = new RIS.Common.Common.GBLEnvVariable().UserUID;
            txtAuth_GenBy.Tag = txtGenBy.Tag = new RIS.Common.Common.GBLEnvVariable().UserID;

            Database_Select_first_PO();
        }

        private void Select_INV_ITEM()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable("INV_ITEM");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = @"  SELECT INV_CATEGORY.CATEGORY_NAME, INV_CATEGORY.CATEGORY_UID, INV_ITEM.*
                                                        FROM INV_ITEM LEFT OUTER JOIN INV_CATEGORY ON INV_ITEM.CATEGORY_ID = INV_CATEGORY.CATEGORY_ID";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
            }

            gridControl2.DataSource = datatable.Copy();
        }

        private void Database_Select_first_PO()
        {
            try
            {

                //txtPrID.Properties.Items.Clear();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_PO");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select PO_ID ,PO_UID ,PO_STATUS from INV_PO";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }

                if (datatable.Rows.Count > 0)
                {
                    string pr_id = datatable.Rows[0]["PO_ID"].ToString()
                                    + "^" + datatable.Rows[0]["PO_UID"].ToString();
                    lv_ValueUpdated(new object(), new RIS.Forms.Lookup.ValueUpdatedEventArgs(pr_id));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Database_Select_first_PO_InAutorizeForm()
        {
            try
            {

                //txtPrID.Properties.Items.Clear();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_REQUISITION");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select REQUISITION_ID,REQUISITION_UID from INV_REQUISITION ";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }

                if (datatable.Rows.Count > 0)
                {
                    string pr_id = datatable.Rows[0]["REQUISITION_ID"].ToString()
                                    + "^" + datatable.Rows[0]["REQUISITION_UID"].ToString();
                    lv_ValueUpdated(new object(), new RIS.Forms.Lookup.ValueUpdatedEventArgs(pr_id));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowView vrow = (DataRowView)gridView2.GetRow(gridView2.FocusedRowHandle);
                DataRow frow = vrow.Row;

                //INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(Convert.ToInt32(frow["QTY"]));
                INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
                delForm.ShowDialog();
                if (delForm.DialogResult == DialogResult.OK)
                {
                    DataTable tb = (DataTable)gridControl1.DataSource;

                    DataRow row = tb.NewRow();

                    int k = 0;
                    foreach (DataRow rows in tb.Rows)
                    {
                        if (frow["ITEM_ID"].ToString().Equals(rows["ITEM_ID"].ToString()))
                        {
                            row["PO_ID"] = rows["PO_ID"];
                            tb.Rows.RemoveAt(k);
                            break;
                        }
                        ++k;
                    }

                    //object[] obRow = frow.ItemArray;
                    //obRow[3] = delForm.ResultValue;

                    row["PO_ID"] = invm.PO.PO_Data.PO_ID;
                    row["ITEM_ID"] = frow["ITEM_ID"];
                    row["ITEM_NAME"] = frow["ITEM_NAME"];
                    row["QTY"] = delForm.ResultValue;
                    row["ORG_ID"] = new Common.Common.GBLEnvVariable().OrgID;
                    row["CREATED_BY"] = new Common.Common.GBLEnvVariable().UserID;
                   // row["CREATED_ON"] = //DateTime.Now.ToLocalTime();
                    row["LAST_MODIFIED_BY"] = new Common.Common.GBLEnvVariable().UserID;
                   // row["LAST_MODIFIED_ON"] = DateTime.Now.ToLocalTime();

                    tb.Rows.Add(row);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowView vrow = (DataRowView)gridView1.GetRow(gridView1.FocusedRowHandle);
                DataRow frow = vrow.Row;

                DataTable tb = (DataTable)gridControl1.DataSource;
                tb.Rows.Remove(frow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveIntoDatabase()
        {
            //if (!ErrorChecking("Before SaveIntoDatabase")) return;

            try
            {
                DataTable tbNew = (DataTable)gridControl1.DataSource;
                DataTable tbOld = (DataTable)gridControl1.Tag;

                foreach (DataRow rowO in tbOld.Rows)
                {
                    bool found = false;
                    foreach (DataRow rowN in tbNew.Rows)
                    {
                        if (rowO["ITEM_ID"].ToString().Equals(rowN["ITEM_ID"].ToString()))
                        {
                            found = true;
                            rowN["CREATED_ON"] = rowO["CREATED_ON"];
                            break;
                        }
                    }

                    //don't founded
                    if (!found)
                    {
                        invm.PO.dsDeleteAdd(rowO);
                    }
                }

                invm.PO.PO_Data.PO_ID = Convert.ToInt32(txtPOUID.Tag);
                invm.PO.PO_Data.PO_UID = txtPOUID.Text;

                invm.PO.PO_Data.VENDOR_ID = Convert.ToInt32(txtVendor.Tag);
                invm.PO.PO_Data.VENDOR_NAME = txtVendor.Text;

                invm.PO.PO_Data.PR_ID = Convert.ToInt32(txtPRUID.Tag);
                invm.PO.PO_Data.PR_UID = txtPRUID.Text;

                invm.PO.PO_Data.GENERATED_ON = txtGenOn.DateTime;

                invm.PO.PO_Data.TOC = txtTOC.Text;

                invm.PO.PO_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PO.PO_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PO.PO_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.PO.dsInsert = ds.Copy();
                invm.PO.poManagement(SqlType.Update);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveIntoDatabase_newInsert()
        {
            ///if (!ErrorChecking("Before SaveIntoDatabase_newInsert")) return;

            try
            {
                DataTable tbNew = (DataTable)gridControl1.DataSource;

                //invm.PO.PO_Data.PO_ID = Convert.ToInt32(txtPOUID.Tag);
                if (txtPOUID.Text.Trim().Length < 1)
                    invm.PO.PO_Data.PO_UID = "AUTO";
                else
                    invm.PO.PO_Data.PO_UID = txtPOUID.Text;

                invm.PO.PO_Data.VENDOR_ID = Convert.ToInt32(txtVendor.Tag);
                invm.PO.PO_Data.VENDOR_NAME = txtVendor.Text;

                invm.PO.PO_Data.PR_ID = Convert.ToInt32(txtPRUID.Tag);
                invm.PO.PO_Data.PR_UID = txtPRUID.Text;

                invm.PO.PO_Data.GENERATED_ON = txtGenOn.DateTime;

                invm.PO.PO_Data.TOC = txtTOC.Text;

                invm.PO.PO_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PO.PO_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PO.PO_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.PO.dsInsert = ds.Copy();
                invm.PO.poManagement(SqlType.Insert);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ErrorChecking(string str)
        {
            if (str.Equals("Before SaveIntoDatabase"))
            {
                try { Convert.ToInt32(txtPOUID.Tag); }
                catch { return false; }
                if (txtPOUID.Text.Trim().Length < 1) return false;
            }
            else if (str.Equals("Before SaveIntoDatabase_newInsert"))
            {
                //try { Convert.ToInt32(txtPrID.Text); }
                //catch { return false; }
                try { Convert.ToInt32(txtVendor.Tag); }
                catch { return false; }
                try { Convert.ToInt32(txtPRUID.Tag); }
                catch { return false; }
                if (txtPOUID.Text.Trim().Length < 1) return false;
                DataTable tb = (DataTable)gridControl1.DataSource;
                if (tb.Rows.Count < 1) return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form_Refresh();

            newInsert = false;
        }

        private void btnSearchPOID_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_ValueUpdated);

            string qry = @"
                select
                    PO_ID
                    ,PO_UID
                    ,PO_STATUS
                from
                    INV_PO
                where 
                            PO_ID     like    '%%' 
                    or      PO_UID       like    '%%'
                    or      PO_STATUS       like    '%%'
                ";

            string fields = "ID,UID,Status";
            string con = "";
            lv.getData(qry, fields, con, "PO List");
            lv.Show();
        }

        private void lv_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPOUID.Text = retValue[1];
            txtPOUID.Tag = (object)retValue[0];

            int PO_ID;

            try { PO_ID = Convert.ToInt32(txtPOUID.Tag); }
            catch { return; }

            try
            {
                invm.PO.SelectPO(PO_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                txtPOUID.Text = invm.PO.PO_Data.PO_UID;
                txtPOUID.Tag = invm.PO.PO_Data.PO_ID;

                txtGenOn.DateTime = invm.PO.PO_Data.GENERATED_ON.ToLocalTime();
                txtVendor.Text = invm.PO.PO_Data.VENDOR_NAME;
                txtVendor.Tag = invm.PO.PO_Data.VENDOR_ID;

                txtPRUID.Text = invm.PO.PO_Data.PR_UID;
                txtPRUID.Tag = invm.PO.PO_Data.PR_ID;

                txtTOC.Text = invm.PO.PO_Data.TOC;

                txtGenBy.Text = invm.PO.PO_Data.CREATED_BY.ToString();
                txtGenOn.DateTime = invm.PO.PO_Data.CREATED_ON;

                //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                gridControl1.DataSource = invm.PO.PO_Data.PO_Detail.Tables[0].Copy();
                gridControl1.Tag = invm.PO.PO_Data.PO_Detail.Tables[0].Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int i = invm.PO.PO_Data.PO_ID;
                invm.PO.poManagement(SqlType.Delete);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Form_Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!newInsert)
            {
                if (!ErrorChecking("Before SaveIntoDatabase")) return;
                SaveIntoDatabase();
            }
            else
            {
                if (!ErrorChecking("Before SaveIntoDatabase_newInsert")) return;
                SaveIntoDatabase_newInsert();
            }

            msb.ShowAlert("UID2002", 1);

            Form_Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = tabcontrol.SelectedIndex;
            tabcontrol.TabPages.RemoveAt(index);
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_Vendor);

            string qry = @"
                select
                    VENDOR_ID
                    ,VENDOR_UID
                    ,VENDOR_NAME
                from
                    INV_VENDOR
                where 
                            VENDOR_ID     like    '%%' 
                    or      VENDOR_UID       like    '%%'
                    or      VENDOR_NAME       like    '%%'
                ";

            string fields = "ID,UID,Name";
            string con = "";
            lv.getData(qry, fields, con, "Vendor List");
            lv.Show();
        }

        private void lv_Vendor(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtVendor.Text = retValue[2];
            txtVendor.Tag = (object)retValue[0];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form_Refresh();
        }

        private void btnPRUID_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_PRUID);

            string qry = @"
                select
                    PR_ID
                    ,PR_UID
                    ,PR_STATUS
                from
                    INV_PR
                where 
                            PR_ID     like    '%%' 
                    or      PR_UID       like    '%%'
                    or      PR_STATUS       like    '%%'
                ";

            string fields = "ID,UID,Status";
            string con = "";
            lv.getData(qry, fields, con, "PR List");
            lv.Show();
        }

        private void lv_PRUID(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPRUID.Text = retValue[1];
            txtPRUID.Tag = (object)retValue[0];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnRefresh.Visible = false;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            gridControl2.Enabled = true;
            gridControl1.Enabled = true;

            btnSearchPRID.Enabled = false;
            btnVendor.Enabled = true;
            btnPRUID.Enabled = true;

            txtPOUID.Text = "";
            //txtPOUID.Tag = null;
            txtPOUID.Properties.ReadOnly = false;

            txtGenOn.DateTime = DateTime.Now;

            txtTOC.Enabled = true;

            DataTable tb = (DataTable)gridControl1.DataSource;
            tb.Rows.Clear();

            newInsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnRefresh.Visible = false;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            gridControl2.Enabled = true;
            gridControl1.Enabled = true;

            btnSearchPRID.Enabled = false;
            btnVendor.Enabled = true;
            btnPRUID.Enabled = true;

            txtPRUID.Properties.ReadOnly = false;
            txtTOC.Enabled = true;

            newInsert = false;
        }

        private void Form_Refresh()
        {
            btnSearchPRID.Enabled = true;
            btnVendor.Enabled = false;
            btnPRUID.Enabled = false;

            //txtPOUID.Text = "";
            //txtPOUID.Tag = null;
            txtPOUID.Properties.ReadOnly = true;

            //txtGenOn.DateTime = DateTime.Now;

            txtTOC.Enabled = false;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnRefresh.Visible = true;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            gridControl2.Enabled = false;
            gridControl1.Enabled = false;


            int PO_ID;

            try { PO_ID = Convert.ToInt32(txtPOUID.Tag); }
            catch { return; }

            try
            {
                invm.PO.SelectPO(PO_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                if (invm.PO.PO_Data.PO_Detail != null)
                {
                    //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                    txtPOUID.Text = invm.PO.PO_Data.PO_UID;
                    txtPOUID.Tag = invm.PO.PO_Data.PO_ID;

                    txtPRUID.Text = invm.PO.PO_Data.PR_UID;
                    txtPRUID.Tag = invm.PO.PO_Data.PR_ID;

                    txtVendor.Text = invm.PO.PO_Data.VENDOR_NAME;
                    txtVendor.Tag = invm.PO.PO_Data.VENDOR_ID;

                    try
                    {
                        txtGenOn.DateTime = invm.PR.PR_Data.GENERATED_ON;
                    }
                    catch { txtGenOn.DateTime = DateTime.Now; }

                    txtTOC.Text = invm.PO.PO_Data.TOC;

                    //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                    gridControl1.DataSource = invm.PO.PO_Data.PO_Detail.Tables[0].Copy();
                    gridControl1.Tag = invm.PO.PO_Data.PO_Detail.Tables[0].Copy();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Select_INV_ITEM();

            invm.PO.dsDelete.Tables[0].Rows.Clear();
        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            //InventoryStockMan sm = new InventoryStockMan();
            //sm.PO.BuildPO_FromAuthorizer();

            
            DataSet ds = new DataSet();
            DataTable tb = (DataTable)gridControl3.DataSource;
            ds.Tables.Add(tb);
            invm.Authorization.dsInsert = ds;
            if (!invm.Authorization.AuthorizationAcceptChange())
                MessageBox.Show("AuthorizationAcceptChange Error!!");

            //invm.Authorization.SelectAuthorization("");
            //invm.Authorization.dsInsert.Clear();            
        }

        private void btnGenPO_Click(object sender, EventArgs e)
        {
            //InventoryStockMan sm = new InventoryStockMan();
            //sm.Authorization.dsInsert = TableLayoutCellPaintEventArgs;
            //sm.Authorization.AuthorizationAcceptChange();
            //sm.PO.BuildPO_FromAuthorizer();

            try
            {
                DataSet dataset = new DataSet();
                DataTable table = (DataTable)gridControl3.DataSource;
                dataset.Tables.Add(table.Copy());
                invm.Authorization.dsInsert = dataset;

                invm.Authorization.AuthorizationAcceptChange();

                INV_TXN_PO_Autorization_Dialog poAuth = new INV_TXN_PO_Autorization_Dialog();
                if (poAuth.ShowDialog() == DialogResult.OK)
                {
                    string po_uid = poAuth.PO_UID;
                    int pr_id = txtAuth_PRUID.Tag.ToString() == "" ? 0 : Convert.ToInt32(txtAuth_PRUID.Tag);
                    int vendor_id = poAuth.VENDOR_ID;
                    string toc = poAuth.TOC;
                    int org_id = new Common.Common.GBLEnvVariable().OrgID;
                    int created_by = new Common.Common.GBLEnvVariable().UserID;
                    int last_modified_by = new Common.Common.GBLEnvVariable().UserID;

                    invm.PO.BuildPO_FromAuthorizer(po_uid, pr_id, vendor_id, toc, org_id, created_by, last_modified_by);
                }          
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //InventoryStockMan sm = new InventoryStockMan();
            //sm.PO.poManagement(SqlType.
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "xtraTabPage2")
            {
                try
                {
                    int pr_id = Convert.ToInt32(txtAuth_PRUID.Tag);
                    invm.Authorization.SelectAuthorization(pr_id);

                    gridControl3.DataSource = invm.Authorization.dsInsert.Tables[0].Copy();
                }
                catch { }
            }    

        }

        private void btnAuth_PRUID_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_Auth_PRUID);

            string qry = @"
                select
                    PR_ID
                    ,PR_UID
                    ,PR_STATUS
                from
                    INV_PR
                where 
                    (
                        PR_ID     like    '%%' 
                        or      PR_UID       like    '%%'
                        or      PR_STATUS       like    '%%'
                    ) 
                    and (   PR_STATUS = 'N' or PR_STATUS = 'A'  )
                ";

            string fields = "ID,UID,Status";
            string con = "";
            lv.getData(qry, fields, con, "PR List");
            lv.Show();
        }

        private void lv_Auth_PRUID(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtAuth_PRUID.Text = retValue[1];
            txtAuth_PRUID.Tag = (object)retValue[0];

            try
            {
                int pr_id = Convert.ToInt32(txtAuth_PRUID.Tag);
                invm.Authorization.SelectAuthorization(pr_id);

                gridControl3.DataSource = invm.Authorization.dsInsert.Tables[0].Copy();
            }
            catch { }
        }

        private void btnGrid2Add_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView2_AddItem();
        }

        private void gridView2_AddItem()
        {
            try
            {
                System.Data.DataRowView vrow = (DataRowView)gridView2.GetRow(gridView2.FocusedRowHandle);
                DataRow frow = vrow.Row;

                //INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(Convert.ToInt32(frow["QTY"]));
                INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
                delForm.ShowDialog();
                if (delForm.DialogResult == DialogResult.OK)
                {
                    DataTable tb = (DataTable)gridControl1.DataSource;

                    DataRow row = tb.NewRow();

                    int k = 0;
                    foreach (DataRow rows in tb.Rows)
                    {
                        if (frow["ITEM_ID"].ToString().Equals(rows["ITEM_ID"].ToString()))
                        {
                            row["PO_ID"] = rows["PO_ID"];
                            tb.Rows.RemoveAt(k);
                            break;
                        }
                        ++k;
                    }

                    //object[] obRow = frow.ItemArray;
                    //obRow[3] = delForm.ResultValue;

                    row["PO_ID"] = invm.PO.PO_Data.PO_ID;
                    row["ITEM_ID"] = frow["ITEM_ID"];
                    row["ITEM_NAME"] = frow["ITEM_NAME"];
                    row["QTY"] = delForm.ResultValue;
                    row["ORG_ID"] = new Common.Common.GBLEnvVariable().OrgID;
                    row["CREATED_BY"] = new Common.Common.GBLEnvVariable().UserID;
                    // row["CREATED_ON"] = //DateTime.Now.ToLocalTime();
                    row["LAST_MODIFIED_BY"] = new Common.Common.GBLEnvVariable().UserID;
                    // row["LAST_MODIFIED_ON"] = DateTime.Now.ToLocalTime();

                    tb.Rows.Add(row);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}