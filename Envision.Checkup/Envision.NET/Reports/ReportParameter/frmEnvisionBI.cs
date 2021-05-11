using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraPivotGrid;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraCharts;
using System.IO;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using DevExpress.XtraGrid.Views.BandedGrid;
using Envision.BusinessLogic;
using RIS.Common.Common;
using RIS.Forms.GBLMessage;
using RIS.Common.UtilityClass;
using System.Configuration;

namespace RIS.Reports.ReportParameter
{
    public partial class frmEnvisionBI : Form
    {
        DateTime dateFrom;
        DateTime dateTo;

        private DataTable tbEnvisionOLAP;
        private DataTable tbQuickTemp;

        private string AppStorePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private DevExpress.Utils.WaitDialogForm dlg;

        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl CloseControl;

        //public frmEnvisionBI()
        //{
        //    InitializeComponent();
        //    this.FormClosing += new FormClosingEventHandler(frmEnvisionBI_FormClosing);
        //}
        public frmEnvisionBI(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            CloseControl = formContainer;
            this.FormClosing += new FormClosingEventHandler(frmEnvisionBI_FormClosing);
            CloseControl.ClosePressed += new EventHandler(CloseControl_ClosePressed);
        }
        private void CloseControl_ClosePressed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frnEnvisionOLAP_Load(object sender, EventArgs e)
        {
            CloseWaitDialog();

            pnlReportList.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;

            txtDateFrom.EditValue = DateTime.Now.AddDays(-7);
            txtDateTo.EditValue = DateTime.Now;

            DateTime dtFm = Convert.ToDateTime(txtDateFrom.EditValue);
            DateTime dtTo = Convert.ToDateTime(txtDateTo.EditValue);

            dateFrom = new DateTime(dtFm.Year, dtFm.Month, dtFm.Day, 0, 0, 0);
            dateTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            ReloadEnvisionOLAP();
            ReloadEnvisionChart();
            ReloadQuickTemplate();

            #region Chart Type Setting
            txtRepChartViewType.Items.Clear();
            txtRepChartViewType.Items.Add("Bar");
            txtRepChartViewType.Items.Add("Bar Stacked");
            txtRepChartViewType.Items.Add("Bar Stacked 100%");
            txtRepChartViewType.Items.Add("Bar 3D");
            txtRepChartViewType.Items.Add("Bar 3D Stacked");
            txtRepChartViewType.Items.Add("Bar 3D Stacked 100%");
            txtRepChartViewType.Items.Add("Manhattan Bar");
            txtRepChartViewType.Items.Add("Point");
            txtRepChartViewType.Items.Add("Bubble");
            txtRepChartViewType.Items.Add("Line");
            txtRepChartViewType.Items.Add("Step Line");
            txtRepChartViewType.Items.Add("Spline");
            txtRepChartViewType.Items.Add("Line 3D");
            txtRepChartViewType.Items.Add("Step Line 3D");
            txtRepChartViewType.Items.Add("Spline 3D");
            txtRepChartViewType.Items.Add("Area");
            txtRepChartViewType.Items.Add("Area Stacked");
            txtRepChartViewType.Items.Add("Area Stacked 100%");
            txtRepChartViewType.Items.Add("Spline Area");
            txtRepChartViewType.Items.Add("Spline Area Stacked");
            txtRepChartViewType.Items.Add("Spline Area Stacked 100%");
            txtRepChartViewType.Items.Add("Area 3D");
            txtRepChartViewType.Items.Add("Area 3D Stacked");
            txtRepChartViewType.Items.Add("Area 3D Stacked 100%");
            txtRepChartViewType.Items.Add("Spline Area 3D");
            txtRepChartViewType.Items.Add("Spline Area 3D Stacked");
            txtRepChartViewType.Items.Add("Spline Area 3D Stacked 100%");
            txtRepChartViewType.Items.Add("Pie");
            txtRepChartViewType.Items.Add("Doughnut");
            txtRepChartViewType.Items.Add("Pie 3D");
            txtRepChartViewType.Items.Add("Doughnut 3D");
            txtRepChartViewType.Items.Add("Stock");
            txtRepChartViewType.Items.Add("Candle Stick");
            txtRepChartViewType.Items.Add("Range Bar");
            txtRepChartViewType.Items.Add("Side By Side Range Bar");
            txtRepChartViewType.Items.Add("Gantt");
            txtRepChartViewType.Items.Add("Side By Side Gantt");
            txtRepChartViewType.Items.Add("Radar Point");
            txtRepChartViewType.Items.Add("Radar Line");
            txtRepChartViewType.Items.Add("Radar Area");

            txtChartViewType.EditValue = "Bar";
            #endregion
        }   

