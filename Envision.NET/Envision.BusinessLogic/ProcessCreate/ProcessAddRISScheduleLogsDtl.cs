using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISScheduleLogsDtl: IBusinessLogic
	{
        public RIS_SCHEDULELOGSDTL RIS_SCHEDULELOGSDTL { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddRISScheduleLogsDtl()
		{
            RIS_SCHEDULELOGSDTL = new RIS_SCHEDULELOGSDTL();
            Transaction = null;
		}
		public void Invoke()
		{
            RISScheduleLogsDtlInsertData _proc = new RISScheduleLogsDtlInsertData();
            _proc.RIS_SCHEDULELOGSDTL = this.RIS_SCHEDULELOGSDTL;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}