using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnvisionAdminTools.HIS
{
    public partial class dlgShowData : Form
    {
        private DataTable dtt;

        public dlgShowData(DataTable dttData)
        {
            InitializeComponent();
            dtt = dttData;
            showGrid();
        }
        private void showGrid() {
            grdData.DataSource = dtt;
        }
    }
}