using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateFINPaymentdtl : IBusinessLogic
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateFINPaymentdtl()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
            Transaction = null;
		}
		public void Invoke()
		{
			FINPaymentdtlUpdateData _proc=new FINPaymentdtlUpdateData();
            _proc.FIN_PAYMENTDTL = this.FIN_PAYMENTDTL;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

