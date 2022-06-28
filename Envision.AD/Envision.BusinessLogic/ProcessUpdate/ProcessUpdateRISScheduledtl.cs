using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISScheduledtl : IBusinessLogic
    {
        public RIS_SCHEDULEDTL RIS_SCHEDULEDTL { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISScheduledtl()
		{
            RIS_SCHEDULEDTL = new RIS_SCHEDULEDTL();
            Transaction = null;
		}
		public void Invoke()
		{
            RISScheduleDtlUpdateData _proc = new RISScheduleDtlUpdateData();
            _proc.RIS_SCHEDULEDTL = this.RIS_SCHEDULEDTL;
			_proc.Update();
		}
        public void InvokeCNMI()
        {
            RISScheduleDtlUpdateData _proc = new RISScheduleDtlUpdateData();
            _proc.RIS_SCHEDULEDTL = this.RIS_SCHEDULEDTL;
            _proc.UpdateCNMI();
        }
    }
}
