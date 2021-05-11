using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.Operational.ReportManager;
using RIS.BusinessLogic;
using RIS.Common.Common;

namespace RIS.Reports.ReportParameter
{
    public partial class RPT_SummaryOrder : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;
        public RPT_SummaryOrder()
        {
            InitializeComponent();
        }
        public RPT_SummaryOrder(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
            getHeaderReport();
        }
        private void getHeaderReport()
        {
            LookUpSelect lk = new LookUpSelect();
            DataSet ds = lk.SelectHeaderReport();
            //DataSet dsHeader = ds.Clone();
            //DataRow[] drId = ds.Tables[0].Select("id <=3 ");
            //for (int i = 0; i < drId.Length; i++)
            //{
            //    dsHeader.Tables[0].NewRow();
            //    dsHeader.Tables[0].Rows.Add(drId[i].ItemArray);
            //    dsHeader.AcceptChanges();
            //}
            cmbHeaderReport.DataSource = ds.Tables[0];
            cmbHeaderReport.DisplayMember = "Name";
            cmbHeaderReport.ValueMember = "id";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                int i = 1;
                try { i = Convert.ToInt32(cmbHeaderReport.SelectedValue.ToString()); }
                catch { }
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();
                DataSet ds = lk.SelectSumarryReport(i, dtStart, dtEnd, cmbHeaderReport.Text);

                RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptSummaryReport(i,ds.Tables[0]), formContainer1);
                DisplayForm(formContainer1, RForm, "RPT_SummaryReport");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(formContainer1, this);
        }

        private void RPT_AppointDate_Load(object sender, EventArgs e)
        {

        }
        private void DisplayForm(UUL.ControlFrame.Controls.TabControl rTabControl, System.Windows.Forms.Form rDisplayForm, string formName)
        {
            System.Windows.Forms.Form rDisplay;
            UUL.ControlFrame.Controls.TabPage page;
            rDisplayForm.Text = formName;
            rDisplay = rDisplayForm;       //--Set text
            setFormProperty(rDisplayForm);
            //page = new UUL.ControlFrame.Controls.TabPage(rDisplayForm.Text, rDisplayForm, rDisplayForm.Icon);
            page = new UUL.ControlFrame.Controls.TabPage(rDisplay.Text, rDisplay);
            page.Selected = true;
            rTabControl.TabPages.Add(page);
        }

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