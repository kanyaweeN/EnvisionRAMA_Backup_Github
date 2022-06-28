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
using Miracle.Util;
using Envision.Plugin.DirectPrint;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_SummaryDFRadPremium : Envision.NET.Forms.Main.MasterForm  //Form
    {
        public RPT_SummaryDFRadPremium()
        {
            InitializeComponent();
            getHeaderReport();
            base.CloseWaitDialog();
        }
        private void RPT_AppointDate_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
     
        private void getHeaderReport()
        {
            DataTable dtt = new DataTable();
            Order dr = new Order();
            dtt = RISBaseData.Ris_Radiologist().Copy();
            dtt.NewRow();
            dtt.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--", 3, "--ทั้งหมด--", "--ทั้งหมด--", "--ทั้งหมด--");
            dtt.AcceptChanges();

            cmbHeaderReport.DisplayMember = "RadioName";
            cmbHeaderReport.ValueMember = "EMP_ID";
            cmbHeaderReport.DataSource = dtt;

            DataTable dtClinic = RISBaseData.RIS_ClinicType();
            cmbClinic.DisplayMember = "CLINIC_TYPE_TEXT";
            cmbClinic.ValueMember = "CLINIC_TYPE_ID";
            cmbClinic.DataSource = dtClinic;

            DataTable dttmoda = new DataTable();
            ProcessGetRISModality modality = new ProcessGetRISModality(true);
            modality.Invoke();
            dttmoda = modality.Result.Tables[0].Copy();

            dttmoda.NewRow();
            dttmoda.Rows.Add(0, 0, "--ทั้งหมด--");
            dttmoda.AcceptChanges();

            cmbModality.DisplayMember = "MODALITY_NAME";
            cmbModality.ValueMember = "MODALITY_ID";
            cmbModality.DataSource = dttmoda;
            cmbModality.SelectedIndex = cmbModality.Items.Count - 1;
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
                DataSet ds = lk.SelectSummaryDFRadPremium(dtStart, dtEnd, i, Convert.ToInt32(cmbClinic.SelectedValue), Convert.ToInt32(cmbModality.SelectedValue));
                dlg.Close();

                if (Utilities.IsHaveData(ds))
                {
                    xrptSummaryDF xrpt = new xrptSummaryDF(ds.Tables[0]);
                    xrpt.ShowPreview();
                }
                else
                    new dialogMessage("No Data!").ShowDialog();

                
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
    }
}