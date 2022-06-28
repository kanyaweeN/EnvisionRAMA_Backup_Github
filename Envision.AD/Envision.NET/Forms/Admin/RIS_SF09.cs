using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid.Views.BandedGrid;

using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.Admin
{
    public partial class RIS_SF09 : MasterForm
    {
        DataTable dtExamType = new DataTable();
        DataRow drExamType;
        string modeSave = "";
        int rowSelected = 0;

        public RIS_SF09()
        {
            InitializeComponent();
        }
        private void RIS_SF09_Load(object sender, EventArgs e)
        {
            ReloadExamType();
            textControl_Enable(false);
            if (gridView1.RowCount > 0)
                gridView1_RowSelecting(0);
            base.CloseWaitDialog();
        }

        private void LoadDataExamType()
        {
            ProcessGetRISSF09 pGet = new ProcessGetRISSF09();
            pGet.Invoke();
            dtExamType = pGet.ResultSet.Tables[0];
        }
        private void LoadFilterExamType()
        { 
        }
        private void LoadGridExamtype()
        {
            gridControl1.DataSource = dtExamType;

            foreach (BandedGridColumn col in gridView1.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.AllowEdit = false;
            }

            gridView1.Columns["EXAM_TYPE_UID"].ColVIndex = 1;
            gridView1.Columns["EXAM_TYPE_UID"].Caption = "Exam Code";

            gridView1.Columns["EXAM_TYPE_TEXT"].ColVIndex = 2;
            gridView1.Columns["EXAM_TYPE_TEXT"].Caption = "Exam Name";

            if (gridView1.RowCount < 100)
                gridView1.BestFitColumns();
        }
        private void ReloadExamType()
        {  
            LoadDataExamType();
            LoadFilterExamType();
            LoadGridExamtype();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                gridView1_RowSelecting(e.FocusedRowHandle);
            }
        }
        private void gridView1_RowSelecting(int rowfocus)
        {
            if (rowfocus > -1 && rowfocus < gridView1.RowCount)
            {
                textControl_Clearing();
                drExamType = gridView1.GetDataRow(rowfocus);
                textControl_Filling();
                textControl_Enable(false);

                gridView1.FocusedRowHandle = rowfocus;
            }
        }

        private void textControl_Filling()
        {
            txtExamCode.Text = drExamType["EXAM_TYPE_UID"].ToString();
            txtExamName.Text = drExamType["EXAM_TYPE_TEXT"].ToString();
            chkActive.CheckState = drExamType["IS_ACTIVE"].ToString().Trim() == "Y" ? CheckState.Checked : CheckState.Unchecked;
        }
        private void textControl_Clearing()
        {
            txtExamCode.Text = "";
            txtExamName.Text = "";
            chkActive.CheckState = CheckState.Unchecked;
        }
        private void textControl_Enable(bool flag)
        {
            txtExamCode.Enabled = flag;
            txtExamName.Enabled = flag;
            chkActive.Enabled = flag;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                textControl_Enable(true);
                textControl_Clearing();
                
                btnAdd.Text = "Save";
                btnAdd.Visible = true;
                btnEdit.Visible = false;
                btnDelete.Visible = false;

                btnCancel.Visible = true;
            }
            else
            {

                GBLEnvVariable patenv = new GBLEnvVariable();
                ProcessAddRISSF09 processpat = new ProcessAddRISSF09();
                RISSF09Data gblpat = new RISSF09Data();

                if (txtExamCode.Text == "")
                {
                    MessageBox.Show("Please Insert Exam Type Code !!");
                    return;
                }
                if (txtExamName.Text == "")
                {
                    MessageBox.Show("Please Insert Exam Type Text !!");
                    return;
                }
                gblpat.EXAM_TYPE_UID = txtExamCode.Text;
                gblpat.EXAM_TYPE_TEXT = txtExamName.Text;
                gblpat.IS_ACTIVE = chkActive.Checked == true ? "Y" : "N";

                gblpat.ORG_ID = patenv.OrgID;
                gblpat.CREATED_BY = patenv.UserID;


                processpat.RISSF09Data = gblpat;

                try
                {
                    processpat.Invoke();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }

                rowSelected = gridView1.FocusedRowHandle;
                ReloadExamType();
                gridView1_RowSelecting(gridView1.RowCount-1);
                
                btnAdd.Text = "Add";
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                btnCancel.Visible = false;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Edit")
            {
                textControl_Enable(true);

                btnEdit.Text = "Save";
                btnAdd.Visible = false;
                btnEdit.Visible = true;
                btnDelete.Visible = false;

                btnCancel.Visible = true;
            }
            else
            {
                GBLEnvVariable gblenv = new GBLEnvVariable();
                RISSF09Data gblpatient = new RISSF09Data();
                ProcessUpdateRISSF09 processpatstatus = new ProcessUpdateRISSF09();

                if (txtExamCode.Text == "")
                {
                    MessageBox.Show("Please Insert Exam Type Code !!");
                    return;
                }
                if (txtExamName.Text == "")
                {
                    MessageBox.Show("Please Insert Exam Type Text !!");
                    return;
                }
                gblpatient.EXAM_TYPE_ID = Convert.ToInt32(drExamType["EXAM_TYPE_ID"]);
                gblpatient.EXAM_TYPE_UID = txtExamCode.Text.ToString();
                gblpatient.EXAM_TYPE_TEXT = txtExamName.Text.ToString();
                gblpatient.IS_ACTIVE = chkActive.Checked == true ? "Y" : "N";

                gblpatient.ORG_ID = gblenv.OrgID;
                gblpatient.LASTMODIFIED_BY = gblenv.UserID;
                processpatstatus.RISSF09Data = gblpatient;

                try
                {
                    processpatstatus.Invoke();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    return;
                }

                rowSelected = gridView1.FocusedRowHandle;
                ReloadExamType();
                gridView1_RowSelecting(rowSelected);

                btnEdit.Text = "Edit";
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;

                btnCancel.Visible = false;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                RISSF09Data risobj = new RISSF09Data();
                ProcessDeleteSF09 processobj = new ProcessDeleteSF09();

                risobj.EXAM_TYPE_ID = Convert.ToInt32(drExamType["EXAM_TYPE_ID"]);
                processobj.RISSF09Data = risobj;

                if (MessageBox.Show("Delete Data " + drExamType["EXAM_TYPE_UID"].ToString() + ". ", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                try
                {
                    processobj.Invoke();
                }
                catch (Exception ex) 
                {
                    throw ex;
                }

                rowSelected = gridView1.FocusedRowHandle;
                ReloadExamType();
                gridView1_RowSelecting(rowSelected);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            rowSelected = gridView1.FocusedRowHandle;
            ReloadExamType();
            gridView1_RowSelecting(rowSelected);

            btnAdd.Text = "Add";
            btnEdit.Text = "Edit";
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;

            btnCancel.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
