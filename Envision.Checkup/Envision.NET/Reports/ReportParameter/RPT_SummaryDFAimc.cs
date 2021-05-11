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
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Reports.ReportViewer;
using RIS.Common.UtilityClass;
using RIS.Plugin.ReportManager;

namespace RIS.Reports.ReportParameter
{
    public partial class RPT_SummaryDFAimc : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;

        public RPT_SummaryDFAimc(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
        }

        private void RPT_SummaryDFAimc_Load(object sender, EventArgs e)
        {
            getHeaderReport();
            getModality();
        }
        private void getHeaderReport()
        {
            DataTable dtt = new DataTable();
            ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
            dtt = processRadiologist.GetRadioLogist().Copy();
            dtt.TableName = "HR_EMP";
            dtt.NewRow();
            dtt.Rows.Add(0, "--������--", "--������--", 3, "--������--", "--������--", "--������--");
            dtt.AcceptChanges();

            cmbHeaderReport.DisplayMember = "RadioName";
            cmbHeaderReport.ValueMember = "EMP_ID";
            cmbHeaderReport.DataSource = dtt;
        }
        public void getModality()
        {
            ProcessGetHRUnit proc = new ProcessGetHRUnit();
            proc.Invoke();
            DataSet ds = proc.Result;
            DataTable dtt = ds.Tables[0];
            dtt.NewRow();
            dtt.Rows.Add(0, "--������--", 0, "--������--");
            dtt.AcceptChanges();

            cmbModalityID.DataSource = dtt;
            cmbModalityID.DisplayMember = "UNIT_NAME";//ds.Tables[1].Columns[1].ToString();//Columns[1].ToString();
            cmbModalityID.ValueMember = "UNIT_ID";//ds.Tables[0].Columns[1].ToString();
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
                int j = 1;
                try { i = Convert.ToInt32(cmbHeaderReport.SelectedValue.ToString()); }
                catch { }
                try { j = Convert.ToInt32(cmbModalityID.SelectedValue.ToString());   }
                catch {}

                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);

                LookUpSelect lk = new LookUpSelect();

                DataSet ds = lk.SelectSummaryDFRad(dtStart, dtEnd, i,j);

                frmReportViewer RForm = new frmReportViewer(reportprovider.rptSummaryDFAimc(ds.Tables[0]));
                dlg.Close();
                RForm.ShowDialog();

            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}