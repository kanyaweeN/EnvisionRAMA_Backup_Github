using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.Common.Common;
using System.Data;
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic;
using System.IO;
using EnvisionOnline.ReportViewer.Reports;
using DevExpress.XtraPrinting;
using EnvisionOnline.Operational.XtraReport.xtraReports;
using EnvisionOnline.BusinessLogic.ProcessUpdate;

namespace EnvisionOnline.ReportViewer
{
    public partial class frmXtraReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string xtraForm = "";
                string order_id = "";
                string IS_ONL = "";
                string acc = "";
                string paperK = "";
                string printor = "";
                int _user_id = 0;
                int _org_id = 1;
                string exmUid = "";

                if (Request.QueryString["XTRAFORM"] != null)
                    xtraForm = Request.QueryString["XTRAFORM"].ToString();
                if (Request.QueryString["ORDER_ID"] != null)
                    order_id = Request.QueryString["ORDER_ID"].ToString();
                if (Request.QueryString["IS_ONLINE"] != null)
                    IS_ONL = Request.QueryString["IS_ONLINE"].ToString();
                if (Request.QueryString["ACCESSION_NO"] != null)
                    acc = Request.QueryString["ACCESSION_NO"].ToString();
                if (Request.QueryString["PAPERKIND"] != null)
                    paperK = Request.QueryString["PAPERKIND"].ToString();
                if (Request.QueryString["PRINTOR"] != null)
                    printor = Request.QueryString["PRINTOR"].ToString();
                if (Request.QueryString["USER_ID"] != null)
                    _user_id = Convert.ToInt32(Request.QueryString["USER_ID"]);
                if (Request.QueryString["ORG_ID"] != null)
                    _org_id = Convert.ToInt32(Request.QueryString["ORG_ID"]);
                if (Request.QueryString["EXAM_UID"] != null)
                    exmUid = Request.QueryString["EXAM_UID"].ToString();

                switch (xtraForm)

                {
                    case "xrptResultReportEnvision":
                        string examName;
                        DataTable dt = new DataTable();
                        ResultEntry result = new ResultEntry();
                        result.getResultReportData(acc,out dt,out examName);

                        printReport(acc, dt, printor, examName, paperK);
                        break;
                    case "xrptOrderReport":
                        using (MemoryStream ms = new MemoryStream())
                        {
                            xrptOrderReport report = new xrptOrderReport(Convert.ToInt32(order_id), Convert.ToBoolean(IS_ONL), _user_id);
                            report.CreateDocument();
                            PdfExportOptions opts = new PdfExportOptions();
                            opts.ShowPrintDialogOnOpen = true;
                            report.ExportToPdf(ms, opts);
                            ms.Seek(0, SeekOrigin.Begin);
                            byte[] report1 = ms.ToArray();
                            Page.Response.ContentType = "application/pdf";
                            Page.Response.Clear();
                            Page.Response.OutputStream.Write(report1, 0, report1.Length);
                            Page.Response.End();
                        }

                        break;
                    case "xrptSchedule":
                        ProcessScheduleReport slkp = new ProcessScheduleReport();
                        int pat_dest_id =  slkp.checkPatientDestination(Convert.ToInt32(order_id));
                        using (MemoryStream ms = new MemoryStream())
                        {
                            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                            switch (pat_dest_id)
                            {
                                case 3: report = new xrptScheduleReportSDMC(Convert.ToInt32(order_id),_org_id,printor); break;
                                case 4: report = new xrptScheduleReportAIMCNew(Convert.ToInt32(order_id), _org_id, printor); break;
                                default: report = new xrptScheduleReport(Convert.ToInt32(order_id), _org_id, printor); break;
                            }
                            
                            report.CreateDocument();
                            PdfExportOptions opts = new PdfExportOptions();
                            opts.ShowPrintDialogOnOpen = true;
                            report.ExportToPdf(ms, opts);
                            ms.Seek(0, SeekOrigin.Begin);
                            byte[] report1 = ms.ToArray();
                            Page.Response.ContentType = "application/pdf";
                            Page.Response.Clear();
                            Page.Response.OutputStream.Write(report1, 0, report1.Length);
                            Page.Response.End();
                        }
                        break;
                    case "xrptScheduleDirect":
                        ProcessScheduleReport slkpDirect = new ProcessScheduleReport();
                        slkpDirect.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(order_id);
                        slkpDirect.RIS_SCHEDULE.ORG_ID = _org_id;
                        slkpDirect.getReport();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            xrptScheduleReport report2 = new xrptScheduleReport(Convert.ToInt32(order_id), _org_id, printor);
                            report2.DataSource = slkpDirect.ResultSet.Tables[1];
                            //ReportPrintTool rpt = new ReportPrintTool(report2);
                            //rpt.Print();
                            ////report2.CreateDocument();
                            ////ReportViewer1.Report = report2;
                            //ReportViewer1.WritePdfTo(this.Response);
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "viewer.Print()", true);
                            //PdfExportOptions opts = new PdfExportOptions();
                            //opts.ShowPrintDialogOnOpen = true;
                            //report.ExportToPdf(ms, opts);
                            //ms.Seek(0, SeekOrigin.Begin);
                            //byte[] report1 = ms.ToArray();
                            //Page.Response.ContentType = "application/pdf";
                            //Page.Response.Clear();
                            //Page.Response.OutputStream.Write(report1, 0, report1.Length);
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Javascript", "viewer.Print()", true);
                        //ClientScript.RegisterClientScriptBlock(GetType(), "Javascript", "<script>function(s, e) {viewer.Print();}</script>",true);
                        break;
                    case "xrptNavigatorApplication":
                        ProcessScheduleReport scheNav = new ProcessScheduleReport();
                        scheNav.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(order_id);
                        scheNav.RIS_SCHEDULE.ORG_ID = _org_id;
                        scheNav.getReportNav();
                        using (MemoryStream ms = new MemoryStream())
                        {
                            xrptNavigatorApplication report = new xrptNavigatorApplication(printor, scheNav.ResultSet.Tables[0], scheNav.ResultSet.Tables[1], exmUid);
                            report.CreateDocument();
                            PdfExportOptions opts = new PdfExportOptions();
                            opts.ShowPrintDialogOnOpen = true;
                            report.ExportToPdf(ms, opts);
                            ms.Seek(0, SeekOrigin.Begin);
                            byte[] report1 = ms.ToArray();
                            Page.Response.ContentType = "application/pdf";
                            Page.Response.Clear();
                            Page.Response.OutputStream.Write(report1, 0, report1.Length);
                            Page.Response.End();
                        }
                        break;
                    case "xtraReportScreening":
                        string _hn = "";
                        string _patient_name = "";
                        int _schedule_id = 0;
                        if (Request.QueryString["HN"] != null)
                            _hn = Request.QueryString["HN"].ToString();
                        if (Request.QueryString["PATIENT_NAME"] != null)
                            _patient_name = Request.QueryString["PATIENT_NAME"].ToString();
                        if (Request.QueryString["SCHEDULE_ID"] != null)
                            _schedule_id = Convert.ToInt32(Request.QueryString["SCHEDULE_ID"].ToString());

