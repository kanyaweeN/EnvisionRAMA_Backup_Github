using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RIS.BusinessLogic;

namespace RIS.Forms.Financial
{
    public partial class FIN_CANCEL_WORKLIST : Form
    {
        FINANCIAL FIN;
        UUL.ControlFrame.Controls.TabControl closeControl;

        public FIN_CANCEL_WORKLIST(UUL.ControlFrame.Controls.TabControl tabControl)
        {
            InitializeComponent();
            closeControl = tabControl;
            dedFrom.DateTime = dedTo.DateTime = DateTime.Now;

            FIN = new FINANCIAL();
            DataTable table = FIN.FIN_CANCEL.Select.Master(dedFrom.DateTime, dedTo.DateTime).Copy();
            gridControl1.DataSource = table;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FormRefreshing();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            OpenNewForm();
        }

        private void btnGridCancel_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenNewForm();
        }

        private void bbtnRefresh_Click(object sender, EventArgs e)
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
            gridControl1.DataSource = FIN.FIN_CANCEL.Select.Master(dt1, dt2);
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OpenNewForm();
            }
        }

        private void OpenNewForm()
        {
            int focus = gridView1.FocusedRowHandle;
            if (focus > -1)
            {
                DataRow row = gridView1.GetDataRow(focus);
                bool paid = true;
                if (paid)
                {
                    long pay_id = Convert.ToInt64(row["PAY_ID"]);
                    string hn = row["HN"].ToString();
                    DateTime from_date = dedFrom.DateTime;
                    DateTime to_date = dedTo.DateTime;

                    FIN_CANCEL_FORM fin_receive = new FIN_CANCEL_FORM(pay_id, hn, from_date, to_date);
                    this.Enabled = false;
                    if (fin_receive.ShowDialog() == DialogResult.OK)
                    {
                        FormRefreshing();
                        fin_receive.Close();
                    }
                    this.Enabled = true;
                }
                gridView1.Focus();
            }
        }
    }
}