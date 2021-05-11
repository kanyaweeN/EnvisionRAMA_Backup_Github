//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/02/2552 09:05:20
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using System.Collections.Generic;
using System;

using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;
namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISSchedule : IBusinessLogic
	{
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISSchedule()
		{
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
		}
		public void Invoke()
		{
			RISScheduleInsertData _proc=new RISScheduleInsertData();
            _proc.RIS_SCHEDULE = this.RIS_SCHEDULE;
			_proc.Add();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
		}
        public void InvokeBlock() {
            RISScheduleInsertData _proc = new RISScheduleInsertData();
            _proc.RIS_SCHEDULE = this.RIS_SCHEDULE;
            _proc.AddBlock();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void InvokeRecurrence() {
            RISScheduleInsertData _proc = new RISScheduleInsertData();
            _proc.RIS_SCHEDULE = this.RIS_SCHEDULE;
            _proc.AddRecurrence();
            this.RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
	}
}

