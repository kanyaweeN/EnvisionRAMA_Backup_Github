using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVPodtl : IBusinessLogic
	{
        public INV_PODTL INV_PODTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVPodtl()
		{
            INV_PODTL = new INV_PODTL();
            Transaction = null;
		}
        public ProcessDeleteINVPodtl(DbTransaction transaction)
        {
            INV_PODTL = new INV_PODTL();
            Transaction = transaction;
        }
		
		public void Invoke()
		{
            INV_PODTLDeleteData _proc = new INV_PODTLDeleteData();
            _proc.INV_PODTL = INV_PODTL;
            if (Transaction == null)
            {
                _proc.Delete();
            }
            else
            {
                _proc.Delete(Transaction);
            }
		}
	}
}

