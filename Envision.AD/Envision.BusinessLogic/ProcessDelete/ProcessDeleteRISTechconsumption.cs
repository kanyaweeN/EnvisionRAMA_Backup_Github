using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISTechconsumption : IBusinessLogic
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISTechconsumption()
		{
            Transaction = null;
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
		}
		
		public void Invoke()
		{
            RIS_TECHCONSUMPTIONDeleteData _proc = new RIS_TECHCONSUMPTIONDeleteData();
            _proc.RIS_TECHCONSUMPTION = RIS_TECHCONSUMPTION;
			_proc.Delete();
		}
	}
}

