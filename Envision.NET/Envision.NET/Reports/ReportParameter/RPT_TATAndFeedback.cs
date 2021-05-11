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
using Envision.Plugin.XtrFile.xtrReports;
using Envision.Plugin.XtraFile.xtraReports;
using Miracle.Util;
using Envision.Plugin.DirectPrint;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_TATAndFeedback : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_TATAndFeedback()
        {
            InitializeComponent();
        }

        private void RPT_TATAndFeedback_Load(object sender, EventArgs e)
        {
            LookUpSelect lv = new LookUpSelect();
            DataSet ds = lv.SelectTATCombobox();

            cmbReportID.DataSource = ds.Tables[0];
            cmbReportID.DisplayMember = "GEN_TEXT";//ds.Tables[1].Columns[1].ToString();//Columns[1].ToString();
            cmbReportID.ValueMember = "GEN_DTL_ID";//ds.Tables[0].Columns[1].ToString();

            base.CloseWaitDialog();
        }
        private void btnRunReport_Click(object sender, EventArgs e)
        {
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


            DataSet ds = new DataSet();
            LookUpSelect lvReport = new LookUpSelect();
            DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
            DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);


            ds = lvReport.SelectTATReport(dtStart, dtEnd, Convert.ToInt32(cmbReportID.SelectedValue));
            dlg.Close();

            if (Utilities.IsHaveData(ds))
            {
                xrptSummaryDF rpt = new xrptSummaryDF(ds.Tables[0]);
                rpt.Name = cmbReportID.Text;
                rpt.ShowPreviewDialog();
            }
            else
                new dialogMessage("No Data!").ShowDialog();
        }
        private void CreateExcel_Click()
        {
           
        }
        private void exportToExcel(DataSet dataSet)
        {
            saveFileDialog1.DefaultExt = "*.xls";
            saveFileDialog1.Filter = "Excel Files|*.xls";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try
                {
                    Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                    // Loop over DataTables in DataSet.
                    DataTableCollection collection = dataSet.Tables;

                    for (int i = collection.Count; i > 0; i--)
                    {
                        Microsoft.Office.Interop.Excel.Sheets xlSheets = null;
                        Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = null;
                        //Create Excel Sheets
                        xlSheets = ExcelApp.Sheets;
                        xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlSheets.Add(xlSheets[1],
                                       Type.Missing, Type.Missing, Type.Missing);

                        System.Data.DataTable table = collection[i - 1];
                        xlWorksheet.Name = table.TableName;

                        
                        for (int j = 1; j < table.Columns.Count + 1; j++)
                        {
                            ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;
                        }

                        // Storing Each row and column value to excel sheet
                        for (int k = 0; k < table.Rows.Count; k++)
                        {
                            for (int l = 0; l < table.Columns.Count; l++)
                            {
                                ExcelApp.Cells[k + 2, l + 1] = table.Rows[k].ItemArray[l].ToString();
                            }
                        }
                        ExcelApp.Columns.AutoFit();
                    }
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkbook.SaveAs(saveFileDialog1.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    //((Microsoft.Office.Interop.Excel.Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
                    //ExcelApp.Visible = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}