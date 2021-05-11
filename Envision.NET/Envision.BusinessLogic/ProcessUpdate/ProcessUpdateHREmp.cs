using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateHREmp : IBusinessLogic
	{
        public HR_EMP HR_EMP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateHREmp()
		{
            HR_EMP = new HR_EMP();
            Transaction = null;
		}
		public void Invoke()
		{
			HREmpUpdateData _proc=new HREmpUpdateData();
            _proc.HR_EMP = this.HR_EMP;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

