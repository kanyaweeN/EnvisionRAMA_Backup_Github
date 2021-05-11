using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Forms.Orders
{
    public partial class frmPopupClinicalIndication : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPopupClinicalIndication()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show dialog with clinical indication
        /// </summary>
        /// <param name="txtClinicalIndication"></param>
        public void ShowDialog(string txtClinicalIndication)
        {
            this.mmClinicalIndication.Text = txtClinicalIndication;
            this.ShowDialog();
        }

        protected override void OnClosed(EventArgs e)
        {
            this.mmClinicalIndication.Text = string.Empty;
            base.OnClosed(e);
        }

        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}