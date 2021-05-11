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
using RIS.Forms.GBLMessage;
using System.Text.RegularExpressions;

namespace RIS.Forms.Financial
{
    public partial class FIN_RECEIVE_FORM : Form
    {
        FINANCIAL FIN;
        Int64 pay_id;
        DateTime from_date;
        DateTime to_date;
        string hn;
        decimal total;
        MyMessageBox msb = new MyMessageBox();

        public FIN_RECEIVE_FORM(long PAY_ID, string HN, DateTime FROM_DATE, DateTime TO_DATE)
        {
            InitializeComponent();

            this.ControlBox = false;
            this.from_date = new DateTime(FROM_DATE.Year, FROM_DATE.Month, FROM_DATE.Day, 0, 0, 0);
            this.to_date = new DateTime(TO_DATE.Year, TO_DATE.Month, TO_DATE.Day, 23, 59, 59);
            this.hn = HN;
            this.pay_id = PAY_ID;

            FIN = new FINANCIAL();

            gridControl1.DataSource = FIN.FIN_RECEIVE.Select.Detail(pay_id, 0, from_date, to_date);

            DataTable table = FIN.FIN_RECEIVE.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];

            textbox_addtext(row);
            

            DataTable table1 = (DataTable)gridControl1.DataSource;
            table1.Columns.Add(new DataColumn("ADD"));
            table1.Columns.Add(new DataColumn("TYPE"));

