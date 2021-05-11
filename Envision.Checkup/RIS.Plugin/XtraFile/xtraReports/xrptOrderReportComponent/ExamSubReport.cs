using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace RIS.Plugin.XtraFile.xtraReports
{
    public partial class ExamSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ExamSubReport()
        {
            InitializeComponent();
            this.tRoom.DataBindings.Add("Text", DataSource, "Room");
            this.tExamUID.DataBindings.Add("Text", DataSource, "ExamUID");
            this.tExamName.DataBindings.Add("Text", DataSource, "ExamName");
            this.tRate.DataBindings.Add("Text", DataSource, "Rate");
            this.tExamStatus.DataBindings.Add("Text", DataSource, "Priority");
            this.tExamDate.DataBindings.Add("Text", DataSource, "ExamDate");
            this.tExamTime.DataBindings.Add("Text", DataSource, "ExamTime");

            this.txtAccessionNo.DataBindings.Add("Text", DataSource, "Accession");
            this.txtBarCodeAccession.DataBindings.Add("Text", DataSource, "Accession");
            this.txtComment.DataBindings.Add("Text", DataSource, "Comment");

            XRSummary _count = new XRSummary();
            _count.Func = SummaryFunc.Count;
            _count.Running = SummaryRunning.Report;
            this.tCount.Summary = _count;
            this.tCount.DataBindings.Add("Text", DataSource, "ExamUID");

            XRSummary _sumRate = new XRSummary();
            _sumRate.Func = SummaryFunc.Sum;
            _sumRate.Running = SummaryRunning.Report;
            _sumRate.FormatString = "{0}.00";
            this.tSumRate.Summary = _sumRate;
            this.tSumRate.DataBindings.Add("Text", DataSource, "Rate");
        }

    }
}
