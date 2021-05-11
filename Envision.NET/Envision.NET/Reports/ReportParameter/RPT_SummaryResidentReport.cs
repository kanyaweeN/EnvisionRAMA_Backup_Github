using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_SummaryResidentReport : Envision.NET.Forms.Main.MasterForm
    {
        public RPT_SummaryResidentReport()
        {
            InitializeComponent();

            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //xrptSummaryResidentReport rpt = new xrptSummaryResidentReport(dateFrom.DateTime, dateTo.DateTime, 0);
            //rpt.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_SummaryResidentReport_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}
