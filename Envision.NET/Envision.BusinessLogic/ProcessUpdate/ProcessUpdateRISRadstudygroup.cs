using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISRadstudygroup : IBusinessLogic
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateRISRadstudygroup()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
            Transaction = null;
		}
		public void Invoke()
		{
			RISRadstudygroupUpdateData _proc=new RISRadstudygroupUpdateData();
            _proc.RIS_RADSTUDYGROUP = this.RIS_RADSTUDYGROUP;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

