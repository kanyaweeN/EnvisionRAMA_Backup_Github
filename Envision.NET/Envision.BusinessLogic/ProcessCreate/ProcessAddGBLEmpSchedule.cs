using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLEmpSchedule : IBusinessLogic
    {
        public GBL_EMPSCHEDULE GBL_EMPSCHEDULE { get; set; }
        public ProcessAddGBLEmpSchedule() {
            GBL_EMPSCHEDULE = new GBL_EMPSCHEDULE();
        }
        public void Invoke()
        {
            GBLEmpScheduleInsertData proc = new GBLEmpScheduleInsertData();
            proc.GBL_EMPSCHEDULE = GBL_EMPSCHEDULE;
            proc.Add();
            proc.GBL_EMPSCHEDULE.SCHEDULE_ID = GBL_EMPSCHEDULE.SCHEDULE_ID;
        }
    }
}
