using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISSchedule : IBusinessLogic
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISSchedule()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
        }
        public void Invoke()
        {
            RIS_SCHEDULEDeleteData _proc = new RIS_SCHEDULEDeleteData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.Delete();
        }
    }
}
