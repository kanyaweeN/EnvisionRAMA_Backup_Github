//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/02/2552 09:05:20
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISSchedule : IBusinessLogic
	{
		private RISSchedule _risschedule;
		private bool useTran;
		public ProcessAddRISSchedule()
		{
			_risschedule = new  RISSchedule();
			useTran=false;
		}
		public RISSchedule RISSchedule
		{
			get{return _risschedule;}
			set{_risschedule=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISScheduleInsertData _proc=new RISScheduleInsertData();
			_proc.RISSchedule=this.RISSchedule;
			_proc.Add();
            _risschedule.SCHEDULE_ID = _proc.RISSchedule.SCHEDULE_ID;
		}
        public void InvokeBlock() {
            RISScheduleInsertData _proc = new RISScheduleInsertData();
            _proc.RISSchedule = this.RISSchedule;
            _proc.AddBlock();
            _risschedule.SCHEDULE_ID = _proc.RISSchedule.SCHEDULE_ID;
        }
	}
}

