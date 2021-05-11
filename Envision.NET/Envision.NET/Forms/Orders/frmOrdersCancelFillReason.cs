using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Dialog;
using Envision.Common;

namespace Envision.NET.Forms.Orders
{
    public partial class frmOrdersCancelFillReason : Form
    {
        public string REASON;

        public frmOrdersCancelFillReason()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txtReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //    Form_OKDialog_Closing();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Form_OKDialog_Closing();
        }

        private void Form_OKDialog_Closing()
        {
            if (txtReason.Text.Trim().Length < 1)
            {
                //MessageBox.Show("Reason of Order Cancelling can't be empty!! Please fill the reason.");
                MyMessageBox msg = new MyMessageBox();
                msg.ShowAlert("UID1110", new GBLEnvVariable().CurrentLanguageID);
                txtReason.Focus();
                return;
            }

            REASON = txtReason.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}