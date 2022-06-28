using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteFINPaymentdtl : IBusinessLogic
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteFINPaymentdtl()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
            Transaction = null;
		}
		
		public void Invoke()
		{
            FIN_PAYMENTDTLDeleteData _proc = new FIN_PAYMENTDTLDeleteData();
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

