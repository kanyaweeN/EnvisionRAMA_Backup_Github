using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Financial
{
    public partial class FIN_RECEIVE_SelectAmount : Form
    {
        public decimal ResultValue;
        public decimal LimitValue;

        public FIN_RECEIVE_SelectAmount(decimal limitvalue)
        {
            InitializeComponent();
            LimitValue = limitvalue;
        }

        private void INV_TXN_Other_DeleteAmount_Load(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FormExit((decimal)txtAmount.Value);
        }

        private void FormExit(decimal value)
        {
            if (!ValueChecking(value))
                return;

            ResultValue = value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValueChecking(decimal value)
        {
            double checknonZero = Convert.ToDouble(txtAmount.Value);
            if (checknonZero < 1)
            {
                txtWarning.Text = "Value equal zero";
                return false;
            }

            if (checknonZero > 9999999)
            {
                txtWarning.Text = "Value out of range 9,999,999.99";
                return false;
            }

            if (value > LimitValue)
            {
                txtWarning.Text = "Value must not over than " + LimitValue.ToString();
                return false;
            }
            
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                FormExit((decimal)txtAmount.Value);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}