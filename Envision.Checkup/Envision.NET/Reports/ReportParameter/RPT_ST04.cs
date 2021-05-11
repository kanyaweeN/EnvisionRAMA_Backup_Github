using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Operational.ReportManager;
namespace RIS.Reports.ReportParameter
{
    public partial class RPT_ST04 : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;
        public RPT_ST04(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(formContainer1, this);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportMangager reportprovider = new ReportMangager();
            ReportViewer.frmReportViewer frmViewer = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptDuration(dateTimePicker1.Value, dateTimePicker2.Value), formContainer1);
            UUL.ControlFrame.Controls.TabPage page;
            page = new UUL.ControlFrame.Controls.TabPage(frmViewer.Text, frmViewer);
            page.Selected = true;
            formContainer1.TabPages.Add(page);

        }
    }
}