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
    public partial class RPT_PamentCheckingReport : Envision.NET.Forms.Main.MasterForm
    {

        public RPT_PamentCheckingReport()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime st = dateEdit1.DateTime;
            DateTime et = dateEdit2.DateTime;

            //xrptPaymentChecking_Dtl prt = new xrptPaymentChecking_Dtl(st, et);
            //xrptPaymentChecking prt = new xrptPaymentChecking(st, et);
            ////prt.DataSource = dt;
            //prt.ShowPreview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Tab.TabPages.RemoveAt(Tab.SelectedIndex);
        }

        private void RPT_PamentCheckingReport_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}
