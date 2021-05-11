using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSchedule : IBusinessLogic
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISSchedule()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
        }
        public void Invoke()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateSchedule();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
    }
}
