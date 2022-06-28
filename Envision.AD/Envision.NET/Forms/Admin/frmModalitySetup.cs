using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Main;

namespace Envision.NET.Forms.Admin
{
    public partial class frmModalitySetup : MasterForm
    {
        DataTable dtModality = new DataTable();
        DataTable dtExamMapping = new DataTable();
        DataTable dtExamOnlineMapping = new DataTable();

        DataTable dtExamMappingChanged = new DataTable();
        DataTable dtExamOnlineChanged = new DataTable();

        DataRow drModSelected; 

        string modid = "";
        bool stopAllEvents = false;
        bool checkStateChange = false;

        public frmModalitySetup()
        {
            InitializeComponent();
        }
        private void ModalitySetup_Load(object sender, EventArgs e)
        {
            #region button enable-disable
            btnModalityEdit.Visible = true;
            btnModalitySave.Visible = false;
            btnModalityCancel.Visible = false;

            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;

            btnExamOnlineEdit.Visible = true;
            btnExamOnlineSave.Visible = false;
            btnExamOnlineCancel.Visible = false;
            btnExamOnlineAdd.Visible = false;

            btnClinicEdit.Visible = true;
            btnClinicSave.Visible = false;
            btnExamCancel.Visible = false;
            btnClinicAdd.Visible = false;
            #endregion
            ReloadModalityList();

            base.CloseWaitDialog();
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
                setEnableModalityControl(false);
                setEnableExamOnlineMappingControl(false);
                ReloadFillControl();

                ReloadExamMapping();
                ReloadExamOnlineMapping();
            }
        }
        private void setEnableModalityControl(bool enableFlag)
        {
            txtModCode.Enabled = enableFlag;
            txtModName.Enabled = enableFlag;

            txtTypeCode.Enabled = enableFlag;
            txtTypeName.Enabled = enableFlag;

            txtUnitCode.Enabled = enableFlag;
            txtUnitName.Enabled = enableFlag;

            txtRoomCode.Enabled = enableFlag;
            txtRoomName.Enabled = enableFlag;

            txtStartdate.Enabled = enableFlag;
            txtEnddate.Enabled = enableFlag;

            txtAverageTime.Enabled = enableFlag;
            chkActive.Enabled = enableFlag;

            btnLookupType.Enabled = enableFlag;
            btnLookupUnit.Enabled = enableFlag;
            btnLookupRoom.Enabled = enableFlag;

            btnLookupDestination.Enabled = enableFlag;

            txtDestinationCode.Enabled = enableFlag;
            txtDestinationName.Enabled = enableFlag;
        }
        private void setEnableExamMappingControl(bool enableFlag)
        {
            gridView2.OptionsBehavior.Editable = enableFlag;

            btnExamEdit.Visible = !enableFlag;
            btnExamSave.Visible = enableFlag;
            btnExamCancel.Visible = enableFlag;
            btnExamAdd.Visible = enableFlag;
        }
        private void setEnableExamOnlineMappingControl(bool enableFlag)
        {
            viewExamOnline.OptionsBehavior.Editable = enableFlag;
            
            btnExamOnlineEdit.Visible = !enableFlag;
            btnExamOnlineSave.Visible = enableFlag;
            btnExamOnlineCancel.Visible = enableFlag;
            btnExamOnlineAdd.Visible = enableFlag;
        }

        private void ReloadFillControl()
        {
            DataRow row = drModSelected;
            txtModCode.Tag = row["MODALITY_ID"].ToString();
            txtModCode.Text = row["MODALITY_UID"].ToString();
            txtModName.Text = row["MODALITY_NAME"].ToString();

            txtTypeCode.Tag = row["MODALITY_TYPE"].ToString();
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

            txtDestinationCode.Tag = row["PAT_DEST_ID"].ToString();
            txtDestinationCode.Text = row["LABEL"].ToString();
            txtDestinationName.Text = row["ENCOUNTER_TYPE"].ToString();
        }

