using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVRequisition : IBusinessLogic
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVRequisition()
		{
            INV_REQUISITION = new INV_REQUISITION();
            Transaction = null;
		}
        public ProcessUpdateINVRequisition(DbTransaction tran)
        {
            INV_REQUISITION = new INV_REQUISITION();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVRequisitionUpdateData _proc=new INVRequisitionUpdateData();
            _proc.INV_REQUISITION = this.INV_REQUISITION;
            if (Transaction == null)
            {
                _proc.Update();
            }
            else
            {
                _proc.Update(Transaction);
            }
		}
	}
}

