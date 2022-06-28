using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ST02 : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_ST02()
        {
            Size s = new Size(250, 50);
            InitializeComponent();
            SetCombooBox();
            base.CloseWaitDialog();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ReportMangager reportprovider = new ReportMangager();

            //    //String FromDate = dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
            //    //String ToDate = dateTimePicker2.Value.Month.ToString() + "/" + dateTimePicker2.Value.Day.ToString() + "/" + dateTimePicker2.Value.Year.ToString();
            //    //reportprovider.WhereClose = " Where RIS_ORDER.ORDER_DT between cast('" + FromDate + "' as datetime) and cast('" + ToDate + "' as datetime)";

            //    String FromDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00";
            //    String ToDate = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 00:00:00";
                
            //    //reportprovider.WhereClose = " Where RIS_ORDER.ORDER_DT between cast('" + FromDate + "' as datetime) and cast('" + ToDate + "' as datetime)";
            //    //Date(2008,05,02)
            //    reportprovider.formulaFromDate = FromDate;
            //    reportprovider.formulaToDate = ToDate;
            //    reportprovider.formulaGroup = "\""+comboBox1.Text+"\"";

            //    String strWorkHour = comboBox2.Text;
            //    if (strWorkHour.Contains("Office"))
            //        reportprovider.formulaClinic = "N";
            //    else if (strWorkHour.Contains("Special"))
            //        reportprovider.formulaClinic = "Y";
            //    else
            //        reportprovider.formulaClinic = "";
                
            //    //Group by Day, Month or Year.
            //    String strGroup = comboBox1.Text;

            //    String FromLongDate = dateTimePicker1.Value.Day.ToString() + " " + (LongMonth)dateTimePicker1.Value.Month + " " + dateTimePicker1.Value.Year.ToString();
            //    String ToLongDate = dateTimePicker2.Value.Day.ToString() + " " + (LongMonth)dateTimePicker2.Value.Month + " " + dateTimePicker2.Value.Year.ToString();
            //    reportprovider.fromDate = FromLongDate;
            //    reportprovider.toDate = ToLongDate;
            //    reportprovider.groupBy = "Group By " + comboBox1.Text;

            //    RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptOrder, formContainer1);
            //    dbu.CloseFrom(formContainer1, this);
            //    DisplayForm(formContainer1, RForm, "Order");

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            Size s = new Size(250, 50);
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

            ReportMangager reportprovider = new ReportMangager();

            DateTime FromDate = new DateTime(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month,dateTimePicker1.Value.Day,0,0,0);
            DateTime ToDate = new DateTime(dateTimePicker2.Value.Year,dateTimePicker2.Value.Month,dateTimePicker2.Value.Day,23,59,59);
            int Unit = 0;
            int Modality = 0;
            bool aimc = false;
            Unit =  (int)cmbUnit.SelectedValue;
            Modality = (int)cmbModality.SelectedValue;

            if (Unit == 2)
            {
                aimc = true;
            }


            GBLEnvVariable env = new GBLEnvVariable();
            //DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
            //DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

            frmReportViewer RForm = new frmReportViewer(reportprovider.rptOrderReportAll(FromDate, ToDate, Unit, Modality, aimc));
            dlg.Close();
            RForm.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetCombooBox()
        {
            ProcessGetHRUnit geUnit = new ProcessGetHRUnit();
            geUnit.Invoke();
            DataTable dtUnit = geUnit.Result.Tables[0];
            dtUnit.Rows.Add(0,"--Select All--",0,"--Select All--");
            dtUnit.AcceptChanges();

            cmbUnit.ValueMember = "UNIT_ID";
            cmbUnit.DisplayMember = "UNIT_NAME";
            cmbUnit.DataSource = dtUnit;
            cmbUnit.SelectedValue = 0;

            ProcessGetRISModality geMo = new ProcessGetRISModality(true);
            geMo.Invoke();
            DataTable dtMo = geMo.Result.Tables[0];
            dtMo.Rows.Add(0, "--Select All--", "--Select All--");
            dtMo.AcceptChanges();


            cmbModality.ValueMember = "MODALITY_ID";
            cmbModality.DisplayMember = "MODALITY_NAME";
            cmbModality.DataSource = dtMo;
            cmbModality.SelectedValue = 0;



            
        }
       
      
        private void cmbUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            //DataTable dttMo = new DataTable();
            //ProcessGetRISModality geMo = new ProcessGetRISModality(true);
            //geMo.Invoke();
            //DataTable dtMo = geMo.Result.Tables[0];
            //dtMo.Rows.Add(0, "--Select All--", "--Select All--");
            //dttMo = dtMo.Clone();
            //try
            //{
            //    DataRow[] drMo = dtMo.Select("UNIT_ID=" + cmbUnit.SelectedValue.ToString());
            //    for (int i = 0; i < drMo.Length; i++)
            //    {
            //        dttMo.Rows.Add(drMo[i].ItemArray);
            //    }
            //    dttMo.Rows.Add(0, "--Select All--", "--Select All--");
            //    dttMo.AcceptChanges();

            //}
            //catch (Exception)
            //{
            //    cmbModality.SelectedValue = 0;
            //}


            //cmbModality.ValueMember = "MODALITY_ID";
            //cmbModality.DisplayMember = "MODALITY_NAME";
            //cmbModality.DataSource = dttMo;
            //cmbModality.SelectedValue = 0;
        }

        private void RPT_ST02_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}