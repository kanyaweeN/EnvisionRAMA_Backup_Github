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

namespace Envision.NET.Reports.ReportParameter
{
    public partial class ParamExamResult : Envision.NET.Forms.Main.MasterForm
    {
        public ParamExamResult()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReportMangager reportprovider = new ReportMangager();
                reportprovider.WhereClose = " WHERE accession_no ='" + textBox1.Text.ToString().Trim() + "'";
                Envision.NET.Reports.ReportViewer.frmReportViewer RForm = new Envision.NET.Reports.ReportViewer.frmReportViewer(reportprovider.rptExamResult);
                RForm.ShowDialog();
                //DisplayForm(formContainer1, RForm, "Exam Result");

            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void ParamExamResult_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }

    }
}