using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateFINPayment : IBusinessLogic
	{
        public FIN_PAYMENT FIN_PAYMENT { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateFINPayment()
        {
            FIN_PAYMENT = new FIN_PAYMENT();
            Transaction = null;
		}
		public void Invoke()
		{
			FINPaymentUpdateData _proc=new FINPaymentUpdateData();
            _proc.FIN_PAYMENT = this.FIN_PAYMENT;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

