using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISSchedule : IBusinessLogic
	{
		private DataSet result;
        private RISSchedule _risschedule;
        private int action = 0;
       
		public ProcessGetRISSchedule()
		{
			_risschedule = new  RISSchedule();
            _risschedule.SCHEDULE_ID = 0;
            action = 0;
		}
        public ProcessGetRISSchedule(int scheduleID)
        {
            _risschedule = new RISSchedule();
            _risschedule.SCHEDULE_ID = scheduleID;
            action = 1;
        }
        public ProcessGetRISSchedule(string HN)
        {
            _risschedule = new RISSchedule();
            _risschedule.HN = HN;
            action = 2;
        }

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}

        public RISSchedule RISSchedule {
            get { return _risschedule; }
            set { _risschedule = value; }
        }

		public void Invoke()
		{
            //RISScheduleSelectData _proc = new RISScheduleSelectData();
            //_proc.RISSchedule = _risschedule;
            //if (_risschedule.SCHEDULE_ID > 0)
            //    _proc = new RISScheduleSelectData(_risschedule.SCHEDULE_ID);

            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = _risschedule;
            if(action==1)
                _proc = new RISScheduleSelectData(_risschedule.SCHEDULE_ID);
            else if(action==2)
                _proc = new RISScheduleSelectData(_risschedule.HN);
            result = _proc.GetData();
		}
        public DataTable GetScheduleData() {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            ds = _proc.GetScheduleData();
            return ds.Tables[0];
        }
        public DataTable CheckTime()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            ds = _proc.CheckTime();
            return ds.Tables[0];
            //return ds;
        }
        public DataTable CheckConfilctDateTime()
        {
            DataSet ds = new DataSet();
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            ds = _proc.CheckConflictTime();
            return ds.Tables[0];
            //return ds;
        }
        public static bool hasHN(int RegID, string HN, DateTime dtAPPOINT_DT,ref int schedule_id)
        {
            bool flag = false;
            schedule_id = 0;
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule.REG_ID = RegID;
            _proc.RISSchedule.HN = HN;
            _proc.RISSchedule.SCHEDULE_DT = DateTime.Today;
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
        public int CaseCount() {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            return _proc.CaseCount();
        }
        public DataSet GetLogSchedule(int ID) {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule.SCHEDULE_ID = ID;
            return _proc.GetScheduleLog();
        }
        public DataTable GetAppointment() {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            return _proc.GetHNAppointment().Tables[0].Copy();
        }
        public DataTable GetModality() {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            
            return _proc.GetModality().Tables[0].Copy();
        }
        public DataTable GetSessionCount() {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            return _proc.GetSessionCount().Tables[0].Copy();
        }
        public DataTable GetByHN() {
            RISScheduleSelectData _proc = new RISScheduleSelectData();
            _proc.RISSchedule = RISSchedule;
            return _proc.GetByHN().Tables[0].Copy();
        
        }
	}
}

