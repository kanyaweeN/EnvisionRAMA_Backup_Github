using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVRequisition : IBusinessLogic
	{
		private INVRequisition _invrequisition;
		public ProcessDeleteINVRequisition()
		{
			_invrequisition = new  INVRequisition();
		}
		public INVRequisition INVRequisition		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Invoke()
		{
			INVRequisitionDeleteData _proc=new INVRequisitionDeleteData();
			_proc.INVRequisition=this.INVRequisition;
			_proc.Delete();
		}
	}
}

