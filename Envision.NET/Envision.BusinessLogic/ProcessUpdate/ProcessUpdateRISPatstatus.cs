using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISPatstatus : IBusinessLogic
	{
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }

		public ProcessUpdateRISPatstatus()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
		}
		public void Invoke()
		{
            RISPatstatusUpdateData _proc = new RISPatstatusUpdateData();
            _proc.RIS_PATSTATUS = this.RIS_PATSTATUS;
            _proc.Update();
		}
	}
}

