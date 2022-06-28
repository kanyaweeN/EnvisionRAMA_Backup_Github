using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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
using Envision.Plugin.XtraFile.xtraReports;
using Miracle.Util;
using DevExpress.XtraScheduler.Services;
namespace Envision.NET.Forms.Schedule
{
    public partial class frmSchedule : Envision.NET.Forms.Main.MasterForm
    {
        private DataTable dttResource;
        private DataTable dttAppointment;
        private DataTable dttSession;
        private DataTable dttHNSearch;
        private DataTable dttModaltiy;
        private DataTable dttModalityExam;
        private DataTable dttScheduleSession;
        private DataTable dttScheduleSessionDetail;

        private int curr;
        private EnvisionSearchRangeType searchRange;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();

        private DataTable dttBpview, dttDepartment, dttDoctor, dttRadiologist, dtInsu;

        private bool drag_drop;
        private bool ready;
        private bool delete_recurrence;
        private string modalitySelect;
        private string reasonText, addTextInBlock;
        private DateTime currDT;
        private bool is_come = false;
        private int scheduleId = 0;
        private int pasteId = 0;
        private frmPopupOrderOrScheduleSummary _summary;
        private DataTable dttWL, dttAppOnline;
        private List<string> modalityId;
        private int posWL;

        private DateTime selected_start_duration = DateTime.Today;
        private DateTime selected_end_duration = DateTime.Today;
        private DateTime selected_date = DateTime.Today;
        private int selected_modality_id = 0;
        private bool selected_Freeslots = false;
        private DataView dv_scan_image = null;

        public frmSchedule()
        {
            InitializeComponent();

            //CreateAppointmentFormatStringService();
            //CreateTimeRulerFormatStringService();
            CreateHeaderCaptionService();
            //CreateHeaderToolTipService();

            //scControl.RemoveService(typeof(IAppointmentFormatStringService));
            //scControl.AddService(typeof(IAppointmentFormatStringService), customAppointmentFormatStringService);

            //scControl.RemoveService(typeof(ITimeRulerFormatStringService));
            //scControl.AddService(typeof(ITimeRulerFormatStringService), customTimeRulerFormatStringService);

            scControl.RemoveService(typeof(IHeaderCaptionService));
            scControl.AddService(typeof(IHeaderCaptionService), customHeaderCaptionService);

            //scControl.RemoveService(typeof(IHeaderToolTipService));
            //scControl.AddService(typeof(IHeaderToolTipService), customHeaderToolTipService);

            scControl.ActiveView.LayoutChanged();
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            env.ErrorForm = base.Menu_Name_Class;
            ProcessGetRISModality process = new ProcessGetRISModality(true);
            process.Invoke();
            dttModaltiy = process.Result.Tables[0].Copy();
            dttBpview = RISBaseData.BP_View();
            dttDepartment = RISBaseData.His_Department();
            dttDoctor = RISBaseData.His_Doctor();
            dttRadiologist = RISBaseData.Ris_Radiologist();
            dtInsu = RISBaseData.Ris_InsuranceType();

            initDataGridSession();
            initialModalityData();
            drag_drop = false;
            ready = false;
            delete_recurrence = false;
            scheduleId = 0;
            searchRange = EnvisionSearchRangeType.ThreeMonth;
            reasonText = string.Empty;
            xtraGridBlending1.GridControl.BackgroundImage = global::Envision.NET.Properties.Resources.gridBG;
            lblExam.Text = string.Empty;
            this._summary = new frmPopupOrderOrScheduleSummary();

            initNavigator();
            initailModalityExam();
            base.CloseWaitDialog();

            initialScheduler();
            base.ShowWaitDialog("Binding Schedule datasource", "Patient Schedule");
            initialScheduleDataByModality();
            base.CloseWaitDialog();
            ready = true;
            setWaittingListTimer(true);
            setInternalMessageTimer();
            setInternalRefresh();
            initWaitingListNavigator();

        }

