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
    public partial class RiskTopNAnlysisReport : Envision.NET.Forms.Main.MasterForm
    {
        public RiskTopNAnlysisReport()
        {
            InitializeComponent();
            this.btnClose.Click += new EventHandler(btnClose_Click);
            this.Load += new EventHandler(RiskStatisticReport_Load);
            this.btnRunReport.Click += new EventHandler(btnRunReport_Click);
        }

        #region Run Report
        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            DataSet ds = this.GetReportTopNDataSet();
            if (ds != null)
            {
                XtraTopNAnalysisReport report = new XtraTopNAnalysisReport(ds);
                report.ShowPreview();
            }
        }
        #endregion

        #region First Load
        protected void RiskStatisticReport_Load(object sender, EventArgs e)
        {
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
            try
            {
                ProcessGetRisRptRiskSystemReport processGetRisRptRiskSys = new ProcessGetRisRptRiskSystemReport();
                processGetRisRptRiskSys.Catelog = ProcessGetRisRptRiskSystemReport.Catelogs.TopN;
                if (this.cbIncluding.Text == "Risk Category")
                    processGetRisRptRiskSys.Mode = 2;
                else
                    processGetRisRptRiskSys.Mode = 1;
                processGetRisRptRiskSys.OrgId = 1;
                processGetRisRptRiskSys.TopN = Convert.ToInt32(this.txtTopN.Text);
                processGetRisRptRiskSys.Invoke();
                return processGetRisRptRiskSys.Result;
            }
            catch (Exception) { return null; }
        }
        #endregion
    }
}
