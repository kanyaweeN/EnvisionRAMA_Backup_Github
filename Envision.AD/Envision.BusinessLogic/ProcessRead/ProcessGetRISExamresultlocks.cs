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
	public class ProcessGetRISExamresultlocks : IBusinessLogic
	{
        public RIS_EXAMRESULTLOCK RIS_EXAMRESULTLOCK { get; set; }
		private DataSet result;

		public ProcessGetRISExamresultlocks()
		{
            RIS_EXAMRESULTLOCK = new RIS_EXAMRESULTLOCK();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlocksSelectData _proc=new RISExamresultlocksSelectData();
            _proc.RIS_EXAMRESULTLOCK = this.RIS_EXAMRESULTLOCK;
			result=_proc.GetData();
		}
        public void Invoke_DateRange()
        {
            RISExamresultlocksSelectData _proc = new RISExamresultlocksSelectData();
            _proc.RIS_EXAMRESULTLOCK = this.RIS_EXAMRESULTLOCK;
            result = _proc.GetData_DateRange();
        }
	}
}

