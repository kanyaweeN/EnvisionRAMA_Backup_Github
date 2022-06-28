using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateFINInvoice : IBusinessLogic
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateFINInvoice()
		{
            FIN_INVOICE = new FIN_INVOICE();
            Transaction = null;
		}
		public void Invoke()
		{
			FINInvoiceUpdateData _proc=new FINInvoiceUpdateData();
            _proc.FIN_INVOICE = this.FIN_INVOICE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

