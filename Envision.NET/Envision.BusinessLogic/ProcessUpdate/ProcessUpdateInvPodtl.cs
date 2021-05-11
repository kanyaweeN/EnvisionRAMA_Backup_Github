using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVPodtl : IBusinessLogic
	{
        public INV_PODTL INV_PODTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVPodtl()
		{
            INV_PODTL = new INV_PODTL();
            Transaction = null;
		}
        public ProcessUpdateINVPodtl(DbTransaction tran)
		{
            INV_PODTL = new INV_PODTL();
            Transaction = tran;
		}
		public void Invoke()
		{
			INVPodtlUpdateData _proc=new INVPodtlUpdateData();
            _proc.INV_PODTL = this.INV_PODTL;
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

