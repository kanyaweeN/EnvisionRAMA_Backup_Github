using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISPaticd : IBusinessLogic
	{
        public RIS_PATICD RIS_PATICD { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISPaticd()
		{
            RIS_PATICD = new RIS_PATICD();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_PATICDDeleteData _proc = new RIS_PATICDDeleteData();
            _proc.RIS_PATICD = RIS_PATICD;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

