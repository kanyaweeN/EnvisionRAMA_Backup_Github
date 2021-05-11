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

namespace RIS.Forms.Inventory
{
    public partial class Inventory_Transaction_Transfer : Form
    {
        private UUL.ControlFrame.Controls.TabControl CloseControl;

        public Inventory_Transaction_Transfer(UUL.ControlFrame.Controls.TabControl closecontrol)
        {
            InitializeComponent();
            CloseControl = closecontrol;

            gridControl2.DataSource = SelectALL_INV_TRANSACTION();
            if (gridView2.RowCount > 0)
            {
                gridView2_FocusedRowChanged(new object(), new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(1, 1));
            }
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
                adapter.SelectCommand.CommandText = "select * from INV_REQUISITION";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);

                return datatable;
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridView2.GetDataRow(e.FocusedRowHandle);

            Control_Filling(row);

            int REQ_ID = Convert.ToInt32(row["REQUISITION_ID"]);
            int UNIT_ID = Convert.ToInt32(row["FROM_UNIT"]);
            DataTable table = GetREQMaster(REQ_ID, UNIT_ID);

            gridControl1.DataSource = table;
        }

        private void Control_Filling(DataRow row)
        {
            //try { txtTxnType.SelectedIndex = Convert.ToInt32(row["REQUISITION_TYPE"]); }
            //catch {  }
            txtReqUid.Tag = row["REQUISITION_ID"].ToString();
            txtReqUid.Text = row["REQUISITION_UID"].ToString();

            txtFromUnit.Text = row["FROM_UNIT"].ToString();
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
    }
}