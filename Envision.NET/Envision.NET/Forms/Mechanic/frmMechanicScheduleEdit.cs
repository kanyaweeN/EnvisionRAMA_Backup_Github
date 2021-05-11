using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.Common;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;

namespace Envision.NET.Forms.Mechanic
{
    public partial class frmMechanicScheduleEdit : Form
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

        DataRow drSelectedRow;

        bool can_inserted = false;

        string sch_status = "";

        public frmMechanicScheduleEdit(SchedulerControl control, Appointment apt)
        {
            InitializeComponent();
            this.apt = apt;
            this.control = control;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");

            ReloadModality();
            ReloadPerson();
            ReLoadScheduleType();

            txtDateStart.DateTime = apt.Start;
            txtDateEnd.DateTime = apt.End;
            if (apt.Location.Trim().Length == 0)
            {
                txtTimeStart.Time = apt.Start;
                txtTimeEnd.Time = apt.End;
            }
            else
            {
                txtTimeStart.Time = apt.Start;
                txtTimeEnd.Time = apt.End;
            }

            ProcessGetRISModalitymaintenanceschedule getData
                = new ProcessGetRISModalitymaintenanceschedule(2);
            getData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = Convert.ToInt32(apt.Location);
            getData.RIS_MODALITYMAINTENANCESCHEDULE.MODE = "MTN_SCH_ID";
            getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = DateTime.Now; //only passing not use
            getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = DateTime.Now; //only passing not use

            try
            {
                getData.Invoke();
            }
            catch
            {
                return;
            }

            DataTable table = getData.Result.Tables[0];
            DataRow drSelectedRow = table.Rows[0];

            int modality_id = Convert.ToInt32(drSelectedRow["MODALITY_ID"]);
            {
                string modality_name = "";
                DataRow[] modality_rows = RIS_MODALITY.Select("MODALITY_ID = " + modality_id);
                if (modality_rows.Length > 0)
                    modality_name = modality_rows[0]["MODALITY_NAME"].ToString();
                txtModality.Text = modality_name;
            }


            int mtn_type_id = Convert.ToInt32(drSelectedRow["MTN_TYPE_ID"]);
            {
                string mtn_type_uid = "";
                DataRow[] mtn_type_rows = RIS_MODALITYMAINTENANCETYPE.Select("MTN_TYPE_ID = " + mtn_type_id);
                if (mtn_type_rows.Length > 0)
                    mtn_type_uid = mtn_type_rows[0]["MTN_TYPE_UID"].ToString();
                txtScheduleType.Text = mtn_type_uid;
            }

            int responsible_person = Convert.ToInt32(drSelectedRow["RESPONSIBLE_PERSON"]);
            {
                string responsible_person_name = "";
                DataRow[] responsible_person_rows = HR_EMP.Select("EMP_ID = " + responsible_person);
                if (responsible_person_rows.Length > 0)
                    responsible_person_name = responsible_person_rows[0]["FullName"].ToString();
                txtPerson.Text = responsible_person_name;
            }

            string comment = drSelectedRow["COMMENTS"].ToString();
            txtComment.Text = comment;

            decimal cost = Convert.ToDecimal(drSelectedRow["MTN_COST"]);
            txtCost.Value = cost;

            bool is_checked = Convert.ToBoolean(drSelectedRow["DISALLOW_EXAM"]);
            chkDisallowExam.Checked = is_checked;

            MTN_DT = DateTime.Now;

            sch_id = Convert.ToInt32(drSelectedRow["SCHEDULE_ID"]);

            sch_status = drSelectedRow["MTN_SCH_STATUS"].ToString();
        }
        public frmMechanicScheduleEdit(SchedulerControl control, Appointment apt, int modality_id)
        {
            InitializeComponent();
            this.apt = apt;
            this.control = control;
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Office 2007 Blue");

            ReloadModality();
            ReloadPerson();
            ReLoadScheduleType();

            txtDateStart.DateTime = apt.Start;
            txtDateEnd.DateTime = apt.End;
            if (apt.Location.Trim().Length == 0)
            {
                txtTimeStart.Time = apt.Start;
                txtTimeEnd.Time = apt.End;
            }
            else
            {
                txtTimeStart.Time = apt.Start;
                txtTimeEnd.Time = apt.End;
            }

            ProcessGetRISModalitymaintenanceschedule getData
                = new ProcessGetRISModalitymaintenanceschedule(2);
            getData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = Convert.ToInt32(apt.Location);
            getData.RIS_MODALITYMAINTENANCESCHEDULE.MODE = "MTN_SCH_ID";
            getData.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = DateTime.Now; //only passing not use
            getData.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = DateTime.Now; //only passing not use

            try
            {
                getData.Invoke();
            }
            catch
            {
                return;
            }

            DataTable table = getData.Result.Tables[0];
            DataRow drSelectedRow = table.Rows[0];

            //int modality_id = Convert.ToInt32(drSelectedRow["MODALITY_ID"]);
            {
                string modality_name = "";
                DataRow[] modality_rows = RIS_MODALITY.Select("MODALITY_ID = " + modality_id);
                if (modality_rows.Length > 0)
                    modality_name = modality_rows[0]["MODALITY_NAME"].ToString();
                txtModality.Text = modality_name;
            }


            int mtn_type_id = Convert.ToInt32(drSelectedRow["MTN_TYPE_ID"]);
            {
                string mtn_type_uid = "";
                DataRow[] mtn_type_rows = RIS_MODALITYMAINTENANCETYPE.Select("MTN_TYPE_ID = " + mtn_type_id);
                if (mtn_type_rows.Length > 0)
                    mtn_type_uid = mtn_type_rows[0]["MTN_TYPE_UID"].ToString();
                txtScheduleType.Text = mtn_type_uid;
            }

            int responsible_person = Convert.ToInt32(drSelectedRow["RESPONSIBLE_PERSON"]);
            {
                string responsible_person_name = "";
                DataRow[] responsible_person_rows = HR_EMP.Select("EMP_ID = " + responsible_person);
                if (responsible_person_rows.Length > 0)
                    responsible_person_name = responsible_person_rows[0]["FullName"].ToString();
                txtPerson.Text = responsible_person_name;
            }

            string comment = drSelectedRow["COMMENTS"].ToString();
            txtComment.Text = comment;

            decimal cost = Convert.ToDecimal(drSelectedRow["MTN_COST"]);
            txtCost.Value = cost;

            bool is_checked = Convert.ToBoolean(drSelectedRow["DISALLOW_EXAM"]);
            chkDisallowExam.Checked = is_checked;

            MTN_DT = DateTime.Now;

            sch_id = Convert.ToInt32(drSelectedRow["SCHEDULE_ID"]);

            sch_status = drSelectedRow["MTN_SCH_STATUS"].ToString();
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

            can_inserted = false;
            UpdateData();

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

        private void UpdateData()
        {
            if (!UpdateDataSchedule_Invoke())
                return;
            if (!UpdateDataModality_Invoke())
                return;

            can_inserted = true;
        }
        private bool UpdateDataSchedule_Invoke()
        {
            GBLEnvVariable env = new GBLEnvVariable();

            try
            {
                int mtn_sch_id = Convert.ToInt32(apt.Location);
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

                if (check_is_patient_schedule_period(start_time, end_time, modality_id))
                {
                    return false;
                }

                //ProcessUpdateRISModalitymaintenanceschedule UpdateDate
                //    = new ProcessUpdateRISModalitymaintenanceschedule();
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtn_sch_id;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID = modality_id;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_ID = mtn_type_id;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = start_time;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = end_time;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_COST = txtCost.Value;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.DISALLOW_EXAM = is_checked;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON = emp_id;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS = txtComment.Text;
                //UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                //UpdateDate.Invoke();

                ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(sch_id);
                //process.RIS_SCHEDULE.APPOINT_DT = start_time;
                process.RIS_SCHEDULE.START_DATETIME = start_time;
                process.RIS_SCHEDULE.END_DATETIME = end_time;
                process.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(modality_id);
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.RIS_SCHEDULE.REASON_CHANGE = "มีการเลื่อนการซ่อมบำรุงเครื่องเอ็กซเรย์";
                process.UpdateBlockTimer();

                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool UpdateDataModality_Invoke()
        {
            try
            {
                int mtn_sch_id = Convert.ToInt32(apt.Location);
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

                if (check_is_patient_schedule_period(start_time, end_time, modality_id))
                {
                    return false;
                }

                ProcessUpdateRISModalitymaintenanceschedule UpdateDate
                    = new ProcessUpdateRISModalitymaintenanceschedule();
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtn_sch_id;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID = modality_id;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_ID = mtn_type_id;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.START_TIME = start_time;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.END_TIME = end_time;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.MTN_COST = txtCost.Value;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.DISALLOW_EXAM = is_checked;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON = emp_id;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS = txtComment.Text;
                UpdateDate.RIS_MODALITYMAINTENANCESCHEDULE.LAST_MODIFIED_BY = new GBLEnvVariable().UserID;
                UpdateDate.Invoke();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MyMessageBox msg = new MyMessageBox();
            GBLEnvVariable env = new GBLEnvVariable();
            if (msg.ShowAlert("UID1025", env.CurrentLanguageID) == "1") return;

            if (sch_status != "N")
            {
                MessageBox.Show("ไม่สามารถทำการลบข้อมูล ที่ได้ดำเนินงานไปแล้วได้");
                return;
            }

            try
            {
                int mtn_sch_id = Convert.ToInt32(apt.Location);
                ProcessDeleteRISModalitymaintenanceschedule deleteData
                    = new ProcessDeleteRISModalitymaintenanceschedule();
                deleteData.RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID = mtn_sch_id;
                deleteData.Invoke();

                ProcessDeleteRISSchedule process = new ProcessDeleteRISSchedule();
                process.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(sch_id);
                process.RIS_SCHEDULE.REASON_CHANGE = "ยกเลิกการซ่อมบำรุงเครื่องเอ็กซเรย์";
                process.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                process.Invoke();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string s = msg.ShowAlert("UID1102", env.CurrentLanguageID);
                txtModality.Focus();
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
                MessageBox.Show(ex.Message);
                return false;
            }
            //return false;
        }
    }
}
