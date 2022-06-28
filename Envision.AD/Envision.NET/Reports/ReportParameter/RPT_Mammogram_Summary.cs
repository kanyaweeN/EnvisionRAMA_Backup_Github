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
    public partial class RPT_Mammogram_Summary : Envision.NET.Forms.Main.MasterForm
    {
        DataTable tbMammo;

        public RPT_Mammogram_Summary()
        {
            InitializeComponent();

            dateFrom.EditValue = DateTime.Now;
            dateTo.EditValue = DateTime.Now;
        }
        private void RPT_Mammogram_Summary_Load(object sender, EventArgs e)
        {
            ReloadMammoReport();
            base.CloseWaitDialog();
        }

        private void LoadMammoReportData()
        {
            DateTime dtf = Convert.ToDateTime(dateFrom.EditValue);
            DateTime dtt = Convert.ToDateTime(dateTo.EditValue);

            DateTime dtNf = new DateTime(dtf.Year, dtf.Month, dtf.Day, 0, 0, 0);
            DateTime dtNt = new DateTime(dtt.Year, dtt.Month, dtt.Day, 23, 59, 59);

            LookUpSelect lku = new LookUpSelect();
            tbMammo = lku.SelectMammogramSummary(dtNf, dtNt).Tables[0];
        }
        private void LoadMammoReportFilter()
        {

        }
        private void LoadMammoReportGrid()
        {
            gcMammoReport.DataSource = tbMammo;
        }
        private void ReloadMammoReport()
        {
            LoadMammoReportData();
            LoadMammoReportFilter();
            LoadMammoReportGrid();
        }

        private void RPT_Mammogram_Summary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                ReloadMammoReport();
            }
        }
        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadMammoReport();
        }
        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Exel File|*.xls";
            save.Title = "Save an Exel File";

            if (save.ShowDialog() == DialogResult.OK)
            {
                gvMammoReport.ExportToXls(save.FileName);
            }
        }
        private void btnExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF File|*.pdf";
            save.Title = "Save an PDF File";

            if (save.ShowDialog() == DialogResult.OK)
            {
                gvMammoReport.ExportToPdf(save.FileName);
            }
        }

        
    }
}
