//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:56
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
	public class ProcessGetRISExamlog : IBusinessLogic
	{
		private DataSet result;
		private RISExamlog _risexamlog;
		public ProcessGetRISExamlog()
		{
			_risexamlog = new  RISExamlog();
		}
		public RISExamlog RISExamlog
		{
			get{return _risexamlog;}
			set{_risexamlog=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamlogSelectData _proc=new RISExamlogSelectData();
			_proc.RISExamlog=this.RISExamlog;
			result=_proc.GetData();
		}
	}
}

