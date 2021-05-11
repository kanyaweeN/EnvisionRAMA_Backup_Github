using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISScheduleLogs : IBusinessLogic
    {
        public RIS_SCHEDULELOGS RIS_SCHEDULELOGS { get; set; }
        public ProcessAddRISScheduleLogs()
        {
            RIS_SCHEDULELOGS = new RIS_SCHEDULELOGS();
        }
        public void Invoke()
        {
            RISScheduleLogsInsertData _proc = new RISScheduleLogsInsertData();
            _proc.RIS_SCHEDULELOGS = this.RIS_SCHEDULELOGS;
                _proc.Add();
        }
        public void InvokeCNMI()
        {
            RISScheduleLogsInsertData _proc = new RISScheduleLogsInsertData();
            _proc.RIS_SCHEDULELOGS = this.RIS_SCHEDULELOGS;
            _proc.AddCNMI();
        }
    }
}