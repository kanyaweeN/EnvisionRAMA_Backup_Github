using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Globalization;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptSummaryReportDFAIMC : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptSummaryReportDFAIMC()
        {
            InitializeComponent();
        }
        public xrptSummaryReportDFAIMC(DateTime dateFrom,DateTime dateTo)
        {
            InitializeComponent();
            string strDate = "ค่าตอบแทนประจำวันที่ " 
                            + dateFrom.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("th-TH"))
                            + " - "
                            + dateTo.ToString("d MMMM yyyy", CultureInfo.CreateSpecificCulture("th-TH"))
                            ;

            lblDataParamHead.Text = strDate;
            lblDateParamBottom.Text = strDate;
        }
    }
}
