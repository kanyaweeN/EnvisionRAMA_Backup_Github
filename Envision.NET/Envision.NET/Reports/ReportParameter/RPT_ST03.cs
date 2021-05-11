using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;

using Envision.Common;
using Envision.Common.Linq;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;
namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ST03 : Envision.NET.Forms.Main.MasterForm  // Form
    {
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

        public RPT_ST03()
        {
            InitializeComponent();
            
            loadRoomDataTocombo();
            loadExamTypeTocombo();
        }

        private void loadRoomDataTocombo() { 
            EnvisionDataContext db=new EnvisionDataContext();
            List<HR_ROOM> roomList = db.HR_ROOMs.ToList();
            DataTable dtt = new DataTable();
            dtt.Columns.Add("ID");
            dtt.Columns.Add("TEXT");
            dtt.AcceptChanges();
            foreach (HR_ROOM room in roomList)
            {
                DataRow row = dtt.NewRow();
                row[0] = room.ROOM_ID;
                row[1] = room.ROOM_UID;
                dtt.Rows.Add(row);
            }
            DataRow dr = dtt.NewRow();
            dr[0] = "0";
            dr[1] = "--- Please Select ---";
            dtt.Rows.InsertAt(dr, 0);
            dtt.AcceptChanges();
            comboBox1.Items.Clear();
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = dtt.Columns[1].ToString();
            comboBox1.ValueMember = dtt.Columns[0].ToString();
        }
        private void loadExamTypeTocombo()
        {
            EnvisionDataContext db = new EnvisionDataContext();
            List<RIS_EXAMTYPE> examList = db.RIS_EXAMTYPEs.ToList();
            DataTable dtt = new DataTable();
            dtt.Columns.Add("ID");
            dtt.Columns.Add("TEXT");
            dtt.AcceptChanges();
            foreach (RIS_EXAMTYPE exam in examList)
            {
                DataRow row = dtt.NewRow();
                row[0] = exam.EXAM_TYPE_ID;
                row[1] = exam.EXAM_TYPE_TEXT;
                dtt.Rows.Add(row);
            }
            DataRow dr = dtt.NewRow();
            dr[0] = "0";
            dr[1] = "--- Please Select ---";
            dtt.Rows.InsertAt(dr, 0);
            dtt.AcceptChanges();
            comboBox2.Items.Clear();
            comboBox2.DataSource = dtt;
            comboBox2.DisplayMember = dtt.Columns[1].ToString();
            comboBox2.ValueMember = dtt.Columns[0].ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

                ReportMangager reportprovider = new ReportMangager();

                String FromDate = dateTimePicker1.Value.Year + "-" + dateTimePicker1.Value.Month + "-" + dateTimePicker1.Value.Day + " 00:00:00";
                String ToDate = dateTimePicker2.Value.Year + "-" + dateTimePicker2.Value.Month + "-" + dateTimePicker2.Value.Day + " 00:00:00";

                //reportprovider.WhereClose = " Where RIS_ORDER.ORDER_DT between cast('" + FromDate + "' as datetime) and cast('" + ToDate + "' as datetime)";
                //Date(2008,05,02)
                reportprovider.formulaFromDate = FromDate;
                reportprovider.formulaToDate = ToDate;

                reportprovider.examType = comboBox2.SelectedValue.ToString();
                if (reportprovider.examType == "0")
                    reportprovider.examType = "";
                reportprovider.Room = comboBox1.SelectedValue.ToString();
                if (reportprovider.Room == "0")
                    reportprovider.Room = "";

                String FromLongDate = dateTimePicker1.Value.Day.ToString() + " " + (LongMonth)dateTimePicker1.Value.Month + " " + dateTimePicker1.Value.Year.ToString();
                String ToLongDate = dateTimePicker2.Value.Day.ToString() + " " + (LongMonth)dateTimePicker2.Value.Month + " " + dateTimePicker2.Value.Year.ToString();
                reportprovider.fromDate = FromLongDate;
                reportprovider.toDate = ToLongDate;

                //reportprovider.WhereClose = " WHERE accession_no ='" + txtJobTitle.Text.ToString().Trim() + "'";
                frmReportViewer RForm = new frmReportViewer(reportprovider.rptService);
                dlg.Close();
                RForm.ShowDialog();
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

        private void RPT_ST03_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}