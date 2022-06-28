using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRptScheduleCountAppoint
    {
        public ReportParameters ReportParameters { get; set; }
		private DataSet result;

        public ProcessGetRptScheduleCountAppoint()
		{
            ReportParameters = new ReportParameters();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISxrptScheduleCountAppoint _proc = new RISxrptScheduleCountAppoint();
            _proc.ReportParameters = this.ReportParameters;
			result=_proc.GetData();
		}
        public void InvokeWithSession()
        {
            RISxrptScheduleCountAppoint _proc = new RISxrptScheduleCountAppoint();
            _proc.ReportParameters = this.ReportParameters;
            result = _proc.GetDataWithSession();
        }
    }
}
