using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using DevExpress.XtraGrid.Views.BandedGrid;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.Dialog
{
    public partial class frmNextAppointment : MasterForm
    {
        string HN = "";
        DataTable dtNextAppt;
        public DataRow returnNextAppointRow { get; set; }
        public frmNextAppointment(string HN)
        {
            InitializeComponent();
            this.HN = HN;
            this.Size = new Size(800, 600);
            this.Text = "Next Appointment.";

            dtNextAppt = new DataTable();
            dtNextAppt.Columns.Add(new DataColumn("hn"));
            dtNextAppt.Columns.Add(new DataColumn("appt_date"));
            dtNextAppt.Columns.Add(new DataColumn("appt_time"));
            dtNextAppt.Columns.Add(new DataColumn("appt_doc_code"));
            dtNextAppt.Columns.Add(new DataColumn("appt_doc_name"));
            dtNextAppt.Columns.Add(new DataColumn("appt_doc_dept_code"));
            dtNextAppt.Columns.Add(new DataColumn("appt_doc_dept_name"));
            dtNextAppt.Columns.Add(new DataColumn("appt_doc_dept_tel"));
        }

        private void frmNextAppointment_Load(object sender, EventArgs e)
        {
            ReloadNextAppointment();

            base.CloseWaitDialog();
        }

        private void LoadNextAppointmentData()
        {
            //Envision.WebService.HISWebService.Service sv
            //    = new Envision.WebService.HISWebService.Service();
            //DataTable tb = sv.Get_appointment_detail(HN).Tables[0];
            //dtNextAppt = tb;
            try
            {
                HIS_Patient nextAppt = new HIS_Patient();
                DataTable tb = nextAppt.Get_appointment_detail(HN).Tables[0];
                dtNextAppt = tb;
            }
            catch { }
        }
        private void LoadNextAppointmentFilter()
        {

        }
        private void LoadNextAppointmentGrid()
        {
            gcNextAppt.DataSource = dtNextAppt;

            foreach (BandedGridColumn col in gvNextAppt.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }

            gvNextAppt.Columns["hn"].ColVIndex = 1;
            gvNextAppt.Columns["hn"].Caption = "HN";

            gvNextAppt.Columns["appt_date"].ColVIndex = 2;
            gvNextAppt.Columns["appt_date"].Caption = "Appoint Date";

            gvNextAppt.Columns["appt_time"].ColVIndex = 3;
            gvNextAppt.Columns["appt_time"].Caption = "Appoint Time";

            gvNextAppt.Columns["appt_doc_code"].ColVIndex = 4;
            gvNextAppt.Columns["appt_doc_code"].Caption = "Physician Code";

            gvNextAppt.Columns["appt_doc_name"].ColVIndex = 5;
            gvNextAppt.Columns["appt_doc_name"].Caption = "Physician Name";

            gvNextAppt.Columns["appt_doc_dept_code"].ColVIndex = 6;
            gvNextAppt.Columns["appt_doc_dept_code"].Caption = "Department Code";

            gvNextAppt.Columns["appt_doc_dept_name"].ColVIndex = 7;
            gvNextAppt.Columns["appt_doc_dept_name"].Caption = "Department Name";

            gvNextAppt.Columns["appt_doc_dept_tel"].ColVIndex = 8;
            gvNextAppt.Columns["appt_doc_dept_tel"].Caption = "Department Tel.";
        }
        private void ReloadNextAppointment()
        {
            LoadNextAppointmentData();
            LoadNextAppointmentFilter();
            LoadNextAppointmentGrid();
        }

        private void gvNextAppt_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks == 2)
            {
                returnNextAppointRow = gvNextAppt.GetDataRow(e.RowHandle);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
