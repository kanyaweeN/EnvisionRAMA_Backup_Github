using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Envision.Common;
using Envision.BusinessLogic;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptAIMCFinancialInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptAIMCFinancialInvoice(int ORDER_ID)
        {
            InitializeComponent();

            this.Margins.Left = 200;
            this.Margins.Top = 25;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;

            DateTime now = DateTime.Now;
            lbPrintDate.Text = now.Day.ToString("00") + "/" + now.Month.ToString("00") + "/" + now.Year.ToString("00")+" "+now.ToString("HH:mm:ss");
            lbPrintBy.Text = new GBLEnvVariable().UserName + " " + new GBLEnvVariable().FirstName + " "+ new GBLEnvVariable().LastName;

            LookUpSelect getData = new LookUpSelect();
            DataSet ds = getData.SelectRptAIMCFinancialInvoice(ORDER_ID);

            if (ds.Tables[0].Rows.Count == 0) return;

            this.DataSource = ds;

            DataRow row = ds.Tables[0].Rows[0];
            
            lbHN.Text = row["HN"].ToString();
            lbInsuranctTypeName.Text = row["INSURANCE_TYPE_NAME"].ToString();
            lbRateTotal.Text = row["RATE_TOTAL"].ToString();//RATE_TOTAL
            lbClinicType.Text = row["CLINIC_TYPE_NAME"].ToString();

            bcodeHN.Text = row["HN"].ToString();

            lbPatientName.Text = row["PATIENT_NAME"].ToString();
            lbPatientName2.Text = row["PATIENT_NAME"].ToString();
            lbScheduleDate.Text = row["ORDER_DT"].ToString();
            //lbScheduleDate.Text = Convert.ToDateTime(row["ORDER_DT"]).ToLocalTime().ToString();
            lbOrderingPhysician.Text = row["REF_DOC_NAME"].ToString();

            lbOrderingDepartment.Text = row["UNIT_NAME"].ToString();
            lbTelephone.Text = row["PHONE_NO"].ToString();

            cellExamName.DataBindings.Add("Text", ds, "EXAM_NAME", "");
            cellExamRate.DataBindings.Add("Text", ds, "RATE", "");
        }
    }
}
