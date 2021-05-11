using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace PassbyParameter
{
    public partial class displaydata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Page lastPage = (Page)Context.Handler;
                if (lastPage is SdmcAppointmentData)
                {
                    string StartDate = ((SdmcAppointmentData)lastPage).startDate;
                    string Enddate = ((SdmcAppointmentData)lastPage).endDate;
                    string[] srcRoom = ((SdmcAppointmentData)lastPage).roomSelect;
                    string[] srcSession = ((SdmcAppointmentData)lastPage).sessionSelect;

                    System.Globalization.CultureInfo en = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    //DateTime fdate1, todate1;
                   
                    //fdate1 = DateTime.Parse(StartDate).AddYears(543);
                    //todate1 = DateTime.Parse(Enddate).AddYears(543);

                    //StartDate = DateTime.Today.ToString("yyyy-MM-dd");
                    //Enddate = DateTime.Today.ToString("yyyy-MM-dd");
                    StartDate = (Convert.ToDateTime(StartDate) - new TimeSpan(0, 0, 0)).ToString();
                    Enddate = (Convert.ToDateTime(Enddate) + new TimeSpan(23, 59, 59)).ToString();


                    Microsoft.Reporting.WebForms.ReportParameter[] RSSBIRADReport = new Microsoft.Reporting.WebForms.ReportParameter[4];
                    RSSBIRADReport[0] = new Microsoft.Reporting.WebForms.ReportParameter("StartTime", StartDate.ToString());
                    RSSBIRADReport[1] = new Microsoft.Reporting.WebForms.ReportParameter("EndTime", Enddate.ToString());
                    RSSBIRADReport[2] = new Microsoft.Reporting.WebForms.ReportParameter("UnitId", srcRoom);
                    RSSBIRADReport[3] = new Microsoft.Reporting.WebForms.ReportParameter("SessionId", srcSession);

                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://miracle9/ReportServer");
                    ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials("administrator", "pacsRM@1", "administrator");

                    ReportViewer1.ServerReport.ReportPath = "/Envision_Report_RSS/SdmcAppointmentDataReport";//_ReportPath;// "/Envision_Report_RSS/" + reportName;
                    ReportViewer1.ServerReport.SetParameters(RSSBIRADReport);
                    ReportViewer1.ServerReport.Refresh();

                    ReportViewer1.DataBind();
                }

            }
        }
    }
}