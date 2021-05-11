using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISExam : IBusinessLogic
	{
        public RIS_EXAM RIS_EXAM { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISExam(){
            RIS_EXAM = new RIS_EXAM();
            Transaction = null;
        }
		
		public void Invoke()
		{
            RIS_EXAMDeleteData _proc = new RIS_EXAMDeleteData();
            _proc.RIS_EXAM = this.RIS_EXAM;
			_proc.Delete();
		}
	}
}

