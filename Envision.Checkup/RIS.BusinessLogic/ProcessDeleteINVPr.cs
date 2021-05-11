using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVPr : IBusinessLogic
	{
		private INVPr _invpr;
		public ProcessDeleteINVPr()
		{
			_invpr = new  INVPr();
		}
		public INVPr INVPr		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public void Invoke()
		{
			INVPrDeleteData _proc=new INVPrDeleteData();
			_proc.INVPr=this.INVPr;
			_proc.Delete();
		}
	}
}

