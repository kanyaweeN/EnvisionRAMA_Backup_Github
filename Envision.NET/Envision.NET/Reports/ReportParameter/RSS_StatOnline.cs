using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RSS_StatOnline : Envision.NET.Forms.Main.MasterForm
    {
        private string FromDate, ToDate ;
        private string groupType, durationMode, reportType;
        public RSS_StatOnline()
        {
            InitializeComponent();

            ProcessGetRSS_StatOnline objParameter = new ProcessGetRSS_StatOnline();
            FromDate = objParameter.GetFromDate;
            ToDate = objParameter.GetToDate;
            groupType = objParameter.GetGroupType;
            durationMode = objParameter.GetDurationType;
            reportType = objParameter.GetReportType;
        }

  
        private void RSS_StatOnline_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            //this.reportViewer1.RefreshReport();

            string reportURL, reportUser, reportPassword, reportDomain;

            reportURL = System.Configuration.ConfigurationSettings.AppSettings["reportingServer"];
            reportUser = System.Configuration.ConfigurationSettings.AppSettings["reportingUser"];
            reportPassword = System.Configuration.ConfigurationSettings.AppSettings["reportingPassword"];
            reportDomain = System.Configuration.ConfigurationSettings.AppSettings["reportingDomain"];

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri(reportURL);
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential(reportUser, reportPassword, reportDomain);

            string reportName;
            switch (reportType)
            {
                case "RSS_StatOnlineRequestXray":
                    reportName = "RSS_StatOnlineRequestXray";
                    reportViewer1.ServerReport.ReportPath = "/Envision_Report_RSS/" + reportName;

                    Microsoft.Reporting.WinForms.ReportParameter[] RptParameters = new Microsoft.Reporting.WinForms.ReportParameter[4];//declare the number of parameters

                    RptParameters[0] = new Microsoft.Reporting.WinForms.ReportParameter("dateBegin", FromDate);// first parameter
                    RptParameters[1] = new Microsoft.Reporting.WinForms.ReportParameter("dateEnd", ToDate);//second parameter
                    RptParameters[2] = new Microsoft.Reporting.WinForms.ReportParameter("clinicType", groupType.ToLower());//second parameter
                    RptParameters[3] = new Microsoft.Reporting.WinForms.ReportParameter("reportType", durationMode.ToLower());

                    reportViewer1.ServerReport.SetParameters(RptParameters);
                    break;
                case "RSS_StatOnlineSchedule":
                    labelControl1.Text = "Online Schedule";
                    reportName = "RSS_StatOnlineSchedule";
                    reportViewer1.ServerReport.ReportPath = "/Envision_Report_RSS/" + reportName;

                    Microsoft.Reporting.WinForms.ReportParameter[] RptParameters1 = new Microsoft.Reporting.WinForms.ReportParameter[4];//declare the number of parameters

                    RptParameters1[0] = new Microsoft.Reporting.WinForms.ReportParameter("dateBegin", FromDate);// first parameter
                    RptParameters1[1] = new Microsoft.Reporting.WinForms.ReportParameter("dateEnd", ToDate);//second parameter
                    RptParameters1[2] = new Microsoft.Reporting.WinForms.ReportParameter("type", groupType.ToLower());//second parameter
 RptParameters1[3] = new Microsoft.Reporting.WinForms.ReportParameter("durationMode", durationMode.ToLower());
                    

                    reportViewer1.ServerReport.SetParameters(RptParameters1);
                    break;
                case "RSS_StatOnlineScheduleWaitingList":
                    labelControl1.Text = "Online Waiting List";
                    reportName = "RSS_StatOnlineScheduleWaitingList";
                    reportViewer1.ServerReport.ReportPath = "/Envision_Report_RSS/" + reportName;

                    Microsoft.Reporting.WinForms.ReportParameter[] RptParameters2 = new Microsoft.Reporting.WinForms.ReportParameter[2];//declare the number of parameters

                    RptParameters2[0] = new Microsoft.Reporting.WinForms.ReportParameter("dateBegin", FromDate);// first parameter
                    RptParameters2[1] = new Microsoft.Reporting.WinForms.ReportParameter("dateEnd", ToDate);

                    reportViewer1.ServerReport.SetParameters(RptParameters2);

                    break;

            }
            //CCustomMessageClass myMessageClass = new CCustomMessageClass();

            //reportViewer1.Messages = myMessageClass;
            reportViewer1.RefreshReport();
        }


    }

    //public class CCustomMessageClass : IReportViewerMessages
    //{

    //    #region IReportViewerMessages Members

    //    public string BackButtonToolTip
    //    {
    //        get { return ("BackButtonToolTip here."); }
    //    }

    //    public string BackMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ChangeCredentialsText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string CurrentPageTextBoxToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string DocumentMapButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string DocumentMapMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ExportButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ExportMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FalseValueText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FindButtonText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FindButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FindNextButtonText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FindNextButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string FirstPageButtonToolTip
    //    {
    //        get { return ("Custom first page tool tip"); }
    //    }

    //    public string LastPageButtonToolTip
    //    {
    //        get { return (null); }
    //    }

    //    public string NextPageButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string NoMoreMatches
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string NullCheckBoxText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string NullCheckBoxToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string NullValueText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PageOf
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PageSetupButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PageSetupMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ParameterAreaButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PasswordPrompt
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PreviousPageButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PrintButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PrintLayoutButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PrintLayoutMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string PrintMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ProgressText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string RefreshButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string RefreshMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string SearchTextBoxToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string SelectAValue
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string SelectAll
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string StopButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string StopMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string TextNotFound
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string TotalPagesToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string TrueValueText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string UserNamePrompt
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ViewReportButtonText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ViewReportButtonToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ZoomControlToolTip
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ZoomMenuItemText
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ZoomToPageWidth
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    public string ZoomToWholePage
    //    {
    //        get { return ("Add your custom text here."); }
    //    }

    //    #endregion
    //}

}
