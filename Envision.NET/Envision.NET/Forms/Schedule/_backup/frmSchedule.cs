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
namespace Envision.NET.Forms.Schedule
{
    public partial class frmSchedule : Envision.NET.Forms.Main.MasterForm  
    {
        private DataTable dttResource;
        private DataTable dttAppointment;
        private DataTable dttSession;
        private DataTable dttHNSearch;
        private DataTable dttModalityExam;
        private int curr;
        private EnvisionSearchRangeType searchRange;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private bool drag_drop;
        private bool ready;
        private bool delete_recurrence;
        private string modalitySelect;
        private string reasonText;
        private DateTime currDT;
        private bool is_come = false;
        private int scheduleId = 0;

        public frmSchedule()
        {
            InitializeComponent();
            bgCrystal.RunWorkerAsync();
            initialModalityData();
            drag_drop = false;
            ready = false;
            delete_recurrence = false;
            scheduleId = 0;
            searchRange = EnvisionSearchRangeType.ThreeMonth;
            reasonText = string.Empty;
            xtraGridBlending1.GridControl.BackgroundImage = global::Envision.NET.Properties.Resources.gridBG;
            lblExam.Text = string.Empty;
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            initialScheduler();
            initialScheduleData();
            initNavigator();
            initDataGridSession();
            
            initailModalityExam();
            initialResourceControl();

            initialAppointmentMapping();
            initialAppointmentControl();
            
            ready = true;
            base.CloseWaitDialog();
        }

        private void initialScheduler()
        {
            currDT = DateTime.Today;
            modalitySelect = string.Empty;
            dateNav.DateTime = DateTime.Today;
            dateNav.DateTime = DateTime.Today.AddMonths(1);
            dateNav.DateTime = currDT;

            scControl.GroupType = SchedulerGroupType.Resource;
            scControl.Start = DateTime.Now;
            scControl.DayView.ShowAllDayArea = false;
            scControl.Storage.EnableReminders = false;
            scControl.DayView.ShowWorkTimeOnly = true;
            btnCheckTime.Checked = true;
        }
        private void initailModalityExam() {
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
                setGridSession(dttSession);
        }
        private bool isModalityMapExam(int scheduleID, int  modalityID)
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
                DataTable dttModality=procModality.Result.Tables[0].Copy();

                ProcessGetRISScheduledtl procSchedule = new ProcessGetRISScheduledtl(scheduleID);
                procSchedule.Invoke();
                DataTable dtt = procSchedule.Result.Tables[0].Copy();
                
