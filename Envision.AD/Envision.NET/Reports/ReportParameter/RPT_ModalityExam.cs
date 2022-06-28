using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Reports.ReportViewer;
using Envision.Plugin.ReportManager;

namespace Envision.NET.Reports.ReportParameter
{
    public partial class RPT_ModalityExam : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_ModalityExam()
        {
            InitializeComponent();
            getModality();
            base.CloseWaitDialog();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);

                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();

                int i = 0;
                try
                {
                    i = Convert.ToInt32(cmbModalityID.SelectedValue.ToString());
                }
                catch { }
                frmReportViewer RForm = new frmReportViewer(reportprovider.rptModalityExam(i, env.UserID));
                dlg.Close();
                RForm.ShowDialog();
                
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
            base.CloseWaitDialog();
        }

        private void RPT_ModalityExam_Load_1(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
        }
    }
}