using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISOpnoteitem : IBusinessLogic
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISOpnoteitem()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_OPNOTEITEMDeleteData _proc = new RIS_OPNOTEITEMDeleteData();
            _proc.RIS_OPNOTEITEM = this.RIS_OPNOTEITEM;
			_proc.Delete();
		}
	}
}

