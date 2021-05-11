using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.Common.UtilityClass;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Plugin.ReportManager;

namespace RIS.Reports.ReportParameter
{
    public partial class RPT_ModalityExam : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;
        public RPT_ModalityExam(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
            getModality();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                
                int i = 0;
                try
                {
                    i = Convert.ToInt32(cmbModalityID.SelectedValue.ToString());
                }
                catch { }

                //RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptOrder, formContainer1);
                //dbu.CloseFrom(formContainer1, this);
                //DisplayForm(formContainer1, RForm, "Order");


                RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptModalityExam(i, env.UserID), formContainer1);
                dbu.CloseFrom(formContainer1, this);
                DisplayForm(formContainer1, RForm, "Order");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dbu.CloseFrom(formContainer1, this);
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
        public void getModality()
        {
            ProcessGetRISModalityexam proc = new ProcessGetRISModalityexam();
            DataSet ds = proc.rptModalityexam_Para();
            cmbModalityID.DataSource = ds.Tables[0];
            cmbModalityID.DisplayMember = "MODALITY_NAME";//ds.Tables[1].Columns[1].ToString();//Columns[1].ToString();
            cmbModalityID.ValueMember = "MODALITY_ID";//ds.Tables[0].Columns[1].ToString();
           //     = "MODALITY_NAME";
           // cmbModalityID.SelectedValue = "MODALITY_ID";
        }

        private void RPT_ModalityExam_Load(object sender, EventArgs e)
        {

        }
    }
}