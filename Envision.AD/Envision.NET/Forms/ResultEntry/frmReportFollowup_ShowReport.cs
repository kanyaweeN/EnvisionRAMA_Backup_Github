using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.NET.Forms.Main;
using Envision.BusinessLogic;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmReportFollowup_ShowReport : MasterForm
    {
        public string HN;
        public DateTime ORDER_DT;
        public string PATIENT_NAME;
        public string PHONE;

        public string EXAM;

        DataTable dt;
        DataView dv;

        public frmReportFollowup_ShowReport()
        {
            InitializeComponent();
        }
        private void frmReportFollowup_ShowReport_Load(object sender, EventArgs e)
        {
            if (HN.Trim().Length == 0) return;

            txtHN.Text = HN;
            txtPatientName.Text = PATIENT_NAME;
            txtTel.Text = PHONE;

            txtStudyDate.Text = ORDER_DT.Day.ToString("00") + "/" + ORDER_DT.Month.ToString("00") + "/" + ORDER_DT.Year.ToString("0000");
            txtExam.Text = EXAM;

            ReloadReport();
        }

        private void LoadDataReport()
        {
            //hn        string
            //lab_date  string
            //lab         string
            //report    string
            //type      string
            //sid       string

            //"C" - Clinical Pathology Laboratory
            //"S" - Anatomical Pathology Laboratory 

            dt = new DataTable();

            try
            {
                HIS_Patient ws = new HIS_Patient();
                DataTable ws_dt = ws.Get_lab_data(HN).Tables[0];

                ws_dt.Columns.Add("type_detail");
                ws_dt.AcceptChanges();

                //DataTable new_dt = ws_dt.Clone(); 
                foreach(DataRow row in ws_dt.Rows)
                {
                    if (row["type"].ToString().Trim() == "C")
                        row["type_detail"] = "Clinical Pathology";
                    else if (row["type"].ToString().Trim() == "S")
                        row["type_detail"] = "Anatomical Pathology";
                    else
                        row["type_deatil"] = "";
                }

                dt = ws_dt;
                dt.AcceptChanges();
            }
            catch
            {
                dt = new DataTable();
                dt.Columns.Add("hn");
                dt.Columns.Add("lab_date");
                dt.Columns.Add("lab");
                dt.Columns.Add("report");
                dt.Columns.Add("type");
                dt.Columns.Add("type_detail");
                dt.Columns.Add("sid");
                dt.AcceptChanges();
            }

            dv = new DataView(dt);
        }
        private void LoadFilterReport()
        {
            if (dt.Rows.Count == 0) return;
            if (!dt.Columns.Contains("lab_date")) return;

            if (chkShowAll.CheckState == CheckState.Checked)
            {
                dv.RowFilter = "";
            }
            else
            {
                string filter = "";
                filter = "lab_date >= '"
                    + ORDER_DT.Year + "-" + ORDER_DT.Month + "-" + ORDER_DT.Day + " 00:00:00"
                    + "' and lab_date <= '" +
                    +ORDER_DT.Year + "-" + ORDER_DT.Month + "-" + ORDER_DT.Day + " 23:59:59'";
                dv.RowFilter = filter;
            }

            dv.Sort = "lab_date desc";
        }
        private void LoadGridReport()
        {
            gridControl1.DataSource = dv;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridView1.Columns)
            {
                col.OptionsColumn.ReadOnly = true;
                col.Visible = false;
            }

            gridView1.Columns["lab_date"].ColVIndex = 0;
            gridView1.Columns["lab_date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["lab_date"].DisplayFormat.FormatString = "dd/MM/yyyy";
            gridView1.Columns["lab_date"].Caption = "Lab Date";

            gridView1.Columns["lab"].ColVIndex = 1;
            gridView1.Columns["lab"].Caption = "Lab Name";

            gridView1.Columns["type_detail"].ColVIndex = 2;
            gridView1.Columns["type_detail"].Caption = "Lab Type";

            //gridView1.Columns["report"].ColVIndex = 2;
            //gridView1.Columns["report"].Caption = "Report";
        
            gridView1.BestFitColumns();

            if (gridView1.RowCount > 0)
                gridView1.FocusedRowHandle = 0;
            else
                txtReportInformation.Text = "";
        }
        private void ReloadReport()
        {
            LoadDataReport();
            LoadFilterReport();
            LoadGridReport();
        }

        private void chkShowAll_CheckStateChanged(object sender, EventArgs e)
        {
            LoadFilterReport();
            LoadGridReport();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;

            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string report = dataRow["report"].ToString();
            txtReportInformation.Text = report;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
