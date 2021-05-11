using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RIS.BusinessLogic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using RIS.Forms.Lookup;
using RIS.Common.Common;

namespace RIS.Forms.Admin
{
    public partial class frmModalitySetup : Form
    {
        DataTable dtModality = new DataTable();
        DataTable dtExam = new DataTable();
        DataTable dtClinic = new DataTable();

        DataTable dtExam_New = new DataTable();
        DataTable dtClinic_New = new DataTable();

        DataRow drModSelected;

        string modid = "";
        bool stopAllEvents = false;

        public frmModalitySetup(UUL.ControlFrame.Controls.TabControl tabcontrol)
        {
            InitializeComponent();
        }
        private void ModalitySetup_Load(object sender, EventArgs e)
        {
            #region make modlist dataset
            //dtModality = new DataTable();
            //dtModality.Columns.AddRange(new DataColumn[]
            //    {
            //        new DataColumn("MODALITY_NAME"),
            //        new DataColumn("MODALITY_ID"),
            //    }
            //    );
            //dtModality.Rows.Clear();
            #endregion
            #region button enable-disable
            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;

            btnClinicEdit.Visible = true;
            btnClinicSave.Visible = false;
            btnExamCancel.Visible = false;
            btnClinicAdd.Visible = false;
            #endregion
            ReloadModalityList();
        }

        private void LoadDataModalityList()
        {
            string name = "";

            ProcessGetRISModality processModality = new ProcessGetRISModality();
            processModality.Invoke();
            DataTable table = processModality.Result.Tables[0];

            table.Columns.Add("name");
            foreach (DataRow dr in table.Rows)
            {
                name = dr["MODALITY_NAME"].ToString() + "(" + dr["ROOM_UID"].ToString() + ")";
                dr["name"] = name;
            }
            dtModality = table.Copy();
        }
        private void LoadFilterModalityList()
        { 
            
        }
        private void LoadGridModalityList()
        {
            gridControl1.DataSource = dtModality.Copy();

            int k = 0;
            while (k < gridView1.Columns.Count)
            {
                gridView1.Columns[k].OptionsColumn.AllowEdit = false;
                gridView1.Columns[k].OptionsColumn.AllowFocus = false;
                gridView1.Columns[k].Visible = false;
                ++k;
            }

            gridView1.Columns["name"].Visible = true;
            gridView1.Columns["name"].Caption = "Modality Name";

            gridView1.BestFitColumns();
            gridView1.OptionsView.ColumnAutoWidth = true;
        }
        private void ReloadModalityList()
        {
            LoadDataModalityList();
            LoadFilterModalityList();
            LoadGridModalityList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (stopAllEvents) return;
            if (gridView1.FocusedRowHandle > -1)
            {
                drModSelected = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                modid = drModSelected["MODALITY_ID"].ToString().Trim();
                if (modid == null || modid == "") return;
                ReloadEnableControl(false);
                ReloadFillControl();
                ReloadExamMapping();
                ReloadClinicType();
            }
        }

        private void ReloadEnableControl(bool enableFlag)
        {
            txtModCode.Enabled = false;
            txtModName.Enabled = false;

            txtTypeCode.Enabled = false;
            txtTypeName.Enabled = false;

            txtUnitCode.Enabled = false;
            txtUnitName.Enabled = false;

            txtRoomCode.Enabled = false;
            txtRoomName.Enabled = false;

            txtStartdate.Enabled = enableFlag;
            txtEnddate.Enabled = enableFlag;

            txtAverageTime.Enabled = enableFlag;
            chkActive.Enabled = enableFlag;

            //gridControl1.Enabled = !enableFlag;
            gridView2.OptionsBehavior.Editable = enableFlag;

            btnExamEdit.Visible = !enableFlag;
            btnExamSave.Visible = enableFlag;
            btnExamCancel.Visible = enableFlag;
            btnExamAdd.Visible = enableFlag;

            btnLookupType.Enabled = enableFlag;
            btnLookupUnit.Enabled = enableFlag;
            btnLookupRoom.Enabled = enableFlag;
        }
        private void ReloadFillControl()
        {
            DataRow row = drModSelected;
            txtModCode.Tag = row["MODALITY_ID"].ToString();
            txtModCode.Text = row["MODALITY_UID"].ToString();
            txtModName.Text = row["MODALITY_NAME"].ToString();

            txtTypeCode.Tag = row["MODALITY_ID"].ToString();
            txtTypeCode.Text = row["TYPE_UID"].ToString();
            txtTypeName.Text = row["TYPE_NAME"].ToString();

            txtUnitCode.Tag = row["UNIT_ID"].ToString();
            txtUnitCode.Text = row["UNIT_UID"].ToString();
            txtUnitName.Text = row["UNIT_NAME"].ToString();

            txtRoomCode.Tag = row["ROOM_ID"].ToString();
            txtRoomCode.Text = row["ROOM_ID"].ToString();
            txtRoomName.Text = row["ROOM_UID"].ToString();

            txtStartdate.EditValue = row["START_TIME"];
            txtEnddate.EditValue = row["END_TIME"];

            txtAverageTime.EditValue = row["AVG_INV_TIME"];
            if (row["IS_ACTIVE"].ToString() == "Y")
                chkActive.Checked = true;
            else
                chkActive.Checked = false;
        }

