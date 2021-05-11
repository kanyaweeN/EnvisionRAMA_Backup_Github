using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetHISDepartment : IBusinessLogic
	{
		private DataSet result;
        HISDepartment _hisdepartment;
		public ProcessGetHISDepartment()
		{
			_hisdepartment = new  HISDepartment();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			HISDepartmentSelectData _proc=new HISDepartmentSelectData();
			result=_proc.GetData();
		}
	}
}

