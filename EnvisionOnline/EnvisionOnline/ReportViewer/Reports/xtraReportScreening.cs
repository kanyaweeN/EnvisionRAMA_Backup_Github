using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Globalization;
using EnvisionOnline.Operational;

namespace EnvisionOnline.ReportViewer.Reports
{
    public partial class xtraReportScreening : DevExpress.XtraReports.UI.XtraReport
    {
        public xtraReportScreening()
        {
            InitializeComponent();
        }
        public xtraReportScreening(string patient_name, string hn)
        {
            InitializeComponent();
            String pathInStorage = Utilities.ToStringDatetimeTH("วันที่ dd เดือน MMMM yyyy เวลา HH:mm น.", DateTime.Now);

            lblDate1.Text = pathInStorage;
            lblDate2.Text = pathInStorage;


            lblPatientName.Text = patient_name;
            lblPatientName2.Text = patient_name;

            lblHN.Text = hn;
            lblHN2.Text = hn;

        }
    }
}
