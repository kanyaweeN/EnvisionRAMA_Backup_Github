using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraEditors.Repository;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessDelete;
using Envision.NET.Forms.Schedule;

namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMechanicSchedule : MasterForm
    {
        //private UUL.ControlFrame.Controls.TabControl ctrlPage;
        
        private DataTable dttResource;
        private DataTable dttAppointment;
        private DataTable dttSession;
        private DataTable dttHNSearch;
        private int curr;
        private MyMessageBox msg = new MyMessageBox();
        private GBLEnvVariable env = new GBLEnvVariable();
        private bool drag_drop;

        private bool ready;
        private string modalitySelect;
        private DateTime currDT;

        public frmMechanicSchedule()//(UUL.ControlFrame.Controls.TabControl controlPage)
        {
            InitializeComponent();
            initialScheduler();
            initialModalityData();
            initialScheduleData();
            //ctrlPage = controlPage;
            drag_drop = false;
            ready = false;
            dateNav.DateTime = DateTime.Today;
            currDT = DateTime.Today;
            modalitySelect = string.Empty;


            //
            initNavigator();
            initDataGridSession();
            //xtraGridBlending1.GridControl.BackgroundImage = global::RIS.Properties.Resources.gridBG;

            initialResourceControl();
            initialAppointmentControl();
            ready = true;
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            base.CloseWaitDialog();
            //scControl.DayView.ShowWorkTimeOnly = true;
        }

        private void initialScheduler()
        {
            scControl.LookAndFeel.SetSkinStyle("Office 2007 Blue");
            dateNav.LookAndFeel.SetSkinStyle("Office 2007 Blue");
            this.defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");

            scControl.GroupType = SchedulerGroupType.Resource;
            scControl.Start = DateTime.Now;
            scControl.DayView.ShowAllDayArea = false;
            scControl.Storage.EnableReminders = false;
            scControl.DayView.ShowWorkTimeOnly = true;
            btnCheckTime.Checked = true;
        }

        private void initialModalityData()
        {
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dttResource = process.GetModality();
        }
        private void initialScheduleData()
        {
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //dttAppointment=process.GetScheduleData();

            try
            {

                string editvalue = txtShowPeriod.EditValue.ToString();
                int period = 3;
                if (editvalue == "3Month")
                    period = 3;
                else if (editvalue == "6Month")
                    period = 6;
                else if (editvalue == "Year")
                    period = 12;

                string mode = "SelectOnlyMTNSchedule";
                if (btnShowVisible.Checked == true)
                    mode = "SelectAllSchedule";
                else
                    mode = "SelectOnlyMTNSchedule";

                ProcessGetRISModalitymaintenanceschedule getData = new ProcessGetRISModalitymaintenanceschedule(2);
                DateTime now = DateTime.Now;
                DateTime start = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                DateTime end = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59).AddMonths(period);

                getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = start;
                getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = end;
                getData.RIS_MODALITYMAINTENANCESCHEDULE.MODE = mode;
                getData.Invoke();

                dttAppointment = getData.Result.Tables[0];
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                new MyMessageBox().ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
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
        private void initialAppointmentControl()
        {
            //schedulerStorage1.Appointments.Mappings.ResourceId = "MODALITY_ID";
            //schedulerStorage1.Appointments.Mappings.Start = "START_DATETIME";
            //schedulerStorage1.Appointments.Mappings.End = "END_DATETIME";
            //schedulerStorage1.Appointments.Mappings.Location = "SCHEDULE_ID";
            //schedulerStorage1.Appointments.Mappings.Subject = "SCHEDULE_DATA";
            schedulerStorage1.Appointments.Mappings.ResourceId = "MODALITY_ID";
            schedulerStorage1.Appointments.Mappings.Start = "START_TIME";
            schedulerStorage1.Appointments.Mappings.End = "END_TIME";
            schedulerStorage1.Appointments.Mappings.Location = "MTN_SCH_ID";
            schedulerStorage1.Appointments.Mappings.Subject = "MTN_SCH_STATUS_TEXT";


            schedulerStorage1.Appointments.CustomFieldMappings[0].Name = "CommandType";
            schedulerStorage1.Appointments.CustomFieldMappings[0].Member = "CommandType";

            //schedulerStorage1.Appointments.CustomFieldMappings[1].Name = "SCHEDULE_ID";
            //schedulerStorage1.Appointments.CustomFieldMappings[1].Member = "SCHEDULE_ID";
            schedulerStorage1.Appointments.CustomFieldMappings[1].Name = "MTN_SCH_ID";
            schedulerStorage1.Appointments.CustomFieldMappings[1].Member = "MTN_SCH_ID";

            //schedulerStorage1.Appointments.CustomFieldMappings[2].Name = "SCHEDULE_STATUS";
            //schedulerStorage1.Appointments.CustomFieldMappings[2].Member = "SCHEDULE_STATUS";
            schedulerStorage1.Appointments.CustomFieldMappings[2].Name = "MTN_SCH_STATUS";
            schedulerStorage1.Appointments.CustomFieldMappings[2].Member = "MTN_SCH_STATUS";

            schedulerStorage1.Appointments.CustomFieldMappings[3].Name = "MODALITY_ID";
            schedulerStorage1.Appointments.CustomFieldMappings[3].Member = "MODALITY_ID";

            //schedulerStorage1.Appointments.CustomFieldMappings[4].Name = "START_DATETIME";
            //schedulerStorage1.Appointments.CustomFieldMappings[4].Member = "START_DATETIME";
            schedulerStorage1.Appointments.CustomFieldMappings[4].Name = "START_TIME";
            schedulerStorage1.Appointments.CustomFieldMappings[4].Member = "START_TIME";

            //schedulerStorage1.Appointments.CustomFieldMappings[5].Name = "END_DATETIME";
            //schedulerStorage1.Appointments.CustomFieldMappings[5].Member = "END_DATETIME";
            schedulerStorage1.Appointments.CustomFieldMappings[5].Name = "END_TIME";
            schedulerStorage1.Appointments.CustomFieldMappings[5].Member = "END_TIME";

            schedulerStorage1.Appointments.DataSource = dttAppointment;
        }

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

        private void scControl_SelectionChanged(object sender, EventArgs e)
        {
            checkModalityCase();
        }
        private void scControl_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
        }

        private void mnuPrintMulti_Click(object sender, EventArgs e)
        {
            //if (scControl.SelectedAppointments != null)
            //    if (scControl.SelectedAppointments.Count > 0)
            //    {
            //        string HN = scControl.SelectedAppointments[0].Subject;
            //        if (HN.Trim().ToLower() == "block") return;
            //        HN = HN.Substring(0, HN.IndexOf(','));
            //        DateTime start = scControl.SelectedAppointments[0].Start;
            //        int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
            //        int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());

            //        ///frmMultiplePrint frm = new frmMultiplePrint(Schedule, HN, "");
            //        ///frm.StartPosition = FormStartPosition.CenterScreen;
            //        ///frm.ShowDialog();
            //    }
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            //if(scControl.SelectedAppointments!=null)
            //    if (scControl.SelectedAppointments.Count > 0)
            //    {
            //        string HN = scControl.SelectedAppointments[0].Subject;
            //        if (HN.Trim().ToLower() == "block") return;
            //        HN = HN.Substring(0, HN.IndexOf(','));
            //        DateTime start = scControl.SelectedAppointments[0].Start;
            //        int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
            //        int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
            //        RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
            //        print.ScheduleDirectPrint(HN, start, Modality, Schedule);
            //    }
        }
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            //if (scControl.SelectedAppointments != null)
            //    if (scControl.SelectedAppointments.Count > 0)
            //    {
            //        string HN = scControl.SelectedAppointments[0].Subject;
            //        if (HN.Trim().ToLower() == "block") return;
            //        HN = HN.Substring(0, HN.IndexOf(','));
            //        DateTime start = scControl.SelectedAppointments[0].Start;
            //        int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
            //        int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
            //        ReportMangager rptManager = new ReportMangager();
            //        RIS.Reports.ReportViewer.frmReportViewer rptViewer = new RIS.Reports.ReportViewer.frmReportViewer(rptManager.rptScheduleReport(HN, start, Modality,Schedule), ctrlPage);
            //        rptViewer.StartPosition = FormStartPosition.CenterScreen;
            //        rptViewer.ShowDialog();
            //    }
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
            schedulerStorage1.RefreshData();
            scControl.Refresh();

            //modality show case.

        }

        private void scControl_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e)
        {
            e.Allow = false;
            e.Handled = true;
            return;

            //DateTime start = e.EditedAppointment.Start;
            //DateTime end = e.EditedAppointment.End;
            //int mtn_sch_id = Convert.ToInt32(e.EditedAppointment.Location);
            //int modality_id = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
            DialogResult dg = DialogResult.Cancel;
            DateTime start = e.EditedAppointment.Start;
            DateTime end = e.EditedAppointment.End;
            int modality = Convert.ToInt32(e.EditedAppointment.ResourceId);

            drag_drop = true;

            if (e.EditedAppointment.Start >= DateTime.Now)
            {
                //int mtn_sch_id = Convert.ToInt32(e.Appointment.Location);
                //ProcessGetRISModalitymaintenanceschedule getData
                //    = new ProcessGetRISModalitymaintenanceschedule();
                //getData.RISModalitymaintenanceschedule.MTN_SCH_ID = mtn_sch_id;
                //e.Appointment
                //string status = 

                object data = e.EditedAppointment.GetValue(schedulerStorage1, "MTN_SCH_STATUS");
                string status = data.ToString();
                if (status == "N")
                {
                    frmMechanicScheduleEdit frm
                        = new frmMechanicScheduleEdit(sender as SchedulerControl, e.EditedAppointment, modality);
                    e.Handled = true;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.Text = e.EditedAppointment.Subject;
                    dg = frm.ShowDialog();
                }
                else
                {
                    //MessageBox.Show("ไม่สามารถแก้ไขได้");
                    new MyMessageBox().ShowAlert("UID4011", new GBLEnvVariable().CurrentLanguageID);
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(e.EditedAppointment.Location))
                {
                    msg.ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                    e.Handled = true;
                    return;
                }
                frmMechanicScheduleEdit frm
                    = new frmMechanicScheduleEdit(sender as SchedulerControl, e.EditedAppointment, modality);
                e.Handled = true;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.Text = e.EditedAppointment.Subject;
                dg = frm.ShowDialog();

            }
            if (dg == DialogResult.OK)
            {
                initialScheduleData();
                initialAppointmentControl();
            }
            else
            {
                e.Handled = true;
                return;
            }
        }
        private void scControl_PreparePopupMenu(object sender, DevExpress.XtraScheduler.PreparePopupMenuEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                //DevExpress.Utils.Menu.DXMenuItem mnuPrint = new DevExpress.Utils.Menu.DXMenuItem("Print");
                //mnuPrint.Click += new EventHandler(mnuPrint_Click);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
                //e.Menu.Items.Add(mnuPrint);

                //DevExpress.Utils.Menu.DXMenuItem mnuPreview = new DevExpress.Utils.Menu.DXMenuItem("Print Preview");
                //mnuPreview.Click += new EventHandler(mnuPreview_Click);
                //e.Menu.Items.Add(mnuPreview);

                //DevExpress.Utils.Menu.DXMenuItem mnuPrintMulti = new DevExpress.Utils.Menu.DXMenuItem("Multi Print");
                //mnuPrintMulti.Click += new EventHandler(mnuPrintMulti_Click);
                //e.Menu.Items.Add(mnuPrintMulti);
            }
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                DevExpress.Utils.Menu.DXMenuItem mnuRefresh = new DevExpress.Utils.Menu.DXMenuItem("Refresh");
                mnuRefresh.Click += new EventHandler(mnuPrint_Click);
                e.Menu.Items.Add(mnuRefresh);
            }
        }
        private void scControl_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            if (e.Appointment.ResourceId.ToString() == "DevExpress.XtraScheduler.Resource")
            {
                e.Handled = true;
                return;
            }

            if (e.OpenRecurrenceForm)
            {
            }
            else
            {
                if (e.Appointment.Start >= DateTime.Now)
                {
                    if (string.IsNullOrEmpty(e.Appointment.Location))
                    {
                        DateTime start = e.Appointment.Start;
                        DateTime end = e.Appointment.End;
                        int modality = Convert.ToInt32(e.Appointment.ResourceId);
                        if (check_is_patient_schedule_period(start, end, modality))
                        {
                            //MessageBox.Show("Schedule Appoint ของคนไข้ ได้มีการลงทะเบียนในช่วงเวลานี้ไว้แล้ว");
                            //MessageBox.Show("ได้มีการลงทะเบียนในช่วงเวลานี้ไว้แล้ว");
                            new MyMessageBox().ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                            e.Handled = true;
                            return;
                        }

                        frmMechanicScheduleNew frm
                            = new frmMechanicScheduleNew(sender as SchedulerControl, e.Appointment);
                        e.Handled = true;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Text = "New - Appointment";
                        e.Appointment.Subject = "New";
                        e.DialogResult = frm.ShowDialog();
                    }
                    else
                    {
                        //int mtn_sch_id = Convert.ToInt32(e.Appointment.Location);
                        //ProcessGetRISModalitymaintenanceschedule getData
                        //    = new ProcessGetRISModalitymaintenanceschedule();
                        //getData.RISModalitymaintenanceschedule.MTN_SCH_ID = mtn_sch_id;
                        //e.Appointment
                        //string status = 

                        object data = e.Appointment.GetValue(schedulerStorage1, "MTN_SCH_STATUS");
                        string status = data.ToString();
                        if (status == "N")
                        {
                            frmMechanicScheduleEdit frm
                                = new frmMechanicScheduleEdit(sender as SchedulerControl, e.Appointment);
                            e.Handled = true;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.Text = e.Appointment.Subject;
                            e.DialogResult = frm.ShowDialog();
                        }
                        else
                        {
                            //MessageBox.Show("ไม่สามารถแก้ไขได้");
                            new MyMessageBox().ShowAlert("UID4011", new GBLEnvVariable().CurrentLanguageID);
                            e.Handled = true;
                            return;
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(e.Appointment.Location))
                    {
                        msg.ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                        e.Handled = true;
                        //return;
                    }
                    else
                    {
                        frmMechanicScheduleEdit frm
                            = new frmMechanicScheduleEdit(sender as SchedulerControl, e.Appointment);
                        e.Handled = true;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.Text = e.Appointment.Subject;
                        e.DialogResult = frm.ShowDialog();
                    }
                }
                if (e.DialogResult == DialogResult.OK)
                {
                    initialScheduleData();
                    initialAppointmentControl();
                }
            }
        }
        private void schedulerStorage1_AppointmentChanging(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            //e.Cancel = true;
            //return;
            if (drag_drop)
            {
                e.Cancel = true;
                drag_drop = false;
                return;
            }

            MyMessageBox msg = new MyMessageBox();
            GBLEnvVariable env = new GBLEnvVariable();

            PersistentObject obj = e.Object as PersistentObject;
            SchedulerStorage store = sender as SchedulerStorage;

            string id = obj.GetValue(store, "MTN_SCH_ID").ToString();
            int modality = Convert.ToInt32(obj.GetValue(store, "MODALITY_ID"));
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;
            string modality_drag = string.Empty;
            int s_id = 0;

            for (int i = 0; i < store.Appointments.Count; i++)
            {
                if (store.Appointments[i].Location.Trim() == id.Trim())
                {
                    start = store.Appointments[i].Start;
                    end = store.Appointments[i].End;
                    if (drag_drop)
                        modality_drag = store.Appointments[i].ResourceId.ToString();
                    s_id = i;
                    break;
                }
            }

            if (start < DateTime.Now)
            {
                e.Cancel = true;
                return;
            }

            if (check_is_patient_schedule_period(start, end, modality))
            {
                //MessageBox.Show("Schedule Appoint ของคนไข้ ได้มีการลงทะเบียนในช่วงเวลานี้ไว้แล้ว");
                //MessageBox.Show("ได้มีการลงทะเบียนในช่วงเวลานี้ไว้แล้ว");
                new MyMessageBox().ShowAlert("UID4009", new GBLEnvVariable().CurrentLanguageID);
                e.Cancel = true;
                return;
            }

            DialogResult dialog_result;
            Appointment apt = new Appointment();
            apt.Start = start;
            apt.End = end;
            apt.Location = id;

            object data = obj.GetValue(store, "MTN_SCH_STATUS");
            string status = data.ToString();
            if (status == "N")
            {
                frmMechanicScheduleEdit frm
                    = new frmMechanicScheduleEdit(sender as SchedulerControl, apt, Convert.ToInt32(modality));
                frm.StartPosition = FormStartPosition.CenterParent;
                //frm.Text = e.Appointment.Subject;
                dialog_result = frm.ShowDialog();
            }
            else
            {
                //MessageBox.Show("ไม่สามารถแก้ไขได้");
                new MyMessageBox().ShowAlert("UID4011", new GBLEnvVariable().CurrentLanguageID);
                e.Cancel = true;
                return;
            }

            if (dialog_result == DialogResult.OK)
            {
                initialScheduleData();
                initialAppointmentControl();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }
        private void schedulerStorage1_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            //e.Cancel = true;
            //return;

            MyMessageBox msg = new MyMessageBox();
            GBLEnvVariable env = new GBLEnvVariable();

            try
            {
                object data = e.Object.CustomFields["MTN_SCH_STATUS"];
                string status = data.ToString();
                if (status != "N")
                {
                    //MessageBox.Show("ไม่สามารถทำการลบข้อมูล ที่ได้ดำเนินงานไปแล้วได้");
                    new MyMessageBox().ShowAlert("UID4011", new GBLEnvVariable().CurrentLanguageID);
                    e.Cancel = true;
                    return;
                }

                if (msg.ShowAlert("UID1025", env.CurrentLanguageID) == "1")
                {
                    e.Cancel = true;
                    return;
                }

                int mtn_sch_id = Convert.ToInt32(e.Object.CustomFields[1]);// obj.GetValue(this.schedulerStorage1, "SCHEDULE_ID").ToString();
                //string modality = e.Object.CustomFields[3].ToString();//obj.GetValue(this.schedulerStorage1, "MODALITY_ID").ToString();
                //DateTime start = Convert.ToDateTime(e.Object.CustomFields[4]);//obj.GetValue(this.schedulerStorage1, "START_DATETIME").ToString()
                //DateTime end = Convert.ToDateTime(e.Object.CustomFields[5]);//obj.GetValue(this.schedulerStorage1, "END_DATETIME").ToString()

                ProcessGetRISModalitymaintenanceschedule getData
                    = new ProcessGetRISModalitymaintenanceschedule(2);
                getData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtn_sch_id;
                getData.RIS_MODALITYMAINTENANCESCHEDULE.MODE = "MTN_SCH_ID";
                getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = DateTime.Now; //only passing not use
                getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = DateTime.Now; //only passing not use
                getData.Invoke();

                DataRow rows = getData.Result.Tables[0].Rows[0];
                int sch_id = Convert.ToInt32(rows["SCHEDULE_ID"]);

                ProcessDeleteRISModalitymaintenanceschedule deleteData
                    = new ProcessDeleteRISModalitymaintenanceschedule();
                deleteData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtn_sch_id;
                deleteData.Invoke();

                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = sch_id;
                process.RIS_SCHEDULE.REASON_CHANGE = "ยกเลิกการซ่อมบำรุงเครื่องเอ็กซเรย์";
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();

            }
            catch (Exception ex)
            {
                e.Cancel = true;
                return;
            }
        }
       
        private void setTextBox()
        {
            if (ready)
            {
                currDT = scControl.ActiveView.SelectedInterval.Start;
                if (currDT > DateTime.MinValue && currDT < DateTime.MaxValue)
                {
                    //txtShow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    //txtShow.Text = currDT.ToString("dddd dd MMMM yyyy");

                    ProcessGetRISModalityclinictype proc = new ProcessGetRISModalityclinictype();
                    proc.Invoke();
                    DataTable dttModalityClinic = proc.Result.Tables[0].Copy();

                    for (int i = 0; i < chkList.CheckedItems.Count; i++)
                    {
                        modalitySelect = chkList.CheckedItems[i].ToString();
                        DataRow[] dr = dttResource.Select("MODALITY_NAME='" + modalitySelect.Trim() + "'");
                        string str = " 0/0.";
                        int id = 0;
                        if (dr.Length > 0)
                        {
                            //id = Convert.ToInt32(dr[0]["MODALITY_ID"]);
                            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                            //process.RISSchedule.MODALITY_ID = id;
                            //process.RISSchedule.APPOINT_DT = currDT;
                            ////id = process.CaseCount();
                            ////str = id.ToString();
                            //str = process.CaseCount().ToString();
                            //string perday = dr[0]["CASE_PER_DAY"].ToString();
                            //if (string.IsNullOrEmpty(perday))
                            //    str += "/0.";
                            //else
                            //    str += "/" + perday.ToString() + ".";
                        }
                       // txtShow.Text += "\r\n\t- " + modalitySelect + " Current appointment : " + str;
                        if (id > 0) 
                        {
                            dr = dttModalityClinic.Select("MODALITY_ID=" + id.ToString());
                            if (dr.Length > 0) 
                            {
                                modalitySelect = "\r\n";
                                foreach (DataRow d in dr) 
                                {
                                    //DateTime ds = Convert.ToDateTime(d["START_DATETIME"]);
                                    //DateTime de = Convert.ToDateTime(d["END_DATETIME"]);
                                    //ds = new DateTime(currDT.Year, currDT.Month, currDT.Day, ds.Hour, ds.Minute, 0);
                                    //de = new DateTime(currDT.Year, currDT.Month, currDT.Day, de.Hour, de.Minute, 0);
                                    //modalitySelect += d["CLINIC_TYPE_TEXT"].ToString() + "(";
                                    
                                    //proc.RISSchedule.SCHEDULE_ID = 0;
                                    //proc.RISSchedule.APPOINT_DT = ds;
                                    //proc.RISSchedule.END_DATETIME = de;
                                    //proc.RISSchedule.MODALITY_ID = id;
                                    //DataTable dtt = proc.GetCheckMax();

                                    
                                    //string cur = "0";
                                    //if (dtt != null)
                                    //    if (dtt.Rows.Count > 0)
                                    //        cur = dtt.Rows[0][0].ToString();
                                    //modalitySelect +=  cur + "/" + d["MAX_APP"].ToString() +")  ";
                                }
                              //  txtShow.Text += modalitySelect;
                            }
                        }
                    }
                }
                else
                {
                    //txtShow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //txtShow.Text = "กรุณาเลือก Modality";
                }
            }
            else
            {
                //txtShow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //txtShow.Text = "กรุณาเลือก Modality";
            }
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
            {
                //initDataGridSession();
                setGridSession(dttSession);
            }
        }

        private void scControl_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            object data = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "MTN_SCH_STATUS");

            if (data != null)
            {
                if (data.ToString().ToUpper() == "N") // New
                {
                    e.ViewInfo.Appearance.BackColor = Color.Pink;
                }
                else if (data.ToString().ToUpper() == "W") // Work In Progress
                {
                    e.ViewInfo.Appearance.BackColor = Color.OrangeRed;
                }
                else if (data.ToString().ToUpper() == "C") //  Complete
                {
                    e.ViewInfo.Appearance.BackColor = Color.OrangeRed;
                }
                else if (data.ToString().ToUpper() == "P") // Postponed
                {
                    e.ViewInfo.Appearance.BackColor = Color.LightGray;
                }
                else if (data.ToString().ToUpper() == "X") // Canceled
                {
                    e.ViewInfo.Appearance.BackColor = Color.LightGray;
                }
                else if (data.ToString().ToUpper() == "S") // Canceled
                {
                    e.ViewInfo.Appearance.BackColor = Color.LightGray;
                }
            }
        }

        //09-06-2009
        private void initNavigator() 
        {
            //btnMoveFirst.Enabled = false;
            //btnMoveLast.Enabled = false;
            //btnMoveNext.Enabled = false;
            //btnMovePrev.Enabled = false;
            //txtHNSearch.Text = string.Empty;
            //lblResult.Text = "Please key-in HN.";
        }
        private void initDataGridSession() 
        { 
            //ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
            //process.Invoke();
            //dttSession = new DataTable();
            //dttSession = process.Result.Tables[0].Copy();
            //setGridSession(dttSession);
        }
        private void setGridSession(DataTable dtt) 
        {
            //grdSchedule.DataSource = dtt;
            //if (view1.Columns.Count == 0) return;
            //for (int i = 0; i < dtt.Columns.Count; i++)
            //    view1.Columns[i].Visible = false;
            //RepositoryItemImageComboBox rImcb = new RepositoryItemImageComboBox();
            //rImcb.SmallImages = ImgSession;
            //rImcb.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",1,0),
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",2,1),
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",3,2),
            //    new DevExpress.XtraEditors.Controls.ImageComboBoxItem("",4,3)
            //});
            //rImcb.Buttons.Clear();

            //view1.Columns["SESSION_ID"].Visible = true;
            //view1.Columns["SESSION_ID"].Width = 20;
            //view1.Columns["SESSION_ID"].ColumnEdit = rImcb;
            //view1.Columns["SESSION_ID"].VisibleIndex = 2;
            //view1.Columns["SESSION_NAME"].Visible = true;
            //view1.Columns["SESSION_NAME"].Width = 300;
            //view1.Columns["SESSION_NAME"].VisibleIndex = 1;
            //view1.Columns["APP"].Visible = true;
            //view1.Columns["APP"].Width = 100;
            //view1.Columns["APP"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            //view1.Columns["APP"].VisibleIndex = 3;
            ////c.AppearanceCell.TextOptions.HAlignment = HorzAlignmentByString(alignment);
            //// scControl.Views.DayView.WorkTime.Start = DateTime.Now.TimeOfDay;
            ////view1.FocusedRowHandle = -2147483648;

            ////TimeSpan timeSP = new TimeSpan(1, 00, 00);
            ////TimeSpan timeEP = new TimeSpan(23, 59, 00);
            ////scControl.Views.DayView.WorkTime.Start = timeSP;
            ////scControl.Views.DayView.WorkTime.End = timeEP;
            ////timeSP = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            ////timeEP = timeSP.Add(TimeSpan.FromMinutes(10));
            ////scControl.Views.DayView.WorkTime.Start = timeSP;
            ////scControl.Views.DayView.WorkTime.End = timeEP;

        }
        private void setGridSessionSelect(string ModalityName) 
        {
            if (ready) 
            {
                if (ModalityName == "(Any)") return;
                DayOfWeek df = dateNav.SelectionStart.DayOfWeek;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int id = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());
                //ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                //process.RISClinicsession.MODALITY_ID = id;
                //process.RISClinicsession.ORG_ID = env.OrgID;
                //process.RISClinicsession.WEEKDAYS = Convert.ToInt32(df);
                //DataTable dtt = process.GetClinicSession();
                //foreach (DataRow dr in dtt.Rows) 
                //{
                //    DateTime tmp    = Convert.ToDateTime(dr["START_TIME"].ToString());
                //    DateTime start  = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day,tmp.Hour,tmp.Minute,tmp.Second);
                //    tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                //    DateTime end    = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day, tmp.Hour, tmp.Minute, tmp.Second);

                //    ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                //    proc.RISSchedule.MODALITY_ID = id;
                //    proc.RISSchedule.APPOINT_DT = start;
                //    proc.RISSchedule.END_DATETIME = end;
                //    DataTable dtmp = proc.GetSessionCount();
                //    dr["APP"] = dtmp.Rows[0][0].ToString() + "/" + dr["MAX_APP"].ToString();
                //}
                //dtt.AcceptChanges();
                //grdSchedule.DataSource = null;
                //setGridSession(dtt);
            }
        }
        private void searchSchedule() 
        {
            //if (txtHNSearch.Text.Trim().Length == 0)
            //{
            //    curr = 0;
            //    enableDisableNavigator(false);
            //    lblExam.Text = string.Empty;
            //    lblResult.Text = "Please key-in HN.";
            //    return;
            //}
            //enableDisableNavigator(true);
            //ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //process.RISSchedule.HN = txtHNSearch.Text;
            //dttHNSearch = new DataTable();
            //dttHNSearch = process.GetByHN();
            //if (dttHNSearch.Rows.Count == 0)
            //{
            //    curr = 0;
            //    lblExam.Text = string.Empty;
            //    enableDisableNavigator(false);
            //    lblResult.Text = "Schedule(s) not found.";
            //}
            //else
            //{
            //    lblResult.Text = dttHNSearch.Rows.Count + " schedule(s) found for this HN.";
            //    curr = 0;
            //    if (dttHNSearch.Rows.Count == 1)
            //    {
            //        scheduleNavigator();
            //        enableDisableNavigator(false);
            //    }
            //    else
            //    {
            //        int i = 0;
            //        bool flag = true;
            //        //find today
            //        for (; i < dttHNSearch.Rows.Count; i++)
            //        {
            //            DataRow dr = dttHNSearch.Rows[i];
            //            DateTime dtTmp = Convert.ToDateTime(dr["START_DATETIME"].ToString());
            //            dtTmp = new DateTime(dtTmp.Year, dtTmp.Month, dtTmp.Day, 0, 0, 0);
            //            if (dtTmp == DateTime.Today)
            //            {
            //                flag = false;
            //                break;
            //            }
            //        }
            //        //find feature.
            //        if (flag)
            //        {
            //            for (; i < dttHNSearch.Rows.Count; i++)
            //            {
            //                DataRow dr = dttHNSearch.Rows[i];
            //                DateTime dtTmp = Convert.ToDateTime(dr["START_DATETIME"].ToString());
            //                dtTmp = new DateTime(dtTmp.Year, dtTmp.Month, dtTmp.Day, 0, 0, 0);
            //                if (dtTmp >= DateTime.Today)
            //                    break;
            //            }
            //        }
            //        if (i >= dttHNSearch.Rows.Count)
            //            i = dttHNSearch.Rows.Count - 1;
            //        curr = i;
            //        scheduleNavigator();
            //    }
            //}
               
        }
        
        private void enableDisableNavigator(bool flag) 
        {
            //btnMoveFirst.Enabled = flag;
            //btnMoveLast.Enabled = flag;
            //btnMoveNext.Enabled = flag;
            //btnMovePrev.Enabled = flag;
        }
        private void scheduleNavigator() 
        {
            //scControl.DayView.ShowWorkTimeOnly = false;
            //btnCheckTime.Checked = false;
            //lblExam.Text = dttHNSearch.Rows[curr]["EXAM_NAME"].ToString();
            //DateTime dtFrom = Convert.ToDateTime(dttHNSearch.Rows[curr]["START_DATETIME"].ToString());
            //DateTime dtTO = Convert.ToDateTime(dttHNSearch.Rows[curr]["END_DATETIME"].ToString());
            //AppointmentBaseCollection aptBase = schedulerStorage1.Appointments.Items.GetAppointments(new TimeInterval(dtFrom, dtTO));
            //foreach (Appointment p in aptBase)
            //{
            //    if (p.Location == dttHNSearch.Rows[curr]["SCHEDULE_ID"].ToString())
            //    {
            //        int i = 0;
            //        for (; i < schedulerStorage1.Resources.Items.Count; i++)
            //            if (schedulerStorage1.Resources.Items[i].Id.ToString() == p.ResourceId.ToString())
            //            {
            //                chkList.SetItemChecked(i, true);
            //                break;
            //            }
            //        scControl.ActiveView.SelectAppointment(p);
            //        break;
            //    }

            //}
        }
        private void txtHNSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) {
            //    searchSchedule();    
            //}
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
            curr = curr >= dttHNSearch.Rows.Count ? dttHNSearch.Rows.Count-1 : curr;
            scheduleNavigator();
        }
        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            curr = dttHNSearch.Rows.Count-1;
            scheduleNavigator();
        }

        private void txtHNSearch_Validated(object sender, EventArgs e)
        {
            //if (txtHNSearch.Text.Trim().Length == 0)
            //{ 
            //    lblExam.Text = string.Empty;
            //    lblResult.Text = "Please key-in HN.";
            //}
        }

        //2010-02-15
        private bool check_is_patient_schedule_period(DateTime start, DateTime end, int modality_id)
        {
            try
            {
                ProcessGetRISModalitymaintenanceschedule getData
                    = new ProcessGetRISModalitymaintenanceschedule(2);
                getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = start;
                getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = end;
                getData.RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID_WHERECLAUSE = modality_id.ToString();
                getData.RIS_MODALITYMAINTENANCESCHEDULE.MODE = "Check Patient Appointment";
                getData.Invoke();
                DataTable table = getData.Result.Tables[0];
                int row_count = table.Rows.Count;

                if (row_count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                new MyMessageBox().ShowAlert("UID009", new GBLEnvVariable().CurrentLanguageID);
                return false;
            }
            //return false;
        }
        private void btnShowVisible_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
        }
        private void repositoryItemRadioGroup1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
        }
        private void repositoryItemRadioGroup1_EditValueChanged(object sender, System.EventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
        }
    }
}
