//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/05/2552 03:39:05
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExamresultlocks : IBusinessLogic
	{
		private RISExamresultlocks _risexamresultlocks;
		private bool useTran;
		public ProcessUpdateRISExamresultlocks()
		{
			_risexamresultlocks = new RISExamresultlocks();
			useTran=false;
		}
		public RISExamresultlocks RISExamresultlocks		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISExamresultlocksUpdateData _proc=new RISExamresultlocksUpdateData();
			_proc.RISExamresultlocks=this.RISExamresultlocks;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

