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

