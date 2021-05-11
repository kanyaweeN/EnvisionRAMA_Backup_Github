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
    public partial class RPT_AppointDate : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_AppointDate()
        {
            InitializeComponent();
            getModality();
            getSession();
            base.CloseWaitDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessGetFINPayment dd = new ProcessGetFINPayment();
            dd.FIN_PAYMENT.TO_DATE = DateTime.Now;
            dd.FIN_PAYMENT.PAY_ID = 0;
            dd.FIN_PAYMENT.INV_ID = 0;
            try
            {
                Size s = new Size(250, 50);
                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Please wait...", "Create Reporting", s);


                ReportMangager reportprovider = new ReportMangager();
                GBLEnvVariable env = new GBLEnvVariable();
                int i = 0;
                int Session = 0;
                try{i = Convert.ToInt32(cmbModalityID.SelectedValue.ToString());}
                catch{}
                try { Session = Convert.ToInt32(cmbSession.SelectedValue.ToString()); }
                catch { }
                DateTime dtStart = new DateTime(dtFromdate.Value.Year, dtFromdate.Value.Month, dtFromdate.Value.Day, 0, 0, 0);
                DateTime dtEnd = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, 23, 59, 59);
                frmReportViewer RForm =new frmReportViewer(reportprovider.rptAppoint(dtStart, dtEnd, env.UserID, i, Session));
                dlg.Close();
                RForm.ShowDialog();
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
        public void getSession()
        {
            LookUpSelect lk = new LookUpSelect();
            DataSet ds = lk.SelectSession();
            object[] obj = ds.Tables[0].Rows[0].ItemArray;

            
            DataSet dsSession = new DataSet();
            obj[0] = 0;
            obj[2] = "<< All >>";
            dsSession = ds.Clone();
            dsSession.Tables[0].Rows.Add(obj);
            dsSession.AcceptChanges();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dsSession.Tables[0].NewRow();
                dsSession.Tables[0].Rows.Add(dr.ItemArray);
                dsSession.AcceptChanges();
            }

            cmbSession.DataSource = dsSession.Tables[0];
            cmbSession.DisplayMember = "SESSION_NAME";
            cmbSession.ValueMember = "SESSION_ID";
        }
    }
}