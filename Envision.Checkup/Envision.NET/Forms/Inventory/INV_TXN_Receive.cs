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
using RIS.Operational.Inventory;

namespace RIS.Forms.Inventory
{
    public partial class INV_TXN_Receive : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        DataSet ds = new DataSet();

        public INV_TXN_Receive(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();

            DataTable tb = SelectALL_INV_TRANSACTION();

            gridControl2.DataSource = tb.Copy();
        }

        public DataTable SelectALL_INV_TRANSACTION()
        {
            //string connectionString = @"server=.\SQLSERVER2005; database=RIS_FIN; integrated security=SSPI";
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable("POList");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = "select * from INV_PO ";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
                return datatable;
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int rowhandle = e.FocusedRowHandle;

            if (rowhandle < 0) return;

            DataRowView rowv = (DataRowView)gridView2.GetRow(rowhandle);
            DataRow row = rowv.Row;

            if (!GetPO(row)) return;

            gridControl1.DataSource = ds.Tables[0];

            gridView1.BestFitColumns();
            gridView1ch1.BestFitColumns();

            Control_Filling(row);
        }

        private void Control_Filling(DataRow row)
        { 
           txtPoID.Text = row["PO_ID"].ToString();
           txtPoUID.Text = row["PO_UID"].ToString();
        }

        private bool GetPO(DataRow row)
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            ds = new DataSet("myDataset");

            try
            {
                InventoryStock invs = new InventoryStock();
                //ds1 = invs.GetREQMaster(7, 1); //Get Master Data from Tranfer Page
                //ds1 = invs.GetREQDetail(7, 1); //Get Detail Data from Tranfer Page
                ds1 = invs.GetPOMaster(Convert.ToInt32(row["PO_ID"]));//Get Master Data from Recieve Page
                ds2 = invs.GetPODetail(Convert.ToInt32(row["PO_ID"]));//Get Detail Data from Recieve Page

                ds1.Tables[0].TableName = "Master";
                ds2.Tables[0].TableName = "Detail";

                ds.Tables.Add(ds1.Tables[0].Copy());
                ds.Tables.Add(ds2.Tables[0].Copy());

                ds.Relations.Add(new DataRelation("Level1", ds.Tables[0].Columns["ITEM_ID"], ds.Tables[1].Columns["ITEM_ID"]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //int frhd = gridView1.FocusedRowHandle;
            //gridView1.FocusedRowHandle = 0;
            //gridView1.FocusedRowHandle = frhd;


            if (!QTY_Checking()) return;

            //gridView1ch1.SetFocusedRowModified();
            

            if (!SaveIntoDatabase()) return;
            else { MessageBox.Show("was saved"); }
        }

        private bool QTY_Checking()
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int itemId = Convert.ToInt32(row["ITEM_ID"]);
                //List<DataRow> lrow = new List<DataRow>();

                DataRow[] rows = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());
                ////lrow.AddRange(rows);
                //List<DataRow> lrow = new List<DataRow>(rows);
                //DataTable newTb = ds.Tables[1].Clone();
                //foreach(DataRow rowss in lrow.ToArray())
                //{
                //    newTb.Rows.Add(rowss);
                //}
                //DataRow[] rowsss = newTb.Select("sum(ITEM_TRANFER)");

                double sum = 0;

                foreach (DataRow rowss in rows)
                {
                    sum += Convert.ToDouble(rowss["QTY"]);
                }

                double qty = Convert.ToDouble(row["QTY"]);

                // some error checking.
                //
                if (ErrorChecking(1, qty, sum))
                {
                    return false;
                }
                //
                // some error checking.
            }

            return true;
        }

        private bool ErrorChecking(int flag, double qty, double sum)
        {
            if (flag == 1)
            {
                if (qty < sum)
                {
                    //MessageBox.Show("Total number of TRANSFER column in Detail table is more than a total number of QTY column in Master table.");
                    MessageBox.Show("Item miss match !!!");
                    return true;
                }
            }

            return false;
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
                    try { invr.INVTransaction.FROM_UNIT = Convert.ToInt32(row["FROM_UNIT"]); }
                    catch { invr.INVTransaction.FROM_UNIT = 1; }
                    try { invr.INVTransaction.TO_UNIT = Convert.ToInt32(row["TO_UNIT"]); }
                    catch { invr.INVTransaction.TO_UNIT = 1; }
                    invr.INVTransaction.PO_ID = int.Parse(txtPoID.Text); // modify : can fill zero '0' or null.
                    invr.INVTransaction.REQUISITION_ID = 0; // modify : can fill zero '0' or null.
                    invr.INVTransaction.COMMENTS = txtComment.Text;
                    invr.INVTransaction.TXN_TYPE = TranferType.R;
                    invr.INVTransaction.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;
                    invr.INVTransaction.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                    invr.INVTransaction.LAST_MODIFIED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;

                    double TotalQTY = 0;

                    foreach (DataRow rowss in rows)
                    {
                        int ITEM_ID = Convert.ToInt32(rowss["ITEM_ID"]);
                        int TXN_UNIT = -1;//int TXN_UNIT = Convert.ToInt32(rowss["TXN_UNIT"]);
                        string BATCH = rowss["BATCH"].ToString();
                        DateTime EXPIRY_DT;
                        try { EXPIRY_DT = DateTime.Parse(rowss["EXPIRY_DT"].ToString()); }
                        catch { EXPIRY_DT = DateTime.Now; }
                        double QTY = Convert.ToDouble(rowss["QTY"]);//double QTY = 1;//double QTY = Convert.ToDouble(rowss["QTY"]);
                        double PRICE;
                        try { PRICE = Convert.ToDouble(rowss["PRICE"]); }
                        catch { PRICE = 0; }
                        int ITEMSTOCK = 200;//Convert.ToInt32(rowss["ITEM_STOCK_ID"]);//int ITEMSTOCK = 15;//int ITEMSTOCK = Convert.ToInt32(rowss["ITEMSTOCK"]);

                        //AddTransaction Detail
                        if (QTY > 0)
                        {
                            invr.AddTransactionDtl(ITEM_ID, TXN_UNIT, BATCH, EXPIRY_DT, QTY, PRICE, ITEMSTOCK);
                            TotalQTY += QTY;
                        }
                    }

                    if (chkForceComplete.Checked)
                    {
                        invr.INVTransaction.STATUS = Status.F;
                    }
                    else if (Convert.ToInt32(row["QTY"]) > TotalQTY)
                    {
                        invr.INVTransaction.STATUS = Status.U;
                    }
                    else if (Convert.ToInt32(row["QTY"]) <= TotalQTY)
                    {
                        invr.INVTransaction.STATUS = Status.C;
                    }

                    //Insert
                    bool bl = invr.InsertTransaction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            return true;
        }

        private void gridView1ch1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //int rowhandle = e.RowHandle;

            //ds.Tables[1].Rows[rowhandle][e.Column.FieldName] = e.Value;
        }

        private void gridView1ch1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowhandle = e.RowHandle;

            DataRow row = ds.Tables[0].Rows[gridView1.FocusedRowHandle];

            int itemId = Convert.ToInt32(row["ITEM_ID"]);

            DataRow[] rows = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());

            rows[rowhandle][e.Column.FieldName] = e.Value;

            //ds.Tables[1].Rows[rowhandle][e.Column.FieldName] = e.Value;
        }
    }
}