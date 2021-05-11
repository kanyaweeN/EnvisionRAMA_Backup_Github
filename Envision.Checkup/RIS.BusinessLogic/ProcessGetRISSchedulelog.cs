//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:36:03
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
	public class ProcessGetRISSchedulelog : IBusinessLogic
	{
		private DataSet result;
		private RISSchedulelog _risschedulelog;
		public ProcessGetRISSchedulelog()
		{
			_risschedulelog = new  RISSchedulelog();
		}
		public RISSchedulelog RISSchedulelog
		{
			get{return _risschedulelog;}
			set{_risschedulelog=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISSchedulelogSelectData _proc=new RISSchedulelogSelectData();
			_proc.RISSchedulelog=this.RISSchedulelog;
			result=_proc.GetData();
		}
	}
}

