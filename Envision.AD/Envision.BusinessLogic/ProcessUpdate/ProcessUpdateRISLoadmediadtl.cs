using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISLoadmediadtl : IBusinessLogic
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISLoadmediadtl()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
            Transaction = null;
		}
		public void Invoke()
		{
			RISLoadmediadtlUpdateData _proc=new RISLoadmediadtlUpdateData();
            _proc.RIS_LOADMEDIADTL = this.RIS_LOADMEDIADTL;
			_proc.Update();
		}
	}
}

