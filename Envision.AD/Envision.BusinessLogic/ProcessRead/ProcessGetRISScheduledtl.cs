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
    public class ProcessGetRISScheduledtl : IBusinessLogic
    {
        private DataSet result;
        private DateTime dtFrom, dtTo;
        private int scheduleID;
        private int Case;

        public ProcessGetRISScheduledtl(DateTime dtFrom, DateTime dtTo,int SCHEDULE_ID)
        {
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            this.scheduleID = SCHEDULE_ID;
            this.Case = 0;
        }
        public ProcessGetRISScheduledtl(int scheduleID)
        {
            this.Case = scheduleID;
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
            if (Case == 0)
                _proc = new RISScheduledtlSelectData(dtFrom, dtTo,scheduleID);
            else
                _proc = new RISScheduledtlSelectData(scheduleID);
            result = _proc.GetData();
        }
    }
}
