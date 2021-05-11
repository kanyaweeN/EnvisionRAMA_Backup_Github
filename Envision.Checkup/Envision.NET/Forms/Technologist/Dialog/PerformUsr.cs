using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.Common.DBConnection;
using RIS.Operational;
using RIS.Forms.GBLMessage;
namespace RIS.Forms.Technologist.Dialog
{
    public partial class PerformUsr : Form
    {
        private int perform;
        private dbConnection dc = new dbConnection();
        private string strTmp = string.Empty;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        public PerformUsr()
        {
            InitializeComponent();
            strTmp = lblName.Text.Trim();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == string.Empty) {
                string id = msg.ShowAlert("UID001", new GBLEnvVariable().CurrentLanguageID);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty) {
                string id = msg.ShowAlert("UID002", new GBLEnvVariable().CurrentLanguageID);
                txtPassword.Focus();
                return;
            }
            string sql = "select * from HR_EMP where USER_NAME='" + txtUserName.Text.Trim() + "' and PWD='" + Secure.Encrypt(txtPassword.Text.Trim()) + "' and IS_ACTIVE='Y'";
            DataTable dt = new DataTable();
            dt = dc.SelectDs(sql);
            if (dt.Rows.Count == 0)
            {
                lblName.Text = strTmp;
                msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
                txtUserName.Focus();
                return;
            }
            else
            {
                lblName.Text = dt.Rows[0]["FNAME"].ToString() + " " + dt.Rows[0]["MNAME"].ToString() + dt.Rows[0]["LNAME"].ToString();
                perform = Convert.ToInt32(dt.Rows[0]["EMP_ID"]);
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        public int PerformBy
        {
            get { return perform; }
            set { perform = value; }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk.Focus();
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            btnOk.Focus();
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            txtPassword.Focus();
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }


    }
}