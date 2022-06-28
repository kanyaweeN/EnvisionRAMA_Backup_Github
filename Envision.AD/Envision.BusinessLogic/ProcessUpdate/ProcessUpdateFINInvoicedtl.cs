using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateFINInvoicedtl : IBusinessLogic
	{
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessUpdateFINInvoicedtl()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
            Transaction = null;
		}
		public void Invoke()
		{
			FINInvoicedtlUpdateData _proc=new FINInvoicedtlUpdateData();
            _proc.FIN_INVOICEDTL = this.FIN_INVOICEDTL;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

