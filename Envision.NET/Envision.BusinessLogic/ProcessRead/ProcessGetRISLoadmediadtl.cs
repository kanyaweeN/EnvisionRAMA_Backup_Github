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
	public class ProcessGetRISLoadmediadtl : IBusinessLogic
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
		private DataSet result;

		public ProcessGetRISLoadmediadtl()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISLoadmediadtlSelectData _proc=new RISLoadmediadtlSelectData();
            _proc.RIS_LOADMEDIADTL = this.RIS_LOADMEDIADTL;
			result=_proc.GetData();
		}
	}
}

