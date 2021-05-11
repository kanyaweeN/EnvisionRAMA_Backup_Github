using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISScheduleDefaultModality : IBusinessLogic
    {
        public RIS_SCHEDULEDEFAULTMODALITY RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        public ProcessAddRISScheduleDefaultModality() {
            RIS_SCHEDULEDEFAULTMODALITY = new RIS_SCHEDULEDEFAULTMODALITY();
        }
        public void Invoke()
        {
            RISScheduleDefaultModalityInsertData proc = new RISScheduleDefaultModalityInsertData();
            proc.RIS_SCHEDULEDEFAULTMODALITY = RIS_SCHEDULEDEFAULTMODALITY;
            proc.Add();
        }

    }
}
