using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetHRUnit : IBusinessLogic
	{
		private DataSet result;
		public ProcessGetHRUnit()
		{
			
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HRUnitSelectData _proc=new HRUnitSelectData();
			result=_proc.GetData();
		}
	}
}

