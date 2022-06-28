using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVRequisitiondtl : IBusinessLogic
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVRequisitiondtl()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = null;
		}
        public ProcessDeleteINVRequisitiondtl(DbTransaction transaction)
        {
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = transaction;
        }
		
		public void Invoke()
		{
            INV_REQUISITIONDTLDeleteData _proc = new INV_REQUISITIONDTLDeleteData();
            _proc.INV_REQUISITIONDTL = INV_REQUISITIONDTL;
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

