using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmAppointmentHistory : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string hn;
        private DataTable dttApp;
        private DataTable dttHis;

        public int SCHEDULE_ID { get; set; }
        public int SELECT_MODE { get; set; }
        public frmAppointmentHistory(DataSet ds)
        {
            InitializeComponent();
            SCHEDULE_ID = 0;
            dttApp = ds.Tables[0];
            dttHis = ds.Tables[1];
            initiateDemographic(ds.Tables[2]);
            initiateData();
            initiateHistory();
            DialogResult = DialogResult.Cancel;
        }
        private void initiateDemographic(DataTable dtt) {
            hn = dtt.Rows[0]["HN"].ToString();
            txtHN.EditValue = dtt.Rows[0]["HN"].ToString();
            txtName.EditValue = dtt.Rows[0]["PATIENT_NAME"].ToString();
            txtAge.EditValue = dtt.Rows[0]["AGE"].ToString();
        }
        private void initiateData()
        {
            grdApp.DataSource = dttApp;
            for (int i = 0; i < dttApp.Columns.Count; i++)
                viewApp.Columns[i].Visible = false;

            viewApp.Columns["START_DATETIME"].Visible = true;
            viewApp.Columns["START_DATETIME"].VisibleIndex = 0;
            viewApp.Columns["START_DATETIME"].Caption = "Start DataTime";
            viewApp.Columns["START_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewApp.Columns["START_DATETIME"].BestFit();

            viewApp.Columns["END_DATETIME"].Visible = true;
            viewApp.Columns["END_DATETIME"].VisibleIndex = 1;
            viewApp.Columns["END_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewApp.Columns["END_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewApp.Columns["END_DATETIME"].Caption = "End DataTime";
            viewApp.Columns["END_DATETIME"].BestFit();

            viewApp.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            viewApp.Columns["CLINIC_TYPE_TEXT"].VisibleIndex = 2;
            viewApp.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
            viewApp.Columns["CLINIC_TYPE_TEXT"].Width = 80;

            viewApp.Columns["MODALITY_NAME"].Visible = true;
            viewApp.Columns["MODALITY_NAME"].VisibleIndex = 3;
            viewApp.Columns["MODALITY_NAME"].Caption = "Modaltiy";
            viewApp.Columns["MODALITY_NAME"].Width = 120;

            viewApp.Columns["EXAM_NAME"].Visible = true;
            viewApp.Columns["EXAM_NAME"].VisibleIndex = 4;
            viewApp.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewApp.Columns["EXAM_NAME"].Width = 120;

            viewApp.Columns["RADIOLOGY"].Visible = true;
            viewApp.Columns["RADIOLOGY"].VisibleIndex = 5;
            viewApp.Columns["RADIOLOGY"].Caption = "Radiology";
            viewApp.Columns["RADIOLOGY"].Width = 130;

            viewApp.Columns["SCHEDULE_STATUS"].Visible = true;
            viewApp.Columns["SCHEDULE_STATUS"].VisibleIndex = 6;
            viewApp.Columns["SCHEDULE_STATUS"].Caption = "Status";
            viewApp.Columns["SCHEDULE_STATUS"].Width = 80;
        }
        private void initiateHistory() {
            grdHis.DataSource = dttHis;
            for (int i = 0; i < dttHis.Columns.Count; i++)
                viewHis.Columns[i].Visible = false;
            viewHis.Columns["START_DATETIME"].Visible = true;
            viewHis.Columns["START_DATETIME"].VisibleIndex = 0;
            viewHis.Columns["START_DATETIME"].Caption = "Start DataTime";
            viewHis.Columns["START_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewHis.Columns["START_DATETIME"].BestFit();

            viewHis.Columns["END_DATETIME"].Visible = true;
            viewHis.Columns["END_DATETIME"].VisibleIndex = 1;
            viewHis.Columns["END_DATETIME"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewHis.Columns["END_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewHis.Columns["END_DATETIME"].Caption = "End DataTime";
            viewHis.Columns["END_DATETIME"].BestFit();

            viewHis.Columns["CLINIC_TYPE_TEXT"].Visible = true;
            viewHis.Columns["CLINIC_TYPE_TEXT"].VisibleIndex = 2;
            viewHis.Columns["CLINIC_TYPE_TEXT"].Caption = "Clinic";
            viewHis.Columns["CLINIC_TYPE_TEXT"].Width = 80;

            viewHis.Columns["MODALITY_NAME"].Visible = true;
            viewHis.Columns["MODALITY_NAME"].VisibleIndex = 3;
            viewHis.Columns["MODALITY_NAME"].Caption = "Modaltiy";
            viewHis.Columns["MODALITY_NAME"].Width = 120;

            viewHis.Columns["EXAM_NAME"].Visible = true;
            viewHis.Columns["EXAM_NAME"].VisibleIndex = 4;
            viewHis.Columns["EXAM_NAME"].Caption = "Exam Name";
            viewHis.Columns["EXAM_NAME"].Width = 120;

            viewHis.Columns["RADIOLOGY"].Visible = true;
            viewHis.Columns["RADIOLOGY"].VisibleIndex = 5;
            viewHis.Columns["RADIOLOGY"].Caption = "Radiology";
            viewHis.Columns["RADIOLOGY"].Width = 130;

            viewHis.Columns["SCHEDULE_STATUS"].Visible = true;
            viewHis.Columns["SCHEDULE_STATUS"].VisibleIndex = 6;
            viewHis.Columns["SCHEDULE_STATUS"].Caption = "Status";
            viewHis.Columns["SCHEDULE_STATUS"].Width = 80;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPage.Name)
            {
                case "pageAppointmentData": selectViewApp(); break;
                case "pageHistory": selectViewHis(); break;
            }
           
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectViewApp()
        {
            if (viewApp.FocusedRowHandle > -1)
            {
                DataRow dr = viewApp.GetDataRow(viewApp.FocusedRowHandle);
                SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"].ToString());
                SELECT_MODE = 0;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void viewApp_DoubleClick(object sender, EventArgs e)
        {
            selectViewApp();
        }
        private void selectViewHis()
        {
            if (viewHis.FocusedRowHandle > -1)
            {
                DataRow dr = viewHis.GetDataRow(viewHis.FocusedRowHandle);
                SCHEDULE_ID = Convert.ToInt32(dr["SCHEDULE_ID"].ToString());
                SELECT_MODE = 1;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void viewHis_DoubleClick(object sender, EventArgs e)
        {
            selectViewHis();
        }
    }
}
