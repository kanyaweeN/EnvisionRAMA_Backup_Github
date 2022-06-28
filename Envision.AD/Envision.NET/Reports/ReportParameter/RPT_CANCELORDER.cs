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

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_CANCELORDER : Envision.NET.Forms.Main.MasterForm
    {
        public RPT_CANCELORDER()
        {
            InitializeComponent();
        }

        private void RPT_CANCELORDER_Load(object sender, EventArgs e)
        {
            DataTable dtExam = new DataTable();
            cmbSelectCase.SelectedIndex = 0;
            rdoMode.SelectedIndex = 0;
            lblMode.Text = "Exam Type :";
            ProcessGetRISExamType get = new ProcessGetRISExamType();
            get.Invoke();
            dtExam = get.Result.Tables[0];
            dtExam.NewRow();
            dtExam.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--");
            dtExam.AcceptChanges();
            cmbMode.Items.Clear();
            cmbMode.DataSource = dtExam;
            cmbMode.DisplayMember = "EXAM_TYPE_TEXT";
            cmbMode.ValueMember = "EXAM_TYPE_ID";
            cmbMode.SelectedValue = 0;
            base.CloseWaitDialog();
            
        }

        private void rdoMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtExam = new DataTable();
            DataTable dtModality = new DataTable();
            if (rdoMode.SelectedIndex == 0)//Exam type
            {
                lblMode.Text = "Exam Type :";
                ProcessGetRISExamType get = new ProcessGetRISExamType();
                get.Invoke();
                dtExam = get.Result.Tables[0];
                dtExam.NewRow();
                dtExam.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--");
                dtExam.AcceptChanges();
                cmbMode.DataSource = null;
                cmbMode.Items.Clear();
                cmbMode.DataSource = dtExam;
                cmbMode.DisplayMember = "EXAM_TYPE_TEXT";
                cmbMode.ValueMember = "EXAM_TYPE_ID";
                
            }
            else //Modality
            {
                lblMode.Text = "Modality Name :";
                ProcessGetRISModality get = new ProcessGetRISModality();
                get.Invoke();
                dtModality = get.Result.Tables[0];
                dtModality.NewRow();
                dtModality.Rows.Add(0, "--ทั้งหมด--", "--ทั้งหมด--");
                dtModality.AcceptChanges();
                cmbMode.DataSource = null;
                cmbMode.Items.Clear();
                cmbMode.DataSource = dtModality;
                cmbMode.DisplayMember = "MODALITY_NAME";
                cmbMode.ValueMember = "MODALITY_ID";
            }
            cmbMode.SelectedValue = 0;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //try
            //{
            //DateTime dtFrom = new DateTime(dtFromdate.Value.Year,dtFromdate.Value.Month,dtFromdate.Value.Day,0,0,0);
            //DateTime dtTo = new DateTime(dtToDate.Value.Year,dtToDate.Value.Month,dtToDate.Value.Day,23,59,59);


            //ProcessGetRptCancelOrder get = new ProcessGetRptCancelOrder();
            //get.ReportParameters.SELECT_MODE_INT = cmbSelectCase.SelectedIndex;
            //if (rdoMode.SelectedIndex == 0)
            //    get.ReportParameters.EXAM_TYPE = Convert.ToInt32(cmbMode.SelectedValue);
            //else
            //    get.ReportParameters.ModalityId = Convert.ToInt32(cmbMode.SelectedValue);
            //get.ReportParameters.FromDate = dtFrom;
            //get.ReportParameters.ToDate = dtTo;
            //DataTable dt = new DataTable();
            //if (cmbSelectCase.SelectedIndex == 0)
            //{
            //    get.Invoke();
            //    dt = get.Result.Tables[0];
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        dr["MODE"] = rdoMode.SelectedIndex;
            //    }
            //    ReportMangager reportprovider = new ReportMangager();

            //    RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptCancelOrderRawData(dt));
            //    //RForm.ShowDialog();
            //    //RForm.Size = new Size(600, 800);
            //    // dbu.CloseFrom(formContainer1, this);
            //    DisplayForm(formContainer1, RForm, "RPT_AppointDate");
            //}
            //else
            //{
            //    get.InvokeSum();
            //    dt = get.Result.Tables[0];
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        dr["MODE"] = rdoMode.SelectedIndex;
            //    }
            //    ReportMangager reportprovider = new ReportMangager();

            //    RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptCancelOrderSummaryData(dt));
            //    //RForm.ShowDialog();
            //    //RForm.Size = new Size(600, 800);
            //    // dbu.CloseFrom(formContainer1, this);
            //    DisplayForm(formContainer1, RForm, "RPT_AppointDate");
            //}

            
            //}
            //catch (Exception ex)
            //{
                
            //}
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}