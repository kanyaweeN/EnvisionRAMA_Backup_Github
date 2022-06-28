using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIS.Forms.Inventory
{
    public partial class INV_TXN_PO_Autorization_Dialog : Form
    {
        private string po_uid; 
        private int pr_id;
        private int vendor_id;
        private string toc;
        private int org_id;
        private int created_by;
        private int last_modified_by;

        public string PO_UID 
        { get { return po_uid; } set { po_uid = value; } }
        public int PR_ID
        { get { return pr_id; } set { pr_id = value; } }
        public int VENDOR_ID
        { get { return vendor_id; } set { vendor_id = value; } }
        public string TOC
        { get { return toc; } set { toc = value; } }
        public int ORG_ID
        { get { return org_id; } set { org_id = value; } }
        public int CREATED_BY
        { get { return created_by; } set { created_by = value; } }
        public int LAST_MODIFIED_BY
        { get { return last_modified_by; } set { last_modified_by = value; } }

        private List<string> venId = new List<string>();

        public INV_TXN_PO_Autorization_Dialog()
        {
            InitializeComponent();
            getVendorintoComboBox();
        }

        private void btnVendorSearching_Click(object sender, EventArgs e)
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

        private void getVendorintoComboBox()
        { 
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            DataTable datatable = new DataTable("INV_VENDOR");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand();
                adapter.SelectCommand.Connection = connection;
                adapter.SelectCommand.CommandText = " select VENDOR_ID, VENDOR_UID, VENDOR_NAME from INV_VENDOR ";
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.Fill(datatable);
            }

            foreach (DataRow row in datatable.Rows)
            {
                venId.Add(row["VENDOR_ID"].ToString());
                string item = row["VENDOR_UID"].ToString() + "(" + row["VENDOR_NAME"].ToString() + ")";
                txtVendor.Properties.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!txtChecking()) return;

            try
            {
                int IndexSelection = txtVendor.SelectedIndex;
                string venid = venId[IndexSelection];
                VENDOR_ID = venid.ToString() == "" ? 0 : Convert.ToInt32(venid);

                PO_UID = txtPOUID.Text;

                TOC = txtTOC.Text;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool txtChecking()
        {
            bool retValue = true;

            if (txtVendor.Text.Trim() == "")
            {
                MessageBox.Show("Please select a Vendor");
                retValue = false;
            }
            if (txtPOUID.Text.Trim() == "")
                txtPOUID.Text = "AUTO";

            return retValue;
        }
    }
}