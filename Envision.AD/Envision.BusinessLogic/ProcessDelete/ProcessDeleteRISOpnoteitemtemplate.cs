using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISOpnoteitemtemplate : IBusinessLogic
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISOpnoteitemtemplate()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
            Transaction = null;
		}
        public ProcessDeleteRISOpnoteitemtemplate(DbTransaction transaction)
        {
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
            Transaction = transaction;
        }
		public void Invoke()
		{
            RIS_OPNOTEITEMTEMPLATEDeleteData _proc = new RIS_OPNOTEITEMTEMPLATEDeleteData();
            _proc.RIS_OPNOTEITEMTEMPLATE = this.RIS_OPNOTEITEMTEMPLATE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

