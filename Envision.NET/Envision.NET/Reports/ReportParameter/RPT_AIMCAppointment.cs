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
    public partial class RPT_AIMCAppointment : Envision.NET.Forms.Main.MasterForm  // Form
    {
        public RPT_AIMCAppointment()
        {
            InitializeComponent();
        }

        private void RPT_AIMCAppointment_Load(object sender, EventArgs e)
        {
            getModality();
            getSession();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}