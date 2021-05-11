using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISModalitytype : IBusinessLogic
	{
		private DataSet result;
		public ProcessGetRISModalitytype(){}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISModalitytypeSelectData _proc=new RISModalitytypeSelectData();
			result=_proc.GetData();
		}
	}
}

