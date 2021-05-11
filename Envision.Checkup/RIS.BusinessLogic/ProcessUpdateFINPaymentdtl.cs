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
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateFINPaymentdtl : IBusinessLogic
	{
		private FINPaymentdtl _finpaymentdtl;
		private bool useTran;
		public ProcessUpdateFINPaymentdtl()
		{
			_finpaymentdtl = new FINPaymentdtl();
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
			FINPaymentdtlUpdateData _proc=new FINPaymentdtlUpdateData();
			_proc.FINPaymentdtl=this.FINPaymentdtl;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

