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

