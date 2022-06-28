using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmScheduleConflictDetail : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable data_Schedule;
        public frmScheduleConflictDetail()
        {
            InitializeComponent();
        }
        public frmScheduleConflictDetail(DataTable dtSchedule)
        {
            InitializeComponent();
            data_Schedule = new DataTable();
            data_Schedule = dtSchedule;
        }
        private void frmScheduleConflictDetail_Load(object sender, EventArgs e)
        {
            grdData.DataSource = data_Schedule;

            for (int i = 0; i < viewData.Columns.Count; i++)
                viewData.Columns[i].Visible = false;
            viewData.Columns["EXAM_NAME"].Caption = "Exam";
            viewData.Columns["EXAM_NAME"].Width = 30;
            viewData.Columns["EXAM_NAME"].VisibleIndex = 1;

            viewData.Columns["MODALITY_NAME"].Caption = "Modality";
            viewData.Columns["MODALITY_NAME"].Width = 20;
            viewData.Columns["MODALITY_NAME"].VisibleIndex = 2;

            viewData.Columns["START_DATETIME"].Caption = "Schedule Datatime";
            viewData.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            viewData.Columns["START_DATETIME"].Width = 30;
            viewData.Columns["START_DATETIME"].VisibleIndex = 3;

            viewData.Columns["SCHEDULE_DATA"].Caption = "Schedule Detail";
            viewData.Columns["SCHEDULE_DATA"].Width = 40;
            viewData.Columns["SCHEDULE_DATA"].VisibleIndex = 4;
        }
    }
}