using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISPaticd : IBusinessLogic
	{
        public RIS_PATICD RIS_PATICD { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISPaticd()
		{
            RIS_PATICD = new RIS_PATICD();
            Transaction = null;
		}
		public void Invoke()
		{
			RISPaticdUpdateData _proc=new RISPaticdUpdateData();
            _proc.RIS_PATICD = this.RIS_PATICD;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}

	}
}

