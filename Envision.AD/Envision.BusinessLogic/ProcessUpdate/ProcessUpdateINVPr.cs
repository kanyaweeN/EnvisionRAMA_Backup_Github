using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVPr : IBusinessLogic
	{
        public INV_PR INV_PR { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVPr()
        {
            INV_PR = new INV_PR();
            Transaction = null;
		}
        public ProcessUpdateINVPr(DbTransaction tran)
        {
            INV_PR = new INV_PR();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVPrUpdateData _proc=new INVPrUpdateData();
            _proc.INV_PR = this.INV_PR;
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

