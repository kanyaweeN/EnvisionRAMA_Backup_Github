using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVRequisitiondtl : IBusinessLogic
	{
		private DataSet result;
		private INVRequisitiondtl _invrequisitiondtl;
		public ProcessGetINVRequisitiondtl()
		{
			_invrequisitiondtl = new  INVRequisitiondtl();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVRequisitiondtlSelectData _proc=new INVRequisitiondtlSelectData();
			result=_proc.GetData();
		}
	}
}

