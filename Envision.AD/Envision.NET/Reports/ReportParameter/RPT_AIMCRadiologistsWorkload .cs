using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic;
using Envision.Plugin.XtraFile.xtraReports;
using Miracle.Util;
using Envision.Plugin.DirectPrint;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_AIMCRadiologistsWorkload : MasterForm
    {
        public RPT_AIMCRadiologistsWorkload()
        {
            InitializeComponent();
        }

        private void RPT_AIMCRadiologistsWorkload_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataTable dt = lk.SelectRadiologistWorkloadAIMC(dtStart, dtEnd).Tables[0];

                //xrptRadiologistWorkload Xrpt = new xrptRadiologistWorkload(ds.Tables[0]);
                //Xrpt.ShowPreview();

                if (dt.Rows.Count > 0)
                {
                    xrptAIMCDailyReport xrpt = new xrptAIMCDailyReport();
                    xrpt.DataSource = dt;
                    xrpt.ShowPreviewMarginLines = false;
                    xrpt.ShowPrintingWarnings = false;
                    xrpt.ShowPreviewDialog();
                    //xrpt.PrintDialog();
                }
                else
                    new dialogMessage("No Data with this data.").ShowDialog();

            }
            catch (Exception ex)
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}