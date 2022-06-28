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
using Envision.NET.Forms.Dialog;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_AIMCFinancialInvoice : Envision.NET.Forms.Main.MasterForm
    {
        DataTable dtmodality;
        List<int> mod_id = new List<int>();

        public RPT_AIMCFinancialInvoice()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            int orderID = Convert.ToInt32(retValue[0]);

            xrptAIMCFinancialInvoice rpt = new xrptAIMCFinancialInvoice(orderID);
            rpt.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_AIMCSummaryPayment_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }

        private void txtHN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                RunReport();
        }

        private void RunReport()
        {
            LookupAIMCFinancialInvoice lv = new LookupAIMCFinancialInvoice();
            lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
            lv.AddColumn("ORDER_ID", "Order No", true, true);
            lv.AddColumn("XRAY_NO", "Xray No", true, true);
            lv.AddColumn("REG_ID", "ID", false, true);
            lv.AddColumn("HN", "HN", true, true);
            lv.AddColumn("ACCESSION_NO", "Accession No", true, true);
            lv.AddColumn("Exam", "Exam", true, true);
            lv.AddColumn("ORDER_DT", "Date", true, true);
            lv.Text = "Xray Search";

            LookUpSelect lvS = new LookUpSelect();
            lv.Data = lvS.SelectAIMCFinancialInvoiceFrom(txtHN.Text).Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
    }
}
