using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;


namespace Envision.NET.Forms.Academic
{
    public partial class frmAcadermicPromote : Envision.NET.Forms.Main.MasterForm
    {
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        List<string> listYear = new List<string>();
        List<string> listYearSelect = new List<string>();
        List<string> listClass = new List<string>();
        DataTable dttTempLeft = new DataTable();
        DataTable dttTempRight = new DataTable();
        public frmAcadermicPromote()
        {
            InitializeComponent();
        }

        private void frmAcadermicPromote_Load(object sender, EventArgs e)
        {
            InitializecmbYear();
            InitializeData();
            InitializeGrid();
            base.CloseWaitDialog();
        }
        private void InitializecmbYear()
        {
            listYear.Clear();
            cmbYear.Properties.Items.Clear();
            ProcessGetACYear _year = new ProcessGetACYear();
            _year.SelectByDatenow();
            DataTable dtYear = _year.ResultSet.Tables[0].Copy();
            foreach (DataRow dr in dtYear.Rows)
            {
                listYear.Add(dr["YEAR_ID"].ToString());
                cmbYear.Properties.Items.Add(dr["YEAR_UID"].ToString());
            }
            cmbYear.SelectedIndex = 0;

            listClass.Clear();
            cmbClass.Properties.Items.Clear();
            ProcessGetACClass _class = new ProcessGetACClass();
            _class.Invoke();
            DataTable dtclass = _class.ResultSet.Tables[0].Copy();
            foreach (DataRow dr in dtclass.Rows)
            {
                listClass.Add(dr["CLASS_ID"].ToString());
                cmbClass.Properties.Items.Add(dr["CLASS_LABEL"].ToString());
            }
            cmbClass.SelectedIndex = 0;
        }
        private void InitializeGrid()
        {
            for (int i = 0; i < gvEnroll.Columns.Count; i++)
                gvEnroll.Columns[i].Visible = false;

            gvEnroll.Columns["ENROLL_UID"].Caption = "Enrollment UID";
            gvEnroll.Columns["CLASS_LABEL"].Caption = "Class";
            gvEnroll.Columns["RESIDENT_NAME"].Caption = "Resident name";
            gvEnroll.Columns["IS_SELECT"].Caption = ".";

            gvEnroll.Columns["IS_SELECT"].Width = 25;
            gvEnroll.Columns["IS_SELECT"].MinWidth = 25;
            gvEnroll.Columns["IS_SELECT"].MaxWidth = 25;

            gvEnroll.Columns["IS_SELECT"].OptionsColumn.AllowEdit = true;
            gvEnroll.Columns["ENROLL_UID"].OptionsColumn.AllowEdit = false;
            gvEnroll.Columns["CLASS_LABEL"].OptionsColumn.AllowEdit = false;
            gvEnroll.Columns["RESIDENT_NAME"].OptionsColumn.AllowEdit = false;

            gvEnroll.Columns["IS_SELECT"].VisibleIndex = 0;
            gvEnroll.Columns["ENROLL_UID"].VisibleIndex = 1;
            gvEnroll.Columns["CLASS_LABEL"].VisibleIndex = 2;
            gvEnroll.Columns["RESIDENT_NAME"].VisibleIndex = 3;

            gvEnroll.Columns["IS_SELECT"].Visible = true;
            gvEnroll.Columns["ENROLL_UID"].Visible = true;
            gvEnroll.Columns["CLASS_LABEL"].Visible = true;
            gvEnroll.Columns["RESIDENT_NAME"].Visible = true;

            gvEnroll.Columns["IS_VISIBLE"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[IS_VISIBLE] = 'Y'");

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
               chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueGrayed = null;
            chk.ValueUnchecked = "N";
            chk.Caption = "";
            chk.CheckStateChanged += new EventHandler(chkLeft_CheckStateChanged);
            gvEnroll.Columns["IS_SELECT"].ColumnEdit = chk;

            for (int i = 0; i < gvEnrollSelect.Columns.Count; i++)
                gvEnrollSelect.Columns[i].Visible = false;

            gvEnrollSelect.Columns["ENROLL_UID"].Caption = "Enrollment UID";
            gvEnrollSelect.Columns["CLASS_LABEL"].Caption = "Class";
            gvEnrollSelect.Columns["RESIDENT_NAME"].Caption = "Resident name";
            gvEnrollSelect.Columns["IS_SELECT"].Caption = ".";

            gvEnrollSelect.Columns["IS_SELECT"].Width = 25;
            gvEnrollSelect.Columns["IS_SELECT"].MinWidth = 25;
            gvEnrollSelect.Columns["IS_SELECT"].MaxWidth = 25;

            gvEnrollSelect.Columns["IS_SELECT"].OptionsColumn.AllowEdit = true;
            gvEnrollSelect.Columns["ENROLL_UID"].OptionsColumn.AllowEdit = false;
            gvEnrollSelect.Columns["CLASS_LABEL"].OptionsColumn.AllowEdit = false;
            gvEnrollSelect.Columns["RESIDENT_NAME"].OptionsColumn.AllowEdit = false;

            gvEnrollSelect.Columns["IS_SELECT"].VisibleIndex = 0;
            gvEnrollSelect.Columns["ENROLL_UID"].VisibleIndex = 1;
            gvEnrollSelect.Columns["CLASS_LABEL"].VisibleIndex = 2;
            gvEnrollSelect.Columns["RESIDENT_NAME"].VisibleIndex = 3;

            gvEnrollSelect.Columns["IS_SELECT"].Visible = true;
            gvEnrollSelect.Columns["ENROLL_UID"].Visible = true;
            gvEnrollSelect.Columns["CLASS_LABEL"].Visible = true;
            gvEnrollSelect.Columns["RESIDENT_NAME"].Visible = true;

            gvEnrollSelect.Columns["IS_VISIBLE"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[IS_VISIBLE] = 'Y'");

            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
               chkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chkSelect.ValueChecked = "Y";
            chkSelect.ValueGrayed = null;
            chkSelect.ValueUnchecked = "N";
            chkSelect.Caption = "";
            chkSelect.CheckStateChanged += new EventHandler(chkRight_CheckStateChanged);
            gvEnrollSelect.Columns["IS_SELECT"].ColumnEdit = chkSelect;
        }
        private void chkRight_CheckStateChanged(object sender, EventArgs e)
        {
            if (gvEnroll.FocusedRowHandle > -1)
            {
                string ENROLL_ID = gvEnrollSelect.GetDataRow(gvEnrollSelect.FocusedRowHandle)["ENROLL_ID"].ToString();
                //string msgType = gvEnroll.GetDataRow(gvEnroll.FocusedRowHandle)["MSG TYPE"].ToString();
                DataRow[] rows = dttTempRight.Select("[ENROLL_ID]='" + ENROLL_ID + "'");

                foreach (DataRow row in rows)
                {
                    if (row["IS_SELECT"] == "N")
                        row["IS_SELECT"] = "Y";
                    else if (row["IS_SELECT"] == "Y")
                        row["IS_SELECT"] = "N";
                }
            }
        }
        private void chkLeft_CheckStateChanged(object sender, EventArgs e)
        {
            if (gvEnroll.FocusedRowHandle > -1)
            {
                string ENROLL_ID = gvEnroll.GetDataRow(gvEnroll.FocusedRowHandle)["ENROLL_ID"].ToString();
                //string msgType = gvEnroll.GetDataRow(gvEnroll.FocusedRowHandle)["MSG TYPE"].ToString();
                DataRow[] rows = dttTempLeft.Select("[ENROLL_ID]='" + ENROLL_ID + "'");

                foreach (DataRow row in rows)
                {
                    if (row["IS_SELECT"] == "N")
                        row["IS_SELECT"] = "Y";
                    else if (row["IS_SELECT"] == "Y")
                        row["IS_SELECT"] = "N";
                }
            }
        }
        private void InitializeData()
        {
            ProcessGetACEnrollment _enroll = new ProcessGetACEnrollment();
            _enroll.SelectEnrollmentByYear(Convert.ToInt32(listYear[cmbYear.SelectedIndex]));
            dttTempLeft = _enroll.ResultSet.Tables[0].Copy();
            gcLeft.DataSource = dttTempLeft;

            listYearSelect.Clear();
            cmbYearPromote.Properties.Items.Clear();
            DataTable dtenroll = _enroll.ResultSet.Tables[1].Copy();
            foreach (DataRow dr in dtenroll.Rows)
            {
                listYearSelect.Add(dr["YEAR_ID"].ToString());
                cmbYearPromote.Properties.Items.Add(dr["YEAR_UID"].ToString());
            }
            cmbYearPromote.SelectedIndex = 0;

            dttTempRight = dttTempLeft.Clone();
            gcRight.DataSource = dttTempRight;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dttTempLeft.Rows)
            {
                if (dr["IS_SELECT"].ToString() == "Y" && dr["IS_VISIBLE"].ToString() == "Y")
                {
                    dttTempRight.NewRow();
                    dttTempRight.Rows.Add(dr.ItemArray);
                    dr["IS_VISIBLE"] = "N";
                }
            }
            
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dttTempRight.Rows)
            {
                if (dr["IS_SELECT"].ToString() == "Y" && dr["IS_VISIBLE"].ToString() == "Y")
                {
                    DataRow[] drLeft = dttTempLeft.Select("[ENROLL_ID]='" + dr["ENROLL_ID"].ToString() + "'");
                    drLeft[0]["IS_VISIBLE"] = "Y";
                    dr["IS_VISIBLE"] = "N";
                }
            }
            DataRow[] drRight = dttTempRight.Select("[IS_VISIBLE]='N'");
            for (int i = 0; i < drRight.Length; i++)
            {
                dttTempRight.Rows.Remove(drRight[i]);
            }
        }

