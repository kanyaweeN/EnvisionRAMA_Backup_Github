using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RIS.Reports.ReportViewer
{
    public partial class frmXtraReportViewer : Form
    {
        public string reportURL;
        private UUL.ControlFrame.Controls.TabControl CloseControl;
        public frmXtraReportViewer(string url, UUL.ControlFrame.Controls.TabControl clsCtl)
        {
            InitializeComponent();
            reportURL = url;
            CloseControl = clsCtl;
        }
        public frmXtraReportViewer(string url)
        {
            InitializeComponent();
            reportURL = url;
            //CloseControl = clsCtl;
        }
        private void frmXtraReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                Uri ur = new Uri(reportURL);
                //ur.
                this.webBrowser1.Url = ur;
            }
            catch { }
        }
    }
}