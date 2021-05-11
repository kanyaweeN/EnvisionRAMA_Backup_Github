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

namespace Envision.NET.Forms.Admin
{
    public partial class frmMPPSMonitoring : MasterForm
    {
        DataTable dtMPPS = new DataTable();

        public frmMPPSMonitoring()
        {
            InitializeComponent();
        }

        private void frmMPPSMonitoring_Load(object sender, EventArgs e)
        {
            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;

            ReloadMPPS();

            base.CloseWaitDialog();
        }

        private void LoadDataMPPS()
        {
            DateTime df = dateFrom.DateTime;
            DateTime dt = dateTo.DateTime;

            ProcessGetRISMPPS getData = new ProcessGetRISMPPS();
            getData.RIS_MPPS.DateForm
                = new DateTime(df.Year, df.Month, df.Day, 0, 0, 0);
            getData.RIS_MPPS.DateTo
                = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
            dtMPPS = getData.GetData();
        }
        private void LoadFilterMPPS()
        { 
        
        }
        private void LoadGridMPPS()
        {
            grcMPPS.DataSource = dtMPPS;

            if (grvMPPS.RowCount < 50)
                grvMPPS.BestFitColumns();
        }
        private void ReloadMPPS()
        {
            LoadDataMPPS();
            LoadFilterMPPS();
            LoadGridMPPS();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadMPPS();
        }
    }
}