        private void btnAllRight_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dttTempLeft.Rows)
            {
                dr["IS_SELECT"] = "Y";
                dttTempRight.NewRow();
                dttTempRight.Rows.Add(dr.ItemArray);
                dr["IS_VISIBLE"] = "N";
            }
        }

        private void btnAllLeft_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dttTempRight.Rows)
            {
                dr["IS_SELECT"] = "Y";
                DataRow[] drLeft = dttTempLeft.Select("[ENROLL_ID]='" + dr["ENROLL_ID"].ToString() + "'");
                drLeft[0]["IS_VISIBLE"] = "Y";
                dr["IS_VISIBLE"] = "N";

            }
            DataRow[] drRight = dttTempRight.Select("[IS_VISIBLE]='N'");
            for (int i = 0; i < drRight.Length; i++)
            {
                dttTempRight.Rows.Remove(drRight[i]);
            }
        }

        private void btnPromote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string s = "";
            s = msg.ShowAlert("UID4050", env.CurrentLanguageID);
            if (s == "2")
            {
                ProcessAddACEnrollment prc;
                if (dttTempRight.Rows.Count > 0)
                {
                    foreach (DataRow dr in dttTempRight.Rows)
                    {
                        prc = new ProcessAddACEnrollment();
                        prc.AC_ENROLLMENT.YEAR_ID = Convert.ToInt32(listYearSelect[cmbYearPromote.SelectedIndex]);
                        prc.AC_ENROLLMENT.CLASS_ID = Convert.ToInt32(listClass[cmbClass.SelectedIndex]);
                        prc.AC_ENROLLMENT.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                        prc.AC_ENROLLMENT.ENROLL_UID = "AUTO";
                        prc.AC_ENROLLMENT.IS_ACTIVE = "Y";
                        prc.AC_ENROLLMENT.ORG_ID = 1;
                        prc.AC_ENROLLMENT.CREATED_BY = new GBLEnvVariable().UserID;
                        prc.AC_ENROLLMENT.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                        prc.Invoke();
                    }
                }
                InitializecmbYear();
                InitializeData();
                InitializeGrid();
            }
        }
    }
}
