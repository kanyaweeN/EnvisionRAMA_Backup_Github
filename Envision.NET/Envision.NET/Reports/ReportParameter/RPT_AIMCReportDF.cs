using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic;
using Envision.Plugin.XtraFile.xtraReports;
using Envision.NET.Forms.Main;
using Miracle.Util;
using Envision.Plugin.DirectPrint;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_AIMCReportDF : MasterForm
    {
        private DataSet ds;
        private DataTable dtRad, dtMod;
        public RPT_AIMCReportDF()
        {
            InitializeComponent();
        }
        private void RPT_AIMCReportDF_Load(object sender, EventArgs e)
        {
            ds = new DataSet();
            dtRad = RISBaseData.Ris_Radiologist().Copy();
            dtMod = RISBaseData.Ris_Modality().Copy();

            cmbRadiologist.DeselectAll();
            cmbRadiologist.EditValue = "";
            cmbRadiologist.RefreshEditValue();


            base.CloseWaitDialog();
        }
        private void getDataAndSetControl()
        {
            cmbRadiologist.Enabled = false;
            cmbRadiologist.DeselectAll();
            cmbRadiologist.EditValue = "";
            cmbRadiologist.RefreshEditValue();
            lblRadiologist.ForeColor = Color.Black;
            lblModality.ForeColor = Color.Black;
            DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

            LookUpSelect lk = new LookUpSelect();
            ds = lk.SelectSummaryDFRadAIMC(rdoSelectRadiologist.SelectedIndex,dtStart, dtEnd);
            if (Utilities.IsHaveData(ds))
            {

                DataView dvDistinctRadiologist = new DataView(ds.Tables[0].Copy());
                DataTable dtDistinctRadiologist = dvDistinctRadiologist.ToTable(true, "FINALIZED_BY");
                string _filterRadiologist = "";
                for (int i = 0; i < dtDistinctRadiologist.Rows.Count; i++)
                {
                    if (i == 0)
                        _filterRadiologist = dtDistinctRadiologist.Rows[i]["FINALIZED_BY"].ToString();
                    else
                        _filterRadiologist += "," + dtDistinctRadiologist.Rows[i]["FINALIZED_BY"].ToString();
                }

                DataView dvRadiologist = new DataView(dtRad);
                dvRadiologist.RowFilter = "EMP_ID in (" + _filterRadiologist + ")";

                cmbRadiologist.Properties.DataSource =  dvRadiologist.ToTable();
                cmbRadiologist.Properties.DisplayMember = "UIDAndRadioName";
                cmbRadiologist.Properties.ValueMember = "EMP_ID";

                cmbRadiologist.Enabled = true;

                DataView dvDistinctModality = new DataView(ds.Tables[0].Copy());
                DataTable dtDistinctModality = dvDistinctRadiologist.ToTable(true, "MODALITY_ID");
                string _filterModality = "";
                for (int i = 0; i < dtDistinctModality.Rows.Count; i++)
                {
                    if (i == 0)
                        _filterModality = dtDistinctModality.Rows[i]["MODALITY_ID"].ToString();
                    else
                        _filterModality += "," + dtDistinctModality.Rows[i]["MODALITY_ID"].ToString();
                }

                DataView dvModality = new DataView(dtMod);
                dvModality.RowFilter = "MODALITY_ID in (" + _filterModality + ")";

                chkcmbModality.Properties.DataSource = dvModality.ToTable();
                chkcmbModality.Properties.DisplayMember = "MODALITY_NAME";
                chkcmbModality.Properties.ValueMember = "MODALITY_ID";

                xtraTabControl1.SelectedTabPageIndex = 1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                if (string.IsNullOrEmpty(cmbRadiologist.EditValue.ToString()))
                {
                    lblRadiologist.ForeColor = Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(chkcmbModality.EditValue.ToString()))
                {
                    lblModality.ForeColor = Color.Red;
                    return;
                }
                if (Utilities.IsHaveData(ds))
                {
                    DataView dvRadiologist = new DataView(ds.Tables[0]);
                    string _filter = "FINALIZED_BY in (" + cmbRadiologist.EditValue.ToString() + ")";
                    _filter += "AND MODALITY_ID in (" + chkcmbModality.EditValue.ToString() + ")";
                    dvRadiologist.RowFilter = _filter;
                    if (dvRadiologist.Count > 0)
                    {
                        xrptSummaryReportDFAIMC xrpt = new xrptSummaryReportDFAIMC(dtStart, dtEnd);
                        xrpt.DataSource = dvRadiologist.ToTable();
                        xrpt.ShowPreviewMarginLines = false;
                        xrpt.ShowPrintingWarnings = false;
                        xrpt.ShowPreviewDialog();
                        //xrpt.PrintDialog();
                    }
                    else
                        new dialogMessage("No Data with this data.").ShowDialog();
                }
                else
                    new dialogMessage("No Data!").ShowDialog();
               
            }
            catch (Exception ex)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

            getDataAndSetControl();
            dlg.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;
        }
    }
}
