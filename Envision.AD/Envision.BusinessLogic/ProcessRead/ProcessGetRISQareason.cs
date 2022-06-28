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
	public class ProcessGetRISQareason : IBusinessLogic
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }
		private DataSet result;

		public ProcessGetRISQareason()
		{
            RIS_QAREASON = new RIS_QAREASON();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISQareasonSelectData _proc=new RISQareasonSelectData();
            _proc.RIS_QAREASON = this.RIS_QAREASON;
			result=_proc.GetData();
		}
	}
}

