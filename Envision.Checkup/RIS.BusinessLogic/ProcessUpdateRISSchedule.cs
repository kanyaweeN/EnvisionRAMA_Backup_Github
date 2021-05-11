using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISSchedule : IBusinessLogic
    {
        private RISSchedule _risschedule;
        //private int scheduleID;
        private SqlTransaction tran;

        public ProcessUpdateRISSchedule()
        {
            tran = null;
            _risschedule = new RISSchedule();
            _risschedule.SCHEDULE_ID = 0;
        }
        public ProcessUpdateRISSchedule(int schedule_ID)
        {
            tran = null;
            _risschedule = new RISSchedule();
            _risschedule.SCHEDULE_ID = schedule_ID;
        }

        public RISSchedule RISSchedule
        {
            get { return _risschedule; }
            set { _risschedule = value; }
        }
        public void Invoke()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            if (tran == null)
            {
                if (_risschedule.SCHEDULE_ID > 0)
                    _proc = new RISScheduleUpdateData(_risschedule);
                _proc.RISSchedule = this.RISSchedule;
                _proc.Update();
            }
            else
            {
                if (_risschedule.SCHEDULE_ID > 0)
                    _proc = new RISScheduleUpdateData(_risschedule);
                _proc.RISSchedule = this.RISSchedule;
                _proc.Update(tran);
            }
        }
        public SqlTransaction UseTransaction
        {
            set
            {
                tran = value;
            }
        }

        public void Update() {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RISSchedule = RISSchedule;
            _proc.UpdateSchedule();
            RISSchedule.SCHEDULE_ID = _proc.RISSchedule.SCHEDULE_ID;
        }
        public void UpdateBlock()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RISSchedule = RISSchedule;
            _proc.UpdateScheduleBlock();
            RISSchedule.SCHEDULE_ID = _proc.RISSchedule.SCHEDULE_ID;
        }
        public void UpdateBlockTimer()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RISSchedule = RISSchedule;
            _proc.UpdateScheduleTimer();
        }
    }
}
