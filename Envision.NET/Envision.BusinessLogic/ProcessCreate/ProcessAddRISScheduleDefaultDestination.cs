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
    public class ProcessAddRISScheduleDefaultDestination :IBusinessLogic
    {
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        public ProcessAddRISScheduleDefaultDestination() {
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();

        }
        public void Invoke()
        {
            RISSchedulePatientDestinationInsertData proc = new RISSchedulePatientDestinationInsertData();
            proc.RIS_SCHEDULEDEFAULTDESTINATION = RIS_SCHEDULEDEFAULTDESTINATION;
            proc.Add();
            RIS_SCHEDULEDEFAULTDESTINATION.SCH_DEF_DEST_ID = proc.RIS_SCHEDULEDEFAULTDESTINATION.SCH_DEF_DEST_ID;
        }
    }
}
