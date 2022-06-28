using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
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
        public void InvokeWorklist(DateTime start_datetime, DateTime end_datetime)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            result = _proc.getDataWorklist(start_datetime, end_datetime);
        }

        public DataTable getXrayreqData(int xrayreq_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.getXrayreqData(xrayreq_id);
        }
        public DataTable getXrayreqData(int xrayreq_id, int modality_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.getXrayreqData(xrayreq_id, modality_id);
        }
        public DataTable GetScheduleData()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            ds = _proc.GetScheduleData();
            return ds.Tables[0];
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
        public DataTable CheckConfilctDateTime(string hn, int exam_id, DateTime datetime_start)
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            ds = _proc.CheckConflictTime(hn, exam_id, datetime_start);
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
        public DataTable GetModality()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();

            return _proc.GetModality().Tables[0].Copy();
        }
        public DataTable GetSessionCount()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetSessionCount().Tables[0].Copy();
        }
        public DataSet GetSessionShow()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetSessionShow().Copy();
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
        public DataTable GetAppointOnline()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetAppointOnline();
        }
        public DataTable GetPendingOnline()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetPendingOnline();
        }
        public DataTable GetShowOnline()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetShowOnline();
        }
        public DataTable GetOnlineStatCase()
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.GetOnlineStatCase();
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
        public DataTable GetAppointmentDuration(string hn, DateTime date_selected)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.GetAppointmentDuration(hn, date_selected).Tables[0].Copy();
        }
        public DataTable GetDataTest()
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.GetScheduleDataTest();
        }
        public DataTable GetScheduleBlock()
        {
            RISScheduleSelectData proc = new RISScheduleSelectData();
            proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return proc.GetScheduleBlock();
        }
        public DataTable UpdateNotifyAdmin(int SCHEDULE_ID, string NOTIFY_ADMIN_WL)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            return _proc.UpdateNotifyAdmin(SCHEDULE_ID, NOTIFY_ADMIN_WL);
        }
        public DataTable getAppointmentMerge(int schedule_id, int modality_id, DateTime appoint_dt, int reg_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.getAppointmentMerge(schedule_id, modality_id, appoint_dt, reg_id);
        }
        public DataSet getAppointmentMerge(int schedule_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.getAppointmentMerge(schedule_id);
        }
        public DataSet checkExamConflictMerge(int schedule_id, int exam_id)
        {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            return _proc.checkExamConflictMerge(schedule_id, exam_id);
        }
    }
}

