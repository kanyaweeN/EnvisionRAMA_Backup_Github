using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISRadstudygroup : IBusinessLogic
	{
        public RIS_RADSTUDYGROUP RIS_RADSTUDYGROUP{get;set;}
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISRadstudygroup()
		{
            RIS_RADSTUDYGROUP = new RIS_RADSTUDYGROUP();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_RADSTUDYGROUPDeleteData _proc = new RIS_RADSTUDYGROUPDeleteData();
            _proc.RIS_RADSTUDYGROUP = RIS_RADSTUDYGROUP;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

