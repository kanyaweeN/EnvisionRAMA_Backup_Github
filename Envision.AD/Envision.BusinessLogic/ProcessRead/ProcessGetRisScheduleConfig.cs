using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRisScheduleConfig : IBusinessLogic
    {
        public RIS_SCHEDULECONFIG RIS_SCHEDULECONFIG { get; set; }
        public DataTable Result { get; set; }

        public ProcessGetRisScheduleConfig() {
            RIS_SCHEDULECONFIG = new RIS_SCHEDULECONFIG();
            Result = null;
        }

        public void  Invoke()
        {
            RISScheduleConfig proc = new RISScheduleConfig();
            Result= proc.GetData();
        }

    }
}
