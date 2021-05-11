using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
//using RIS.DataAccess.Select;

using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
    public class ProcessGetRISScheduledtl : IBusinessLogic
    {
        private DataSet result;
        private DateTime dtFrom, dtTo;
        private int scheduleID;

        public ProcessGetRISScheduledtl(DateTime dtFrom, DateTime dtTo)
        {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            this.scheduleID = 0;
        }
        public ProcessGetRISScheduledtl(int scheduleID)
        {
            this.scheduleID = scheduleID;
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISScheduledtlSelectData _proc;
            if (scheduleID == 0)
                _proc = new RISScheduledtlSelectData(dtFrom, dtTo);
            else
                _proc = new RISScheduledtlSelectData(scheduleID);
            result = _proc.GetData();
        }
    }
}
