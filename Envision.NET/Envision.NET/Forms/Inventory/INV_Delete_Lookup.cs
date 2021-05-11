using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Operational;
using Envision.Common;
using System.Data.SqlClient;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Inventory
{
    public partial class INV_Delete_Lookup : Form
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataSet dsRecieve;
        private string filter;
        DevExpress.XtraGrid.Columns.ColumnFilterInfo fil;
        DataTable dtt = new DataTable();
        private int qty;
        public INV_Delete_Lookup()
        {
            InitializeComponent();
        }
        public INV_Delete_Lookup(DataRow dr,DataTable dttDetail)
        {
            InitializeComponent();
            dtt = dttDetail.Copy();
            dtt.Rows.Clear();
            dtt.AcceptChanges();
            dtt.Rows.Add(dr.ItemArray);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {


            Envision.BusinessLogic.InventoryManagement inv = new Envision.BusinessLogic.InventoryManagement();
            switch (cmbTXN_TYPE.EditValue.ToString())
            {
                case "Delete":
                    inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.D.ToString());
                    break;
                case "Lost":
                    inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.L.ToString());
                    break;
                case "ETC":
                    inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.E.ToString());
                    break;
                default:
                    inv.ItemTransation.INVTransaction.TXN_TYPE = Convert.ToChar(Envision.Common.TranferType.D.ToString());
                    break;
            }
            inv.ItemTransation.INVTransaction.REQUISITION_ID = 0;
            inv.ItemTransation.INVTransaction.PO_ID = 0;
            inv.ItemTransation.INVTransaction.FROM_UNIT = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"].ToString());
            inv.ItemTransation.INVTransaction.TO_UNIT = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"].ToString());
            inv.ItemTransation.INVTransaction.COMMENTS = "";
            inv.ItemTransation.INVTransaction.ORG_ID = 1;
            inv.ItemTransation.INVTransaction.CREATED_BY = new GBLEnvVariable().UserID;
            inv.ItemTransation.INVTransaction.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            inv.ItemTransation.INVTransaction.STATUS = Envision.Common.Status.C.ToString();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            inv.ItemTransation.AddTransactionDtl(Convert.ToInt32(dr["ITEM_ID"].ToString()), Convert.ToInt32(dr["ITEM_ID"].ToString()), Convert.ToInt32(dr["TXN_UNIT_ID"].ToString()), dr["BATCH"].ToString(), Convert.ToDateTime(dr["EXPIRY_DT"].ToString())
                     , Convert.ToDouble(dr["QTY"].ToString()), Convert.ToDouble(dr["PRICE"].ToString()), "", Convert.ToInt32(dr["ITEM_STOCK_ID"].ToString()));
            if (inv.ItemTransation.InsertTransaction())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void INV_Recieve_Lookup_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = dtt;
            cmbTXN_TYPE.Properties.Items.Add("Delete");
            cmbTXN_TYPE.Properties.Items.Add("Lost");
            cmbTXN_TYPE.Properties.Items.Add("ETC");
            cmbTXN_TYPE.SelectedIndex = 0;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Caption == "Quantity")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }
    }
}