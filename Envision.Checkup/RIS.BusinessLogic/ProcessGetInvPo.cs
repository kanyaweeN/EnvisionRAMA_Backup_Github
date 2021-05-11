using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVPo : IBusinessLogic
	{
		private DataSet result;
		private INVPo _invpo;
		public ProcessGetINVPo()
		{
			_invpo = new  INVPo();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPoSelectData _proc=new INVPoSelectData();
			result=_proc.GetData();
		}
	}
}

