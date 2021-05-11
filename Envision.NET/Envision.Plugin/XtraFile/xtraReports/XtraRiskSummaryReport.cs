using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;

namespace Envision.Plugin.XtrFile.xtrReports
{
    public partial class XtraRiskSummaryReport : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet dsReport;
        private DateTime from;
        private DateTime to;
        public XtraRiskSummaryReport(DataSet report, DateTime fromDt, DateTime toDt)
        {
            if(report.Tables.Count > 1)
                this.DataSource = report.Tables[1];
            this.dsReport = report;
            this.from = fromDt;
            this.to = toDt;
            InitializeComponent();
            this.InitializeReportDataSource();
        }

        public XtraRiskSummaryReport(DataSet reportDataSet)
            : this(reportDataSet, DateTime.Now, DateTime.Now) { }

        public XtraRiskSummaryReport()
            : this(new DataSet(), DateTime.Now, DateTime.Now) { }

        private void InitializeReportDataSource()
        {
            if (dsReport != null)
            {
                if (dsReport.Tables.Count > 1)
                {
                    if (dsReport.Tables[0].Rows.Count > 0)
                    {
                        //Set Org Image
                        byte[] OrgImg = (byte[])(this.dsReport.Tables[0].Rows[0]["ORG_IMG"]);
                        using (MemoryStream imgStream = new MemoryStream(OrgImg))
                        {
                            Image img = Bitmap.FromStream(imgStream);
                            Bitmap bmp = new Bitmap(img, 50, 50);
                            this.pxOrgImg.Image = bmp;
                        }
                        //Set Header
                        this.txtH1.Text = this.dsReport.Tables[0].Rows[0]["ORG_NAME"].ToString();
                        this.txtH2.Text = string.Format("{0} {1} {2} {3} Tel: {4} Fax: {5}",
                            this.dsReport.Tables[0].Rows[0]["ORG_ADDR1"].ToString(),
                            this.dsReport.Tables[0].Rows[0]["ORG_ADDR2"].ToString(),
                            this.dsReport.Tables[0].Rows[0]["ORG_ADDR3"].ToString(),
                            this.dsReport.Tables[0].Rows[0]["ORG_ADDR4"].ToString(),
                            this.dsReport.Tables[0].Rows[0]["ORG_TEL1"].ToString().Trim(),
                            this.dsReport.Tables[0].Rows[0]["ORG_FAX"].ToString().Trim());

                        this.txtPrintDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                        this.txtDtFrom.Text = from.ToLongDateString();
                        this.txtDtTo.Text = to.ToLongDateString();
                        this.txtPrintBy.Text = new Envision.Common.GBLEnvVariable().FirstName + " " + new Envision.Common.GBLEnvVariable().LastName;
                    }
                    if (dsReport.Tables[1].Rows.Count > 0)
                    {
                        this.xrCols1.Text = this.dsReport.Tables[1].Rows[0]["COLS1"].ToString();
                        this.xrCols2.Text = this.dsReport.Tables[1].Rows[0]["COLS2"].ToString();
                        this.txtDescription.Text = this.dsReport.Tables[1].Rows[0]["HEADER1"].ToString();
                        this.xrR1COLS1.Text = this.dsReport.Tables[1].Rows[0]["RCOLS1"].ToString();
                        this.xrR1COLS2.Text = this.dsReport.Tables[1].Rows[0]["COUNT"].ToString();
                    }
                    if (dsReport.Tables.Count > 2)
                    {
                        if (dsReport.Tables[2].Rows.Count > 0)
                        {
                            this.xrR2COLS1.Text = this.dsReport.Tables[2].Rows[0]["RCOLS1"].ToString();
                            this.xrR2COLS2.Text = this.dsReport.Tables[2].Rows[0]["COUNT"].ToString();
                        }
                    }
                    if (dsReport.Tables.Count > 3)
                    {
                        if (dsReport.Tables[3].Rows.Count > 0)
                        {
                            this.xrR3COLS1.Text = this.dsReport.Tables[3].Rows[0]["RCOLS1"].ToString();
                            this.xrR3COLS2.Text = this.dsReport.Tables[3].Rows[0]["COUNT"].ToString();
                        }
                    }
                }
            }
        }
    }
}
