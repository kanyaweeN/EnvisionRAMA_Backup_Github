using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Plugin.XtrFile.xtrReports;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;

namespace Envision.NET.Risk
{
    public partial class RiskStatisticReport : Envision.NET.Forms.Main.MasterForm
    {
        private DateTime fromDt;
        private DateTime toDt;
        public RiskStatisticReport()
        {
            InitializeComponent();
            this.btnClose.Click += new EventHandler(btnClose_Click);
            this.Load += new EventHandler(RiskStatisticReport_Load);
            this.btnRunReport.Click += new EventHandler(btnRunReport_Click);
            this.chkUseFilter.CheckedChanged += new EventHandler(chkUseFilter_CheckedChanged);
        }

        #region Check Changed Event
        protected void chkUseFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUseFilter.Checked)
            {
                this.cbFilter.Enabled = true;
                this.dtFrom.Enabled = false;
                this.dtTo.Enabled = false;
            }
            else
            {
                this.cbFilter.Enabled = false;
                this.dtFrom.Enabled = true;
                this.dtTo.Enabled = true;
            }
        }
        #endregion

        #region Run Report
        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            //XtraTopNAnalysisReport report = new XtraTopNAnalysisReport(GetReportTopNDataSet());
            XtraRiskStatisticReport report = new XtraRiskStatisticReport(GetReportRiskStatisticDataSet(), toDt, fromDt);
            report.ShowPreview();
            
        }
        #endregion

        #region First Load
        protected void RiskStatisticReport_Load(object sender, EventArgs e)
        {
            this.dtTo.DateTime = DateTime.Today;
            this.dtFrom.DateTime = this.dtTo.DateTime.AddMonths(-1);
            this.CloseWaitDialog();
        }
        #endregion

        #region Close Click
        protected void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Run as Top 'N' Analysis
        public DataSet GetReportTopNDataSet()
        {
            DateTime fromDt = new DateTime(this.dtFrom.DateTime.Year, this.dtFrom.DateTime.Month, this.dtFrom.DateTime.Day, 0, 0, 0);
            DateTime toDt = new DateTime(this.dtTo.DateTime.Year, this.dtTo.DateTime.Month, this.dtTo.DateTime.Day, 23, 59, 59);
            ProcessGetRisRptRiskSystemReport processGetRisRptRiskSys = new ProcessGetRisRptRiskSystemReport();
            processGetRisRptRiskSys.Catelog = ProcessGetRisRptRiskSystemReport.Catelogs.TopN;
            processGetRisRptRiskSys.Mode = 1;
            processGetRisRptRiskSys.OrgId = 1;
            processGetRisRptRiskSys.TopN = 10;
            processGetRisRptRiskSys.FromDt = fromDt;
            processGetRisRptRiskSys.ToDt = toDt;
            processGetRisRptRiskSys.Invoke();
            return processGetRisRptRiskSys.Result;
        }
        #endregion

        public DataSet GetReportRiskStatisticDataSet()
        {
            
            if (!this.chkUseFilter.Checked)
            {
                this.toDt = new DateTime(this.dtFrom.DateTime.Year, this.dtFrom.DateTime.Month, this.dtFrom.DateTime.Day, 0, 0, 0);
                this.fromDt = new DateTime(this.dtTo.DateTime.Year, this.dtTo.DateTime.Month, this.dtTo.DateTime.Day, 23, 59, 59);
            }
            else
            {
                if (this.cbFilter.Text == "Weekly")
                {
                    this.fromDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    this.toDt = this.fromDt.AddDays(-7);
                    this.toDt = new DateTime(this.toDt.Year, this.toDt.Month, this.toDt.Day, 0, 0, 0);
                }
                else if (this.cbFilter.Text == "Monthly")
                {
                    this.fromDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    this.toDt = this.fromDt.AddMonths(-1);
                    this.toDt = new DateTime(this.toDt.Year, this.toDt.Month, this.toDt.Day, 0, 0, 0);
                }
                else if (this.cbFilter.Text == "Yearly")
                {
                    this.fromDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    this.toDt = this.fromDt.AddMonths(-12);
                    this.toDt = new DateTime(this.toDt.Year, this.toDt.Month, this.toDt.Day, 0, 0, 0);
                }
                else if (this.cbFilter.Text == "Quarter")
                {
                    this.fromDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                    this.toDt = this.fromDt.AddMonths(-3);
                    this.toDt = new DateTime(this.toDt.Year, this.toDt.Month, this.toDt.Day, 0, 0, 0);
                }
            }
            ProcessGetRisRptRiskSystemReport processGetRisRptRiskSys = new ProcessGetRisRptRiskSystemReport();
            processGetRisRptRiskSys.Catelog = ProcessGetRisRptRiskSystemReport.Catelogs.Statistic;
            if (this.cbIncluding.Text == "Patient Risk")
                processGetRisRptRiskSys.Mode = 2;
            else if (this.cbIncluding.Text == "Involvement")
                processGetRisRptRiskSys.Mode = 3;
            processGetRisRptRiskSys.OrgId = 1;
            processGetRisRptRiskSys.FromDt = this.toDt;
            processGetRisRptRiskSys.ToDt = this.fromDt;
            processGetRisRptRiskSys.Invoke();
            return processGetRisRptRiskSys.Result;
        }
    }
}
