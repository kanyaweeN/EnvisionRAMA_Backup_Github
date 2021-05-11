using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISUserorgmap : IBusinessLogic
	{
        public RIS_USERORGMAP RIS_USERORGMAP { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteRISUserorgmap()
		{
            RIS_USERORGMAP = new RIS_USERORGMAP();
            Transaction = null;
		}
		public void Invoke()
		{
            RIS_USERORGMAPDeleteData _proc = new RIS_USERORGMAPDeleteData();
            _proc.RIS_USERORGMAP = this.RIS_USERORGMAP;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

