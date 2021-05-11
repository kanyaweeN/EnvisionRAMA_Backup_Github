using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISInsurancetype : IBusinessLogic
	{
		private DataSet result;
		public ProcessGetRISInsurancetype()
		{
			
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISInsurancetypeSelectData _proc=new RISInsurancetypeSelectData();
			result=_proc.GetData();
		}
	}
}

