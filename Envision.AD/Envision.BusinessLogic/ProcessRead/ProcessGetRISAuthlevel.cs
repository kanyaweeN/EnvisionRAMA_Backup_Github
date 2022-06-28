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
	public class ProcessGetRISAuthlevel : IBusinessLogic
	{
		private DataSet result;
		public ProcessGetRISAuthlevel()
		{
		
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISAuthlevelSelectData _proc=new RISAuthlevelSelectData();
			result=_proc.GetData();
		}
	}
}

