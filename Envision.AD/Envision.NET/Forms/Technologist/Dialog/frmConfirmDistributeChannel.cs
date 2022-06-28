using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;

namespace Envision.NET.Forms.Technologist.Dialog
{
    public partial class frmConfirmDistributeChannel : Form
    {
        private DataTable dtData;
        public frmConfirmDistributeChannel()
        {
            InitializeComponent();
        }
        public frmConfirmDistributeChannel(DataRow[] drData)
        {
            InitializeComponent();
            initLookUp();

            dtData = new DataTable();

            foreach (DataColumn col in drData[0].Table.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            dtData.AcceptChanges();
            dtData.NewRow();

            for (int i = 0; i < drData.Length; i++)
            {
                dtData.Rows.Add(drData[i].ItemArray);
            }

            dtData.AcceptChanges();

            grdData.DataSource = dtData;
            SetGridData();
            lookupRadio.EditValue = "";

        }
        public frmConfirmDistributeChannel(DataRow drData)
        {
            InitializeComponent();
            initLookUp();

            dtData = new DataTable();

            foreach (DataColumn col in drData.Table.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            dtData.AcceptChanges();
            dtData.NewRow();
            dtData.Rows.Add(drData.ItemArray);

            dtData.AcceptChanges();

            grdData.DataSource = dtData;
            SetGridData();
            if(string.IsNullOrEmpty(dtData.Rows[0]["ASSIGNED_TO"].ToString()))
                lookupRadio.EditValue = "";
            else
            {
                lookupRadio.EditValue = Convert.ToInt32(dtData.Rows[0]["ASSIGNED_TO"]);
            }
            
        }
        private void SetGridData()
        {
            for (int i = 0; i < viewData.Columns.Count; i++)
            {
                viewData.Columns[i].Visible = false;
            }
            viewData.Columns["All"].Caption = " ";
            viewData.Columns["All"].Visible = false;

            viewData.Columns["HN"].Caption = "HN";
            viewData.Columns["HN"].Visible = true;

            viewData.Columns["Pat.Name"].Caption = "Patient Name";
            viewData.Columns["Pat.Name"].Visible = true;

            viewData.Columns["AGE"].Caption = " ";
            viewData.Columns["AGE"].Visible = false;

            //viewData.Columns["AGE1"].Caption = " ";
            //viewData.Columns["AGE1"].Visible = false;

            viewData.Columns["Exam Code"].Caption = "Exam Code";
            viewData.Columns["Exam Code"].Visible = true;

            viewData.Columns["Exam Name"].Caption = "Exam Name";
            viewData.Columns["Exam Name"].Visible = false;

            viewData.Columns["Accession No."].Caption = "Accession No.";
            viewData.Columns["Accession No."].Visible = true;

            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            viewData.Columns["Order Date Time"].Caption = "Order Time";
            viewData.Columns["Order Date Time"].ColumnEdit = txt;
            viewData.Columns["Order Date Time"].Visible = false;

            viewData.Columns["Priority"].Caption = " ";
            viewData.Columns["Priority"].Visible = false;

            viewData.Columns["Result Status"].Caption = " ";
            viewData.Columns["Result Status"].Visible = false;

            viewData.Columns["Assigned Rad."].Caption = "Radiologist";
            viewData.Columns["Assigned Rad."].Visible = false;

            viewData.Columns["Distributed By."].Caption = " ";
            viewData.Columns["Distributed By."].Visible = false;

            viewData.Columns["Distributed ON."].Caption = " ";
            viewData.Columns["Distributed ON."].Visible = false;

            viewData.Columns["OPD"].Caption = " ";
            viewData.Columns["OPD"].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)grdData.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(lookupRadio.Text))
                {
                    CheckExamResult _exresult = new CheckExamResult();
                    _exresult.SpType = 2;
                    _exresult.AccessionNo = dr["Accession No."].ToString(); ;
                    _exresult.AssignedTO = Convert.ToInt32(lookupRadio.EditValue);
                    _exresult.AssignedBy = new GBLEnvVariable().UserID;

                    ProcessCheckExam _procexam = new ProcessCheckExam();
                    _procexam.CheckExamResult = _exresult;
                    _procexam.Invoke();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    CheckExamResult _exresult = new CheckExamResult();
                    _exresult.SpType = 2;
                    _exresult.AccessionNo = dr["Accession No."].ToString(); ;
                    _exresult.AssignedTO = 0;
                    _exresult.AssignedBy = new GBLEnvVariable().UserID;

                    ProcessCheckExam _procexam = new ProcessCheckExam();
                    _procexam.CheckExamResult = _exresult;
                    _procexam.Invoke();
                    this.DialogResult = DialogResult.OK;
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteRad_Click(object sender, EventArgs e)
        {
            lookupRadio.EditValue = "";
        }

        private void initLookUp()
        {
            string qry2 = @"select 
                                        ([FNAME]+' '+ [LNAME]+' ('+EMP_UID+')') AS RADIOLOGIST,
                                        EMP_ID
                           from 
                                        HR_EMP 
                           where 
                                        JOB_TYPE='D' AND 
                                        IS_RADIOLOGIST='Y' AND 
                                        ISNULL(SUPPORT_USER,'N') <> 'Y' ";
            ProcessGetGBLLookup lkp3 = new ProcessGetGBLLookup(qry2);
            lkp3.Invoke();
            DataTable dt3 = lkp3.ResultSet.Tables[0];
            lookupRadio.Properties.DisplayMember = "RADIOLOGIST";
            lookupRadio.Properties.ValueMember = "EMP_ID";
            lookupRadio.Properties.DataSource = dt3;

            gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            gridLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            gridLookUpEdit1View.OptionsView.ShowIndicator = false;
            gridLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            gridLookUpEdit1View.Columns["EMP_ID"].Caption = "Emp Code";
            gridLookUpEdit1View.Columns["EMP_ID"].VisibleIndex = 1;
            gridLookUpEdit1View.Columns["EMP_ID"].Visible = false;

            //gridLookUpEdit1View.Columns["EMP_UID"].Caption = "Emp Code";
            //gridLookUpEdit1View.Columns["EMP_UID"].VisibleIndex = 0;
            //gridLookUpEdit1View.Columns["EMP_UID"].Visible = false;

            gridLookUpEdit1View.Columns["RADIOLOGIST"].Caption = "Radiologist";
            gridLookUpEdit1View.Columns["RADIOLOGIST"].VisibleIndex = 2;
            if (dt3.Rows.Count > 0)
                lookupRadio.EditValue = dt3.Rows[0]["EMP_ID"];
        }

        private void frmConfirmDistributeChannel_DoubleClick(object sender, EventArgs e)
        {
            return;
        }
    }
}