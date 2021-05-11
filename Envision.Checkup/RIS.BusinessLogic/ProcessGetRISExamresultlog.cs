//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    04/06/2009 10:15:35
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
	public class ProcessGetRISExamresultlog : IBusinessLogic
	{
		private DataSet result;
		private RISExamresultlog _risexamresultlog;
		public ProcessGetRISExamresultlog()
		{
			_risexamresultlog = new  RISExamresultlog();
		}
		public RISExamresultlog RISExamresultlog
		{
			get{return _risexamresultlog;}
			set{_risexamresultlog=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlogSelectData _proc=new RISExamresultlogSelectData();
			_proc.RISExamresultlog=this.RISExamresultlog;
			result=_proc.GetData();
		}
	}
}

