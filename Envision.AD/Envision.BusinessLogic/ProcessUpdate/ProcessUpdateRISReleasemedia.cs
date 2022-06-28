using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISReleasemedia : IBusinessLogic
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        public DbTransaction Transaction { get; set; } 

		public ProcessUpdateRISReleasemedia()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            Transaction = null;
		}
		public void Invoke()
		{
			RISReleasemediaUpdateData _proc=new RISReleasemediaUpdateData();
            _proc.RIS_RELEASEMEDIA = this.RIS_RELEASEMEDIA;
			_proc.Update();
		}
	}
}

