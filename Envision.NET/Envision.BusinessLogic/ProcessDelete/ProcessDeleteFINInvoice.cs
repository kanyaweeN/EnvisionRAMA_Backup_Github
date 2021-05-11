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
	public class ProcessDeleteFINInvoice : IBusinessLogic
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteFINInvoice()
		{
            FIN_INVOICE = new FIN_INVOICE();
            Transaction = null;
		}
		public void Invoke()
		{
            FIN_INVOICEDeleteData _proc = new FIN_INVOICEDeleteData();
            _proc.FIN_INVOICE = FIN_INVOICE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

