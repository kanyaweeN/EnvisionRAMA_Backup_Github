using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateEmpSchedule : IBusinessLogic
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }

        public ProcessUpdateEmpSchedule() {
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
        }
        public void Invoke()
        {
            GBLEmpScheduleUpdate proc = new GBLEmpScheduleUpdate();
            proc.GBL_EMPSCHEDULE = this.GBL_EMPSCHEDULE;
            proc.Update();
        }

    }
}
