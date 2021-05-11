using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVTransaction : IBusinessLogic
	{
		private INVTransaction _invtransaction;
		public ProcessAddINVTransaction()
		{
			_invtransaction = new  INVTransaction();
		}
		public INVTransaction INVTransaction		{
			get{return _invtransaction;}
			set{_invtransaction=value;}
		}
		public void Invoke()
		{
			INVTransactionInsertData _proc=new INVTransactionInsertData();
			_proc.INVTransaction=this.INVTransaction;
			_proc.Add();
		}
	}
}

