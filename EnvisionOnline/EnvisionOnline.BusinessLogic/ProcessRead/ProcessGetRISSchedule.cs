using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISSchedule : IBusinessLogic
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        private DataSet result;
        private int action = 0;

        public ProcessGetRISSchedule()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.SCHEDULE_ID = 0;
            action = 0;
        }
        public ProcessGetRISSchedule(int scheduleID)
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.SCHEDULE_ID = scheduleID;
            action = 1;
        }
        public ProcessGetRISSchedule(string HN)
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.HN = HN;
            action = 2;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            //RISScheduleSelectData _proc = new RISScheduleSelectData();
            //_proc.RIS_SCHEDULE = _risschedule;
            //if (_risschedule.SCHEDULE_ID > 0)
            //    _proc = new RISScheduleSelectData(_risschedule.SCHEDULE_ID);

            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            if (action == 1)
                _proc = new RISScheduleSelectData(RIS_SCHEDULE.SCHEDULE_ID);
            else if (action == 2)
                _proc = new RISScheduleSelectData(RIS_SCHEDULE.HN);
            result = _proc.GetData();
        }
        public DataTable GetScheduleData()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            ds = _proc.GetScheduleData();
            return ds.Tables[0];
        }
        public DataTable GetScheduleConflictExam(int exam_id, int reg_id)
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            ds = _proc.GetScheduleConflictExam(exam_id, reg_id);
            return ds.Tables[0];
        }
        public DataTable get_ScheduleAppCountDisplay(int modalityId, DateTime appDate, string sessionUid)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.getScheduleAppCountDisplay(modalityId, appDate, sessionUid).Tables[0];
        }
        public DataTable CheckTime()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            ds = _proc.CheckTime();
            return ds.Tables[0];
            //return ds;
        }
        public DataTable CheckConfilctDateTime()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            ds = _proc.CheckConflictTime();
            return ds.Tables[0];
            //return ds;
        }
        public DataTable CheckFreeSlot()
        {
            DataTable dtt = new DataTable();
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.CheckFreeSlot();
        }
        public DataTable GetScheduleApp(DateTime start_time, DateTime end_time, int modality_id)
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE.START_DATETIME = start_time;
            proc.RIS_SCHEDULE.END_DATETIME = end_time;
            proc.RIS_SCHEDULE.MODALITY_ID = modality_id;
            return proc.GetScheduleApp();
        }
        public DataSet CheckBlockcase(DateTime start_datetime,int modality_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE.SCHEDULE_DT = start_datetime;
            _proc.RIS_SCHEDULE.MODALITY_ID = modality_id;
            return _proc.checkBlockcase();

        }

        public static bool hasHN(int RegID, string HN, DateTime dtAPPOINT_DT, ref int schedule_id)
        {
            bool flag = false;
            schedule_id = 0;
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE.REG_ID = RegID;
            //_proc.RIS_SCHEDULE.HN = HN;
            _proc.RIS_SCHEDULE.SCHEDULE_DT = DateTime.Today;
            DataSet ds = _proc.GetData();
            if (ds != null)
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["SCHEDULE_STATUS"].ToString() == "0")
                    {
                        flag = true;
                        schedule_id = Convert.ToInt32(ds.Tables[0].Rows[0]["SCHEDULE_ID"]);
                    }
                }
            return flag;
        }
        public int CaseCount()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.CaseCount();
        }
        public DataSet GetLogSchedule(int ID)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE.SCHEDULE_ID = ID;
            return _proc.GetScheduleLog();
        }
        public DataTable GetAppointment()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetHNAppointment().Tables[0].Copy();
        }
        public DataTable GetModality(int emp_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();

            return _proc.GetModality(emp_id).Tables[0].Copy();
        }
        public DataTable GetSessionCount()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetSessionCount().Tables[0].Copy();
        }
        public DataSet GetByHN()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetByHN();
            // return _proc.GetByHN().Tables[0].Copy();

        }
        public DataTable GetMultiPrint()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetByMultiPrint().Tables[0].Copy();
        }
        public bool CheckFreeTime()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            ds = _proc.CheckFreeTime();
            bool flag = true;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    flag = false;
                else if (ds.Tables[1].Rows.Count > 0)
                    flag = false;
            }
            return flag;
        }
        public DataTable GetWaitingList()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetWaitingList();
        }
        public DataTable GetBusyStatus()
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.GetBusyStatus();
        }
        public DataSet GetCurrentAppointment()
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.GetCurrentAppointment();
        }

        public DataTable GetDataTest()
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.GetScheduleDataTest();
        }
        public DataTable UpdateNotifyAdmin(int SCHEDULE_ID, string NOTIFY_ADMIN_WL)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.UpdateNotifyAdmin(SCHEDULE_ID, NOTIFY_ADMIN_WL);
        }
    }
}
