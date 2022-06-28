using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISLoadmedia : IBusinessLogic
	{
        public RIS_LOADMEDIA RIS_LOADMEDIA { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISLoadmedia()
		{
            RIS_LOADMEDIA = new RIS_LOADMEDIA();
            Transaction = null;
		}
		public void Invoke()
		{
			RISLoadmediaUpdateData _proc=new RISLoadmediaUpdateData();
            _proc.RIS_LOADMEDIA = this.RIS_LOADMEDIA;
			_proc.Update();
		}
	}
}

