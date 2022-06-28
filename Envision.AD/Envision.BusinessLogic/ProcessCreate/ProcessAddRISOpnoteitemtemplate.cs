using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISOpnoteitemtemplate : IBusinessLogic
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISOpnoteitemtemplate()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
		}
        public ProcessAddRISOpnoteitemtemplate(DbTransaction tran)
        {
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
            Transaction = tran;
        }
		public void Invoke()
		{
            RIS_OPNOTEITEMTEMPLATEInsertData _proc = new RIS_OPNOTEITEMTEMPLATEInsertData();
            _proc.RIS_OPNOTEITEMTEMPLATE = RIS_OPNOTEITEMTEMPLATE;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
		}
	}
}

