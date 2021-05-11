using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using RIS.Common.UtilityClass;
//using RIS.Operational.ReportManager;

using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ST06 : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_ST06()
        {
            InitializeComponent();
            base.CloseWaitDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       

        private enum LongMonth
        {
            January = 1,
            Febuary,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

                ReportMangager reportprovider = new ReportMangager();
                String FromDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00";
                String ToDate = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 00:00:00";

                reportprovider.formulaFromDate = FromDate;
                reportprovider.formulaToDate = ToDate;

                String FromLongDate = dateTimePicker1.Value.Day.ToString() + " " + (LongMonth)dateTimePicker1.Value.Month + " " + dateTimePicker1.Value.Year.ToString();
                String ToLongDate = dateTimePicker2.Value.Day.ToString() + " " + (LongMonth)dateTimePicker2.Value.Month + " " + dateTimePicker2.Value.Year.ToString();
                reportprovider.fromDate = FromLongDate;
                reportprovider.toDate = ToLongDate;
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptCancelation = reportprovider.rptCancelation;

                frmReportViewer RForm = new frmReportViewer(rptCancelation);
                dlg.Close();
                RForm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_ST06_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}