using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISNursesDataDtl : IBusinessLogic
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        public DbTransaction Transaction { get; set; }
        public ProcessUpdateRISNursesDataDtl()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
            Transaction = null;
		}
		public void Invoke()
		{

            RISNurseDataDtlUpdateData _proc = new RISNurseDataDtlUpdateData();
            _proc.RIS_NURSESDATADTL = this.RIS_NURSESDATADTL;
			_proc.Update();
		}
    }
}
