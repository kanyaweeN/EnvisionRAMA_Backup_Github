using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptSummaryDFByTech : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtt = new DataTable();
        public xrptSummaryDFByTech()
        {
            InitializeComponent();
        }
        public xrptSummaryDFByTech(DataTable dt)
        {
            InitializeComponent();
            dtt = dt;
            ShowData();
        }
        private void ShowData()
        {
            grdSummaryDF.DataSource = dtt;
        }

    }
}
