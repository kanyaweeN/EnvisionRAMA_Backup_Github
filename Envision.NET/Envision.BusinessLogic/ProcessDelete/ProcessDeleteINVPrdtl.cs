using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVPrdtl : IBusinessLogic
	{
        public INV_PRDTL INV_PRDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVPrdtl()
		{
            INV_PRDTL = new INV_PRDTL();
            Transaction = null;
		}
        public ProcessDeleteINVPrdtl(DbTransaction transaction)
        {
            INV_PRDTL = new INV_PRDTL();
            Transaction = transaction;
        }
		
		public void Invoke()
		{
            INV_PRDTLDeleteData _proc = new INV_PRDTLDeleteData();
            _proc.INV_PRDTL = INV_PRDTL;
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

