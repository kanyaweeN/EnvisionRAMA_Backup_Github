using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISExamresultrads : IBusinessLogic
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS {get;set;}
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISExamresultrads()
		{
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            Transaction = null;
		}
		public void Invoke()
        {
            RISExamresultradsUpdateData _proc = new RISExamresultradsUpdateData();
            _proc.RIS_EXAMRESULTRADS = this.RIS_EXAMRESULTRADS;
			_proc.Update();
		}
    }
}
