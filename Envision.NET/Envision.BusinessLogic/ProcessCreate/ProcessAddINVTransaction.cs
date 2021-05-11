using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVTransaction : IBusinessLogic
	{
        public INV_TRANSACTION INV_TRANSACTION { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddINVTransaction()
        {
            INV_TRANSACTION = new INV_TRANSACTION();
            Transaction = null;
        }
		public void Invoke()
		{
			INVTransactionInsertData _proc=new INVTransactionInsertData();
            _proc.INV_TRANSACTION = this.INV_TRANSACTION;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
        public bool InvokePOCancel(int PO_ID, int CreatedBy)
        {
            INVTransactionInsertData _proc = new INVTransactionInsertData();
            _proc.INV_TRANSACTION = this.INV_TRANSACTION;
            return _proc.AddPOCancel(PO_ID, CreatedBy);
        }
        public bool InvokeRQCancel(int REQUISITION_ID, int CreatedBy)
        {
            INVTransactionInsertData _proc = new INVTransactionInsertData();
            _proc.INV_TRANSACTION = this.INV_TRANSACTION;
            return _proc.AddRQCancel(REQUISITION_ID, CreatedBy);
        }
	}
}

