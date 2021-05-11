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
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmRadiologistWorkloadER : MasterForm
    {
        public frmRadiologistWorkloadER()
        {
            InitializeComponent();
        }
        private void frmRadiologistWorkloadER_Load(object sender, EventArgs e)
        {
            txtDateFrom.DateTime = DateTime.Now.AddDays(-7);
            txtDateTo.DateTime = DateTime.Now;

            #region Load Radiologist List
            LookUpSelect lku = new LookUpSelect();
            DataSet dsRad = lku.SelectRadiologistWorkloadER("RadiologistList", DateTime.Now, DateTime.Now, "");
            
            txtRadiologistList.Properties.Items.Clear();
            foreach (DataRow dr in dsRad.Tables[0].Rows)
            {
                txtRadiologistList.Properties.Items.Add(dr["EMP_ID"], dr["FULL_NAME"].ToString(), CheckState.Unchecked, true);
            }
            #endregion

            base.CloseWaitDialog();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            base.ShowWaitDialog();

            ShowReport();

            base.CloseWaitDialog();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowReport()
        {
            LookUpSelect lku = new LookUpSelect();
            DataSet dsRad = lku.SelectRadiologistWorkloadER("ReportData", txtDateFrom.DateTime, txtDateTo.DateTime, txtRadiologistList.EditValue.ToString());

            xrptRadiologistWorkload Xrpt = new xrptRadiologistWorkload(dsRad.Tables[0]);
            Xrpt.ShowPreview();
        }
    }
}
