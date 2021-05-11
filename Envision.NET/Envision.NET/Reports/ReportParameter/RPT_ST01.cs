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
    public partial class RPT_ST01 : Envision.NET.Forms.Main.MasterForm  // Form
    {
        private enum LongMonth
        {
            January=1,
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
        public RPT_ST01()
        {
            InitializeComponent();
            SetCombooBox();
            base.CloseWaitDialog();
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportMangager reportprovider = new ReportMangager();

                ////2007-05-02 00:00:00
                //DateTime FromDate2 = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
                //DateTime ToDate2 = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day, 23, 59, 59);

                //String FromDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00";
                //String ToDate = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 23:59:59";
                //DateTime date = dateTimePicker1.Value;
                //DateTime date2 = dateTimePicker2.Value;
                //string s = date.Year.ToString();
                //s += "/";
                //s += date.Day.ToString().Length == 2 ? date.Day.ToString() : "0" + date.Day.ToString();
                //s += "/";
                //s += date.Month.ToString().Length == 2 ? date.Month.ToString() : "0" + date.Month.ToString();
                //s += " ";
                //s += date.Hour.ToString().Length == 2 ? date.Hour.ToString() : "0" + date.Hour.ToString();
                //s += ":";
                //s += date.Minute.ToString().Length == 2 ? date.Minute.ToString() : "0" + date.Minute.ToString();
                //s += ":";
                //s += date.Second.ToString().Length == 2 ? date.Second.ToString() : "0" + date.Second.ToString();

                //string d = date2.Year.ToString();
                //d += "/";
                //d += date2.Day.ToString().Length == 2 ? date2.Day.ToString() : "0" + date2.Day.ToString();
                //d += "/";
                //d += date2.Month.ToString().Length == 2 ? date2.Month.ToString() : "0" + date2.Month.ToString();
                //d += " ";
                //d += date2.Hour.ToString().Length == 2 ? date2.Hour.ToString() : "0" + date2.Hour.ToString();
                //d += ":";
                //d += date2.Minute.ToString().Length == 2 ? date2.Minute.ToString() : "0" + date2.Minute.ToString();
                //d += ":";
                //d += date2.Second.ToString().Length == 2 ? date2.Second.ToString() : "0" + date2.Second.ToString();
                ////reportprovider.WhereClose = " Where RIS_ORDER.ORDER_DT between cast('" + FromDate + "' as datetime) and cast('" + ToDate + "' as datetime)";
                ////Date(2008,05,02)
                //reportprovider.formulaFromDate = s;// FromDate2.ToString();
                //reportprovider.formulaToDate = d;//ToDate2.ToString();

                ////if (txtJobTitle.Text != "")
                ////reportprovider.JobDesc = cmbJobTitle.SelectedValue.ToString();
                //if (cmbJobTitle.Text == "--- Please Select ---")
                //    reportprovider.JobDesc = "";
                //else
                //{
                //    switch (cmbJobTitle.Text){
                //        case "Doctor":
                //            reportprovider.JobDesc = "D";
                //            break;
                //        case "Technologist":
                //            reportprovider.JobDesc = "T";
                //            break;
                //        case "Operator":
                //            reportprovider.JobDesc = "0";
                //            break;
                //        default:
                //            reportprovider.JobDesc = "";
                //            break;
                //    }
                //}
                //    //reportprovider.JobDesc = txtJobTitle.Text;
                //    //reportprovider.WhereClose += " AND HR_JOBTITLE.JOB_TITLE_DESC like '%" + txtJobTitle.Text.ToString().Trim() + "%'";

                //String FromLongDate = dateTimePicker1.Value.Day.ToString() + " " + (LongMonth)dateTimePicker1.Value.Month + " " + dateTimePicker1.Value.Year.ToString();
                //String ToLongDate = dateTimePicker2.Value.Day.ToString() + " " + (LongMonth)dateTimePicker2.Value.Month + " " + dateTimePicker2.Value.Year.ToString();
                //reportprovider.fromDate = FromLongDate;
                //reportprovider.toDate = ToLongDate;
                
                //RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptWorkLoad, formContainer1);
                //dbu.CloseFrom(formContainer1, this);
                //DisplayForm(formContainer1, RForm, "Workload");




                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                string JobType = "";
                switch (cmbJobTitle.SelectedIndex)
                {
                    case 0: JobType = "A"; break;
                    case 1: JobType = "D"; break;
                    case 2: JobType = "T"; break;
                    case 3: JobType = "O"; break;
                }
                int us = env.UserID;
                DateTime FromDate = new DateTime(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month,dateTimePicker1.Value.Day,0,0,0);
                DateTime ToDate = new DateTime(dateTimePicker2.Value.Year,dateTimePicker2.Value.Month,dateTimePicker2.Value.Day,11,59,59);
                //string FromDateS = DATESTRING(FromDate);
                //string ToDateS = DATESTRING(ToDate);
                //DateTime FD = Convert.ToDateTime(FromDateS);
                //DateTime TD = Convert.ToDateTime(ToDateS);

                frmReportViewer RForm = new frmReportViewer(reportprovider.rptWorkload(Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), env.UserID, JobType));
                dlg.Close();
                RForm.ShowDialog();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        private string DATESTRING(DateTime date)
        {
            string s = date.Year.ToString();
            s += "/";
            s += date.Month.ToString().Length == 2 ? date.Month.ToString() : "0" + date.Month.ToString();
            s += "/";
            s += date.Day.ToString().Length == 2 ? date.Day.ToString() : "0" + date.Day.ToString();
            s += " ";
            s += date.Hour.ToString().Length == 2 ? date.Hour.ToString() : "0" + date.Hour.ToString();
            s += ":";
            s += date.Minute.ToString().Length == 2 ? date.Minute.ToString() : "0" + date.Minute.ToString();
            s += ":";
            s += date.Second.ToString().Length == 2 ? date.Second.ToString() : "0" + date.Second.ToString();
            return s;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetCombooBox()
        {
            cmbJobTitle.Items.Add("---Select All---");
            cmbJobTitle.Items.Add("Doctor");
            cmbJobTitle.Items.Add("Technologist");
            cmbJobTitle.Items.Add("Operator");
            cmbJobTitle.SelectedIndex = 0;
        }

        private void RPT_ST01_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
     
    }
}