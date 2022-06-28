using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVPrdtl : IBusinessLogic
	{
        public INV_PRDTL INV_PRDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVPrdtl()
        {
            INV_PRDTL = new INV_PRDTL();
            Transaction = null;
		}
        public ProcessUpdateINVPrdtl(DbTransaction tran)
		{
            INV_PRDTL = new INV_PRDTL();
            Transaction = tran;
		}
		public void Invoke()
		{
			INVPrdtlUpdateData _proc=new INVPrdtlUpdateData();
            _proc.INV_PRDTL = this.INV_PRDTL;
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

