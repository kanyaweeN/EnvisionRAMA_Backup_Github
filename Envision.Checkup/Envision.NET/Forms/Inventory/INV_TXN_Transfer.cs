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
    public partial class INV_TXN_Transfer : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        private DataSet ds;
        bool formAlready = false;

        public INV_TXN_Transfer(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            DataTable tb1 = SelectALL_INV_TRANSACTION();
            gridControl2.DataSource = tb1;
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
                adapter.SelectCommand.CommandText = "select * from INV_REQUISITION where ISNULL(STATUS,'N')<>'C' and ISNULL(STATUS,'N')<>'F'";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);

                return datatable;
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;

            ds = new DataSet("myDataset");

            DataRow row = gridView2.GetDataRow(e.FocusedRowHandle);

            Control_Filling(row);

            int REQ_ID = Convert.ToInt32(row["REQUISITION_ID"]);
            int UNIT_ID = Convert.ToInt32(row["FROM_UNIT"]);

            DataTable table1 = GetREQMaster(REQ_ID, UNIT_ID).Copy();          
            DataTable table2 = GetREQDetail(REQ_ID, UNIT_ID).Copy();

            table1.TableName = "Master";
            table2.TableName = "Detail";
            
            ds.Tables.Add(table1);
            ds.Tables.Add(table2);

            ds.Relations.Add(new DataRelation("Level1",ds.Tables[0].Columns["ITEM_ID"],ds.Tables[1].Columns["ITEM_ID"]));

            gridControl1.DataSource = ds.Tables[0];

            gridView1.BestFitColumns();
            gridView1ch1.BestFitColumns();
        }

        private void Control_Filling(DataRow row)
        {
            try
            {
                txtReqID.Text = row["REQUISITION_ID"].ToString();
                txtReqUID.Text = row["REQUISITION_UID"].ToString();

                txtFromUnit.Text = row["FROM_UNIT"].ToString();
                txtToUnit.Text = row["TO_UNIT"].ToString();

                txtComment.Text = "";

                //checkBox1.Checked = true;
                //chkForceComplete.Checked = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetREQMaster(int REQ_ID, int UNIT_ID)
        {
            DataSet ds1 = new DataSet();
            InventoryStock invs = new InventoryStock();
            ds1 = invs.GetREQMaster(REQ_ID, UNIT_ID);

            return ds1.Tables[0];
        }

        private DataTable GetREQDetail(int REQ_ID, int UNIT_ID)
        {
            DataSet ds1 = new DataSet();
            InventoryStock invs = new InventoryStock();
            ds1 = invs.GetREQDetail(REQ_ID, UNIT_ID);

            return ds1.Tables[0];
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //int focRow = gridView1.FocusedRowHandle;

            //if (focRow < 0) return;

            //DataRow MasRow = gridView1.GetDataRow(focRow);

            //int itemId = Convert.ToInt32(MasRow["ITEM_ID"]);

            //DataRow DetRow = ds.Tables[focRow].NewRow();

            //DetRow["ITEM_ID"] = itemId;

            //ds.Tables[focRow].Rows.Add(DetRow);
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (FromViewToDataset()) return;

            gridView1ch1.FocusedRowHandle = -1;

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
                    sum += Convert.ToDouble(rowss["ITEM_TRANFER"]);
                }

                double qty = Convert.ToDouble(row["QTY"]);

                // some error checking.
                //
                if (ErrorChecking(1,qty,sum))
                {
                    return;
                }
                //
                // some error checking.

                if (SaveIntoDatabase())
                {                
                    return;
                }
            }
        }

        private bool FromViewToDataset()
        { 
            try
            {
                //foreach(DataRow row in gridView1ch1.)
            }
            catch
            {
                return false;
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

        private void gridView1ch1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //int rowhandle = e.RowHandle;

            //ds.Tables[1].Rows[rowhandle][e.Column.FieldName] = e.Value;
        }

        private bool SaveIntoDatabase()
        {
            try
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int itemId = Convert.ToInt32(row["ITEM_ID"]);

                    DataRow[] rows = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());

                    InventoryRequest invr = new InventoryRequest();
                    invr.INVTransaction = new INVTransaction();
                    //Set Property Transaction
                    try
                    {
                        invr.INVTransaction.FROM_UNIT = int.Parse(txtFromUnit.Text);//invr.INVTransaction.FROM_UNIT = 1;
                        invr.INVTransaction.TO_UNIT = int.Parse(txtToUnit.Text);
                    }
                    catch
                    {
                        invr.INVTransaction.FROM_UNIT = -1;//invr.INVTransaction.FROM_UNIT = 1;
                        invr.INVTransaction.TO_UNIT = -1;
                    }
                    invr.INVTransaction.PO_ID = 0; // modify : can fill zero '0' or null.
                    invr.INVTransaction.REQUISITION_ID = int.Parse(txtReqID.Text); // modify : can fill zero '0' or null.
                    invr.INVTransaction.COMMENTS = txtComment.Text;
                    invr.INVTransaction.TXN_TYPE = TranferType.T;
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
                        double QTY = Convert.ToDouble(rowss["ITEM_TRANFER"]);//double QTY = 1;//double QTY = Convert.ToDouble(rowss["QTY"]);
                        //double PRICE = Convert.ToDouble(rowss["PRICE"]);
                        double PRICE;
                        try { PRICE = Convert.ToDouble(rowss["PRICE"]); }
                        catch { PRICE = 0; }
                        int ITEMSTOCK = Convert.ToInt32(rowss["ITEM_STOCK_ID"]);//int ITEMSTOCK = 15;//int ITEMSTOCK = Convert.ToInt32(rowss["ITEMSTOCK"]);


                        //AddTransaction Detail
                        //invr.AddTransactionDtl(1, 1, "1", DateTime.Now, 15, 2, 15);
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


                    if (!bl)
                    {
                        MessageBox.Show(this, "Can't save into Database.");
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;

        }

        private void gridView1ch1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowhandle = e.RowHandle;

            DataRow row = ds.Tables[0].Rows[gridView1.FocusedRowHandle];

            int itemId = Convert.ToInt32(row["ITEM_ID"]);

            DataRow[] rows = ds.Tables[1].Select("ITEM_ID=" + itemId.ToString());

            rows[rowhandle][e.Column.FieldName] = e.Value;
        }

    }
}