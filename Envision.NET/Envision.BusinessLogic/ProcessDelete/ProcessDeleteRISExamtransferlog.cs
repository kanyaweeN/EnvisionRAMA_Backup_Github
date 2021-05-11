using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISExamtransferlog : IBusinessLogic
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISExamtransferlog()
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
            Transaction = null;
		}
		public void Invoke()
		{
            RIS_EXAMTRANSFERLOGDeleteData _proc = new RIS_EXAMTRANSFERLOGDeleteData();
            _proc.RIS_EXAMTRANSFERLOG = this.RIS_EXAMTRANSFERLOG;
			_proc.Delete();
		}
	}
}

