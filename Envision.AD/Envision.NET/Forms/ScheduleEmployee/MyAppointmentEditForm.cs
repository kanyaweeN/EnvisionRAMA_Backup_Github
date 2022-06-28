using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.Common.Linq;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessUpdate;

using Envision.NET.Forms.Dialog;
using Envision.NET.Forms.Schedule.Common;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler.Xml;


namespace Envision.NET.Forms.ScheduleEmployee
{
    public partial class MyAppointmentEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private SchedulerControl control;
        private Appointment apt;
        private bool openRecurrenceForm = false;
        private int suspendUpdateCount;
        private MyAppointmentFormController controller;
        private GBLEnvVariable env;
        private MyMessageBox msg;
        private string mode;
        private List<GBL_EMPSCHEDULECATEGORY> listCategory;

        protected AppointmentStorage Appointments
        {
            get { return control.Storage.Appointments; }
        }
        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }

        public MyAppointmentEditForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            InitializeComponent();
            UpdateForm();
            if (apt.CustomFields[0] == null)
            {
                this.Text = "New Appointment";
                mode = "New";
                barDelete.Enabled = false;
            }
            else
            {
                this.Text = "Edit Appointment";
                mode = "Edit";
                this.controller.SCHEDULE_ID = Convert.ToInt32(apt.CustomFields[0].ToString());
                barDelete.Enabled = true;
            }
            loadCategory();
            if (apt.IsRecurring) 
                rgbRecurence.Visible = false;
        }

        private void loadCategory() { 
            EnvisionDataContext db=new EnvisionDataContext();
            IQueryable<GBL_EMPSCHEDULECATEGORY> cateQuery = from cate in db.GBL_EMPSCHEDULECATEGORies select cate;
            listCategory = new List<GBL_EMPSCHEDULECATEGORY>();
            listCategory = (from cate in cateQuery select cate).ToList();
            edtCategory.Properties.LargeImages = edLabel.Properties.LargeImages;
            edtCategory.Properties.SmallImages = edLabel.Properties.SmallImages;
            if (listCategory.Count > 0) {
            
                foreach (GBL_EMPSCHEDULECATEGORY c in listCategory)
                {
                    int index = c.IMAGE_INDEX.GetValueOrDefault();
                    DevExpress.XtraEditors.Controls.ImageComboBoxItem item = new DevExpress.XtraEditors.Controls.ImageComboBoxItem();
                    item.Description = c.CATEGORY_DESC;
                    item.ImageIndex = edLabel.Properties.Items[index].ImageIndex;
                    item.Value = c.CATEGORY_ID;
                    edtCategory.Properties.Items.Add(item);
                }
                edtCategory.SelectedIndex = 0;
                if (mode=="Edit")
                {
                    
                    for (int i = 0; i < edtCategory.Properties.Items.Count; i++)
                        if (apt.LabelId.ToString() == edtCategory.Properties.Items[i].Value.ToString())
                        {
                            edtCategory.SelectedIndex = i;
                            break;
                        }
                }
            }
        }
        private void doTimerValidated()
        {
            if ((timeStart.Time > timeEnd.Time) || (timeEnd.Time < timeStart.Time))
            {
                dxErrorProvider1.SetError(timeStart, "more than end time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(timeEnd, "less than start time", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
            }
            else
                dxErrorProvider1.ClearErrors();
        }


        #region Recurrence Section 
        private void MyAppointmentEditForm_Activated(object sender, EventArgs e)
        {
            if (openRecurrenceForm)
            {
                openRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }
        private void barRecurrence_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OnRecurrenceButton();
        }
        private void OnRecurrenceButton()
        {
            ShowRecurrenceForm();
        }
        private void ShowRecurrenceForm()
        {
            if (!control.SupportsRecurrence)
                return;

            // Prepare to edit the appointment's recurrence.
            Appointment editedAptCopy = controller.EditedAppointmentCopy;
            Appointment editedPattern = controller.EditedPattern;
            Appointment patternCopy = controller.PrepareToRecurrenceEdit();
            AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, control.OptionsView.FirstDayOfWeek, controller);
            // Required for skin support.
            dlg.LookAndFeel.ParentLookAndFeel = this.LookAndFeel.ParentLookAndFeel;
            DialogResult result = dlg.ShowDialog(this);
            dlg.Dispose();
            if (result == DialogResult.Abort)
                controller.RemoveRecurrence();
            else
                if (result == DialogResult.OK)
                {
                    controller.ApplyRecurrence(patternCopy);
                    if (controller.EditedAppointmentCopy != editedAptCopy)
                        UpdateForm();
                }
            UpdateIntervalControls();
        }
        #endregion

        #region Control Event Leave 
        private void dtStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false)
            {
                if (!IsUpdateSuspended)
                    controller.DisplayStart = dtStart.DateTime.Date + timeStart.Time.TimeOfDay;
                UpdateIntervalControls();
            }
        }
        private void dtEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
            if (dxErrorProvider1.HasErrors == false)
            {
                if (IsUpdateSuspended) return;
                if (IsIntervalValid())
                    controller.DisplayEnd = dtEnd.DateTime.Date + timeEnd.Time.TimeOfDay;
                else
                    dtEnd.EditValue = controller.DisplayEnd.Date;
            }
        }
        private void timeStart_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
        }
        private void timeEnd_EditValueChanged(object sender, System.EventArgs e)
        {
            doTimerValidated();
        }
        private bool IsIntervalValid()
        {
            DateTime start = dtStart.DateTime + timeStart.Time.TimeOfDay;
            DateTime end = dtEnd.DateTime + timeEnd.Time.TimeOfDay;
            return end >= start;
        }

        private void checkAllDay_CheckedChanged(object sender, System.EventArgs e)
        {
            controller.AllDay = this.checkAllDay.Checked;
            if (!IsUpdateSuspended)
                UpdateAppointmentStatus();

            UpdateIntervalControls();
        }
        #endregion

        #region Updating Form 
        protected void SuspendUpdate()
        {
            suspendUpdateCount++;
        }
        protected void ResumeUpdate()
        {
            if (suspendUpdateCount > 0)
                suspendUpdateCount--;
        }

        private void UpdateForm()
        {
            SuspendUpdate();
            try
            {
                txSubject.Text = controller.Subject;
                edStatus.Status = Appointments.Statuses[controller.StatusId];
                edLabel.Label = Appointments.Labels[controller.LabelId];

                dtStart.DateTime = controller.DisplayStart.Date;
                dtEnd.DateTime = controller.DisplayEnd.Date;

                timeStart.Time = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.Time = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);
                checkAllDay.Checked = controller.AllDay;

                txDesc.Text = controller.Description;
                txLocation.Text = controller.Location;

                edStatus.Storage = control.Storage;
                edLabel.Storage = control.Storage;
            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }
        protected virtual void UpdateIntervalControls()
        {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            try
            {
                dtStart.EditValue = controller.DisplayStart.Date;
                dtEnd.EditValue = controller.DisplayEnd.Date;
                timeStart.EditValue = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timeEnd.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);


                timeStart.Visible = !controller.AllDay;
                timeEnd.Visible = !controller.AllDay;
                timeStart.Enabled = !controller.AllDay;
                timeEnd.Enabled = !controller.AllDay;

            }
            finally
            {
                ResumeUpdate();
            }
        }
        private void UpdateAppointmentStatus()
        {
            AppointmentStatus currentStatus = edStatus.Status;
            AppointmentStatus newStatus = controller.UpdateAppointmentStatus(currentStatus);
            if (newStatus != currentStatus)
                edStatus.Status = newStatus;
        }

        #endregion

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSchedule.Is_Appointment = "N";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void barDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rgbRecurence.Visible)
            {
                if (msg.ShowAlert("UID1201", env.CurrentLanguageID) == "1") return;

                controller.COMMAND = "F";
                frmSchedule.Is_Appointment = "Y";
                controller.ApplyChanges();

                #region Delete in Database.
                ProcessDeleteGBLEmpSchedule proc = new ProcessDeleteGBLEmpSchedule();
                proc.GBL_EMPSCHEDULE.SCHEDULE_ID = this.controller.SCHEDULE_ID;
                proc.Invoke();
                #endregion
            }
            else {

                frmSchedule.Is_Appointment = "Y";

                controller.COMMAND = "F";
                controller.ApplyChanges();
                controller.DeleteAppointment();

                #region Delete in Control.
                ProcessAddGBLEmpSchedule proc = new ProcessAddGBLEmpSchedule();
                proc.GBL_EMPSCHEDULE.ALLDAY = apt.AllDay;
                proc.GBL_EMPSCHEDULE.DESCRIPTION = apt.Description;
                proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(apt.ResourceId.ToString());
                proc.GBL_EMPSCHEDULE.ENDDATETIME = apt.End;
                proc.GBL_EMPSCHEDULE.LABEL = apt.LabelId;
                proc.GBL_EMPSCHEDULE.LOCATION = apt.Location;
                proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                proc.GBL_EMPSCHEDULE.STARTDATETIME = apt.Start;
                proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(apt.StatusId.ToString());
                proc.GBL_EMPSCHEDULE.SUBJECT = apt.Subject;
                proc.GBL_EMPSCHEDULE.EVENTTYPE = 4;// Convert.ToInt32(apt.Type);
                if (apt.RecurrenceInfo != null)
                {
                    string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                    if (apt.RecurrenceIndex > 0)
                        str += " Index=\"" + apt.RecurrenceIndex + "\"";
                    str += " />";
                    proc.GBL_EMPSCHEDULE.RECURRENCEINFO = str;
                }


                if (apt.Reminder != null)
                {
                    ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(apt.Reminder, DateSavingType.LocalTime);
                    proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                }
                proc.GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT = Convert.ToInt32(apt.CustomFields[0].ToString());
                proc.Invoke();
                #endregion
            }
            frmSchedule.Is_Appointment = "N";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (msg.ShowAlert("UID1200", env.CurrentLanguageID) == "1")return;

            #region Save To Schedule Control.
            if (!controller.IsConflictResolved())
                return;

            controller.Subject = txSubject.Text;
            controller.SetStatus(edStatus.Status);
            controller.SetLabel(edLabel.Label);
            controller.AllDay = this.checkAllDay.Checked;

            //controller.DisplayStart = this.dtStart.DateTime.Date + this.timeStart.Time.TimeOfDay;
            //controller.DisplayEnd = this.dtEnd.DateTime.Date + this.timeEnd.Time.TimeOfDay;

            DateTime dtS = new DateTime(this.dtStart.DateTime.Year, this.dtStart.DateTime.Month, this.dtStart.DateTime.Day, this.timeStart.Time.Hour, this.timeStart.Time.Minute, this.timeStart.Time.Second);
            DateTime dtE = new DateTime(this.dtEnd.DateTime.Year, this.dtEnd.DateTime.Month, this.dtEnd.DateTime.Day, this.timeEnd.Time.Hour, this.timeEnd.Time.Minute, this.timeEnd.Time.Second);

            controller.DisplayStart = dtS;
            controller.DisplayEnd = dtE;



            controller.EditedAppointmentCopy.AllDay = checkAllDay.Checked;
            controller.EditedAppointmentCopy.Description = txDesc.Text;
            controller.EditedAppointmentCopy.Location = txLocation.Text;
            controller.EditedAppointmentCopy.Subject = txSubject.Text;
            #endregion
            foreach (var c in listCategory)
                        if (c.CATEGORY_DESC.Trim().ToLower() == edtCategory.SelectedItem.ToString().Trim().ToLower())
                        {
                            this.controller.LabelId = c.CATEGORY_ID;
                            this.controller.EditedAppointmentCopy.LabelId = c.CATEGORY_ID;
                            break;
                        }
            if (rgbRecurence.Visible)
            {
                if (mode == "New")
                {
                    #region New Appointment
                    
                    ProcessAddGBLEmpSchedule proc = new ProcessAddGBLEmpSchedule();
                    proc.GBL_EMPSCHEDULE.ALLDAY = this.checkAllDay.Checked;
                    proc.GBL_EMPSCHEDULE.DESCRIPTION = txDesc.Text;
                    proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(controller.EditedAppointmentCopy.ResourceId.ToString());
                    proc.GBL_EMPSCHEDULE.ENDDATETIME = this.controller.End;
                    proc.GBL_EMPSCHEDULE.LABEL = this.controller.LabelId;
                    proc.GBL_EMPSCHEDULE.LOCATION = txLocation.Text;
                    proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                    proc.GBL_EMPSCHEDULE.STARTDATETIME = this.controller.Start;
                    proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(controller.EditedAppointmentCopy.StatusId.ToString());
                    proc.GBL_EMPSCHEDULE.SUBJECT = txSubject.Text;
                    proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(controller.EditedAppointmentCopy.Type);
                    if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
                    {
                        RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.RECURRENCEINFO = helper.ToXml();
                    }
                    if (controller.EditedAppointmentCopy.Reminder != null)
                    {
                        ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(controller.EditedAppointmentCopy.Reminder, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                    }
                    proc.Invoke();
                    frmSchedule.Is_UpdateRecurrence = "Y";
                    controller.EditedAppointmentCopy.CustomFields[0] = proc.GBL_EMPSCHEDULE.SCHEDULE_ID;
                    #endregion
                }
                else
                {
                    #region Edit Appointment
                    ProcessUpdateEmpSchedule proc = new ProcessUpdateEmpSchedule();
                    proc.GBL_EMPSCHEDULE.ALLDAY = this.checkAllDay.Checked;
                    proc.GBL_EMPSCHEDULE.DESCRIPTION = txDesc.Text;
                    proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(controller.EditedAppointmentCopy.ResourceId.ToString());
                    proc.GBL_EMPSCHEDULE.ENDDATETIME = this.controller.End;
                    proc.GBL_EMPSCHEDULE.LABEL = this.controller.LabelId;
                    proc.GBL_EMPSCHEDULE.LOCATION = txLocation.Text;
                    proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                    proc.GBL_EMPSCHEDULE.STARTDATETIME = this.controller.Start;
                    proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(controller.EditedAppointmentCopy.StatusId.ToString());
                    proc.GBL_EMPSCHEDULE.SUBJECT = txSubject.Text;
                    proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(controller.EditedAppointmentCopy.Type);
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID = this.controller.SCHEDULE_ID;
                    if (controller.EditedAppointmentCopy.RecurrenceInfo != null)
                    {
                        RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(controller.EditedAppointmentCopy.RecurrenceInfo, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.RECURRENCEINFO = helper.ToXml();
                        frmSchedule.Is_UpdateRecurrence = "Y";
                    }
                    if (controller.EditedAppointmentCopy.Reminder != null)
                    {
                        ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(controller.EditedAppointmentCopy.Reminder, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                    }
                    proc.Invoke();
                    #endregion
                }
            }
            else
            {
                #region Edit recurence
                frmSchedule.Is_Appointment = "Y";
                if (this.controller.SCHEDULE_ID_PARENT == 0)
                {
                    //add
                    ProcessAddGBLEmpSchedule proc = new ProcessAddGBLEmpSchedule();
                    proc.GBL_EMPSCHEDULE.ALLDAY = apt.AllDay;
                    proc.GBL_EMPSCHEDULE.DESCRIPTION = apt.Description;
                    proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(apt.ResourceId.ToString());
                    proc.GBL_EMPSCHEDULE.ENDDATETIME = controller.DisplayEnd;// apt.End;
                    proc.GBL_EMPSCHEDULE.LABEL = apt.LabelId;
                    proc.GBL_EMPSCHEDULE.LOCATION = apt.Location;
                    proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                    proc.GBL_EMPSCHEDULE.STARTDATETIME = controller.DisplayStart;  //apt.Start;
                    proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(apt.StatusId.ToString());
                    proc.GBL_EMPSCHEDULE.SUBJECT = apt.Subject;
                    proc.GBL_EMPSCHEDULE.EVENTTYPE = 3;// Convert.ToInt32(apt.Type);
                    if (apt.RecurrenceInfo != null)
                    {
                        string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                        if (apt.RecurrenceIndex > 0)
                            str += " Index=\"" + apt.RecurrenceIndex + "\"";
                        str += " />";
                        proc.GBL_EMPSCHEDULE.RECURRENCEINFO = str;

                    }
                    if (apt.Reminder != null)
                    {
                        ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(apt.Reminder, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                    }
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT = Convert.ToInt32(apt.CustomFields[0].ToString());
                    proc.Invoke();
                }
                else
                {
                    //update
                    ProcessUpdateEmpSchedule proc = new ProcessUpdateEmpSchedule();
                    proc.GBL_EMPSCHEDULE.ALLDAY = controller.AllDay;// apt.AllDay;
                    proc.GBL_EMPSCHEDULE.DESCRIPTION = controller.Description;
                    proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(apt.ResourceId.ToString());
                    proc.GBL_EMPSCHEDULE.ENDDATETIME = controller.DisplayEnd;
                    proc.GBL_EMPSCHEDULE.LABEL = controller.LabelId;
                    proc.GBL_EMPSCHEDULE.LOCATION = controller.Location;
                    proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                    proc.GBL_EMPSCHEDULE.STARTDATETIME = controller.DisplayStart;
                    proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(controller.StatusId.ToString());
                    proc.GBL_EMPSCHEDULE.SUBJECT = controller.Subject;
                    proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(apt.Type);
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID = Convert.ToInt32(apt.CustomFields[0].ToString());
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT = Convert.ToInt32(apt.CustomFields[0].ToString());
                    if (apt.RecurrenceInfo != null)
                    {
                        string str = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\" ";
                        if (apt.RecurrenceIndex > 0)
                            str += " Index=\"" + apt.RecurrenceIndex + "\"";
                        str += " />";
                        proc.GBL_EMPSCHEDULE.RECURRENCEINFO = str;
                    }
                    if (apt.Reminder != null)
                    {
                        ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(apt.Reminder, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                    }
                    proc.Invoke();
                } 
                #endregion
            }
            frmSchedule.Is_Appointment = "Y";
            controller.ApplyChanges();
            frmSchedule.Is_Appointment = "N";
            DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
