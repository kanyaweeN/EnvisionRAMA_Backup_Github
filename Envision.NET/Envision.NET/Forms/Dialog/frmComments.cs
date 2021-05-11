using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmComments : Form
    {
        MyMessageBox msg = new MyMessageBox();
        GBLEnvVariable env = new GBLEnvVariable();

        public frmComments()
        {
            InitializeComponent();
        }
        public string Comments
        {
            set 
            { 
                txtComment.Text = value;
                //txtComment.Text = txtComment.Text.Replace("<F>", "");
                //txtComment.Text = txtComment.Text.Replace("</F>", "");
            }
            get { return txtComment.Text; }
        }    
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtComment.Text.Trim().Length == 0)
            {
                msg.ShowAlert("UID1110", env.CurrentLanguageID);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}