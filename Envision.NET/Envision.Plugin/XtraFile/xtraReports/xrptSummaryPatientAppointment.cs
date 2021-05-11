using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.UI;
using Envision.BusinessLogic;


namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptSummaryPatientAppointment : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptSummaryPatientAppointment(DateTime from, DateTime to)
        {
            InitializeComponent();

            DateTime date_from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
            DateTime date_to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);

            string str_from = date_from.ToString("dd/MM/yyyy");
            string str_to = date_to.ToString("dd/MM/yyyy");
            xrlbDateTime.Text = xrlbDateTime.Text.Replace("#F", str_from);
            xrlbDateTime.Text = xrlbDateTime.Text.Replace("#T", str_to);

            LookUpSelect getData = new LookUpSelect();
            DataSet ds = getData.SelectRptSummaryPatientAppointment(date_from, date_to);
            this.DataSource = ds;

            xrtc_HN.DataBindings.Add("Text", ds, "HN", "");
            xrtc_APPOINT_DT.DataBindings.Add("Text", ds, "APPOINT_DT", "");
            xrtc_UNIT_NAME.DataBindings.Add("Text", ds, "UNIT_NAME", "");
            xrtc_EXAM_NAME.DataBindings.Add("Text", ds, "EXAM_NAME", "");

            xrtc_Total_Count.DataBindings.Add("Text", ds, "Total_Count", "");

            //xrRichText1.DataBindings.Add("Text", ds, "EXAM_NAME", "");
        }

    }
}
