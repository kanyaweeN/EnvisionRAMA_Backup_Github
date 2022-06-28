using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;
using Envision.Plugin.XtraFile.xtraReports;
using CrystalDecisions.CrystalReports.Engine;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_SummaryFullDFTech : Envision.NET.Forms.Main.MasterForm
    {
        //public RPT_SummaryFullDFTech()
        //{
        //    InitializeComponent();
        //}
        public RPT_SummaryFullDFTech()
        {
            InitializeComponent();
            getHeaderReport();
        }
        private void getHeaderReport()
        {
            DataTable dtt = new DataTable();
            //order dr = new order();
            //dtt = order.Ris_Radiologist().Copy();
            ProcessGetHREmp hre = new ProcessGetHREmp();
            hre.HR_EMP.MODE = "select_all_technologist";
            hre.Invoke();
            dtt = hre.Result.Tables[0].Copy();

            dtt.NewRow();
            dtt.Rows.Add(0, "--ทั้งหมด--");
            dtt.AcceptChanges();

            cmbHeaderReport.DisplayMember = "RadioName";
            cmbHeaderReport.ValueMember = "EMP_ID";
            cmbHeaderReport.DataSource = dtt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                int i = 1;
                try { i = Convert.ToInt32(cmbHeaderReport.SelectedValue.ToString()); }
                catch { }
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectSumarryDFTech(dtStart, dtEnd, i);

                ReportDocument rptDoc = reportprovider.rptSummaryDFTech(ds.Tables[0]);
                frmReportViewer RForm = new frmReportViewer(rptDoc);
                //DisplayForm(formContainer1, RForm, "RPT_SummaryFullDFTech");

                //RIS.Operational.XtraFile.xtraReports.xrptSummaryDFByTech xrpt = new RIS.Operational.XtraFile.xtraReports.xrptSummaryDFByTech(ds.Tables[0]);
                //xrpt.ShowPreview();
                dlg.Close();
                //RForm.ShowDialog();
                RForm.Show();
                RForm.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPT_AppointDate_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
        //private void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        //{
        //    System.Windows.Forms.Form rDisplay;
        //    UUL.ControlFrame.Controls.TabPage page;
        //    rDisplayForm.Text = formName;
        //    rDisplay = rDisplayForm;       //--Set text
        //    setFormProperty(rDisplayForm);
        //    //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
        //    page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
        //    page.Selected = true;
        //    rTabControl.TabPages.Add(page);
        //}

        public void setFormProperty(Form displayForm)
        {
            try
            {
                //displayForm.Font = new System.Drawing.Font("verdana", 10);
                System.Drawing.Color c = System.Drawing.Color.FromArgb( /* R */ 0x98, /* G */ 0xB8, /* B */ 0xE2);
                //displayForm.BackColor = System.Drawing.Color.Red;
                displayForm.BackColor = c;
                displayForm.MaximizeBox = false;
                displayForm.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}