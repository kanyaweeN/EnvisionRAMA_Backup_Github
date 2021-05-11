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
    public partial class frmSummaryDFRadByModalityUnit : Envision.NET.Forms.Main.MasterForm  //Form
    {
        public frmSummaryDFRadByModalityUnit()
        {
            InitializeComponent();
        }
        private void frmSummaryDFRadByModalityUnit_Load(object sender, EventArgs e)
        {
            getHeaderReport();
            base.CloseWaitDialog();
        }
     
        private void getHeaderReport()
        {
            //Load Radiologist List
            DataTable dtt = new DataTable();
            Order dr = new Order();
            dtt = RISBaseData.Ris_Radiologist().Copy();
            dtt.NewRow();
            dtt.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--", 3, "--ทั้งหมด--", "--ทั้งหมด--", "--ทั้งหมด--");
            dtt.AcceptChanges();

            txtRadiologist.DisplayMember = "UIDAndRadioName";
            txtRadiologist.ValueMember = "EMP_ID";
            txtRadiologist.DataSource = dtt;
            
            //Load Unit List

            ProcessGetHRUnit prcGet = new ProcessGetHRUnit();
            prcGet.GetData_WithUnitType();
            DataTable dtUnit = new DataTable();
            dtUnit = prcGet.Result.Tables[0];

            txtUnitName.DisplayMember = "UNIT_FULLNAME";
            txtUnitName.ValueMember = "UNIT_ID";
            txtUnitName.DataSource = dtUnit;

        }
        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                
                int empID = 1;
                try { empID = Convert.ToInt32(txtRadiologist.SelectedValue.ToString()); }
                catch { }

                int unitID = 1;
                try { unitID = Convert.ToInt32(txtUnitName.SelectedValue.ToString()); }
                catch { }

                DateTime dtStart = new DateTime(txtDateFrom.Value.Year, txtDateFrom.Value.Month, txtDateFrom.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(txtDateTo.Value.Year, txtDateTo.Value.Month, txtDateTo.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectSummaryDFRadWithModalityUnitID(dtStart, dtEnd, empID, unitID);

                xrptSummaryDFRadWithModalityUnitID xrpt = new xrptSummaryDFRadWithModalityUnitID(ds.Tables[0]);
                dlg.Close();
                xrpt.ShowPreview();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}