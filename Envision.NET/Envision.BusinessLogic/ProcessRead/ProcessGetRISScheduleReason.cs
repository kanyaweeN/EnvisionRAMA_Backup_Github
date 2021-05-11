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
    public class ProcessGetRISScheduleReason : IBusinessLogic
    {
        public RIS_SCHEDULE_LOG RIS_SCHEDULE_LOG { get; set; }
        private DataSet result;

        public ProcessGetRISScheduleReason()
		{
            RIS_SCHEDULE_LOG = new RIS_SCHEDULE_LOG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISScheduleReasonSelectData _proc = new RISScheduleReasonSelectData();
            _proc.RIS_SCHEDULE_LOG = this.RIS_SCHEDULE_LOG;
			result=_proc.GetData();
		}
    }
}