        private void initialScheduler()
        {
            currDT = DateTime.Today;
            modalitySelect = string.Empty;
            //dateNav.DateTime = DateTime.Today;
            //dateNav.DateTime = DateTime.Today.AddMonths(1);
            //dateNav.DateTime = currDT;

            scControl.GroupType = SchedulerGroupType.Resource;
            scControl.Start = DateTime.Now;
            scControl.DayView.ShowAllDayArea = false;
            scControl.Storage.EnableReminders = false;
            scControl.DayView.ShowWorkTimeOnly = true;
            btnCheckTime.Checked = true;
        }
        private void initailModalityExam()
        {
            ProcessGetRISModalityexam procss = new ProcessGetRISModalityexam(true);
            procss.Invoke();
            dttModalityExam = new DataTable();
            dttModalityExam = procss.Result.Tables[0].Copy();
        }
        private void checkModalityCase()
        {
            if (chkList.CheckedItems.Count > 0)
            {
                int index = 0;
                for (; index < chkList.Items.Count; index++)
                {
                    if (chkList.GetItemChecked(index))
                        break;
                }
                setGridSessionSelect(scControl.ActiveView.SelectedResource.Caption);
            }
            else
                initDataGridSession();
        }
        private bool isModalityMapExam(int scheduleID, int modalityID)
        {
            bool flag = true;
            try
            {
                //ProcessGetRISScheduledtl process = new ProcessGetRISScheduledtl(scheduleID);
                //process.Invoke();
                //foreach (DataRow row in process.Result.Tables[0].Rows)
                //{
                //    DataRow[] dr = dttModalityExam.Select("MODALITY_ID=" + modalityID + " AND EXAM_ID=" + row["EXAM_ID"].ToString().Trim());
                //    flag = dr.Length == 0 ? false : true;
                //    if (flag==false)
                //        break;
                //}



                ProcessGetRISModalityexam procModality = new ProcessGetRISModalityexam(modalityID);
                procModality.Invoke();
                DataTable dttModality = procModality.Result.Tables[0].Copy();

                ProcessGetRISScheduledtl procSchedule = new ProcessGetRISScheduledtl(scheduleID);
                procSchedule.Invoke();
                DataTable dtt = procSchedule.Result.Tables[0].Copy();

                foreach (DataRow row in dtt.Rows)
                {
                    DataRow[] rows = dttModality.Select("IS_ACTIVE='Y' AND EXAM_ID=" + row["EXAM_ID"].ToString());
                    if (rows.Length == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        private bool isHaveBlock(int scheduleID, int modalityID, DateTime dtStart, DateTime dtEnd, char isBlock)
        {
            bool flag = true;
            try
            {
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                schedule.RIS_SCHEDULE.MODALITY_ID = modalityID;
                schedule.RIS_SCHEDULE.START_DATETIME = dtStart;
                schedule.RIS_SCHEDULE.END_DATETIME = dtEnd;
                schedule.RIS_SCHEDULE.IS_BLOCKED = isBlock;
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
        private bool isOverSession(int modalityID, int weekDay, DateTime dtStart, DateTime dtEnd)
        {
            bool flag = false;
            try
            {
                ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                process.RIS_CLINICSESSION.MODALITY_ID = modalityID;
                process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
                process.RIS_CLINICSESSION.WEEKDAYS = weekDay;
                process.Invoke();
                DataTable dtmp = process.GetClinicSession();
                int max_app = 0;
                int clinic_id = 0;
                foreach (DataRow row in dttSession.Rows)
                {
                    DateTime dtStartApp = Convert.ToDateTime(row["START_TIME"].ToString());
                    DateTime dtEndApp = Convert.ToDateTime(row["END_TIME"].ToString());
                    DateTime dtSt = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                    DateTime dtEn = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);
                    if ((dtStart >= dtSt) || (dtEnd <= dtEn))
                    {
                        clinic_id = Convert.ToInt32(row["SESSION_ID"].ToString());
                        break;
                    }
                }
                if (clinic_id > 0)
                {
                    DataRow[] drs = dtmp.Select("SESSION_ID=" + clinic_id.ToString());
                    max_app = Convert.ToInt32(drs[0]["MAX_APP"].ToString());
                    DateTime dtStartApp = Convert.ToDateTime(drs[0]["START_TIME"].ToString());
                    DateTime dtEndApp = Convert.ToDateTime(drs[0]["END_TIME"].ToString());
                    DateTime dtSt = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                    DateTime dtEn = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);

                    ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
                    procSC.RIS_SCHEDULE.MODALITY_ID = process.RIS_CLINICSESSION.MODALITY_ID;
                    procSC.RIS_SCHEDULE.START_DATETIME = dtSt;
                    procSC.RIS_SCHEDULE.END_DATETIME = dtEn;
                    dtmp = new DataTable();
                    dtmp = procSC.GetSessionCount();
                    int curr_app = 0;
                    if (dtmp != null)
                    {
                        if (dtmp.Rows.Count > 0)
                            curr_app = Convert.ToInt32(dtmp.Rows[0]["AMT"].ToString());
                    }
                    if (curr_app > max_app) flag = true;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        #region Initail Resource and Appointment.
        private void initialModalityData()
        {
            #region Show All modality with all user
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //dttResource = process.GetModality();
            #endregion
            #region Show modality with User
            ProcessGetRISScheduleDefaultDestination procDestiantion = new ProcessGetRISScheduleDefaultDestination();
            procDestiantion.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
            procDestiantion.Invoke();
            if (Miracle.Util.Utilities.IsHaveData(procDestiantion.Result))
            {
                DataTable dtt = new DataTable();
                ProcessGetRISModality procModality = new ProcessGetRISModality();
                procModality.Invoke();
                dtt = procModality.Result.Tables[0];
                dttResource = dtt.Clone();
                dttResource.AcceptChanges();

                foreach (DataRow rowHandle in procDestiantion.Result.Tables[1].Rows)
                {
                    DataView dv = new DataView(dtt);
                    dv.RowFilter = "MODALITY_ID=" + rowHandle["MODALITY_ID"].ToString();
                    DataTable dttTemp = dv.ToTable();
                    if (dttTemp.Rows.Count > 0)
                    {
                        DataRow row = dttResource.NewRow();
                        for (int i = 0; i < dttTemp.Columns.Count; i++)
                            row[i] = dttTemp.Rows[0][i];
                        dttResource.Rows.Add(row);
                    }
                    dttResource.AcceptChanges();
                }
                if (dttResource.Rows.Count == 0)
                {
                    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                    dttResource = process.GetModality();
                }
            }
            else
            {
                ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                dttResource = process.GetModality();
            }
            #endregion

            ccbModality.Properties.Items.Clear();
            foreach (DataRow row in dttResource.Rows)
                ccbModality.Properties.Items.Add(row["MODALITY_ID"], row["MODALITY_NAME"].ToString(), CheckState.Checked, true);

            if (!string.IsNullOrEmpty(env.Filter_PopupWaitinglistForm_Schedule))
            {
                ccbModality.EditValue = env.Filter_PopupWaitinglistForm_Schedule;
                ccbModality.RefreshEditValue();
            }
        }
        private void ccbModality_EditValueChanged(object sender, EventArgs e)
        {
            env.Filter_PopupWaitinglistForm_Schedule = ccbModality.EditValue.ToString();
            viewScheduleOnl.ActiveFilterString = "MODALITY_ID IN (" + ccbModality.EditValue + ")";
        }
        private void initialScheduleData()
        {
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //process.RIS_SCHEDULE.TYPE = (int)searchRange;
            //dttAppointment = process.GetScheduleData();
            ////dttAppointment = process.GetDataTest();

            bool reload_schedule = false;
            bool reload_session = false;

            if (selected_start_duration != dateNav.SelectionStart.Date
                || selected_end_duration != dateNav.SelectionEnd.Date)
            {
                reload_schedule = true;

                if (dateNav.SelectionStart.Date > dateNav.SelectionEnd.Date)
                {
                    selected_start_duration = dateNav.SelectionEnd.Date;
                    selected_end_duration = dateNav.SelectionStart.Date;
                }
                else
                {
                    selected_start_duration = dateNav.SelectionStart.Date;
                    selected_end_duration = dateNav.SelectionEnd.Date;
                }
            }

            if (selected_date != scControl.SelectedInterval.Start.Date)
            {
                reload_session = true;

                selected_date = scControl.SelectedInterval.Start.Date;
            }

            if (scControl.SelectedResource.Caption == "(Any)")
            {
                reload_session = true;

                selected_modality_id = 0;
            }
            else if (Convert.ToInt32(scControl.SelectedResource.Id) != selected_modality_id)
            {
                reload_session = true;

                selected_modality_id = Convert.ToInt32(scControl.SelectedResource.Id);
            }

            if (reload_session)
            {
                setGridSessionSelect(scControl.ActiveView.SelectedResource.Caption);
            }
            if (dttAppointment == null)
            {
                reload_schedule = true;
            }
            if (reload_schedule)
            {
                base.ShowWaitDialog("Load schedule datasource", "Patient Schedule");
                loadControlSchedule();
                base.CloseWaitDialog();
            }

        }
        private void loadControlSchedule()
        {
            ProcessGetRISSchedule prc = new ProcessGetRISSchedule();
            prc.RIS_SCHEDULE.ORG_ID = env.OrgID;
            prc.InvokeWorklist(selected_start_duration, selected_end_duration);
            dttAppointment = prc.Result.Tables[0];

            scControl.Storage.Appointments.BeginUpdate();
            try
            {
                scControl.Storage.Appointments.DataSource = null;
                if (Utilities.IsHaveData(prc.Result))
                    scControl.Storage.Appointments.DataSource = prc.Result.Tables[0].DefaultView;

                scControl.Storage.RefreshData();
            }
            finally
            {
                scControl.Storage.Appointments.EndUpdate();
            }

        }

        private void initialResourceControl()
        {
            schedulerStorage1.Resources.Mappings.Id = "MODALITY_ID";
            schedulerStorage1.Resources.Mappings.Caption = "MODALITY_NAME";
            schedulerStorage1.Resources.DataSource = dttResource;

            for (int i = 0; i < chkList.Items.Count; i++)
                chkList.SetItemChecked(i, false);
        }
        private void initialAppointmentMapping()
        {
            schedulerStorage1.Appointments.Mappings.ResourceId = "MODALITY_ID";
            schedulerStorage1.Appointments.Mappings.Start = "START_DATETIME";
            schedulerStorage1.Appointments.Mappings.End = "END_DATETIME";
            schedulerStorage1.Appointments.Mappings.Location = "SCHEDULE_ID";
            schedulerStorage1.Appointments.Mappings.Subject = "SCHEDULE_DATA";

            // schedulerStorage1.Appointments.Mappings.Description = "SCHEDULE_DATA";
            schedulerStorage1.Appointments.Mappings.AllDay = "ALLDAY";
            schedulerStorage1.Appointments.Mappings.Label = "LABEL";
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RECURRENCEINFO";
            schedulerStorage1.Appointments.Mappings.Status = "STATUS";
            schedulerStorage1.Appointments.Mappings.Type = "EVENTTYPE";


            schedulerStorage1.Appointments.CustomFieldMappings.AddRange(
                new AppointmentCustomFieldMapping[] {
                            new AppointmentCustomFieldMapping("CommandType", "CommandType"),
                            new AppointmentCustomFieldMapping("SCHEDULE_ID", "SCHEDULE_ID"),
                            new AppointmentCustomFieldMapping("SCHEDULE_STATUS", "SCHEDULE_STATUS"),
                            new AppointmentCustomFieldMapping("MODALITY_ID", "MODALITY_ID"),
                            new AppointmentCustomFieldMapping("START_DATETIME", "START_DATETIME"),
                            new AppointmentCustomFieldMapping("END_DATETIME", "END_DATETIME"),
                            new AppointmentCustomFieldMapping("HN", "HN"),
                            new AppointmentCustomFieldMapping("LOCATION", "LOCATION"),
                            new AppointmentCustomFieldMapping("IS_BLOCKED", "IS_BLOCKED"),
                            new AppointmentCustomFieldMapping("HAS_COMMENTS", "HAS_COMMENTS"),
                            new AppointmentCustomFieldMapping("PREPARATION_DESC", "PREPARATION_DESC"),
                            new AppointmentCustomFieldMapping("REF_UNIT", "REF_UNIT"),
                            new AppointmentCustomFieldMapping("IS_ALERT_CLINICAL_INSTRUCTION", "IS_ALERT_CLINICAL_INSTRUCTION"),
                            new AppointmentCustomFieldMapping("IS_TELEMED", "IS_TELEMED")
                        }
                );
        }
        private void initialAppointmentControl()
        {
            schedulerStorage1.Appointments.DataSource = dttAppointment;
        }

        private DataTable ToDataTable<T>(List<T> items)
        {

            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        #endregion

        #region HN Search.
        private void initNavigator()
        {
            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMovePrev.Enabled = false;
            txtHNSearch.Text = string.Empty;
            lblResult.Text = "Please key-in HN.";
        }
        private void searchSchedule()
        {
            tmRefresh.Stop();
            try
            {
                if (txtHNSearch.Text.Trim().Length == 0)
                {
                    curr = 0;
                    enableDisableNavigator(false);
                    lblExam.Text = string.Empty;
                    lblResult.Text = "Please key-in HN.";
                    return;
                }
                if (txtHNSearch.Text.Trim().Length == 0)
                {
                    curr = 0;
                    enableDisableNavigator(false);
                    lblExam.Text = string.Empty;
                    lblResult.Text = "Please key-in HN.";
                    return;
                }



                // int selectIndex = rdoRange.SelectedIndex == 0 ? 1 : rdoRange.SelectedIndex == 1 ? 2 : 3;
                int selectIndex = cboRange.SelectedIndex + 1;
                int searchR = (int)searchRange;
                if (selectIndex > searchR)
                {
                    if ("2" == msg.ShowAlert("UID1137", env.CurrentLanguageID))
                    //if (DialogResult.Yes == MessageBox.Show("มีการเปลี่ยนช่วงเวลาในการค้นหานัดทำให้ต้องปรับปรุงข้อมูลการนัดในโปรแกรม  ต้องการค้นหาข้อมูลการนัดของคนไข้ใช่หรือไม่", "ปรับปรุงข้อมูลนัด", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                    {
                        searchRange = (EnvisionSearchRangeType)selectIndex;
                        searchR = selectIndex;
                        initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                    }
                    else
                    {
                        curr = 0;
                        enableDisableNavigator(false);
                        lblExam.Text = string.Empty;
                        lblResult.Text = "Please key-in HN.";
                        return;
                    }
                }

                enableDisableNavigator(true);
                ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                process.RIS_SCHEDULE.TYPE = searchR;
                process.RIS_SCHEDULE.HN = txtHNSearch.Text;
                DataSet ds = process.GetByHN();
                dttHNSearch = new DataTable();
                dttHNSearch = ds.Tables[0];
                DataTable dttHNHistory = ds.Tables[1];
                if (dttHNSearch.Rows.Count == 0)
                {
                    curr = 0;
                    lblExam.Text = string.Empty;
                    enableDisableNavigator(false);
                    lblResult.Text = "Schedule(s) not found.";


                    if (dttHNHistory.Rows.Count > 0)
                    {
                        frmAppointmentHistory frm = new frmAppointmentHistory(ds);
                        frm.ShowDialog();
                        int id = frm.SCHEDULE_ID;
                        frm.Dispose();
                        if (id > 0)
                            scheduleNavigator(dttHNHistory, id);
                    }

                }
                else if (dttHNSearch.Rows.Count == 1)
                {
                    curr = 0;
                    //int schedule_id = Convert.ToInt32(dttHNSearch.Rows[curr]["SCHEDULE_ID"]);
                    //if (schedule_id > 0)
                    //{
                    //    DateTime dtFrom = Convert.ToDateTime(dttHNSearch.Rows[curr]["START_DATETIME"].ToString());
                    //    DateTime dtTO = Convert.ToDateTime(dttHNSearch.Rows[curr]["END_DATETIME"].ToString());
                    //    dateNav.DateTime = dtFrom;
                    //    initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                    //    scheduleNavigator(schedule_id, dtFrom, dtTO);
                    //}

                    //enableDisableNavigator(false);
                    lblResult.Text = "1 schedule found for this HN.";
                    frmAppointmentHistory frm = new frmAppointmentHistory(ds);
                    frm.ShowDialog();
                    int id = frm.SCHEDULE_ID;
                    frm.Dispose();
                    if (id > 0)
                    {
                        if (frm.SELECT_MODE == 0)
                            scheduleNavigator(dttHNSearch, id);
                        else
                            scheduleNavigator(dttHNHistory, id);
                    }
                }
                else
                {
                    curr = 0;

                    lblResult.Text = dttHNSearch.Rows.Count + " schedule(s) found for this HN.";
                    frmAppointmentHistory frm = new frmAppointmentHistory(ds);
                    frm.ShowDialog();
                    int id = frm.SCHEDULE_ID;
                    frm.Dispose();
                    if (id > 0)
                    {
                        if (frm.SELECT_MODE == 0)
                            scheduleNavigator(dttHNSearch, id);
                        else
                            scheduleNavigator(dttHNHistory, id);
                    }

                }
            }
            catch
            {
                DataTable dtt = dttHNSearch.Clone();
                dttHNSearch = null;
                dttHNSearch = dtt;
                curr = 0;
                enableDisableNavigator(false);
                lblExam.Text = string.Empty;
                txtHNSearch.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
            }
            tmRefresh.Start();
        }

        private void scheduleNavigator()
        {
            scControl.DayView.ShowWorkTimeOnly = false;
            btnCheckTime.Checked = false;
            lblExam.Text = dttHNSearch.Rows[curr]["EXAM_NAME"].ToString();
            DateTime dtFrom = Convert.ToDateTime(dttHNSearch.Rows[curr]["START_DATETIME"].ToString());
            DateTime dtTO = Convert.ToDateTime(dttHNSearch.Rows[curr]["END_DATETIME"].ToString());
            int schedule_id = Convert.ToInt32(dttHNSearch.Rows[curr]["SCHEDULE_ID"].ToString());
            dateNav.DateTime = dtFrom;
            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            scheduleNavigator(schedule_id, dtFrom, dtTO);
        }
        private void scheduleNavigator(DataTable dataSource, int Schedule_id)
        {
            for (int i = 0; i < dataSource.Rows.Count; i++)
                if (dataSource.Rows[i]["SCHEDULE_ID"].ToString() == Schedule_id.ToString())
                {
                    curr = i;
                    break;
                }
            int schedule_id = Convert.ToInt32(dataSource.Rows[curr]["SCHEDULE_ID"]);
            if (schedule_id > 0)
            {
                DateTime dtFrom = Convert.ToDateTime(dataSource.Rows[curr]["START_DATETIME"].ToString());
                DateTime dtTO = Convert.ToDateTime(dataSource.Rows[curr]["END_DATETIME"].ToString());
                dateNav.DateTime = dtFrom;
                initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                scheduleNavigator(schedule_id, dtFrom, dtTO);
            }
        }
        private void enableDisableNavigator(bool flag)
        {
            btnMoveFirst.Enabled = flag;
            btnMoveLast.Enabled = flag;
            btnMoveNext.Enabled = flag;
            btnMovePrev.Enabled = flag;
        }

        private void txtHNSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchSchedule();
            else if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (string.IsNullOrEmpty(txtHNSearch.Text.Trim()))
                {
                    lblExam.Text = string.Empty;
                    lblResult.Text = "Please key-in HN.";
                }
            }
        }
        private void txtHNSearch_Validated(object sender, EventArgs e)
        {
            if (txtHNSearch.Text.Trim().Length == 0)
            {
                lblExam.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
            }
        }
        private void txtHNSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 47) e.Handled = true;
            else if (txtHNSearch.Text.Trim().Length == 0)
            {
                lblExam.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
            }
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            curr = 0;
            scheduleNavigator();
        }
        private void btnMovePrev_Click(object sender, EventArgs e)
        {
            curr--;
            curr = curr < 0 ? 0 : curr;
            scheduleNavigator();
        }
        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            curr++;
            curr = curr >= dttHNSearch.Rows.Count ? dttHNSearch.Rows.Count - 1 : curr;
            scheduleNavigator();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            curr = dttHNSearch.Rows.Count - 1;
            scheduleNavigator();
        }


        #endregion

        #region Initial Session Data.
        private void initDataGridSession()
        {
            dttScheduleSession = new DataTable();
            dttScheduleSession.Columns.Add("CLINIC");
            dttScheduleSession.Columns.Add("MORNING");
            dttScheduleSession.Columns.Add("AFTERNOON");
            dttScheduleSession.Columns.Add("EVENING");

            dttScheduleSession.Columns.Add("MORNING_START", typeof(DateTime));
            dttScheduleSession.Columns.Add("MORNING_END", typeof(DateTime));
            dttScheduleSession.Columns.Add("AFTERNOON_START", typeof(DateTime));
            dttScheduleSession.Columns.Add("AFTERNOON_END", typeof(DateTime));
            dttScheduleSession.Columns.Add("EVENING_START", typeof(DateTime));
            dttScheduleSession.Columns.Add("EVENING_END", typeof(DateTime));

            dttScheduleSession.AcceptChanges();
            dttScheduleSession.Rows.Add("ในเวลา", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            dttScheduleSession.Rows.Add("คลินิกพิเศษ", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            dttScheduleSession.Rows.Add("คลินิกพรีเมี่ยม", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            dttScheduleSession.Rows.Add("CNMI", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            dttScheduleSession.Rows.Add("AIMC", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
            dttScheduleSession.AcceptChanges();

            setGridSession(dttScheduleSession);
        }
        private void setGridSession(DataTable dtt)
        {
            if (dtt == null) return;
            grdSchedule.DataSource = dtt;
            if (view1.Columns.Count == 0) return;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["CLINIC"].Visible = true;
            view1.Columns["CLINIC"].Width = 100;
            view1.Columns["CLINIC"].Caption = " ";
            view1.Columns["CLINIC"].VisibleIndex = 1;

            view1.Columns["MORNING"].Visible = true;
            view1.Columns["MORNING"].Width = 50;
            view1.Columns["MORNING"].Caption = "เช้า";
            view1.Columns["MORNING"].VisibleIndex = 2;

            view1.Columns["AFTERNOON"].Visible = true;
            view1.Columns["AFTERNOON"].Width = 50;
            view1.Columns["AFTERNOON"].Caption = "บ่าย";
            view1.Columns["AFTERNOON"].VisibleIndex = 3;

            view1.Columns["EVENING"].Visible = true;
            view1.Columns["EVENING"].Width = 50;
            view1.Columns["EVENING"].Caption = "เย็น";
            view1.Columns["EVENING"].VisibleIndex = 4;


        }
        private void setGridSessionSelect(string ModalityName)
        {
            if (ready)
            {
                if (ModalityName == "(Any)") return;
                DayOfWeek df = dateNav.SelectionStart.DayOfWeek;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int id = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());
                ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                process.RIS_CLINICSESSION.MODALITY_ID = id;
                process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
                process.RIS_CLINICSESSION.WEEKDAYS = Convert.ToInt32(df);
                DataTable dtt = process.GetClinicSession();

                initDataGridSession();
                foreach (DataRow dr in dtt.Rows)
                {
                    DateTime tmp = Convert.ToDateTime(dr["START_TIME"].ToString());
                    DateTime start = new DateTime(dateNav.SchedulerControl.SelectedInterval.Start.Year, dateNav.SchedulerControl.SelectedInterval.Start.Month, dateNav.SchedulerControl.SelectedInterval.Start.Day, tmp.Hour, tmp.Minute, tmp.Second);
                    tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                    DateTime end = new DateTime(dateNav.SchedulerControl.SelectedInterval.Start.Year, dateNav.SchedulerControl.SelectedInterval.Start.Month, dateNav.SchedulerControl.SelectedInterval.Start.Day, tmp.Hour, tmp.Minute, tmp.Second);

                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                    proc.RIS_SCHEDULE.MODALITY_ID = id;
                    // proc.RIS_SCHEDULE.APPOINT_DT = start;
                    proc.RIS_SCHEDULE.START_DATETIME = start;
                    proc.RIS_SCHEDULE.END_DATETIME = end;
                    proc.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dr["SESSION_ID"]);
                    DataSet dsmp = proc.GetSessionShow();
                    dr["APP"] = dsmp.Tables[0].Rows[0][0].ToString() + "/" + dr["MAX_APP"].ToString() + " : " + dsmp.Tables[1].Rows[0][0].ToString();
                    switch (dr["SESSION_UID"].ToString().ToUpper())
                    {
                        case "RM":
                            dttScheduleSession.Rows[0][1] = calculateSessionSelected(dttScheduleSession.Rows[0][1].ToString(), dsmp.Tables[0].Rows[0][0].ToString(), dr["MAX_APP"].ToString(), dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[0][4] = start;
                            dttScheduleSession.Rows[0][5] = end;

                            break;
                        case "RA":
                            dttScheduleSession.Rows[0][2] = calculateSessionSelected(dttScheduleSession.Rows[0][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[0][6] = start;
                            dttScheduleSession.Rows[0][7] = end;
                            break;
                        case "RE":
                            dttScheduleSession.Rows[0][3] = calculateSessionSelected(dttScheduleSession.Rows[0][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() ,dr["MAX_APP"].ToString(), dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[0][8] = start;
                            dttScheduleSession.Rows[0][9] = end;
                            break;

                        case "SM":
                            dttScheduleSession.Rows[1][1] = calculateSessionSelected(dttScheduleSession.Rows[1][1].ToString(), dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[1][4] = start;
                            dttScheduleSession.Rows[1][5] = end;
                            break;
                        case "SA":
                            dttScheduleSession.Rows[1][2] = calculateSessionSelected(dttScheduleSession.Rows[1][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString(), dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[1][6] = start;
                            dttScheduleSession.Rows[1][7] = end;
                            break;
                        case "SE":
                            dttScheduleSession.Rows[1][3] = calculateSessionSelected(dttScheduleSession.Rows[1][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() ,dr["MAX_APP"].ToString(), dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[1][8] = start;
                            dttScheduleSession.Rows[1][9] = end;
                            break;
                        case "PM":
                            dttScheduleSession.Rows[2][1] = calculateSessionSelected(dttScheduleSession.Rows[2][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString() ,dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[2][4] = start;
                            dttScheduleSession.Rows[2][5] = end;
                            break;
                        case "PA":
                            dttScheduleSession.Rows[2][2] = calculateSessionSelected(dttScheduleSession.Rows[2][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[2][6] = start;
                            dttScheduleSession.Rows[2][7] = end;
                            break;
                        case "PE":
                            dttScheduleSession.Rows[2][3] = calculateSessionSelected(dttScheduleSession.Rows[2][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() ,dr["MAX_APP"].ToString() ,dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[2][8] = start;
                            dttScheduleSession.Rows[2][9] = end;
                            break;
                        case "CM":
                            dttScheduleSession.Rows[3][1] = calculateSessionSelected(dttScheduleSession.Rows[3][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[3][4] = start;
                            dttScheduleSession.Rows[3][5] = end;
                            break;
                        case "CA":
                            dttScheduleSession.Rows[3][2] = calculateSessionSelected(dttScheduleSession.Rows[3][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[3][6] = start;
                            dttScheduleSession.Rows[3][7] = end;
                            break;
                        case "CE":
                            dttScheduleSession.Rows[3][3] = calculateSessionSelected(dttScheduleSession.Rows[3][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[3][8] = start;
                            dttScheduleSession.Rows[3][9] = end;
                            break;
                        case "AA":
                            dttScheduleSession.Rows[4][1] = calculateSessionSelected(dttScheduleSession.Rows[4][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString() ,dr["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                            dttScheduleSession.Rows[4][4] = start;
                            dttScheduleSession.Rows[4][5] = end;
                            break;

                    }
                    dttScheduleSession.AcceptChanges();
                }
                dttScheduleSessionDetail = dtt.Copy();
                grdSchedule.DataSource = dttScheduleSession;
            }
        }
        private string calculateSessionSelected(string summarySession, string countApp, string countMaxApp, string countBlock)
        {
            string _temp = "";

            string _countApp = summarySession.Substring(0, summarySession.IndexOf('/')).Trim();
            string _countMaxApp = summarySession.Substring(summarySession.IndexOf('/'), summarySession.IndexOf(':') - summarySession.IndexOf('/')).Substring(1).Trim();
            string _countBlock = summarySession.Substring(summarySession.IndexOf(':')).Substring(1).Trim();

            int _totalApp = Convert.ToInt32(_countApp) + Convert.ToInt32(countApp);
            int _totalMax = Convert.ToInt32(_countMaxApp) + Convert.ToInt32(countMaxApp);
            int _totalBlock = Convert.ToInt32(_countBlock) + Convert.ToInt32(countBlock);
            _temp = _totalApp.ToString() + "/" + _totalMax.ToString() + " : " + _totalBlock.ToString();

            return _temp;
        }
        private void view1_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                string ModalityName = scControl.ActiveView.SelectedResource.Caption;
                if (ModalityName == "(Any)") return;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int ModalityId = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());

                DateTime dtSeStart = new DateTime();
                DateTime dtSeEnd = new DateTime();
                DateTime dt = dateNav.SelectionStart;
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                switch (view1.FocusedColumn.ColumnHandle)
                {
                    case 1:
                        dtSeStart = Convert.ToDateTime(dr["MORNING_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["MORNING_END"]);
                        break;
                    case 2:
                        dtSeStart = Convert.ToDateTime(dr["AFTERNOON_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["AFTERNOON_END"]);
                        break;
                    case 3:
                        dtSeStart = Convert.ToDateTime(dr["EVENING_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["EVENING_END"]);
                        break;
                }

                if (!dr.IsNull(0))
                {

                    DateTime dtFrom = new DateTime(dt.Year, dt.Month, dt.Day, dtSeStart.Hour, dtSeStart.Minute, dtSeStart.Second);
                    DateTime dtEnd = new DateTime(dt.Year, dt.Month, dt.Day, dtSeEnd.Hour, dtSeEnd.Minute, dtSeEnd.Second);
                    int session_id = 0;
                    string session_desc = dr["CLINIC"].ToString();
                    switch (dr["CLINIC"].ToString())
                    {
                        case "ในเวลา":
                            switch (view1.FocusedColumn.Caption)
                            {
                                case "เช้า": session_id = 2; session_desc += ">เช้า"; break;
                                case "บ่าย": session_id = 3; session_desc += ">บ่าย"; break;
                                case "เย็น": session_id = 9; session_desc += ">เย็น"; break;
                                default: popupSessionDetail("R"); break;
                            }
                            break;
                        case "คลินิกพิเศษ":
                            switch (view1.FocusedColumn.Caption)
                            {
                                case "เช้า": session_id = 1; session_desc += ">เช้า"; break;
                                case "บ่าย": session_id = 8; session_desc += ">บ่าย"; break;
                                case "เย็น": session_id = 4; session_desc += ">เย็น"; break;
                                default: popupSessionDetail("S"); break;
                            }
                            break;
                        case "คลินิกพรีเมี่ยม":
                            switch (view1.FocusedColumn.Caption)
                            {
                                case "เช้า": session_id = 5; session_desc += ">เช้า"; break;
                                case "บ่าย": session_id = 6; session_desc += ">บ่าย"; break;
                                case "เย็น": session_id = 7; session_desc += ">เย็น"; break;
                                default: popupSessionDetail("P"); break;
                            }
                            break;
                    }
                    base.LabelWaitDialog("Create Reporting");

                    ProcessGetRptScheduleCountAppoint getRpt = new ProcessGetRptScheduleCountAppoint();
                    getRpt.ReportParameters.Session = session_id;
                    getRpt.ReportParameters.ModalityId = ModalityId;
                    getRpt.ReportParameters.FromDate = dtFrom;
                    getRpt.ReportParameters.ToDate = dtEnd;
                    getRpt.InvokeWithSession();
                    DataTable dtXrpt = new DataTable();
                    dtXrpt = getRpt.Result.Tables[0];
                    if (dtXrpt.Rows.Count > 0)
                    {
                        Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint rptSCA = new Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint("Modality : " + ModalityName + " > " + session_desc);
                        rptSCA.DataSource = dtXrpt;
                        rptSCA.ShowPreviewMarginLines = false;
                        rptSCA.ShowPreview();
                    }
                    base.CloseWaitDialog();

                }

            }
        }
        private void popupSessionDetail(string sessionUid)
        {
            DataRow[] rowsPopoup = dttScheduleSessionDetail.Select("SESSION_UID like '" + sessionUid + "%'");
            DataView dv = rowsPopoup.CopyToDataTable().DefaultView;
            dv.Sort = "SL_NO";
            DataTable sortedDT = dv.ToTable();
            string popDetail = "";
            foreach (DataRow rowPopDetail in sortedDT.Rows)
                popDetail += rowPopDetail["SESSION_NAME"].ToString() + " : \t\t" + rowPopDetail["APP"].ToString() + "\r\n\r\n";

            if (!string.IsNullOrEmpty(popDetail))
                MessageBox.Show(popDetail, "Session Detail", MessageBoxButtons.OK);
        }
        #endregion

        #region Schedule Control.
        private void scControl_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e)
        {
            tmRefresh.Stop();
            //This event for check condition for only drag_drop before schedulerStorage1_AppointmentChanging occur
            string status = string.Empty;
            int Id = -1;
            try
            {
                #region GetAppontment Information.
                DateTime start = e.EditedAppointment.Start;
                DateTime end = e.EditedAppointment.End;
                status = e.EditedAppointment.CustomFields[2].ToString();
                Id = Convert.ToInt32(e.EditedAppointment.CustomFields[1].ToString());
                if (checkIsBusy(Id))
                {
                    msg.ShowAlert("UID1417", env.CurrentLanguageID);
                    e.Allow = false;
                    e.Handled = true;
                    drag_drop = false;
                    setWaittingListTimer(false);
                    return;
                }
                if (status == "X") return;
                if (status == "W")
                {
                    tmWaitingList.Stop();
                    tmRefresh.Stop();
                    udpateBusy(Id, "Y");
                }
                else
                {
                    if (start < DateTime.Now)
                    {
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                }
                int scheduleID = 0;
                if (e.SourceAppointment.IsRecurring)
                {
                    if (string.IsNullOrEmpty(e.EditedAppointment.CustomFields["LOCATION"].ToString()))
                        scheduleID = Convert.ToInt32(e.EditedAppointment.Location);
                    else
                        scheduleID = Convert.ToInt32(e.EditedAppointment.CustomFields["LOCATION"].ToString());
                }
                else
                    scheduleID = Convert.ToInt32(e.EditedAppointment.Location);
                int weekend = Convert.ToInt32(e.EditedAppointment.Start.DayOfWeek);
                string hn = e.EditedAppointment.CustomFields["HN"].ToString();
                int modalityID = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
                string block = e.EditedAppointment.CustomFields["IS_BLOCKED"].ToString();
                #endregion

                if (block == "Y")
                {
                    #region Block Condition.
                    if (isHaveBlock(scheduleID, modalityID, e.EditedAppointment.Start, e.EditedAppointment.End, 'Y'))
                    {
                        string s = msg.ShowAlert("UID1108", env.CurrentLanguageID);//UID1107
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        setWaittingListTimer(false);
                        return;
                    }
                    drag_drop = true;
                    #endregion
                }
                else
                {
                    #region Change Modality - Check ExamMapping.
                    if (e.SourceAppointment.ResourceId.ToString().Trim() != e.EditedAppointment.ResourceId.ToString().Trim())
                    {
                        //This case for appointment change modality 
                        //the logic need tocheck exam in appointment have the new modality or not
                        if (e.SourceAppointment.IsRecurring)
                        {
                            msg.ShowAlert("UID1136", env.CurrentLanguageID);
                            e.Allow = false;
                            e.Handled = true;
                            drag_drop = false;
                            return;
                        }
                        int newModality = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString().Trim());
                        if (!isModalityMapExam(scheduleID, modalityID))
                        {
                            string s = msg.ShowAlert("UID1106", env.CurrentLanguageID);
                            e.Allow = false;
                            e.Handled = true;
                            drag_drop = false;
                            return;
                        }
                        modalityID = newModality;
                    }
                    #endregion

                    #region Check this appoinment conflict with block.
                    if (isHaveBlock(scheduleID, modalityID, e.EditedAppointment.Start, e.EditedAppointment.End, 'N'))
                    {
                        string s = msg.ShowAlert("UID1107", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    #endregion

                    #region Check patient conflict.
                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule(scheduleID);
                    proc.Invoke();
                    DataTable dttExam = new DataTable();
                    dttExam = proc.Result.Tables[1].Copy();

                    if (checkConflict(dttExam, hn, e.EditedAppointment.Start))
                    {
                        //string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    #endregion

                    #region Check Session.
                    if (isOverSession(modalityID, weekend, e.EditedAppointment.Start, e.EditedAppointment.End))
                    {
                        if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                        {
                            e.Allow = false;
                            e.Handled = true;
                            drag_drop = false;
                            return;
                        }
                    }
                    #endregion
                }
                ConfirmDialog confrim = new ConfirmDialog(scheduleID, modalityID.ToString(), start, end);
                confrim.dtInsu = dtInsu;
                confrim.dttBpview = dttBpview;
                confrim.dttDoctor = dttDoctor;
                confrim.dttRadiologist = dttRadiologist;
                DialogResult dlg = confrim.ShowDialog();
                if (dlg == DialogResult.Cancel)
                {
                    e.Allow = false;
                    e.Handled = true;
                    drag_drop = false;
                    reasonText = string.Empty;
                    addTextInBlock = string.Empty;
                }
                else
                {
                    drag_drop = true;
                    reasonText = confrim.REASON;
                    addTextInBlock = confrim.TextINBlock;
                    if (status == "W")
                    {
                        ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
                        process.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                        process.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                        process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                        process.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                        process.UpdateWatingList();
                    }
                    saveLogs(scheduleID, "Update DragDrop(s)");
                }
                confrim.Dispose();
                udpateBusy(Id, "N");
            }
            catch (Exception ex)
            {
                e.Allow = false;
                e.Handled = true;
                drag_drop = false;
                udpateBusy(Id, "N");
            }
            setWaittingListTimer(false);
            tmRefresh.Start();
        }
        private bool checkConflict(DataTable all_Exam, string hn, DateTime datetime_start)
        {
            bool flag = false;
            ScheduleInfo schCheckConflictTime = new ScheduleInfo();
            DataTable dataConflictTime = new DataTable();
            DataTable dataConflictAll = new DataTable();
            foreach (DataRow row in all_Exam.Rows)
            {
                if (row["EXAM_ID"].ToString().Trim() != string.Empty)
                {
                    schCheckConflictTime.IsHaveAppointment(hn, Convert.ToInt32(row["EXAM_ID"]), datetime_start, out dataConflictTime);
                    dataConflictAll.Merge(dataConflictTime);
                }
            }
            // popup Conflict form
            for (int i = 0; i < dataConflictTime.Rows.Count; i++)
            {
                if (all_Exam.Rows[0]["SCHEDULE_ID"].ToString() == dataConflictTime.Rows[0]["SCHEDULE_ID"].ToString())
                    dataConflictTime.Rows.RemoveAt(i);
            }
            if (dataConflictTime.Rows.Count > 0)
            {

                if (all_Exam.Rows[0]["SCHEDULE_ID"] != dataConflictTime.Rows[0]["SCHEDULE_ID"])
                    flag = true;
                frmScheduleConflictDetail frmConflictDetail = new frmScheduleConflictDetail(dataConflictTime);
                frmConflictDetail.ShowDialog();
            }
            return flag;
        }
        private void scControl_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            //W
            tmWaitingList.Stop();
            tmRefresh.Stop();
            string status = string.Empty;
            try
            {
                status = e.Appointment.CustomFields[2].ToString();
            }
            catch { }
            if (e.Appointment.ResourceId.ToString() == "DevExpress.XtraScheduler.Resource" && status != "W")
                e.Handled = true;
            else
            {
                if (e.OpenRecurrenceForm)
                {
                    #region Recurence Section.
                    #endregion
                }
                else
                {
                    DataRow row = null;
                    int id = 0;
                    if (e.Appointment.Start >= DateTime.Now || status == "W")
                    {
                        #region Show Appointment.
                        if (string.IsNullOrEmpty(e.Appointment.Location))
                        {
                            int _modality_id = Convert.ToInt32(e.Appointment.ResourceId);
                            int avg_inv_time = 5;
                            DataRow[] dr = dttModaltiy.Select("MODALITY_ID =" + _modality_id.ToString());
                            if (dr.Length > 0)
                                avg_inv_time = Convert.ToInt32(dr[0]["AVG_INV_TIME"].ToString());


                            #region Insert Reservation
                            ProcessAddRISSchedule process = new ProcessAddRISSchedule();
                            DateTime start = e.Appointment.Start;
                            DateTime end = e.Appointment.Start.AddMinutes(avg_inv_time);
                            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                            end = end.Subtract(ts);
                            string schedule_data = "";
                            schedule_data = "Reservation - " + env.UserUID + ":" + env.FirstName + " " + env.LastName;

                            process.RIS_SCHEDULE.SCHEDULE_DT = start;
                            process.RIS_SCHEDULE.START_DATETIME = start;
                            process.RIS_SCHEDULE.END_DATETIME = end;
                            process.RIS_SCHEDULE.MODALITY_ID = _modality_id;
                            process.RIS_SCHEDULE.ORG_ID = env.OrgID;
                            process.RIS_SCHEDULE.REASON = "";
                            process.RIS_SCHEDULE.SCHEDULE_DATA = schedule_data;
                            process.RIS_SCHEDULE.SCHEDULE_ID = 0;
                            process.RIS_SCHEDULE.SCHEDULE_STATUS = 'X';
                            process.RIS_SCHEDULE.CREATED_BY = env.UserID;
                            process.RIS_SCHEDULE.ALLDAY = false;
                            process.RIS_SCHEDULE.LABEL = e.Appointment.LabelId;
                            process.RIS_SCHEDULE.STATUS = Convert.ToInt32(e.Appointment.StatusId.ToString());
                            process.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(e.Appointment.Type);
                            int _schedule_reservation = process.InvokeReservation();
                            #endregion
                            #region New Appontment.
                            frmAppointment frm = new frmAppointment(sender as SchedulerControl, e.Appointment);
                            frm.dttBpview = dttBpview;
                            frm.dttDepartment = dttDepartment;
                            frm.dttDoctor = dttDoctor;
                            frm.dttRadiologist = dttRadiologist;
                            e.Handled = true;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Text = "New - Appointment";
                            e.Appointment.Subject = "New";
                            e.DialogResult = frm.ShowDialog();
                            frm.Hide();
                            frm.Dispose();
                            #endregion
                            #region Delete Reservation
                            ProcessDeleteRISSchedule delReservation = new ProcessDeleteRISSchedule();
                            delReservation.RIS_SCHEDULE.SCHEDULE_ID = _schedule_reservation;
                            delReservation.InvokeReservation();
                            #endregion
                        }
                        else
                        {
                            int wId = Convert.ToInt32(e.Appointment.Location);
                            if (checkIsBusy(wId))
                            {
                                msg.ShowAlert("UID1417", env.CurrentLanguageID);
                                setWaittingListTimer(false);
                                e.Handled = true;
                                return;
                            }
                            else
                                udpateBusy(wId, "Y");

                            if (status == "X")
                            {
                                e.Handled = true;
                                return;
                            }
                            #region Edit Appoinetment
                            frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment, dttAppointment);
                            frm.dttBpview = dttBpview;
                            frm.dttDepartment = dttDepartment;
                            frm.dttDoctor = dttDoctor;
                            frm.dttRadiologist = dttRadiologist;

                            e.Handled = true;
                            frm.Text = e.Appointment.Subject;
                            frm.SCHEDULE_STATUS = status;
                            e.DialogResult = frm.ShowDialog();
                            row = frm.RowAppointment;
                            id = frm.SCHEDULE_ID;
                            frm.Dispose();
                            udpateBusy(wId, "N");
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        //Make appontment less than Current DateTime is not allow
                        if (string.IsNullOrEmpty(e.Appointment.Location))
                        {
                            msg.ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                            e.Handled = true;
                        }
                        else
                        {
                            if (status == "X") return;
                            #region Edit Old Appointment.
                            frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment, dttAppointment);
                            frm.dttBpview = dttBpview;
                            frm.dttDepartment = dttDepartment;
                            frm.dttDoctor = dttDoctor;
                            frm.dttRadiologist = dttRadiologist;
                            e.Handled = true;
                            frm.Text = e.Appointment.Subject;
                            e.DialogResult = frm.ShowDialog();
                            id = frm.SCHEDULE_ID == 0 ? -1 : frm.SCHEDULE_ID;
                            frm.Dispose();
                            #endregion
                        }
                    }
                    if (e.DialogResult == DialogResult.OK)
                    {
                        if (id == -1)
                        {
                            setWaittingListTimer(false);
                            return;
                        }
                        if (id != 0)
                        {
                            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                            checkWaitingList();
                        }
                        else
                            initialScheduleDataByModality("Insert this appointment to datasource.", "Patient Schedule");
                    }
                }
            }
            setWaittingListTimer(false);
            tmRefresh.Start();
        }

        private void scControl_PreparePopupMenu(object sender, DevExpress.XtraScheduler.PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                if (scControl.SelectedAppointments.Count <= 0) return;
                if (scControl.SelectedAppointments[0].CustomFields.Count <= 0) return;
                string _status = scControl.SelectedAppointments[0].CustomFields["SCHEDULE_STATUS"].ToString();
                if (_status == "X") return;

                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.RestoreOccurrence);

                e.Menu.Items[0].Image = Envision.NET.Properties.Resources.rightclick_open;
                e.Menu.Items[2].Image = Envision.NET.Properties.Resources.rightclick_delete;

                DevExpress.Utils.Menu.DXMenuItem mnuAccept = new DevExpress.Utils.Menu.DXMenuItem("Accept");
                mnuAccept.Click += new EventHandler(mnuAccept_Click);
                mnuAccept.Image = Envision.NET.Properties.Resources.icoWL_Accept;
                e.Menu.Items.Add(mnuAccept);

                DevExpress.Utils.Menu.DXMenuItem mnuPending = new DevExpress.Utils.Menu.DXMenuItem("Pending");
                mnuPending.Click += new EventHandler(mnuPending_Click);
                mnuPending.Image = Envision.NET.Properties.Resources.Wait_icon32;
                if (_status == "W")
                    e.Menu.Items.Add(mnuPending);


                DevExpress.Utils.Menu.DXMenuItem mnuCut = new DevExpress.Utils.Menu.DXMenuItem("Cut");
                mnuCut.Image = Envision.NET.Properties.Resources.go_cut;
                mnuCut.Click += new EventHandler(mnuCut_Click);
                e.Menu.Items.Add(mnuCut);

                DevExpress.Utils.Menu.DXMenuItem mnuModality = new DevExpress.Utils.Menu.DXMenuItem("Change Modality");
                mnuModality.Click += new EventHandler(mnuModality_Click);
                mnuModality.Image = Envision.NET.Properties.Resources.rightclick_changeModality;
                e.Menu.Items.Add(mnuModality);

                DevExpress.Utils.Menu.DXMenuItem mnuPreview = new DevExpress.Utils.Menu.DXMenuItem("Print Preview");
                mnuPreview.Click += new EventHandler(mnuPreview_Click);
                mnuPreview.Image = Envision.NET.Properties.Resources.rightclick_printPreview;
                e.Menu.Items.Add(mnuPreview);

                DevExpress.Utils.Menu.DXMenuItem mnuPrintMulti = new DevExpress.Utils.Menu.DXMenuItem("Print");
                mnuPrintMulti.Click += new EventHandler(mnuPrintMulti_Click);
                mnuPrintMulti.Image = Envision.NET.Properties.Resources.rightclick_print;
                e.Menu.Items.Add(mnuPrintMulti);

                DevExpress.Utils.Menu.DXMenuItem mnuScanImage = new DevExpress.Utils.Menu.DXMenuItem("View Scanned Image");
                mnuScanImage.Click += new EventHandler(mnuScanImage_Click);
                mnuScanImage.Image = Envision.NET.Properties.Resources.rightclick_viewImage;
                e.Menu.Items.Add(mnuScanImage);

                //เมนูนี้ให้ไปใช้กับ mnuSchSummary ได้เหมือนกัน
                DevExpress.Utils.Menu.DXMenuItem mnuLabData = new DevExpress.Utils.Menu.DXMenuItem("View Lab Data");
                mnuLabData.Click += new EventHandler(mnuLabData_Click);
                mnuLabData.Image = Envision.NET.Properties.Resources.rightclick_lab;
                e.Menu.Items.Add(mnuLabData);

                DevExpress.Utils.Menu.DXMenuItem mnuComments = new DevExpress.Utils.Menu.DXMenuItem("Comments");
                mnuComments.Click += new EventHandler(mnuComments_Click);
                mnuComments.Image = Envision.NET.Properties.Resources.Comment_add_icon32;
                e.Menu.Items.Add(mnuComments);

                DevExpress.Utils.Menu.DXMenuItem mnuEmail = new DevExpress.Utils.Menu.DXMenuItem("Email");
                mnuEmail.Click += new EventHandler(mnuEmail_Click);
                mnuEmail.Image = Envision.NET.Properties.Resources.rightclick_mail;
                e.Menu.Items.Add(mnuEmail);

                DevExpress.Utils.Menu.DXMenuItem mnuSchSummary = new DevExpress.Utils.Menu.DXMenuItem("Schedule Summary");
                mnuSchSummary.Click += new EventHandler(mnuSchSummary_Click);
                mnuSchSummary.Image = Envision.NET.Properties.Resources.history_48;
                e.Menu.Items.Add(mnuSchSummary);

                DevExpress.Utils.Menu.DXMenuItem mnuPintDocument = new DevExpress.Utils.Menu.DXMenuItem("Intervention Document");
                mnuPintDocument.Click += new EventHandler(mnuPintDocument_Click);
                mnuPintDocument.Image = Envision.NET.Properties.Resources.rightclick_printPreview;
                e.Menu.Items.Add(mnuPintDocument);

                DevExpress.Utils.Menu.DXMenuItem mnuMergeSchedule = new DevExpress.Utils.Menu.DXMenuItem("Merge Appointment");
                mnuMergeSchedule.Click += new EventHandler(mnumnuMergeSchedule_Click);
                mnuMergeSchedule.Image = Envision.NET.Properties.Resources.merge_48;
                e.Menu.Items.Add(mnuMergeSchedule);

                DevExpress.Utils.Menu.DXMenuItem mnuPendingSchedule = new DevExpress.Utils.Menu.DXMenuItem("Pending Appointment");
                mnuPendingSchedule.Click += new EventHandler(mnuPendingSchedule_Click);
                mnuPendingSchedule.Image = Envision.NET.Properties.Resources.pendingIcon48;
                e.Menu.Items.Add(mnuPendingSchedule);
            }
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                if (pasteId > 0)
                {
                    DevExpress.Utils.Menu.DXMenuItem mnuPaste = new DevExpress.Utils.Menu.DXMenuItem("Paste");
                    mnuPaste.Click += new EventHandler(mnuPaste_Click);
                    e.Menu.Items.Add(mnuPaste);
                }

                DevExpress.Utils.Menu.DXMenuItem mnuRefresh = new DevExpress.Utils.Menu.DXMenuItem("Refresh");
                mnuRefresh.Click += new EventHandler(mnuRefresh_Click);
                e.Menu.Items.Add(mnuRefresh);
            }
        }

        private void scControl_SelectionChanged(object sender, EventArgs e)
        {
            checkModalityCase();
            if (!selected_Freeslots)
                initialScheduleData();
        }
        private void scControl_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            object data = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "SCHEDULE_STATUS");
            if (data != null)
            {
                if (data.ToString().ToUpper() == "O")
                {
                    if (scControl.ActiveView.Type == SchedulerViewType.Day && (dateNav.SelectionStart.ToShortDateString() == dateNav.SelectionEnd.ToShortDateString()))
                    {
                        DateTime dtStart = Convert.ToDateTime(e.ViewInfo.Appointment.GetValue(schedulerStorage1, "START_DATETIME").ToString());
                        if (dateNav.DateTime.ToString("dd/MM/yyyy") == dtStart.ToString("dd/MM/yyyy"))
                            e.ViewInfo.Appearance.BackColor = Color.Pink;
                    }
                    else
                        e.ViewInfo.Appearance.BackColor = Color.Pink;
                }
                else if (data.ToString().ToUpper() == "C")
                    e.ViewInfo.Appearance.BackColor = Color.OrangeRed;
                else if (data.ToString().ToUpper() == "W")
                    e.ViewInfo.Appearance.BackColor = Color.Aqua;
                else if (data.ToString().ToUpper() == "V")
                    e.ViewInfo.Appearance.BackColor = Color.MediumVioletRed;
                else if (data.ToString().ToUpper() == "P")
                    e.ViewInfo.Appearance.BackColor = Color.Brown;
                else if (data.ToString().ToUpper() == "X")
                    e.ViewInfo.Appearance.BackColor = Color.DarkGray;

                object isRequestOnline = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "IS_REQONLINE");
                object isWaitingOnline = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "WL_CONFIRMED_BY");
                if (isWaitingOnline == null) return;
                if (isRequestOnline.ToString().ToUpper() == "Y" && data.ToString().ToUpper() == "S")
                {
                    if (isWaitingOnline.ToString() == "")
                        e.ViewInfo.Appearance.BackColor = Color.GreenYellow;
                    else
                        e.ViewInfo.Appearance.BackColor = Color.Green;
                }
            }
        }
        private void scControl_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
        {
            try
            {
                string checkComments = e.Appointment.CustomFields["HAS_COMMENTS"].ToString() == "" ? "0" : e.Appointment.CustomFields["HAS_COMMENTS"].ToString();
                string checkIsAlert = e.Appointment.CustomFields["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                string checkIsTelemed = e.Appointment.CustomFields["IS_TELEMED"].ToString();
                if (checkComments != "0")
                {
                    AppointmentImageInfo info = new AppointmentImageInfo();
                    info.Image = Envision.NET.Properties.Resources.history_16;
                    e.ImageInfoList.Add(info);
                }
                if (checkIsAlert == "Y")
                {
                    AppointmentImageInfo info2 = new AppointmentImageInfo();
                    info2.Image = Envision.NET.Properties.Resources.alert_16;
                    e.ImageInfoList.Add(info2);
                }
                if (checkIsTelemed == "Y")
                {
                    AppointmentImageInfo info3 = new AppointmentImageInfo();
                    info3.Image = img16.Images[0];
                    e.ImageInfoList.Add(info3);
                }
            }
            catch { }
        }
        private void scControl_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            try
            {
                string checkComments = e.Appointment.CustomFields["HAS_COMMENTS"].ToString() == "" ? "0" : e.Appointment.CustomFields["HAS_COMMENTS"].ToString();
                if (checkComments != "0")
                {
                    MessageConversationManagement msgShow = new MessageConversationManagement();
                    DataTable dt = msgShow.getMessageForAppointmentBar(Convert.ToInt32(e.Appointment.Location));
                    string _desc = "";
                    foreach (DataRow rows in dt.Rows)
                        _desc += "\r\n [" + rows["EMP_UID"].ToString() + "-" + rows["FNAME"].ToString() + " ] " + rows["MSG_TEXT"].ToString();

                    e.Description += string.IsNullOrEmpty(_desc) ? "" : "Comment:" + _desc;

                }

                if (!string.IsNullOrEmpty(e.Appointment.CustomFields["PREPARATION_DESC"].ToString()))
                    e.Text += "\r\n-> Preparation : " + e.Appointment.CustomFields["PREPARATION_DESC"].ToString();
                if (!string.IsNullOrEmpty(e.Appointment.CustomFields["REF_UNIT"].ToString()))
                {
                    DataRow[] rowDepart = dttDepartment.Select("UNIT_ID=" + e.Appointment.CustomFields["REF_UNIT"].ToString());
                    if (rowDepart.Length > 0)
                        e.Text += "\r\n-> Unit : " + rowDepart[0]["UNIT_UID"].ToString() + " : " + rowDepart[0]["UNIT_NAME"].ToString();
                }
            }
            catch { }
        }
        private void dateNav_EditDateModified(object sender, EventArgs e)
        {
            selected_Freeslots = false;
            initialScheduleData();
        }
        #endregion

        #region Schedule Storage.
        private void schedulerStorage1_AppointmentChanging(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            if (drag_drop)
                e.Cancel = false;
            else
            {
                if (is_come) return;
                Appointment apt = e.Object as Appointment;
                if (apt == null) return;
                if (apt.CustomFields == null) return;
                string status = apt.CustomFields["SCHEDULE_STATUS"].ToString().Trim();
                if (status == "X") return;
                if (status == "O")
                {
                    msg.ShowAlert("UID1104", env.CurrentLanguageID);
                    e.Cancel = true;
                    return;
                }
                DateTime start = apt.Start;
                DateTime end = apt.End;
                DateTime edt = end;

                #region Check Start/End Datetime.
                TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                edt = edt.Subtract(ts);
                if (end <= start)
                {
                    e.Cancel = true;
                    return;
                }
                if (start <= DateTime.Now)
                {
                    e.Cancel = true;
                    return;
                }
                #endregion

                #region Check Appoitment Condition.
                if (msg.ShowAlert("UID1020", env.CurrentLanguageID) == "1")
                {
                    //if (apt.IsRecurring)
                    //{
                    is_come = true;
                    delete_recurrence = true;
                    //}
                    //else
                    //    e.Cancel = true;
                    return;
                }
                end = edt;
                try
                {
                    status = apt.CustomFields["CommandType"].ToString().Trim();
                }
                catch { }
                if (status == "F")
                {
                    e.Cancel = false;
                    apt.CustomFields["CommandType"] = "N";
                    return;
                }

                int scheduleId = Convert.ToInt32(apt.CustomFields["SCHEDULE_ID"].ToString().Trim());
                int modalityId = 0;
                ProcessGetRISSchedule procSc = new ProcessGetRISSchedule(scheduleId);
                procSc.Invoke();
                DataTable dttSc = procSc.Result.Tables[0].Copy();
                modalityId = Convert.ToInt32(dttSc.Rows[0]["MODALITY_ID"].ToString());
                string block = dttSc.Rows[0]["IS_BLOCKED"].ToString().Trim();
                string hn = apt.CustomFields["HN"].ToString().Trim();
                if (drag_drop)
                    modalityId = Convert.ToInt32(apt.ResourceId.ToString());
                if (drag_drop == false)
                {
                    #region Check DateTime for change appointment.
                    if (block.Trim() == "N")
                    {
                        //if (isConflictNotFree(scheduleId, modalityId, hn, start, edt))
                        // {
                        //     string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                        //     e.Cancel = true;
                        //     return;
                        // }
                        if (isHaveBlock(scheduleId, modalityId, start, edt, 'N')) //old is 'Y'
                        {
                            string s = msg.ShowAlert("UID1107", env.CurrentLanguageID);
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        if (isHaveBlock(scheduleId, modalityId, start, edt, 'Y'))
                        {
                            string s = msg.ShowAlert("UID1108", env.CurrentLanguageID);
                            e.Cancel = true;
                            return;
                        }
                    }
                    end = edt;
                    #endregion
                }
                ConfirmDialog confrim = new ConfirmDialog(scheduleId, modalityId.ToString(), start, end);
                confrim.dtInsu = dtInsu;
                confrim.dttBpview = dttBpview;
                confrim.dttDoctor = dttDoctor;
                confrim.dttRadiologist = dttRadiologist;
                DialogResult dlg = confrim.ShowDialog();
                if (dlg == DialogResult.Cancel)
                {
                    //if (apt.IsRecurring)
                    //{
                    is_come = true;
                    delete_recurrence = true;
                    //}
                    //else
                    //    e.Cancel = true;
                }
                else
                {
                    reasonText = confrim.REASON;
                    addTextInBlock = confrim.TextINBlock;
                    if (apt.IsRecurring) drag_drop = true;
                }
                confrim.Dispose();
                #endregion

            }
        }
        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            System.Collections.IList list = e.Objects as System.Collections.IList;
            Appointment apt = (Appointment)list[0];
            if (apt == null) return;
            if (apt.CustomFields == null) return;
            DateTime start = apt.Start;
            DateTime end = apt.End;
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            end = end.Subtract(ts);
            int scheduleId = 0;
            if (delete_recurrence)
            {
                DataRow[] drs = dttAppointment.Select("SCHEDULE_ID=" + apt.Location);
                if (apt.IsRecurring)
                {
                    if (drs.Length > 0)
                    {
                        start = Convert.ToDateTime(drs[0]["START_DATETIME"].ToString());
                        start = new DateTime(apt.Start.Year, apt.Start.Month, apt.Start.Day, start.Hour, start.Minute, start.Second);
                        end = Convert.ToDateTime(drs[0]["END_DATETIME"].ToString());
                        end = new DateTime(apt.End.Year, apt.End.Month, apt.End.Day, end.Hour, end.Minute, end.Second);
                    }
                }
                else
                {
                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule(Convert.ToInt32(apt.Location));
                    proc.Invoke();
                    DataTable dtt = proc.Result.Tables[0].Copy();
                    if (Miracle.Util.Utilities.IsHaveData(dtt))
                    {
                        start = Convert.ToDateTime(dtt.Rows[0]["START_DATETIME"].ToString());
                        end = Convert.ToDateTime(dtt.Rows[0]["END_DATETIME"].ToString());
                    }
                }
            }
            else
            {
                if (apt.IsRecurring)
                {
                    #region Recurrence Appointment.
                    string cmd = string.Empty;
                    try
                    {
                        cmd = apt.CustomFields["LOCATION"].ToString();
                    }
                    catch
                    {
                        cmd = string.Empty;
                    }
                    if (string.IsNullOrEmpty(cmd))
                    {
                        DataRow[] rows = dttAppointment.Select("SCHEDULE_ID=" + apt.Location);
                        apt.CustomFields["LOCATION"] = apt.Location;
                        ProcessAddRISSchedule proc = new ProcessAddRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(rows[0]["SCHEDULE_ID"].ToString());
                        proc.RIS_SCHEDULE.START_DATETIME = start;
                        proc.RIS_SCHEDULE.END_DATETIME = end;
                        proc.RIS_SCHEDULE.IS_BLOCKED = string.IsNullOrEmpty(rows[0]["IS_BLOCKED"].ToString()) ? 'N' : rows[0]["IS_BLOCKED"].ToString()[0];
                        proc.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(apt.Type);
                        if (apt.RecurrenceInfo != null)
                        {
                            string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                            if (apt.RecurrenceIndex > 0)
                                str += " Index=\"" + apt.RecurrenceIndex + "\"";
                            str += " />";
                            proc.RIS_SCHEDULE.RECURRENCEINFO = str;
                        }
                        proc.RIS_SCHEDULE.STATUS = apt.StatusId;
                        proc.RIS_SCHEDULE.LABEL = apt.LabelId;
                        proc.RIS_SCHEDULE.LOCATION = apt.Location;
                        proc.RIS_SCHEDULE.HN = apt.CustomFields["HN"].ToString();
                        proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                        proc.RIS_SCHEDULE.CREATED_BY = env.UserID;
                        proc.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        proc.RIS_SCHEDULE.SCHEDULE_DATA = rows[0]["SCHEDULE_DATA"].ToString();
                        proc.InvokeRecurrence();
                        scheduleId = proc.RIS_SCHEDULE.SCHEDULE_ID;

                    }
                    else
                    {
                        ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                        scheduleId = proc.RIS_SCHEDULE.SCHEDULE_ID;
                        proc.RIS_SCHEDULE.IS_BLOCKED = apt.CustomFields["IS_BLOCKED"].ToString()[0];
                        proc.RIS_SCHEDULE.LOCATION = apt.CustomFields["LOCATION"].ToString();
                        proc.RIS_SCHEDULE.HN = apt.CustomFields["HN"].ToString();
                        proc.RIS_SCHEDULE.SCHEDULE_DATA = apt.Subject;

                        proc.RIS_SCHEDULE.START_DATETIME = start;
                        proc.RIS_SCHEDULE.END_DATETIME = end;
                        proc.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(apt.Type);
                        if (apt.RecurrenceInfo != null)
                        {
                            string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                            if (apt.RecurrenceIndex > 0)
                                str += " Index=\"" + apt.RecurrenceIndex + "\"";
                            str += " />";
                            proc.RIS_SCHEDULE.RECURRENCEINFO = str;
                        }
                        proc.RIS_SCHEDULE.STATUS = apt.StatusId;
                        proc.RIS_SCHEDULE.LABEL = apt.LabelId;
                        proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                        proc.RIS_SCHEDULE.CREATED_BY = env.UserID;
                        proc.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        proc.UpdateRecurrence();
                    }
                    #endregion
                }
                else
                {
                    #region Normal Appontment
                    ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
                    process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);
                    process.RIS_SCHEDULE.START_DATETIME = start;
                    process.RIS_SCHEDULE.END_DATETIME = end;
                    process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                    process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    process.RIS_SCHEDULE.SCHEDULE_DATA = addTextInBlock;
                    process.RIS_SCHEDULE.REASON = reasonText;
                    if (apt.RecurrenceInfo != null)
                    {
                        RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(apt.RecurrenceInfo, DateSavingType.LocalTime);
                        process.RIS_SCHEDULE.RECURRENCEINFO = helper.ToXml();
                    }
                    process.RIS_SCHEDULE.LABEL = apt.LabelId;
                    process.RIS_SCHEDULE.STATUS = apt.StatusId;
                    process.RIS_SCHEDULE.EVENTTYPE = Convert.ToInt32(apt.Type);
                    process.UpdateBlockTimer();

                    scheduleId = process.RIS_SCHEDULE.SCHEDULE_ID;
                    #endregion
                }
                Object objOLD = apt.Location;
                Object objNew = scheduleId;
                apt.Location = objNew.ToString();
                apt.CustomFields["LOCATION"] = objOLD;
                initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            }
            apt.Start = start;
            //apt.End = end;
            drag_drop = false;
            delete_recurrence = false;
            is_come = false;
        }
        private void schedulerStorage1_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            if (is_come)
                return;
            Appointment apt = e.Object as Appointment;
            if (apt == null) return;
            if (apt.CustomFields == null) return;
            string status = apt.CustomFields[2].ToString();
            if (status == "O")
            {
                msg.ShowAlert("UID1103", env.CurrentLanguageID);
                e.Cancel = true;
                return;
            }
            else if (status == "X")
            {
                e.Cancel = true;
                return;
            }
            string schduleID = apt.CustomFields[1].ToString();
            string modality = apt.CustomFields[3].ToString();
            DateTime start = apt.Start;
            DateTime end = apt.End;

            ConfirmDialog confrim = new ConfirmDialog(Convert.ToInt32(schduleID), modality, start, end);
            confrim.dtInsu = dtInsu;
            confrim.dttBpview = dttBpview;
            confrim.dttDoctor = dttDoctor;
            confrim.dttRadiologist = dttRadiologist;
            confrim.Text = "ลบข้อมูล";
            DialogResult dlg = confrim.ShowDialog();
            if (dlg == DialogResult.Cancel)
                e.Cancel = true;
            else
                reasonText = confrim.REASON;
            confrim.Dispose();
            if (e.Cancel == false)
            {
                if (apt.IsRecurring)
                {
                    #region recurrence appointment.
                    int eventType = Convert.ToInt32(apt.Type);

                    if (eventType == 1)
                    {
                        #region Delete Series.
                        this.scheduleId = Convert.ToInt32(schduleID);
                        is_come = true;
                        #endregion
                    }
                    else
                    {
                        #region Delete this occurence.
                        DataRow[] rows = dttAppointment.Select("SCHEDULE_ID=" + apt.Location);
                        string location = string.IsNullOrEmpty(apt.CustomFields["LOCATION"].ToString()) ? apt.Location : apt.CustomFields["LOCATION"].ToString();
                        ProcessAddRISSchedule proc = new ProcessAddRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.Location);// Convert.ToInt32(rows[0]["SCHEDULE_ID"].ToString());
                        proc.RIS_SCHEDULE.START_DATETIME = start;
                        proc.RIS_SCHEDULE.END_DATETIME = end;
                        proc.RIS_SCHEDULE.IS_BLOCKED = string.IsNullOrEmpty(rows[0]["IS_BLOCKED"].ToString()) ? 'N' : rows[0]["IS_BLOCKED"].ToString()[0];
                        proc.RIS_SCHEDULE.EVENTTYPE = 4;
                        if (apt.RecurrenceInfo != null)
                        {
                            string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                            if (apt.RecurrenceIndex > 0)
                                str += " Index=\"" + apt.RecurrenceIndex + "\"";
                            str += " />";
                            proc.RIS_SCHEDULE.RECURRENCEINFO = str;
                        }
                        proc.RIS_SCHEDULE.STATUS = apt.StatusId;
                        proc.RIS_SCHEDULE.LABEL = apt.LabelId;
                        proc.RIS_SCHEDULE.LOCATION = location;
                        proc.RIS_SCHEDULE.HN = apt.CustomFields["HN"].ToString();
                        proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                        proc.RIS_SCHEDULE.CREATED_BY = env.UserID;
                        proc.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        proc.RIS_SCHEDULE.SCHEDULE_DATA = rows[0]["SCHEDULE_DATA"].ToString();
                        proc.RIS_SCHEDULE.REASON = reasonText;
                        proc.InvokeRecurrence();

                        Object objOLD = apt.Location;
                        Object objNew = proc.RIS_SCHEDULE.SCHEDULE_ID;
                        apt.Location = objNew.ToString();
                        apt.CustomFields["LOCATION"] = objOLD;
                        apt.Start = start;
                        apt.End = end;
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region normal appoitment.
                    ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                    process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(schduleID);
                    process.RIS_SCHEDULE.REASON_CHANGE = reasonText;
                    process.RIS_SCHEDULE.REASON = reasonText;
                    process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    process.Invoke();
                    #endregion
                }
            }
            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            drag_drop = false;
            //delete_recurrence = true;
        }
        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            if (scheduleId > 0)
            {
                //delete series.
                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(scheduleId);
                process.RIS_SCHEDULE.REASON_CHANGE = reasonText;
                process.RIS_SCHEDULE.REASON = reasonText;
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();
                scheduleId = 0;
                is_come = false;
                delete_recurrence = false;
                drag_drop = false;
                reasonText = string.Empty;
            }
        }
        #endregion

        #region Right Click.
        private void mnuPrintMulti_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string schedule_status = scControl.SelectedAppointments[0].CustomFields[2].ToString();
                    switch (schedule_status)
                    {
                        case "W":
                        case "P":
                            msg.ShowAlert("UID4051", env.CurrentLanguageID);
                            break;
                        default:
                            string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                            if (HN.Trim().ToLower() == "block") return;
                            DateTime start = scControl.SelectedAppointments[0].Start;
                            int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
                            int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
                            if (HN.IndexOf(',') > 0)
                            {
                                frmMultiplePrint frm = new frmMultiplePrint(Schedule);
                                frm.StartPosition = FormStartPosition.CenterScreen;
                                frm.ShowDialog();
                            }
                            else
                            {
                                #region Single Exam.
                                ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                                process.RIS_SCHEDULE.SCHEDULE_ID = Schedule;
                                DataTable dtData = process.GetMultiPrint();
                                DataTable dts = new DataTable();
                                foreach (DataRow row in dtData.Rows)
                                {
                                    ReportParameters spara = new ReportParameters();
                                    spara.ScheduleID = Convert.ToInt32(row["SCHEDULE_ID"].ToString());
                                    spara.PatientId = row["HN"].ToString();
                                    spara.AppointDate = Convert.ToDateTime(row["START_DATETIME"].ToString());
                                    spara.ModalityId = Convert.ToInt32(row["MODALITY_ID"].ToString());
                                    ProcessScheduleReport slkp = new ProcessScheduleReport();
                                    slkp.ReportParameters = spara;
                                    slkp.Invoke();
                                    dts = slkp.ResultSet.Tables[0];
                                }
                                if (dts.Rows.Count > 0)
                                {
                                    if (!string.IsNullOrEmpty(dts.Rows[0]["PAT_DEST_LABEL"].ToString()))
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.AppointmentDirectPrint(Schedule, dts.Rows[0]["PAT_DEST_LABEL"].ToString());
                                    }
                                }

                                #endregion
                            }
                            saveLogs(Schedule, "Print Envision");
                            break;
                    }
                }
        }
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string schedule_status = scControl.SelectedAppointments[0].CustomFields[2].ToString();
                    switch (schedule_status)
                    {
                        case "W":
                        case "P":
                            msg.ShowAlert("UID4051", env.CurrentLanguageID);
                            break;
                        default:
                            string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                            if (HN.Trim().ToLower() == "block") return;
                            //HN = HN.Substring(0, HN.IndexOf(','));
                            DateTime start = scControl.SelectedAppointments[0].Start;
                            int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
                            int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());

                            ReportParameters spara = new ReportParameters();
                            spara.ScheduleID = Schedule;
                            spara.PatientId = HN;
                            spara.AppointDate = start;
                            spara.ModalityId = Modality;
                            ProcessScheduleReport slkp = new ProcessScheduleReport();
                            slkp.ReportParameters = spara;
                            slkp.Invoke();
                            DataTable dts = slkp.ResultSet.Tables[0];

                            if (dts.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dts.Rows[0]["PAT_DEST_LABEL"].ToString()))
                                {
                                    DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
                                    switch (dts.Rows[0]["PAT_DEST_LABEL"].ToString())
                                    {
                                        case "SDMC": report = new xrptScheduleReportSDMC(Schedule); break;
                                        case "AIMC": report = new xrptScheduleReportAIMCNew(Schedule); break;
                                        default: report = new xrptScheduleReport(Schedule); break;
                                    }
                                    report.ShowPreviewDialog();
                                }
                            }
                            break;
                    }

                }
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            initialScheduleDataByModality("Refresh patient appointments data", "Load Data");
        }
        private void mnuSchSummary_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    try
                    {
                        string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                        int id = Convert.ToInt32(scControl.SelectedAppointments[0].Location);
                        //frmScheduleSummary frm = new frmScheduleSummary(HN, id);
                        //frm.StartPosition = FormStartPosition.CenterScreen;
                        //frm.ShowDialog();
                        _summary.ShowDialog(true, HN, id, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, false);
                    }
                    catch { }
                }

        }
        private void mnuEmail_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    try
                    {
                        string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                        if (HN.Trim().ToLower() == "block") return;
                        Patient p = new Patient(HN, true);
                        HN = scControl.SelectedAppointments[0].Subject;
                        string[] data = HN.Split("\r\n".ToCharArray());
                        string message = "เรียนคุณ " + p.FirstName.Trim() + " " + p.LastName.Trim();
                        message += "  มีนัดทำ " + data[2] + "ในวันที่ " + scControl.SelectedAppointments[0].Start.ToString("dd/MM/yyyy");
                        System.Diagnostics.Process.Start("mailto:" + p.Email + "?subject=นัดตรวจ Xray&body=" + message);
                    }
                    catch { }
                }

        }
        private void mnuModality_Click(object sender, EventArgs e)
        {
            setWaittingListTimer(false);
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    int scheduleID = Convert.ToInt32(scControl.SelectedAppointments[0].Location);
                    if (checkIsBusy(scheduleID))
                    {
                        msg.ShowAlert("UID1417", env.CurrentLanguageID);
                    }
                    else
                    {
                        udpateBusy(scheduleID, "Y");
                        frmChangeModality dlg = new frmChangeModality(scheduleID, dttAppointment);
                        if (DialogResult.OK == dlg.ShowDialog())
                        {
                            saveLogs(scheduleID, "Changed Modality Envision");
                            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                        }
                        dlg.Dispose();
                        udpateBusy(scheduleID, "N");
                    }
                }
            setWaittingListTimer(true);
        }
        private void mnuComments_Click(object sender, EventArgs e)
        {
            //DataTable ExamID;
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    tmRefresh.Stop();
                    string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                    if (HN.Trim().ToLower() == "block") return;
                    DateTime start = scControl.SelectedAppointments[0].Start;
                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());

                    frmMessageConversation frm = new frmMessageConversation(Schedule);
                    if (frm.ShowDialog(this.Text) == DialogResult.OK)
                    {
                        initialScheduleDataByModality("Refresh patient appointments data", "Load Data");
                        tmRefresh.Start();
                    }
                }
        }
        private void mnuScanImage_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                    if (HN.Trim().ToLower() == "block") return;

                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
                    dv_scan_image = new ScanImages().GetData(Schedule, 0);
                    diagUploadFile diag = new diagUploadFile(dv_scan_image, false);
                    diag.Height = Height;
                    diag.Width = Width;

                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        dv_scan_image = diag.OrderImages;
                        new ScanImages().Invoke(HN, Schedule, 0, dv_scan_image);
                    }
                    else if (diag.ShowDialog() == DialogResult.Abort)
                    {
                        PointerStruct[] p = PointerStruct.GetPointerStruct();
                        PointerStruct.ImageUrl = env.PacsUrl2;
                        ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
                        process.RIS_ORDERIMAGE.ORDER_ID = 0;
                        process.RIS_ORDERIMAGE.SCHEDULE_ID = Schedule;
                        DataTable dtOrderImage = process.GetDataByID();

                        string mode = "Edit";
                        if (dtOrderImage.Rows.Count > 0)
                        {
                            Miracle.Scanner.EditImageOrder editFrm = new Miracle.Scanner.EditImageOrder(dtOrderImage, env.PixPicture);
                            editFrm.StartPosition = FormStartPosition.CenterScreen;
                            editFrm.ShowDialog();
                            if (editFrm.DialogResult == DialogResult.Yes)
                                env.PixPicture = editFrm.PictureStruct;
                            else
                                return;
                        }
                        else
                        {
                            mode = "New";
                            Miracle.Scanner.NewScan frm = new Miracle.Scanner.NewScan(env.PixPicture);
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                            if (frm.DialogResult == DialogResult.OK)
                                env.PixPicture = frm.PictureStruct;
                            else
                                return;
                        }
                        ScanImage save = null;
                        if (mode == "New")
                            save = new ScanImage(HN, Schedule, "Y");
                        else
                            save = new ScanImage(HN, Schedule, dtOrderImage, "Y");
                        env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
                    }
                }
        }
        private void mnuLabData_Click(object sender, EventArgs e)
        {
            //if (scControl.SelectedAppointments != null)
            //    if (scControl.SelectedAppointments.Count > 0)
            //    {
            //        string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
            //        if (HN.Trim().ToLower() == "block") return;
            //        try
            //        {
            //            HIS_Patient HIS_p = new HIS_Patient();
            //            DataSet dsHIS = HIS_p.Get_lab_data(HN);
            //            if (dsHIS.Tables[0].Rows.Count > 0)
            //            {
            //                Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            //                lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
            //                lv.Text = "Lab Detail List";
            //                lv.Data = dsHIS.Tables[0];
            //                Size ss = new Size(800, 600);
            //                lv.Size = ss;
            //                lv.PreviewFieldName = "report";
            //                lv.SortFieldName = "lab_date";
            //                lv.ShowDescription = true;
            //                lv.ShowBox();
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID);
            //        }
            //    }
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    try
                    {
                        string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                        int id = Convert.ToInt32(scControl.SelectedAppointments[0].Location);
                        //frmScheduleSummary frm = new frmScheduleSummary(HN, id);
                        //frm.StartPosition = FormStartPosition.CenterScreen;
                        //frm.ShowDialog();
                        _summary.ShowDialog(true, HN, id, 0, frmPopupOrderOrScheduleSummary.PagesModes.Schedule, true);
                    }
                    catch { }
                }
        }
        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
        }
        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                    pasteId = Convert.ToInt32(scControl.SelectedAppointments[0].Location);
        }
        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (pasteId == 0) return;
            ProcessGetRISSchedule procSC = new ProcessGetRISSchedule(pasteId);
            procSC.Invoke();
            DataTable dtt = procSC.Result.Tables[0];
            if (Miracle.Util.Utilities.IsHaveData(dtt))
            {
                int modalityID = Convert.ToInt32(scControl.SelectedResource.Id.ToString());
                DateTime dtStart = Convert.ToDateTime(dtt.Rows[0]["START_DATETIME"].ToString());
                DateTime dtEnd = Convert.ToDateTime(dtt.Rows[0]["END_DATETIME"].ToString());
                //dtStart = new DateTime(scControl.SelectedInterval.Start.Year, scControl.SelectedInterval.Start.Month, scControl.SelectedInterval.Start.Day, dtStart.Hour, dtStart.Minute, dtStart.Second);
                //dtStart = scControl.SelectedInterval.Start;
                //dtEnd = new DateTime(scControl.SelectedInterval.End.Year, scControl.SelectedInterval.End.Month, scControl.SelectedInterval.End.Day, dtEnd.Hour, dtEnd.Minute, dtEnd.Second);

                TimeSpan ts = dtEnd.Subtract(dtStart);
                dtStart = scControl.SelectedInterval.Start;
                dtEnd = dtStart.Add(ts);

                ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                proc.RIS_SCHEDULE.SCHEDULE_ID = pasteId;
                proc.RIS_SCHEDULE.HN = dtt.Rows[0]["HN"].ToString();
                proc.RIS_SCHEDULE.START_DATETIME = dtStart;// scControl.SelectedInterval.Start;
                proc.RIS_SCHEDULE.END_DATETIME = dtEnd;// scControl.SelectedInterval.End;
                proc.RIS_SCHEDULE.MODALITY_ID = modalityID;
                DataTable dtCheck = null;
                if (dtt.Rows[0]["IS_BLOCKED"].ToString() == "Y")
                {
                    dtCheck = proc.CheckFreeSlot();
                    if (Miracle.Util.Utilities.IsHaveData(dtCheck))
                        msg.ShowAlert("UID1102", env.CurrentLanguageID);
                    else
                        updateCutPaste(dtStart, dtEnd);
                }
                else
                {
                    dtCheck = proc.CheckTime();
                    DataRow[] rows = dtCheck.Select("IS_BLOCKED='Y'");
                    if (rows.Length > 0)
                    {
                        msg.ShowAlert("UID1101", env.CurrentLanguageID);
                        return;
                    }

                    if (!isModalityMapExam(pasteId, modalityID))
                    {
                        msg.ShowAlert("UID1106", env.CurrentLanguageID);
                        return;
                    }
                    updateCutPaste(dtStart, dtEnd);
                }

            }
        }
        private void mnuOrderSummary_Click(object sender, EventArgs e)
        {
            //OrderSummaryProcess();
        }
        private void mnuAccept_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
            string _status = scControl.SelectedAppointments[0].CustomFields["SCHEDULE_STATUS"].ToString();
            if (_status == "W" || _status == "P")
            {
                if (checkIsBusy(id))
                    msg.ShowAlert("UID1417", env.CurrentLanguageID);
                else if (msg.ShowAlert("UID1415", env.CurrentLanguageID) == "2")
                {
                    udpateBusy(id, "Y");
                    ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                    proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                    proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'S';
                    proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    switch (_status)
                    {
                        case "W":
                            proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                            proc.UpdateWatingList();
                            break;
                        case "P":
                            proc.RIS_SCHEDULE.PENDING_BY = env.UserID;
                            proc.UpdatePending();
                            break;
                    }
                    initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                    udpateBusy(id, "N");
                    checkWaitingList();
                }
            }

        }
        private void mnuPending_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
            string _status = scControl.SelectedAppointments[0].CustomFields["SCHEDULE_STATUS"].ToString();
            if (_status == "W")
            {
                if (checkIsBusy(id))
                    msg.ShowAlert("UID1417", env.CurrentLanguageID);
                else if (msg.ShowAlert("UID1415", env.CurrentLanguageID) == "2")
                {

                    Reason frmReason = new Reason();
                    if (frmReason.ShowDialog() == DialogResult.OK)
                    {
                        udpateBusy(id, "Y");
                        ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                        proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                        proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'P';
                        proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;

                        proc.RIS_SCHEDULE.WL_CONFIRMED_BY = env.UserID;
                        proc.UpdateWatingList();

                        proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                        proc.UpdatePendingComments();

                        saveLogs(id, "Update Pending(s)");
                    }

                    initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                    udpateBusy(id, "N");
                    checkWaitingList();
                }
            }
        }

        private bool requireCheckFreeTime(int modalityId, int sessionId)
        {
            DateTime start = scControl.SelectedInterval.Start;
            DateTime end = scControl.SelectedInterval.End;
            int max_app = 0;
            int curr_app = 0;
            DateTime dtsTmp = DateTime.Today;
            DateTime dteTmp = DateTime.Today;
            DataRow[] drs;

            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
            process.RIS_CLINICSESSION.MODALITY_ID = modalityId;
            process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
            process.RIS_CLINICSESSION.WEEKDAYS = Convert.ToInt32(start.DayOfWeek);
            process.Invoke();
            DataTable dtmp = process.GetClinicSession();
            drs = dtmp.Select("SESSION_ID=" + sessionId.ToString());
            max_app = Convert.ToInt32(drs[0]["MAX_APP"].ToString());
            DateTime dtStartApp = Convert.ToDateTime(drs[0]["START_TIME"].ToString());
            DateTime dtEndApp = Convert.ToDateTime(drs[0]["END_TIME"].ToString());

            DateTime dtSt = new DateTime(start.Year, start.Month, start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
            DateTime dtEn = new DateTime(start.Year, start.Month, start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);

            ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
            procSC.RIS_SCHEDULE.MODALITY_ID = process.RIS_CLINICSESSION.MODALITY_ID;
            procSC.RIS_SCHEDULE.START_DATETIME = dtSt;
            procSC.RIS_SCHEDULE.END_DATETIME = dtEn;
            dtmp = new DataTable();
            dtmp = procSC.GetSessionCount();
            curr_app = 0;
            if (curr_app > max_app)
            {
                if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                    return false;
            }
            return true;
        }
        private void updateCutPaste(DateTime dtStart, DateTime dtEnd)
        {
            //MessageBox.Show("UPDATE CUT & PASTE : " + pasteId.ToString());
            ConfirmDialog confrim = new ConfirmDialog(pasteId, scControl.SelectedResource.Id.ToString(), scControl.SelectedInterval.Start, scControl.SelectedInterval.End);
            confrim.dtInsu = dtInsu;
            confrim.dttBpview = dttBpview;
            confrim.dttDoctor = dttDoctor;
            confrim.dttRadiologist = dttRadiologist;
            DialogResult dlg = confrim.ShowDialog();
            string reason = confrim.REASON;
            confrim.Dispose();
            if (dlg == DialogResult.Cancel) return;

            ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
            proc.RIS_SCHEDULE.SCHEDULE_ID = pasteId;
            proc.RIS_SCHEDULE.START_DATETIME = dtStart;// scControl.SelectedInterval.Start;
            proc.RIS_SCHEDULE.END_DATETIME = dtEnd;// scControl.SelectedInterval.End;
            TimeSpan ts = new TimeSpan(0, 0, 0, 1);
            proc.RIS_SCHEDULE.END_DATETIME = proc.RIS_SCHEDULE.END_DATETIME.Subtract(ts);
            proc.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(scControl.SelectedResource.Id.ToString());
            proc.RIS_SCHEDULE.REASON = reason;
            proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
            proc.UpdateBlockTimer();
            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            //
            pasteId = 0;
        }
        private void mnuPintDocument_Click(object sender, EventArgs e)
        {
            string hn = scControl.SelectedAppointments[0].CustomFields[6].ToString();
            Patient p = new Patient(hn, true);

            frmScheduleInterventionDocument printDoc = new frmScheduleInterventionDocument();
            printDoc.HN = hn;
            printDoc.PatientName = p.FirstName + " " + p.LastName;
            //TimeSpan ts = (DateTime.Now.AddDays(731) - DateTime.Now);
            TimeSpan ts = (DateTime.Now - p.DateOfBirth);
            string year = (ts.TotalDays / 365).ToString().IndexOf(".") > 0 ? (ts.TotalDays / 365).ToString().Substring(0, (ts.TotalDays / 365).ToString().IndexOf(".")) : (ts.TotalDays / 365).ToString();
            string month = ((ts.TotalDays % 365) / 30).ToString().IndexOf(".") > 0 ? ((ts.TotalDays % 365) / 30).ToString().Substring(0, ((ts.TotalDays % 365) / 30).ToString().IndexOf(".")) : ((ts.TotalDays % 365) / 30).ToString();
            printDoc.Age = year + " ปี " + (month == "0" ? "" : month + " เดือน");
            printDoc.ShowDialog();
        }
        private void mnumnuMergeSchedule_Click(object sender, EventArgs e)
        {
            tmRefresh.Stop();
            DateTime start = scControl.SelectedAppointments[0].Start;
            int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
            int _modality_id = Convert.ToInt32(scControl.SelectedAppointments[0].CustomFields["MODALITY_ID"].ToString());
            string hn = scControl.SelectedAppointments[0].CustomFields["HN"].ToString();


            frmScheduleMerge frm = new frmScheduleMerge(Schedule, _modality_id, start, hn);
            frm.ShowDialog();

            initialScheduleDataByModality("Refresh patient appointments data", "Load Data");
            tmRefresh.Start();
        }
        private void mnuPendingSchedule_Click(object sender, EventArgs e)
        {
            tmRefresh.Stop();
            DataRow[] rows = dttAppointment.Select("SCHEDULE_ID=" + scControl.SelectedAppointments[0].Location);
            Reason frmReason = new Reason(rows[0]["SCHEDULE_DATA"].ToString());
            if (frmReason.ShowDialog() == DialogResult.OK)
            {
                int id = Convert.ToInt32(rows[0]["SCHEDULE_ID"].ToString());
                udpateBusy(id, "Y");
                ProcessUpdateRISSchedule proc = new ProcessUpdateRISSchedule();
                proc.RIS_SCHEDULE.SCHEDULE_STATUS = 'P';
                proc.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                proc.RIS_SCHEDULE.SCHEDULE_ID = id;
                proc.UpdatePendingSchedule();

                proc.RIS_SCHEDULE.COMMENTS = frmReason.Comment;
                proc.UpdatePendingComments();

                saveLogs(id, "Update Schedule Pending(s)");

                udpateBusy(id, "N");
                initialScheduleDataByModality("Refresh patient appointments data", "Load Data");
            }
            tmRefresh.Start();
        }
        #endregion

        private void btnCheckTime_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            scControl.DayView.ShowWorkTimeOnly = btnCheckTime.Checked;
        }
        private void chkList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (ready)
            {
                checkModalityCase();
            }
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkList.Items.Count; i++)
                chkList.SetItemChecked(i, chkAll.Checked);
            checkModalityCase();
        }

        private List<string> modalitySelectList;
        private bool isNeedToBindData()
        {
            bool flag = true;
            if (modalitySelectList != null)
                if (modalitySelectList.Count > 0)
                {
                    List<string> lst = new List<string>();
                    for (int index = 0; index < chkList.Items.Count; index++)
                    {
                        if (chkList.GetItemChecked(index))
                        {
                            Object obj = chkList.Items[index].Value;
                            DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem rs = (DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem)obj;
                            lst.Add(rs.Resource.Id.ToString());
                        }
                    }
                    flag = false;
                    foreach (string s in lst)
                        if (modalitySelectList.IndexOf(s) == -1)
                        {
                            flag = true;
                            break;
                        }
                }
            return flag;
        }
        private void checkBindDataBySource()
        {
            if (isNeedToBindData())
            {
                modalitySelectList = new List<string>();
                if (chkList.CheckedItems.Count > 0)
                {
                    for (int index = 0; index < chkList.Items.Count; index++)
                    {
                        if (chkList.GetItemChecked(index))
                        {
                            Object obj = chkList.Items[index].Value;
                            DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem rs = (DevExpress.XtraScheduler.UI.ResourceCheckedListBoxItem)obj;
                            modalitySelectList.Add(rs.Resource.Id.ToString());
                        }
                    }
                    initialScheduleDataByModality("Load patients appointment.", "Load Schedule data");
                }
            }
        }
        private void initialScheduleDataByModality()
        {
            initialResourceControl();
            scControl.BeginUpdate();
            schedulerStorage1.BeginUpdate();
            initialScheduleData();
            initialAppointmentMapping();
            schedulerStorage1.Appointments.DataSource = dttAppointment;
            schedulerStorage1.EndUpdate();
            scControl.EndUpdate();
            scControl.Refresh();
        }
        private void initialScheduleDataByModality(string message, string title)
        {
            scControl.BeginUpdate();
            #region Load Schedule Data
            dttAppointment = null;
            initialScheduleData();
            #endregion

            #region Preparing User layout
            base.ShowWaitDialog(message, title);
            checkModalityCase();
            initialAppointmentMapping();
            schedulerStorage1.Appointments.DataSource = dttAppointment;
            base.CloseWaitDialog();
            #endregion
            try
            {
                scControl.EndUpdate();
            }
            catch (Exception ex)
            {
            }
            scControl.Refresh();
        }

        #region Waiting List.
        private void checkModalitySelect()
        {
            modalityId = new List<string>();
            if (chkList.CheckedItems.Count > 0)
            {
                DevExpress.XtraEditors.BaseCheckedListBoxControl.CheckedItemCollection items = chkList.CheckedItems;
                DataView dv = null;
                foreach (object obj in items)
                {
                    dv = new DataView(dttResource);
                    dv.RowFilter = "MODALITY_NAME='" + obj.ToString() + "'";
                    DataTable dtt = dv.ToTable();
                    if (Miracle.Util.Utilities.IsHaveData(dtt))
                        modalityId.Add(dtt.Rows[0]["MODALITY_ID"].ToString());
                }
            }
        }
        private void checkWaitingList()
        {
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            DataTable dt = proc.GetShowOnline();
            grdScheduleOnline.DataSource = dt;

            grdScheduleOnline.ForceInitialize();

            viewScheduleOnl.OptionsView.RowAutoHeight = true;
            viewScheduleOnl.OptionsView.ShowHorzLines = false;
            viewScheduleOnl.OptionsView.ColumnAutoWidth = false;

            for (int i = 0; i < viewScheduleOnl.Columns.Count; i++)
            {
                viewScheduleOnl.Columns[i].Visible = false;
            }

            viewScheduleOnl.Columns["SCH_TEXT"].GroupIndex = 1;
            viewScheduleOnl.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, string.Empty);

            //if (Miracle.Util.Utilities.IsHaveData(dt))
            //{
            //    string txtWL = dttWL.Rows.Count.ToString() + " Waiting online.";
            //    string txtPending = dttPending.Rows.Count.ToString() + " Pending online.";
            //    string txtAppoint = dttAppOnline.Rows.Count.ToString() + " Auto online.";

            //    lblWL.Text = txtWL;
            //    string showAlertBox = "";
            //    showAlertBox += "Online \r\n";
            //    showAlertBox += "- Waiting: [" + dttWL.Rows.Count.ToString() + "]\r\n";
            //    showAlertBox += "- Pending: [" + dttPending.Rows.Count.ToString() + "]\r\n";
            //    showAlertBox += "- Auto   : [" + dttAppOnline.Rows.Count.ToString() + "]";
            //    enableWaitingListDisableNavigator(true);
            //    if (txtWLHN.Text.Trim().Length == 0 && this.panelWL.ContentImage == null)
            //    {
            //        memAlertMSG.Text = showAlertBox;
            //        //DevExpress.XtraBars.Alerter.AlertInfo info = new DevExpress.XtraBars.Alerter.AlertInfo(showAlertBox, " ");
            //        //info.Image = Envision.NET.Properties.Resources.icoWL_Alert;
            //        //alertMsg.Show(this, info);
            //    }
            //    this.panelWL.ContentImage = Envision.NET.Properties.Resources.picAlarmBG;
            //    this.panelSearch.ContentImage = Envision.NET.Properties.Resources.picAlarmBG;
            //    tabCtrlList.SelectedTabPageIndex = 1;
            //    lblWL.ForeColor = Color.White;
            //    //cboSearchType.SelectedIndex = 1;
            //    return;
            //}
            //this.panelWL.ContentImage = null;
            //this.panelSearch.ContentImage = null;
            initWaitingListNavigator();
        }
        private void viewScheduleOnl_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            string caption = info.Column.Caption;
            if (info.Column.Caption == string.Empty)
                caption = info.Column.ToString();
            info.GroupText = string.Format("{0} : {1}", info.EditValue, view.GetChildRowCount(e.RowHandle));
        }
        private void setWaittingListTimer(bool directly)
        {
            tmWaitingList.Stop();
            int ml = Convert.ToInt32(TimeSpan.FromMinutes(ScheduleInfo.SCHEDULE_CONFIRM_TIME).TotalMilliseconds / 3);
            if (directly)
                tmWaitingList.Interval = 5;
            else
                tmWaitingList.Interval = ml;
            tmWaitingList.Start();
        }
        private void tmWaitingList_Tick(object sender, EventArgs e)
        {
            tmWaitingList.Stop();
            dttWL = null;
            initWaitingListNavigator();
            checkWaitingList();
            setWaittingListTimer(false);
        }

        private void setInternalMessageTimer()
        {
            int ml = Convert.ToInt32(TimeSpan.FromMinutes(ScheduleInfo.SCHEDULE_CONFIRM_TIME).TotalMilliseconds);
            tmIM.Interval = ml;
            tmIM.Start();
        }
        private void tmIM_Tick(object sender, EventArgs e)
        {
            tmIM.Stop();
            //ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            //DataTable dtt = proc.GetWaitingList();
            //if (Miracle.Util.Utilities.IsHaveData(dtt))
            //{
            //    string message = string.Empty;
            //    foreach (DataRow rowHandle in dtt.Rows)
            //    {
            //        int min = Convert.ToInt32(rowHandle["WAIT_MIN"].ToString());
            //        if (min >= ScheduleInfo.SCHEDULE_CONFIRM_TIME)
            //        {
            //            if (rowHandle["NOTIFY_ADMIN_WL"].ToString() == "N")
            //            {
            //                if (string.IsNullOrEmpty(message))
            //                    message = "These schedules are not confirmed within the specified time . Please take action\r\n\t\t";
            //                message += rowHandle["SCHEDULE_DATA"].ToString() + " " + rowHandle["REQUEST_BY"] + " Waiting " + rowHandle["MIN_TEXT"].ToString() + "\r\n\t\t";

            //                ProcessGetRISSchedule updateNotifyAdmin = new ProcessGetRISSchedule();
            //                proc.UpdateNotifyAdmin(Convert.ToInt32(rowHandle["SCHEDULE_ID"]), "Y");
            //            }
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(message))
            //    {
            //        Envision.NET.Forms.InternalMessage.frmSend frm = new Envision.NET.Forms.InternalMessage.frmSend();
            //        frm.SendAutoMessage("ADM001", "Schedule not confirmed", message);
            //        frm.Dispose();
            //    }
            //}
            tmIM.Start();
        }
        private void setInternalRefresh()
        {
            int ml = Convert.ToInt32(TimeSpan.FromMinutes(ScheduleInfo.SCHEDULE_REFRESH_TIME).TotalMilliseconds);
            tmRefresh.Interval = ml;
            tmRefresh.Start();
        }
        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            tmRefresh.Stop();
            initialScheduleDataByModality("Refresh patient appointments data", "Load Data");
            tmRefresh.Start();
        }

        private void initWaitingListNavigator()
        {
            if (Miracle.Util.Utilities.IsHaveData(dttWL)) return;
            btnWLFirst.Enabled = false;
            btnWLLast.Enabled = false;
            btnWLNext.Enabled = false;
            btnWLPrev.Enabled = false;
            this.panelWL.ContentImage = null;
            this.panelSearch.ContentImage = null;

        }
        private void enableWaitingListDisableNavigator(bool flag)
        {
            btnWLFirst.Enabled = flag;
            btnWLLast.Enabled = flag;
            btnWLNext.Enabled = flag;
            btnWLPrev.Enabled = flag;
        }
        private void scheduleNavigator(int Id, DateTime dtFrom, DateTime dtTo)
        {
            scControl.DayView.ShowWorkTimeOnly = false;
            btnCheckTime.Checked = false;
            AppointmentBaseCollection aptBase = schedulerStorage1.Appointments.Items.GetAppointments(new TimeInterval(dtFrom, dtTo));
            foreach (Appointment p in aptBase)
            {
                if (p.Location == Id.ToString())
                {
                    int i = 0;
                    for (; i < schedulerStorage1.Resources.Items.Count; i++)
                        if (schedulerStorage1.Resources.Items[i].Id.ToString() == p.ResourceId.ToString())
                        {
                            chkList.SetItemChecked(i, true);
                            break;
                        }
                    scControl.ActiveView.SelectAppointment(p);
                    break;
                }
            }
        }
        private void scheduleNavigator(DataRow rowHandle)
        {
            scControl.DayView.ShowWorkTimeOnly = false;
            btnCheckTime.Checked = false;
            DateTime dtFrom = Convert.ToDateTime(rowHandle["START_DATETIME"].ToString());
            DateTime dtTO = Convert.ToDateTime(rowHandle["END_DATETIME"].ToString());
            AppointmentBaseCollection aptBase = schedulerStorage1.Appointments.Items.GetAppointments(new TimeInterval(dtFrom, dtTO));
            foreach (Appointment p in aptBase)
            {
                if (p.Location == rowHandle["SCHEDULE_ID"].ToString())
                {
                    int i = 0;
                    for (; i < schedulerStorage1.Resources.Items.Count; i++)
                        if (schedulerStorage1.Resources.Items[i].Id.ToString() == p.ResourceId.ToString())
                        {
                            chkList.SetItemChecked(i, true);
                            break;
                        }
                    scControl.ActiveView.SelectAppointment(p);
                    break;
                }
            }
        }
        private void waitingListPosition()
        {
            if (tmWaitingList.Enabled == false) return;
            enableWaitingListDisableNavigator(true);
            if (posWL < 0) posWL = 0;
            if (posWL >= dttWL.Rows.Count) posWL = dttWL.Rows.Count - 1;
            DataRow rowHandle = dttWL.Rows[posWL];
            scheduleNavigator(rowHandle);
            string txt = dttWL.Rows.Count == 1 ? "1/1 appointment." : (posWL + 1) + "/" + dttWL.Rows.Count.ToString() + " appointments.";
            lblWL.Text = txt;
            lblWL.ForeColor = Color.White;
            tabCtrlList.SelectedTabPage = pageWL;
            cboSearchType.SelectedIndex = 1;
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

        #region Waiting List Button Navigators.
        private void btnWLFirst_Click(object sender, EventArgs e)
        {
            posWL = 0;
            waitingListPosition();
        }
        private void btnWLPrev_Click(object sender, EventArgs e)
        {
            posWL--;
            waitingListPosition();
        }

        private void btnWLNext_Click(object sender, EventArgs e)
        {
            posWL++;
            waitingListPosition();
        }
        private void btnWLLast_Click(object sender, EventArgs e)
        {
            posWL = dttWL.Rows.Count - 1;
            waitingListPosition();

        }
        #endregion

        private void txtWLHN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtWLHN.Text.Trim().Length > 0)
                {
                    checkWaitingList();
                    if (Miracle.Util.Utilities.IsHaveData(dttWL))
                    {
                        DataView dv = new DataView(dttWL);
                        dv.RowFilter = "HN='" + txtWLHN.Text.Trim() + "'";
                        DataTable dtt = dv.ToTable();
                        if (Miracle.Util.Utilities.IsHaveData(dtt))
                        {
                            dttWL = dv.ToTable();
                            posWL = 0;
                            waitingListPosition();
                        }
                        else
                        {
                            msg.ShowAlert("UID1419", env.CurrentLanguageID);
                            return;
                        }
                    }
                    else
                    {
                        msg.ShowAlert("UID1419", env.CurrentLanguageID);
                        return;
                    }
                }
                else
                {
                    checkWaitingList();
                    initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                }
            }
        }
        private void btnCheckTime_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSearchType.SelectedIndex == 0)
            {
                initNavigator();
                tabCtrlList.SelectedTabPage = pageSearch;
                cboRange.Visible = true;
                btnBrowse.Visible = false;
                initWaitingListNavigator();

                lblWL.Text = "Please key-in HN.";
                lblWL.ForeColor = Color.Black;
                txtWLHN.Text = string.Empty;
                lblWL.ForeColor = Color.Black;
            }
            else if (cboSearchType.SelectedIndex == 1)
            {
                cboRange.Visible = false;
                btnBrowse.Visible = true;
                int count = 0;
                if (Miracle.Util.Utilities.IsHaveData(dttWL))
                    count = dttWL.Rows.Count;
                checkWaitingList();
                tabCtrlList.SelectedTabPage = pageWL;
            }
            else
                cboRange.Visible = false;
        }
        private void cboRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRange.SelectedIndex > -1)
            {
                txtHNSearch.Text = string.Empty;
                dateNav.DateTime = currDT;

                curr = 0;
                enableDisableNavigator(false);
                lblExam.Text = string.Empty;
                txtHNSearch.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
                txtHNSearch.Focus();
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            frmWaitingList frm = new frmWaitingList();
            frm.dttBpview = dttBpview;
            frm.dttDepartment = dttDepartment;
            frm.dttDoctor = dttDoctor;
            frm.dttRadiologist = dttRadiologist;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (!frm.StartTime.Equals(DateTime.MinValue))
                    dateNav.DateTime = frm.StartTime;
                initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
                if (frm.ScheduleID > 0)
                    scheduleNavigator(frm.ScheduleID, frm.StartTime, frm.EndTime);
            }
            else
                initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            frm.Dispose();
        }
        #endregion

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

        private void btnCheckFreeSlot_Click(object sender, EventArgs e)
        {
            frmCheckFreeSlots frm = new frmCheckFreeSlots(chkList);
            frm.dateNavSelected = dateNav.SelectionStart.Date;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                base.ShowWaitDialog("Load schedule datasource", "Patient Schedule");

                DateTime dateFirstSart = new DateTime(selected_start_duration.Year, selected_start_duration.Month, selected_start_duration.Day, 0, 0, 0);
                DateTime dateFirstEnd = new DateTime(selected_start_duration.Year, selected_start_duration.Month, selected_start_duration.Day, 23, 59, 59);
                DateTime dateSecondSart = new DateTime(frm.dateNavSelected.Year, frm.dateNavSelected.Month, frm.dateNavSelected.Day, 0, 0, 0);
                DateTime dateSecondEnd = new DateTime(frm.dateNavSelected.Year, frm.dateNavSelected.Month, frm.dateNavSelected.Day, 23, 59, 59);

                ProcessGetRISSchedule prc = new ProcessGetRISSchedule();
                prc.RIS_SCHEDULE.ORG_ID = env.OrgID;
                prc.InvokeWorklist(dateFirstSart, dateFirstEnd);
                dttAppointment = prc.Result.Tables[0];

                prc.InvokeWorklist(dateSecondSart, dateSecondEnd);
                dttAppointment.Merge(prc.Result.Tables[0]);
                dttAppointment.AcceptChanges();

                DevExpress.XtraScheduler.Native.IDateNavigatorControllerOwner dn = dateNav as DevExpress.XtraScheduler.Native.IDateNavigatorControllerOwner;
                DayIntervalCollection coll = new DayIntervalCollection();
                coll.Add(new TimeInterval(dateFirstSart, dateFirstEnd));
                coll.Add(new TimeInterval(dateSecondSart, dateSecondEnd));
                dn.SetSelection(coll);
                dateNav.Refresh();

                scControl.ActiveViewType = SchedulerViewType.Day;

                TimeIntervalCollection colls = new TimeIntervalCollection();
                colls.Add(new TimeInterval(dateFirstSart, dateFirstEnd));
                colls.Add(new TimeInterval(dateSecondSart, dateSecondEnd));
                scControl.DayView.SetVisibleIntervals(colls);

                scControl.Storage.Appointments.BeginUpdate();
                try
                {
                    scControl.Storage.Appointments.DataSource = null;
                    if (Utilities.IsHaveData(dttAppointment))
                        scControl.Storage.Appointments.DataSource = dttAppointment.DefaultView;

                    scControl.Storage.RefreshData();
                }
                finally
                {
                    scControl.Storage.Appointments.EndUpdate();
                }
                selected_Freeslots = true;
                base.CloseWaitDialog();

            }
        }


        ITimeRulerFormatStringService prevTimeRulerFormatStringService;
        CustomTimeRulerFormatStringService customTimeRulerFormatStringService;
        IAppointmentFormatStringService prevAppointmentFormatStringService;
        CustomAppointmentFormatStringService customAppointmentFormatStringService;
        IHeaderCaptionService prevHeaderCaptionService;
        CustomHeaderCaptionService customHeaderCaptionService;
        IHeaderToolTipService prevHeaderToolTipService;
        CustomHeaderToolTipService customHeaderToolTipService;


        public void CreateAppointmentFormatStringService()
        {
            this.prevAppointmentFormatStringService = (IAppointmentFormatStringService)scControl.GetService(typeof(IAppointmentFormatStringService));
            this.customAppointmentFormatStringService = new CustomAppointmentFormatStringService(prevAppointmentFormatStringService);
        }
        public void CreateTimeRulerFormatStringService()
        {
            this.prevTimeRulerFormatStringService = (ITimeRulerFormatStringService)scControl.GetService(typeof(ITimeRulerFormatStringService));
            this.customTimeRulerFormatStringService = new CustomTimeRulerFormatStringService(prevTimeRulerFormatStringService);
        }
        public void CreateHeaderCaptionService()
        {
            this.prevHeaderCaptionService = (IHeaderCaptionService)scControl.GetService(typeof(IHeaderCaptionService));
            this.customHeaderCaptionService = new CustomHeaderCaptionService(prevHeaderCaptionService);
        }
        public void CreateHeaderToolTipService()
        {
            this.prevHeaderToolTipService = (IHeaderToolTipService)scControl.GetService(typeof(IHeaderToolTipService));
            this.customHeaderToolTipService = new CustomHeaderToolTipService(prevHeaderToolTipService);
        }

    }
    public class CustomTimeRulerFormatStringService : TimeRulerFormatStringServiceWrapper
    {
        public CustomTimeRulerFormatStringService(ITimeRulerFormatStringService service)
            : base(service)
        {
        }
        #region ITimeRulerFormatStringService Members
        public override string GetHalfDayHourFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "hh:mm" : "HH:mm";
        }
        public override string GetHourFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "hh:mm" : "HH:mm";
        }
        public override string GetHourOnlyFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "hh" : "HH";
        }
        public override string GetMinutesOnlyFormat(TimeRuler ruler)
        {
            return "mm";
        }
        public override string GetTimeDesignatorOnlyFormat(TimeRuler ruler)
        {
            return ruler.UseClientTimeZone ? "tt" : "mm";
        }
        #endregion
    }
    public class CustomAppointmentFormatStringService : AppointmentFormatStringServiceWrapper
    {
        public CustomAppointmentFormatStringService(IAppointmentFormatStringService service)
            : base(service)
        {
        }
        #region IAppointmentFormatStringService Members
        public override string GetVerticalAppointmentStartFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm:ss}";
        }
        public override string GetVerticalAppointmentEndFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm:ss}";
        }
        public override string GetHorizontalAppointmentEndFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm}";
        }
        public override string GetHorizontalAppointmentStartFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm}";
        }
        public override string GetContinueItemStartFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm MMM dd}";
        }
        public override string GetContinueItemEndFormat(IAppointmentViewInfo aptViewInfo)
        {
            return "{0: HHmm MMM dd}";
        }
        #endregion
    }
    public class CustomHeaderToolTipService : HeaderToolTipServiceWrapper
    {
        public CustomHeaderToolTipService(IHeaderToolTipService service)
            : base(service)
        {
        }

        #region IHeaderToolTipService Members
        public override string GetDayColumnHeaderToolTip(DayHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "Let's celebrate!";
            else
                return base.GetDayColumnHeaderToolTip(header);
        }
        public override string GetDayOfWeekHeaderToolTip(DayOfWeekHeader header)
        {
            if (header.Interval.Contains(new DateTime(2009, 1, 1)))
                return "Let's celebrate!";
            else
                return base.GetDayOfWeekHeaderToolTip(header);
        }
        public override string GetTimeScaleHeaderToolTip(TimeScaleHeader header)
        {
            if (header.Interval.Contains(new DateTime(2009, 1, 1)))
                return "Let's celebrate!";
            else
                return base.GetTimeScaleHeaderToolTip(header);
        }
        #endregion
    }
    public class CustomHeaderCaptionService : HeaderCaptionServiceWrapper
    {
        public CustomHeaderCaptionService(IHeaderCaptionService service)
            : base(service)
        {
        }

        #region IHeaderCaptionService Members
        public override string GetDayColumnHeaderCaption(DayHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "Happy New Year.";
            else
                return date.ToString("dddd, MMMM dd (yyyy)");
            //return base.GetDayColumnHeaderCaption(header);
        }

        public override string GetDayOfWeekAbbreviatedHeaderCaption(DayOfWeekHeader header)
        {
            DayOfWeek date = header.DayOfWeek;
            if (date == DayOfWeek.Thursday)
                return "DOW";
            else
                return base.GetDayOfWeekAbbreviatedHeaderCaption(header);
        }

        public override string GetDayOfWeekHeaderCaption(DayOfWeekHeader header)
        {
            DayOfWeek date = header.DayOfWeek;
            if (date == DayOfWeek.Thursday)
                return "DayOfWeekHeader";
            else
                return base.GetDayOfWeekHeaderCaption(header);
        }

        public override string GetHorizontalWeekCellHeaderCaption(SchedulerHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "HorizontalWeekCellHeader";
            else
                return base.GetHorizontalWeekCellHeaderCaption(header);

        }

        public override string GetTimeScaleHeaderCaption(TimeScaleHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "TimeScaleHeader";
            else
                return base.GetTimeScaleHeaderCaption(header);

        }

        public override string GetVerticalWeekCellHeaderCaption(SchedulerHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "VerticalWeekCellHeader";
            else
                return base.GetVerticalWeekCellHeaderCaption(header);

        }


        #endregion
    }

}

