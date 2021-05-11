using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class Exam2SubReport : DevExpress.XtraReports.UI.XtraReport
    {
        public Exam2SubReport()
        {
            InitializeComponent();
            this.pExamUID.DataBindings.Add("Text", DataSource, "ExamUID");
            this.pExamName.DataBindings.Add("Text", DataSource, "ExamName");
            this.pRate.DataBindings.Add("Text", DataSource, "Rate");
            this.pExamDate.DataBindings.Add("Text", DataSource, "ExamDate");
            this.pExamTime.DataBindings.Add("Text", DataSource, "ExamTime");
        }

    }
}
