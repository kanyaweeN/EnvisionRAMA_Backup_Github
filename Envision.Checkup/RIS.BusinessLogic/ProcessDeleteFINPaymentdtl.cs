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
	public class ProcessDeleteFINPaymentdtl : IBusinessLogic
	{
		private FINPaymentdtl _finpaymentdtl;
		private bool useTran;
		public ProcessDeleteFINPaymentdtl()
		{
			_finpaymentdtl = new  FINPaymentdtl();
			useTran=false;
		}
		public FINPaymentdtl FINPaymentdtl		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			FINPaymentdtlDeleteData _proc=new FINPaymentdtlDeleteData();
			_proc.FINPaymentdtl=this.FINPaymentdtl;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

