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
	public class ProcessGetRISExamresultlog : IBusinessLogic
	{
        public RIS_EXAMRESULTLOG RIS_EXAMRESULTLOG { get; set; }
		private DataSet result;

		public ProcessGetRISExamresultlog()
		{
            RIS_EXAMRESULTLOG = new RIS_EXAMRESULTLOG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlogSelectData _proc=new RISExamresultlogSelectData();
            _proc.RIS_EXAMRESULTLOG = this.RIS_EXAMRESULTLOG;
			result=_proc.GetData();
		}
	}
}

