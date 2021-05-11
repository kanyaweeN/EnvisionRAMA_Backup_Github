using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVTransactiondtl : IBusinessLogic
	{
        public INV_TRANSACTIONDTL INV_TRANSACTIONDTL { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddINVTransactiondtl()
        {
            INV_TRANSACTIONDTL = new INV_TRANSACTIONDTL();
            Transaction = null;
        }
		public void Invoke()
		{
            INVTransactiondtlInsertData _proc = new INVTransactiondtlInsertData();
            _proc.INV_TRANSACTIONDTL = this.INV_TRANSACTIONDTL;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

