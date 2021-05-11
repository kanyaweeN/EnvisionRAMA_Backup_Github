using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler.Xml;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.Operational;
using Envision.NET.Forms.Dialog;
using Envision.Plugin.ReportManager;
using DevExpress.XtraEditors.Repository;
using System.Reflection;
using Miracle.Scanner;
using Envision.NET.Forms.Schedule.Common;
using Envision.NET.Forms.EMR;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmWaitingList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DataTable dttBpview { get; set; }
        public DataTable dttDepartment { get; set; }
        public DataTable dttDoctor { get; set; }
        public DataTable dttRadiologist { get; set; }

        public int ScheduleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        private bool isAccpet;
        private DataTable dttWL;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private DataSet dtClinicalindicationtype = new DataSet();

        public frmWaitingList()
        {
            InitializeComponent();
        }
        private void frmWaitingList_Load(object sender, EventArgs e)
        {
            ribbonControl1.SelectedPage = rbbWaiting;
            initModality();
            grdData.DataSource = loadWaitingListData();
            setGridColumn();

            tmRefreshGrid.Interval = 60000;
            tmRefreshGrid.Enabled = true;

            isAccpet = false;
            view1.ActiveFilterString = "MODALITY_ID IN (" + ccbModality.EditValue + ")";

            //try
            //{
            //    ProcessGetClinicalIndicationType processClinicalindicationtype = new ProcessGetClinicalIndicationType();
            //    dtClinicalindicationtype = processClinicalindicationtype.GetClinicalIndicationType(env.OrgID, env.UserID);
            //}
            //catch { }
        }
        private void frmWaitingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isAccpet)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.Cancel;

            tmRefreshGrid.Enabled = false;
            bgRefreshGrid.Dispose();
        }
        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ccbModality.Text))
                view1.ActiveFilterString = "MODALITY_ID IN (" + ccbModality.EditValue + ")";
            view1.ActiveFilterEnabled = true;

            grdData.DataSource = loadWaitingListData();
        }

        #region Waiting List
        private void btnAccept_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isSelectRows())
            {
                if (msg.ShowAlert("UID1415", env.CurrentLanguageID) == "2")
                {
                    DataRow[] arryHandle = dttWL.Select("colCheck='Y'");
                    foreach (DataRow rowHandle in arryHandle)
                    {
                        //if (rowHandle["colCheck"].ToString() == "Y")
                        //{
                        int id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                        udpateBusy(id, "Y");
                        ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                        proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                        proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                        proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                        proc.UpdateWatingList();

                        saveLogs(id, "Accept Waiting(w)");
                        udpateBusy(id, "N");
                        //isAccpet = true;
                        //}
                    }
                }
            }

            grdData.DataSource = loadWaitingListData();
        }
        private void btnPending_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isSelectRows())
            {
                if (msg.ShowAlert("UID1415", env.CurrentLanguageID) == "2")
                {
                    foreach (DataRow rowHandle in dttWL.Rows)
                    {
                        if (rowHandle["colCheck"].ToString() == "Y")
                        {
                            Reason frmReason = new Reason(rowHandle["SCHEDULE_DATA"].ToString());
                            if (frmReason.ShowDialog() == DialogResult.OK)
                            {
                                int id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                                udpateBusy(id, "Y");
                                ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                                proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'P';
                                proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                                proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                                proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                                proc.UpdateWatingList();

                                proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                                proc.UpdatePendingComments();

                                saveLogs(id, "Update Pending(w)");

                                udpateBusy(id, "N");
                                isAccpet = true;
                            }
                        }
                    }
                }
            }
            grdData.DataSource = loadWaitingListData();
        }
        private void btnSummary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (rowHandle == null) return;
            frmPopupOrderOrScheduleSummary frm = new frmPopupOrderOrScheduleSummary();
            string HN = rowHandle["HN"].ToString();
            int id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
            frm.ShowDialog(true, HN, id, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false);
            frm.Dispose();
        }
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            env.Filter_PopupWaitinglistForm_Schedule = ccbModality.EditValue.ToString();
            this.Close();
        }
        #endregion
        #region Auto Appointment
        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            env.Filter_PopupWaitinglistForm_Schedule = ccbModality.EditValue.ToString();
            this.Close();
        }
        #endregion
        #region Pending List
        private void btnPendAccept_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isSelectRows())
            {
                if (msg.ShowAlert("UID1415", env.CurrentLanguageID) == "2")
                {
                    foreach (DataRow rowHandle in dttWL.Rows)
                    {
                        if (rowHandle["colCheck"].ToString() == "Y")
                        {
                            int id = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                            udpateBusy(id, "Y");
                            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                            proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                            proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                            proc.RIS_SCHEDULE.PENDING_BY = env.UserID;
                            proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                            proc.UpdatePending();
                            saveLogs(id, "Accept Pending(w)");
                            udpateBusy(id, "N");
                            isAccpet = true;
                        }
                    }
                }
            }
            grdData.DataSource = loadWaitingListData();
        }
        private void btnPendingClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            env.Filter_PopupWaitinglistForm_Schedule = ccbModality.EditValue.ToString();
            this.Close();
        }
        #endregion
        #region Online Stat Case
        private void initModality()
        {
            ccbModality.Properties.Items.Clear();
            ProcessGetRISModality procModality = new ProcessGetRISModality();
            procModality.Invoke();
            DataTable dt = procModality.Result.Tables[0];

            foreach (DataRow row in dt.Rows)
                ccbModality.Properties.Items.Add(row["MODALITY_ID"], row["MODALITY_NAME"].ToString(), CheckState.Checked, true);

            if (!string.IsNullOrEmpty(env.Filter_PopupWaitinglistForm_Schedule))
            {
                ccbModality.EditValue = env.Filter_PopupWaitinglistForm_Schedule;
                ccbModality.RefreshEditValue();
            }
        }
        private void barCloseStatCase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            env.Filter_PopupWaitinglistForm_Schedule = ccbModality.EditValue.ToString();
            this.Close();
        }
        private void ccbModality_EditValueChanged(object sender, EventArgs e)
        {
            view1.ActiveFilterString = "MODALITY_ID IN (" + ccbModality.EditValue + ")";
        }
        private void changeOrderToScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
                #region New Appontment.
                frmAppointment frm = new frmAppointment(row);
                frm.dttBpview = dttBpview;
                frm.dttDepartment = dttDepartment;
                frm.dttDoctor = dttDoctor;
                frm.dttRadiologist = dttRadiologist;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Text = "New - Appointment";
                frm.ShowDialog();
                frm.Hide();
                frm.Dispose();

                grdData.DataSource = loadWaitingListData();
                #endregion
            }
        }
        #endregion
        private bool isSelectRows()
        {
            bool flag = false;
            try
            {
                dttWL = (DataTable)grdData.DataSource;
                foreach (DataRow row in dttWL.Rows)
                    if (row["colCheck"].ToString() == "Y")
                    {
                        flag = true;
                        break;
                    }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        private bool checkIsBusy(int scheduleId)
        {
            bool flag = false;
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
            DataTable dtt = proc.GetBusyStatus();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                if (dtt.Rows[0]["IS_BUSY"].ToString() == "Y" && dtt.Rows[0]["BUSY_BY"].ToString() != env.UserID.ToString())
                    flag = true;
            }
            return flag;
        }
        private bool isWaitingList(int scheduleId)
        {
            bool flag = false;
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
            DataTable dtt = proc.GetBusyStatus();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                if (dtt.Rows[0]["SCHEDULE_STATUS"].ToString() == "W")
                    flag = true;
            }
            return flag;
        }
        private void udpateBusy(int scheduleId, string busy)
        {
            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = scheduleId;
            proc.RIS_SCHEDULE.IS_BUSY = busy;
            proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            proc.UpdateBusy();
        }

        private DataTable loadWaitingListData()
        {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            switch (ribbonControl1.SelectedPage.Name)
            {
                case "rbbWaiting":
                    dttWL = proc.GetWaitingList();
                    break;
                case "rbbAppOnline":
                    dttWL = proc.GetAppointOnline();
                    break;
                case "rbbPending":
                    dttWL = proc.GetPendingOnline();
                    break;
                case "rbbOnlineStat":
                    dttWL = proc.GetOnlineStatCase();
                    break;
            }
            dttWL.Columns.Add("colCheck", typeof(string));
            dttWL.AcceptChanges();

            return dttWL;
        }
        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)sender;
            if (chk == null) return;
            DataRow rowHandle = view1.GetDataRow(view1.FocusedRowHandle);
            if (chk.Checked)
                rowHandle["colCheck"] = "Y";
            else
                rowHandle["colCheck"] = "N";
        }
        private void setGridColumn()
        {
            for (int i = 0; i < dttWL.Columns.Count; i++)
            {
                view1.Columns[i].Visible = false;
                view1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            view1.OptionsView.ShowAutoFilterRow = true;
            view1.OptionsSelection.EnableAppearanceFocusedCell = false;
            view1.OptionsSelection.EnableAppearanceFocusedRow = true;

            view1.Columns["SCHEDULE_STATUS_TEXT"].GroupIndex = 1;
            view1.Columns["SCHEDULE_STATUS_TEXT"].Caption = "Priority";

            view1.Columns["colCheck"].VisibleIndex = 1;
            view1.Columns["colCheck"].Caption = " ";
            view1.Columns["colCheck"].OptionsColumn.AllowEdit = true;
            view1.Columns["colCheck"].Width = 30;
            DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chk = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            chk.ValueChecked = "Y";
            chk.ValueUnchecked = "N";
            chk.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Standard;
            chk.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            chk.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
            view1.Columns["colCheck"].ColumnEdit = chk;

            view1.Columns["CLINICAL_INSTRUCTION_TAG"].Visible = true;
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].ColVIndex = 2;
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].Caption = " ";
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].Width = 50;
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.ReadOnly = true;
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsColumn.AllowEdit = false;
            view1.Columns["CLINICAL_INSTRUCTION_TAG"].OptionsFilter.AllowFilter = false;

            view1.Columns["MIN_TEXT_THAI"].Visible = true;
            view1.Columns["MIN_TEXT_THAI"].Caption = "Wait";
            view1.Columns["MIN_TEXT_THAI"].Width = 90;
            view1.Columns["MIN_TEXT_THAI"].ColVIndex = 3;
            view1.Columns["MIN_TEXT_THAI"].Visible = true;

            view1.Columns["CREATED_ON"].Visible = true;
            view1.Columns["CREATED_ON"].Caption = "Created Datetime";
            view1.Columns["CREATED_ON"].ColVIndex = 4;
            view1.Columns["CREATED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["CREATED_ON"].Width = 100;

            view1.Columns["START_DATETIME"].Visible = true;
            view1.Columns["START_DATETIME"].Caption = "Start";
            view1.Columns["START_DATETIME"].ColVIndex = 5;
            view1.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["START_DATETIME"].Width = 100;

            view1.Columns["END_DATETIME"].Visible = true;
            view1.Columns["END_DATETIME"].Caption = "End";
            view1.Columns["END_DATETIME"].ColVIndex = 6;
            view1.Columns["END_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            view1.Columns["END_DATETIME"].Width = 100;

            RepositoryItemLookUpEdit repositoryItemLookUpEdit4 = new RepositoryItemLookUpEdit();
            repositoryItemLookUpEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            repositoryItemLookUpEdit4.ImmediatePopup = true;
            repositoryItemLookUpEdit4.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            repositoryItemLookUpEdit4.AutoHeight = false;
            repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MODALITY_NAME", "Modality", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None) });
            repositoryItemLookUpEdit4.DisplayMember = "MODALITY_NAME";
            repositoryItemLookUpEdit4.ValueMember = "MODALITY_ID";
            repositoryItemLookUpEdit4.DropDownRows = 5;
            repositoryItemLookUpEdit4.NullText = string.Empty;
            repositoryItemLookUpEdit4.DataSource = RISBaseData.Ris_Modality();
            repositoryItemLookUpEdit4.BestFit();
            repositoryItemLookUpEdit4.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            view1.Columns["MODALITY_ID"].Visible = true;
            view1.Columns["MODALITY_ID"].ColumnEdit = repositoryItemLookUpEdit4;
            view1.Columns["MODALITY_ID"].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            view1.Columns["MODALITY_ID"].ColVIndex = 7;
            view1.Columns["MODALITY_ID"].Caption = "Modality";

            view1.Columns["REF_UNIT_NAME"].Visible = true;
            view1.Columns["REF_UNIT_NAME"].Caption = "Ordering Dept";
            view1.Columns["REF_UNIT_NAME"].Width = 100;
            view1.Columns["REF_UNIT_NAME"].ColVIndex = 8;

            view1.Columns["PAT_DEST_LABEL"].Visible = true;
            view1.Columns["PAT_DEST_LABEL"].Caption = "Service Loc";
            view1.Columns["PAT_DEST_LABEL"].Width = 50;
            view1.Columns["PAT_DEST_LABEL"].ColVIndex = 9;


            DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit mem = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            mem.ScrollBars = ScrollBars.None;
            mem.LinesCount = 0;
            view1.Columns["SCHEDULE_DATA"].Visible = true;
            view1.Columns["SCHEDULE_DATA"].Caption = "Schedule Data";
            view1.Columns["SCHEDULE_DATA"].Width = 500;
            view1.Columns["SCHEDULE_DATA"].ColumnEdit = mem;
            view1.Columns["SCHEDULE_DATA"].ColVIndex = 10;
        }
        private void view1_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private void view1_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }
        private void view1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(e.RowHandle);
                if (dr != null)
                {
                    if (dr.Table.Columns.Contains("SCHEDULE_STATUS"))
                    {
                        if (dr["IS_ALERT_CLINICAL_INSTRUCTION"].ToString() == "Y")
                        {
                            e.Appearance.BackColor = Color.Tomato;
                            //e.Appearance.ForeColor = Color.White;
                        }
                        else
                        if (dr["SCHEDULE_STATUS"].ToString() == "V")
                            e.Appearance.BackColor = Color.LightPink;
                        else
                            e.Appearance.BackColor = SystemColors.Window;
                    }
                }
            }
        }

        private bool isHaveBlock(DataRow rowHandle)
        {
            bool flag = true;
            try
            {
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(rowHandle["SCHEDULE_ID"].ToString());
                schedule.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(rowHandle["MODALITY_ID"].ToString());
                schedule.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(rowHandle["START_DATETIME"].ToString());
                schedule.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(rowHandle["END_DATETIME"].ToString());
                schedule.RIS_SCHEDULE.IS_BLOCKED = 'N';
                DataTable dtt = new DataTable();
                dtt = schedule.CheckTime();
                flag = Miracle.Util.Utilities.IsHaveData(dtt) ? true : false;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private void view1_DoubleClick(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle < 0) return;
            DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
            if (ribbonControl1.SelectedPage == rbbOnlineStat)
                if (row["MODE"].ToString() != "Schedule")
                    return;
            ScheduleID = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
            StartTime = Convert.ToDateTime(row["START_DATETIME"].ToString());
            EndTime = Convert.ToDateTime(row["END_DATETIME"].ToString());
            DialogResult = DialogResult.OK;
            isAccpet = true;
        }

        private void bgRefreshGrid_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = loadWaitingListData();
        }

        private void bgRefreshGrid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Action a = () =>
            {
                this.dttWL = (DataTable)e.Result;
                this.grdData.DataSource = dttWL;
            };
            this.grdData.Invoke(a);

            tmRefreshGrid.Enabled = true;
        }

        private void tmRefreshGrid_Tick(object sender, EventArgs e)
        {
            tmRefreshGrid.Enabled = false;
            if (bgRefreshGrid.IsBusy == false)
                bgRefreshGrid.RunWorkerAsync();
            else
                tmRefreshGrid.Enabled = true;
        }

        #region Keep logs
        private void saveLogs(int schedule_id, string logs_desc)
        {
            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = schedule_id;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = env.UserID;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = 'U';
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = logs_desc;
            schLogs.Invoke();
            #endregion
        }
        #endregion

        private void contextList_Opening(object sender, CancelEventArgs e)
        {
            switch (ribbonControl1.SelectedPage.Name)
            {
                case "rbbOnlineStat":
                    changeOrderToScheduleToolStripMenuItem.Visible = true;
                    if (view1.FocusedRowHandle >= 0)
                    {
                        DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
                        if (row["NEED_SCHEDULE"].ToString() == "Y")
                            e.Cancel = false;
                        else
                            e.Cancel = true;
                    }
                    break;
                case "rbbWaiting":
                    commentWaitingListToolStripMenuItem.Visible = true;
                    break;
                case "rbbPending":
                    commentPendingToolStripMenuItem.Visible = true;
                    break;
                default: e.Cancel = true; break;
            }
        }

        private void commentWaitingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow row = view1.GetDataRow(view1.FocusedRowHandle);

                Reason frmReason = new Reason();
                try
                {
                    frmReason = new Reason(row["SCHEDULE_DATA"].ToString(), row["COMMENTS"].ToString());
                }
                catch
                {
                    frmReason = new Reason(row["SCHEDULE_DATA"].ToString());
                }
                
                if (frmReason.ShowDialog() == DialogResult.OK)
                {
                    int id = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
                    udpateBusy(id, "Y");
                    try
                    {
                        string schedule_data = "";
                        schedule_data += "HN : " + row["HN"].ToString() +
                            " " + row["PATIENT_NAME"].ToString() +
                            " " + row["EXAM_NAME"].ToString() + ";" +
                            " (" + frmReason.Comment + ");";

                        if (row["PENDING_COMMENTS"].ToString() != "")
                            schedule_data +=  " (" + row["PENDING_COMMENTS"].ToString() + ")"; ;

                        ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                        proc.RIS_SCHEDULE.SCHEDULE_DATA = schedule_data;
                        proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                        proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                        proc.UpdateWatingComments();
                    }
                    catch
                    {
                        ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                        proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                        proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                        proc.RIS_SCHEDULE.SCHEDULE_ID = id;

                        proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                        proc.UpdatePendingComments();
                    }
                    saveLogs(id, "Comment Waiting List(w)");

                    udpateBusy(id, "N");
                    isAccpet = true;
                }
            }

        }

        private void commentPendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow row = view1.GetDataRow(view1.FocusedRowHandle);
                Reason frmReason = new Reason(row["SCHEDULE_DATA"].ToString());
                if (frmReason.ShowDialog() == DialogResult.OK)
                {
                    int id = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
                    udpateBusy(id, "Y");
                    ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                    proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                    proc.RIS_SCHEDULE.SCHEDULE_ID = id;

                    proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                    proc.UpdatePendingComments();

                    saveLogs(id, "Comment Pending(w)");

                    udpateBusy(id, "N");
                    isAccpet = true;
                }
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            ToolTipControlInfo info = null;
            try
            {
                if (e.SelectedControl == grdData)
                {
                    GridView view = grdData.GetViewAt(e.ControlMousePosition) as GridView;
                    if (view == null) return;
                    GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
                    if (hi.InRowCell)
                    {
                        if (hi.RowHandle >= 0)
                        {
                            DataRow rowDetail = view.GetDataRow(hi.RowHandle);

                            switch (hi.Column.FieldName)
                            {
                                case "CLINICAL_INSTRUCTION_TAG":
                                    if (!string.IsNullOrEmpty(rowDetail["CLINICAL_INSTRUCTION_TAG"].ToString()))
                                    {
                                        try
                                        {
                                            string strinfo = string.Empty;
                                            string[] tag = rowDetail["CLINICAL_INSTRUCTION_TAG"].ToString().Split(',');
                                            DataTable dtCliType = dtClinicalindicationtype.Tables[0].Copy();

                                            foreach (string str in tag)
                                            {
                                                DataRow[] drClitype = dtCliType.Select("CI_TAG = '" + str + "'");
                                                if (drClitype.Length > 0)
                                                {
                                                    if (strinfo == string.Empty)
                                                        strinfo = drClitype[0]["CI_DESC"].ToString();
                                                    else
                                                        strinfo += "\r\n" + drClitype[0]["CI_DESC"].ToString();
                                                }
                                            }

                                            if (strinfo != string.Empty)
                                                info = new ToolTipControlInfo(new CellToolTipInfo(hi.RowHandle, hi.Column, "cell"), strinfo);

                                            return;
                                        }
                                        catch { return; }
                                    }
                                    break;
                            }
                        }
                    }
                    if (hi.HitTest == GridHitTest.Column)
                    {
                        switch (hi.Column.FieldName)
                        {
                            case "CLINICAL_INSTRUCTION_TAG": info = new ToolTipControlInfo(hi.HitTest, "Alert Code"); break;
                        }
                    }
                }
            }
            finally
            {
                e.Info = info;
            }
        }
    }
}
