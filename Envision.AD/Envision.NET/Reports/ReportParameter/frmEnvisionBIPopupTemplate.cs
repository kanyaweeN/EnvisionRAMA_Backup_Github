using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmEnvisionBIPopupTemplate : Form
    {
        public string BI_NAME { get; set; }
        public string BI_DESC { get; set; }
        public string BI_TAG { get; set; }
        public char IS_GLOBAL { get; set; }

        private string formMODE; //NEW, EDIT

        public frmEnvisionBIPopupTemplate(string formMODE)
        {
            InitializeComponent();
            this.formMODE = formMODE;
        }
        private void frmEnvisionOLAPAddTemplate_Load(object sender, EventArgs e)
        {
            if (formMODE == "EDIT")
            {
                txtName.Text = BI_NAME;
                txtDescription.Text = BI_DESC;
                txtTags.Text = BI_TAG;
                if (IS_GLOBAL == 'Y')
                    txtIsGlobal.SelectedIndex = 0;
                else
                    txtIsGlobal.SelectedIndex = 1;
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
                MessageBox.Show("Please fill the Name of template");

            BI_NAME = txtName.Text.Trim();
            BI_DESC = txtDescription.Text.Trim();
            BI_TAG = txtTags.Text.Trim();
            IS_GLOBAL = txtIsGlobal.SelectedIndex == 0 ? 'Y' : 'N';

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
