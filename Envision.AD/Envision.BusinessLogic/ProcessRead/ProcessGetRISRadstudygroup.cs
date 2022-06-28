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
	public class ProcessGetRISRadstudygroup : IBusinessLogic
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }
		private DataSet result;

		public ProcessGetRISRadstudygroup()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISRadstudygroupSelectData _proc=new RISRadstudygroupSelectData();
            _proc.RIS_RADSTUDYGROUP = this.RIS_RADSTUDYGROUP;
			result=_proc.GetData();
		}
	}
}

