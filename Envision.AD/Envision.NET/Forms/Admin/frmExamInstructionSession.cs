using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraEditors.Controls;
using Envision.Common.Common;
using Miracle.Util;
using Envision.BusinessLogic.ProcessCreate;
using Envision.Common;

namespace Envision.NET.Forms.Admin
{
    public partial class frmExamInstructionSession : MasterForm
    {
        private GBLEnvVariable env = new GBLEnvVariable();
        private int ins_id;
        public frmExamInstructionSession()
        {
            InitializeComponent();
        }

        private void frmExamInstructionSession_Load(object sender, EventArgs e)
        {
            initSession();
            initExam();
            this.CloseWaitDialog();
        }
        private void initSession()
        {
            ProcessGetRISClinicsession get = new ProcessGetRISClinicsession();
            get.Invoke();
            DataTable dt = get.Result.Tables[0];

            cmbSession.Properties.Items.Clear();
            ComboBoxItemCollection colls = cmbSession.Properties.Items;
            colls.BeginUpdate();
            try
            {
                foreach (DataRow dr in dt.Rows)
                    colls.Add(new Filter_ClinicSession(Convert.ToInt32(dr["SESSION_ID"]), dr["SESSION_NAME"].ToString()));
            }
            finally
            {
                colls.EndUpdate();
            }
            cmbSession.SelectedIndex = 0;
        }
        private void initExam()
        {
            ProcessGetRISExam prc = new ProcessGetRISExam();
            prc.Invoke();

            grdExam.DataSource = prc.Result.Tables[0];
            for (int i = 0; i < viewExam.Columns.Count; i++)
                viewExam.Columns[i].Visible = false;

            viewExam.Columns["EXAM_UID"].Caption = "Code";
            viewExam.Columns["EXAM_UID"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["EXAM_UID"].OptionsColumn.AllowEdit = false;
            viewExam.Columns["EXAM_UID"].Visible = true;

            viewExam.Columns["EXAM_NAME"].Caption = "Name";
            viewExam.Columns["EXAM_NAME"].OptionsColumn.ReadOnly = true;
            viewExam.Columns["EXAM_NAME"].OptionsColumn.AllowEdit = false;
            viewExam.Columns["EXAM_NAME"].Visible = true;

        }
        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingData();
        }
        private void bindingData()
        {
            if (viewExam.FocusedRowHandle >= 0)
            {
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                Filter_ClinicSession filterMode = cmbSession.SelectedItem as Filter_ClinicSession;
                if (filterMode != null)
                {
                    this.ins_id = 0;
                    ProcessGetRISExamInstructionClinicSession prc = new ProcessGetRISExamInstructionClinicSession(Convert.ToInt32( dr["EXAM_ID"]),filterMode.id());
                    prc.Invoke();
                    DataSet ds = prc.Result;
                    if (Utilities.IsHaveData(ds))
                    {
                        this.ins_id = Convert.ToInt32(ds.Tables[0].Rows[0]["INS_ID"]);
                        memAdult.Text = ds.Tables[0].Rows[0]["INS_TEXT"].ToString();
                        memKid.Text = ds.Tables[0].Rows[0]["INS_TEXT_KID"].ToString();
                    }
                    else
                    {
                        this.ins_id = 0;
                        memAdult.Text = "";
                        memKid.Text = "";
                    }
                }
            }
        }
        private void viewExam_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bindingData();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (viewExam.FocusedRowHandle >= 0)
            {
                DataRow dr = viewExam.GetDataRow(viewExam.FocusedRowHandle);
                Filter_ClinicSession filterMode = cmbSession.SelectedItem as Filter_ClinicSession;
                if (filterMode != null)
                {
                    ProcessAddRISExaminstructionsClinicSession add = new ProcessAddRISExaminstructionsClinicSession();
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.CREATED_BY = env.UserID;
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.INS_TEXT = memAdult.Text;
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.INS_TEXT_KID = memKid.Text;
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.INS_UID = filterMode.ToString();
                    add.RIS_EXAMINSTRUCTIONCLINICSESSION.SESSION_ID = filterMode.id();
                    add.Invoke();
                }
            }
        }
    }
}
