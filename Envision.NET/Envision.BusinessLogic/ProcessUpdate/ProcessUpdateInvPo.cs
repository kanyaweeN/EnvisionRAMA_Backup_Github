using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVPo : IBusinessLogic
	{
        public INV_PO INV_PO { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessUpdateINVPo()
		{
            INV_PO = new INV_PO();
            Transaction = null;
		}
        public ProcessUpdateINVPo(DbTransaction tran)
        {
            INV_PO = new INV_PO();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPoUpdateData _proc=new INVPoUpdateData();
            _proc.INV_PO = this.INV_PO;
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