                foreach (DataRow row in dtt.Rows) {
                    DataRow[] rows = dttModality.Select("IS_ACTIVE='Y' AND EXAM_ID=" + row["EXAM_ID"].ToString());
                    if (rows.Length == 0)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            catch {
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
        private bool isConflictNotFree(int scheduleID, int modalityID, string HN, DateTime dtStart, DateTime dtEnd)
        {
            bool flag = true;
            try
            {
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
                schedule.RIS_SCHEDULE.HN = HN;
                schedule.RIS_SCHEDULE.START_DATETIME = dtStart;
                schedule.RIS_SCHEDULE.END_DATETIME = dtEnd;
                schedule.RIS_SCHEDULE.MODALITY_ID = modalityID;
                DataTable dtt = new DataTable();
                dtt = schedule.CheckConfilctDateTime();
                flag = Miracle.Util.Utilities.IsHaveData(dtt) ? true : false;
                if (flag == false)
                {
                    dtt = new DataTable();
                    flag = schedule.CheckFreeTime();
                    flag = !flag;
                }
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
                    DateTime dtSt = new DateTime(dtStart.Year,  dtStart.Month, dtStart.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                    DateTime dtEn = new DateTime(dtEnd.Year,    dtEnd.Month,     dtEnd.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);
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
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dttResource = process.GetModality();
        }
        private void initialScheduleData()
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RIS_SCHEDULE.TYPE = (int)searchRange;
            dttAppointment = process.GetScheduleData();

            #region Way - select resource and bindData.
            //dttAppointment = new DataTable();
            //#region Initialte RIS_SCHEDULE table.
            //dttAppointment.Columns.Add("SCHEDULE_ID", typeof(int));
            //dttAppointment.Columns.Add("REG_ID", typeof(int));
            //dttAppointment.Columns.Add("SCHEDULE_DT", typeof(DateTime));
            //dttAppointment.Columns.Add("MODALITY_ID", typeof(int));
            //dttAppointment.Columns.Add("SCHEDULE_DATA", typeof(string));
            //dttAppointment.Columns.Add("LABEL", typeof(int));
            //dttAppointment.Columns.Add("LOCATION", typeof(string));
            //dttAppointment.Columns.Add("EVENTTYPE", typeof(int));
            //dttAppointment.Columns.Add("SESSION_ID", typeof(int));
            //dttAppointment.Columns.Add("START_DATETIME", typeof(DateTime));
            //dttAppointment.Columns.Add("END_DATETIME", typeof(DateTime));
            //dttAppointment.Columns.Add("REF_UNIT", typeof(int));
            //dttAppointment.Columns.Add("REF_DOC", typeof(int));
            //dttAppointment.Columns.Add("REF_DOC_INSTRUCTION", typeof(string));
            //dttAppointment.Columns.Add("CLINICAL_INSTRUCTION", typeof(string));
            //dttAppointment.Columns.Add("REASON", typeof(string));
            //dttAppointment.Columns.Add("DIAGNOSIS", typeof(string));
            //dttAppointment.Columns.Add("PAT_STATUS", typeof(int));
            //dttAppointment.Columns.Add("LMP_DT", typeof(DateTime));
            //dttAppointment.Columns.Add("ICD_ID", typeof(int));
            //dttAppointment.Columns.Add("SCHEDULE_STATUS", typeof(string));
            //dttAppointment.Columns.Add("INSURANCE_TYPE_ID", typeof(int));
            //dttAppointment.Columns.Add("CONFIRMED_BY", typeof(int));
            //dttAppointment.Columns.Add("CONFIRMED_ON", typeof(DateTime));
            //dttAppointment.Columns.Add("IS_BLOCKED", typeof(string));
            //dttAppointment.Columns.Add("BLOCK_REASON", typeof(string));
            //dttAppointment.Columns.Add("COMMENTS", typeof(string));
            //dttAppointment.Columns.Add("ORG_ID", typeof(int));
            //dttAppointment.Columns.Add("CREATED_BY", typeof(int));
            //dttAppointment.Columns.Add("CREATED_ON", typeof(DateTime));
            //dttAppointment.Columns.Add("LAST_MODIFIED_BY", typeof(int));
            //dttAppointment.Columns.Add("LAST_MODIFIED_ON", typeof(DateTime));
            //dttAppointment.Columns.Add("HN", typeof(string));
            //dttAppointment.Columns.Add("CommandType", typeof(string)); 
            //#endregion
            //dttAppointment.AcceptChanges(); 
            #endregion
        }

        private void initialResourceControl()
        {
            schedulerStorage1.Resources.Mappings.Id = "MODALITY_ID";
            schedulerStorage1.Resources.Mappings.Caption = "MODALITY_NAME";
            schedulerStorage1.Resources.DataSource = dttResource;

            for (int i = 0; i < chkList.Items.Count; i++)
                chkList.SetItemChecked(i, false);
        }
        private void initialAppointmentMapping() {
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


            schedulerStorage1.Appointments.CustomFieldMappings[0].Name = "CommandType";
            schedulerStorage1.Appointments.CustomFieldMappings[0].Member = "CommandType";

            schedulerStorage1.Appointments.CustomFieldMappings[1].Name = "SCHEDULE_ID";
            schedulerStorage1.Appointments.CustomFieldMappings[1].Member = "SCHEDULE_ID";

            schedulerStorage1.Appointments.CustomFieldMappings[2].Name = "SCHEDULE_STATUS";
            schedulerStorage1.Appointments.CustomFieldMappings[2].Member = "SCHEDULE_STATUS";

            schedulerStorage1.Appointments.CustomFieldMappings[3].Name = "MODALITY_ID";
            schedulerStorage1.Appointments.CustomFieldMappings[3].Member = "MODALITY_ID";

            schedulerStorage1.Appointments.CustomFieldMappings[4].Name = "START_DATETIME";
            schedulerStorage1.Appointments.CustomFieldMappings[4].Member = "START_DATETIME";

            schedulerStorage1.Appointments.CustomFieldMappings[5].Name = "END_DATETIME";
            schedulerStorage1.Appointments.CustomFieldMappings[5].Member = "END_DATETIME";

            schedulerStorage1.Appointments.CustomFieldMappings[6].Name = "HN";
            schedulerStorage1.Appointments.CustomFieldMappings[6].Member = "HN";

            schedulerStorage1.Appointments.CustomFieldMappings[7].Name = "LOCATION";
            schedulerStorage1.Appointments.CustomFieldMappings[7].Member = "LOCATION";

            schedulerStorage1.Appointments.CustomFieldMappings[8].Name = "IS_BLOCKED";
            schedulerStorage1.Appointments.CustomFieldMappings[8].Member = "IS_BLOCKED";
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

                

                int selectIndex = rdoRange.SelectedIndex == 0 ? 1 : rdoRange.SelectedIndex == 1 ? 2 : 3;
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
                if (dttHNSearch.Rows.Count == 0)
                {
                    curr = 0;
                    lblExam.Text = string.Empty;
                    enableDisableNavigator(false);
                    lblResult.Text = "Schedule(s) not found.";
                }
                else if (dttHNSearch.Rows.Count == 1)
                {
                    curr = 0;
                    scheduleNavigator();
                    enableDisableNavigator(false);
                    lblResult.Text = "1 schedule found for this HN.";
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
                        for (int i = 0; i < dttHNSearch.Rows.Count; i++)
                            if (dttHNSearch.Rows[i]["SCHEDULE_ID"].ToString() == id.ToString())
                            {
                                curr = i;
                                break;
                            }
                        scheduleNavigator();
                    }

                }
            }
            catch {
                DataTable dtt = dttHNSearch.Clone();
                dttHNSearch = null;
                dttHNSearch = dtt;
                curr = 0;
                enableDisableNavigator(false);
                lblExam.Text = string.Empty;
                txtHNSearch.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
            }
        }
        private void scheduleNavigator()
        {
            scControl.DayView.ShowWorkTimeOnly = false;
            btnCheckTime.Checked = false;
            lblExam.Text = dttHNSearch.Rows[curr]["EXAM_NAME"].ToString();
            DateTime dtFrom = Convert.ToDateTime(dttHNSearch.Rows[curr]["START_DATETIME"].ToString());
            DateTime dtTO = Convert.ToDateTime(dttHNSearch.Rows[curr]["END_DATETIME"].ToString());
            
            
            AppointmentBaseCollection aptBase = schedulerStorage1.Appointments.Items.GetAppointments(new TimeInterval(dtFrom, dtTO));
            foreach (Appointment p in aptBase)
            {
                if (p.Location == dttHNSearch.Rows[curr]["SCHEDULE_ID"].ToString())
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
            else if (txtHNSearch.Text.Trim().Length == 0) {
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

        private void rdoRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoRange.SelectedIndex > -1)
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
        #endregion

        #region Initial Session Data.
        private void initDataGridSession()
        {
            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
            process.Invoke();
            dttSession = new DataTable();
            dttSession = process.Result.Tables[0].Copy();
            setGridSession(dttSession);
        }
        private void setGridSession(DataTable dtt)
        {
            grdSchedule.DataSource = dtt;
            if (view1.Columns.Count == 0) return;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;
            RepositoryItemImageComboBox rImcb = new RepositoryItemImageComboBox();
            rImcb.SmallImages = ImgSession;
            rImcb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
                new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3)
            });
            rImcb.Buttons.Clear();

            view1.Columns["SESSION_ID"].Visible = true;
            view1.Columns["SESSION_ID"].Width = 20;
            view1.Columns["SESSION_ID"].ColumnEdit = rImcb;
            view1.Columns["SESSION_ID"].VisibleIndex = 2;
            view1.Columns["SESSION_NAME"].Visible = true;
            view1.Columns["SESSION_NAME"].Width = 300;
            view1.Columns["SESSION_NAME"].VisibleIndex = 1;
            view1.Columns["APP"].Visible = true;
            view1.Columns["APP"].Width = 100;
            view1.Columns["APP"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            view1.Columns["APP"].VisibleIndex = 3;
            //c.AppearanceCell.TextOptions.HAlignment = HorzAlignmentByString(alignment);
            // scControl.Views.DayView.WorkTime.Start = DateTime.Now.TimeOfDay;
            //view1.FocusedRowHandle = -2147483648;

            //TimeSpan timeSP = new TimeSpan(1, 00, 00);
            //TimeSpan timeEP = new TimeSpan(23, 59, 00);
            //scControl.Views.DayView.WorkTime.Start = timeSP;
            //scControl.Views.DayView.WorkTime.End = timeEP;
            //timeSP = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //timeEP = timeSP.Add(TimeSpan.FromMinutes(10));
            //scControl.Views.DayView.WorkTime.Start = timeSP;
            //scControl.Views.DayView.WorkTime.End = timeEP;

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
                foreach (DataRow dr in dtt.Rows)
                {
                    DateTime tmp = Convert.ToDateTime(dr["START_TIME"].ToString());
                    DateTime start = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day, tmp.Hour, tmp.Minute, tmp.Second);
                    tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                    DateTime end = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day, tmp.Hour, tmp.Minute, tmp.Second);

                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                    proc.RIS_SCHEDULE.MODALITY_ID = id;
                    // proc.RIS_SCHEDULE.APPOINT_DT = start;
                    proc.RIS_SCHEDULE.START_DATETIME = start;
                    proc.RIS_SCHEDULE.END_DATETIME = end;
                    DataTable dtmp = proc.GetSessionCount();
                    dr["APP"] = dtmp.Rows[0][0].ToString() + "/" + dr["MAX_APP"].ToString();
                }
                dtt.AcceptChanges();
                grdSchedule.DataSource = null;
                setGridSession(dtt);
            }
        }
        
        #endregion

        #region Schedule Control.
        private void scControl_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e)
        {
            //This event for check condition for only drag_drop before schedulerStorage1_AppointmentChanging occur
            try
            {
                #region GetAppontment Information. 
                DateTime start = e.EditedAppointment.Start;
                DateTime end = e.EditedAppointment.End;
                if (start < DateTime.Now)
                {
                    e.Allow = false;
                    e.Handled = true;
                    drag_drop = false;
                    return;
                } 
                DataTable dtt = new DataTable();
                int scheduleID = 0;
                int modalityID = 0;
                int weekend = 0;
                string hn = string.Empty;
                string block = string.Empty;
                if (e.SourceAppointment.IsRecurring)
                {
                    if (string.IsNullOrEmpty(e.EditedAppointment.CustomFields["LOCATION"].ToString()))
                        scheduleID = Convert.ToInt32(e.EditedAppointment.Location);
                    else
                        scheduleID = Convert.ToInt32(e.EditedAppointment.CustomFields["LOCATION"].ToString());
                }
                else
                    scheduleID = Convert.ToInt32(e.EditedAppointment.Location);
                modalityID = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
                weekend = Convert.ToInt32(e.EditedAppointment.Start.DayOfWeek);
                hn = e.EditedAppointment.CustomFields["HN"].ToString();
                block = e.EditedAppointment.CustomFields["IS_BLOCKED"].ToString(); 
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
                    if(isHaveBlock(scheduleID,modalityID,e.EditedAppointment.Start,e.EditedAppointment.End,'N'))
                    {
                        string s = msg.ShowAlert("UID1107", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    #endregion

                    #region Check patient conflict.
                    //if(isConflictNotFree(scheduleID,modalityID, hn,e.EditedAppointment.Start,e.EditedAppointment.End))
                    //{
                    //    string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                    //    e.Allow = false;
                    //    e.Handled = true;
                    //    drag_drop = false;
                    //    return;
                    //}
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
                DialogResult dlg = confrim.ShowDialog();
                if (dlg == DialogResult.Cancel)
                {
                    e.Allow = false;
                    e.Handled = true;
                    drag_drop = false;
                    reasonText = string.Empty;
                }
                else
                {
                    drag_drop = true;
                    reasonText = confrim.REASON;
                }
                confrim.Dispose();
            }
            catch (Exception ex)
            {
                e.Allow = false;
                e.Handled = true;
                drag_drop = false;
            }
        }
        private void scControl_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            if (e.Appointment.ResourceId.ToString() == "DevExpress.XtraScheduler.Resource")
            {
                e.Handled = true;
            }
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
                    if (e.Appointment.Start >= DateTime.Now)
                    {
                        #region Show Appointment.
                        if (string.IsNullOrEmpty(e.Appointment.Location))
                        {
                            #region New Appontment.
                            frmAppointment frm = new frmAppointment(sender as SchedulerControl, e.Appointment,dttAppointment);
                            e.Handled = true;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Text = "New - Appointment";
                            e.Appointment.Subject = "New";
                            e.DialogResult = frm.ShowDialog();
                            frm.Hide();
                            frm.Dispose();
                            #endregion
                        }
                        else
                        {
                            #region Edit Appoinetment
                            frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment,dttAppointment);
                            e.Handled = true;
                            frm.Text = e.Appointment.Subject;
                            e.DialogResult = frm.ShowDialog();
                            row = frm.RowAppointment;
                            id = frm.SCHEDULE_ID;
                            frm.Dispose();
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
                            #region Edit Old Appointment.
                            frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment,dttAppointment);
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
                        if (id == -1) return;
                        if(id!=0)
                            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule"); 
                        else
                            initialScheduleDataByModality("Insert this appointment to datasource.", "Patient Schedule");  
                    }
                }
            }
        }
        private void scControl_PreparePopupMenu(object sender, DevExpress.XtraScheduler.PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {   
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.RestoreOccurrence);

                e.Menu.Items[0].Image = Envision.NET.Properties.Resources.rightclick_open;
                e.Menu.Items[2].Image = Envision.NET.Properties.Resources.rightclick_delete;

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

                DevExpress.Utils.Menu.DXMenuItem mnuLabData = new DevExpress.Utils.Menu.DXMenuItem("View Lab Data");
                mnuLabData.Click += new EventHandler(mnuLabData_Click);
                mnuLabData.Image = Envision.NET.Properties.Resources.rightclick_lab;
                e.Menu.Items.Add(mnuLabData);

                DevExpress.Utils.Menu.DXMenuItem mnuComments = new DevExpress.Utils.Menu.DXMenuItem("Comments");
                mnuComments.Click += new EventHandler(mnuComments_Click);
                mnuComments.Image = Envision.NET.Properties.Resources.mail_reply_all_3;
                e.Menu.Items.Add(mnuComments);

                DevExpress.Utils.Menu.DXMenuItem mnuEmail = new DevExpress.Utils.Menu.DXMenuItem("Email");
                mnuEmail.Click += new EventHandler(mnuEmail_Click);
                mnuEmail.Image = Envision.NET.Properties.Resources.rightclick_mail;
                e.Menu.Items.Add(mnuEmail);
            }
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                DevExpress.Utils.Menu.DXMenuItem mnuRefresh = new DevExpress.Utils.Menu.DXMenuItem("Refresh");
                mnuRefresh.Click += new EventHandler(mnuRefresh_Click);
                e.Menu.Items.Add(mnuRefresh);
            }
        }
      
        private void scControl_SelectionChanged(object sender, EventArgs e)
        {
            checkModalityCase();
        }
        private void scControl_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            object data = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "SCHEDULE_STATUS");
            if (data != null)
            {
                if (data.ToString().ToUpper() == "O")
                {
                    if (scControl.ActiveView.Type == SchedulerViewType.Day && (dateNav.SelectionStart.ToShortDateString()==dateNav.SelectionEnd.ToShortDateString()))
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
            }
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
                string status = apt.CustomFields["SCHEDULE_STATUS"].ToString().Trim();
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
                else {
                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule(Convert.ToInt32(apt.Location));
                    proc.Invoke();
                    DataTable dtt = proc.Result.Tables[0].Copy();
                    if (Miracle.Util.Utilities.IsHaveData(dtt)) {
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
                    process.RIS_SCHEDULE.REASON_CHANGE = reasonText;
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
            apt.End = end;
            drag_drop = false;
            delete_recurrence = false;
            is_come = false;
        }
        private void schedulerStorage1_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            if (is_come)
                return;
            Appointment apt = e.Object as Appointment;
            string status = apt.CustomFields[2].ToString();
            if (status == "O")
            {
                msg.ShowAlert("UID1103", env.CurrentLanguageID);
                e.Cancel = true;
                return;
            }
            string schduleID = apt.CustomFields[1].ToString();
            string modality = apt.CustomFields[3].ToString(); 
            DateTime start = apt.Start;
            DateTime end = apt.End;
            
            ConfirmDialog confrim = new ConfirmDialog(Convert.ToInt32(schduleID), modality, start, end);
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
                    process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    process.Invoke();
                    #endregion
                }
            }
            initialScheduleDataByModality("Update schedule datasource", "Patient Schedule");
            drag_drop = false;
            delete_recurrence = true;
        }
        private void schedulerStorage1_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            if (scheduleId > 0) {
                //delete series.
                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(scheduleId);
                process.RIS_SCHEDULE.REASON_CHANGE = reasonText;
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
                            ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                            geExam.Invoke();
                            DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dts.Rows[0]["EXAM_UID"].ToString() + "'");
                            if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                            {
                                if (drExam[0]["UNIT_ID"].ToString() == "2")
                                {
                                    if (dts.Rows[0]["MODALITY_ID"].ToString().Contains("91"))
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.ScheduleDirectPrintMultiER(dts);
                                    }
                                    else
                                    {
                                        Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                        print.ScheduleDirectPrintMultiAIMC(dts);
                                    }
                                }
                                else
                                {
                                    Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                                    print.ScheduleDirectPrintMulti(dts);
                                }
                            }
                        }
                        #endregion
                    }
                }
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                    if (HN.Trim().ToLower() == "block") return;
                    DateTime start = scControl.SelectedAppointments[0].Start;
                    int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());

                    ProcessGetRISSchedule geSch = new ProcessGetRISSchedule(Schedule);
                    geSch.Invoke();
                    DataTable dtt = geSch.Result.Tables[0];
                    ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                    geExam.Invoke();
                    DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dtt.Rows[0]["EXAM_ID"].ToString());
                    if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                    {
                        if (drExam[0]["UNIT_ID"].ToString() == "2")
                        {
                            Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                            print.ScheduleDirectPrintAIMC(HN, start, Modality, Schedule);
                        }
                        else
                        {
                            Envision.Plugin.DirectPrint.DirectPrint print = new Envision.Plugin.DirectPrint.DirectPrint();
                            print.ScheduleDirectPrint(HN, start, Modality, Schedule);
                        }
                    }

                }
        }
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
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
                    
                    ProcessGetRISExam geExam = new ProcessGetRISExam(true);
                    geExam.Invoke();
                    DataRow[] drExam = geExam.Result.Tables[0].Select("EXAM_UID='" + dts.Rows[0]["EXAM_UID"].ToString()+"'");
                    if (!string.IsNullOrEmpty(drExam[0]["UNIT_ID"].ToString()))
                    {
                        if (drExam[0]["UNIT_ID"].ToString() == "2")
                        {

                            //ReportMangager rptManager = new ReportMangager();
                            //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptScheduleReportAIMC(HN, start, Modality, Schedule));
                            //rptViewer.StartPosition = FormStartPosition.CenterScreen;
                            //rptViewer.ShowDialog();
                        }
                        else
                        {
                            ReportMangager rptManager = new ReportMangager();
                            Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptScheduleReport(dts));
                            rptViewer.StartPosition = FormStartPosition.CenterScreen;
                            rptViewer.ShowDialog();
                        }
                    }




                }
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            //initialScheduleData();
            //initialAppointmentControl();
            //schedulerStorage1.RefreshData();
            //scControl.Refresh();

            //modality show case.
            initialScheduleDataByModality("Refresh patient appointments data", "Load Data");

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
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    int scheduleID = Convert.ToInt32(scControl.SelectedAppointments[0].Location);
                    frmChangeModality dlg = new frmChangeModality(scheduleID, dttAppointment);
                    if (DialogResult.OK == dlg.ShowDialog()) {
                        initialScheduleDataByModality("Update schedule datasource", "Patient Schedule"); 
                    }
                    dlg.Dispose();
                }
        }
        private void mnuComments_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                    if (HN.Trim().ToLower() == "block") return;
                    DateTime start = scControl.SelectedAppointments[0].Start;
                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
                    ProcessGetRISSchedule geSch = new ProcessGetRISSchedule(Schedule);
                    geSch.Invoke();
                    if (geSch.Result.Tables[1].Rows.Count == 1)
                    {
                        Comment.CommentForm frm = new Envision.NET.Comment.CommentForm(HN, Schedule, Convert.ToInt32(geSch.Result.Tables[1].Rows[0]["EXAM_ID"].ToString()), Envision.NET.Comment.CommentForm.QueryFromMode.Schedule);
                        frm.ShowDialog();
                        frm.Dispose();
                    }
                    else {
                        Comment.CommentForm frm = new Envision.NET.Comment.CommentForm(HN, scheduleId, 0, Envision.NET.Comment.CommentForm.QueryFromMode.Schedule);
                        frm.ShowDialog();
                        frm.Dispose();
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
                        PointerStruct[] p = PointerStruct.GetPointerStruct();
                        PointerStruct.ImageUrl = env.PacsUrl2;
                        int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
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
                        else {
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
                            save = new ScanImage(HN, Schedule, dtOrderImage,"Y");
                        env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
                 }
        }
        private void mnuLabData_Click(object sender, EventArgs e)
        {
             if (scControl.SelectedAppointments != null)
                 if (scControl.SelectedAppointments.Count > 0)
                 {
                     string HN = scControl.SelectedAppointments[0].CustomFields[6].ToString();
                     if (HN.Trim().ToLower() == "block") return;
                     try
                     {
                         HIS_Patient HIS_p = new HIS_Patient();
                         DataSet dsHIS = HIS_p.Get_lab_data(HN);
                         if (dsHIS.Tables[0].Rows.Count > 0)
                         {
                             Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
                             lv.ValueUpdated += new ValueUpdatedEventHandler(lv_ValueUpdated);
                             lv.Text = "Lab Detail List";
                             lv.Data = dsHIS.Tables[0];
                             Size ss = new Size(800, 600);
                             lv.Size = ss;
                             lv.PreviewFieldName = "report";
                             lv.SortFieldName = "lab_date";
                             lv.ShowDescription = true;
                             lv.ShowBox();
                         }
                     }
                     catch (Exception ex)
                     {
                         msg.ShowAlert("UID4022", new GBLEnvVariable().CurrentLanguageID);
                     }
                 }
        }
        private void lv_ValueUpdated(object sender, ValueUpdatedEventArgs e)
        {
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

        private void view1_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {

                string ModalityName = scControl.ActiveView.SelectedResource.Caption;
                if (ModalityName == "(Any)") return;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int ModalityId = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());

                DateTime dt = dateNav.SelectionStart;
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                DateTime dtSeStart = Convert.ToDateTime(dr["START_TIME"]);
                DateTime dtSeEnd = Convert.ToDateTime(dr["END_TIME"]);

                if (!dr.IsNull(0))
                {
                   
                    DateTime dtFrom = new DateTime(dt.Year, dt.Month, dt.Day, dtSeStart.Hour, dtSeStart.Minute, dtSeStart.Second);
                    DateTime dtEnd = new DateTime(dt.Year, dt.Month, dt.Day, dtSeEnd.Hour, dtSeEnd.Minute, dtSeEnd.Second);
                    ProcessGetRptScheduleCountAppoint getRpt = new ProcessGetRptScheduleCountAppoint();
                    //getRpt.ReportParameters.Session = Convert.ToInt32(dr["SESSION_ID"]);
                    getRpt.ReportParameters.ModalityId = ModalityId;
                    getRpt.ReportParameters.FromDate = dtFrom;
                    getRpt.ReportParameters.ToDate = dtEnd;
                    getRpt.Invoke();
                    DataTable dtXrpt = new DataTable();
                    dtXrpt = getRpt.Result.Tables[0];
                    if (dtXrpt.Rows.Count > 0)
                    {
                        Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint rptSCA = new Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint("Modality : "+ModalityName);
                        rptSCA.DataSource = dtXrpt;
                        rptSCA.ShowPreviewMarginLines = false;
                        rptSCA.ShowPreview();
                    }
                }

            }
        }

        private List<string> modalitySelectList;
        private bool isNeedToBindData() {
            bool flag = true;
            if(modalitySelectList!=null)
                if (modalitySelectList.Count > 0) {
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
                    foreach(string s in lst)
                        if (modalitySelectList.IndexOf(s) == -1)
                        {
                            flag = true;
                            break;
                        }
                }
            return flag;
        }
        private void checkBindDataBySource() {
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
        private void initialScheduleDataByModality(string message,string title)
        {
            //if (modalitySelectList == null) return;
            //if (modalitySelectList.Count == 0) return;

            
            dttAppointment.AcceptChanges();


            scControl.BeginUpdate();

            #region Way - select resource by Data.
            //DataTable dttTemp = dttAppointment.Clone();
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //foreach (string mid in modalitySelectList)
            //{
            //    process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(mid);
            //    process.RIS_SCHEDULE.HN = txtHNSearch.Text;
            //    DataTable dtt = process.GetScheduleData();
            //    foreach (DataRow dr in dtt.Rows)
            //        dttTemp.Rows.Add(dr.ItemArray);
            //}
            //dttAppointment = dttTemp.Copy();
            //initialAppointmentMapping();
            //schedulerStorage1.Appointments.DataSource = dttAppointment;
            
            #endregion
            
            base.ShowWaitDialog(message,title);
            initialScheduleData();
            initialAppointmentMapping();
            schedulerStorage1.Appointments.DataSource = dttAppointment;
            scControl.EndUpdate();
            scControl.Refresh();
            base.CloseWaitDialog();
        }

        private void bgCrystal_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //Envision.Plugin.ReportManager.ReportMangager rptManager = new Envision.Plugin.ReportManager.ReportMangager();
                //Envision.NET.Reports.ReportViewer.frmReportViewer rptViewer = new Envision.NET.Reports.ReportViewer.frmReportViewer(rptManager.rptOrderReport(0, env.UserID));
            }
            catch (Exception ex)
            {

            }
        }
        private void bgCrystal_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgCrystal.CancelAsync();
        }
    }
}

