using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.IO;

namespace Envision.Plugin.XtrFile.xtrReports
{
    public partial class XtraTopNAnalysisReport : DevExpress.XtraReports.UI.XtraReport
    {
        private DataSet dsReport;
        public XtraTopNAnalysisReport(DataSet report)
        {
            if(report.Tables.Count > 1)
                this.DataSource = report.Tables[1];
            this.dsReport = report;
            InitializeComponent();
            this.InitializeReportDataSource();
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(Detail_BeforePrint);
        }

        void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }


        public XtraTopNAnalysisReport()
            :this(new DataSet())
        {
            
        }
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
                        this.txtPrintBy.Text = new Envision.Common.GBLEnvVariable().FirstName + " " + new Envision.Common.GBLEnvVariable().LastName;
                    }
                    if (dsReport.Tables[1].Rows.Count > 0)
                    {
                        this.xrCols1.Text = this.dsReport.Tables[1].Rows[0]["COLS1"].ToString();
                        this.xrCols2.Text = this.dsReport.Tables[1].Rows[0]["COLS2"].ToString();
                        this.xrCols3.Text = this.dsReport.Tables[1].Rows[0]["COLS3"].ToString();

                        this.txtDescription.Text = this.dsReport.Tables[1].Rows[0]["HEADER1"].ToString();

                        this.xrRCols1.DataBindings.Add("Text", this.DataSource, "RCOLS1");
                        this.xrRCols2.DataBindings.Add("Text", this.DataSource, "RCOLS2");
                        this.xrRCols3.DataBindings.Add("Text", this.DataSource, "COUNT");
                    }
                }
            }
        }
    }
}
