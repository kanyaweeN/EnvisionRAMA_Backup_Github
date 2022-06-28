using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.BusinessLogic
{
    public class ScheduleInfo
    {
        public static int SCHEDULE_CONFIG_Id { private set; get; }
        public static int SCHEDULE_CONFIRM_TIME { private set; get; }
        public static int SCHEDULE_REFRESH_TIME { private set; get; }
        public static string CAN_OVERLAP { private set; get; }
        public static string CAN_EXCEED_MAX { private set; get; }
        public static string SHOW_ALERT { private set; get; }
        public static string NEED_CONFIRMATION { private set; get; }
        public static string DEFAULT_SEARCH { private set; get; }
        public static string DEFAULT_ONLINE_ACTION { private set; get; }
        public static TimeSpan START_WORK_TIME { private set; get; }
        public static TimeSpan END_WORK_TIME { private set; get; }
        public static string WORK_TIME_IS_CHECKED { private set; get; }
        public static string DEFAULT_CALENDAR_VIEW { private set; get; }
        public static string ALLOW_UNTIMED_SCHEDULE { private set; get; }
        public static TimeSpan TIME_SCALE { private set; get; }
        public static DataTable CLINIC_SESSION { private set; get; }

        private static void initScheduleInfo()
        {
            ProcessGetRisScheduleConfig proc = new ProcessGetRisScheduleConfig();
            proc.Invoke();
            DataTable dtt = proc.Result;
            SCHEDULE_CONFIG_Id = Convert.ToInt32(dtt.Rows[0]["SCHEDULE_CONFIG_ID"].ToString());
            SCHEDULE_CONFIRM_TIME = Convert.ToInt32(dtt.Rows[0]["SCHEDULE_CONFIRM_TIME"].ToString());
            SCHEDULE_REFRESH_TIME = Convert.ToInt32(dtt.Rows[0]["SCHEDULE_REFRESH_TIME"].ToString());
            CAN_OVERLAP = dtt.Rows[0]["CAN_OVERLAP"].ToString();
            CAN_EXCEED_MAX = dtt.Rows[0]["CAN_EXCEED_MAX"].ToString();
            SHOW_ALERT = dtt.Rows[0]["SHOW_ALERT"].ToString();
            NEED_CONFIRMATION = dtt.Rows[0]["NEED_CONFIRMATION"].ToString();
            DEFAULT_SEARCH = dtt.Rows[0]["DEFAULT_SEARCH"].ToString();
            DEFAULT_ONLINE_ACTION = dtt.Rows[0]["DEFAULT_ONLINE_ACTION"].ToString();
            WORK_TIME_IS_CHECKED = dtt.Rows[0]["WORK_TIME_IS_CHECKED"].ToString();
            DEFAULT_CALENDAR_VIEW = dtt.Rows[0]["DEFAULT_CALENDAR_VIEW"].ToString();
            ALLOW_UNTIMED_SCHEDULE = dtt.Rows[0]["ALLOW_UNTIMED_SCHEDULE"].ToString();
            string[] tm = dtt.Rows[0]["START_WORK_TIME"].ToString().Split(':'.ToString().ToCharArray());
            START_WORK_TIME = new TimeSpan(Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), Convert.ToInt32(tm[2]));
            tm = dtt.Rows[0]["END_WORK_TIME"].ToString().Split(':'.ToString().ToCharArray());
            END_WORK_TIME = new TimeSpan(Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), Convert.ToInt32(tm[2]));
            tm = dtt.Rows[0]["TIME_SCALE"].ToString().Split(':'.ToString().ToCharArray());
            TIME_SCALE = new TimeSpan(Convert.ToInt32(tm[0]), Convert.ToInt32(tm[1]), Convert.ToInt32(tm[2]));

            ProcessGetRISClinicsession clinicSession = new ProcessGetRISClinicsession();
            clinicSession.Invoke();
            CLINIC_SESSION = clinicSession.Result.Tables[0].Copy();
        }

        static ScheduleInfo()
        {
            initScheduleInfo();
        }
        public ScheduleInfo()
        {
            initScheduleInfo();
        }

        public bool CanAppointment(int ModalityId, int SessionId, DateTime StartDate, DateTime EndDate, int patientAge)
        {
            bool flag = true;
            //ProcessGetRISClinicsession clinicSession = new ProcessGetRISClinicsession();
            //clinicSession.Invoke();
            //DataView dv = new DataView(clinicSession.Result.Tables[0]);
            //dv.RowFilter = "SESSION_ID=" + SessionId;
            //DataTable dttSession = dv.ToTable();
            //if (Miracle.Util.Utilities.IsHaveData(dttSession))
            //{
            //    ProcessGetRISModalityConfig proc = new ProcessGetRISModalityConfig();
            //    proc.RIS_MODALITYCONFIG.MODALITY_ID = ModalityId;
            //    proc.RIS_MODALITYCONFIG.CLINIC_SESSION_ID = SessionId;
            //    proc.RIS_MODALITYCONFIG.WEEKDAY = (int)StartDate.DayOfWeek;
            //    DataTable dtt = proc.GetBySession();
            //    if (Miracle.Util.Utilities.IsHaveData(dtt))
            //    {
            //        int adout = Convert.ToInt32(dtt.Rows[0]["ADULT"].ToString());
            //        int child = Convert.ToInt32(dtt.Rows[0]["CHILD"].ToString());
            //        DateTime sessStart = Convert.ToDateTime(dttSession.Rows[0]["START_TIME"].ToString());
            //        DateTime sessEnd = Convert.ToDateTime(dttSession.Rows[0]["END_TIME"].ToString());
            //        DateTime dtStart = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, sessStart.Hour, sessStart.Minute, sessStart.Second);
            //        DateTime dtEnd = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, sessEnd.Hour, sessEnd.Minute, sessEnd.Second);
            //        ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
            //        schedule.RIS_SCHEDULE.MODALITY_ID = ModalityId;
            //        schedule.RIS_SCHEDULE.START_DATETIME = dtStart;
            //        schedule.RIS_SCHEDULE.END_DATETIME = dtEnd;
            //        schedule.RIS_SCHEDULE.SCHEDULE_ID = 0;
            //        DataSet dsCurrent = schedule.GetCurrentAppointment();
            //        int currentChild = Convert.ToInt32(dsCurrent.Tables[0].Rows[0][0].ToString());
            //        int currentOLD = Convert.ToInt32(dsCurrent.Tables[1].Rows[0][0].ToString());
            //        if (patientAge > 14)
            //            flag = adout - currentChild > 0 ? true : false;
            //        else
            //            flag = child - currentOLD > 0 ? true : false;
            //    }
            //}
            return flag;
        }
        public bool CanAppointment(int ScheduleId, int ModalityId, int SessionId, DateTime StartDate, DateTime EndDate, int patientAge)
        {
            bool flag = true;
            //ProcessGetRISClinicsession clinicSession = new ProcessGetRISClinicsession();
            //clinicSession.Invoke();
            //DataView dv = new DataView(clinicSession.Result.Tables[0]);
            //dv.RowFilter = "SESSION_ID=" + SessionId;
            //DataTable dttSession = dv.ToTable();
            //if (Miracle.Util.Utilities.IsHaveData(dttSession))
            //{
            //    ProcessGetRISModalityConfig proc = new ProcessGetRISModalityConfig();
            //    proc.RIS_MODALITYCONFIG.MODALITY_ID = ModalityId;
            //    proc.RIS_MODALITYCONFIG.CLINIC_SESSION_ID = SessionId;
            //    proc.RIS_MODALITYCONFIG.WEEKDAY = (int)StartDate.DayOfWeek;
            //    DataTable dtt = proc.GetBySession();
            //    if (Miracle.Util.Utilities.IsHaveData(dtt))
            //    {
            //        int adout = Convert.ToInt32(dtt.Rows[0]["ADULT"].ToString());
            //        int child = Convert.ToInt32(dtt.Rows[0]["CHILD"].ToString());
            //        DateTime sessStart = Convert.ToDateTime(dttSession.Rows[0]["START_TIME"].ToString());
            //        DateTime sessEnd = Convert.ToDateTime(dttSession.Rows[0]["END_TIME"].ToString());
            //        DateTime dtStart = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, sessStart.Hour, sessStart.Minute, sessStart.Second);
            //        DateTime dtEnd = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, sessEnd.Hour, sessEnd.Minute, sessEnd.Second);
            //        ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
            //        schedule.RIS_SCHEDULE.MODALITY_ID = ModalityId;
            //        schedule.RIS_SCHEDULE.START_DATETIME = dtStart;
            //        schedule.RIS_SCHEDULE.END_DATETIME = dtEnd;
            //        schedule.RIS_SCHEDULE.SCHEDULE_ID = ScheduleId;
            //        DataSet dsCurrent = schedule.GetCurrentAppointment();
            //        int currentChild = Convert.ToInt32(dsCurrent.Tables[0].Rows[0][0].ToString());
            //        int currentOLD = Convert.ToInt32(dsCurrent.Tables[1].Rows[0][0].ToString());
            //        if (patientAge > 14)
            //            flag = adout - currentChild > 0 ? true : false;
            //        else
            //            flag = child - currentOLD > 0 ? true : false;
            //    }
            //}
            return flag;
        }
        public bool CanExceedSchedule(int EmpId)
        {
            bool flag = false;
            ProcessGetHREmp proc = new ProcessGetHREmp();
            proc.HR_EMP.EMP_ID = EmpId;
            proc.HR_EMP.ORG_ID = 1;
            DataTable dtt = proc.GetEmployee();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
                if (dtt.Rows[0]["CAN_EXCEED_SCHEDULE"].ToString() == "Y") flag = true;
            return flag;
        }

        public bool IsHaveAppointment(int modalityID, DateTime StartDate, DateTime EndDate)
        {
            bool flag = false;
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            proc.RIS_SCHEDULE.MODALITY_ID = modalityID;
            proc.RIS_SCHEDULE.START_DATETIME = StartDate;
            proc.RIS_SCHEDULE.END_DATETIME = EndDate;
            DataTable dtt = proc.CheckFreeSlot();
            if (Miracle.Util.Utilities.IsHaveData(dtt)) flag = true;
            return flag;
        }
        public bool IsHaveAppointment(string hn, int exam_id, DateTime datetime_start,out DataTable dataConflict)
        {
            bool flag = false;
            ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
            dataConflict = proc.CheckConfilctDateTime(hn, exam_id, datetime_start);
            if (Miracle.Util.Utilities.IsHaveData(dataConflict)) flag = true;
            return flag;
        }

        public bool CanMoveAppointment(int scheduleId, int modalityId, int weekday)
        {
            bool flag = false;
            ProcessGetRISSchedule process = new ProcessGetRISSchedule(scheduleId);
            process.Invoke();
            int sessionId = Convert.ToInt32(process.Result.Tables[0].Rows[0]["SESSION_ID"].ToString());
            DataTable dttSchedule = process.Result.Tables[1].Copy();
            DataTable dttExam = GetExamData(modalityId, sessionId, weekday);
            foreach (DataRow rowHandle in dttSchedule.Rows)
            {
                DataView dv = new DataView(dttExam);
                dv.RowFilter = "EXAM_ID=" + rowHandle["EXAM_ID"].ToString();
                if (Miracle.Util.Utilities.IsHaveData(dv.ToTable()))
                    flag = true;
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public int GetSessionId(int scheduleId)
        {
            int id = 0;
            ProcessGetRISSchedule process = new ProcessGetRISSchedule(scheduleId);
            process.Invoke();
            DataTable dtt = process.Result.Tables[0].Copy();
            if (Miracle.Util.Utilities.IsHaveData(dtt))
                id = Convert.ToInt32(dtt.Rows[0]["SESSION_ID"].ToString());
            return id;
        }
        public DataTable GetExamData(int modalityId, int sessionId, int weekday)
        {
            //ProcessGetRISModalityexam processExam = new ProcessGetRISModalityexam();
            //processExam.RIS_MODALITYEXAM.MODALITY_ID = modalityId;
            //processExam.RIS_MODALITYEXAM.CLINIC_SESSION_ID = sessionId;
            //processExam.RIS_MODALITYEXAM.WEEKDAY = weekday;
            //return processExam.GetExamByConfig();
            return null;
        }

        public bool IsDateTimeInSession(DateTime dtDate)
        {
            bool flag = false;
            DataTable dttSession = CLINIC_SESSION;
            foreach (DataRow row in dttSession.Rows)
            {
                DateTime sessionStart = Convert.ToDateTime(row["START_TIME"].ToString());
                DateTime sessionEnd = Convert.ToDateTime(row["END_TIME"].ToString());
                DateTime start = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, sessionStart.Hour, sessionStart.Minute, sessionStart.Second);
                DateTime end = new DateTime(dtDate.Year, dtDate.Month, dtDate.Day, sessionEnd.Hour, sessionEnd.Minute, sessionEnd.Second);
                if (dtDate >= start && dtDate <= end)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public DataSet GetDefaultDestination(int EmpId)
        {
            ProcessGetRISScheduleDefaultDestination proc = new ProcessGetRISScheduleDefaultDestination();
            proc.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = EmpId;
            proc.Invoke();
            return proc.Result;
        }
        public DataTable GetModality() {
            ProcessGetRISModality proc = new ProcessGetRISModality();
            proc.Invoke();
            DataTable dtt=null;
            if (Miracle.Util.Utilities.IsHaveData(proc.Result)) dtt = proc.Result.Tables[0];
            return dtt;
        }
    }
}
