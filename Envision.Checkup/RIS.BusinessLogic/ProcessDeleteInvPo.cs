using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVPo : IBusinessLogic
	{
		private INVPo _invpo;
		public ProcessDeleteINVPo()
		{
			_invpo = new  INVPo();
		}
		public INVPo INVPo		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public void Invoke()
		{
			INVPoDeleteData _proc=new INVPoDeleteData();
			_proc.INVPo=this.INVPo;
			_proc.Delete();
		}
	}
}

