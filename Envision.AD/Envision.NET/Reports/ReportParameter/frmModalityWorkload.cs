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
using Envision.BusinessLogic;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class frmModalityWorkload : MasterForm
    {
        public frmModalityWorkload()
        {
            InitializeComponent();
        }
        private void frmModalityWorkload_Load(object sender, EventArgs e)
        {
            txtDateFrom.DateTime = DateTime.Now;
            txtDateTo.DateTime = DateTime.Now;
            txtDepartment.Properties.Items.Clear();

            LookUpSelect lkSelect = new LookUpSelect();
            DataSet dsResult = lkSelect.SelectStudiesWorkloadbyModality("GetItemList", DateTime.Now, DateTime.Now);
            if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsResult.Tables[0].Rows)
                {
                    txtDepartment.Properties.Items.Add(dr["ITEM_NAME"].ToString());
                }
            }

            base.CloseWaitDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string selectMode = txtDepartment.Text;

            DateTime df = new DateTime(txtDateFrom.DateTime.Year, txtDateFrom.DateTime.Month, txtDateFrom.DateTime.Day, 0, 0, 0);
            DateTime dt = new DateTime(txtDateTo.DateTime.Year, txtDateTo.DateTime.Month, txtDateTo.DateTime.Day, 23, 59, 59);

            LookUpSelect lkSelect = new LookUpSelect();
            DataSet dsResult = lkSelect.SelectStudiesWorkloadbyModality(selectMode, df, dt);

            if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
            {
                xrptModalityWorkload rpt = new xrptModalityWorkload(dsResult);
                rpt.DateFrom = df.ToString("dd/MM/yyyy");
                rpt.DateTo = dt.ToString("dd/MM/yyyy");
                rpt.DeptName = selectMode;
                rpt.ShowPreviewDialog();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
