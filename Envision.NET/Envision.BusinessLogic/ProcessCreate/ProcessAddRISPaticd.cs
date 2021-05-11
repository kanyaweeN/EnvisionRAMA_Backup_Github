using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISPaticd : IBusinessLogic
	{
        public RIS_PATICD RIS_PATICD { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISPaticd()
		{
            RIS_PATICD = new RIS_PATICD();
            Transaction = null;
		}
		public void Invoke()
		{
			RISPaticdInsertData _proc=new RISPaticdInsertData();
            _proc.RIS_PATICD = this.RIS_PATICD;
            if (Transaction == null)
                _proc.Add();
            else
                RIS_PATICD.PAT_ICD_ID = _proc.Add(Transaction);
		}
	}
}

