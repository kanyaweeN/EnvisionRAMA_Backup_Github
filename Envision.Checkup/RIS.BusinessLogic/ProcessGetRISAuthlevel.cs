using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
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

