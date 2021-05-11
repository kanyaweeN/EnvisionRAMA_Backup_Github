using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Forms.Order.WaitDialog
{
    public partial class frmDocInstruction : Form
    {
        public string REF_DOC=string.Empty;
        public string CLINIC = string.Empty;
        public frmDocInstruction()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRefDoc.Text = string.Empty;
            txtClinic.Text = string.Empty;
            txtRefDoc.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            REF_DOC = txtRefDoc.Text;
            CLINIC = txtClinic.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void frmDocInstruction_Load(object sender, EventArgs e)
        {
            txtRefDoc.Text=REF_DOC;
            txtClinic.Text = CLINIC;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}