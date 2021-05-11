//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddFINPayment : IBusinessLogic
	{
		private FINPayment _finpayment;
		private bool useTran;
		public ProcessAddFINPayment()
		{
			_finpayment = new  FINPayment();
			useTran=false;
		}
		public FINPayment FINPayment
		{
			get{return _finpayment;}
			set{_finpayment=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			FINPaymentInsertData _proc=new FINPaymentInsertData();
			_proc.FINPayment=this.FINPayment;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

