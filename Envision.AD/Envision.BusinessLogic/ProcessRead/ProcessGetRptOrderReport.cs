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
    public class ProcessGetRptOrderReport : IBusinessLogic
    {
		private DataSet result;
		private ReportParameters _reportparameter;
        public ProcessGetRptOrderReport()
		{
			_reportparameter = new  ReportParameters();
		}
		public ReportParameters ReportParameters
		{
			get{return _reportparameter;}
			set{_reportparameter=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			OrderReportSelectData _proc=new OrderReportSelectData();
			_proc.ReportParameters=this.ReportParameters;
			result=_proc.GetData();
		}
    }
}
