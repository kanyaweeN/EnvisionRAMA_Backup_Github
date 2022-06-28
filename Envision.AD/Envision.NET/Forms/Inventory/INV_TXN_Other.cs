using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NHapi.Base;
using System.Data.SqlClient;
using RIS.Operational;
using RIS.Common;
using System.Threading;
using RIS.Operational.Inventory;

namespace RIS.Forms.Inventory
{
    public partial class INV_TXN_Other : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        DataSet ds = new DataSet();  
        DataTable tb = new DataTable();
        int focusGrid1;
        int focusGrid1ch1;
        int focusGrid2;

        public INV_TXN_Other(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();

            if (!select_all_unit()) return;

            //if (Select_INV_ITEMSTOCK()) return;

            if (!dataSource_Inserting()) return;

            gridControl2.DataSource = tb;

            tb.Columns.AddRange(
                                    new DataColumn[]
                                    {
                                        new DataColumn("ITEM_STOCK_ID"),
                                        new DataColumn("UNIT_ID"),
                                        new DataColumn("ITEM_ID"),
                                        new DataColumn("BATCH"),
                                        new DataColumn("EXPIRY_DT"),
                                        new DataColumn("QTY"),
                                        new DataColumn("ORG_ID"),
                                        new DataColumn("ITEM_NAME"),
                                    }

                                );
        }

