using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISExaminstructions : IBusinessLogic
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISExaminstructions(){
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
            Transaction = null;
        }
		
		public void Invoke()
		{
            RIS_EXAMINSTRUCTIONDeleteData _proc = new RIS_EXAMINSTRUCTIONDeleteData();
            _proc.RIS_EXAMINSTRUCTION = this.RIS_EXAMINSTRUCTION;
			_proc.Delete();
		}
	}
}

