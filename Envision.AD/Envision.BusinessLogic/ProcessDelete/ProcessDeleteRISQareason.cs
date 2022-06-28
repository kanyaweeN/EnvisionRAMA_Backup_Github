using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISQareason : IBusinessLogic
	{
        public RIS_QAREASON RIS_QAREASON { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISQareason()
		{
            RIS_QAREASON = new RIS_QAREASON();
            Transaction = null;
		}
	
		public void Invoke()
		{
            RIS_QAREASONDeleteData _proc = new RIS_QAREASONDeleteData();
            _proc.RIS_QAREASON = RIS_QAREASON;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

