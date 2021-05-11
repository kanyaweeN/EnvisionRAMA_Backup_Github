using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISScheduleDefaultDestination : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }
        public ProcessGetRISScheduleDefaultDestination() {
            Result = null;
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();
        }

        public void Invoke()
        {
            RISSchedulePatientDestinationSelectData proc = new RISSchedulePatientDestinationSelectData();
            proc.RIS_SCHEDULEDEFAULTDESTINATION = RIS_SCHEDULEDEFAULTDESTINATION;
            Result = new DataSet();
            Result = proc.GetDestinationData();

        }

       
    }
}
