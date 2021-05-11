using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Operational.ReportManager;

namespace RIS.Reports.ReportParameter
{
    public partial class RPT_ST06 : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;
        public RPT_ST06(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        {
            System.Windows.Forms.Form rDisplay;
            UUL.ControlFrame.Controls.TabPage page;
            rDisplayForm.Text = formName;
            rDisplay = rDisplayForm;       //--Set text
            setFormProperty(rDisplayForm);
            //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
            page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
            page.Selected = true;
            rTabControl.TabPages.Add(page);
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

        public void setFormProperty(Form displayForm)
        {
            try
            {
                //displayForm.Font = new System.Drawing.Font("verdana", 10);
                System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0x98, /* G */ 0xB8, /* B */ 0xE2);
                //displayForm.BackColor = System.Drawing.Color.Red;
                displayForm.BackColor = c;
                displayForm.MaximizeBox = false;
                displayForm.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                ReportMangager reportprovider = new ReportMangager();
                String FromDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00";
                String ToDate = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 00:00:00";

                reportprovider.formulaFromDate = FromDate;
                reportprovider.formulaToDate = ToDate;

                String FromLongDate = dateTimePicker1.Value.Day.ToString() + " " + (LongMonth)dateTimePicker1.Value.Month + " " + dateTimePicker1.Value.Year.ToString();
                String ToLongDate = dateTimePicker2.Value.Day.ToString() + " " + (LongMonth)dateTimePicker2.Value.Month + " " + dateTimePicker2.Value.Year.ToString();
                reportprovider.fromDate = FromLongDate;
                reportprovider.toDate = ToLongDate;

                //reportprovider.WhereClose = " Where RIS_ORDER.ORDER_DT between cast('" + FromDate + "' as datetime) and cast('" + ToDate + "' as datetime)";

                RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptCancelation, formContainer1);

                

                dbu.CloseFrom(formContainer1, this);
                DisplayForm(formContainer1, RForm, "Cancellation");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dbu.CloseFrom(formContainer1, this);
        }
    }
}