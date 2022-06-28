using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Envision.NET.Properties;
using DevExpress.Utils;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmReportFollowup : MasterForm
    {
        DataTable dtOrder = new DataTable();
        DataView dvOrder = new DataView();

        public frmReportFollowup()
        {
            InitializeComponent();
        }
        private void frmReportFollowup_Load(object sender, EventArgs e)
        {
            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;

            ReloadOrder();

            base.CloseWaitDialog();
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReloadOrder();
        }

        private void LoadDataOrder()
        { 
            DateTime FromDate = new DateTime(
                    dateFrom.DateTime.Year,dateFrom.DateTime.Month,dateFrom.DateTime.Day,0,0,0);

            DateTime ToDate = new DateTime(
                    dateTo.DateTime.Year,dateTo.DateTime.Month,dateTo.DateTime.Day,23,59,59);

            ProcessGetRISOrderdtl prcGet = new ProcessGetRISOrderdtl();
            DataSet ds = prcGet.getOrderData(FromDate,ToDate);
            dtOrder = ds.Tables[0];

            dtOrder.Columns.Add("REPORT");
            dtOrder.Columns.Add("CHECK");

            foreach (DataRow row in dtOrder.Rows)
                row["CHECK"] = "N";

            dtOrder.AcceptChanges();
        }
        private void LoadFilterOrder()
        {
            
        }
        private void LoadGridOrder()
        {
            gridControl1.DataSource = dtOrder;

            foreach (GridColumn col in gridView1.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.Visible = false;
            }


            RepositoryItemCheckEdit repCheck 
                = new RepositoryItemCheckEdit();
            repCheck.ValueChecked = "Y";
            repCheck.ValueGrayed = "N";
            repCheck.ValueUnchecked = "N";
            repCheck.AllowGrayed = false;
            repCheck.Caption = "";

            RepositoryItemHyperLinkEdit repBtn 
                = new RepositoryItemHyperLinkEdit();
            repBtn.Image = imgSmall.Images[0];
            repBtn.TextEditStyle = TextEditStyles.DisableTextEditor;
            repBtn.ImageAlignment = HorzAlignment.Center;
            repBtn.Click += new EventHandler(repBtn_Click);


            gridView1.Columns["CHECK"].ColVIndex = 1;
            gridView1.Columns["CHECK"].ColumnEdit = repCheck;
            gridView1.Columns["CHECK"].Caption = "";
            gridView1.Columns["CHECK"].Width = 25;
            gridView1.Columns["CHECK"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["REPORT"].ColVIndex = 2;
            gridView1.Columns["REPORT"].ColumnEdit = repBtn;
            gridView1.Columns["REPORT"].Caption = "Report";
            gridView1.Columns["REPORT"].Width = 50;
            gridView1.Columns["REPORT"].OptionsColumn.FixedWidth = true;

            gridView1.Columns["HN"].ColVIndex = 3;
            gridView1.Columns["HN"].Caption = "HN";
            gridView1.Columns["HN"].MinWidth = 50;

            gridView1.Columns["PATIENT_NAME"].ColVIndex = 4;
            gridView1.Columns["PATIENT_NAME"].Caption = "Name";
            gridView1.Columns["PATIENT_NAME"].MinWidth = 50;

            gridView1.Columns["ORDER_DT"].ColVIndex = 5;
            gridView1.Columns["ORDER_DT"].Caption = "Study Date";
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns["ORDER_DT"].DisplayFormat.FormatString = "g";
            gridView1.Columns["ORDER_DT"].MinWidth = 75;

            gridView1.Columns["EXAM_UID"].ColVIndex = 6;
            gridView1.Columns["EXAM_UID"].Caption = "Exam Code";
            gridView1.Columns["EXAM_UID"].MinWidth = 75;

            gridView1.Columns["EXAM_NAME"].ColVIndex = 7;
            gridView1.Columns["EXAM_NAME"].Caption = "Exam Name";
            gridView1.Columns["EXAM_NAME"].MinWidth = 100;

            gridView1.Columns["PHONE"].ColVIndex = 8;
            gridView1.Columns["PHONE"].Caption = "Phone";
            gridView1.Columns["PHONE"].MinWidth = 100;

            gridView1.Columns["ACCESSION_NO"].ColVIndex = 9;
            gridView1.Columns["ACCESSION_NO"].Caption = "Acc. No.";
            gridView1.Columns["ACCESSION_NO"].MinWidth = 75;

            gridView1.BestFitColumns();
        }
        private void ReloadOrder()
        {
            LoadDataOrder();
            LoadFilterOrder();
            LoadGridOrder();
        }

        private void repBtn_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string HN = row["HN"].ToString();
            string PATIENT_NAME = row["PATIENT_NAME"].ToString();
            string PHONE = row["PHONE"].ToString();
            DateTime ORDER_DT = Convert.ToDateTime(row["ORDER_DT"]);
            string EXAM = row["EXAM_UID"].ToString() + " - " + row["EXAM_NAME"].ToString();

            frmReportFollowup_ShowReport dlg = new frmReportFollowup_ShowReport();
            dlg.HN = HN;
            dlg.PATIENT_NAME = PATIENT_NAME;
            dlg.PHONE = PHONE;
            dlg.ORDER_DT = ORDER_DT;
            dlg.EXAM = EXAM;
            dlg.ShowDialog();
        }

        private void btnCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //    row["EXAM_UID"]
            //}
        }
    }
}
