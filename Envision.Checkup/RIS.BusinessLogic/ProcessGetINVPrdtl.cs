using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVPrdtl : IBusinessLogic
	{
		private DataSet result;
		private INVPrdtl _invprdtl;
		public ProcessGetINVPrdtl()
		{
			_invprdtl = new  INVPrdtl();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPrdtlSelectData _proc=new INVPrdtlSelectData();
			result=_proc.GetData();
		}
	}
}

