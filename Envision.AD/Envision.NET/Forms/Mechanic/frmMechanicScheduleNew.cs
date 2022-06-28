using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.BusinessLogic.ProcessCreate;
using DevExpress.XtraScheduler.Xml;
using Envision.NET.Forms.ScheduleEmployee;

namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMechanicScheduleNew : Form
    {
        private SchedulerControl control;
        private Appointment apt;

        private DataTable RIS_MODALITY;
        private List<int> MODALITY_ID = new List<int>();

        private DataTable HR_EMP;
        private List<int> EMP_ID = new List<int>();

        private DataTable RIS_MODALITYMAINTENANCETYPE;
        private List<int> MTN_TYPE_ID = new List<int>();

        private DateTime MTN_DT;

        public int sch_id = -1;
        public int mod_id = -1;

        bool openRecurrenceForm = false;

        MyAppointmentFormController controller;

        List<DateTime> start_list = new List<DateTime>();
        List<DateTime> end_list = new List<DateTime>();

        bool can_inserted = false;

        public frmMechanicScheduleNew(SchedulerControl control, Appointment apt)
        {
            InitializeComponent();
            this.apt = apt;
            this.control = control;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");

            ReloadModality();
            ReloadPerson();
            ReLoadScheduleType();

            string name = "";
            DataRow[] rows = RIS_MODALITY.Select("MODALITY_ID = " + apt.ResourceId.ToString());
            if (rows.Length > 0)
                name = rows[0]["MODALITY_NAME"].ToString();
            txtModality.Text = name;
            if (txtScheduleType.Properties.Items.Count > 0)
                txtScheduleType.SelectedIndex = 0;
            txtDateStart.DateTime = apt.Start;
            txtDateEnd.DateTime = apt.End;
            if (apt.Location.Trim().Length == 0)
            {
                txtTimeStart.Time = apt.Start;
                txtTimeEnd.Time = apt.End;
            }
            if (txtPerson.Properties.Items.Count > 0)
                txtPerson.SelectedIndex = 0;

            MTN_DT = DateTime.Now;

            #region Recurrent Control Setting

            RepositoryItemRadioGroup txtRecurrentRadio_edit = (RepositoryItemRadioGroup)txtRecurrentRadio.Edit;
            txtRecurrentRadio_edit.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Once", "Once"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Week", "Every Week"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Month", "Every Month"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3Month", "Every 3 Month"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("6Month", "Every 6 Month"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Year", "Every Year")});
            txtRecurrentRadio.EditValue = "Once";

            RepositoryItemComboBox txtRecurrentTimePeriod_edit = (RepositoryItemComboBox)txtRecurrentTimePeriod.Edit;
            txtRecurrentTimePeriod_edit.Items.AddRange(new object[] {
            "1 Year",
            "2 Years"});
            txtRecurrentTimePeriod.EditValue = "1 Year";
            #endregion

            this.controller = new MyAppointmentFormController(control, apt);
        }

        private void LoadPersonData()
        {
            ProcessGetHREmp getData = new ProcessGetHREmp();
            getData.HR_EMP.MODE = "All";
            getData.HR_EMP.EMP_ID = 0;
            getData.HR_EMP.USER_NAME = "";
            getData.HR_EMP.UNIT_ID = 0;
            getData.HR_EMP.AUTH_LEVEL_ID = 0;
            getData.Invoke();
            HR_EMP = getData.Result.Tables[0];
        }
        private void LoadPersonFilter()
        {
            DataTable table = HR_EMP.Clone();

            DataRow[] rows = HR_EMP.Select("ISNULL(IS_ACTIVE,'N') = 'Y'", "FNAME");
            foreach (DataRow dr in rows)
                table.Rows.Add(dr.ItemArray);

            HR_EMP = new DataTable();
            HR_EMP = table.Copy();
        }
        private void LoadPersonControl()
        {
            EMP_ID.Clear();
            txtPerson.Properties.Items.Clear();

            foreach (DataRow dr in HR_EMP.Rows)
            {
                EMP_ID.Add(Convert.ToInt32(dr["EMP_ID"]));
                txtPerson.Properties.Items.Add(dr["FullName"].ToString());
            }
        }
        private void ReloadPerson()
        {
            LoadPersonData();
            LoadPersonFilter();
            LoadPersonControl();
        }

        private void LoadScheduleTypeData()
        {
            ProcessGetRISModalitymaintenancetype getData = new ProcessGetRISModalitymaintenancetype();
            getData.Invoke();
            RIS_MODALITYMAINTENANCETYPE = getData.Result.Tables[0];
        }
        private void LoadScheduleTypeFilter()
        {

        }
        private void LoadScheduleTypeControl()
        {
            MTN_TYPE_ID.Clear();
            txtScheduleType.Properties.Items.Clear();

            foreach (DataRow dr in RIS_MODALITYMAINTENANCETYPE.Rows)
            {
                MTN_TYPE_ID.Add(Convert.ToInt32(dr["MTN_TYPE_ID"]));
                txtScheduleType.Properties.Items.Add(dr["MTN_TYPE_UID"].ToString());
            }
        }
        private void ReLoadScheduleType()
        {
            LoadScheduleTypeData();
            LoadScheduleTypeFilter();
            LoadScheduleTypeControl();
        }

        private void LoadModalityData()
        {
            ProcessGetRISModality getData = new ProcessGetRISModality(true);
            getData.Invoke();
            RIS_MODALITY = getData.Result.Tables[0];
        }
        private void LoadModalityFilter()
        {
        }
        private void LoadModalityControl()
        {
            MODALITY_ID.Clear();
            txtModality.Properties.Items.Clear();

            foreach (DataRow dr in RIS_MODALITY.Rows)
            {
                MODALITY_ID.Add(Convert.ToInt32(dr["MODALITY_ID"]));
                txtModality.Properties.Items.Add(dr["MODALITY_NAME"].ToString());
            }
        }
        private void ReloadModality()
        {
            LoadModalityData();
            LoadModalityFilter();
            LoadModalityControl();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            GBLEnvVariable env = new GBLEnvVariable();

            string editvalue = txtRecurrentRadio.EditValue.ToString();
            int year = txtRecurrentTimePeriod.EditValue.ToString().StartsWith("1") ? 365 : 365 * 2;
            can_inserted = false;

            if (editvalue == "Once")
                InsertData();
            else if (editvalue == "Week")
            {
                int k = 0;
                int week = year / 7;
                while (k < week)
                {
                    InsertData();
                    txtDateStart.DateTime = txtDateStart.DateTime.AddDays(7);
                    txtDateEnd.DateTime = txtDateEnd.DateTime.AddDays(7);
                    k++;
                }
            }
            else if (editvalue == "Month")
            {
                int k = 0;
                int month = year / 30;
                while (k < month)
                {
                    InsertData();
                    txtDateStart.DateTime = txtDateStart.DateTime.AddMonths(1);
                    txtDateEnd.DateTime = txtDateEnd.DateTime.AddMonths(1);
                    k++;
                }
            }
            else if (editvalue == "3Month")
            {
                int k = 0;
                int month3 = year / 90;
                while (k < month3)
                {
                    InsertData();
                    txtDateStart.DateTime = txtDateStart.DateTime.AddMonths(3);
                    txtDateEnd.DateTime = txtDateEnd.DateTime.AddMonths(3);
                    k++;
                }
            }
            else if (editvalue == "6Month")
            {
                int k = 0;
                int month6 = year / 180;
                while (k < month6)
                {
                    InsertData();
                    txtDateStart.DateTime = txtDateStart.DateTime.AddMonths(6);
                    txtDateEnd.DateTime = txtDateEnd.DateTime.AddMonths(6);
                    k++;
                }
            }
            else if (editvalue == "Year")
            {
                int k = 0;
                int years = year / 365;
                while (k < years)
                {
                    InsertData();
                    txtDateStart.DateTime = txtDateStart.DateTime.AddYears(1);
                    txtDateEnd.DateTime = txtDateEnd.DateTime.AddYears(1);
                    k++;
                }
            }
            
            //RecurrenceInfo reinfo = controller.EditedAppointmentCopy.RecurrenceInfo;
            //RecurrenceType type = reinfo.Type;
            //int occurence = reinfo.OccurrenceCount;
            //DateTime start = controller.Start;
            //DateTime end = controller.End;

            //start_list.Add(start);
            //end_list.Add(end);

            //if (type == RecurrenceType.Minutely)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddMinutes(1);
            //        start_list.Add(start);
            //        end = end.AddMinutes(1);
            //        end_list.Add(end);
            //    }
            //}
            //else if (type == RecurrenceType.Hourly)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddHours(1);
            //        start_list.Add(start);
            //        end = end.AddHours(1);
            //        end_list.Add(end);
            //    }
            //}
            //else if (type == RecurrenceType.Daily)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddDays(1);
            //        start_list.Add(start);
            //        end = end.AddDays(1);
            //        end_list.Add(end);
            //    }
            //}
            //else if (type == RecurrenceType.Weekly)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddDays(7);
            //        start_list.Add(start);
            //        end = end.AddDays(7);
            //        end_list.Add(end);
            //    }
            //}
            //else if (type == RecurrenceType.Monthly)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddMonths(1);
            //        start_list.Add(start);
            //        end = end.AddMonths(1);
            //        end_list.Add(end);
            //    }
            //}
            //else if (type == RecurrenceType.Yearly)
            //{
            //    for (int i = 1; i < occurence; i++)
            //    {
            //        start = start.AddYears(1);
            //        start_list.Add(start);
            //        end = end.AddYears(1);
            //        end_list.Add(end);
            //    }
            //}

            if (can_inserted)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                txtModality.Focus();
            }
        }

        private void InsertData()
        {
            if (!InsertDataSchedule_Invoke())
                return;
            if (!InsertDataModality_Invoke())
                return;

            can_inserted = true;
        }
        private bool InsertDataSchedule_Invoke()
        {
            GBLEnvVariable env = new GBLEnvVariable();
            ProcessAddRISSchedule process = new ProcessAddRISSchedule();

            try
            {
                int modality_id = MODALITY_ID[txtModality.SelectedIndex];
                int mtn_type_id = MTN_TYPE_ID[txtScheduleType.SelectedIndex];
                int emp_id = EMP_ID[txtPerson.SelectedIndex];

                DateTime date_start = txtDateStart.DateTime;
                DateTime time_start = txtTimeStart.Time;
                DateTime start_time = new DateTime(date_start.Year, date_start.Month, date_start.Day
                    , time_start.Hour, time_start.Minute, time_start.Second);

                DateTime date_end = txtDateEnd.DateTime;
                DateTime time_end = txtTimeEnd.Time;
                DateTime end_time = new DateTime(date_end.Year, date_end.Month, date_end.Day
                    , time_end.Hour, time_end.Minute, time_end.Second);
                //end_time = end_time.AddSeconds(-1);

                //ProcessAddRISSchedule process = new ProcessAddRISSchedule();
                //DateTime start = new DateTime(dtStart.DateTime.Year, dtStart.DateTime.Month, dtStart.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, 0);
                //DateTime end = new DateTime(dtEnd.DateTime.Year, dtEnd.DateTime.Month, dtEnd.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, 0);

                //process.RIS_SCHEDULE.APPOINT_DT = date_start;
                process.RIS_SCHEDULE.START_DATETIME = start_time;
                process.RIS_SCHEDULE.CREATED_BY = env.UserID;
                process.RIS_SCHEDULE.END_DATETIME = end_time;
                process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(apt.ResourceId.ToString());
                process.RIS_SCHEDULE.ORG_ID = env.OrgID;
                process.RIS_SCHEDULE.REASON = "ได้มีการนัดช่วงเวลานี้ไว้แล้ว  เพื่อทำการซ่อมบำรุงเครื่องเอ็กซเรย์";
                process.RIS_SCHEDULE.SCHEDULE_DATA = "BLOCK - " + "ซ่อมบำรุงเครื่องเอ็กซเรย์";
                process.RIS_SCHEDULE.SCHEDULE_ID = 0;
                process.RIS_SCHEDULE.SCHEDULE_STATUS = Convert.ToChar("S");
                process.InvokeBlock();

                sch_id = process.RIS_SCHEDULE.SCHEDULE_ID;

                if (sch_id == -1)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        private bool InsertDataModality_Invoke()
        {
            try
            {
                int modality_id = MODALITY_ID[txtModality.SelectedIndex];
                int mtn_type_id = MTN_TYPE_ID[txtScheduleType.SelectedIndex];
                int emp_id = EMP_ID[txtPerson.SelectedIndex];

                DateTime date_start = txtDateStart.DateTime;
                DateTime time_start = txtTimeStart.Time;
                DateTime start_time = new DateTime(date_start.Year, date_start.Month, date_start.Day
                    , time_start.Hour, time_start.Minute, time_start.Second);

                DateTime date_end = txtDateEnd.DateTime;
                DateTime time_end = txtTimeEnd.Time;
                DateTime end_time = new DateTime(date_end.Year, date_end.Month, date_end.Day
                    , time_end.Hour, time_end.Minute, time_end.Second);

                bool is_checked = chkDisallowExam.CheckState == CheckState.Checked ? true : false;

                decimal mtn_cost = txtCost.Value;

                ProcessAddRISModalitymaintenanceschedule AddData
                    = new ProcessAddRISModalitymaintenanceschedule();
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID = modality_id;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_ID = mtn_type_id;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON = emp_id;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = start_time;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = end_time;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS = txtComment.Text;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.DISALLOW_EXAM = is_checked;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_COST = mtn_cost;
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_STATUS = "N";
                AddData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_DT = MTN_DT;

                //if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
                //{
                //    RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                //    AddData.RIS_MODALITYMAINTENANCESCHEDULE.RECURRENCEINFO = helper.ToXml();
                //}
                //if (controller.EditedAppointmentCopy.Reminder != null)
                //{
                //    ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(controller.EditedAppointmentCopy.Reminder, DateSavingType.LocalTime);
                //    AddData.RIS_MODALITYMAINTENANCESCHEDULE.REMINDERINFO = helper.ToXml();
                //}

                AddData.RIS_MODALITYMAINTENANCESCHEDULE.SCHEDULE_ID = sch_id;
                AddData.Invoke();

                mod_id = AddData.RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID;

                if (mod_id == -1)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnRecurrence_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MyAppointmentFormController controller = new MyAppointmentFormController(control, apt);
            //Appointment editedAptCopy = controller.EditedAppointmentCopy;
            //Appointment editedPattern = controller.EditedPattern;
            //Appointment patternCopy = controller.PrepareToRecurrenceEdit();
            //frmMechanicScheduleNew_Recurrence dlg = 
            //    new frmMechanicScheduleNew_Recurrence(patternCopy, control.OptionsView.FirstDayOfWeek, controller);
            //dlg.LookAndFeel.ParentLookAndFeel = control.LookAndFeel;
            //dlg.ShowDialog();

            ShowRecurrenceForm();
        }

        private void ShowRecurrenceForm()
        {
            ////if (!control.SupportsRecurrence)
            ////    return;

            //// Prepare to edit the appointment's recurrence.
            //Appointment editedAptCopy = controller.EditedAppointmentCopy;
            //Appointment editedPattern = controller.EditedPattern;
            //Appointment patternCopy = controller.PrepareToRecurrenceEdit();
            //frmMechanicScheduleNew_Recurrence dlg = 
            //    new frmMechanicScheduleNew_Recurrence(patternCopy, control.OptionsView.FirstDayOfWeek, controller);
            //// Required for skin support.
            ////dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
            //DialogResult result = dlg.ShowDialog(this);
            //dlg.Dispose();
            //if (result == DialogResult.Abort)
            //    controller.RemoveRecurrence();
            //else
            //    if (result == DialogResult.OK)
            //    {
            //        controller.ApplyRecurrence(patternCopy);
            //        if (controller.EditedAppointmentCopy != editedAptCopy)
            //        {
            //            //UpdateForm();
            //        }
            //    }
            ////UpdateIntervalControls();
        }

    }
}