        private void btnLookupType_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnLookupType_Clicks);
            lv.AddColumn("TYPE_ID", "EXAM_ID", false, true);
            lv.AddColumn("TYPE_UID", "Exam Code", true, true);
            lv.AddColumn("TYPE_NAME", "Exam Name", true, true);
            lv.AddColumn("TYPE_NAME_ALIAS", "Exam Type", true, true);
            lv.Text = "Modality Type Search";

            ProcessGetRISModalitytype pg = new ProcessGetRISModalitytype();
            pg.Invoke();
            lv.Data = pg.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnLookupType_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] vs = e.NewValue.Split(new Char[] { '^' });
            txtTypeCode.Tag = vs[0];
            txtTypeCode.Text = vs[1];
            txtTypeName.Text = vs[2];
        }

        private void btnLookupUnit_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnLookupUnit_Clicks);
            lv.AddColumn("UNIT_ID", "UNIT_ID", false, true);
            lv.AddColumn("UNIT_UID", "Unit Code", true, true);
            lv.AddColumn("UNIT_NAME", "Unit Name", true, true);
            lv.Text = "Unit Search";

            //ProcessGetRISModalitytype pg = new ProcessGetRISModalitytype();
            //pg.Invoke();
            ProcessGetHRUnit pg = new ProcessGetHRUnit();
            pg.Invoke();
            lv.Data = pg.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnLookupUnit_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] vs = e.NewValue.Split(new Char[] { '^' });
            txtUnitCode.Tag = vs[0];
            txtUnitCode.Text = vs[1];
            txtUnitName.Text = vs[3];
        }

        private void btnLookupRoom_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnLookupRoom_Clicks);
            lv.AddColumn("ROOM_ID", "ROOM_ID", false, true);
            lv.AddColumn("ROOM_ID", "Room Code", true, true);
            lv.AddColumn("ROOM_UID", "Room Name", true, true);
            lv.Text = "Unit Search";

            //ProcessGetHRUnit pg = new ProcessGetHRUnit();
            //pg.Invoke();
            ProcessGetHRRoom pg = new ProcessGetHRRoom();
            pg.Invoke();
            lv.Data = pg.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnLookupRoom_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] vs = e.NewValue.Split(new Char[] { '^' });
            txtRoomCode.Tag = vs[0];
            txtRoomCode.Text = vs[0];
            txtRoomName.Text = vs[1];
        }

        private void LoadDataExamMapping()
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(Convert.ToInt32(modid));
            process.Invoke();
            dtExam = process.Result.Tables[0].Copy();
            dtExam.Columns.Add("delete");
        }
        private void LoadFilterExamMapping()
        { 
        }
        private void LoadGridExamMapping()
        {
            dtExam_New = dtExam.Copy();
            gridControl2.DataSource = dtExam_New;

            int k = 0;
            while (k < gridView2.Columns.Count)
            {
                gridView2.Columns[k].OptionsColumn.AllowEdit = false;
                gridView2.Columns[k].OptionsColumn.AllowFocus = false;
                gridView2.Columns[k].Visible = false;
                ++k;
            }
            
            #region columnd setting
            gridView2.Columns["EXAM_UID"].Visible = true;
            gridView2.Columns["EXAM_UID"].Caption = "Modality Code";

            gridView2.Columns["EXAM_NAME"].Visible = true;
            gridView2.Columns["EXAM_NAME"].Caption = "Modality Name";

            gridView2.Columns["IS_ACTIVE"].Visible = true;
            gridView2.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["IS_ACTIVE"].OptionsColumn.AllowFocus = true;
            gridView2.Columns["IS_ACTIVE"].Caption = "Active";

            gridView2.Columns["IS_DEFAULT_MODALITY"].Visible = true;
            gridView2.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.AllowFocus = true;
            gridView2.Columns["IS_DEFAULT_MODALITY"].Caption = "Default";

            gridView2.Columns["delete"].Visible = true;
            gridView2.Columns["delete"].OptionsColumn.AllowEdit = true;
            gridView2.Columns["delete"].OptionsColumn.AllowFocus = true;
            gridView2.Columns["delete"].Caption = "";
            #endregion

            #region repository item
            RepositoryItemCheckEdit chk1 = new RepositoryItemCheckEdit();
            chk1.ValueChecked = "Y";
            chk1.ValueGrayed = "N";
            chk1.ValueUnchecked = "N";
            chk1.CheckStateChanged += new EventHandler(IsActive_CheckStateChanged);
            gridView2.Columns["IS_ACTIVE"].ColumnEdit = chk1;

            RepositoryItemCheckEdit chk2 = new RepositoryItemCheckEdit();
            chk2.ValueChecked = "Y";
            chk2.ValueGrayed = "N";
            chk2.ValueUnchecked = "N";
            chk2.CheckStateChanged += new EventHandler(IsDefault_CheckStateChanged);
            gridView2.Columns["IS_DEFAULT_MODALITY"].ColumnEdit = chk2;

            RepositoryItemButtonEdit btn1 = new RepositoryItemButtonEdit();
            btn1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn1.Buttons.Clear();
            EditorButton eb = new EditorButton();
            eb.Kind = ButtonPredefines.Delete;
            eb.Width = 50;
            btn1.Buttons.Add(eb);
            btn1.ButtonPressed += new ButtonPressedEventHandler(Delete_ButtonPressed);
            gridView2.Columns["delete"].ColumnEdit = btn1;
            #endregion

            if (gridView2.RowCount < 200)
                gridView2.BestFitColumns();
            gridView2.OptionsView.ColumnAutoWidth = true;
        }
        private void ReloadExamMapping()
        {
            LoadDataExamMapping();
            LoadFilterExamMapping();
            LoadGridExamMapping();
        }

        private void IsActive_CheckStateChanged(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                int tbIndex = dtExam_New.Rows.IndexOf(row);
                if (dtExam_New.Rows[tbIndex]["IS_ACTIVE"].ToString() == "Y")
                    dtExam_New.Rows[tbIndex]["IS_ACTIVE"] = "N";
                else if ((dtExam_New.Rows[tbIndex]["IS_ACTIVE"].ToString() == "N"))
                    dtExam_New.Rows[tbIndex]["IS_ACTIVE"] = "Y";
                dtExam_New.AcceptChanges();
            }
        }
        private void IsDefault_CheckStateChanged(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                int tbIndex = dtExam_New.Rows.IndexOf(row);
                if (dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "Y")
                    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "N";
                else if ((dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N"))
                    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "Y";
                dtExam_New.AcceptChanges();
            }
        }
        private void Delete_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                dtExam_New.Rows.Remove(row);
                dtExam_New.AcceptChanges();
            }
        }

        private void btnExamEdit_Click(object sender, EventArgs e)
        {
            ReloadEnableControl(true);
            btnExamEdit.Visible = false;
            btnExamSave.Visible = true;
            btnExamCancel.Visible = true;
            btnExamAdd.Visible = true;
        }
        private void btnExamSave_Click(object sender, EventArgs e)
        {
            #region Update Modality
            ProcessUpdateRISModality processUpdate = new ProcessUpdateRISModality();
            processUpdate.RISModality.MODALITY_ID = Convert.ToInt32(drModSelected["MODALITY_ID"]);
            processUpdate.RISModality.MODALITY_UID = txtModCode.Text;
            processUpdate.RISModality.MODALITY_NAME = txtModName.Text;
            processUpdate.RISModality.MODALITY_TYPE = txtTypeCode.Tag == null ? "0" : txtTypeCode.Tag.ToString();
            processUpdate.RISModality.ORG_ID = new GBLEnvVariable().OrgID;
            processUpdate.RISModality.ROOM_ID = txtRoomCode.Tag == null ? 0 : Convert.ToInt32(txtRoomCode.Tag);
            processUpdate.RISModality.UNIT_ID = txtUnitCode.Tag == null ? 0 : Convert.ToInt32(txtUnitCode.Tag);
            processUpdate.RISModality.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            processUpdate.RISModality.IS_ACTIVE = chkActive.Checked ? "Y" : "N";
            processUpdate.RISModality.IS_UPDATED = drModSelected["IS_UPDATED"].ToString();
            processUpdate.RISModality.IS_DELETED = drModSelected["IS_DELETED"].ToString();
            processUpdate.Invoke();
            #endregion


            DataTable tbAdd = dtExam.Clone();
            #region row was added
            foreach (DataRow nr in dtExam_New.Rows)
            {
                DataRow[] rows = dtExam.Select("EXAM_ID=" + nr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbAdd.Rows.Add(nr.ItemArray);
            }
            #endregion

            DataTable tbDelete = dtExam.Clone();
            #region row was deleted
            foreach(DataRow mr in dtExam.Rows)
            {
                DataRow[] rows = dtExam_New.Select("EXAM_ID=" + mr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbDelete.Rows.Add(mr.ItemArray);
            }
            #endregion

            DataTable tbUpdate = dtExam.Clone();
            #region row was updated
            //foreach (DataRow nr in dtExam_New.Rows)
            //{
            //    string examid = nr["EXAM_ID"].ToString();
            //    string isactive = nr["IS_ACTIVE"].ToString().Trim().ToUpper();
            //    string isdefault = nr["IS_DEFAULT_MODALITY"].ToString().Trim().ToUpper();
            //    DataRow[] rows = dtExam.Select("EXAM_ID=" + examid + " AND (IS_ACTIVE<>'" + isactive + "' OR IS_DEFAULT_MODALITY<>'" + isdefault + "')");
            //    //if (rows.Length > 0)
            //    //    if ((nr["IS_ACTIVE"] != rows[0]["IS_ACTIVE"]) || (nr["IS_DEFAULT_MODALITY"] != rows[0]["IS_DEFAULT_MODALITY"]))
            //    //        tbUpdate.Rows.Add(rows[0].ItemArray);
            //    if (rows.Length > 0)
            //    { 
            //        //foreach(DataRow dr in rows)
            //        //    tbUpdate.Rows.Add(dr.ItemArray);
            //        tbUpdate.Rows.Add(nr.ItemArray);
            //    }
            //}
            foreach (DataRow mr in dtExam.Rows)
            {
                string examid = mr["EXAM_ID"].ToString();
                string isactive = mr["IS_ACTIVE"].ToString().Trim().ToUpper();
                string isdefault = mr["IS_DEFAULT_MODALITY"].ToString().Trim().ToUpper();
                DataRow[] rows = dtExam_New.Select("EXAM_ID=" + examid + " AND (IS_ACTIVE<>'" + isactive + "' OR IS_DEFAULT_MODALITY<>'" + isdefault + "')");
                if (rows.Length > 0)
                {
                    mr["IS_ACTIVE"] = rows[0]["IS_ACTIVE"];
                    mr["IS_DEFAULT_MODALITY"] = rows[0]["IS_DEFAULT_MODALITY"];
                    tbUpdate.Rows.Add(mr.ItemArray);
                }
            }
            #endregion

            #region clear add row
            foreach (DataRow dr in tbAdd.Rows)
            {
                ProcessAddRISModalityexam processAdd = new ProcessAddRISModalityexam();
                processAdd.RISModalityexam.CREATED_BY = new GBLEnvVariable().UserID;
                processAdd.RISModalityexam.MODALITY_ID = processUpdate.RISModality.MODALITY_ID;
                processAdd.RISModalityexam.ORG_ID = new GBLEnvVariable().OrgID;
                processAdd.RISModalityexam.EXAM_ID = (int)dr["EXAM_ID"];
                processAdd.RISModalityexam.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim();
                processAdd.RISModalityexam.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim();
                processAdd.RISModalityexam.IS_DELETED = dr["IS_DELETED"].ToString().Trim();
                processAdd.RISModalityexam.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim();
                processAdd.Invoke();
            }
            #endregion

            #region clear delete row
            foreach (DataRow dr in tbDelete.Rows)
            {
                ProcessDeleteRISModalityexam processDelete = new ProcessDeleteRISModalityexam();
                processDelete.RISModalityexam.MODALITY_EXAM_ID = Convert.ToInt32(dr["MODALITY_EXAM_ID"]);
                processDelete.Invoke();
            }
            #endregion

            #region clear update row
            foreach (DataRow dr in tbUpdate.Rows)
            {
                ProcessUpdateRISModalityexam processUpdateDetails = new ProcessUpdateRISModalityexam();
                processUpdateDetails.RISModalityexam.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdateDetails.RISModalityexam.EXAM_ID = (int)dr["EXAM_ID"];
                processUpdateDetails.RISModalityexam.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim() == string.Empty || dr["IS_ACTIVE"].ToString().Trim() == "N" ? "N" : "Y";
                processUpdateDetails.RISModalityexam.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim() == string.Empty || dr["IS_DEFAULT_MODALITY"].ToString().Trim() == "N" ? "N" : "Y";
                processUpdateDetails.RISModalityexam.IS_DELETED = dr["IS_DELETED"].ToString().Trim() == string.Empty || dr["IS_DELETED"].ToString().Trim() == "N" ? "N" : "Y";
                processUpdateDetails.RISModalityexam.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim() == string.Empty || dr["IS_UPDATED"].ToString().Trim() == "N" ? "N" : "Y";
                processUpdateDetails.RISModalityexam.MODALITY_EXAM_ID = (int)dr["MODALITY_EXAM_ID"];
                processUpdateDetails.RISModalityexam.MODALITY_ID = (int)dr["MODALITY_ID"];
                processUpdateDetails.RISModalityexam.ORG_ID = new GBLEnvVariable().OrgID;
                processUpdateDetails.RISModalityexam.QA_BYPASS = dr["QA_BYPASS"].ToString();
                processUpdateDetails.RISModalityexam.TECH_BYPASS = dr["TECH_BYPASS"].ToString();
                //processUpdateDetails.RISModalityexam.CREATED_BY =(int) dr["CREATED_BY"];
                processUpdateDetails.Invoke();
            }
            #endregion

            int frow = gridView1.FocusedRowHandle;
            stopAllEvents = true;
            ReloadModalityList();
            stopAllEvents = false;
            gridView1.FocusedRowHandle = frow;

            ReloadEnableControl(false);
            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;
        }
        private void btnExamCancel_Click(object sender, EventArgs e)
        {
            ReloadEnableControl(false);
            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;
        }
        private void btnExamAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnExamAdd_Clicks);
            lv.AddColumn("EXAM_ID", "EXAM_ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            //lv.AddColumn("EXAM_TYPE", "Exam Type", true, true);
            //lv.AddColumn("IS_ACTIVE", "Exam Type", false, true);
            //lv.AddColumn("ExAM_TYPE", "Exam Type", true, true);
            lv.Text = "Exam Search";

            //ProcessGetRISExam ex = new ProcessGetRISExam();
            //ex.Invoke();
            //DataRow[] rows = ex.Result.Tables[0].Select("EXAM_TYPE <> 8");
            //DataTable table = ex.Result.Tables[0].Clone();
            //foreach (DataRow dr in rows)
            //    table.Rows.Add(dr.ItemArray);
            //lv.Data = table;

            ProcessGetRISExam ex = new ProcessGetRISExam();
            ex.Invoke();
            lv.Data = ex.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnExamAdd_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] rv = e.NewValue.Split(new Char[] { '^' });

            DataRow[] rows = dtExam_New.Select("EXAM_ID=" + rv[0]);
            if (rows.Length == 0)
            {
                #region add new exam
                DataRow row = dtExam_New.NewRow();
                row["MODALITY_ID"] = drModSelected["MODALITY_ID"];
                row["EXAM_ID"] = rv[0];
                row["EXAM_UID"] = rv[1];
                row["EXAM_NAME"] = rv[3];
                row["IS_ACTIVE"] = "Y";
                row["IS_DEFAULT_MODALITY"] = "N";
                dtExam_New.Rows.Add(row);
                #endregion
            }
            else
            {
                MessageBox.Show("Already added this exam", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void LoadDataClinicType()
        {
            ProcessGetRISModalityclinictype getProcess = new ProcessGetRISModalityclinictype();
            getProcess.RISModalityclinictype.MODALITY_ID = Convert.ToInt32(modid);
            getProcess.Invoke(2);
            dtClinic = getProcess.Result.Tables[0].Copy();
            dtClinic.Columns.Add("delete");
        }
        private void LoadFilterClinicType()
        {
        }
        private void LoadGridClinicType()
        {
            gridControl3.DataSource = dtClinic;
        }
        private void ReloadClinicType()
        {
            LoadDataClinicType();
            LoadFilterClinicType();
            LoadGridClinicType();
        }

    }
}
