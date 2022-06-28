using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_BrowserOLAP : Envision.NET.Forms.Main.MasterForm
    {
        public RPT_BrowserOLAP()
        {
            InitializeComponent();
        }

        private void RPT_BrowserOLAP_Load(object sender, EventArgs e)
        {
            webBrowserOlap.Url = new Uri("http://ENVISIONDB/EnvisionOlapNet/OlapClient/CubeClient.aspx");
            base.CloseWaitDialog();
        }
    }
}
