using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptScheduleCountAppoint : DevExpress.XtraReports.UI.XtraReport
    {
        private string ModalityName;
        public xrptScheduleCountAppoint(string modality)
        {
            InitializeComponent();
            ModalityName = "";
            ModalityName = modality;
        }

        private void txtModality_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtModality.Text = ModalityName;
        }

    }
}
