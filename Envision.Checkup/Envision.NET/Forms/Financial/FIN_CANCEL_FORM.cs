using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using RIS.BusinessLogic;
using RIS.Common;
using System.Text.RegularExpressions;
using RIS.Forms.GBLMessage;

namespace RIS.Forms.Financial
{
    public partial class FIN_CANCEL_FORM : Form
    {
        FINANCIAL FIN;
        Int64 pay_id;
        DateTime from_date;
        DateTime to_date;
        string hn;
        decimal total;
        MyMessageBox msb = new MyMessageBox();

        public FIN_CANCEL_FORM(string HN, DateTime FROM_DATE, DateTime TO_DATE)
        {
            InitializeComponent();

            this.from_date = new DateTime(FROM_DATE.Year, FROM_DATE.Month, FROM_DATE.Day, 0, 0, 0);
            this.to_date = new DateTime(TO_DATE.Year, TO_DATE.Month, TO_DATE.Day, 23, 59, 59);
            this.hn = HN;

            FIN = new FINANCIAL();

            DataTable tb = FIN.FIN_CANCEL.Select.Detail(hn, -2, from_date, to_date).Copy();
            tb.Columns.Add(new DataColumn("Delete"));
            gridControl1.DataSource = tb;

            DataTable table = FIN.FIN_CANCEL.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];

            textbox_addtext(row);
        }
        public FIN_CANCEL_FORM(long PAY_ID, string HN, DateTime FROM_DATE, DateTime TO_DATE)
        {
            InitializeComponent();

            this.from_date = new DateTime(FROM_DATE.Year, FROM_DATE.Month, FROM_DATE.Day, 0, 0, 0);
            this.to_date = new DateTime(TO_DATE.Year, TO_DATE.Month, TO_DATE.Day, 23, 59, 59);
            this.hn = HN;
            this.pay_id = PAY_ID;

            FIN = new FINANCIAL();

            DataTable tb = FIN.FIN_CANCEL.Select.Detail(pay_id, hn, -2, from_date, to_date).Copy();
            tb.Columns.Add(new DataColumn("DELETE"));
            gridControl1.DataSource = tb;

            DataTable table = FIN.FIN_CANCEL.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];

            textbox_addtext(row);

            foreach (DataRow row1 in tb.Rows)
            {
                string status = row1["STATUS"].ToString();
                if (status == "C")
                {
                    row1["STATUS"] = "Cash";
                }
                else if (status == "V")
                {
                    row1["STATUS"] = "Visa Card";
                }
                else if (status == "M")
                {
                    row1["STATUS"] = "Master Card";
                }
                else if (status == "K")
                {
                    row1["STATUS"] = "Credit Card";
                }
                else if (status == "S")
                {
                    row1["STATUS"] = "Settlement";
                }

                row1["DELETE"] = "N";
            }
        }
        private void FIN_CANCEL_FORM_Load(object sender, EventArgs e)
        {
            gridView1.Focus();
        }

        private void textbox_addtext(DataRow row)
        {
            try
            {
                txtHN.Text = row["HN"].ToString();
                txtName.Text = row["TITLE"].ToString()
                                + " " + row["FNAME"].ToString()
                                + " " + row["LNAME"].ToString();
                try
                {
                    txtRegDT.DateTime = DateTime.Parse(row["REG_DT"].ToString());
                }
                catch
                {
                    txtRegDT.DateTime = DateTime.Now;
                }
                try
                {
                    txtRegDT.DateTime = DateTime.Parse(row["DOB"].ToString());
                }
                catch
                {
                    txtRegDT.DateTime = DateTime.Now;
                }
                txtAddress.Text = row["ADDR1"].ToString()
                                    + " " + row["ADDR2"].ToString()
                                    + " " + row["ADDR3"].ToString()
                                    + " " + row["ADDR4"].ToString()
                                    + " " + row["ADDR5"].ToString();
                txtAddress.Text = Regex.Replace(txtAddress.Text, " {1,}", " ");

                txtGender.Text = row["GENDER"].ToString() == "F" ? "Female" : "Male";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataTable table1 = (DataTable)gridControl1.DataSource;
            bool found = false;
            foreach (DataRow row in table1.Rows)
            {
                if (row["DELETE"].ToString() == "Y")
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                if (msb.ShowAlert("UID2052", 2) == "2")
                {
                    DataTable table = (DataTable)gridControl1.DataSource;
                    string status = radioGroup1.EditValue.ToString();

                    if (table.Rows.Count > -1)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            string chk = row["DELETE"].ToString();
                            if (chk == "Y")
                            {
                                long pay_id = Convert.ToInt64(row["PAY_ID"]);
                                int exam_id = Convert.ToInt32(row["EXAM_ID"]);
                                int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
                                byte qty = Convert.ToByte(row["QTY"]);
                                decimal rate = Convert.ToDecimal(row["RATE"]);
                                decimal discount = 0;
                                decimal payable = Convert.ToDecimal(row["RATE"]);
                                decimal paid = 0;
                                int org_id = new Common.Common.GBLEnvVariable().OrgID;
                                int created_by = new Common.Common.GBLEnvVariable().UserID;
                                int order_id = Convert.ToInt32(row["ORDER_ID"]);
                                status = "O";

                                FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                , discount, payable, paid, status
                                , org_id, created_by, order_id);


                                #region oldCode
                                //long PAY_ID = (long)row["PAY_ID"];
                                //int EXAM_ID = (int)row["EXAM_ID"];
                                //int ORDER_ID = (int)row["ORDER_ID"];

                                //FIN.FIN_CANCEL.Update.Detail(PAY_ID, EXAM_ID, "O", ORDER_ID);
                                #endregion oldCode
                            }
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการด้วย โดยการทำเครื่องหมายหน้ารายการ","ยังไม่มีรายการที่เลือก");
                return;

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataTable tb = (DataTable)gridControl1.DataSource;
                DataRow row = tb.Rows[focus];

                if (row["DELETE"].ToString() == "Y")
                    row["DELETE"] = "N";
                else if (row["DELETE"].ToString() == "N")
                    row["DELETE"] = "Y";
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int focus = gridView1.FocusedRowHandle;
                if (focus > -1)
                {
                    DataTable tb = (DataTable)gridControl1.DataSource;
                    DataRow row = tb.Rows[focus];

                    if (row["DELETE"].ToString() == "Y")
                        row["DELETE"] = "N";
                    else if (row["DELETE"].ToString() == "N")
                        row["DELETE"] = "Y";
                }
            }
            if (e.KeyChar == (char)Keys.Space)
            {
                int focus = gridView1.FocusedRowHandle;
                if (focus > -1)
                {
                    DataTable tb = (DataTable)gridControl1.DataSource;
                    DataRow row = tb.Rows[focus];

                    if (row["DELETE"].ToString() == "Y")
                        row["DELETE"] = "N";
                    else if (row["DELETE"].ToString() == "N")
                        row["DELETE"] = "Y";
                }
            }
        }

        private void chkEditCancel_CheckedChanged(object sender, EventArgs e)
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataTable tb = (DataTable)gridControl1.DataSource;
                DataRow row = tb.Rows[focus];

                if (row["DELETE"].ToString() == "Y")
                    row["DELETE"] = "N";
                else if (row["DELETE"].ToString() == "N")
                    row["DELETE"] = "Y";
            }
        }

    }
}