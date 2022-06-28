using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Envision.Common;
using System.Data;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptScheduleReportAIMCNew : DevExpress.XtraReports.UI.XtraReport
    {
        public bool HasData { get; set; }
        public int ScheduleID { get; set; }

        private int schedule_id;
        private DataSet dsTemp;
        private string vender;
        private GBLEnvVariable env = new GBLEnvVariable();

        public xrptScheduleReportAIMCNew()
        {
            InitializeComponent();
        }
        public xrptScheduleReportAIMCNew(int _schedule_id)
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;
            schedule_id = _schedule_id;

            initReport();
        }
        private void initReport()
        {
            DataSet ds = new DataSet();

            ProcessScheduleReport slkp = new ProcessScheduleReport();
            slkp.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
            slkp.RIS_SCHEDULE.ORG_ID = env.OrgID;
            slkp.getReportAIMC();
            ds = slkp.ResultSet;
            HasData = true;

            bindingData(ds);
        }
        private void bindingData(DataSet ds)
        {
            DataSource = ds.Tables[0];
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_1"].ToString()))
                xrRichText1.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_2"].ToString()))
                xrRichText2.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_3"].ToString()))
                xrRichText3.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_4"].ToString()))
                xrRichText4.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_5"].ToString()))
                xrRichText5.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_6"].ToString()))
                xrRichText6.Visible = true;
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["INS_7"].ToString()))
                xrRichText7.Visible = true;
            //DataTable dtIns = new DataTable();
            //dtIns = ds.Tables[1].Clone();
            //for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            //{
            //    if (ds.Tables[1].Rows[i]["SERVICE_TYPE"].ToString() == "1")
            //    {
            //        if (ds.Tables[1].Rows[i]["INS_TEXT"].ToString() != "")
            //        {
            //            DataRow drr = dtIns.NewRow();
            //            for (int y = 0; y < dtIns.Columns.Count; y++)
            //            {
            //                drr[y] = ds.Tables[1].Rows[i][y];
            //            }
            //            dtIns.Rows.Add(drr);
            //            dtIns.AcceptChanges();
            //        }
            //    }
            //}
            //DetailReport.DataSource = ds.Tables[1];
            //lblHN.Text = ds.Tables[1].Rows[0]["HN"].ToString();
            //xrBarCode2.Text = ds.Tables[1].Rows[0]["HN"].ToString();
            //lblPatientThai.Text = ds.Tables[1].Rows[0]["PAT_THAI_NAME"].ToString();
            //lblPatientEng.Text = ds.Tables[1].Rows[0]["PAT_ENG_NAME"].ToString();
            //lblAppointDt.Text = "วัน" + Convert.ToDateTime(ds.Tables[1].Rows[0]["APPOINT_DT"]).ToString("dddd d MMMM yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH").DateTimeFormat);
            //lblGender.Text = ds.Tables[1].Rows[0]["GENDER"].ToString();
            //lblAge.Text = ds.Tables[1].Rows[0]["AGE"].ToString();
            //lblClinic.Text = ds.Tables[1].Rows[0]["CLINIC_TYPE_TEXT"].ToString();
            //lblPatientID.Text = ds.Tables[1].Rows[0]["PATIENT_ID_LABEL"].ToString();

            //subExam.ReportSource.DataSource = ds.Tables[1];
            //subIns.ReportSource.DataSource = dtIns;

            //lblCreatedBy.Text = ds.Tables[1].Rows[0]["SCH_CREATED_NAME"].ToString();
            //lblCreatedOn.Text = ds.Tables[1].Rows[0]["SCH_CREATED_DATETIME"].ToString();
            //lblConfirmBy.Text = ds.Tables[1].Rows[0]["SCH_CONFIRMED_NAME"].ToString();
            //lblConfirmOn.Text = ds.Tables[1].Rows[0]["SCH_CONFIRMED_DATETIME"].ToString();
            lblPrintBy.Text = "ผู้ออกบัตรนัด : " + env.FirstName + " " + env.LastName;
            lblPrintBy.Text += "ออกบัตรนัดวันที่ : " + ds.Tables[1].Rows[0]["SCH_PRINT_DATETIME"].ToString();
        }
    }
}
