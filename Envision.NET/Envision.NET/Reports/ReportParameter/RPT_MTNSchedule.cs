using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_MTNSchedule : MasterForm
    {
        public RPT_MTNSchedule()
        {
            InitializeComponent();
        }

        private void RPT_ModalityMaintenanceSchedule_Load(object sender, EventArgs e)
        {
            txtFromDate.DateTime = DateTime.Now;
            txtToDate.DateTime = DateTime.Now;
            base.CloseWaitDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ProcessGetRISModalitymaintenanceschedule getData = new ProcessGetRISModalitymaintenanceschedule(0);
            
            DateTime from_date = txtFromDate.DateTime;
            getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = new DateTime(from_date.Year, from_date.Month, from_date.Day, 0, 0, 0);
            
            DateTime to_date = txtToDate.DateTime;
            getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = new DateTime(to_date.Year, to_date.Month, to_date.Day, 23, 59, 59); ;
         
            getData.Invoke();

            XtraMTNSchedule xprt = new XtraMTNSchedule(getData.Result);
            xprt.ShowPreviewDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