        private void btnLookupType_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnLookupType_Clicks);
            lv.AddColumn("TYPE_ID", "TYPE_ID", false, true);
            lv.AddColumn("TYPE_UID", "Type Code", true, true);
            lv.AddColumn("TYPE_NAME", "Type Name", true, true);
            lv.AddColumn("TYPE_NAME_ALIAS", "Alias Name", true, true);
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

        private void btnLookupDestination_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnLookupDestination_Clicks);
            lv.AddColumn("LABEL", "Label", true, true);
            lv.AddColumn("ENCOUNTER_TYPE", "Type", false, true);
            lv.AddColumn("ENCOUNTER_CLINIC_TYPE", "Clinic Type", false, true);
            lv.AddColumn("ORDERING_DEPT", "Ordering Dept.", false, true);
            lv.Text = "Patient Destination";

            ProcessGetRISPatientDestination patGet = new ProcessGetRISPatientDestination();
            patGet.RIS_PATIENTDESTINATION.ORG_ID = new GBLEnvVariable().OrgID;
            patGet.Invoke();
            lv.Data = patGet.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnLookupDestination_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] vs = e.NewValue.Split(new Char[] { '^' });
            txtDestinationCode.Tag = vs[0];
            txtDestinationCode.Text = vs[2];
            txtDestinationName.Text = vs[2];
        }

        private void LoadDataExamMapping()
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(Convert.ToInt32(modid));
            process.Invoke();
            dtExamMapping = process.Result.Tables[0].Copy();
            dtExamMapping.Columns.Add("delete");
        }
        private void LoadGridExamMapping()
        {
            dtExamMappingChanged = dtExamMapping.Copy();
            gridControl2.DataSource = dtExamMappingChanged;

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
            gridView2.Columns["EXAM_UID"].Caption = "Exam Code";

            gridView2.Columns["EXAM_NAME"].Visible = true;
            gridView2.Columns["EXAM_NAME"].Caption = "Exam Name";

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
        private void IsActive_CheckStateChanged(object sender, EventArgs e)
        {
            if (stopAllEvents) return;
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                if (row["IS_ACTIVE"].ToString() == "Y")
                    row["IS_ACTIVE"] = "N";
                else if (row["IS_ACTIVE"].ToString() == "N")
                    row["IS_ACTIVE"] = "Y";
            }
        }
        private void IsDefault_CheckStateChanged(object sender, EventArgs e)
        {
            if (stopAllEvents) return;
            if (checkStateChange) { checkStateChange = false; return; }
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                //int tbIndex = dtExam_New.Rows.IndexOf(row);

                #region Check Default Condition
                if (row["IS_DEFAULT_MODALITY"].ToString() == "N")
                {
                    int exam_id = Convert.ToInt32(row["EXAM_ID"]);
                    int modality_id = Convert.ToInt32(row["MODALITY_ID"]);
                    ProcessGetRISModality getDupl = new ProcessGetRISModality();
                    DataSet dsCheck = getDupl.GetCheckDuplicateIsDefault(exam_id, modality_id);
                    if (Miracle.Util.Utilities.IsHaveData(dsCheck))
                    {
                        DataRow[] drs = dsCheck.Tables[0].Select("ISNULL(IS_DEFAULT_MODALITY,'N') = 'Y'");
                        if (drs.Length > 0)
                        {
                            MyMessageBox msg = new MyMessageBox();
                            string msgAck = msg.ShowAlert("UID2123", new GBLEnvVariable().CurrentLanguageID);
                            if (msgAck == "1")
                            {
                                checkStateChange = true;
                                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                                chk.CheckState = CheckState.Unchecked;
                                return;
                            }
                        }
                    }
                }
                #endregion

                //if (dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "Y")
                //    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "N";
                //else if ((dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N"))
                //    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "Y";
                //dtExam_New.AcceptChanges();
            }
        }
        private void Delete_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (gridView2.FocusedRowHandle > -1)
            {
                DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                dtExamMappingChanged.Rows.Remove(row);
                dtExamMappingChanged.AcceptChanges();
            }
        }

        private void ReloadExamMapping()
        {
            LoadDataExamMapping();
            LoadGridExamMapping();
        }

        private void LoadDataExamOnlineMapping()
        {
            ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(Convert.ToInt32(modid));
            process.InvokeOnline();
            dtExamOnlineMapping = process.Result.Tables[0].Copy();
            dtExamOnlineMapping.Columns.Add("delete");
        }
        private void LoadGridExamOnlineMapping()
        {
            dtExamOnlineChanged = dtExamOnlineMapping.Copy();
            grdExamOnline.DataSource = dtExamOnlineChanged;
            
            int k = 0;
            while (k < viewExamOnline.Columns.Count)
            {
                viewExamOnline.Columns[k].OptionsColumn.AllowEdit = false;
                viewExamOnline.Columns[k].OptionsColumn.AllowFocus = false;
                viewExamOnline.Columns[k].Visible = false;
                ++k;
            }

            #region columnd setting
            viewExamOnline.Columns["EXAM_UID"].Visible = true;
            viewExamOnline.Columns["EXAM_UID"].Caption = "Exam Code";

            viewExamOnline.Columns["EXAM_NAME"].Visible = true;
            viewExamOnline.Columns["EXAM_NAME"].Caption = "Exam Name";

            viewExamOnline.Columns["IS_ACTIVE"].Visible = true;
            viewExamOnline.Columns["IS_ACTIVE"].OptionsColumn.AllowEdit = true;
            viewExamOnline.Columns["IS_ACTIVE"].OptionsColumn.AllowFocus = true;
            viewExamOnline.Columns["IS_ACTIVE"].Caption = "Active";

            viewExamOnline.Columns["IS_DEFAULT_MODALITY"].Visible = true;
            viewExamOnline.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.AllowEdit = true;
            viewExamOnline.Columns["IS_DEFAULT_MODALITY"].OptionsColumn.AllowFocus = true;
            viewExamOnline.Columns["IS_DEFAULT_MODALITY"].Caption = "Default";

            viewExamOnline.Columns["delete"].Visible = true;
            viewExamOnline.Columns["delete"].OptionsColumn.AllowEdit = true;
            viewExamOnline.Columns["delete"].OptionsColumn.AllowFocus = true;
            viewExamOnline.Columns["delete"].Caption = "";
            #endregion

            #region repository item
            RepositoryItemCheckEdit chk1 = new RepositoryItemCheckEdit();
            chk1.ValueChecked = "Y";
            chk1.ValueGrayed = "N";
            chk1.ValueUnchecked = "N";
            chk1.CheckStateChanged += new EventHandler(IsActiveOnline_CheckStateChanged);
            viewExamOnline.Columns["IS_ACTIVE"].ColumnEdit = chk1;

            RepositoryItemCheckEdit chk2 = new RepositoryItemCheckEdit();
            chk2.ValueChecked = "Y";
            chk2.ValueGrayed = "N";
            chk2.ValueUnchecked = "N";
            chk2.CheckStateChanged += new EventHandler(IsDefaultOnline_CheckStateChanged);
            viewExamOnline.Columns["IS_DEFAULT_MODALITY"].ColumnEdit = chk2;

            RepositoryItemButtonEdit btn1 = new RepositoryItemButtonEdit();
            btn1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btn1.Buttons.Clear();
            EditorButton eb = new EditorButton();
            eb.Kind = ButtonPredefines.Delete;
            eb.Width = 50;
            btn1.Buttons.Add(eb);
            btn1.ButtonPressed += new ButtonPressedEventHandler(DeleteOnline_ButtonPressed);
            viewExamOnline.Columns["delete"].ColumnEdit = btn1;
            #endregion

            if (viewExamOnline.RowCount < 200)
                viewExamOnline.BestFitColumns();
            viewExamOnline.OptionsView.ColumnAutoWidth = true;
        }
        private void IsActiveOnline_CheckStateChanged(object sender, EventArgs e)
        {
            if (stopAllEvents) return;
            if (viewExamOnline.FocusedRowHandle > -1)
            {
                DataRow row = viewExamOnline.GetDataRow(viewExamOnline.FocusedRowHandle);
                if (row["IS_ACTIVE"].ToString() == "Y")
                    row["IS_ACTIVE"] = "N";
                else if (row["IS_ACTIVE"].ToString() == "N")
                    row["IS_ACTIVE"] = "Y";
            }
        }
        private void IsDefaultOnline_CheckStateChanged(object sender, EventArgs e)
        {
            if (stopAllEvents) return;
            if (checkStateChange) { checkStateChange = false; return; }
            if (viewExamOnline.FocusedRowHandle > -1)
            {
                DataRow row = viewExamOnline.GetDataRow(viewExamOnline.FocusedRowHandle);

                #region Check Default Condition
                if (row["IS_DEFAULT_MODALITY"].ToString() == "N")
                {
                    int exam_id = Convert.ToInt32(row["EXAM_ID"]);
                    int modality_id = Convert.ToInt32(row["MODALITY_ID"]);
                    ProcessGetRISModality getDupl = new ProcessGetRISModality();
                    DataSet dsCheck = getDupl.GetCheckDuplicateIsDefault(exam_id, modality_id);
                    if (Miracle.Util.Utilities.IsHaveData(dsCheck))
                    {
                        DataRow[] drs = dsCheck.Tables[0].Select("ISNULL(IS_DEFAULT_MODALITY,'N') = 'Y'");
                        if (drs.Length > 0)
                        {
                            MyMessageBox msg = new MyMessageBox();
                            string msgAck = msg.ShowAlert("UID2123", new GBLEnvVariable().CurrentLanguageID);
                            if (msgAck == "1")
                            {
                                checkStateChange = true;
                                DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
                                chk.CheckState = CheckState.Unchecked;
                                return;
                            }
                        }
                    }
                }
                #endregion

                //if (dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "Y")
                //    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "N";
                //else if ((dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"].ToString() == "N"))
                //    dtExam_New.Rows[tbIndex]["IS_DEFAULT_MODALITY"] = "Y";
            }
        }
        private void DeleteOnline_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (viewExamOnline.FocusedRowHandle > -1)
            {
                DataRow row = viewExamOnline.GetDataRow(viewExamOnline.FocusedRowHandle);
                dtExamOnlineChanged.Rows.Remove(row);
                dtExamOnlineChanged.AcceptChanges();
            }
        }

        private void ReloadExamOnlineMapping()
        {
            LoadDataExamOnlineMapping();
            LoadGridExamOnlineMapping();
        }
        
        private void btnModalityEdit_Click(object sender, EventArgs e)
        {
            setEnableModalityControl(true);
            btnModalityEdit.Visible = false;
            btnModalitySave.Visible = true;
            btnModalityCancel.Visible = true;
        }
        private void btnModalitySave_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string ansMsg = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (ansMsg == "1") return;

            #region Update Modality
            ProcessUpdateRISModality processUpdate = new ProcessUpdateRISModality();
            processUpdate.RIS_MODALITY.MODALITY_ID = Convert.ToInt32(drModSelected["MODALITY_ID"]);
            processUpdate.RIS_MODALITY.MODALITY_UID = txtModCode.Text;
            processUpdate.RIS_MODALITY.MODALITY_NAME = txtModName.Text;
            processUpdate.RIS_MODALITY.MODALITY_TYPE = txtTypeCode.Tag.ToString().Length == 0 ? 0 : Convert.ToInt32(txtTypeCode.Tag);
            processUpdate.RIS_MODALITY.ORG_ID = new GBLEnvVariable().OrgID;
            processUpdate.RIS_MODALITY.ROOM_ID = txtRoomCode.Tag == null ? 0 : Convert.ToInt32(txtRoomCode.Tag);
            processUpdate.RIS_MODALITY.UNIT_ID = txtUnitCode.Tag == null ? 0 : Convert.ToInt32(txtUnitCode.Tag);
            processUpdate.RIS_MODALITY.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
            processUpdate.RIS_MODALITY.IS_ACTIVE = chkActive.Checked ? 'Y' : 'N';
            processUpdate.RIS_MODALITY.IS_UPDATED = drModSelected["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)(drModSelected["IS_UPDATED"].ToString().Trim()[0]);
            processUpdate.RIS_MODALITY.IS_DELETED = drModSelected["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)(drModSelected["IS_DELETED"].ToString().Trim()[0]);
            processUpdate.RIS_MODALITY.PAT_DEST_ID = txtDestinationCode.Tag.ToString().Length == 0 ? null : (int?)Convert.ToInt32(txtDestinationCode.Tag);
            processUpdate.Invoke();
            #endregion

            ReloadModalityList();

            setEnableModalityControl(false);
            btnModalityEdit.Visible = true;
            btnModalitySave.Visible = false;
            btnModalityCancel.Visible = false;
        }
        private void btnModalityCancel_Click(object sender, EventArgs e)
        {
            setEnableModalityControl(false);
            btnModalityEdit.Visible = true;
            btnModalitySave.Visible = false;
            btnModalityCancel.Visible = false;
        }

        private void btnExamEdit_Click(object sender, EventArgs e)
        {
            setEnableExamMappingControl(true);
            btnExamEdit.Visible = false;
            btnExamSave.Visible = true;
            btnExamCancel.Visible = true;
            btnExamAdd.Visible = true;
        }
        private void btnExamSave_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string ansMsg = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (ansMsg == "1") return;
            
            DataTable tbAdd = dtExamMapping.Clone();
            #region row was added
            foreach (DataRow nr in dtExamMappingChanged.Rows)
            {
                DataRow[] rows = dtExamMapping.Select("EXAM_ID=" + nr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbAdd.Rows.Add(nr.ItemArray);
            }
            #endregion

            DataTable tbDelete = dtExamMapping.Clone();
            #region row was deleted
            foreach (DataRow mr in dtExamMapping.Rows)
            {
                DataRow[] rows = dtExamMappingChanged.Select("EXAM_ID=" + mr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbDelete.Rows.Add(mr.ItemArray);
            }
            #endregion

            DataTable tbUpdate = dtExamMapping.Clone();
            #region row was updated
            foreach (DataRow mr in dtExamMapping.Rows)
            {
                string examid = mr["EXAM_ID"].ToString();
                string isactive = mr["IS_ACTIVE"].ToString().Trim().ToUpper();
                string isdefault = mr["IS_DEFAULT_MODALITY"].ToString().Trim().ToUpper();
                DataRow[] rows = dtExamMappingChanged.Select("EXAM_ID=" + examid + " AND (IS_ACTIVE<>'" + isactive + "' OR IS_DEFAULT_MODALITY<>'" + isdefault + "')");
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
                processAdd.RIS_MODALITYEXAM.CREATED_BY = new GBLEnvVariable().UserID;
                processAdd.RIS_MODALITYEXAM.MODALITY_ID = Convert.ToInt32(drModSelected["MODALITY_ID"]);
                processAdd.RIS_MODALITYEXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processAdd.RIS_MODALITYEXAM.EXAM_ID = (int)dr["EXAM_ID"];
                processAdd.RIS_MODALITYEXAM.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_ACTIVE"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_DEFAULT_MODALITY"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_DELETED = dr["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_DELETED"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_UPDATED"].ToString().Trim()[0]);
                processAdd.Invoke();
            }
            #endregion

            #region clear delete row
            foreach (DataRow dr in tbDelete.Rows)
            {
                ProcessDeleteRISModalityexam processDelete = new ProcessDeleteRISModalityexam();
                processDelete.RIS_MODALITYEXAM.MODALITY_EXAM_ID = Convert.ToInt32(dr["MODALITY_EXAM_ID"]);
                processDelete.Invoke();
            }
            #endregion

            #region clear update row
            foreach (DataRow dr in tbUpdate.Rows)
            {
                ProcessUpdateRISModalityexam processUpdateDetails = new ProcessUpdateRISModalityexam();
                processUpdateDetails.RIS_MODALITYEXAM.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdateDetails.RIS_MODALITYEXAM.EXAM_ID = (int)dr["EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_ACTIVE"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DEFAULT_MODALITY"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DELETED = dr["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DELETED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_UPDATED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_EXAM_ID = (int)dr["MODALITY_EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_ID = (int)dr["MODALITY_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processUpdateDetails.RIS_MODALITYEXAM.QA_BYPASS = dr["QA_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["QA_BYPASS"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.TECH_BYPASS = dr["TECH_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["TECH_BYPASS"].ToString().Trim()[0];
                //processUpdateDetails.RISModalityexam.CREATED_BY =(int) dr["CREATED_BY"];
                processUpdateDetails.Invoke();
            }
            #endregion

            int frow = gridView1.FocusedRowHandle;
            stopAllEvents = true;
            ReloadModalityList();
            stopAllEvents = false;
            gridView1.FocusedRowHandle = frow;

            setEnableExamMappingControl(false);
            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;
        }
        private void btnExamCancel_Click(object sender, EventArgs e)
        {
            setEnableExamMappingControl(false);
            btnExamEdit.Visible = true;
            btnExamSave.Visible = false;
            btnExamCancel.Visible = false;
            btnExamAdd.Visible = false;

            ReloadExamMapping();
        }
        private void btnExamAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnExamAdd_Clicks);
            lv.AddColumn("EXAM_ID", "EXAM_ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.Text = "Exam Search";

            ProcessGetRISExam ex = new ProcessGetRISExam();
            ex.Invoke();
            lv.Data = ex.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnExamAdd_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] rv = e.NewValue.Split(new Char[] { '^' });

            DataRow[] rows = dtExamMappingChanged.Select("EXAM_ID=" + rv[0]);
            if (rows.Length == 0)
            {
                #region add new exam
                DataRow row = dtExamMappingChanged.NewRow();
                row["MODALITY_ID"] = drModSelected["MODALITY_ID"];
                row["EXAM_ID"] = rv[0];
                row["EXAM_UID"] = rv[1];
                row["EXAM_NAME"] = rv[3];
                row["IS_ACTIVE"] = "Y";
                row["IS_DEFAULT_MODALITY"] = "N";
                dtExamMappingChanged.Rows.Add(row);
                #endregion
            }
            else
            {
                MessageBox.Show("Already added this exam", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnExamOnlineEdit_Click(object sender, EventArgs e)
        {
            setEnableExamOnlineMappingControl(true);
            btnExamOnlineEdit.Visible = false;
            btnExamOnlineSave.Visible = true;
            btnExamOnlineCancel.Visible = true;
            btnExamOnlineAdd.Visible = true;
        }
        private void btnExamOnlineSave_Click(object sender, EventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            string ansMsg = msg.ShowAlert("UID1019", new GBLEnvVariable().CurrentLanguageID);
            if (ansMsg == "1") return;
            
            DataTable tbAdd = dtExamOnlineMapping.Clone();
            #region row was added
            foreach (DataRow nr in dtExamOnlineChanged.Rows)
            {
                DataRow[] rows = dtExamOnlineMapping.Select("EXAM_ID=" + nr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbAdd.Rows.Add(nr.ItemArray);
            }
            #endregion

            DataTable tbDelete = dtExamOnlineMapping.Clone();
            #region row was deleted
            foreach (DataRow mr in dtExamOnlineMapping.Rows)
            {
                DataRow[] rows = dtExamOnlineChanged.Select("EXAM_ID=" + mr["EXAM_ID"]);
                if (rows.Length == 0)
                    tbDelete.Rows.Add(mr.ItemArray);
            }
            #endregion

            DataTable tbUpdate = dtExamOnlineMapping.Clone();
            #region row was updated
            foreach (DataRow mr in dtExamOnlineMapping.Rows)
            {
                string examid = mr["EXAM_ID"].ToString();
                string isactive = mr["IS_ACTIVE"].ToString().Trim().ToUpper();
                string isdefault = mr["IS_DEFAULT_MODALITY"].ToString().Trim().ToUpper();
                DataRow[] rows = dtExamOnlineChanged.Select("EXAM_ID=" + examid + " AND (IS_ACTIVE<>'" + isactive + "' OR IS_DEFAULT_MODALITY<>'" + isdefault + "')");
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
                processAdd.RIS_MODALITYEXAM.CREATED_BY = new GBLEnvVariable().UserID;
                processAdd.RIS_MODALITYEXAM.MODALITY_ID = Convert.ToInt32(drModSelected["MODALITY_ID"]);
                processAdd.RIS_MODALITYEXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processAdd.RIS_MODALITYEXAM.EXAM_ID = (int)dr["EXAM_ID"];
                processAdd.RIS_MODALITYEXAM.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_ACTIVE"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_DEFAULT_MODALITY"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_DELETED = dr["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_DELETED"].ToString().Trim()[0]);
                processAdd.RIS_MODALITYEXAM.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)(dr["IS_UPDATED"].ToString().Trim()[0]);
                processAdd.InvokeOnline();
            }
            #endregion

            #region clear delete row
            foreach (DataRow dr in tbDelete.Rows)
            {
                ProcessDeleteRISModalityexam processDelete = new ProcessDeleteRISModalityexam();
                processDelete.RIS_MODALITYEXAM.MODALITY_EXAM_ID = Convert.ToInt32(dr["MODALITY_EXAM_ID"]);
                processDelete.InvokeOnline();
            }
            #endregion

            #region clear update row
            foreach (DataRow dr in tbUpdate.Rows)
            {
                ProcessUpdateRISModalityexam processUpdateDetails = new ProcessUpdateRISModalityexam();
                processUpdateDetails.RIS_MODALITYEXAM.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                processUpdateDetails.RIS_MODALITYEXAM.EXAM_ID = (int)dr["EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.IS_ACTIVE = dr["IS_ACTIVE"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_ACTIVE"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DEFAULT_MODALITY = dr["IS_DEFAULT_MODALITY"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DEFAULT_MODALITY"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_DELETED = dr["IS_DELETED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_DELETED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.IS_UPDATED = dr["IS_UPDATED"].ToString().Trim().Length == 0 ? null : (char?)dr["IS_UPDATED"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_EXAM_ID = (int)dr["MODALITY_EXAM_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.MODALITY_ID = (int)dr["MODALITY_ID"];
                processUpdateDetails.RIS_MODALITYEXAM.ORG_ID = new GBLEnvVariable().OrgID;
                processUpdateDetails.RIS_MODALITYEXAM.QA_BYPASS = dr["QA_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["QA_BYPASS"].ToString().Trim()[0];
                processUpdateDetails.RIS_MODALITYEXAM.TECH_BYPASS = dr["TECH_BYPASS"].ToString().Trim().Length == 0 ? null : (char?)dr["TECH_BYPASS"].ToString().Trim()[0];
                //processUpdateDetails.RISModalityexam.CREATED_BY =(int) dr["CREATED_BY"];
                processUpdateDetails.InvokeOnline();
            }
            #endregion

            int frow = gridView1.FocusedRowHandle;
            stopAllEvents = true;
            ReloadModalityList();
            stopAllEvents = false;
            gridView1.FocusedRowHandle = frow;

            setEnableExamOnlineMappingControl(false);
            btnExamOnlineEdit.Visible = true;
            btnExamOnlineSave.Visible = false;
            btnExamOnlineCancel.Visible = false;
            btnExamOnlineAdd.Visible = false;
        }
        private void btnExamOnlineCancel_Click(object sender, EventArgs e)
        {
            setEnableExamOnlineMappingControl(false);
            btnExamOnlineEdit.Visible = true;
            btnExamOnlineSave.Visible = false;
            btnExamOnlineCancel.Visible = false;
            btnExamOnlineAdd.Visible = false;

            ReloadExamMapping();
        }
        private void btnExamOnlineAdd_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            LookupData lv = new LookupData();
            lv.ValueUpdated += new ValueUpdatedEventHandler(btnExamOnlineAdd_Clicks);
            lv.AddColumn("EXAM_ID", "EXAM_ID", false, true);
            lv.AddColumn("EXAM_UID", "Exam Code", true, true);
            lv.AddColumn("EXAM_NAME", "Exam Name", true, true);
            lv.Text = "Exam Search";

            ProcessGetRISExam ex = new ProcessGetRISExam();
            ex.Invoke();
            lv.Data = ex.Result.Tables[0];
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void btnExamOnlineAdd_Clicks(object sender, ValueUpdatedEventArgs e)
        {
            string[] rv = e.NewValue.Split(new Char[] { '^' });

            DataRow[] rows = dtExamOnlineChanged.Select("EXAM_ID=" + rv[0]);
            if (rows.Length == 0)
            {
                #region add new exam
                DataRow row = dtExamOnlineChanged.NewRow();
                row["MODALITY_ID"] = drModSelected["MODALITY_ID"];
                row["EXAM_ID"] = rv[0];
                row["EXAM_UID"] = rv[1];
                row["EXAM_NAME"] = rv[3];
                row["IS_ACTIVE"] = "Y";
                row["IS_DEFAULT_MODALITY"] = "N";
                dtExamOnlineChanged.Rows.Add(row);
                #endregion
            }
            else
            {
                MessageBox.Show("Already added this exam", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
