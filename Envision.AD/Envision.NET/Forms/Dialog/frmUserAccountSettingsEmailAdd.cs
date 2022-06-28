using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmUserAccountSettingsEmailAdd : Form
    {
        public event ValueUpdatedEventHandler ValueUpdated;
        string regEx = @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)";

        public frmUserAccountSettingsEmailAdd()
        {
            InitializeComponent();
        }
        public frmUserAccountSettingsEmailAdd(string editValue)
        {
            InitializeComponent();

            if (editValue.Trim().Length > 0)
            {
                string[] retValues = editValue.Split(new string[] { "#" }, StringSplitOptions.None);
                txtOfficeEmail.Text = retValues[0];
                txtPersonalEmail.Text = retValues[1];
            }
        }
        private void frmUserAccountSettingsPhoneNum_Load(object sender, EventArgs e)
        {
            txtPersonalEmail.Properties.Mask.EditMask = regEx;
            txtOfficeEmail.Properties.Mask.EditMask = regEx;
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string retValue = "";

            retValue = txtPersonalEmail.Text.Trim() + "#" + txtOfficeEmail.Text.Trim();

            ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(retValue);
            ValueUpdated(this, valueArgs);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                SendKeys.Send("{Tab}");
        }
    }
}
