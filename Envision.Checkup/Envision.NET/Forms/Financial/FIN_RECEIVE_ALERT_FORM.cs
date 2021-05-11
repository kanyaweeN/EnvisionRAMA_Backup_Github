using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using RIS.BusinessLogic;
using RIS.Common;

namespace RIS.Forms.Financial
{
    public partial class FIN_RECEIVE_ALERT_FORM : Form
    {
        string status = "O";

        public FIN_RECEIVE_ALERT_FORM(string hn, string payable, string fullname)
        {
            InitializeComponent();
            txtHeader.Text = "Do you want to receive " + payable + " payment from HN(" + hn + ") Name(" + fullname + ")?"; 
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            saveResult();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveResult()
        {
            status = "";

            if (radioButton1.Checked) status = "C";
            else if (radioButton2.Checked) status = "K";
            else if (radioButton3.Checked) status = "S";
            else status = "O";
        }

        public string statusResult
        {
            get { return status; }
            set { status = value; }
        }
    }
}