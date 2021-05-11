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
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic
{
	public class ProcessUpdateFINPaymentdtl_UpdateStatus : IBusinessLogic
	{
        private FIN_PAYMENTDTL _finpaymentdtl;
		private bool useTran;
        public ProcessUpdateFINPaymentdtl_UpdateStatus()
		{
			_finpaymentdtl = new FIN_PAYMENTDTL();
			useTran=false;
		}
        public FIN_PAYMENTDTL FIN_PAYMENTDTL		
        {
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
            FINPaymentdtlUpdateData_UpdateStatus _proc = new FINPaymentdtlUpdateData_UpdateStatus();
            _proc.FIN_PAYMENTDTL = this.FIN_PAYMENTDTL;
			_proc.Update();
		}
	}
}

