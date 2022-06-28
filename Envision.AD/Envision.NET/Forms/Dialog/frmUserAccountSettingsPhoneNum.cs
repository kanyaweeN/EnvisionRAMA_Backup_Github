using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmUserAccountSettingsPhoneNum : Form
    {
        public event ValueUpdatedEventHandler ValueUpdated;

        public frmUserAccountSettingsPhoneNum()
        {
            InitializeComponent();
        }
        public frmUserAccountSettingsPhoneNum(string editValue)
        {
            InitializeComponent();

            if (editValue.Trim().Length > 0)
            {
                string[] retValues = editValue.Split(new string[] { "#" }, StringSplitOptions.None);
                txtHomePhoneNo.Text = retValues[0];
                txtMobilePhoneNo.Text = retValues[1];
                txtOfficePhoneNo.Text = retValues[2];
            }
        }
        private void frmUserAccountSettingsPhoneNum_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string retValue = "";

            retValue = txtHomePhoneNo.Text.Trim() + "#" + txtMobilePhoneNo.Text.Trim() + "#" + txtOfficePhoneNo.Text.Trim();

            ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(retValue);
            ValueUpdated(this, valueArgs);

            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == '-' || e.KeyChar == (char)Keys.Back)
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return;
            }
            else
            {
                try
                {
                    int output = Convert.ToInt32(e.KeyChar.ToString());
                    e.Handled = false;
                    return;
                }
                catch
                {
                    e.Handled = true;
                }
            }
            e.Handled = true;
        }
    }
}
