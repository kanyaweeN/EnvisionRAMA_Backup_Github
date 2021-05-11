using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Order
{
    public partial class frmComments : Form
    {
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
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}