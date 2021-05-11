using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.Inventory
{
    public partial class INV_TXN_SelectAmount : Form
    {
        public double ResultValue;
        public double LimitValue;
        public INV_TXN_SelectAmount()
        {
            InitializeComponent();
        }
        public INV_TXN_SelectAmount(double limitvalue)
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
            double checknonZero = Convert.ToDouble(txtAmount.Value);
            if (checknonZero < 1)
            {
                txtWarning.Text = "Value equal zero";
                return;
            }

            if (checknonZero > 9999999)
            {
                txtWarning.Text = "Value out of range 9,999,999.99";
                return;
            }

            FormExit((double)txtAmount.Value);
        }

        private void INV_TXN_Other_DeleteAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                double checknonZero = Convert.ToDouble(txtAmount.Value);
                if (checknonZero < 1)
                {
                    txtWarning.Text = "Value equal zero";
                    return;
                }

                if (checknonZero > 9999999)
                {
                    txtWarning.Text = "Value out of range 9,999,999.99";
                    return;
                }
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

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                try
                {
                    double checknonZero = Convert.ToDouble(txtAmount.Value);
                    if (checknonZero < 1)
                    {
                        txtWarning.Text = "Value equal zero";
                        return;
                    }

                    if (checknonZero > 9999999)
                    {
                        txtWarning.Text = "Value out of range 9,999,999.99";
                        return;
                    }
                }
                catch{return;}
                FormExit((double)txtAmount.Value);
            }
            else if ((int)e.KeyChar == 13)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }
    }
}