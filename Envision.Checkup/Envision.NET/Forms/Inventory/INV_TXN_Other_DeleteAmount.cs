using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Inventory
{
    public partial class INV_TXN_Other_DeleteAmount : Form
    {
        public double ResultValue;
        public double LimitValue;

        public INV_TXN_Other_DeleteAmount(double limitvalue)
        {
            InitializeComponent();
            LimitValue = limitvalue;
        }

        private void INV_TXN_Other_DeleteAmount_Load(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FormExit((double)txtAmount.Value);
        }

        private void INV_TXN_Other_DeleteAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FormExit((double)txtAmount.Value);
            }
        }

        private void FormExit(double value)
        {
            if (!ValueChecking(value))
                return;

            ResultValue = value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValueChecking(double value)
        {
            if (value > LimitValue)
            {
                txtWarning.Text = "Value must not over than " + LimitValue.ToString();
                return false;
            }
            
            return true;
        }

        private void buttonEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtAmount.Value = (decimal)e.NewValue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}