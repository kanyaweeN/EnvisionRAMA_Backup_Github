using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;
using Envision.BusinessLogic;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptSummaryPaymentAimc : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptSummaryPaymentAimc(DateTime from, DateTime to)
        {
            InitializeComponent();

            DateTime date_from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
            DateTime date_to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

            string str_from = date_from.ToString("dd/MM/yyyy");
            string str_to = date_to.ToString("dd/MM/yyyy");
            xrlbDateTime.Text = xrlbDateTime.Text.Replace("#F", str_from);
            xrlbDateTime.Text = xrlbDateTime.Text.Replace("#T", str_to);

            LookUpSelect getData = new LookUpSelect();
            DataSet ds = getData.SelectRptAIMCSummaryPayment(date_from, date_to);
            this.DataSource = ds;

            xrtc_HN.DataBindings.Add("Text", ds, "HN", "");
            xrtc_EXAM_CODE.DataBindings.Add("Text", ds, "EXAM_CODE", "");
            xrtc_RATE.DataBindings.Add("Text", ds, "RATE", "");

            xrtc_RATE_SUM.DataBindings.Add("Text", ds, "RATE_SUM", "");
            xrtc_FACULTY.DataBindings.Add("Text", ds, "FACULTY", "");
            xrtc_FOUNDATION.DataBindings.Add("Text", ds, "FOUNDATION", "");

            xrtc_Total_Count.DataBindings.Add("Text", ds, "Total_Count", "");
            xrtc_Total_RATE.DataBindings.Add("Text", ds, "RATE", "");
            xrtc_Total_RATE_SUM.DataBindings.Add("Text", ds, "RATE", "");
            xrtc_Total_FACULTY.DataBindings.Add("Text", ds, "FACULTY", "");
            xrtc_Total_FOUNDATION.DataBindings.Add("Text", ds, "FOUNDATION", "");
        }

    }
}
