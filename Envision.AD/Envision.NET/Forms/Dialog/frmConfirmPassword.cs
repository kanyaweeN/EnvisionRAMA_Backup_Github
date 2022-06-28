using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
namespace Envision.NET.Forms.Dialog
{
    public partial class frmConfirmPassword : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();

        public frmConfirmPassword()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            txtUserName.Text = env.UserName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            confirmPassword();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void confirmPassword()
        {
            if (txtPassword.Text.Trim() == env.PasswordAD)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            MyMessageBox msg = new MyMessageBox();
            msg.ShowAlert("UID2048", env.CurrentLanguageID);
            msg.Dispose();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                confirmPassword();
            }
        }
    }
}
//RECONFIRM_PASS_ON_SAVE
