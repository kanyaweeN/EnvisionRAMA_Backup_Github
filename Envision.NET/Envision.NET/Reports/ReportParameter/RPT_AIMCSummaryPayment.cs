using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_AIMCSummaryPayment : Envision.NET.Forms.Main.MasterForm
    {
        DataTable dtmodality;
        List<int> mod_id = new List<int>();

        public RPT_AIMCSummaryPayment()
        {
            InitializeComponent();

            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            xrptSummaryPaymentAimc rpt = new xrptSummaryPaymentAimc(dateFrom.DateTime, dateTo.DateTime);
            rpt.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_AIMCSummaryPayment_Load(object sender, EventArgs e)
        {
            ProcessGetRISModality bg = new ProcessGetRISModality(true);
            bg.Invoke();
            dtmodality = bg.Result.Tables[0];

            mod_id.Clear();

            mod_id.Add(0);
            txtModality.Properties.Items.Add("All Modality");

            foreach (DataRow dr in dtmodality.Rows)
            {
                mod_id.Add(Convert.ToInt32(dr["MODALITY_ID"]));
                txtModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString());
            }

            txtModality.SelectedIndex = 0;
            base.CloseWaitDialog();
        }
    }
}
