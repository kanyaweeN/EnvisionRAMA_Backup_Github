using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;
namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ST04 : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_ST04()
        {
            InitializeComponent();
            base.CloseWaitDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

            ReportMangager reportprovider = new ReportMangager();
            frmReportViewer frmViewer = new frmReportViewer(reportprovider.rptDuration(dateTimePicker1.Value, dateTimePicker2.Value));//, formContainer1);
            dlg.Close();
            frmViewer.ShowDialog();
        }

        private void RPT_ST04_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}