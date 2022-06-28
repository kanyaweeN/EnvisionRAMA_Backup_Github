using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISQareason : IBusinessLogic
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISQareason()
        {
            RIS_QAREASON = new RIS_QAREASON();
            Transaction = null;
		}
		public void Invoke()
		{
			RISQareasonUpdateData _proc=new RISQareasonUpdateData();
            _proc.RIS_QAREASON = this.RIS_QAREASON;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

