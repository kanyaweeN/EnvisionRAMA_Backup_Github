using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace EnvisionOnline.Operational.XtraReport.xtraReports
{
    public partial class xrptScheduleReportSubExam : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptScheduleReportSubExam()
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;


            this.pExamCode.DataBindings.Add("Text", DataSource, "EXAM_UID");
            this.pExamName.DataBindings.Add("Text", DataSource, "EXAM_NAME");
            this.pModality.DataBindings.Add("Text", DataSource, "MODALITY_NAME");
            this.pRate.DataBindings.Add("Text", DataSource, "RATE");
            this.pSumRate.DataBindings.Add("Text", DataSource, "RATE");
        }

    }
}
