using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
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

