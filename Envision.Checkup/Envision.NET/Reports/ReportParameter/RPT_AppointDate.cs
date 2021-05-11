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
    public partial class RPT_AppointDate : Form
    {
        DBUtility dbu = new DBUtility();
        UUL.ControlFrame.Controls.TabControl formContainer1;
        public RPT_AppointDate(UUL.ControlFrame.Controls.TabControl formContainer)
        {
            InitializeComponent();
            formContainer1 = formContainer;
            getModality();
            getSession();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessGetFINPayment dd = new ProcessGetFINPayment();
            dd.FINPayment.TO_DATE = DateTime.Now;
            dd.FINPayment.PAY_ID = 0;
            dd.FINPayment.INV_ID = 0;
            try
            {
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


                //dtStart = dtFromdate.Value;
                //dtStart = Convert.ToDateTime(dtFromdate.Value.ToString("yyyy-MM-dd") + " 00:00:01.000");
                //string a = dtFromdate.Value.ToString("yyyy-MM-dd");

                //dtEnd = Convert.ToDateTime(dtToDate.Value.ToString("yyyy-MM-dd") + " 23:59:59.000");             

                RIS.Reports.ReportViewer.frmReportViewer RForm = new RIS.Reports.ReportViewer.frmReportViewer(reportprovider.rptAppoint(dtStart, dtEnd, env.UserID, i, Session), formContainer1);
                //RForm.ShowDialog();
                //RForm.Size = new Size(600, 800);
               // dbu.CloseFrom(formContainer1, this);
                DisplayForm(formContainer1, RForm, "RPT_AppointDate");

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