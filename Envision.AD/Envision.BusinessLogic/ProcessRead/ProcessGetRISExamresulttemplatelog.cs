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
	public class ProcessGetRISExamresulttemplatelog : IBusinessLogic
	{
        public RIS_EXAMRESULTTEMPLATELOG RIS_EXAMRESULTTEMPLATELOG { get; set; }
		private DataSet result;

		public ProcessGetRISExamresulttemplatelog()
		{
            RIS_EXAMRESULTTEMPLATELOG = new RIS_EXAMRESULTTEMPLATELOG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresulttemplatelogSelectData _proc=new RISExamresulttemplatelogSelectData();
            _proc.RIS_EXAMRESULTTEMPLATELOG = this.RIS_EXAMRESULTTEMPLATELOG;
			result=_proc.GetData();
		}
	}
}

