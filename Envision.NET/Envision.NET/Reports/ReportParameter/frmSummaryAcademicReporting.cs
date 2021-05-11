using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.Plugin.XtraFile.xtraReports;
using Envision.BusinessLogic;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmSummaryAcademicReporting : MasterForm
    {
        public frmSummaryAcademicReporting()
        {
            InitializeComponent();
        }

        private void frmSummaryAcademicReporting_Load(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            Order dr = new Order();
            dtt = RISBaseData.Ris_Radiologist().Copy();
            dtt.NewRow();
            dtt.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--", 3, "--ทั้งหมด--", "--ทั้งหมด--", "--ทั้งหมด--");
            dtt.AcceptChanges();

            txtRadiologist.DisplayMember = "RadioName";
            txtRadiologist.ValueMember = "EMP_ID";
            txtRadiologist.DataSource = dtt;

            txtDateFrom.DateTime = DateTime.Now;
            txtDateTo.DateTime = DateTime.Now;
            txtRadiologist.SelectedIndex = 0;

            base.CloseWaitDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            xrptACAcademicReport xrpt;
            
            DateTime dtFrom = new DateTime(txtDateFrom.DateTime.Year,txtDateFrom.DateTime.Month,txtDateFrom.DateTime.Day,0,0,0);
            DateTime dtTo = new DateTime(txtDateTo.DateTime.Year,txtDateTo.DateTime.Month,txtDateTo.DateTime.Day,23,59,59);
            int RadID = Convert.ToInt32(txtRadiologist.SelectedValue);
            string Mode = "";

            if (Convert.ToInt32(txtRadiologist.SelectedValue) == 0)
                Mode = "AllRad";
            else
                Mode = "OnlyOneRad";

            //xrpt = new xrptACAcademicReport(dtFrom, dtTo, RadID, Mode);
            //xrpt.ShowPreviewDialog();
            LookUpSelect lk = new LookUpSelect();
            DataSet dsData = lk.SelectACAcademicReport(dtFrom, dtTo, RadID, Mode);
            if (dsData != null && dsData.Tables.Count > 0)
            {
                xrpt = new xrptACAcademicReport(dsData.Tables[0]);
                xrpt.ShowPreviewDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
