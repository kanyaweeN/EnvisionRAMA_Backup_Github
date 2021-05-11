using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptScheduleReportSubIns : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptScheduleReportSubIns()
        {
            InitializeComponent();

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
