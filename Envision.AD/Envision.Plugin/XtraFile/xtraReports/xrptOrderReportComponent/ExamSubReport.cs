using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class ExamSubReport : DevExpress.XtraReports.UI.XtraReport
    {
        private int _countDetail;
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
            _countDetail = 1;
        }

        private void tExamUID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if ((_countDetail % 3) == 0)
                xrPageBreak1.Visible = true;
            else
                xrPageBreak1.Visible = false;
            _countDetail++;
        }

        private void tExamUID_AfterPrint(object sender, EventArgs e)
        {
           
        }
    }
}
