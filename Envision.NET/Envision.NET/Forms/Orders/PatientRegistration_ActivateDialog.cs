using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Envision.NET.Forms.Orders
{
    public partial class PatientRegistration_ActivateDialog : Form
    {
        private string activateCode = "";

        public PatientRegistration_ActivateDialog()
        {
            InitializeComponent();

            textEdit1.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            string str1 = textEdit1.Text.Trim();
            string str2 = textEdit2.Text.Trim();
            string str3 = textEdit3.Text.Trim();
            string str4 = textEdit4.Text.Trim();
            string str5 = textEdit5.Text.Trim();
            string str6 = textEdit6.Text.Trim();
            string str7 = textEdit7.Text.Trim();

            if (str1.Length < 4 || str2.Length < 4 || str3.Length < 4
                || str4.Length < 4 || str5.Length < 4 || str6.Length < 4 || str7.Length < 4)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Hide();
            }
            else
            {
                activateCode = str1 + "-" + str2
                                + "-" + str3 + "-" + str4
                                + "-" + str5 + "-" + str6
                                + "-" + str7;

                DirectoryInfo di = Directory.CreateDirectory(@"C:\Envision");

                string path = @"C:\Envision\activeCode.env";
                string createText = activateCode;
                File.WriteAllText(path, createText, Encoding.UTF8);

                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
     
            this.Hide();
        }

        public string ActivateCode
        {
            get { return activateCode; }
            set { activateCode = value; }
        }
    }
}