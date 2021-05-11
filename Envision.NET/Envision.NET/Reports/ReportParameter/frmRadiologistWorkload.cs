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
    public partial class frmRadiologistWorkload : MasterForm
    {
        public frmRadiologistWorkload()
        {
            InitializeComponent();
        }
        private void frmRadiologistWorkload_Load(object sender, EventArgs e)
        {
            LoadControl();
            this.CloseWaitDialog();
        }

        private void LoadControl()
        {
            LookUpSelect lk = new LookUpSelect();
            DataSet ds = lk.SelectRadiologistWorkload(DateTime.Now, DateTime.Now, -1);

            txtRadiologist.DisplayMember = "RadioNameFull";
            txtRadiologist.ValueMember = "EMP_ID";
            txtRadiologist.DataSource = ds.Tables[0];
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            int empID = 0;
            try { empID = Convert.ToInt32(txtRadiologist.SelectedValue.ToString()); }
            catch { }
            DateTime FromDate = new DateTime(txtDateFrom.Value.Year, txtDateFrom.Value.Month, txtDateFrom.Value.Day, 0, 0, 0);
            DateTime ToDate = new DateTime(txtDateTo.Value.Year, txtDateTo.Value.Month, txtDateTo.Value.Day, 23, 59, 59);

            LookUpSelect lk = new LookUpSelect();
            DataSet ds = lk.SelectRadiologistWorkload(FromDate, ToDate, empID);

            xrptRadiologistWorkload Xrpt = new xrptRadiologistWorkload(ds.Tables[0]);
            Xrpt.ShowPreview();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
