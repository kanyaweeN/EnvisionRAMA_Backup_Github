using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteMISBiopsyresult : IBusinessLogic
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteMISBiopsyresult()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
            Transaction = null;
		}
		public void Invoke()
		{
            MIS_BIOPSYRESULTDeleteData _proc = new MIS_BIOPSYRESULTDeleteData();
            _proc.MIS_BIOPSYRESULT = this.MIS_BIOPSYRESULT;
		    _proc.Delete();
		}
	}
}

