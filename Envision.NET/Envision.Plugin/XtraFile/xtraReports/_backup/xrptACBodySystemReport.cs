using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptACBodySystemReport : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptACBodySystemReport()
        {
            InitializeComponent();
        }

        private void LoadDataGrid()
        { 

        }
        private void LoadDataFilter()
        { 
        }
        private void LoadDataControl()
        { 
        }
        private void ReloadData()
        {
            LoadDataGrid();
            LoadDataFilter();
            LoadDataControl();
        }

    }
}
