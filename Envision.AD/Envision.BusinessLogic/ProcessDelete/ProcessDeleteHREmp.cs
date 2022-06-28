using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteHREmp : IBusinessLogic
	{
        public HR_EMP HR_EMP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteHREmp()
		{
            HR_EMP = new HR_EMP();
            Transaction = null;
		}
	
		public void Invoke()
		{
            HR_EMPDeleteData _proc = new HR_EMPDeleteData();
            _proc.HR_EMP = HR_EMP;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

