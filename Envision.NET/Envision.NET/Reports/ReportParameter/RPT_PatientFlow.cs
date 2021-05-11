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

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_PatientFlow : Envision.NET.Forms.Main.MasterForm  //Form
    {
        public RPT_PatientFlow()
        {
            InitializeComponent();
            getHeaderReport();
            base.CloseWaitDialog();
        }
     
        private void getHeaderReport()
        {
            //DataTable dtt = new DataTable();
            //Order dr = new Order();
            //dtt = Order.Ris_Radiologist().Copy();
            //dtt.NewRow();
            //dtt.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--", 3, "--ทั้งหมด--", "--ทั้งหมด--", "--ทั้งหมด--");
            //dtt.AcceptChanges();

            //cmbHeaderReport.DisplayMember = "RadioName";
            //cmbHeaderReport.ValueMember = "EMP_ID";
            //cmbHeaderReport.DataSource = dtt;
            
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
                DataSet ds = lk.SelectPatientFlow(dtStart, dtEnd);

                frmReportViewer RForm = new frmReportViewer(reportprovider.rptPatientFlowReport(ds.Tables[0]));
                dlg.Close();
                RForm.ShowDialog();
            }
            catch (Exception ex)
            {
                //throw ex;
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