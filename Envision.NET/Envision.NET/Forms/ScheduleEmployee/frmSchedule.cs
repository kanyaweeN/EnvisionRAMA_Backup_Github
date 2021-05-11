using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
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
using Envision.NET.Forms.Schedule.Common;
using Envision.NET.Forms.Dialog;

using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler.Xml;

namespace Envision.NET.Forms.ScheduleEmployee
{
    public partial class frmSchedule : Envision.NET.Forms.Main.MasterForm  
    {
        private GBLEnvVariable env;
        private DataTable dttResource;
        private DataTable dttAppointment;
        private MyMessageBox msg;
        private bool is_recurrence;
        private bool is_click;
        private bool is_deleteComplete;
        private bool is_staffSchedule;

        public static string Is_Appointment { get; set; }
        public static string Is_UpdateRecurrence { get; set; }

        public frmSchedule()
        {
            InitializeComponent();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            is_recurrence = false;
            is_click = false;
            is_deleteComplete = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
	    public frmSchedule(int EMP_ID)
        {
            InitializeComponent();
            msg = new MyMessageBox();
            env = new GBLEnvVariable();
            is_recurrence = false;
            is_click = false;
            is_deleteComplete = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            is_staffSchedule = true;
            scControl.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
        }
        private void frmSchedule_Load(object sender, EventArgs e)
        {
            initializeControl();
            this.CloseWaitDialog();
            dateNav.DateTime = DateTime.Now;
        }

        private void initializeControl() {
            chkList.Visible = env.SUPPORT_USER == "Y" ? true : false;
 	    if (is_staffSchedule) {
                ProcessGetEmployee employee = new ProcessGetEmployee();
                DataSet ds = new DataSet();
                employee.HR_EMP.EMP_ID = -1;
                ds = employee.GetSchedule();
                dttResource = ds.Tables[0].Copy();
                dttAppointment = ds.Tables[1].Clone();
                dttAppointment.AcceptChanges();
                chkList.Items.Clear();
                chkList.DisplayMember = "THAINAME";
                chkList.ValueMember = "EMP_ID";
                chkList.DataSource = dttResource;
                if (env.SUPPORT_USER != "Y") chkList.SetItemChecked(0, true);

 		dttResource = new DataTable();
                dttResource.Columns.Add("EMP_ID", typeof(int));
                dttResource.Columns.Add("THAINAME", typeof(string));
                dttResource.AcceptChanges();
            }
            else if (env.SUPPORT_USER == "Y")
            {
                #region Support User.
                ProcessGetEmployee employee = new ProcessGetEmployee();
                DataSet ds = new DataSet();
                employee.HR_EMP.EMP_ID = 0;
                ds = employee.GetSchedule();
                dttResource = ds.Tables[0].Copy();
                dttAppointment = ds.Tables[1].Clone();
                dttAppointment.AcceptChanges();
                chkList.Items.Clear();
                chkList.DisplayMember = "THAINAME";
                chkList.ValueMember = "EMP_ID";
                chkList.DataSource = dttResource;
                if (env.SUPPORT_USER != "Y") chkList.SetItemChecked(0, true);

                dttResource = new DataTable();
                dttResource.Columns.Add("EMP_ID", typeof(int));
                dttResource.Columns.Add("THAINAME", typeof(string));
                dttResource.AcceptChanges();
                #endregion
            }
            else
            {
                #region Normal User.
                ProcessGetEmployee employee = new ProcessGetEmployee();
                DataSet ds = new DataSet();
                employee.HR_EMP.EMP_ID = env.UserID;
                ds = employee.GetSchedule();
                dttResource = ds.Tables[1].Copy();
                dttAppointment = ds.Tables[0].Copy();
                scheduleMappingData(); 
                #endregion
            }
          
        }
        private void scheduleMappingData() {
            scControl.GroupType = SchedulerGroupType.Resource;
            scControl.Start = DateTime.Now;
            scControl.DayView.ShowAllDayArea = false;
            scControl.Storage.EnableReminders = false;
            scControl.DayView.ShowWorkTimeOnly = true;

            //Load Resource
            scStorage.Resources.Mappings.Id = "EMP_ID";
            scStorage.Resources.Mappings.Caption = "THAINAME";
            scStorage.Resources.DataSource = dttResource;
          
            //Load Appointment
            scStorage.Appointments.Mappings.ResourceId = "EMP_ID";
            scStorage.Appointments.Mappings.AllDay = "ALLDAY";
            scStorage.Appointments.Mappings.Description = "DESCRIPTION";
            scStorage.Appointments.Mappings.End = "ENDDATETIME";
            scStorage.Appointments.Mappings.Label = "LABEL";
            scStorage.Appointments.Mappings.Location = "LOCATION";
            scStorage.Appointments.Mappings.RecurrenceInfo = "RECURRENCEINFO";
            scStorage.Appointments.Mappings.ReminderInfo = "REMINDERINFO";
            scStorage.Appointments.Mappings.Start = "STARTDATETIME";
            scStorage.Appointments.Mappings.Status = "STATUS";
            scStorage.Appointments.Mappings.Subject = "SUBJECT";
            scStorage.Appointments.Mappings.Type = "EVENTTYPE";
            scStorage.Appointments.CustomFieldMappings[0].Name = "SCHEDULE_ID";
            scStorage.Appointments.CustomFieldMappings[0].Member = "SCHEDULE_ID";
            scStorage.Appointments.CustomFieldMappings[1].Name = "COMMAND";
            scStorage.Appointments.CustomFieldMappings[1].Member = "COMMAND";
            scStorage.Appointments.DataSource = dttAppointment;
        }
        private void multiUserSelect() {
            DataTable rs = dttResource.Clone();
            DataTable app = dttAppointment.Clone();

            dttResource = new DataTable();
            dttAppointment = new DataTable();
            dttResource = rs;
            dttAppointment = app;
            scheduleMappingData();

            if (chkList.CheckedItems.Count == 0) return;
            for (int i = 0; i < chkList.CheckedItems.Count; i++)
            {
                int id = Convert.ToInt32(chkList.CheckedItems[i].ToString());

                ProcessGetEmployee employee = new ProcessGetEmployee();
                DataSet ds = new DataSet();
                employee.HR_EMP.EMP_ID = id;
                ds = employee.GetSchedule();

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    DataRow row = dttResource.NewRow();
                    row[0] = dr[0];
                    row[1] = dr[1];
                    dttResource.Rows.Add(row);
                }
                dttResource.AcceptChanges();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow row = dttAppointment.NewRow();
                    for (int j = 0; j < dttAppointment.Columns.Count; j++)
                    {
                        row[j] = dr[j];
                    }
                    dttAppointment.Rows.Add(row);
                }
                dttAppointment.AcceptChanges();
            }
            dttAppointment.AcceptChanges();
            scheduleMappingData();
        }

