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
    public partial class INV_TXN_RQ : Form
    {
        InventoryStockMan invm;
        bool newInsert;
        UUL.ControlFrame.Controls.TabControl tabcontrol;
        MyMessageBox msb = new MyMessageBox();

        List<string> List_unitID = new List<string>();
            
        public INV_TXN_RQ(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();

            Select_INV_ITEM();

            invm = new InventoryStockMan();

            Database_Initgridcontrol1();

            //btnSearchPRID_Click(new object(), new EventArgs());
            //lv_ValueUpdated(new object(), new RIS.Forms.Lookup.ValueUpdatedEventArgs(

            Database_Select_first_PR();

            Database_Combobox_AddNewItem();

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
            gridControl1.DataSource = invm.Request.dsInsert.Tables[0].Copy();
        }

        private void Database_Select_first_PR()
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

        private void Database_Combobox_AddNewItem()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_UNIT");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select UNIT_ID,UNIT_UID from INV_UNIT ";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }




                foreach (DataRow row in datatable.Rows)
                {
                    try
                    {
                        string str = row[1].ToString();
                        txtFromUnit.Properties.Items.Add(row[1].ToString());
                        List_unitID.Add(row[0].ToString());
                    }
                    catch { }
                }

                foreach (DataRow row in datatable.Rows)
                {
                    try
                    {
                        txtToUnit.Properties.Items.Add(row[1].ToString());
                    }
                    catch { }
                }

                //foreach (DataRow row in datatable.Rows)
                //{
                //    string tag = "";
                //    try
                //    {
                //        int unit_id = Convert.ToInt32(row[0]);
                //        txtFromUnit.Properties.Items.Add(Convert.ToInt32(row[1]));
                //        tag = tag + "^" + unit_id.ToString();
                //    }
                //    catch { }
                //}

                //foreach (DataRow row in datatable.Rows)
                //{
                //    string tag = "";
                //    try
                //    {
                //        int unit_id = Convert.ToInt32(row[0]);
                //        txtToUnit.Properties.Items.Add(Convert.ToInt32(row[1]));
                //        tag = tag + "^" + unit_id.ToString();
                //    }
                //    catch { }
                //}
            }
            catch (Exception ex)
            {
            }

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
                            catch { datetime = DateTime.Now; }

                            row["REQUISITION_ID"] = rows["REQUISITION_ID"];
                            tb.Rows.RemoveAt(k);
                            break;
                        }
                        ++k;
                    }

                    //object[] obRow = frow.ItemArray;
                    //obRow[3] = delForm.ResultValue;

                    row["REQUISITION_ID"] = invm.Request.Request_Data.REQUISITION_ID;
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

        private void Form_Refresh()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnRefresh.Visible = true;

            txtRQUID.ReadOnly = true;
            txtFromUnit.Enabled = false;
            txtToUnit.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Visible = false;

            gridControl2.Enabled = false;
            gridControl1.Enabled = false;

            btnSearchPRID.Enabled = true;
            //txtPrID.Properties.ReadOnly = false;

            //Combobox_InsertItem();
            int REQUISITION_ID;

            try { REQUISITION_ID = Convert.ToInt32(txtRQUID.Tag); }
            catch { return; }

            try
            {
                invm.Request.SelectRequest(REQUISITION_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                if (invm.Request.Request_Data.RequestDetail != null)
                {
                    txtRQUID.Text = invm.Request.Request_Data.REQUISITION_UID;
                    txtRQUID.Tag = invm.Request.Request_Data.REQUISITION_ID;
                    txtGenBy.Text = invm.Request.Request_Data.GENERATED_BY.ToString()
                                    + " - " + invm.Request.Request_Data.GENERATED_BY_TEXT;
                    txtGenBy.Tag = invm.Request.Request_Data.GENERATED_BY;
                    //txtGenOn.Text = invm.Request.Request_Data.GENERATED_ON.ToShortDateString();
                    txtGenOn.DateTime = invm.Request.Request_Data.GENERATED_ON;

                    string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                    DataTable datatable = new DataTable("INV_UNIT");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = new SqlCommand();
                        adapter.SelectCommand.Connection = connection;
                        adapter.SelectCommand.CommandText = "select UNIT_ID,UNIT_UID from INV_UNIT";
                        adapter.SelectCommand.CommandType = CommandType.Text;
                        adapter.Fill(datatable);
                    }
                    DataRow[] dataRow1 = datatable.Select("UNIT_ID = " + invm.Request.Request_Data.FROM_UNIT.ToString());
                    txtFromUnit.Text = dataRow1[0]["UNIT_UID"].ToString();//invm.Request.Request_Data.FROM_UNIT.ToString();
                    DataRow[] dataRow2 = datatable.Select("UNIT_ID = " + invm.Request.Request_Data.TO_UNIT.ToString());
                    txtToUnit.Text = dataRow2[0]["UNIT_UID"].ToString();//invm.Request.Request_Data.TO_UNIT.ToString();
                    //txtFromUnit.Text = invm.Request.Request_Data.FROM_UNIT.ToString();
                    //txtToUnit.Text = invm.Request.Request_Data.TO_UNIT.ToString();

                    //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                    gridControl1.DataSource = invm.Request.Request_Data.RequestDetail.Tables[0].Copy();
                    gridControl1.Tag = invm.Request.Request_Data.RequestDetail.Tables[0].Copy();

                    if (invm.Request.Request_Data.STATUS != "N")
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
                else
                {
                    DataTable table = (DataTable)gridControl1.DataSource;
                    try
                    {
                        table.Rows.Clear();                      
                    }
                    catch 
                    { 
                        
                    }

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

            invm.Request.dsDelete.Tables[0].Rows.Clear();
        }

        private void btnSearchPRID_Click(object sender, EventArgs e)
        {
            RIS.Forms.Lookup.Lookup lv = new RIS.Forms.Lookup.Lookup();
            lv.ValueUpdated += new RIS.Forms.Lookup.ValueUpdatedEventHandler(lv_ValueUpdated);

            string qry = @"
                select
                    REQUISITION_ID
                    ,REQUISITION_UID
                    ,FROM_UNIT
                    ,TO_UNIT
                from
                    INV_REQUISITION
                where 
                            REQUISITION_ID     like    '%%' 
                    or      REQUISITION_UID       like    '%%'
                    or      FROM_UNIT       like    '%%'
                    or      TO_UNIT       like    '%%'
                ";

            string fields = "ID,UID,From Unit,To Unit";
            string con = "";
            lv.getData(qry, fields, con, "Reqyisition List");
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
            txtRQUID.Text = retValue[1];
            txtRQUID.Tag = (object)retValue[0];

            int REQUISITION_ID;

            try { REQUISITION_ID = Convert.ToInt32(txtRQUID.Tag); }
            catch { return; }

            try
            {
                invm.Request.SelectRequest(REQUISITION_ID);

                //txtPrID.Text = invm.PR.PR_Data.PR_ID.ToString();
                txtRQUID.Text = invm.Request.Request_Data.REQUISITION_UID;
                txtRQUID.Tag = invm.Request.Request_Data.REQUISITION_ID;
                txtGenBy.Text = invm.Request.Request_Data.GENERATED_BY.ToString()
                                + " - " + invm.Request.Request_Data.GENERATED_BY_TEXT;
                txtGenBy.Tag = invm.Request.Request_Data.GENERATED_BY;
                //txtGenOn.Text = invm.Request.Request_Data.GENERATED_ON.ToShortDateString();
                txtGenOn.DateTime = invm.Request.Request_Data.GENERATED_ON;

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
                DataTable datatable = new DataTable("INV_UNIT");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select UNIT_ID,UNIT_UID from INV_UNIT";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }
                DataRow[] dataRow1 = datatable.Select("UNIT_ID = " + invm.Request.Request_Data.FROM_UNIT.ToString());
                txtFromUnit.Text = dataRow1[0]["UNIT_UID"].ToString();//invm.Request.Request_Data.FROM_UNIT.ToString();
                DataRow[] dataRow2 = datatable.Select("UNIT_ID = " + invm.Request.Request_Data.TO_UNIT.ToString());
                txtToUnit.Text = dataRow2[0]["UNIT_UID"].ToString();//invm.Request.Request_Data.TO_UNIT.ToString();

                //tb2 = invm.PR.PR_Data.PR_Detail.Tables[0].Copy();
                gridControl1.DataSource = invm.Request.Request_Data.RequestDetail.Tables[0].Copy();
                gridControl1.Tag = invm.Request.Request_Data.RequestDetail.Tables[0].Copy();

                if (invm.Request.Request_Data.STATUS != "N")
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
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

            txtRQUID.ReadOnly = false;
            txtFromUnit.Enabled = true;
            txtToUnit.Enabled = true;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            gridControl2.Enabled = true;
            gridControl1.Enabled = true;

            btnSearchPRID.Enabled = false;

            //txtPrID.Properties.ReadOnly = true;

            //txtPrID.Text = "";
            txtRQUID.Text = "AUTO";
            txtGenBy.Text = new Common.Common.GBLEnvVariable().UserUID;
            //txtGenOn.DateTime = DateTime.Now.ToLocalTime();
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            btnRefresh.Visible = false;

            txtRQUID.ReadOnly = false;
            txtFromUnit.Enabled = true;
            txtToUnit.Enabled = true;

            btnSave.Visible = true;
            btnCancel.Visible = true;

            gridControl2.Enabled = true;
            gridControl1.Enabled = true;

            btnSearchPRID.Enabled = false;
            //txtPrID.Properties.ReadOnly = true;

            //txtPrID.Text = "";
            //txtPrUID.Text = "";

            //DataTable tb = (DataTable)gridControl1.DataSource;
            //tb.Rows.Clear();

            newInsert = false;
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
                        int i = invm.Request.Request_Data.REQUISITION_ID;
                        invm.Request.RequestManagement(SqlType.Delete);
                        ++k;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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

            Form_Refresh();

            msb.ShowAlert("UID2002", 1);
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
                        invm.Request.dsDeleteAdd(rowO);
                    }
                }

                invm.Request.Request_Data.REQUISITION_ID = Convert.ToInt32(txtRQUID.Tag);
                invm.Request.Request_Data.REQUISITION_UID = txtRQUID.Text;
                invm.Request.Request_Data.GENERATED_BY = new Common.Common.GBLEnvVariable().UserID;
                try
                {
                    invm.Request.Request_Data.FROM_UNIT = Convert.ToInt32(List_unitID[txtFromUnit.SelectedIndex]);
                    invm.Request.Request_Data.TO_UNIT = Convert.ToInt32(List_unitID[txtToUnit.SelectedIndex]);
                }
                catch { }
                invm.Request.Request_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.Request.Request_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.Request.Request_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.Request.dsInsert = ds.Copy();
                invm.Request.RequestManagement(SqlType.Update);
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

                invm.Request.Request_Data.REQUISITION_ID = 0;
                if (txtRQUID.Text.Trim().Length < 1 || txtRQUID.Text.ToUpper() == "AUTO")
                    invm.Request.Request_Data.REQUISITION_UID = "AUTO";
                else invm.Request.Request_Data.REQUISITION_UID = txtRQUID.Text;
                invm.Request.Request_Data.REQUISITION_TYPE = "M";

                try
                {
                    invm.Request.Request_Data.FROM_UNIT = Convert.ToInt32(List_unitID[txtFromUnit.SelectedIndex]);
                    invm.Request.Request_Data.TO_UNIT = Convert.ToInt32(List_unitID[txtToUnit.SelectedIndex]);
                }
                catch { }

                invm.Request.Request_Data.GENERATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.Request.Request_Data.LAST_MODIFIED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.Request.Request_Data.CREATED_BY = new Common.Common.GBLEnvVariable().UserID;
                invm.Request.Request_Data.ORG_ID = new Common.Common.GBLEnvVariable().OrgID;

                DataSet ds = new DataSet();
                ds.Tables.Add(tbNew);
                invm.Request.dsInsert = ds.Copy();
                invm.Request.RequestManagement(SqlType.Insert);
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
                //try { Convert.ToInt32(txtRQUID.Tag); }
                //catch { return false; }
                if (txtRQUID.Text.Trim().Length < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
                if (txtFromUnit.Text.Trim() == "" || txtToUnit.Text.Trim() == "")
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
                if (txtRQUID.Text.Trim().Length < 1)
                {
                    msb.ShowAlert("UID2001", 1);
                    return false;
                }
                if (txtFromUnit.Text.Trim() == "" || txtToUnit.Text.Trim() == "")
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

        private void btnGridAdd_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                            if (frow["ITEM_ID"].ToString().Equals(rows["ITEM_ID"].ToString()))
                            {
                                try
                                {
                                    datetime = (DateTime)rows["CREATED_ON"];
                                }
                                catch { datetime = DateTime.Now; }

                                row["REQUISITION_ID"] = rows["REQUISITION_ID"];
                                tb.Rows.RemoveAt(k);
                                break;
                            }
                            ++k;
                        }

                        //object[] obRow = frow.ItemArray;
                        //obRow[3] = delForm.ResultValue;

                        row["REQUISITION_ID"] = invm.Request.Request_Data.REQUISITION_ID;
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
    }
}