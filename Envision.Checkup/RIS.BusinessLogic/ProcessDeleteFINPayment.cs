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
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteFINPayment : IBusinessLogic
	{
		private FINPayment _finpayment;
		private bool useTran;
		public ProcessDeleteFINPayment()
		{
			_finpayment = new  FINPayment();
			useTran=false;
		}
		public FINPayment FINPayment		{
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
			FINPaymentDeleteData _proc=new FINPaymentDeleteData();
			_proc.FINPayment=this.FINPayment;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

