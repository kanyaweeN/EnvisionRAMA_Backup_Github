using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Technologist.Dialog
{
    public partial class Reason : Form
    {
        private string comment = string.Empty;

        public Reason()
        {
            InitializeComponent();
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

        private void Reason_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtComment.Text.Trim().Length == 0)
                e.Cancel = true;
            else
            {
                DialogResult = DialogResult.OK;
                comment = txtComment.Text;
            }

        }
    }
}