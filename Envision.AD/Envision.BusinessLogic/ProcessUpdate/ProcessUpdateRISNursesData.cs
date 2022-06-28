using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISNursesData : IBusinessLogic
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISNursesData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
            Transaction = null;
		}
		public void Invoke()
		{

            RISNurseDataUpdateData _proc = new RISNurseDataUpdateData();
            _proc.RIS_NURSESDATA = this.RIS_NURSESDATA;
			_proc.Update();
		}
    }
}
