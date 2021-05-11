using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Reports.ReportViewer
{
    public partial class frmReportViewer : Form
    {
        public CrystalDecisions.CrystalReports.Engine.ReportDocument RefReport;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public frmReportViewer(CrystalDecisions.CrystalReports.Engine.ReportDocument refReport, UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            RefReport = refReport;
            CloseControl = clsCtl;
        }
        public frmReportViewer(CrystalDecisions.CrystalReports.Engine.ReportDocument refReport)
        {
            InitializeComponent();
            RefReport = refReport;
            //crystalReportViewer1.ShowExportButton = false;
            //crystalReportViewer1.ShowPrintButton = false;
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