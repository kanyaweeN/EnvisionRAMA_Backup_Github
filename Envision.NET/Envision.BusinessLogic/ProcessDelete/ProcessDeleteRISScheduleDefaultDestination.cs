using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISScheduleDefaultDestination : IBusinessLogic
    {
        public RIS_SCHEDULEDEFAULTDESTINATION RIS_SCHEDULEDEFAULTDESTINATION { get; set; }

        public ProcessDeleteRISScheduleDefaultDestination() {
            RIS_SCHEDULEDEFAULTDESTINATION = new RIS_SCHEDULEDEFAULTDESTINATION();
        }


        #region IBusinessLogic Members

        public void Invoke()
        {
            RISSchedulePatientDestinationDeleteData proc = new RISSchedulePatientDestinationDeleteData();
            proc.RIS_SCHEDULEDEFAULTDESTINATION = RIS_SCHEDULEDEFAULTDESTINATION;
            proc.Delete();
        }

        #endregion
    }
}
