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
	public class ProcessGetRISExamlog : IBusinessLogic
	{
        public RIS_EXAMLOG RIS_EXAMLOG { get; set; }
		private DataSet result;

		public ProcessGetRISExamlog()
		{
            RIS_EXAMLOG = new RIS_EXAMLOG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamlogSelectData _proc=new RISExamlogSelectData();
            _proc.RIS_EXAMLOG = this.RIS_EXAMLOG;
			result=_proc.GetData();
		}
	}
}

