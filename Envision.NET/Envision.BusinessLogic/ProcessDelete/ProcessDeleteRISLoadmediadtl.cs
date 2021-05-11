using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISLoadmediadtl : IBusinessLogic
	{
        public RIS_LOADMEDIADTL RIS_LOADMEDIADTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISLoadmediadtl()
		{
            RIS_LOADMEDIADTL = new RIS_LOADMEDIADTL();
            Transaction = null;
		}
	
		public void Invoke()
		{
            RIS_LOADMEDIADTLDeleteData _proc = new RIS_LOADMEDIADTLDeleteData();
            _proc.RIS_LOADMEDIADTL = this.RIS_LOADMEDIADTL;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