        private void LoadEnvisionOLAPData()
        {
            string conStr = ConfigurationSettings.AppSettings["connStr"];
            tbEnvisionOLAP = new DataTable();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter adap = new SqlDataAdapter("Prc_OLAPV_ORDER_Select", con))
                {
                    adap.SelectCommand.CommandTimeout = 60 * 12;
                    adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adap.SelectCommand.Parameters.Add(new SqlParameter("@DateFrom", dateFrom));
                    adap.SelectCommand.Parameters.Add(new SqlParameter("@DateTo", dateTo));

                    try
                    {
                        adap.Fill(tbEnvisionOLAP);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        private void LoadEnvisionOLAPFilter()
        {

        }
        private void LoadEnvisionOLAPGrid()
        {
            gcPivotOLAP.DataSource = tbEnvisionOLAP;
            gcPivotOLAP.Fields.Clear();

            int ArIdx = 0;
            foreach(DataColumn col in tbEnvisionOLAP.Columns)
            {
                PivotGridField pFil = new PivotGridField();
                pFil.Area = PivotArea.FilterArea;
                pFil.AreaIndex = ArIdx;
                pFil.Caption = col.ColumnName;
                pFil.FieldName = col.ColumnName;
                pFil.Name = "field" + col.ColumnName.Replace(" ", "");
                pFil.SummaryType = PivotSummaryType.Count;

                gcPivotOLAP.Fields.Add(pFil);

                ArIdx += 1;
            }

            gcPivotOLAP.Fields["Gross Income"].SummaryType = PivotSummaryType.Sum;
            
            gcPivotOLAP.Fields["ORDER_ID"].Area = PivotArea.DataArea;
            gcPivotOLAP.Fields["ORDER_ID"].Caption = "Studies";

            gcPivotOLAP.ForceInitialize();

        }
        private void ReloadEnvisionOLAP()
        {
            try
            {
                ShowWaitDialog();

                LoadEnvisionOLAPData();
                LoadEnvisionOLAPFilter();
                LoadEnvisionOLAPGrid();

                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
            }
        }

        #region Ribbon Control
        private void gcPivotOLAP_FieldFilterChanged(object sender, PivotFieldEventArgs e)
        {
            if (e.Field.FilterValues.Values.Length == 0)
            {
                e.Field.Appearance.Header.ForeColor = Color.Black;
                e.Field.Appearance.Header.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            }
            else
            {
                e.Field.Appearance.Header.ForeColor = Color.Red;
                e.Field.Appearance.Header.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            }
        }
        private void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                saveFileDialog1.Filter = "Excel files(*.xls)|*.xls";
                //saveFileDialog1.FileName = "EnvisionBI" + DateTime.Now.ToString("yyyyMMdd_HHmmssss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    gcPivotOLAP.ExportToXls(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Exporting");
            }
        }
        private void btnExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                saveFileDialog1.Filter = "PDF files(*.pdf)|*.pdf";
                //saveFileDialog1.FileName = "EnvisionBI" + DateTime.Now.ToString("yyyyMMdd_HHmmssss") + ".xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    gcPivotOLAP.ExportToPdf(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Exporting");
            }
        }
        private void txtRepChartViewType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue == "Bar")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Bar);
            else if (e.NewValue == "Bar Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedBar);
            else if (e.NewValue == "Bar Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedBar);
            else if (e.NewValue == "Bar 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Bar3D);
            else if (e.NewValue == "Bar 3D Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedBar3D);
            else if (e.NewValue == "Bar 3D Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedBar3D);
            else if (e.NewValue == "Manhattan Bar")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.ManhattanBar);
            else if (e.NewValue == "Point")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Point);
            //else if (e.NewValue == "Bubble")
            //    chartOLAP.SeriesTemplate.ChangeView(ViewType.Bubble);
            else if (e.NewValue == "Line")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Line);
            else if (e.NewValue == "Step Line")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StepLine);
            else if (e.NewValue == "Spline")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Spline);
            else if (e.NewValue == "Line 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Line3D);
            else if (e.NewValue == "Step Line 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StepLine3D);
            else if (e.NewValue == "Spline 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Spline3D);
            else if (e.NewValue == "Area")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Area);
            else if (e.NewValue == "Area Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedArea);
            else if (e.NewValue == "Area Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedArea);
            else if (e.NewValue == "Spline Area")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.SplineArea);
            else if (e.NewValue == "Spline Area Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedSplineArea);
            else if (e.NewValue == "Spline Area Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedSplineArea);
            else if (e.NewValue == "Area 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Area3D);
            else if (e.NewValue == "Area 3D Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedArea3D);
            else if (e.NewValue == "Area 3D Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedArea3D);
            else if (e.NewValue == "Spline Area 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.SplineArea3D);
            else if (e.NewValue == "Spline Area 3D Stacked")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.StackedSplineArea3D);
            else if (e.NewValue == "Spline Area 3D Stacked 100%")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.FullStackedSplineArea3D);
            else if (e.NewValue == "Pie")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Pie);
            else if (e.NewValue == "Doughnut")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Doughnut);
            else if (e.NewValue == "Pie 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Pie3D);
            else if (e.NewValue == "Doughnut 3D")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Doughnut3D);
            else if (e.NewValue == "Stock")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Stock);
            else if (e.NewValue == "Candle Stick")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.CandleStick);
            else if (e.NewValue == "Range Bar")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.RangeBar);
            else if (e.NewValue == "Side By Side Range Bar")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.SideBySideRangeBar);
            else if (e.NewValue == "Gantt")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.Gantt);
            else if (e.NewValue == "Side By Side Gantt")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.SideBySideGantt);
            else if (e.NewValue == "Radar Point")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.RadarPoint);
            else if (e.NewValue == "Radar Line")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.RadarLine);
            else if (e.NewValue == "Radar Area")
                chartOLAP.SeriesTemplate.ChangeView(ViewType.RadarArea);
        }
        
        private void btnSearch_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LastFieldOrderRemember();

            DateTime dtFm = Convert.ToDateTime(txtDateFrom.EditValue);
            DateTime dtTo = Convert.ToDateTime(txtDateTo.EditValue);

            dateFrom = new DateTime(dtFm.Year, dtFm.Month, dtFm.Day, 0, 0, 0);
            dateTo = new DateTime(dtTo.Year, dtTo.Month, dtTo.Day, 23, 59, 59);

            ReloadEnvisionOLAP();
            ReloadEnvisionChart();

            LastFieldOrderRetrieve();
        }
        private void btnResetFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowWaitDialog();
            foreach (PivotGridField field in gcPivotOLAP.Fields)
            {
                field.Appearance.Header.ForeColor = Color.Black;
                field.Appearance.Header.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);

                field.FilterValues.Clear();
            }
            CloseWaitDialog();
        }
        private void LastFieldOrderRemember()
        {
            string xmlFile = AppStorePath + @"\EnvisionLastFieldOrder";
            if (File.Exists(xmlFile))
                File.Delete(xmlFile);
            gcPivotOLAP.SaveLayoutToXml(xmlFile);
        }
        private void LastFieldOrderRetrieve()
        {
            string xmlFile = AppStorePath + @"\EnvisionLastFieldOrder";
            if (File.Exists(xmlFile))
                gcPivotOLAP.RestoreLayoutFromXml(xmlFile);

            FilterFontColorChanged();
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkGrandTotal.Checked)
                chkGrandTotal.Caption = "Show Total Field";
            else
                chkGrandTotal.Caption = "Hide Total Field";


            gcPivotOLAP.OptionsView.ShowColumnGrandTotals = chkGrandTotal.Checked;
            gcPivotOLAP.OptionsView.ShowRowGrandTotals = chkGrandTotal.Checked;

            gcPivotOLAP.OptionsView.ShowColumnTotals = chkGrandTotal.Checked;
            gcPivotOLAP.OptionsView.ShowRowTotals = chkGrandTotal.Checked;

            //gcPivotOLAP.OptionsChartDataSource.ShowColumnCustomTotals = chkGrandTotal.Checked;
            //gcPivotOLAP.OptionsChartDataSource.ShowColumnGrandTotals = chkGrandTotal.Checked;
            //gcPivotOLAP.OptionsChartDataSource.ShowColumnTotals = chkGrandTotal.Checked;
            //gcPivotOLAP.OptionsChartDataSource.ShowRowCustomTotals = chkGrandTotal.Checked;
            //gcPivotOLAP.OptionsChartDataSource.ShowRowGrandTotals = chkGrandTotal.Checked;
            //gcPivotOLAP.OptionsChartDataSource.ShowRowTotals = chkGrandTotal.Checked;
        }
        private void FilterFontColorChanged()
        {
            foreach (PivotGridField field in gcPivotOLAP.Fields)
            {
                if (field.FilterValues.Values.Length == 0)
                {
                    field.Appearance.Header.ForeColor = Color.Black;
                    field.Appearance.Header.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                }
                else
                {
                    field.Appearance.Header.ForeColor = Color.Red;
                    field.Appearance.Header.Font = new Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                }
            }
        }
        #endregion

        private void LoadEnvisionChartData()
        {
            chartOLAP.DataSource = gcPivotOLAP;
        }
        private void LoadEnvisionChartFilter()
        {

        }
        private void LoadEnvisionChartGrid()
        {
            chartOLAP.SeriesTemplate.ChangeView(ViewType.Bar);
        }
        private void ReloadEnvisionChart()
        {
            LoadEnvisionChartData();
            LoadEnvisionChartFilter();
            LoadEnvisionChartGrid();
        }

        private void LoadQuickTemplateData()
        {
            ProcessGetGBLBISettings getBI = new ProcessGetGBLBISettings();
            if (rdoReportTypeSelect.SelectedIndex == 0)
                getBI.GBL_BISETTINGS.MODE = "GLOBAL";
            else if (rdoReportTypeSelect.SelectedIndex == 1)
                getBI.GBL_BISETTINGS.MODE = "PERSONAL";
            else if (rdoReportTypeSelect.SelectedIndex == 2)
                getBI.GBL_BISETTINGS.MODE = "ALL";

            getBI.GBL_BISETTINGS.EMP_ID = new GBLEnvVariable().UserID;

            tbQuickTemp = getBI.GetData();

            //string data = tbQuickTemp.Rows[0]["BI_FIELD_ORDER"].ToString();
        }
        private void LoadQuickTemplateFilter()
        {
        }
        private void LoadQuickTemplateGrid()
        {
            gcQuickTemp.DataSource = tbQuickTemp;

            foreach (BandedGridColumn col in gvQuickTemp.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.Visible = false;
            }

            gvQuickTemp.Columns["BI_NAME"].ColVIndex = 1;
            gvQuickTemp.Columns["BI_NAME"].Caption = "Name";

            gvQuickTemp.Columns["BI_DESC"].ColVIndex = 2;
            gvQuickTemp.Columns["BI_DESC"].Caption = "Description";
        }
        private void ReloadQuickTemplate()
        {
            LoadQuickTemplateData();
            LoadQuickTemplateFilter();
            LoadQuickTemplateGrid();
        }

        #region Quick Template Control
        private void gvQuickTemp_DoubleClick(object sender, EventArgs e)
        {
            if (gvQuickTemp.FocusedRowHandle < 0) return;

            ShowWaitDialog();
            DataRow drQuick = gvQuickTemp.GetDataRow(gvQuickTemp.FocusedRowHandle); //.GetFocusedDataRow();

            string xmlFile = AppStorePath + @"\EnvisionQuickTemplate";
            string xnlContent = drQuick["BI_FIELD_ORDER"].ToString();
            if (File.Exists(xmlFile))
                File.Delete(xmlFile);
            File.AppendAllText(xmlFile, xnlContent);
            gcPivotOLAP.RestoreLayoutFromXml(xmlFile);

            FilterFontColorChanged();
            CloseWaitDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEnvisionBIPopupTemplate frmAdd = new frmEnvisionBIPopupTemplate("NEW");
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                string xmlFile = AppStorePath + @"\EnvisionQuickTemplate";
                if (File.Exists(xmlFile))
                    File.Delete(xmlFile);
                gcPivotOLAP.SaveLayoutToXml(xmlFile);          
                string xmlText = File.ReadAllText(xmlFile);

                //@EMP_ID int
                //,@BI_NAME nvarchar(150)
                //,@BI_DESC nvarchar(300)
                //,@BI_TAG nvarchar(300)
                //,@IS_GLOBAL nvarchar(1)
                //,@ORG_ID int
                //,@CREATED_BY int
                ProcessAddGBLBISettings addBI = new ProcessAddGBLBISettings();
                addBI.GBL_BISETTINGS.EMP_ID = new GBLEnvVariable().UserID;
                addBI.GBL_BISETTINGS.BI_NAME = frmAdd.BI_NAME;
                addBI.GBL_BISETTINGS.BI_DESC = frmAdd.BI_DESC;
                addBI.GBL_BISETTINGS.BI_TAG = frmAdd.BI_TAG;
                addBI.GBL_BISETTINGS.IS_GLOBAL = frmAdd.IS_GLOBAL;
                addBI.GBL_BISETTINGS.BI_FIELD_ORDER = xmlText;
                addBI.Invoke();

                ReloadQuickTemplate();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gvQuickTemp.FocusedRowHandle < 0) return;

            DataRow drQuTm = gvQuickTemp.GetDataRow(gvQuickTemp.FocusedRowHandle);
            
            frmEnvisionBIPopupTemplate frmAdd = new frmEnvisionBIPopupTemplate("EDIT");
            frmAdd.BI_NAME = drQuTm["BI_NAME"].ToString();
            frmAdd.BI_DESC = drQuTm["BI_DESC"].ToString();
            frmAdd.BI_TAG = drQuTm["BI_TAG"].ToString();
            frmAdd.IS_GLOBAL = Convert.ToChar(drQuTm["IS_GLOBAL"]);
            
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {

                ProcessUpdateGBLBISettings upBI = new ProcessUpdateGBLBISettings();
                upBI.GBL_BISETTINGS.BISETTINGS_ID = Convert.ToInt32(drQuTm["BISETTINGS_ID"]);
                upBI.GBL_BISETTINGS.EMP_ID = new GBLEnvVariable().UserID;
                upBI.GBL_BISETTINGS.BI_NAME = frmAdd.BI_NAME;
                upBI.GBL_BISETTINGS.BI_DESC = frmAdd.BI_DESC;
                upBI.GBL_BISETTINGS.BI_TAG = frmAdd.BI_TAG;
                upBI.GBL_BISETTINGS.IS_GLOBAL = frmAdd.IS_GLOBAL;
                upBI.Invoke();

                ReloadQuickTemplate();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvQuickTemp.FocusedRowHandle < 0) return;

            MyMessageBox msg = new MyMessageBox();
            string strMsg = msg.ShowAlert("UID1025", new GBLEnvVariable().CurrentLanguageID);
            if (strMsg == "2")
            {
                DataRow drQuick = gvQuickTemp.GetDataRow(gvQuickTemp.FocusedRowHandle);
                int BISETTINGS_ID = Convert.ToInt32(drQuick["BISETTINGS_ID"]);

                ProcessDeleteGBLBISettings delBI = new ProcessDeleteGBLBISettings();
                delBI.GBL_BISETTINGS.BISETTINGS_ID = BISETTINGS_ID;
                delBI.Invoke();

                ReloadQuickTemplate();
            }
        }
        private void rdoReportTypeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadQuickTemplate();
        }
        #endregion  
   
        private void ShowWaitDialog()
        {
            Size s = new Size(250, 50);
            dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Envision BI", s);
        }
        private void CloseWaitDialog()
        {
            if (dlg != null) dlg.Close();
        }
        private void frmEnvisionBI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dlg != null) dlg.Dispose();
        }
    }
}
