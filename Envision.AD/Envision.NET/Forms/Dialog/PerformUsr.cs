using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.Common.Linq;
using Envision.Operational;
using Envision.NET.Forms.Dialog;
using System.Linq;
using Miracle.Util;

namespace Envision.NET.Forms.Dialog
{
    public partial class PerformUsr : Form
    {
        private int perform;
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
            //string sql = "select * from HR_EMP where USER_NAME='" + txtUserName.Text.Trim() + "' and PWD='" + Secure.Encrypt(txtPassword.Text.Trim()) + "' and IS_ACTIVE='Y'";
            //DataTable dt = new DataTable();
            //dt = dc.SelectDs(sql);
            //if (dt.Rows.Count == 0)
            //{
            //    lblName.Text = strTmp;
            //    msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
            //    txtUserName.Focus();
            //    return;
            //}
            //else
            //{
            //    lblName.Text = dt.Rows[0]["FNAME"].ToString() + " " + dt.Rows[0]["MNAME"].ToString() + dt.Rows[0]["LNAME"].ToString();
            //    perform = Convert.ToInt32(dt.Rows[0]["EMP_ID"]);
            //}

            #region Check UserName, Password, Authentication.
            EnvisionDataContext db = new EnvisionDataContext();

            IQueryable<HR_EMP> empListData = from emp in db.HR_EMPs select emp;
            IEnumerable<HR_EMP> hrData = null;
            HR_EMP userInfo = new HR_EMP();

            string pwd = Utilities.Encrypt(txtPassword.Text.Trim());
            IEnumerable<HR_EMP> empSelect = from emp in empListData where (emp.USER_NAME == txtUserName.Text) && (emp.PWD == pwd) && (emp.IS_ACTIVE == 'Y') select emp;
            hrData = empSelect.ToList();

            if (hrData == null || hrData.Count() == 0)
            {
                string id = msg.ShowAlert("UID003", new GBLEnvVariable().CurrentLanguageID);
                txtUserName.Focus();
                return;
            }
            else
            {
                userInfo = hrData.Single();
                //lblName.Text = dt.Rows[0]["FNAME"].ToString() + " " + dt.Rows[0]["MNAME"].ToString() + dt.Rows[0]["LNAME"].ToString();
                //perform = Convert.ToInt32(dt.Rows[0]["EMP_ID"]);
                lblName.Text = userInfo.FNAME + " " + userInfo.MNAME == "" ? ("") : (userInfo.MNAME + " ") + userInfo.LNAME;
                perform = userInfo.EMP_ID;
            }
            #endregion
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