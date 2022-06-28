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
	public class ProcessDeleteFINInvoicedtl : IBusinessLogic
	{
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteFINInvoicedtl()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
            Transaction = null;
		}
		public void Invoke()
		{
            FIN_INVOICEDTLDeleteData _proc = new FIN_INVOICEDTLDeleteData();
            _proc.FIN_INVOICEDTL = FIN_INVOICEDTL;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

