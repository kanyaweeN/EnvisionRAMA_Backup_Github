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
    public partial class INV_TXN_PR : Form
    {
        InventoryStockMan invm;
        int comboIndex;
        bool newInsert;
        UUL.ControlFrame.Controls.TabControl tabcontrol;
        MyMessageBox msb = new MyMessageBox();

        public INV_TXN_PR(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();

            Combobox_InsertItem();

            Select_INV_ITEM();

            try { txtPrID.SelectedIndex = 0; }
            catch { }

            invm = new InventoryStockMan();

            Database_Initgridcontrol1();

            //btnSearchPRID_Click(new object(), new EventArgs());
            //lv_ValueUpdated(new object(), new RIS.Forms.Lookup.ValueUpdatedEventArgs(

            Database_Select_first_PR();

            tabcontrol = closecontrol;

            AddColumn_button();
        }

        private void AddColumn_button()
        {
            DataTable table = (DataTable)gridControl1.DataSource;

            table.Columns.Add(new DataColumn("btnDelete"));

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

        private void Database_Initgridcontrol1()
        {
            //invm.PR.SelectPR(PR_ID);
            gridControl1.DataSource = invm.PR.dsInsert.Tables[0].Copy();
        }

        private void Database_Select_first_PR()
        {
            try
            {

                //txtPrID.Properties.Items.Clear();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_PR");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select PR_ID,PR_UID from INV_PR ";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }

                if (datatable.Rows.Count > 0)
                {
                    string pr_id = datatable.Rows[0]["PR_ID"].ToString()
                                    + "^" + datatable.Rows[0]["PR_UID"].ToString();
                    lv_ValueUpdated(new object(), new RIS.Forms.Lookup.ValueUpdatedEventArgs(pr_id));
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Combobox_InsertItem()
        {
            try
            {

                txtPrID.Properties.Items.Clear();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_PR");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select PR_ID from INV_PR ";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }

                foreach (DataRow row in datatable.Rows)
                {
                    try { txtPrID.Properties.Items.Add(Convert.ToInt32(row[0])); }
                    catch { }
                }
            }
            catch(Exception ex)
            { 
                
            }
        }

        private void txtPrID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPrID.SelectedIndex < 0) return;

            int PR_ID;

            try { PR_ID = Convert.ToInt32(txtPrID.Text); }
            catch { return; }

            invm.PR.SelectPR(PR_ID);

            //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
            txtPrUID.Text = invm.PR.PR_Data.PR_UID;

            //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
            gridControl1.DataSource = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
            gridControl1.Tag = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();

            comboIndex = txtPrID.SelectedIndex;
        }

        private void comboBoxEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPrID.SelectedIndex < 0) return;

            int PR_ID;

            try {PR_ID = Convert.ToInt32(txtPrID.Text); }
            catch { return; }

            invm.PR.SelectPR(PR_ID);

            //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
            txtPrUID.Text = invm.PR.PR_Data.PR_UID;

            //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
            gridControl1.DataSource = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
            gridControl1.Tag = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();

            comboIndex = PR_ID;
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

            return;

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

                    DateTime datetime = new DateTime();

                    int k = 0;
                    foreach (DataRow rows in tb.Rows)
                    {
                        if (frow["ITEM_ID"].ToString().Equals(rows["ITEM_ID"].ToString()))
                        {
                            try
                            {
                                datetime = (DateTime)rows["CREATED_ON"];
                            }
                            catch {}

                            row["PR_ID"] = rows["PR_ID"];
                            tb.Rows.RemoveAt(k);
                            break;
                        }
                        ++k;
                    }

                    //object[] obRow = frow.ItemArray;
                    //obRow[3] = delForm.ResultValue;

                    row["PR_ID"] = invm.PR.PR_Data.PR_ID;
                    row["ITEM_ID"] = frow["ITEM_ID"];
                    row["ITEM_NAME"] = frow["ITEM_NAME"];
                    if (datetime.Year > 1)
                        row["CREATED_ON"] = datetime;
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
            return;

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

        private void GenerateNewPRID()
        {
            int newPRID = 0;
            foreach (int//DevExpress.XtraEditors.Controls.ComboBoxItemCollection
                itemidx in txtPrID.Properties.Items)
            {
                newPRID++;

                if (newPRID != itemidx) break;
            }

            txtPrID.Text = newPRID.ToString();
        }

        private void Form_Refresh()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnRefresh.Visible = true;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            gridControl2.Enabled = false;
            gridControl1.Enabled = false;

            btnSearchPRID.Enabled = true;
            txtPrUID.ReadOnly = true;
            txtPrUID.Enabled = false;
            //txtPrID.Properties.ReadOnly = false;

            //Combobox_InsertItem();
            int PR_ID;

            try { PR_ID = Convert.ToInt32(txtPrUID.Tag); }
            catch { return; }

            try
            {
                invm.PR.SelectPR(PR_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                if (invm.PR.PR_Data.PR_Detail != null)
                {
                    //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                    txtPrUID.Text = invm.PR.PR_Data.PR_UID;
                    txtPrUID.Tag = invm.PR.PR_Data.PR_ID;
                    txtGenBy.Text = invm.PR.PR_Data.GENERATED_BY.ToString()
                                    + " - " + invm.PR.PR_Data.GENERATED_BY_TEXT;
                    txtGenBy.Tag = invm.PR.PR_Data.GENERATED_BY;
                    txtGenOn.DateTime = invm.PR.PR_Data.GENERATED_ON;

                    //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                    gridControl1.DataSource = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                    gridControl1.Tag = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                }
                else
                {
                    Database_Select_first_PR();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //txtPrID.SelectedIndex = -1;
            //txtPrID.SelectedIndex = comboIndex;

            Select_INV_ITEM();

            invm.PR.dsDelete.Tables[0].Rows.Clear();
        }

        private void btnSearchPRID_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_ValueUpdated);

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

        private void lv_ValueUpdated(object sender, RIS.Forms.Lookup.ValueUpdatedEventArgs e)
        {
            //string[] retValue = e.NewValue.Split(new Char[] { '^' });

            //int selValue;
            //try
            //{
            //    selValue = Convert.ToInt32(retValue[0]);


            //    int selIndex = 0;
            //    foreach (int itemidx in txtPrID.Properties.Items)
            //    {
            //        if (itemidx == selValue) break;

            //        selIndex++;
            //    }

            //    txtPrID.SelectedIndex = -1;
            //    txtPrID.SelectedIndex = selIndex;

            //}
            //catch (Exception ex)
            //{
            //    txtPrID.SelectedIndex = -1;
            //    txtPrID.SelectedIndex = comboIndex;
            //}

            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            txtPrUID.Text = retValue[1];
            txtPrUID.Tag = (object)retValue[0];

            int PR_ID;

            try { PR_ID = Convert.ToInt32(txtPrUID.Tag); }
            catch { return; }

            try
            {
                invm.PR.SelectPR(PR_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                txtPrUID.Text = invm.PR.PR_Data.PR_UID;
                txtPrUID.Tag = invm.PR.PR_Data.PR_ID;
                txtGenBy.Text = invm.PR.PR_Data.GENERATED_BY.ToString()
                                + " - " + invm.PR.PR_Data.GENERATED_BY_TEXT;
                txtGenBy.Tag = invm.PR.PR_Data.GENERATED_BY;
                //txtGenOn.Text = invm.PR.PR_Data.GENERATED_ON.ToShortDateString();
                txtGenOn.DateTime = invm.PR.PR_Data.GENERATED_ON;

                //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                gridControl1.DataSource = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                gridControl1.Tag = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            txtPrUID.Enabled = true;
            txtPrUID.ReadOnly = false;

            //txtPrID.Properties.ReadOnly = true;

            //txtPrID.Text = "";
            txtPrUID.Text = "";
            txtGenBy.Text = new Common.Common.GBLEnvVariable().UserUID;
            txtPrUID.ReadOnly = false;
            txtPrUID.Text = "AUTO";
            txtGenOn.DateTime = DateTime.Now;

            DataTable tb = (DataTable)gridControl1.DataSource;
            try
            {
                tb.Rows.Clear();
            }
            catch
            {

            }

            newInsert = true;

            //GenerateNewPRID();

            gridView2.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //gridView2.Focus();
            
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnRefresh.Visible = false;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            gridControl2.Enabled = true;
            gridControl1.Enabled = true;

            btnSearchPRID.Enabled = false;
            txtPrUID.Enabled = true;
            txtPrUID.ReadOnly = false;
            //txtPrID.Properties.ReadOnly = true;

            //txtPrID.Text = "";
            //txtPrUID.Text = "";

            //DataTable tb = (DataTable)gridControl1.DataSource;
            //tb.Rows.Clear();

            newInsert = false;

            gridView2.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (msb.ShowAlert("UID2003", 1) == "2")
            {
                try
                {
                    int k = 0;
                    while (k < 3)
                    {
                        int i = invm.PR.PR_Data.PR_ID;
                        invm.PR.prManagement(SqlType.Delete);
                        k++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //comboIndex = 0;

                Form_Refresh();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Form_Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form_Refresh();

            newInsert = false;
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
                        invm.PR.dsDeleteAdd(rowO);
                    }
                }

                invm.PR.PR_Data.PR_ID = Convert.ToInt32(txtPrUID.Tag);
                invm.PR.PR_Data.PR_UID = txtPrUID.Text;
                invm.PR.PR_Data.GENERATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.PR.dsInsert = ds.Copy();
                invm.PR.prManagement(SqlType.Update);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveIntoDatabase_newInsert()
        {
            //if (!ErrorChecking("Before SaveIntoDatabase_newInsert")) return;

            try
            {
                DataTable tbNew = (DataTable)gridControl1.DataSource;

                invm.PR.PR_Data.PR_ID = 0;
                if (txtPrUID.Text.Trim().Length < 1 || txtPrUID.Text.ToUpper() == "AUTO")
                    invm.PR.PR_Data.PR_UID = "AUTO";
                else invm.PR.PR_Data.PR_UID = txtPrUID.Text;
                invm.PR.PR_Data.GENERATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.PR.PR_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.PR.dsInsert = ds.Copy();
                invm.PR.prManagement(SqlType.Insert);
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
                //try { Convert.ToInt32(txtPrUID.Tag); }
                //catch { msb.ShowAlert("UID2001", 1); return false; }
                if (txtPrUID.Text.Trim().Length < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
                DataTable tb = (DataTable)gridControl1.DataSource;
                if (tb.Rows.Count < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
            }
            else if (str.Equals("Before SaveIntoDatabase_newInsert"))
            {
                //try { Convert.ToInt32(txtPrID.Text); }
                //catch { return false; }
                //if (txtPrUID.Text.Trim().Length < 1) return false;
                if (txtPrUID.Text.Trim().Length < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
                DataTable tb = (DataTable)gridControl1.DataSource;
                if (tb.Rows.Count < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = tabcontrol.SelectedIndex;
            tabcontrol.TabPages.RemoveAt(index);
        }

        private void btnColDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                try
                {
                    System.Data.DataRowView vrow = (DataRowView)gridView1.GetRow(focus);
                    DataRow frow = vrow.Row;

                    DataTable tb = (DataTable)gridControl1.DataSource;
                    tb.Rows.Remove(frow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gridView2_AddItem()
        {
            int focus = gridView2.FocusedRowHandle;
            if (focus > -1)
            {
                try
                {
                    System.Data.DataRowView vrow = (DataRowView)gridView2.GetRow(focus);
                    DataRow frow = vrow.Row;

                    //INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(Convert.ToInt32(frow["QTY"]));
                    INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(double.MaxValue);
                    delForm.ShowDialog();
                    if (delForm.DialogResult == DialogResult.OK)
                    {
                        DataTable tb = (DataTable)gridControl1.DataSource;

                        DataRow row = tb.NewRow();

                        DateTime datetime = new DateTime();

                        int k = 0;
                        foreach (DataRow rows in tb.Rows)
                        {
                            if (frow["ITEM_ID"].ToString() == rows["ITEM_ID"].ToString())
                            {
                                try
                                {
                                    datetime = (DateTime)rows["CREATED_ON"];
                                }
                                catch { datetime = DateTime.Now; }

                                row["PR_ID"] = rows["PR_ID"];
                                tb.Rows.RemoveAt(k);
                                break;
                            }
                            ++k;
                        }

                        //object[] obRow = frow.ItemArray;
                        //obRow[3] = delForm.ResultValue;

                        row["PR_ID"] = invm.PR.PR_Data.PR_ID;
                        row["ITEM_ID"] = frow["ITEM_ID"];
                        row["ITEM_NAME"] = frow["ITEM_NAME"];
                        if (datetime.Year > 1)
                            row["CREATED_ON"] = datetime;
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

        private void btnGridbtnAdd_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView2_AddItem();
        }

        private void gridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            if (key == (char)Keys.Enter)
            {
                gridView2_AddItem();
            }
        }
    }
}