        private void barCheckTime_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            scControl.DayView.ShowWorkTimeOnly = barCheckTime.Checked;
        }

        private void chkList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            multiUserSelect();
        }

        //storage all event.
        private void scStorage_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            if (is_click) return;
            if (Is_Appointment == "Y") return;
            Appointment appointMent = e.Object as Appointment;
            if (appointMent == null)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                if (msg.ShowAlert("UID1020", env.CurrentLanguageID) == "1")
                {
                    is_click = false;
                    e.Cancel = true;
                    return;
                }
                is_click = true;
                if (appointMent.IsRecurring == false)
                {
                    SchedulerStorage store = sender as DevExpress.XtraScheduler.SchedulerStorage;
                    #region Update Appointment.
                    ProcessUpdateEmpSchedule proc = new ProcessUpdateEmpSchedule();
                    proc.GBL_EMPSCHEDULE.ALLDAY = appointMent.AllDay;
                    proc.GBL_EMPSCHEDULE.DESCRIPTION = appointMent.Description;
                    proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(appointMent.ResourceId.ToString());
                    proc.GBL_EMPSCHEDULE.ENDDATETIME = appointMent.End;
                    proc.GBL_EMPSCHEDULE.LABEL = appointMent.LabelId;
                    proc.GBL_EMPSCHEDULE.LOCATION = appointMent.Location;
                    proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                    proc.GBL_EMPSCHEDULE.STARTDATETIME = appointMent.Start;
                    proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(appointMent.StatusId.ToString());
                    proc.GBL_EMPSCHEDULE.SUBJECT = appointMent.Subject;
                    proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(appointMent.Type);
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID = Convert.ToInt32(appointMent.CustomFields[0].ToString());
                    if (appointMent.RecurrenceInfo != null)
                    {
                        RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(appointMent.RecurrenceInfo, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.RECURRENCEINFO = helper.ToXml();
                    }
                    if (appointMent.Reminder != null)
                    {
                        ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(appointMent.Reminder, DateSavingType.LocalTime);
                        proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                    }
                    proc.Invoke();
                    #endregion
                    is_recurrence = false;
                }
                else
                {
                    is_recurrence = true;
                }
            }
        }
        private void scStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            if (is_recurrence)
            {
                System.Collections.IList list = e.Objects as System.Collections.IList;
                Appointment appointMent = (Appointment)list[0];
                for (int i = 0; i < dttAppointment.Rows.Count; i++)
                {
                    if (dttAppointment.Rows[i].RowState == DataRowState.Added)
                    {
                        ProcessAddGBLEmpSchedule proc = new ProcessAddGBLEmpSchedule();
                        proc.GBL_EMPSCHEDULE.ALLDAY = appointMent.AllDay;
                        proc.GBL_EMPSCHEDULE.DESCRIPTION = appointMent.Description;
                        proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(appointMent.ResourceId.ToString());
                        proc.GBL_EMPSCHEDULE.ENDDATETIME = appointMent.End;
                        proc.GBL_EMPSCHEDULE.LABEL = appointMent.LabelId;
                        proc.GBL_EMPSCHEDULE.LOCATION = appointMent.Location;
                        proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                        proc.GBL_EMPSCHEDULE.STARTDATETIME = appointMent.Start;
                        proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(appointMent.StatusId.ToString());
                        proc.GBL_EMPSCHEDULE.SUBJECT = appointMent.Subject;
                        proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(appointMent.Type);
                        //proc.GBL_EMPSCHEDULE.RECURRENCEINFO = dttAppointment.Rows[i]["RECURRENCEINFO"].ToString();

                        if (appointMent.RecurrenceInfo != null) {
                            string str = "<RecurrenceInfo Id=\"" + appointMent.RecurrenceInfo.Id.ToString() + "\" ";
                            if (appointMent.RecurrenceIndex > 0)
                                str += " Index=\"" + appointMent.RecurrenceIndex + "\"";
                            str += " />";
                            proc.GBL_EMPSCHEDULE.RECURRENCEINFO = str;
                        }


                        if (appointMent.Reminder != null)
                        {
                            ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(appointMent.Reminder, DateSavingType.LocalTime);
                            proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                        }
                        proc.GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT = Convert.ToInt32(appointMent.CustomFields[0].ToString());
                        proc.Invoke();
                    }
                    else if (dttAppointment.Rows[i].RowState == DataRowState.Modified)
                    {
                        ProcessUpdateEmpSchedule proc = new ProcessUpdateEmpSchedule();
                        proc.GBL_EMPSCHEDULE.ALLDAY = appointMent.AllDay;
                        proc.GBL_EMPSCHEDULE.DESCRIPTION = appointMent.Description;
                        proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(appointMent.ResourceId.ToString());
                        proc.GBL_EMPSCHEDULE.ENDDATETIME = appointMent.End;
                        proc.GBL_EMPSCHEDULE.LABEL = appointMent.LabelId;
                        proc.GBL_EMPSCHEDULE.LOCATION = appointMent.Location;
                        proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                        proc.GBL_EMPSCHEDULE.STARTDATETIME = appointMent.Start;
                        proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(appointMent.StatusId.ToString());
                        proc.GBL_EMPSCHEDULE.SUBJECT = appointMent.Subject;
                        proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(appointMent.Type);
                        proc.GBL_EMPSCHEDULE.SCHEDULE_ID = Convert.ToInt32(appointMent.CustomFields[0].ToString());
                        proc.GBL_EMPSCHEDULE.SCHEDULE_ID_PARENT = Convert.ToInt32(appointMent.CustomFields[0].ToString());
                       // proc.GBL_EMPSCHEDULE.RECURRENCEINFO = dttAppointment.Rows[i]["RECURRENCEINFO"].ToString();

                        if (appointMent.RecurrenceInfo != null)
                        {
                            string str = "<RecurrenceInfo Id=\"" + appointMent.RecurrenceInfo.Id.ToString() + "\" ";
                            if (appointMent.RecurrenceIndex > 0)
                                str += " Index=\"" + appointMent.RecurrenceIndex + "\"";
                            str += " />";
                            proc.GBL_EMPSCHEDULE.RECURRENCEINFO = str;
                        }

                        if (appointMent.Reminder != null)
                        {
                            ReminderXmlPersistenceHelper helper = new ReminderXmlPersistenceHelper(appointMent.Reminder, DateSavingType.LocalTime);
                            proc.GBL_EMPSCHEDULE.REMINDERINFO = helper.ToXml();
                        }
                        proc.Invoke();
                    }
                }
                is_recurrence = false;
            }
            dttAppointment.AcceptChanges();
            is_click = false;
        }
        private void scStorage_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            if (is_deleteComplete)
            {
                e.Cancel = false;
                return;
            }
            if (is_recurrence == false)
            {
                if (e.Object.CustomFields[1] != null)
                {
                    if (e.Object.CustomFields[1].ToString() == "F")
                    {
                        e.Cancel = false;
                        return;
                    }
                }
                if (msg.ShowAlert("UID1201", env.CurrentLanguageID) == "1")
                {
                    e.Cancel = true;
                    return;
                }
                int schduleID = Convert.ToInt32(e.Object.CustomFields[0].ToString());
                ProcessDeleteGBLEmpSchedule proc = new ProcessDeleteGBLEmpSchedule();
                proc.GBL_EMPSCHEDULE.SCHEDULE_ID = schduleID;
                proc.Invoke();


            }
            else
            {
                DevExpress.XtraScheduler.Appointment apt = (DevExpress.XtraScheduler.Appointment)e.Object;
                int eventType = Convert.ToInt32(apt.Type);
                if (eventType == 1)
                {
                    //delete all appointment.
                    int schduleID = Convert.ToInt32(e.Object.CustomFields[0].ToString());
                    ProcessDeleteGBLEmpSchedule proc = new ProcessDeleteGBLEmpSchedule();
                    proc.GBL_EMPSCHEDULE.SCHEDULE_ID = schduleID;
                    proc.Invoke();
                    is_recurrence = true;
                    is_deleteComplete = true;
                }
                else
                {
                    //delete select appointment.
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
                        //string r = "<RecurrenceInfo Id=\"" + apt.RecurrenceInfo.Id + "\" Index=\"" + apt.RecurrenceIndex + "\" />";
                        //proc.GBL_EMPSCHEDULE.RECURRENCEINFO = r;

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
                e.Cancel = false;
                return;
            }
        }
        private void scStorage_AppointmentsDeleted(object sender, PersistentObjectsEventArgs e)
        {
            is_recurrence = false;
            is_deleteComplete = false;
            dttAppointment.AcceptChanges();
        }
       
        
        //schedule control all event.
        private void scControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {

            #region Check Resouce is select or not.
            int isInt;
            int.TryParse(e.Appointment.ResourceId.ToString(), out isInt);
            if (isInt == 0)
            {
                e.Handled = true;
                return;
            }
            #endregion
            Appointment apt = e.Appointment;

            bool openRecurrenceForm=false;
            MyAppointmentEditForm myForm = null;
            object obj = apt.CustomFields[0];
            if (obj == null)
            {
                openRecurrenceForm = false;
                e.Handled = true;
            }
            else
            {
                openRecurrenceForm = apt.IsRecurring;
                if (apt.IsRecurring)
                {
                    //ask edit series or occurence.
                    OccurenceDialog ocurDlg = new OccurenceDialog();
                    if (ocurDlg.ShowDialog() != DialogResult.OK)
                    {
                        e.Handled = true;
                        return;

                    }
                    openRecurrenceForm = ocurDlg.SelectType == 0 ? false : true;
                    if (openRecurrenceForm)
                    {

                        e.Handled = true;
                        MyAppointmentFormController controller = new MyAppointmentFormController(scControl, apt);
                        Appointment editedAptCopy = controller.EditedAppointmentCopy;
                        Appointment editedPattern = controller.EditedPattern;
                        Appointment patternCopy = controller.PrepareToRecurrenceEdit();
                        //AppointmentRecurrenceForm dlg = new AppointmentRecurrenceForm(patternCopy, scControl.OptionsView.FirstDayOfWeek, controller);
                        MyAppointmentRecurrence dlg = new MyAppointmentRecurrence(patternCopy, scControl.OptionsView.FirstDayOfWeek, controller);
                        dlg.LookAndFeel.ParentLookAndFeel = scControl.LookAndFeel;
                        DialogResult result = dlg.ShowDialog(this);
                        dlg.Dispose();
                        if (result == DialogResult.OK)
                        {
                           

                            RecurrenceInfoXmlPersistenceHelper helper = new RecurrenceInfoXmlPersistenceHelper(patternCopy.RecurrenceInfo, DateSavingType.LocalTime);
                            string recu = helper.ToXml();
                            string find = "Id=\"" + patternCopy.RecurrenceInfo.Id.ToString() + "\"";
                            string rep = "Id=\"" + apt.RecurrenceInfo.Id.ToString() + "\"";
                            recu = recu.Replace(find, rep);

                            ProcessUpdateEmpSchedule proc = new ProcessUpdateEmpSchedule();
                            proc.GBL_EMPSCHEDULE.ALLDAY = patternCopy.AllDay;
                            proc.GBL_EMPSCHEDULE.DESCRIPTION = patternCopy.Description;
                            proc.GBL_EMPSCHEDULE.EMP_ID = Convert.ToInt32(patternCopy.ResourceId.ToString());
                            proc.GBL_EMPSCHEDULE.ENDDATETIME = patternCopy.End;
                            proc.GBL_EMPSCHEDULE.LABEL = patternCopy.LabelId;
                            proc.GBL_EMPSCHEDULE.LOCATION = patternCopy.Location;
                            proc.GBL_EMPSCHEDULE.ORG_ID = env.OrgID;
                            proc.GBL_EMPSCHEDULE.STARTDATETIME = patternCopy.Start;
                            proc.GBL_EMPSCHEDULE.STATUS = Convert.ToInt32(patternCopy.StatusId.ToString());
                            proc.GBL_EMPSCHEDULE.SUBJECT = patternCopy.Subject;
                            proc.GBL_EMPSCHEDULE.EVENTTYPE = Convert.ToInt32(patternCopy.Type);
                            proc.GBL_EMPSCHEDULE.SCHEDULE_ID = Convert.ToInt32(patternCopy.CustomFields[0].ToString());
                            proc.GBL_EMPSCHEDULE.RECURRENCEINFO = recu;
                            proc.Invoke();
                            scControl.Refresh();
                            if (env.SUPPORT_USER == "Y")
                                multiUserSelect();
                        }
                        return;
                    }
                }
            }


            myForm = new MyAppointmentEditForm((SchedulerControl)sender, apt, openRecurrenceForm);
            try
            {
                myForm.LookAndFeel.ParentLookAndFeel = scControl.LookAndFeel;
                e.DialogResult = myForm.ShowDialog();
                scControl.Refresh();
                e.Handled = true;
                if (env.SUPPORT_USER == "Y")
                    multiUserSelect();
                else {
                    if (Is_UpdateRecurrence == "Y")
                        initializeControl();
                }
            }
            finally
            {
                myForm.Dispose();
                dttAppointment.AcceptChanges();
                Is_UpdateRecurrence = "N";
            }
        }
        private void scControl_AppointmentDrag(object sender, AppointmentDragEventArgs e)
        {
            if (e.SourceAppointment.ResourceId.ToString().Trim() != e.EditedAppointment.ResourceId.ToString().Trim())
            {
                e.Allow = false;
                e.Handled = true;
            }

        }
        private void scControl_DeleteRecurrentAppointmentFormShowing(object sender, DeleteRecurrentAppointmentFormEventArgs e)
        {
            is_recurrence = true;
        }
        private void scControl_EditRecurrentAppointmentFormShowing(object sender, EditRecurrentAppointmentFormEventArgs e)
        {

        }
        private void scControl_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.EditSeries);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
            }
        }

     

      

        
    }
}
