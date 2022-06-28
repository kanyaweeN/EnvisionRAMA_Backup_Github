using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLEmpSchedule : IBusinessLogic
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }

        public ProcessDeleteGBLEmpSchedule() {
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
        }
        public void Invoke()
        {
            GBLEmpScheduleDeleteData proc = new GBLEmpScheduleDeleteData();
            proc.GBL_EMPSCHEDULE = GBL_EMPSCHEDULE;
            proc.Delete();
        }
    }
}
