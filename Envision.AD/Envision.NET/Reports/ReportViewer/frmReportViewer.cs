using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Reports.ReportViewer
{
    public partial class frmReportViewer : DevExpress.XtraBars.Ribbon.RibbonForm // Form 
    {
        public CrystalDecisions.CrystalReports.Engine.ReportDocument RefReport;

        public frmReportViewer(CrystalDecisions.CrystalReports.Engine.ReportDocument refReport)
        {

            InitializeComponent();
            RefReport = refReport;
        }
        public frmReportViewer(CrystalDecisions.CrystalReports.Engine.ReportDocument refReport,bool PrintButtonEnaled)
        {
            InitializeComponent();
            RefReport = refReport;
            
            crystalReportViewer1.ShowExportButton = PrintButtonEnaled;//default is false;
            crystalReportViewer1.ShowPrintButton = PrintButtonEnaled;// default is false;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ReportSource = RefReport;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            try
            {
                crystalReportViewer1.ReportSource = RefReport;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}