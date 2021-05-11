using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class frmOrderCancelWorklist : MasterForm
    {
        DataTable tbCancelWorklist;

        public frmOrderCancelWorklist()
        {
            InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2007 Blue";

            txtFromDate.DateTime = DateTime.Now;
            txtToDate.DateTime = DateTime.Now;
        }
        private void frmOrderCancelWorklist_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            ReloadOrderIsCancel();
        }

        private void LoadOrderIsCancelData()
        {
            DateTime sd = txtFromDate.DateTime;
            DateTime START_DATE = new DateTime(sd.Year, sd.Month, sd.Day, 0, 0, 0);

            DateTime td = txtToDate.DateTime;
            DateTime END_DATE = new DateTime(td.Year, td.Month, td.Day, 23, 59, 59);

            ProcessGetRISOrder getData = new ProcessGetRISOrder();
            DataTable tb = getData.GetOrderCancelWorklist(START_DATE, END_DATE);

            tbCancelWorklist = tb;
        }
        private void LoadOrderIsCancelFilter()
        {

        }
        private void LoadOrderIsCancelGrid()
        {
            gridControl1.DataSource = tbCancelWorklist.Copy();

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].Visible = false;
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                ++k;
            }

            gridView1.Columns["HN"].VisibleIndex = 0;
            gridView1.Columns["HN"].Caption = "HN";

            gridView1.Columns["PATIENT_NAME"].VisibleIndex = 1;
            gridView1.Columns["PATIENT_NAME"].Caption = "Patient Name";

            gridView1.Columns["ACCESSION_NO"].VisibleIndex = 2;
            gridView1.Columns["ACCESSION_NO"].Caption = "Accession No.";

            gridView1.Columns["ORDER_DT"].VisibleIndex = 3;
            gridView1.Columns["ORDER_DT"].Caption = "Study Date";
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatString = "G";
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            gridView1.Columns["EXAM_UID"].VisibleIndex = 4;
            gridView1.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView1.Columns["EXAM_NAME"].VisibleIndex = 5;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";

            gridView1.Columns["REASON"].VisibleIndex = 6;
            gridView1.Columns["REASON"].Caption = "Cancel Reason";

            gridView1.Columns["LAST_MODIFIED_BY"].VisibleIndex = 7;
            gridView1.Columns["LAST_MODIFIED_BY"].Caption = "Cancelled by";

            gridView1.Columns["LAST_MODIFIED_ON"].VisibleIndex = 8;
            gridView1.Columns["LAST_MODIFIED_ON"].Caption = "Cancel Date";
            gridView1.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatString = "G";
            gridView1.Columns["LAST_MODIFIED_ON"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            if (gridView1.RowCount < 200)
                gridView1.BestFitColumns();
        }
        private void ReloadOrderIsCancel()
        {
            LoadOrderIsCancelData();
            LoadOrderIsCancelFilter();
            LoadOrderIsCancelGrid();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            ReloadOrderIsCancel();
        }


    }
}