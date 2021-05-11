using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using DevExpress.XtraGrid;


namespace RIS.Forms.Financial
{
    public partial class FIN_RECEIVE_WORKLIST : Form
    {
        FINANCIAL FIN;
        UUL.ControlFrame.Controls.TabControl closeControl;

        public FIN_RECEIVE_WORKLIST(UUL.ControlFrame.Controls.TabControl tabControl)
        {
            InitializeComponent();
            closeControl = tabControl;
            dedFrom.DateTime = dedTo.DateTime = DateTime.Now;

            FIN = new FINANCIAL();
            gridControl1.DataSource = FIN.FIN_RECEIVE.Select.Master(dedFrom.DateTime,dedTo.DateTime);

            DataTable table = (DataTable)gridControl1.DataSource;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        string hn = row["HN"].ToString();
                        int exam_id = 0;
                        long pay_id = Convert.ToInt64(row["PAY_ID"]);

                        //DataTable tb = FIN.FIN_RECEIVE.Select.Detail(hn, exam_id, dedFrom.DateTime, dedTo.DateTime);
                        DataTable tb = FIN.FIN_RECEIVE.Select.Detail(pay_id, exam_id, dedFrom.DateTime, dedTo.DateTime);

                        int lenght = tb.Rows.Count;
                        if (lenght < 1)
                            row["STATUS"] = "PAID";
                        else
                            row["STATUS"] = "UNPAID";

                        #region oldCode
                        //double payable = Convert.ToDouble(row["TOTAL_PAYABLE"]);
                        //if (payable == 0)
                        //    row["STATUS"] = "PAID";
                        //else
                        //    row["STATUS"] = "UNPAID";
                        #endregion oldCode
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            Gridview1_Condition_Setting();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FormRefreshing();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            OpenNewForm();
        }
        private void btnGridPaynow_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenNewForm();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormRefreshing();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            int index = closeControl.SelectedIndex;
            closeControl.TabPages.RemoveAt(index);
        }

        private void FormRefreshing()
        {
            DateTime dt1 = dedFrom.DateTime;
            DateTime dt2 = dedTo.DateTime;
            gridControl1.DataSource = FIN.FIN_RECEIVE.Select.Master(dt1, dt2);

            DataTable table = (DataTable)gridControl1.DataSource;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        string hn = row["HN"].ToString();
                        int exam_id = 0;
                        long pay_id = Convert.ToInt64(row["PAY_ID"]);

                        //DataTable tb = FIN.FIN_RECEIVE.Select.Detail(hn, exam_id, dedFrom.DateTime, dedTo.DateTime);
                        DataTable tb = FIN.FIN_RECEIVE.Select.Detail(pay_id, exam_id, dedFrom.DateTime, dedTo.DateTime);

                        int lenght = tb.Rows.Count;
                        if (lenght < 1)
                            row["STATUS"] = "PAID";
                        else
                            row["STATUS"] = "UNPAID";
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        private void Gridview1_Condition_Setting()
        {
            StyleFormatCondition cn;
            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "UNPAID");
            cn.Appearance.ForeColor = Color.Red;
            gridView1.FormatConditions.Add(cn);
            cn = new StyleFormatCondition(FormatConditionEnum.Equal, gridView1.Columns["STATUS"], null, "PAID");
            cn.Appearance.ForeColor = Color.Green;
            gridView1.FormatConditions.Add(cn);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OpenNewForm();
            }
            else if (e.KeyChar == (char)Keys.F5)
            {
                FormRefreshing();
            }
        }

        private void OpenNewForm()
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataRow row = gridView1.GetDataRow(focus);
                bool paid = row["STATUS"].ToString().ToUpper().StartsWith("U");
                //bool paid = true;
                if (paid)
                {
                    long pay_id = Convert.ToInt64(row["PAY_ID"]);
                    string hn = row["HN"].ToString();
                    DateTime from_date = dedFrom.DateTime;
                    DateTime to_date = dedTo.DateTime;

                    //FIN_RECEIVE_FORM fin_receive = new FIN_RECEIVE_FORM(hn, from_date, to_date);
                    FIN_RECEIVE_FORM fin_receive = new FIN_RECEIVE_FORM(pay_id, hn, from_date, to_date);
                    this.Enabled = false;
                    if (fin_receive.ShowDialog() == DialogResult.OK)
                    {
                        FormRefreshing();
                        fin_receive.Close();
                    }
                    this.Enabled = true;

                    gridView1.Focus();
                }
            }
        }

        private void FIN_RECEIVE_WORKLIST_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F5)
            {
                FormRefreshing();
            }
        }

    }
}