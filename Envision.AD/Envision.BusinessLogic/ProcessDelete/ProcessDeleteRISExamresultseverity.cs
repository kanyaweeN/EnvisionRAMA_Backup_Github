using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISExamresultseverity : IBusinessLogic
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
        public DbTransaction Transaction { get; set; }


		public ProcessDeleteRISExamresultseverity()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_EXAMRESULTSEVERITYDeleteData _proc = new RIS_EXAMRESULTSEVERITYDeleteData();
            _proc.RIS_EXAMRESULTSEVERITY = this.RIS_EXAMRESULTSEVERITY;
			_proc.Delete();
		}
	}
}

