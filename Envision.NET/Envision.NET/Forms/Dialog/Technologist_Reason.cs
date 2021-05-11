using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Forms.Dialog
{
    public partial class Technologist_Reason : Form
    {
        private string comment = string.Empty;

        public Technologist_Reason()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtComment.Text.Trim().Length==0)
            {
                txtComment.Focus();
                return;
            }
            comment = txtComment.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}