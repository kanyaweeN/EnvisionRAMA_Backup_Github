using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.ReportViewer.Reports.xrptOrderReportComponent
{
    public class OrderReportParameters
    {
        private string _printDate = string.Format("{0}/{1}/{2}",
            DateTime.Now.Day
            , DateTime.Now.Month
            , DateTime.Now.Year);
        public string OrgName { get; set; }
        public string OrgAddress { get; set; }
        //public string PrintDate { get { return _printDate; } }
        public string PrintDate { get; set; }
        public string PrintTime { get { return DateTime.Now.ToString("HH:mm"); } }
        public string CompanyName { get; set; }
        public string Unit { get; set; }
        public string OrderBy { get; set; }
        public string PrintBy { get; set; }
        public string Clinic { get; set; }
        public byte[] OrgImg { get; set; }
        public string OrgPhone { get; set; }
        public string OrgEmail { get; set; }
        public string OrgWebSite { get; set; }
        public string OrgOrderDescription { get; set; }
        public string PatientStatus { get; set; }
        public string LMP { get; set; }
        public string OrderDT { get; set; }
        public string AppointBy { get; set; }
        public string ClinicalIndication { get; set; }

        public string OrderingDoc { get; set; }
        public string Request_Name { get; set; }
        public string Request_Datetime { get; set; }
        public string Arrived_Name { get; set; }
        public string Arrived_Datetime { get; set; }
    }
}
