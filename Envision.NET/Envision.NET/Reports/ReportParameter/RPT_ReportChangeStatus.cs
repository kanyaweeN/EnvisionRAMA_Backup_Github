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
using Envision.Plugin.DirectPrint;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ReportChangeStatus : Envision.NET.Forms.Main.MasterForm  //Form
    {
        public RPT_ReportChangeStatus()
        {
            InitializeComponent();
            base.CloseWaitDialog();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectReportChangeStatus(dtStart, dtEnd);

                if (ds == null || ds.Tables[1].Rows.Count < 1)
                {
                    dlg.Close();
                    new dialogMessage("No Data!").ShowDialog();
                }
                else
                {
                    Envision.Plugin.XtraFile.xtraReports.XtraReportChangeStatus xrpt = new Envision.Plugin.XtraFile.xtraReports.XtraReportChangeStatus(ds);
                    dlg.Close();
                    xrpt.ShowPreview();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_AppointDate_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}