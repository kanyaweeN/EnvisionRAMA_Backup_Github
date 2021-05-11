using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace EnvisionOnline.ReportViewer.Reports
{
    public partial class xrptScheduleReportSubIns2 : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptScheduleReportSubIns2()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // get the current pupil_id
            string iPupilID = GetCurrentColumnValue("EXAM_UID").ToString();
            string iPreviousPupilID = GetPreviousColumnValue("EXAM_UID").ToString();

            if (iPupilID != iPreviousPupilID)
            {
                // Insert a Page Break
                xrPageBreak1.Visible = true;
            }
            else
            {
                xrPageBreak1.Visible = false;
            }
        }

    }
}
