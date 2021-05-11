using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace DisPlayDataSelect
{
    public partial class displaydataselect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Page lastPage = (Page)Context.Handler;
                //if(lastPage is )
                //string StartDate = Session["StartDate"].ToString();
                //string Enddate = Session["EndDate"].ToString();

                //System.Globalization.CultureInfo en = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                //DateTime fdate1, todate1;
                //fdate1 = DateTime.Parse(StartDate).AddYears(543);
                //todate1 = DateTime.Parse(Enddate).AddYears(543);


                //Microsoft.Reporting.WebForms.ReportParameter[] RSSBIRADReport = new Microsoft.Reporting.WebForms.ReportParameter[3];
                //RSSBIRADReport[0] = new Microsoft.Reporting.WebForms.ReportParameter("date_begin", fdate1.ToString());
                //RSSBIRADReport[1] = new Microsoft.Reporting.WebForms.ReportParameter("date_end", todate1.ToString());
                //RSSBIRADReport[2] = new Microsoft.Reporting.WebForms.ReportParameter("MODALITY_ID", "1,2,3");

                //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://user-pc:80/ReportServer");
                ////ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials("USER-PC", "chonchon24", "USER-PC");

                //ReportViewer1.ServerReport.ReportPath = "/Report StatisticBodyPart/ReportStatisticBodyPart";//_ReportPath;// "/Envision_Report_RSS/" + reportName;
                //ReportViewer1.ServerReport.SetParameters(RSSBIRADReport);
                //ReportViewer1.ServerReport.Refresh();

                //ReportViewer1.DataBind();

            }
        }
    }
}