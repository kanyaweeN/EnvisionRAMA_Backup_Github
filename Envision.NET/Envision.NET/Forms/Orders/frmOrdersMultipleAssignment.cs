using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Envision.BusinessLogic;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Envision.NET.Forms.Orders
{
    public partial class frmOrdersMultipleAssignment : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataTable tbRadList = new DataTable();
        DataTable tbNurseList = new DataTable();
        DataTable tbTechList = new DataTable();

        public frmOrdersMultipleAssignment()
        {
            InitializeComponent();
        }
        private void frmOrdersMultipleAssignment_Load(object sender, EventArgs e)
        {
            DataTable tbTmp = new DataTable();

            tbTmp.Columns.Add(new DataColumn("LEVEL"));
            tbTmp.Columns.Add(new DataColumn("EMP_ID"));
            tbTmp.Columns.Add(new DataColumn("USER_NAME"));
            tbTmp.Columns.Add(new DataColumn("NAME"));
            tbTmp.Columns.Add(new DataColumn("JOBTITLE"));
            tbTmp.AcceptChanges();

            tbRadList = tbTmp.Clone();
            tbNurseList = tbTmp.Clone();
            tbTechList = tbTmp.Clone();

            ReloadMultipleAssignment();
        }

        private void LoadMultipleAssignmentData()
        {
            
        }
        private void LoadMultipleAssignmentFilter()
        {

        }
        private void LoadMultipleAssignmentGrid()
        {
            #region Radiologist Grid
            gcRadiologist.DataSource = tbRadList;

            foreach (GridColumn col in gvRadiologist.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.ReadOnly = true;
            }

            gvRadiologist.Columns["LEVEL"].VisibleIndex = 1;
            gvRadiologist.Columns["LEVEL"].Caption = "Level";

            gvRadiologist.Columns["USER_NAME"].VisibleIndex = 2;
            gvRadiologist.Columns["USER_NAME"].Caption = "Radiologist Code";

            gvRadiologist.Columns["NAME"].VisibleIndex = 3;
            gvRadiologist.Columns["NAME"].Caption = "Radiologist Name";

            gvRadiologist.Columns["JOBTITLE"].VisibleIndex = 4;
            gvRadiologist.Columns["JOBTITLE"].Caption = "Jobtitle";
            
            #endregion

            #region Nurse Grid
            gcNurse.DataSource = tbNurseList;

            foreach (GridColumn col in gvNurse.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.ReadOnly = true;
            }

            gvNurse.Columns["LEVEL"].VisibleIndex = 1;
            gvNurse.Columns["LEVEL"].Caption = "Level";

            gvNurse.Columns["USER_NAME"].VisibleIndex = 2;
            gvNurse.Columns["USER_NAME"].Caption = "Nurse Code";

            gvNurse.Columns["NAME"].VisibleIndex = 3;
            gvNurse.Columns["NAME"].Caption = "Nurse Name";

            gvNurse.Columns["JOBTITLE"].VisibleIndex = 4;
            gvNurse.Columns["JOBTITLE"].Caption = "Jobtitle";

            #endregion

            #region Technologist Grid
            gcTechnologist.DataSource = tbTechList;

            foreach (GridColumn col in gvTechnologist.Columns)
            {
                col.Visible = false;
                col.OptionsColumn.ReadOnly = true;
            }

            gvTechnologist.Columns["LEVEL"].VisibleIndex = 1;
            gvTechnologist.Columns["LEVEL"].Caption = "Level";

            gvTechnologist.Columns["USER_NAME"].VisibleIndex = 2;
            gvTechnologist.Columns["USER_NAME"].Caption = "Technologist Code";

            gvTechnologist.Columns["NAME"].VisibleIndex = 3;
            gvTechnologist.Columns["NAME"].Caption = "Technologist Name";

            gvTechnologist.Columns["JOBTITLE"].VisibleIndex = 4;
            gvTechnologist.Columns["JOBTITLE"].Caption = "Jobtitle";

            #endregion
        }
        private void ReloadMultipleAssignment()
        {
            LoadMultipleAssignmentData();
            LoadMultipleAssignmentFilter();
            LoadMultipleAssignmentGrid();
        }

        private void btnRadiologistAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lkp = new LookUpSelect();
            DataSet dsRadList = lkp.SelectMultipleAssignmentRad();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(RadListSelected);
            lv.AddColumn("EMP_ID", "Radiologist ID", false, true);
            lv.AddColumn("USER_NAME", "Radiologist Code", true, true);
            lv.AddColumn("NAME", "Radiologist Name", true, true);
            lv.AddColumn("JOBTITLE", "Jobtitle", true, true);
            lv.Text = "Radiologist List";

            lv.Data = dsRadList.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnRadiologistDelete_Click(object sender, EventArgs e)
        {
            if (gvRadiologist.FocusedRowHandle < 0) return;

            DataRow[] rows = tbRadList.Select("", "LEVEL desc");
            if (rows.Length == 0) return;

            tbRadList.Rows.Remove(rows[0]);
            tbRadList.AcceptChanges();

            gcRadiologist.DataSource = tbRadList;
        }
        private void RadListSelected(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            int level = 1;
            DataRow[] rows = tbRadList.Select("", "LEVEL desc");
            if (rows.Length != 0)
            {
                level = Convert.ToInt32(rows[0]["LEVEL"]);
                level += 1;
            }

            DataRow row = tbRadList.NewRow();
            row["LEVEL"] = level;
            row["EMP_ID"] = retValue[0];
            row["USER_NAME"] = retValue[1];
            row["NAME"] = retValue[2];
            row["JOBTITLE"] = retValue[3];
            tbRadList.Rows.Add(row.ItemArray);

            tbRadList.AcceptChanges();
            gcRadiologist.DataSource = tbRadList;
        }

        private void btnNurseAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lkp = new LookUpSelect();
            DataSet dsNurseList = lkp.SelectMultipleAssignmentNurse();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(NurseListSelected);
            lv.AddColumn("EMP_ID", "Nurse ID", false, true);
            lv.AddColumn("USER_NAME", "Nurse Code", true, true);
            lv.AddColumn("NAME", "Nurse Name", true, true);
            lv.AddColumn("JOBTITLE", "Jobtitle", true, true);
            lv.Text = "Nurse List";

            lv.Data = dsNurseList.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnNurseDelete_Click(object sender, EventArgs e)
        {
            if (gvNurse.FocusedRowHandle < 0) return;

            DataRow[] rows = tbNurseList.Select("", "LEVEL desc");
            if (rows.Length == 0) return;

            tbNurseList.Rows.Remove(rows[0]);
            tbNurseList.AcceptChanges();

            gcNurse.DataSource = tbNurseList;
        }
        private void NurseListSelected(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            
            int level = 1;
            DataRow[] rows = tbNurseList.Select("", "LEVEL desc");
            if (rows.Length != 0)
            {
                level = Convert.ToInt32(rows[0]["LEVEL"]);
                level += 1;
            }

            DataRow row = tbNurseList.NewRow();
            row["LEVEL"] = level;
            row["EMP_ID"] = retValue[0];
            row["USER_NAME"] = retValue[1];
            row["NAME"] = retValue[2];
            row["JOBTITLE"] = retValue[3];
            tbNurseList.Rows.Add(row.ItemArray);

            tbNurseList.AcceptChanges();
            gcNurse.DataSource = tbNurseList;
        }

        private void btnTechnologistAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lkp = new LookUpSelect();
            DataSet dsTechList = lkp.SelectMultipleAssignmentTech();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(TechListSelected);
            lv.AddColumn("EMP_ID", "Technologist ID", false, true);
            lv.AddColumn("USER_NAME", "Technologist Code", true, true);
            lv.AddColumn("NAME", "Technologist Name", true, true);
            lv.AddColumn("JOBTITLE", "Jobtitle", true, true);
            lv.Text = "Technologist List";

            lv.Data = dsTechList.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnTechnologistDelete_Click(object sender, EventArgs e)
        {
            if (gvTechnologist.FocusedRowHandle < 0) return;

            DataRow[] rows = tbTechList.Select("", "LEVEL desc");
            if (rows.Length == 0) return;

            tbTechList.Rows.Remove(rows[0]);
            tbTechList.AcceptChanges();

            gcTechnologist.DataSource = tbTechList;
        }
        private void TechListSelected(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });

            int level = 1;
            DataRow[] rows = tbTechList.Select("", "LEVEL desc");
            if (rows.Length != 0)
            {
                level = Convert.ToInt32(rows[0]["LEVEL"]);
                level += 1;
            }

            DataRow row = tbTechList.NewRow();
            row["LEVEL"] = level;
            row["EMP_ID"] = retValue[0];
            row["USER_NAME"] = retValue[1];
            row["NAME"] = retValue[2];
            row["JOBTITLE"] = retValue[3];
            tbTechList.Rows.Add(row.ItemArray);

            tbTechList.AcceptChanges();
            gcTechnologist.DataSource = tbTechList;
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}