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
	public class ProcessGetRISSchedulelog : IBusinessLogic
	{
        public RIS_SCHEDULE_LOG RIS_SCHEDULE_LOG { get; set; }
		private DataSet result;

        public ProcessGetRISSchedulelog()
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
			RISSchedulelogSelectData _proc=new RISSchedulelogSelectData();
            _proc.RIS_SCHEDULE_LOG = this.RIS_SCHEDULE_LOG;
			result=_proc.GetData();
		}
	}
}

