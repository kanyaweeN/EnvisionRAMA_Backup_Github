using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISScheduleLogs: IBusinessLogic
	{
        public RIS_SCHEDULELOGS RIS_SCHEDULELOGS { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessAddRISScheduleLogs()
		{
            RIS_SCHEDULELOGS = new RIS_SCHEDULELOGS();
            Transaction = null;
		}
		public void Invoke()
		{
            RISScheduleLogsInsertData _proc = new RISScheduleLogsInsertData();
            _proc.RIS_SCHEDULELOGS = this.RIS_SCHEDULELOGS;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
        public void InvokeCNMI()
        {
            RISScheduleLogsInsertData _proc = new RISScheduleLogsInsertData();
            _proc.RIS_SCHEDULELOGS = this.RIS_SCHEDULELOGS;
            if (Transaction == null)
                _proc.AddCNMI();
            else
                _proc.AddCNMI(Transaction);
        }
	}
}