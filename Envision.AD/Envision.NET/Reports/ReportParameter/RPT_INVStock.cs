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
    public partial class RPT_INVStock : Envision.NET.Forms.Main.MasterForm  //Form
    {
        public RPT_INVStock()
        {
            InitializeComponent();
            getHeaderReport();
            base.CloseWaitDialog();
        }
     
        private void getHeaderReport()
        {
            DataTable dtt = new DataTable();
            ProcessGetInvUnit prc = new ProcessGetInvUnit();
            prc.Invoke();
            dtt = prc.ResultTable.Copy();
            dtt.NewRow();
            dtt.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--", "--ทั้งหมด--", 3, 3, 3, DateTime.Now, 3,DateTime.Now,"--ทั้งหมด--", "--ทั้งหมด--",3,"","");
            dtt.AcceptChanges();

            cmbHeaderReport.DisplayMember = "UNIT_NAME";
            cmbHeaderReport.ValueMember = "UNIT_ID";
            cmbHeaderReport.DataSource = dtt;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                int i = 1;
                try { i = Convert.ToInt32(cmbHeaderReport.SelectedValue.ToString()); }
                catch { }
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectrptInvStock(i,dtStart,dtEnd);
                frmReportViewer RForm = new frmReportViewer(reportprovider.rptInvStock(ds.Tables[0]));
                dlg.Close();
                RForm.ShowDialog();
              

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