using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISScheduleDefaultModality : IBusinessLogic
    {
        public RIS_SCHEDULEDEFAULTMODALITY RIS_SCHEDULEDEFAULTMODALITY { get; set; }

        public ProcessDeleteRISScheduleDefaultModality() {
            RIS_SCHEDULEDEFAULTMODALITY = new RIS_SCHEDULEDEFAULTMODALITY();
        }


        public void Invoke()
        {

        }

    }
}
