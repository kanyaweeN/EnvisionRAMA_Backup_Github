using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports.InterventionDocument
{
    public partial class xrptRFA : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptRFA(string HN, string PatientName, string Age)
        {
            InitializeComponent();
            txtHN.Text = HN;
            txtName.Text = PatientName;
            txtAge.Text = Age;
        }
    }
}
