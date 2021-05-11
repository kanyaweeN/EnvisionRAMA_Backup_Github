using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVPodtl : IBusinessLogic
	{
		private DataSet result;
		private INVPodtl _invpodtl;
		public ProcessGetINVPodtl()
		{
			_invpodtl = new  INVPodtl();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPodtlSelectData _proc=new INVPodtlSelectData();
			result=_proc.GetData();
		}
	}
}

