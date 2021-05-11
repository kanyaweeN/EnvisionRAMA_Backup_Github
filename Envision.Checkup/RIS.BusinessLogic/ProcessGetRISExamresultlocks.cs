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
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExamresultlocks : IBusinessLogic
	{
		private DataSet result;
		private RISExamresultlocks _risexamresultlocks;
		public ProcessGetRISExamresultlocks()
		{
			_risexamresultlocks = new  RISExamresultlocks();
		}
		public RISExamresultlocks RISExamresultlocks
		{
			get{return _risexamresultlocks;}
			set{_risexamresultlocks=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlocksSelectData _proc=new RISExamresultlocksSelectData();
			_proc.RISExamresultlocks=this.RISExamresultlocks;
			result=_proc.GetData();
		}
        public void Invoke_DateRange()
        {
            RISExamresultlocksSelectData _proc = new RISExamresultlocksSelectData();
            _proc.RISExamresultlocks = this.RISExamresultlocks;
            result = _proc.GetData_DateRange();
        }
	}
}

