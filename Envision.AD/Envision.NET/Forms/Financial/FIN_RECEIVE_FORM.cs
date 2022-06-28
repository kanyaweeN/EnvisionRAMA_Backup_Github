using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic;
using Envision.Common;
using Miracle.Translator;
using Envision.Plugin.DirectPrint;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Technologist;
using Envision.NET.Properties;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Forms.Financial
{
    public partial class FIN_RECEIVE_FORM : MasterForm
    {
        FINANCIAL FIN;
        Int64 pay_id;
        DateTime from_date;
        DateTime to_date;
        string hn;
        decimal total;
        MyMessageBox msb = new MyMessageBox();
        int _order_id;
        string comments = "";

        public FIN_RECEIVE_FORM(long PAY_ID, string HN, DateTime FROM_DATE, DateTime TO_DATE)
        {
            InitializeComponent();

            this.ControlBox = false;
            this.from_date = new DateTime(FROM_DATE.Year, FROM_DATE.Month, FROM_DATE.Day, 0, 0, 0);
            this.to_date = new DateTime(TO_DATE.Year, TO_DATE.Month, TO_DATE.Day, 23, 59, 59);
            this.hn = HN;
            this.pay_id = PAY_ID;

            FIN = new FINANCIAL();
            //DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, 0, from_date, to_date);
            //DataTable dt = FIN.FIN_RECEIVE.Select.Detail(hn, -5, from_date, to_date);
            DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, -7, from_date, to_date);
            gridControl1.DataSource = dt;
            this._order_id = Convert.ToInt32(dt.Rows[0]["ORDER_ID"].ToString());

            DataTable table = FIN.FIN_RECEIVE.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];
            textbox_addtext(row);
            int i_pay = Convert.ToInt32(PAY_ID);
            DataTable dtPay = FIN.FIN_RECEIVE.Select.Master(i_pay);

            txtRefName.Text = dtPay.Rows[0]["REF_NAME"].ToString();
            txtRefAddress.Text = dtPay.Rows[0]["REF_ADR"].ToString();
            txtDOB.DateTime = Convert.ToDateTime(dtPay.Rows[0]["DOB"].ToString());
            txtRegDT.DateTime = Convert.ToDateTime(dtPay.Rows[0]["ORDER_START_TIME"].ToString());
            
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
            //string str = table1.Rows[0]["INSURANCE_TYPE_ID"].ToString();
            //if (str == "4")
            //{
            //    radioButton1.Enabled = false;
            //    radioButton2.Enabled = false;
            //    radioButton3.Enabled = false;
            //    radioButton4.Enabled = false;
            //    radioButton5.Enabled = false;

            //    radioButton5.Checked = true;

            //    txtInsuranceType.Text = table1.Rows[0]["INSURANCE_TYPE_DESC"].ToString();
            //}
            //else
            //{
            //    radioButton1.Enabled = true;
            //    radioButton2.Enabled = true;
            //    radioButton3.Enabled = true;
            //    radioButton4.Enabled = true;
            //    radioButton5.Enabled = true;

            //    radioButton1.Checked = true;

            //    txtInsuranceType.Text = table1.Rows[0]["INSURANCE_TYPE_DESC"].ToString();
            //}
        }
        public FIN_RECEIVE_FORM(long PAY_ID, string HN)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.from_date = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            this.to_date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            this.hn = HN;
            this.pay_id = PAY_ID;

            FIN = new FINANCIAL();
            //DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, 0, from_date, to_date);
            //DataTable dt = FIN.FIN_RECEIVE.Select.Detail(hn, -5, from_date, to_date);
            DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, -8, hn, from_date, to_date);
            gridControl1.DataSource = dt;
            this._order_id =  Convert.ToInt32(dt.Rows[0]["ORDER_ID"].ToString());

            DataTable table = FIN.FIN_RECEIVE.Select.Detail(hn, -1, from_date, to_date);
            DataRow row = table.Rows[0];
            textbox_addtext(row);
            int i_pay = Convert.ToInt32(PAY_ID);
            DataTable dtPay = FIN.FIN_RECEIVE.Select.Master(i_pay);

            txtRefName.Text = dtPay.Rows[0]["REF_NAME"].ToString();
            txtRefAddress.Text = dtPay.Rows[0]["REF_ADR"].ToString();
            txtDOB.DateTime = Convert.ToDateTime(dtPay.Rows[0]["DOB"].ToString());
            txtRegDT.DateTime = Convert.ToDateTime(dtPay.Rows[0]["ORDER_START_TIME"].ToString());

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
                if (string.IsNullOrEmpty(row["FNAME"].ToString()))
                {
                    txtName.Text = row["TITLE_ENG"].ToString()
                + " " + row["FNAME_ENG"].ToString()
                + " " + row["LNAME_ENG"].ToString();
                }
                else
                {
                    txtName.Text = row["TITLE"].ToString()
                                    + " " + row["FNAME"].ToString()
                                    + " " + row["LNAME"].ToString();
                }
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

                string id = msb.ShowAlert("UID2053", 2);
                if (id == "3")
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
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
                else if (id == "2")
                {
                    string status = "";
                    if (radioButton1.Checked) status = "C";
                    else if (radioButton2.Checked) status = "M";
                    else if (radioButton3.Checked) status = "V";
                    else if (radioButton4.Checked) status = "K";
                    else if (radioButton5.Checked) status = "S";

                    string ChangeBaht = "("+ textBaht.ToBahtText(Convert.ToDouble(txtPaid.Text))+")";
                    int PayId = 0;


                    DataTable dtG = (DataTable)gridControl1.DataSource;

                    foreach (DataRow dr in dtG.Rows)
                    {
                        PayId = Convert.ToInt32(dr["PAY_ID"]);
                    }
                    foreach (DataRow row in dtG.Rows)
                    {
                        string add = row["ADD"].ToString();
                        if (add == "Y")
                        {
                            PayId = Convert.ToInt32(row["PAY_ID"]);
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id);
                        }
                    }

                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    if (rowcount == rowIsY.Length)
                    {
                        if (status == "S")
                        {
                           DirectPrint print = new DirectPrint();
                           //print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, PayId, status);
                        }
                        else
                        {
                            DirectPrint printReciept = new DirectPrint();
                            //printReciept.ReceiptDirectPrint(ChangeBaht, PayId);
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
                DataRow dr = gridView1.GetDataRow(focus);
                ProcessGetRISExam exam = new ProcessGetRISExam();
                exam.Invoke();
                DataRow[] drEx = exam.Result.Tables[0].Select("EXAM_ID ="+dr["EXAM_ID"].ToString());
                DataTable tb = (DataTable)gridControl1.DataSource;

                for (int i = 0; i <= drEx.Length-1; i++)
                {
                    if (Convert.ToInt32(drEx[i]["SERVICE_TYPE"]) == 1)
                    {
                        frmComments frm = new frmComments();
                        string Comment = dr["COMMENTS"].ToString();
                        string tag;
                        if (Comment.IndexOf("</F>") > 0)
                        {
                            frm.Comments = getTagXML("F", Comment);
                            tag = frm.Comments;
                        }
                        else
                        {
                            frm.Comments = "";
                            tag = " ";
                            Comment = Comment + "<F> </F>";
                        }
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.ShowDialog();
                        DataRow row = tb.Rows[focus];
                        if (frm.DialogResult == DialogResult.OK)
                        {


                            if (row["ADD"].ToString() == "Y")
                            {
                                row["ADD"] = "N";
                                dr["PAID"] = 0;
                                dr[""] = 0;
                            }
                            else if (row["ADD"].ToString() == "N")
                            {
                                row["ADD"] = "Y";
                                decimal rate = Convert.ToDecimal(row["RATE"]);
                                decimal discount = Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
                                decimal paid = rate + discount;
                                row["PAID"] = paid.ToString("0.00");
                            }

                            dr["COMMENTS"] = comments = Comment.Replace("<F>" + tag + "</F>", "<F>" + frm.Comments + "</F>");
                            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGrid = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                            chkGrid.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
                            chkGrid.ValueChecked = "Y";
                            chkGrid.ValueUnchecked = "N";
                            gridView1.Columns["ADD"].ColumnEdit = chkGrid;
                            chkGrid.Click += new EventHandler(chkAdd_CheckedChanged);
                            //calTotal();
                        }
                        else
                        {
                            if (row["ADD"].ToString() == "Y")
                            {
                                row["ADD"] = "Y";
                                //dr["PAID"] = 0;
                            }
                            else if (row["ADD"].ToString() == "N")
                            {
                                row["ADD"] = "N";
                            }
                            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkGrid = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                             chkGrid.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style8;
                            chkGrid.ValueChecked = "Y";
                            chkGrid.ValueUnchecked = "N";
                            gridView1.Columns["ADD"].ColumnEdit = chkGrid;
                            chkGrid.Click += new EventHandler(chkAdd_CheckedChanged);
                            
                        }
                    }
                    else
                    {
                        DataRow row = tb.Rows[focus];

                            if (row["ADD"].ToString() == "Y")
                            {
                                row["ADD"] = "N";
                                dr["PAID"] = 0;
                            }
                            else if (row["ADD"].ToString() == "N")
                            {
                                row["ADD"] = "Y";
                                decimal rate = Convert.ToDecimal(row["RATE"]);
                                decimal discount = Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
                                decimal paid = rate + discount;
                                row["PAID"] = paid.ToString("0.00");
                            }
                    }
                }

            }

            Paid_Calculation();
            Total_Calculation();
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ChangeBaht = "(" + textBaht.ToBahtText(Convert.ToDouble(txtPaid.Text)) + ")";
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

                string id = msb.ShowAlert("UID2053", 2);
                if (id == "3")
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id);
                        }
                    }
                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    if (rowcount == rowIsY.Length)
                    {
                        if (status == "S")
                        {
                            //RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                            //print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                        else
                        {
                            //RIS.Operational.DirectPrint.DirectPrint printReciept = new RIS.Operational.DirectPrint.DirectPrint();
                            //printReciept.ReceiptDirectPrint(ChangeBaht, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                    }
                    Order ord = new Order(this._order_id);
                    ord.SendBilling(this._order_id);
                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

                    this.Close();
                }
                else if (id == "2")
                {
                    string status = "";
                    if (radioButton1.Checked) status = "C";
                    else if (radioButton2.Checked) status = "M";
                    else if (radioButton3.Checked) status = "V";
                    else if (radioButton4.Checked) status = "K";
                    else if (radioButton5.Checked) status = "S";
                   
                    int PayId = 0;


                    DataTable dtG = (DataTable)gridControl1.DataSource;

                    //foreach (DataRow dr in dtG.Rows)
                    //{
                    //    PayId = Convert.ToInt32(dr["PAY_ID"]);
                    //}
                    foreach (DataRow row in dtG.Rows)
                    {
                        string add = row["ADD"].ToString();
                        if (add == "Y")
                        {
                            PayId = Convert.ToInt32(row["PAY_ID"]);
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id);
                        }
                    }

                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    //if (rowcount == rowIsY.Length)
                    //{
                    if (status == "S")
                    {
                        DirectPrint print = new DirectPrint();
                        print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, PayId, status, txtRefName.Text, txtRefAddress.Text, true);
                        Order ord = new Order(_order_id);
                        ord.SendBilling(_order_id);

                    }
                    else
                    {
                        DirectPrint printReciept = new DirectPrint();
                        //printReciept.ReceiptDirectPrint(ChangeBaht, PayId,status,txtRefName.Text,txtRefAddress.Text,true);
                        printReciept.ReceiptDirectPrint2(ChangeBaht, rowIsY, status, txtRefName.Text, txtRefAddress.Text, true);

                        int chkOrderID = 0;
                        for (int i = 0; i < rowIsY.Length; i++)
                        {

                            if (chkOrderID != Convert.ToInt32(rowIsY[i]["ORDER_ID"]))
                            {
                                Order ord = new Order(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));
                                ord.SendBilling(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));
                                chkOrderID = Convert.ToInt32(rowIsY[i]["ORDER_ID"]);
                            }
                        }
                        //}



                    }

                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

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
        }

        private void barSave_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool found_intervent = false;
            ProcessGetRISOrderdtl getData = new ProcessGetRISOrderdtl();
            DataTable table = getData.Get_Orderdtl_Intervention(this._order_id);
            found_intervent = table.Rows.Count > 0 ? true : false;

            if (found_intervent)
                Save_with_Intetvent_exam();
            else
                Save_with_Non_Intetvent_exam();
        }
        private void Save_with_Intetvent_exam()
        {
            DataTable table1 = (DataTable)gridControl1.DataSource;
            string ChangeBaht = "(" + textBaht.ToBahtText(Convert.ToDouble(txtPaid.Text)) + ")";
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
                try { rate1 = Convert.ToDecimal(row1["RATEPERUNIT"]); }
                catch { rate1 = 0; }
                string strRate = rate1.ToString("0.00");
                string fullname = row1["FULLNAME"].ToString();
                //FIN_RECEIVE_CONFIRM_FORM confirm = new FIN_RECEIVE_CONFIRM_FORM(hn, strRate, fullname, table1);

                string id = msb.ShowAlert("UID2053", 2);
                if (id == "3")
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
                        //string add = row["ADD"].ToString();
                        //if (add == "Y")
                        //{
                            long pay_id = Convert.ToInt64(row["PAY_ID"]);
                            int exam_id = Convert.ToInt32(row["EXAM_ID"]);
                            int item_id = row["ITEM_ID"].ToString() == "" ? 0 : Convert.ToInt32(row["ITEM_ID"]);
                            byte qty = Convert.ToByte(row["QTY"]);
                            decimal rate = Convert.ToDecimal(row["RATEPERUNIT"]);
                            decimal discount = Convert.ToDecimal(row["SETTLEMENT_DISCOUNT"]);
                            decimal payable;
                            try { payable = Convert.ToDecimal(row["PAYABLE"]); }
                            catch { payable = 0; }
                            //try { payable = Convert.ToDecimal(row["PAID"]); }
                            //catch { payable = 0; }
                            decimal paid = Convert.ToDecimal(row["PAID"]);
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id,comments);
                        //}
                    }
                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    if (rowcount == rowIsY.Length)
                    {
                        if (status == "S")
                        {
                            //RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                            //print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                        else
                        {
                            //RIS.Operational.DirectPrint.DirectPrint printReciept = new RIS.Operational.DirectPrint.DirectPrint();
                            //printReciept.ReceiptDirectPrint(ChangeBaht, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                    }
                    //order ord = new order(this._order_id);
                    //ord.SendBilling(this._order_id);
                    Order ord = new Order(_order_id);
                    ord.SendBilling_Intervent(_order_id);
                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

                    this.Close();
                }
                else if (id == "2")
                {
                    string status = "";
                    if (radioButton1.Checked) status = "C";
                    else if (radioButton2.Checked) status = "M";
                    else if (radioButton3.Checked) status = "V";
                    else if (radioButton4.Checked) status = "K";
                    else if (radioButton5.Checked) status = "S";

                    int PayId = 0;


                    DataTable dtG = (DataTable)gridControl1.DataSource;

                    //foreach (DataRow dr in dtG.Rows)
                    //{
                    //    PayId = Convert.ToInt32(dr["PAY_ID"]);
                    //}
                    foreach (DataRow row in dtG.Rows)
                    {
                        //string add = row["ADD"].ToString();
                        //if (add == "Y")
                        //{
                            PayId = Convert.ToInt32(row["PAY_ID"]);
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id,comments);
                        //}
                    }

                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    //if (rowcount == rowIsY.Length)
                    //{
                    if (status == "S")
                    {
                        DirectPrint print = new DirectPrint();
                        print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, PayId, status, txtRefName.Text, txtRefAddress.Text, true);
                        //order ord = new order(_order_id);
                        //ord.SendBilling(_order_id);

                        Order ord = new Order(_order_id);
                        ord.SendBilling_Intervent(_order_id);
                    }
                    else
                    {
                        DirectPrint printReciept = new DirectPrint();
                        //printReciept.ReceiptDirectPrint(ChangeBaht, PayId,status,txtRefName.Text,txtRefAddress.Text,true);
                        printReciept.ReceiptDirectPrint2(ChangeBaht, rowIsY, status, txtRefName.Text, txtRefAddress.Text, true);

                        int chkOrderID = 0;
                        for (int i = 0; i < rowIsY.Length; i++)
                        {

                            if (chkOrderID != Convert.ToInt32(rowIsY[i]["ORDER_ID"]))
                            {
                                //order ord = new order(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));
                                //ord.SendBilling(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));

                                Order ord = new Order(_order_id);
                                ord.SendBilling_Intervent(_order_id);
                                chkOrderID = Convert.ToInt32(rowIsY[i]["ORDER_ID"]);
                            }
                        }
                        //}



                    }

                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

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
        }
        private void Save_with_Non_Intetvent_exam()
        {
            DataTable table1 = (DataTable)gridControl1.DataSource;
            string ChangeBaht = "(" + textBaht.ToBahtText(Convert.ToDouble(txtPaid.Text)) + ")";
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

                string id = msb.ShowAlert("UID2053", 2);
                if (id == "3")
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id,comments);
                        }
                    }
                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    if (rowcount == rowIsY.Length)
                    {
                        if (status == "S")
                        {
                            //RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                            //print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                        else
                        {
                            //RIS.Operational.DirectPrint.DirectPrint printReciept = new RIS.Operational.DirectPrint.DirectPrint();
                            //printReciept.ReceiptDirectPrint(ChangeBaht, Convert.ToInt32(pay_id), status, txtRefName.Text, txtRefAddress.Text, false);
                        }
                    }
                    Order ord = new Order(this._order_id);
                    ord.SendBilling(this._order_id);
                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

                    this.Close();
                }
                else if (id == "2")
                {
                    string status = "";
                    if (radioButton1.Checked) status = "C";
                    else if (radioButton2.Checked) status = "M";
                    else if (radioButton3.Checked) status = "V";
                    else if (radioButton4.Checked) status = "K";
                    else if (radioButton5.Checked) status = "S";

                    int PayId = 0;


                    DataTable dtG = (DataTable)gridControl1.DataSource;

                    //foreach (DataRow dr in dtG.Rows)
                    //{
                    //    PayId = Convert.ToInt32(dr["PAY_ID"]);
                    //}
                    foreach (DataRow row in dtG.Rows)
                    {
                        string add = row["ADD"].ToString();
                        if (add == "Y")
                        {
                            PayId = Convert.ToInt32(row["PAY_ID"]);
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
                            int org_id = new GBLEnvVariable().OrgID;
                            int created_by = new GBLEnvVariable().UserID;
                            int order_id = Convert.ToInt32(row["ORDER_ID"]);

                            FIN.FIN_RECEIVE.Update.Detail(pay_id, exam_id, item_id, qty, rate
                                                            , discount, payable, paid, status
                                                            , org_id, created_by, order_id);
                        }
                    }

                    DataRow[] rowIsY = ((DataTable)gridControl1.DataSource).Select("ADD='Y'");
                    int rowcount = ((DataTable)gridControl1.DataSource).Rows.Count;
                    //if (rowcount == rowIsY.Length)
                    //{
                    if (status == "S")
                    {
                        //DirectPrint print = new DirectPrint();
                        //print.InvoiceDirectPrint(ChangeBaht, txtPaid.Text, PayId, status, txtRefName.Text, txtRefAddress.Text, true);
                        xrptAIMCFinancialInvoice rpt = new xrptAIMCFinancialInvoice(_order_id);
                        rpt.ShowPreviewDialog();
                        
                        Order ord = new Order(_order_id);
                        ord.SendBilling(_order_id);
                    }
                    else
                    {
                        //DirectPrint printReciept = new DirectPrint();
                        //printReciept.ReceiptDirectPrint(ChangeBaht, PayId,status,txtRefName.Text,txtRefAddress.Text,true);
                        //printReciept.ReceiptDirectPrint2(ChangeBaht, rowIsY, status, txtRefName.Text, txtRefAddress.Text, true);

                        xrptAIMCFinancialInvoice rpt = new xrptAIMCFinancialInvoice(_order_id);
                        rpt.ShowPreviewDialog();

                        int chkOrderID = 0;
                        for (int i = 0; i < rowIsY.Length; i++)
                        {

                            if (chkOrderID != Convert.ToInt32(rowIsY[i]["ORDER_ID"]))
                            {
                                Order ord = new Order(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));
                                ord.SendBilling(Convert.ToInt32(rowIsY[i]["ORDER_ID"]));
                                chkOrderID = Convert.ToInt32(rowIsY[i]["ORDER_ID"]);
                            }
                        }
                        //}



                    }

                    this.DialogResult = DialogResult.OK;
                    //msb.ShowAlert("UID2050", 2);

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
        }

        private void barOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmConsumable frm = new frmConsumable(_order_id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ControlBox = false;
            //frm.ShowDialog();
            //RIS.Forms.Order.frmOrders frm = new RIS.Forms.Order.frmOrders(order_id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FIN = new FINANCIAL();
                //DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, 0, from_date, to_date);
                DataTable dt = FIN.FIN_RECEIVE.Select.Detail(pay_id, -8,hn, from_date, to_date);
                gridControl1.DataSource = dt;
                //this.order_id = Convert.ToInt32(dt.Rows[0]["ORDER_ID"].ToString());

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
                string str = table1.Rows[0]["INSURANCE_TYPE_ID"].ToString();
               
            }
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void normalRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments frm = new frmComments();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);//view1.GetDataRow(view1.FocusedRowHandle);
            string Comment = dr["COMMENTS"].ToString();
            if (Comment.IndexOf("</F>") > 0)
            {
                DataRow[] drAr = Order.Ris_Exam().Select("EXAM_ID = " + dr["EXAM_ID"].ToString());
                //dr["COMMENTS"] = Comment.Replace("<F>" + getTagXML("F", Comment) + "</F>", "");
                dr["RATE"] = drAr[0]["RATE"];

                DataRow[] drClinic = Order.RIS_ClinicType().Select("CLINIC_TYPE_ID = " + dr["CLINIC_TYPE"].ToString());

                switch (drClinic[0]["CLINIC_TYPE_UID"].ToString())
                {
                    case "Normal":
                        dr["RATE"] = drAr[0]["RATE"];
                        break;
                    case "Special":
                        dr["RATE"] = drAr[0]["SPECIAL_RATE"];
                        break;
                    case "VIP":
                        dr["RATE"] = drAr[0]["VIP_RATE"];
                        break;
                    default:
                        break;
                }

                calTotal();
            }
        }

        private void freeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComments frm = new frmComments();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string Comment = dr["COMMENTS"].ToString();
            string tag;
            if (Comment.IndexOf("</F>") > 0)
            {
                frm.Comments = getTagXML("F", Comment);
                tag = frm.Comments;
            }
            else
            {
                frm.Comments = "";
                tag = " ";
                Comment = Comment + "<F> </F>";
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                dr["COMMENTS"] = Comment.Replace("<F>" + tag + "</F>", "<F>" + frm.Comments + "</F>");
                dr["PAID"] = 0;
                calTotal();
            }
        }
        private void calTotal()
        {
            decimal total = 0.0M;
            DataTable dv = (DataTable)gridControl1.DataSource;
            foreach (DataRow dr in dv.Rows)
            {
                decimal taxTemp = dr["PAID"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["PAID"]);
                int qty = dr["QTY"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["QTY"]);

                total = total + (taxTemp * qty);
            }
            txtTotal.Text = total.ToString("#,##0.00");
            txtPaid.Text = total.ToString("#,##0.00");
        }
        public string getTagXML(string tag, string TextXML)
        {
            string TagData, Ftag, Ltag;
            Ftag = "<" + tag + ">";
            Ltag = "</" + tag + ">";
            try
            {
                TagData = TextXML.Substring(TextXML.IndexOf(Ftag) + 3, TextXML.IndexOf(Ltag) - (TextXML.IndexOf(Ftag) + 3));
            }
            catch { return ""; }
            return TagData;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                DataTable dtt = (DataTable)gridControl1.DataSource;
                string SetRate = dtt.Rows[gridView1.FocusedRowHandle]["COMMENTS"].ToString();
                if (SetRate.Length > 3)
                {
                    SetRate = SetRate.Substring(0, 3).ToUpper();
                }
                switch (SetRate)
                {
                    case "<F>":
                        normalRateToolStripMenuItem.Image = null;
                        freeRateToolStripMenuItem.Image = Resources.QA;
                        break;
                    default:
                        normalRateToolStripMenuItem.Image = Resources.QA;
                        freeRateToolStripMenuItem.Image = null;
                        break;
                }
            }
        }
    }
}