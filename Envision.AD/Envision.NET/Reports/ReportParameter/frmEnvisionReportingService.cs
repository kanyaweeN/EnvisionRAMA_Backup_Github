using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.NET.Forms.Main;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmEnvisionReportingService : MasterForm
    {
        public frmEnvisionReportingService()
        {
            InitializeComponent();
        }

        private void frmEnvisionReportingService_Load(object sender, EventArgs e)
        {
            Uri ur = new Uri(this.ReportingSerivce_URL);
            webBrowser1.Url = ur;
            base.CloseWaitDialog();
        }
    }
}