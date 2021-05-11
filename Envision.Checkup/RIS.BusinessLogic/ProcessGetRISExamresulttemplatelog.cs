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
	public class ProcessGetRISExamresulttemplatelog : IBusinessLogic
	{
		private DataSet result;
		private RISExamresulttemplatelog _risexamresulttemplatelog;
		public ProcessGetRISExamresulttemplatelog()
		{
			_risexamresulttemplatelog = new  RISExamresulttemplatelog();
		}
		public RISExamresulttemplatelog RISExamresulttemplatelog
		{
			get{return _risexamresulttemplatelog;}
			set{_risexamresulttemplatelog=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresulttemplatelogSelectData _proc=new RISExamresulttemplatelogSelectData();
			_proc.RISExamresulttemplatelog=this.RISExamresulttemplatelog;
			result=_proc.GetData();
		}
	}
}

