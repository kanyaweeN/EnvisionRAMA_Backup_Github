using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionInterface.DataAccess.Select;

namespace EnvisionInterface.BusinessLogic.ProcessRead
{
    public class ProcessGetAppointmentRama
    {
        private DataSet result;

        public ProcessGetAppointmentRama()
        {
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void getData(string hn)
        {
            RISRamaAppointmentSelectData _proc = new RISRamaAppointmentSelectData();
            result = _proc.GetData(hn);
        }
        public void getDataByScheduleID(int schedule_id)
        {
            RISRamaAppointmentSelectData _proc = new RISRamaAppointmentSelectData();
            result = _proc.GetDataByScheduleID(schedule_id);
        }
        public void getDataByXrayreqID(int xrayreq_id)
        {
            RISRamaAppointmentSelectData _proc = new RISRamaAppointmentSelectData();
            result = _proc.getDataByXrayreqID(xrayreq_id);
        }
    }
}
