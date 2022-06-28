using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVRequisitiondtl : IBusinessLogic
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVRequisitiondtl()
        {
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = null;
		}
        public ProcessUpdateINVRequisitiondtl(DbTransaction tran)
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = tran;
		}
		public void Invoke()
		{
			INVRequisitiondtlUpdateData _proc=new INVRequisitiondtlUpdateData();
            _proc.INV_REQUISITIONDTL = this.INV_REQUISITIONDTL;
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

