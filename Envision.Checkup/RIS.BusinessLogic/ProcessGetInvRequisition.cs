using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetINVRequisition : IBusinessLogic
	{
		private DataSet result;
		private INVRequisition _invrequisition;
		public ProcessGetINVRequisition()
		{
			_invrequisition = new  INVRequisition();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVRequisitionSelectData _proc=new INVRequisitionSelectData();
			result=_proc.GetData();
		}
        public void Invoke222()
        {
            InvItemSelectData _proc = new InvItemSelectData();
            result = _proc.Query();
        }
	}
}