            decimal total = 0;
            foreach (DataRow row1 in table1.Rows)
            {
                row1["ADD"] = "Y";
                total += Convert.ToDecimal(row1["SETTLEMENT_DISCOUNT"]);

                decimal rate = Convert.ToDecimal(row1["RATE"]);
                decimal discount = Convert.ToDecimal(row1["SETTLEMENT_DISCOUNT"]);
                decimal paid = rate + discount;
                row1["PAID"] = paid.ToString("0.00");
            }
            txtDiscount.Text = total.ToString("0.00");
            Paid_Calculation();
            Total_Calculation();
            string str =table1.Rows[0]["REF_UNIT"].ToString();
            if (str != "")
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = true;
                radioButton5.Checked = true;
                txtInsuranceType.Text = table1.Rows[0]["INSURANCE_TYPE_DESC"].ToString();
            }
            else
            { 
                
            }
        }
        public FIN_RECEIVE_FORM(string HN, DateTime FROM_DATE, DateTime TO_DATE)
        {
            InitializeComponent();

            this.from_date = new DateTime(FROM_DATE.Year, FROM_DATE.Month, FROM_DATE.Day, 0, 0, 0);
            this.to_date = new DateTime(TO_DATE.Year, TO_DATE.Month, TO_DATE.Day, 23, 59, 59);
            this.hn = HN;

            FIN = new FINANCIAL();

            gridControl1.DataSource = FIN.FIN_RECEIVE.Select.Detail(hn, 0, from_date, to_date);

            DataTable table = FIN.FIN_RECEIVE.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];

            textbox_addtext(row);
            Total_Calculation();

            DataTable table1 = (DataTable)gridControl1.DataSource;
            table1.Columns.Add(new DataColumn("ADD"));
            table1.Columns.Add(new DataColumn("TYPE"));

            decimal total = 0;
            foreach(DataRow row1 in table1.Rows)
            {
                row1["ADD"] = "Y";
                total += Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
            }
            txtDiscount.Text = total.ToString("0.00");

        }
        private void FIN_RECEIVE_FORM_Load(object sender, EventArgs e)
        {
            gridView1.Focus();
        }

        private void dabase_select_all_his_registration()
        {
            //string hn = datarow["HN"].ToString();

            //string connectionString = System.Configuration.ConfigurationSettings.AppSettings["connStr"];
            //DataTable datatable = new DataTable("HIS_REGISTRATION");

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = new SqlCommand();
            //    adapter.SelectCommand.Connection = connection;
            //    adapter.SelectCommand.CommandText = "select * from HIS_REGISTRATION where HN like '" + hn.Trim()+"'";
            //    adapter.SelectCommand.CommandType = CommandType.Text;
            //    adapter.Fill(datatable);
            //}

            //DataRow row = datatable.Rows[0];
            //textbox_addtext(row);

            //datatable = new DataTable();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = new SqlCommand();
            //    adapter.SelectCommand.Connection = connection;
            //    adapter.SelectCommand.CommandText = "select PAY_ID from FIN_PAYMENT where HN like '" + hn.Trim() + "'";
            //    adapter.SelectCommand.CommandType = CommandType.Text;
            //    adapter.Fill(datatable);
            //}

            //DataTable newgrid = new DataTable();
            //DataTable tableforloop = new DataTable();

            //bool firstloop = true;
            //int k = 0;
            //while (k < datatable.Rows.Count)
            //{
            //    int pay_id = Convert.ToInt32(datatable.Rows[k]["PAY_ID"]);
            //    tableforloop = new DataTable();

            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        SqlDataAdapter adapter = new SqlDataAdapter();
            //        adapter.SelectCommand = new SqlCommand();
            //        adapter.SelectCommand.Connection = connection;
            //        adapter.SelectCommand.CommandText = "select * from FIN_PAYMENTDTL where PAY_ID=" + pay_id.ToString() + " AND ISNULL(FIN_PAYMENTDTL.STATUS,'O') like 'O'";
            //        adapter.SelectCommand.CommandType = CommandType.Text;
            //        adapter.Fill(tableforloop);
            //    }

            //    if (firstloop)
            //    {
            //        newgrid = tableforloop.Clone();
            //    }

            //    foreach (DataRow row2 in tableforloop.Rows)
            //    {
            //        //DataRow row3 = newgrid.NewRow();
            //        //row3 = row2.ItemArray;
            //        newgrid.Rows.Add(row2.ItemArray);
            //    }

            //    firstloop = false;
            //    ++k;
            //}

            ////gridControl1.DataSource = datatable.Copy();
            //gridControl1.DataSource = newgrid.Copy();
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

                txtGender.Text = row["GENDER"].ToString() == "F" ? "Female" : "Male";

                txtAddress.Text = Regex.Replace(txtAddress.Text, " {1,}", " ");

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
                if (row["ADD"].ToString() == "Y")
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {

                DataRow row1 = table1.Rows[0];
                string hn = row1["HN"].ToString();
                decimal rate1;
                try { rate1 = Convert.ToDecimal(row1["RATE"]); }
                catch { rate1 = 0; }
                string strRate = rate1.ToString("0.00");
                string fullname = row1["FULLNAME"].ToString();
                //FIN_RECEIVE_CONFIRM_FORM confirm = new FIN_RECEIVE_CONFIRM_FORM(hn, strRate, fullname, table1);


                if (msb.ShowAlert("UID2051", 2) == "2")
                {
                    DataTable table = (DataTable)gridControl1.DataSource;
                    string status = "";
                    if (radioButton1.Checked) status = "C";
                    else if (radioButton2.Checked) status = "M";
                    else if (radioButton3.Checked) status = "V";
                    else if (radioButton4.Checked) status = "K";
                    else if (radioButton5.Checked) status = "S";

                    foreach (DataRow row in table.Rows)
                    {
                        string add = row["ADD"].ToString();
                        if (add == "Y")
                        {
                            long pay_id = Convert.ToInt64(row["PAY_ID"]);
                            int exam_id = Convert.ToInt32(row["EXAM_ID"]);
                            int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
                            byte qty = Convert.ToByte(row["QTY"]);
                            decimal rate = Convert.ToDecimal(row["RATE"]);
                            decimal discount = Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
                            decimal payable;
                            //try { payable = Convert.ToDecimal(row["PAYABLE"]); }
                            //catch { payable = 0; }
                            try { payable = Convert.ToDecimal(row["RATE"]); }
                            catch { payable = 0; }
                            decimal paid = Convert.ToDecimal(row["PAID"]);
                            int org_id = new Common.Common.GBLEnvVariable().OrgID;
                            int created_by = new Common.Common.GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id);
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    msb.ShowAlert("UID2050", 2);

                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการด้วย โดยการทำเครื่องหมายหน้ารายการ", "ยังไม่มีรายการที่เลือก");
                return;

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            #region oldCode3
            //DataTable table1 = (DataTable)gridControl1.DataSource;
            //DataRow row1 = table1.Rows[0];
            //string hn = row1["HN"].ToString();
            //decimal rate1;
            //try { rate1 = Convert.ToDecimal(row1["RATE"]); }
            //catch { rate1 = 0; }
            //string strRate = rate1.ToString("0.00");
            //string fullname = row1["FULLNAME"].ToString();
            //FIN_RECEIVE_CONFIRM_FORM confirm = new FIN_RECEIVE_CONFIRM_FORM(hn,strRate,fullname,table1);

            //if (confirm.ShowDialog() == DialogResult.OK)
            //{
            //    DataTable table = (DataTable)gridControl1.DataSource;
            //    string status = "";
            //    if (radioButton1.Checked) status = "C";
            //    else if (radioButton2.Checked) status = "M";
            //    else if (radioButton3.Checked) status = "V";
            //    else if (radioButton4.Checked) status = "K";
            //    else if (radioButton5.Checked) status = "S";

            //    foreach (DataRow row in table.Rows)
            //    {
            //        long pay_id = Convert.ToInt64(row["PAY_ID"]);
            //        int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //        int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
            //        byte qty = Convert.ToByte(row["QTY"]);
            //        decimal rate = Convert.ToDecimal(row["RATE"]);
            //        decimal discount = Convert.ToDecimal(row["DISCOUNT"]);
            //        decimal payable;
            //        try { payable = Convert.ToDecimal(row["PAYABLE"]); }
            //        catch { payable = 0; }
            //        decimal paid = Convert.ToDecimal(row["PAID"]);
            //        int org_id = new Common.Common.GBLEnvVariable().OrgID;
            //        int created_by = new Common.Common.GBLEnvVariable().UserID;
            //        int order_id = Convert.ToInt32(row["ORDER_ID"]);

            //        FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
            //                                        , discount, payable, paid, status
            //                                        , org_id, created_by, order_id);
            //    }

            //    this.DialogResult = DialogResult.OK;
            //}
            #endregion 

            #region oldCode2
            //DataTable table = (DataTable)gridControl1.DataSource;
            //string status = "";// = radioGroup1.EditValue.ToString();

            //foreach (DataRow row in table.Rows)
            //{
            //    if (row["TYPE"].ToString().ToLower().StartsWith("crash"))
            //        status = "C";
            //    else if (row["TYPE"].ToString().ToLower().StartsWith("credit"))
            //        status = "K";
            //    else if (row["TYPE"].ToString().ToLower().StartsWith("settle"))
            //        status = "S";

            //    long pay_id = Convert.ToInt64(row["PAY_ID"]);
            //    int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //    int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
            //    byte qty = Convert.ToByte(row["QTY"]);
            //    decimal rate = Convert.ToDecimal(row["RATE"]);
            //    decimal discount = Convert.ToDecimal(row["DISCOUNT"]);
            //    decimal payable;
            //    try { payable = Convert.ToDecimal(row["PAYABLE"]); }
            //    catch { payable = 0; }
            //    decimal paid = Convert.ToDecimal(row["PAID"]);
            //    int org_id = new Common.Common.GBLEnvVariable().OrgID;
            //    int created_by = new Common.Common.GBLEnvVariable().UserID;
            //    int order_id = Convert.ToInt32(row["ORDER_ID"]);

            //    FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
            //                                    , discount, payable, paid, status
            //                                    , org_id, created_by, order_id);
            //}

            //this.DialogResult = DialogResult.OK;

            #endregion

            #region oldCode

            //DataTable table = (DataTable)gridControl1.DataSource;
            //string status = radioGroup1.EditValue.ToString();
            
            //foreach(DataRow row in table.Rows)
            //{

            //    long pay_id = Convert.ToInt64(row["PAY_ID"]);
            //    int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //    int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
            //    byte qty = Convert.ToByte(row["QTY"]);
            //    decimal rate = Convert.ToDecimal(row["RATE"]);
            //    decimal discount = Convert.ToDecimal(row["DISCOUNT"]);
            //    decimal payable;
            //    try { payable = Convert.ToDecimal(row["PAYABLE"]); }
            //    catch { payable = 0; }
            //    decimal paid = Convert.ToDecimal(row["PAID"]);
            //    int org_id = new Common.Common.GBLEnvVariable().OrgID;
            //    int created_by = new Common.Common.GBLEnvVariable().UserID;
            //    int order_id = Convert.ToInt32(row["ORDER_ID"]);

            //    FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
            //                                    , discount, payable, paid, status
            //                                    , org_id, created_by, order_id);
            //}

            //this.DialogResult = DialogResult.OK;
            
            #endregion
        }

        private void Total_Calculation()
        {
            DataTable table = (DataTable)gridControl1.DataSource;

            total = 0;
            foreach (DataRow row in table.Rows)
            {
                string add = row["ADD"].ToString();
                if (add == "Y")
                {
                    try
                    {
                        decimal rate = Convert.ToDecimal(row["RATE"]);
                        total += rate;
                    }
                    catch
                    { }
                }
            }

            txtTotal.Text = total.ToString("0.00");         
        }

        private void Paid_Calculation()
        {
            DataTable tb = (DataTable)gridControl1.DataSource;
            decimal discount = 0;
            decimal paid = 0;
            foreach (DataRow row in tb.Rows)
            {
                string add = row["ADD"].ToString();
                if (add == "Y")
                {
                    discount += Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
                    paid += Convert.ToDecimal(row["PAID"]);
                }
            }
            txtDiscount.Text = discount.ToString("0.00");
            txtPaid.Text = paid.ToString("0.00");

            if (discount >= 0)
            {
                label10.Text = "Charge";
                //bandedGridColumn6.Caption = "Charge";
            }
            else if (discount < 0)
            {
                label10.Text = "Discount";
                //bandedGridColumn6.Caption = "Discount";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowNewDialog();

            #region oldcode
            //int focus = gridView1.FocusedRowHandle;
            //if (focus > -1)
            //{
            //    DataRow row = gridView1.GetDataRow(focus);
            //    string hn = row["HN"].ToString();
            //    decimal payable;
            //    try { payable = Convert.ToDecimal(row["PAYABLE"]); }
            //    catch { payable = 0; }
            //    string strPayable = payable.ToString("0.00");
            //    string fullname = row["FULLNAME"].ToString();

            //    FIN_RECEIVE_ALERT_FORM fin_alert = new FIN_RECEIVE_ALERT_FORM(hn, strPayable, fullname);
            //    if (fin_alert.ShowDialog() == DialogResult.OK)
            //    {
            //        string status = fin_alert.statusResult;
            //        if (status == "C")
            //        {
            //            long pay_id = Convert.ToInt64(row["PAY_ID"]);
            //            int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, status);

            //            DataTable table = (DataTable)gridControl1.DataSource;
            //            table.Rows.Remove(row);

            //            decimal paid = payable;
            //            Paid_Calculation(paid);
            //        }
            //        else if (status == "K" || status == "S")
            //        {
            //            long pay_id = Convert.ToInt64(row["PAY_ID"]);
            //            int exam_id = Convert.ToInt32(row["EXAM_ID"]);
            //            int item_id = row["ITEM_ID"].ToString()==""?0:Convert.ToInt32(row["ITEM_ID"]);
            //            byte qty = Convert.ToByte(row["QTY"]);
            //            decimal rate = Convert.ToDecimal(row["RATE"]);
            //            decimal discount = Convert.ToDecimal(row["DISCOUNT"]);
            //            //decimal payable = Convert.ToDecimal(row["PAYABLE"]);
            //            decimal paid = Convert.ToDecimal(row["PAID"]);
            //            int org_id = new Common.Common.GBLEnvVariable().OrgID;
            //            int created_by = new Common.Common.GBLEnvVariable().UserID;
            //            int order_id = Convert.ToInt32(row["ORDER_ID"]);

            //            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
            //                                            , discount, payable, paid, status
            //                                            , org_id, created_by, order_id);

            //            DataTable table = (DataTable)gridControl1.DataSource;
            //            table.Rows.Remove(row);

            //            decimal paids = payable;
            //            Paid_Calculation(paids);
            //        }
            //    }

            //}
            #endregion oldCode
        }

        private void spinPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataRow focusRow = gridView1.GetDataRow(focus);
                DataTable tb = (DataTable)gridControl1.DataSource;
                DataRow gridRow = tb.Rows[focus];

                gridRow["PAID"] = focusRow["PAID"];

                decimal paid = Convert.ToDecimal(gridRow["PAID"]);
                decimal rate = Convert.ToDecimal(gridRow["RATE"]);
                decimal discount = paid - rate;
                gridRow["SETTLEMENT_DISCOUNT"] = discount;

                Paid_Calculation();                
            }

        }

        private void btnPaid_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ShowNewDialog();
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char chKey = e.KeyChar;
            if (chKey == (char)Keys.Enter)
            {
                ShowNewDialog();
            }
            else if (chKey == (char)Keys.Space)
            {
                int focus = gridView1.FocusedRowHandle;
                DataTable tb = (DataTable)gridControl1.DataSource;
                DataRow row = tb.Rows[focus];

                if (row["ADD"].ToString() == "Y")
                    row["ADD"] = "N";
                else if (row["ADD"].ToString() == "N")
                    row["ADD"] = "Y";
            }
            else if (chKey == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ShowNewDialog()
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                FIN_RECEIVE_SelectAmount selAmount = new FIN_RECEIVE_SelectAmount(decimal.MaxValue);
                if (selAmount.ShowDialog() == DialogResult.OK)
                {
                    DataTable tb = (DataTable)gridControl1.DataSource;
                    DataRow gridRow = tb.Rows[focus];

                    gridRow["PAID"] = selAmount.ResultValue;

                    decimal paid = Convert.ToDecimal(gridRow["PAID"]);
                    decimal rate = Convert.ToDecimal(gridRow["RATE"]);
                    decimal discount = paid - rate;
                    gridRow["SETTLEMENT_DISCOUNT"] = discount;

                    Paid_Calculation();

                    gridView1.RefreshData();
                }
            }
        }

        private void chkAdd_CheckedChanged(object sender, EventArgs e)
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataTable tb = (DataTable)gridControl1.DataSource;
                DataRow row = tb.Rows[focus];

                if (row["ADD"].ToString() == "Y")
                    row["ADD"] = "N";
                else if (row["ADD"].ToString() == "N")
                    row["ADD"] = "Y";
            }

            Paid_Calculation();
            Total_Calculation();
        }
    }
}