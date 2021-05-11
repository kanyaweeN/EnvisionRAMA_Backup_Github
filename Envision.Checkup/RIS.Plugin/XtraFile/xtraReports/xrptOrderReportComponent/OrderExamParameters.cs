using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIS.Plugin.XtraFile.xtraReports.xrptOrderReportComponent
{
    public class OrderExamParameters
    {
        public string ExamUID { get; set; }
        public string ExamName { get; set; }
        public Decimal Rate { get; set; }
        public string ExamDate { get; set; }
        public string ExamTime { get; set; }
        public string Priority { get; set; }
        public string Room { get; set; }
        public string Accession { get; set; }
        public string pStatus { get; set; }
        public string Comment { get; set; }
    }
}
