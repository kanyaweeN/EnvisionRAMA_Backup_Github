using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISExamresultlocks : IBusinessLogic
	{
        public RIS_EXAMRESULTLOCK RIS_EXAMRESULTLOCK { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISExamresultlocks()
		{
            RIS_EXAMRESULTLOCK = new RIS_EXAMRESULTLOCK();
            Transaction = null;
		}
		public void Invoke()
		{
			RISExamresultlocksUpdateData _proc=new RISExamresultlocksUpdateData();
            _proc.RIS_EXAMRESULTLOCK = this.RIS_EXAMRESULTLOCK;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