                        ProcessUpdateRISSchedule upSchedule = new ProcessUpdateRISSchedule();
                        upSchedule.RIS_SCHEDULE.SCHEDULE_ID = _schedule_id;
                        upSchedule.UpdateIsConsentForm();
                        using (MemoryStream ms = new MemoryStream())
                        {

                            xtraReportScreening report = new xtraReportScreening(_patient_name, _hn);
                            report.CreateDocument();
                            PdfExportOptions opts = new PdfExportOptions();
                            opts.ShowPrintDialogOnOpen = true;
                            report.ExportToPdf(ms, opts);
                            ms.Seek(0, SeekOrigin.Begin);
                            byte[] report1 = ms.ToArray();
                            Page.Response.ContentType = "application/pdf";
                            Page.Response.Clear();
                            Page.Response.OutputStream.Write(report1, 0, report1.Length);
                            Page.Response.End();
                        }
                        break;
                }
            }
        }
        private void printReport(string acc, DataTable dt, string nameUser, string examName,string paperKind)
        {
            LookUpSelect lkPat = new LookUpSelect();
            string patDest = lkPat.SelectPatientDestination(acc).Tables[0].Rows[0]["PAT_DEST_NAME"].ToString();

            switch (patDest) //Considering from Patient Destination Label
            {
                case "AIMC":
                    using (MemoryStream ms = new MemoryStream())
                    {
                        xrptResultReportEnvisionAIMC xrptAIMC = new xrptResultReportEnvisionAIMC(dt, nameUser, examName);
                        if (paperKind == "A5")
                            xrptAIMC.PaperKind = System.Drawing.Printing.PaperKind.A5Rotated;
                        xrptAIMC.DataSource = dt;
                        xrptAIMC.ShowPreviewMarginLines = false;
                        xrptAIMC.CreateDocument();
                        PdfExportOptions opts = new PdfExportOptions();
                        opts.ShowPrintDialogOnOpen = true;
                        xrptAIMC.ExportToPdf(ms, opts);
                        ms.Seek(0, SeekOrigin.Begin);
                        byte[] report1 = ms.ToArray();
                        Page.Response.ContentType = "application/pdf";
                        Page.Response.Clear();
                        Page.Response.OutputStream.Write(report1, 0, report1.Length);
                        Page.Response.End();

                    }
                    break;
                case "SDMC":
                    using (MemoryStream ms = new MemoryStream())
                    {
                        xrptResultReportEnvisionSDMC report = new xrptResultReportEnvisionSDMC(dt, nameUser, examName);
                        if (paperKind == "A5")
                            report.PaperKind = System.Drawing.Printing.PaperKind.A5Rotated;
                        report.DataSource = dt;
                        report.ShowPreviewMarginLines = false;
                        report.CreateDocument();
                        PdfExportOptions opts = new PdfExportOptions();
                        opts.ShowPrintDialogOnOpen = true;
                        report.ExportToPdf(ms, opts);
                        ms.Seek(0, SeekOrigin.Begin);
                        byte[] report1 = ms.ToArray();
                        Page.Response.ContentType = "application/pdf";
                        Page.Response.Clear();
                        Page.Response.OutputStream.Write(report1, 0, report1.Length);
                        Page.Response.End();

                    }
                    break;
                case "DIAG":
                case "MAMMO":
                case "ER":
                default:
                    using (MemoryStream ms = new MemoryStream())
                    {
                        xrptResultReportEnvision report = new xrptResultReportEnvision(dt, nameUser, examName);
                        if (paperKind == "A5")
                            report.PaperKind = System.Drawing.Printing.PaperKind.A5Rotated;
                        report.DataSource = dt;
                        report.ShowPreviewMarginLines = false;
                        report.CreateDocument();
                        PdfExportOptions opts = new PdfExportOptions();
                        opts.ShowPrintDialogOnOpen = true;
                        report.ExportToPdf(ms, opts);
                        ms.Seek(0, SeekOrigin.Begin);
                        byte[] report1 = ms.ToArray();
                        Page.Response.ContentType = "application/pdf";
                        Page.Response.Clear();
                        Page.Response.OutputStream.Write(report1, 0, report1.Length);
                        Page.Response.End();

                    }
                    break;
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('');", true);

        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
            //string xtraForm = "";
            //string order_id = "";
            //string IS_ONL = "";
            //if (Request.QueryString["XTRAFORM"] != null)
            //    xtraForm = Request.QueryString["XTRAFORM"].ToString();
            //if (Request.QueryString["ORDER_ID"] != null)
            //    order_id = Request.QueryString["ORDER_ID"].ToString();
            //if (Request.QueryString["IS_ONLINE"] != null)
            //    IS_ONL = Request.QueryString["IS_ONLINE"].ToString();

            string xtraForm = "";
            string order_id = "";
            string IS_ONL = "";
            string acc = "";
            string paperK = "";
            string printor = "";
            int _user_id = 0;
            int _org_id = 1;

            if (Request.QueryString["XTRAFORM"] != null)
                xtraForm = Request.QueryString["XTRAFORM"].ToString();
            if (Request.QueryString["ORDER_ID"] != null)
                order_id = Request.QueryString["ORDER_ID"].ToString();
            if (Request.QueryString["IS_ONLINE"] != null)
                IS_ONL = Request.QueryString["IS_ONLINE"].ToString();
            if (Request.QueryString["ACCESSION_NO"] != null)
                acc = Request.QueryString["ACCESSION_NO"].ToString();
            if (Request.QueryString["PAPERKIND"] != null)
                paperK = Request.QueryString["PAPERKIND"].ToString();
            if (Request.QueryString["PRINTOR"] != null)
                printor = Request.QueryString["PRINTOR"].ToString();
            if (Request.QueryString["USER_ID"] != null)
                _user_id = Convert.ToInt32(Request.QueryString["USER_ID"]);
            if (Request.QueryString["ORG_ID"] != null)
                _org_id = Convert.ToInt32(Request.QueryString["ORG_ID"]);
            switch (xtraForm)
            {
                case "xrptOrderReport":
                    xrptOrderReport _reportord = new xrptOrderReport(Convert.ToInt32(order_id), Convert.ToBoolean(IS_ONL), _user_id);
                    //_reportord.Print();
                    break;
                case "xrptSchedule":
                    xrptScheduleReport _reportsch = new xrptScheduleReport(Convert.ToInt32(order_id), _org_id, printor);
                    //_reportsch.Print();
                    break;
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        }
    }
}