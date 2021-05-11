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
	public class ProcessGetRISExamresultlegacy : IBusinessLogic
	{
		private DataSet result;
        public RIS_EXAMRESULTLEGACY RIS_EXAMRESULTLEGACY { get; set; }

		public ProcessGetRISExamresultlegacy()
		{
            RIS_EXAMRESULTLEGACY = new RIS_EXAMRESULTLEGACY();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamresultlegacySelectData _proc=new RISExamresultlegacySelectData();
            _proc.RIS_EXAMRESULTLEGACY = this.RIS_EXAMRESULTLEGACY;
			result=_proc.GetData();
		}
	}
}

