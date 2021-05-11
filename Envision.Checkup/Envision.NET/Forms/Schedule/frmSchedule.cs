using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using RIS.Forms.GBLMessage;
using RIS.Common;
using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Operational.ReportManager;
using DevExpress.XtraScheduler.UI;
namespace RIS.Forms.Schedule
{
    public partial class frmSchedule : Form
    {
        private UUL.ControlFrame.Controls.TabControl ctrlPage;
        
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

        public frmSchedule(UUL.ControlFrame.Controls.TabControl controlPage)
        {
            InitializeComponent();
            initialScheduler();
            initialModalityData();
            initialScheduleData();
            ctrlPage = controlPage;
            drag_drop = false;
            ready = false;
            dateNav.DateTime = DateTime.Today;
            currDT = DateTime.Today;
            modalitySelect = string.Empty;


            //
            initNavigator();
            initDataGridSession();
            xtraGridBlending1.GridControl.BackgroundImage = global::Envision.NET.Properties.Resources.gridBG;
         
        }

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            initialResourceControl();
            initialAppointmentControl();
            ready = true;
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
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dttAppointment=process.GetScheduleData();
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
            
            schedulerStorage1.Appointments.Mappings.ResourceId = "MODALITY_ID";
            schedulerStorage1.Appointments.Mappings.Start = "START_DATETIME";
            schedulerStorage1.Appointments.Mappings.End = "END_DATETIME";
            schedulerStorage1.Appointments.Mappings.Location = "SCHEDULE_ID";
            schedulerStorage1.Appointments.Mappings.Subject = "SCHEDULE_DATA";
            schedulerStorage1.Appointments.CustomFieldMappings[0].Name = "CommandType";
            schedulerStorage1.Appointments.CustomFieldMappings[0].Member = "CommandType";
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
        private void scControl_AppointmentDrop(object sender, DevExpress.XtraScheduler.AppointmentDragEventArgs e)
        {
            //check ว่า Modality มีการ MapExam หรือไม่
            //check ว่าช่วงเวลานั้นมี Block ไหม
            try
            {
                DateTime start = e.EditedAppointment.Start;
                DateTime end = e.EditedAppointment.End;

                if (start < DateTime.Now)
                {
                    drag_drop = false;
                    return;
                }
                DataTable dtt = new DataTable();
                string block = e.SourceAppointment.GetValue(this.schedulerStorage1, "IS_BLOCK").ToString();
                if (block == "Y")
                {
                    //
                    ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                    schedule.RISSchedule.SCHEDULE_ID = Convert.ToInt32(e.EditedAppointment.Location);
                    schedule.RISSchedule.MODALITY_ID = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
                    schedule.RISSchedule.APPOINT_DT = e.EditedAppointment.Start;
                    schedule.RISSchedule.END_DATETIME = e.EditedAppointment.End;
                    schedule.RISSchedule.IS_BLOCK = "Y";
                    dtt = schedule.CheckTime();
                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1108", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    drag_drop = true;
                }
                else
                {
                    if (e.SourceAppointment.ResourceId.ToString().Trim() != e.EditedAppointment.ResourceId.ToString().Trim())
                    {
                        //กรณีมีการเปลี่ยน modality
                        ProcessGetRISModalityexam procss = new ProcessGetRISModalityexam(true);
                        procss.Invoke();
                        dtt = procss.Result.Tables[0].Copy();
                        string ExamID = e.SourceAppointment.GetValue(schedulerStorage1, "EXAM_ID").ToString();
                        DataRow[] dr = dtt.Select("MODALITY_ID=" + e.EditedAppointment.ResourceId.ToString() + " AND EXAM_ID=" + ExamID);
                        if (dr.Length == 0)
                        {
                            string s = msg.ShowAlert("UID1106", env.CurrentLanguageID);
                            e.Allow = false;
                            e.Handled = true;
                            drag_drop = false;
                            return;
                        }

                    }
                    //เช็คว่ามี block อยู่ด้วยหรือเปล่า
                    ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                    schedule.RISSchedule.SCHEDULE_ID = Convert.ToInt32(e.EditedAppointment.Location);
                    schedule.RISSchedule.MODALITY_ID = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
                    schedule.RISSchedule.APPOINT_DT = e.EditedAppointment.Start;
                    schedule.RISSchedule.END_DATETIME = e.EditedAppointment.End;
                    schedule.RISSchedule.IS_BLOCK = "N";
                    dtt = schedule.CheckTime();
                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1107", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    block = e.SourceAppointment.GetValue(this.schedulerStorage1, "HN").ToString();
                    schedule.RISSchedule.HN = block;
                    dtt = schedule.CheckConfilctDateTime();
                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                        return;
                    }
                    ProcessGetRISSchedule sche = new ProcessGetRISSchedule();
                    DataTable dtsc = sche.GetScheduleData();
                    DataRow[] drr = dtsc.Select("SCHEDULE_ID=" + e.EditedAppointment.Location);
                    if (Convert.ToDateTime(drr[0]["START_DATETIME"])< DateTime.Now)
                    {
                        e.Allow = false;
                        e.Handled = true;
                        drag_drop = false;
                    }
                    //check session ว่าเกิดหรือไม่
                    ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                    process.RISClinicsession.MODALITY_ID = Convert.ToInt32(e.EditedAppointment.ResourceId.ToString());
                    process.RISClinicsession.ORG_ID = env.OrgID;
                    process.RISClinicsession.WEEKDAYS = Convert.ToInt32(e.EditedAppointment.Start.DayOfWeek);
                    process.Invoke();
                    DataTable dtmp = process.GetClinicSession();
                    int max_app = 0;
                    int clinic_id=0;
                    foreach (DataRow row in dttSession.Rows) {
                        DateTime dtStartApp = Convert.ToDateTime(row["START_TIME"].ToString());
                        DateTime dtEndApp = Convert.ToDateTime(row["END_TIME"].ToString());
                        DateTime dtSt = new DateTime(e.EditedAppointment.Start.Year, e.EditedAppointment.Start.Month, e.EditedAppointment.Start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                        DateTime dtEn = new DateTime(e.EditedAppointment.Start.Year, e.EditedAppointment.Start.Month, e.EditedAppointment.Start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);


                        if ((e.EditedAppointment.Start >= dtSt) && (e.EditedAppointment.End <= dtEn))
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
                        DateTime dtSt = new DateTime(e.EditedAppointment.Start.Year, e.EditedAppointment.Start.Month, e.EditedAppointment.Start.Day, dtStartApp.Hour, dtStartApp.Minute, dtStartApp.Second);
                        DateTime dtEn = new DateTime(e.EditedAppointment.Start.Year, e.EditedAppointment.Start.Month, e.EditedAppointment.Start.Day, dtEndApp.Hour, dtEndApp.Minute, dtEndApp.Second);

                        ProcessGetRISSchedule procSC = new ProcessGetRISSchedule();
                        procSC.RISSchedule.MODALITY_ID = process.RISClinicsession.MODALITY_ID;
                        procSC.RISSchedule.APPOINT_DT = dtSt;
                        procSC.RISSchedule.END_DATETIME = dtEn;
                        dtmp = new DataTable();
                        dtmp = procSC.GetSessionCount();
                        int curr_app = 0;
                        if (dtmp != null)
                        {
                            if (dtmp.Rows.Count > 0)
                                curr_app = Convert.ToInt32(dtmp.Rows[0]["AMT"].ToString());
                        }
                        if (curr_app > max_app)
                        {
                            if (msg.ShowAlert("UID1113", env.CurrentLanguageID) == "1")
                            {
                                e.Allow = false;
                                e.Handled = true;
                                drag_drop = false;
                            }
                        }
                    }

                    drag_drop = true;
                }
            }
            catch(Exception ex) {
                e.Allow = false;
                e.Handled = true;
                drag_drop = false;
            }
        }
        private void scControl_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {

                ProcessGetRISSchedule processScd = new ProcessGetRISSchedule();
                processScd.Invoke();
                DataSet dsSchD = processScd.Result;
                if (e.Appointment.ResourceId.ToString() == "DevExpress.XtraScheduler.Resource")
                {
                    e.Handled = true;
                    //frmShowModality frmSh = new frmShowModality();
                    //frmSh.ShowDialog();
                    return;
                }

                if (e.OpenRecurrenceForm)
                {
                    //RIS.BusinessLogic.Patient p = new Patient();
                }
                else
                {
                    if (e.Appointment.Start >= DateTime.Now)
                    {
                            if (string.IsNullOrEmpty(e.Appointment.Location))
                            {
                                frmAppointment frm = new frmAppointment(sender as SchedulerControl, e.Appointment);
                                e.Handled = true;
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.Text = "New - Appointment";
                                e.Appointment.Subject = "New";
                                e.DialogResult = frm.ShowDialog();

                            }
                            else
                            {
                                frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment);
                               
                                e.Handled = true;
                                frm.Text = e.Appointment.Subject;
                                e.DialogResult = frm.ShowDialog();
                            } 
                        
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(e.Appointment.Location))
                        {
                            e.Handled = true;
                            return;
                        }
                        frmAppointmentEdit frm = new frmAppointmentEdit(sender as SchedulerControl, e.Appointment);
                        e.Handled = true;
                        frm.Text = e.Appointment.Subject;
                        e.DialogResult = frm.ShowDialog();

                    }
                    if (e.DialogResult == DialogResult.OK)
                    {
                        //if (e.Appointment.Start < DateTime.Now)
                        //{
                        //    e.Handled = true;
                        //    return;
                        //}
                        initialScheduleData();
                        initialAppointmentControl();
                    }
                } 
        }
        private void scControl_PreparePopupMenu(object sender, DevExpress.XtraScheduler.PreparePopupMenuEventArgs e)
        {

            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {


                DevExpress.Utils.Menu.DXMenuItem mnuPrint = new DevExpress.Utils.Menu.DXMenuItem("Print");
                mnuPrint.Click += new EventHandler(mnuPrint_Click);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
                e.Menu.Items.Add(mnuPrint);

                DevExpress.Utils.Menu.DXMenuItem mnuPreview = new DevExpress.Utils.Menu.DXMenuItem("Print Preview");
                mnuPreview.Click += new EventHandler(mnuPreview_Click);
                e.Menu.Items.Add(mnuPreview);
            }
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu) {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                DevExpress.Utils.Menu.DXMenuItem mnuRefresh = new DevExpress.Utils.Menu.DXMenuItem("Refresh");
                mnuRefresh.Click += new EventHandler(mnuPrint_Click);
                e.Menu.Items.Add(mnuRefresh);
            }
        }
        private void scControl_SelectionChanged(object sender, EventArgs e)
        {
            checkModalityCase();
            //setGridSessionSelect();
        }
        private void scControl_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {

            //AppointmentViewInfo info = e.ObjectInfo as AppointmentViewInfo;
            //if (info != null)
            //{
            //    object data = info.Appointment.GetValue(schedulerStorage1, "SCHEDULE_STATUS");
            //    if (data != null)
            //    {
            //        if (data.ToString().ToUpper() == "D")
            //        {
            //            //Brush br = e.Cache.GetSolidBrush(Color.Pink);//Color.FromArgb(252, 24, 203));
            //            //e.Graphics.FillRectangle(br, e.Bounds);
            //            //DevExpress.XtraScheduler.AppointmentLabelCollection al = new AppointmentLabelCollection() ;
            //            //info.Appearance.ForeColor = Color.Pink;
            //            //info.Appearance.BackColor = Color.Pink;
            //            //e.Handled = true;

            //        }
            //        if (data.ToString().ToUpper() == "S")
            //        {

            //            Brush br = e.Cache.GetSolidBrush(Color.Orange);//Color.FromArgb(252, 192, 112));
            //            e.Graphics.FillRectangle(br, e.Bounds);
            //            //info.Appearance.ForeColor = Color.White;
            //            //info.Appearance.BackColor = Color.White;
            //            e.Handled = true;

            //        }
            //    }
            //}

        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            if(scControl.SelectedAppointments!=null)
                if (scControl.SelectedAppointments.Count > 0) {
                    string HN = scControl.SelectedAppointments[0].Subject;
                    if (HN.Trim().ToLower() == "block") return;
                    HN = HN.Substring(0, HN.IndexOf(','));
                    DateTime start = scControl.SelectedAppointments[0].Start;
                    int Modality=Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
                    RIS.Operational.DirectPrint.DirectPrint print = new RIS.Operational.DirectPrint.DirectPrint();
                    print.ScheduleDirectPrint(HN, start, Modality,Schedule);
                }
        }
        private void mnuPreview_Click(object sender, EventArgs e)
        {
            if (scControl.SelectedAppointments != null)
                if (scControl.SelectedAppointments.Count > 0)
                {
                    string HN = scControl.SelectedAppointments[0].Subject;
                    if (HN.Trim().ToLower() == "block") return;
                    HN = HN.Substring(0, HN.IndexOf(','));
                    DateTime start = scControl.SelectedAppointments[0].Start;
                    int Modality = Convert.ToInt32(scControl.SelectedAppointments[0].ResourceId.ToString());
                    int Schedule = Convert.ToInt32(scControl.SelectedAppointments[0].Location.ToString());
                    ReportMangager rptManager = new ReportMangager();
                    RIS.Reports.ReportViewer.frmReportViewer rptViewer = new RIS.Reports.ReportViewer.frmReportViewer(rptManager.rptScheduleReport(HN, start, Modality,Schedule), ctrlPage);
                    rptViewer.StartPosition = FormStartPosition.CenterScreen;
                    rptViewer.ShowDialog();
                }
        }
        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            initialScheduleData();
            initialAppointmentControl();
            schedulerStorage1.RefreshData();
            scControl.Refresh();

            //modality show case.

        }

        private void schedulerStorage1_AppointmentChanging(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            PersistentObject obj = e.Object as PersistentObject;
            DevExpress.XtraScheduler.SchedulerStorage store = sender as DevExpress.XtraScheduler.SchedulerStorage;

            #region Change by MyForm.
            string cmd = string.Empty;
            try
            {
                cmd = store.Appointments.CustomFieldMappings["CommandType"].GetValue(obj).ToString();

            }
            catch { }
            if (cmd == "F")
            {
                e.Cancel = false;
                store.Appointments.CustomFieldMappings["CommandType"].SetValue(obj, "N");
                initialScheduleData();
                initialAppointmentControl();
                return;
            }
            string status = obj.GetValue(this.schedulerStorage1, "SCHEDULE_STATUS").ToString();
            if (status == "O")
            {
                msg.ShowAlert("UID1104", env.CurrentLanguageID);
                e.Cancel = true;
                return;
            }
            #endregion

            string id = obj.GetValue(store, "SCHEDULE_ID").ToString();
            string block = obj.GetValue(store, "IS_BLOCK").ToString();
            string modality = obj.GetValue(store, "MODALITY_ID").ToString();
            DateTime start = DateTime.MinValue; ;
            DateTime end = DateTime.MinValue;
            string modality_drag = string.Empty;
            Appointment ap = new Appointment();
            ap.Description = "testtttt";

            for (int i = 0; i < store.Appointments.Count; i++)
            {
                if (store.Appointments[i].Location.Trim() == id.Trim())
                {
                    start = store.Appointments[i].Start;
                    end = store.Appointments[i].End;
                    if (drag_drop)
                        modality_drag = store.Appointments[i].ResourceId.ToString();
                    break;
                }
            }
            
            if (drag_drop == false)
            {
                #region Check ช่วงเวลาว่าสามารถสร้างเปลี่ยนแปลงได้หรือไม่.
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
             
                DataTable dtt = new DataTable();
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RISSchedule.SCHEDULE_ID = Convert.ToInt32(id);
                schedule.RISSchedule.MODALITY_ID = Convert.ToInt32(modality);
                schedule.RISSchedule.APPOINT_DT = start;
                schedule.RISSchedule.END_DATETIME = end;
                if (block.Trim() == "N")
                {
                    schedule.RISSchedule.IS_BLOCK = "N";
                    dtt = schedule.CheckTime();

                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1107", env.CurrentLanguageID);
                        e.Cancel = true;
                        return;
                    }
                    schedule.RISSchedule.HN = obj.GetValue(store, "HN").ToString();
                    dtt = schedule.CheckConfilctDateTime();
                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1111", env.CurrentLanguageID);
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    schedule.RISSchedule.IS_BLOCK = "Y";
                    dtt = schedule.CheckTime();
                    if (dtt.Rows.Count > 0)
                    {
                        string s = msg.ShowAlert("UID1108", env.CurrentLanguageID);
                        e.Cancel = true;
                        return;
                    }
                }
             
                #endregion
            }

            ConfirmDialog confrim;
            if (drag_drop)
                confrim = new ConfirmDialog(id, modality_drag, start, end);
            else
                confrim = new ConfirmDialog(id, modality, start, end);
            DialogResult dlg=confrim.ShowDialog();
         
            //cmd = msg.ShowAlert("UID1105", env.CurrentLanguageID);
            //if (cmd == "1")
            //{
            //    e.Cancel = true;
                
            //}
            if (dlg == DialogResult.Cancel)
                e.Cancel = true;
            else
            {
                ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
                process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(id);
                process.RISSchedule.APPOINT_DT = start;
                process.RISSchedule.END_DATETIME = end;
                process.RISSchedule.MODALITY_ID = Convert.ToInt32(modality);
                if (drag_drop)
                    process.RISSchedule.MODALITY_ID = Convert.ToInt32(modality_drag);
                process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                process.RISSchedule.REASON_CHANGE = confrim.REASON;
                process.UpdateBlockTimer();
            }
            drag_drop = false;
        }
        private void schedulerStorage1_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            PersistentObject obj = e.Object as PersistentObject;
            string status = obj.GetValue(this.schedulerStorage1, "SCHEDULE_STATUS").ToString();
            if (status == "O")
            {
                msg.ShowAlert("UID1103", env.CurrentLanguageID);
                e.Cancel = true;
                return;
            }


            //string s = msg.ShowAlert("UID1025", env.CurrentLanguageID);

            //if (s=="1")
            //    e.Cancel = true;

            string schduleID = obj.GetValue(this.schedulerStorage1, "SCHEDULE_ID").ToString();
            string modality = obj.GetValue(this.schedulerStorage1, "MODALITY_ID").ToString();
            DateTime start = Convert.ToDateTime(obj.GetValue(this.schedulerStorage1, "START_DATETIME").ToString());
            DateTime end = Convert.ToDateTime(obj.GetValue(this.schedulerStorage1, "END_DATETIME").ToString());
            ConfirmDialog confrim = new ConfirmDialog(schduleID, modality, start, end);
            confrim.Text = "ลบข้อมูล";
            DialogResult dlg=confrim.ShowDialog();

            if (dlg == DialogResult.Cancel)
                e.Cancel = true;
            else
            {              

                if (!string.IsNullOrEmpty(schduleID))
                {
                    RIS.BusinessLogic.ProcessDeleteRISSchedule process = new RIS.BusinessLogic.ProcessDeleteRISSchedule();
                    process.RISSchedule.SCHEDULE_ID = Convert.ToInt32(schduleID);
                    process.RISSchedule.REASON_CHANGE = confrim.REASON;
                    process.RISSchedule.LAST_MODIFIED_BY = env.UserID;
                    process.Invoke();
                }

                DataRow[] dr = dttAppointment.Select("SCHEDULE_ID=" + schduleID);
                if (dr.Length > 0)
                    dr[0].Delete();
                dttAppointment.AcceptChanges();
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
                            id = Convert.ToInt32(dr[0]["MODALITY_ID"]);
                            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                            process.RISSchedule.MODALITY_ID = id;
                            process.RISSchedule.APPOINT_DT = currDT;
                            //id = process.CaseCount();
                            //str = id.ToString();
                            str = process.CaseCount().ToString();
                            string perday = dr[0]["CASE_PER_DAY"].ToString();
                            if (string.IsNullOrEmpty(perday))
                                str += "/0.";
                            else
                                str += "/" + perday.ToString() + ".";
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
                                    DateTime ds = Convert.ToDateTime(d["START_DATETIME"]);
                                    DateTime de = Convert.ToDateTime(d["END_DATETIME"]);
                                    ds = new DateTime(currDT.Year, currDT.Month, currDT.Day, ds.Hour, ds.Minute, 0);
                                    de = new DateTime(currDT.Year, currDT.Month, currDT.Day, de.Hour, de.Minute, 0);
                                    modalitySelect += d["CLINIC_TYPE_TEXT"].ToString() + "(";
                                    
                                    proc.RISSchedule.SCHEDULE_ID = 0;
                                    proc.RISSchedule.APPOINT_DT = ds;
                                    proc.RISSchedule.END_DATETIME = de;
                                    proc.RISSchedule.MODALITY_ID = id;
                                    DataTable dtt = proc.GetCheckMax();

                                    
                                    string cur = "0";
                                    if (dtt != null)
                                        if (dtt.Rows.Count > 0)
                                            cur = dtt.Rows[0][0].ToString();
                                    modalitySelect +=  cur + "/" + d["MAX_APP"].ToString() +")  ";
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
            #region MyRegion
            //modalitySelect = chkList.CheckedItems[i].ToString();
            //DataRow[] dr = dttResource.Select("MODALITY_NAME='" + modalitySelect.Trim() + "'");
            //string str = " 0/0.";
            //if (dr.Length > 0)
            //{
            //    int id = Convert.ToInt32(dr[0]["MODALITY_ID"]);
            //    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            //    process.RISSchedule.MODALITY_ID = id;
            //    process.RISSchedule.APPOINT_DT = currDT;
            //    id = process.CaseCount();
            //    str = id.ToString();
            //    string perday = dr[0]["CASE_PER_DAY"].ToString();
            //    if (string.IsNullOrEmpty(perday))
            //        str += "/0.";
            //    else
            //        str += "/" + perday.ToString() + ".";
            //}

            //txtShow.Text += "\r\n\t- " + modalitySelect + " Current appointment : " + str;
            #endregion
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
            object data = e.ViewInfo.Appointment.GetValue(schedulerStorage1, "SCHEDULE_STATUS");

            if (data != null)
            {
                if (data.ToString().ToUpper() == "O")
                {
                    e.ViewInfo.Appearance.BackColor = Color.Pink;
                }
                else if (data.ToString().ToUpper() == "C")
                {
                    e.ViewInfo.Appearance.BackColor = Color.OrangeRed;
                }

            }
            
        }

        //09-06-2009
        private void initNavigator() 
        {
            btnMoveFirst.Enabled = false;
            btnMoveLast.Enabled = false;
            btnMoveNext.Enabled = false;
            btnMovePrev.Enabled = false;
            txtHNSearch.Text = string.Empty;
            lblResult.Text = "Please key-in HN.";
        }
        private void initDataGridSession() { 
            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
            process.Invoke();
            dttSession = new DataTable();
            dttSession = process.Result.Tables[0].Copy();
            setGridSession(dttSession);
        }
        private void setGridSession(DataTable dtt) {
            grdSchedule.DataSource = dtt;
            if (view1.Columns.Count == 0) return;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["SESSION_NAME"].Visible = true;
            view1.Columns["SESSION_NAME"].Width = 300;
            view1.Columns["APP"].Visible = true;
            view1.Columns["APP"].Width = 100;
            view1.Columns["APP"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

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
        private void setGridSessionSelect(string ModalityName) {
            if (ready) 
            {
                if (ModalityName == "(Any)") return;
                DayOfWeek df = dateNav.SelectionStart.DayOfWeek;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int id = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());
                ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
                process.RISClinicsession.MODALITY_ID = id;
                process.RISClinicsession.ORG_ID = env.OrgID;
                process.RISClinicsession.WEEKDAYS = Convert.ToInt32(df);
                DataTable dtt = process.GetClinicSession();
                foreach (DataRow dr in dtt.Rows) {
                    DateTime tmp    = Convert.ToDateTime(dr["START_TIME"].ToString());
                    DateTime start  = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day,tmp.Hour,tmp.Minute,tmp.Second);
                    tmp = Convert.ToDateTime(dr["END_TIME"].ToString());
                    DateTime end    = new DateTime(dateNav.SelectionStart.Year, dateNav.SelectionStart.Month, dateNav.SelectionStart.Day, tmp.Hour, tmp.Minute, tmp.Second);

                    ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                    proc.RISSchedule.MODALITY_ID = id;
                    proc.RISSchedule.APPOINT_DT = start;
                    proc.RISSchedule.END_DATETIME = end;
                    DataTable dtmp = proc.GetSessionCount();
                    dr["APP"] = dtmp.Rows[0][0].ToString() + "/" + dr["MAX_APP"].ToString();
                }
                dtt.AcceptChanges();
                grdSchedule.DataSource = null;
                setGridSession(dtt);
            }
        }
        private void searchSchedule() {
            if (txtHNSearch.Text.Trim().Length == 0)
            {
                curr = 0;
                enableDisableNavigator(false);
                lblExam.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
                return;
            }
            enableDisableNavigator(true);
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            process.RISSchedule.HN = txtHNSearch.Text;
            dttHNSearch = new DataTable();
            dttHNSearch = process.GetByHN();
            if (dttHNSearch.Rows.Count == 0)
            {
                curr = 0;
                lblExam.Text = string.Empty;
                enableDisableNavigator(false);
                lblResult.Text = "Schedule(s) not found.";
            }
            else
            {
                lblResult.Text = dttHNSearch.Rows.Count + " schedule(s) found for this HN.";
                curr = 0;
                if (dttHNSearch.Rows.Count == 1)
                {
                    scheduleNavigator();
                    enableDisableNavigator(false);
                }
                else
                {
                    int i = 0;
                    bool flag = true;
                    //find today
                    for (; i < dttHNSearch.Rows.Count; i++)
                    {
                        DataRow dr = dttHNSearch.Rows[i];
                        DateTime dtTmp = Convert.ToDateTime(dr["START_DATETIME"].ToString());
                        dtTmp = new DateTime(dtTmp.Year, dtTmp.Month, dtTmp.Day, 0, 0, 0);
                        if (dtTmp == DateTime.Today)
                        {
                            flag = false;
                            break;
                        }
                    }
                    //find feature.
                    if (flag)
                    {
                        for (; i < dttHNSearch.Rows.Count; i++)
                        {
                            DataRow dr = dttHNSearch.Rows[i];
                            DateTime dtTmp = Convert.ToDateTime(dr["START_DATETIME"].ToString());
                            dtTmp = new DateTime(dtTmp.Year, dtTmp.Month, dtTmp.Day, 0, 0, 0);
                            if (dtTmp >= DateTime.Today)
                                break;
                        }
                    }
                    if (i >= dttHNSearch.Rows.Count)
                        i = dttHNSearch.Rows.Count - 1;
                    curr = i;
                    scheduleNavigator();
                }
            }
               
        }
        
        private void enableDisableNavigator(bool flag) {
            btnMoveFirst.Enabled = flag;
            btnMoveLast.Enabled = flag;
            btnMoveNext.Enabled = flag;
            btnMovePrev.Enabled = flag;
        }
        private void scheduleNavigator() {
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
        private void txtHNSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                searchSchedule();    
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
            if (txtHNSearch.Text.Trim().Length == 0)
            { 
                lblExam.Text = string.Empty;
                lblResult.Text = "Please key-in HN.";
            }
        }
    }
}