        public DataTable SelectALL_INV_TRANSACTION()
        {
            //string connectionString = @"server=.\SQLSERVER2005; database=RIS_FIN; integrated security=SSPI";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = "select * from INV_TRANSACTION";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
                return datatable;
            }
        }

        public bool Select_INV_ITEMSTOCK(int UnitID)
        {
            ds = new DataSet();

            try
            {
                InventoryStock invstock = new InventoryStock();

                DataTable tb1 = new DataTable();
                DataTable tb2 = new DataTable();

                tb1 = invstock.GetItemStockMaster(UnitID).Tables[0].Copy();
                tb2 = invstock.GetItemStockDetail(UnitID).Tables[0].Copy();

                tb1.TableName = "Master";
                tb2.TableName = "Detail";

                ds.Tables.Add(tb1);
                ds.Tables.Add(tb2);

                ds.Relations.Add(new DataRelation("Level1", ds.Tables[0].Columns["ITEM_ID"], ds.Tables[1].Columns["ITEM_ID"]));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool select_all_unit()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand();
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = "select UNIT_ID, UNIT_UID from INV_UNIT order by unit_id asc";
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    adapter.Fill(datatable);
                }

                foreach (DataRow row in datatable.Rows)
                {
                    string text = row["UNIT_ID"].ToString() + " - " + row["UNIT_UID"].ToString();
                    txtUnit.Properties.Items.Add(text);
                }

                if (txtUnit.Properties.Items.Count > -1)
                    txtUnit.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool dataSource_Inserting()
        {
            try
            {
                gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private void txtUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtUnit.SelectedIndex < 0) return;

            if (!Select_INV_ITEMSTOCK(txtUnit.SelectedIndex+1)) return;

            if (!dataSource_Inserting()) return;
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusGrid1 = e.FocusedRowHandle;
        }

        private void gridView1ch1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusGrid1ch1 = e.FocusedRowHandle;

            int itemId = Convert.ToInt32(ds.Tables[1].Rows[focusGrid1ch1]["ITEM_ID"]);

            DataRow[] row = ds.Tables[0].Select("ITEM_ID=" + itemId.ToString());

            focusGrid1 = ds.Tables[0].Rows.IndexOf(row[0]);
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            focusGrid2 = e.FocusedRowHandle;
        }

        private void gridView1ch1_DoubleClick(object sender, EventArgs e)
        {
            DataRow rowss = ds.Tables[0].Rows[focusGrid1];
            int i = gridView1ch1.SelectedRowsCount;
            int itemId = Convert.ToInt32(rowss["ITEM_ID"]);

            DataRow[] rowsss = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());

            DataRow row = rowsss[focusGrid1ch1];

            INV_TXN_SelectAmount delForm = new INV_TXN_SelectAmount(Convert.ToInt32(row["QTY"]));          
            delForm.ShowDialog();
            if (delForm.DialogResult == DialogResult.OK)
            {
                object[] obRow = row.ItemArray;
                obRow[5] = delForm.ResultValue;

                int k = 0;
                foreach (DataRow rows in tb.Rows)
                {
                    if (row["ITEM_STOCK_ID"].ToString().Equals(rows["ITEM_STOCK_ID"].ToString()))
                    {
                        tb.Rows.RemoveAt(k);
                        break;
                    }
                    ++k;
                }
                tb.Rows.Add(obRow);
            }
            else
            {
                return;
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            tb.Rows.RemoveAt(focusGrid2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!SaveIntoDatabase()) return;
            else 
            { 
                MessageBox.Show("was Deleted"); 
                tb.Rows.Clear(); 
            }
        }

        private bool SaveIntoDatabase()
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int itemId = Convert.ToInt32(row["ITEM_ID"]);

                DataRow[] rows = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());

                try
                {
                    InventoryRequest invr = new InventoryRequest();
                    invr.INVTransaction = new INVTransaction();
                    //Set Property Transaction
                    try { invr.INVTransaction.FROM_UNIT = Convert.ToInt32(row["UNIT_ID"]); }
                    catch { invr.INVTransaction.FROM_UNIT = 1; }
                    //try { invr.INVTransaction.TO_UNIT = Convert.ToInt32(row["TO_UNIT"]); }
                    //catch { invr.INVTransaction.TO_UNIT = 1; }
                    invr.INVTransaction.PO_ID = 0; // modify : can fill zero '0' or null.
                    invr.INVTransaction.REQUISITION_ID = 0; // modify : can fill zero '0' or null.
                    invr.INVTransaction.COMMENTS = txtComment.Text;
                    invr.INVTransaction.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                    invr.INVTransaction.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                    invr.INVTransaction.LAST_MODIFIED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                    if (txtTXNType.SelectedIndex == 0)
                    {
                        invr.INVTransaction.TXN_TYPE = TranferType.D;
                    }
                    else if (txtTXNType.SelectedIndex == 1)
                    {
                        invr.INVTransaction.TXN_TYPE = TranferType.L;
                    }
                    else if (txtTXNType.SelectedIndex == 2)
                    {
                        invr.INVTransaction.TXN_TYPE = TranferType.E;
                    }

                    foreach (DataRow rowss in rows)
                    {
                        int ITEM_ID = Convert.ToInt32(rowss["ITEM_ID"]);
                        int TXN_UNIT = 111;//int TXN_UNIT = Convert.ToInt32(rowss["TXN_UNIT"]);
                        string BATCH = rowss["BATCH"].ToString();
                        DateTime EXPIRY_DT;
                        try { EXPIRY_DT = DateTime.Parse(rowss["EXPIRY_DT"].ToString()); }
                        catch { EXPIRY_DT = DateTime.Now; }
                        double QTY = Convert.ToDouble(rowss["QTY"]);//double QTY = 1;//double QTY = Convert.ToDouble(rowss["QTY"]);
                        double PRICE = 0;
                        //try { PRICE = Convert.ToDouble(rowss["PRICE"]); }
                        //catch { PRICE = 0; }
                        int ITEMSTOCK = Convert.ToInt32(rowss["ITEM_STOCK_ID"]);//Convert.ToInt32(rowss["ITEM_STOCK_ID"]);//int ITEMSTOCK = 15;//int ITEMSTOCK = Convert.ToInt32(rowss["ITEMSTOCK"]);

                        //AddTransaction Detail
                        if (QTY > 0)
                            invr.AddTransactionDtl(ITEM_ID, TXN_UNIT, BATCH, EXPIRY_DT, QTY, PRICE, ITEMSTOCK);
                    }

                    //Insert
                    bool bl = invr.InsertTransaction();

                    if (!bl)
                    {
                        MessageBox.Show(this, "Can't save into Database.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            return true;
        }

        private void gridView1ch1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int i = e.RowHandle;
        }

        private void gridView1ch1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            int i = e.ControllerRow;
        }

    }
}