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
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISSchedule : IBusinessLogic
	{
		private RISSchedule _risschedule;
		private bool useTran;
		public ProcessDeleteRISSchedule()
		{
			_risschedule = new  RISSchedule();
			useTran=false;
		}
		public RISSchedule RISSchedule		{
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
			RISScheduleDeleteData _proc=new RISScheduleDeleteData();
			_proc.RISSchedule=this.RISSchedule;
			_proc.Delete();
		}
	}
}

