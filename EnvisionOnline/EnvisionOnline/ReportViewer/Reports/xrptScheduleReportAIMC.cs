using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.Common.Common;
using System.Globalization;

namespace EnvisionOnline.Operational.XtraReport.xtraReports
{
    public partial class xrptScheduleReportAIMC : DevExpress.XtraReports.UI.XtraReport
    {
        private int schedule_id, org_id;
        private DataSet dsTemp;
        private string vender, printor_name;

        public xrptScheduleReportAIMC(GBLEnvVariable envv)
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;

        }
        public xrptScheduleReportAIMC(int _schedule_id,int _org_id,string _printor_name)
        {

            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;
            schedule_id = _schedule_id;
            org_id = _org_id;
            printor_name = _printor_name;

            initReport();
        }
        public xrptScheduleReportAIMC(DataSet ds, GBLEnvVariable envv)
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;
            dsTemp = new DataSet();

            bindingData(ds);
        }
        private void initReport()
        {
            DataSet ds = new DataSet();

            ProcessScheduleReport slkp = new ProcessScheduleReport();
            slkp.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
            slkp.RIS_SCHEDULE.ORG_ID = org_id;
            slkp.getReport();
            ds = slkp.ResultSet;

            bindingData(ds);
        }
        private void bindingData(DataSet ds)
        {
            DataSource = ds.Tables[0];

            DataTable dtIns = new DataTable();
            dtIns = ds.Tables[1].Clone();
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                if (ds.Tables[1].Rows[i]["SERVICE_TYPE"].ToString() == "1")
                {
                    if (ds.Tables[1].Rows[i]["INS_TEXT"].ToString() != "" || ds.Tables[1].Rows[i]["HR_UNIT_INS"].ToString() != "")
                    {
                        DataRow drr = dtIns.NewRow();
                        for (int y = 0; y < dtIns.Columns.Count; y++)
                        {
                            drr[y] = ds.Tables[1].Rows[i][y];
                        }
                        dtIns.Rows.Add(drr);
                        dtIns.AcceptChanges();
                    }
                }
            }
            //DetailReport.DataSource = ds.Tables[1];
            lblHN.Text = ds.Tables[1].Rows[0]["HN"].ToString();
            xrBarCode2.Text = ds.Tables[1].Rows[0]["HN"].ToString();
            lblPatientThai.Text = ds.Tables[1].Rows[0]["PAT_THAI_NAME"].ToString();
            lblPatientEng.Text = ds.Tables[1].Rows[0]["PAT_ENG_NAME"].ToString();
            lblAppointDt.Text = "วัน"+ Convert.ToDateTime(ds.Tables[1].Rows[0]["APPOINT_DT"]).ToString("dddd d MMMM yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
            lblGender.Text = ds.Tables[1].Rows[0]["GENDER"].ToString();
            lblAge.Text = ds.Tables[1].Rows[0]["AGE"].ToString();
            lblClinic.Text = ds.Tables[1].Rows[0]["CLINIC_TYPE_TEXT"].ToString();


            subExam.ReportSource.DataSource = ds.Tables[1];
            subIns.ReportSource.DataSource = dtIns;
            lblCreatedBy.Text = ds.Tables[1].Rows[0]["SCH_CREATED_NAME"].ToString();
            lblCreatedOn.Text = ds.Tables[1].Rows[0]["SCH_CREATED_DATETIME"].ToString();
            lblConfirmBy.Text = ds.Tables[1].Rows[0]["SCH_CONFIRMED_NAME"].ToString();
            lblConfirmOn.Text = ds.Tables[1].Rows[0]["SCH_CONFIRMED_DATETIME"].ToString();
            lblPrintBy.Text = "Print By : " + printor_name;
            lblPrintOn.Text = ds.Tables[1].Rows[0]["SCH_PRINT_DATETIME"].ToString();
        }
        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
