using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISModalityexam : IBusinessLogic
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISModalityexam(){
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
            Transaction = null;
        }
		
		public void Invoke()
		{
            RIS_MODALITYEXAMDeleteData _proc = new RIS_MODALITYEXAMDeleteData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
			_proc.Delete();
		}

        public void InvokeOnline()
        {
            RIS_MODALITYEXAMDeleteData _proc = new RIS_MODALITYEXAMDeleteData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
            _proc.DeleteOnline();
        }
	}
}

