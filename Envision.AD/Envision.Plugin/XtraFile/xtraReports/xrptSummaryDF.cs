using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptSummaryDF : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtt = new DataTable();
        public xrptSummaryDF()
        {
            InitializeComponent();
        }
        public xrptSummaryDF(DataTable dt)
        {
            InitializeComponent();
            dtt = dt;
            ShowData();
        }
        public xrptSummaryDF(DataSet ds)
        {
            InitializeComponent();
            grdSummaryDF.DataSource = ds;
        }
        private void ShowData()
        {
            grdSummaryDF.DataSource = dtt;
        }

    }
}
