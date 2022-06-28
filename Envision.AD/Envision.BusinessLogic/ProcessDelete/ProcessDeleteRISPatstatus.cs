using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISPatstatus : IBusinessLogic
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISPatstatus()
		{
            RIS_PATSTATUS = new RIS_PATSTATUS();
            Transaction = null;
		}
        
		public void Invoke()
		{
            RIS_PATSTATUSDeleteData _proc = new RIS_PATSTATUSDeleteData();
            _proc.RIS_PATSTATUS = RIS_PATSTATUS;
			 _proc.Delete();
		}
    }
}
