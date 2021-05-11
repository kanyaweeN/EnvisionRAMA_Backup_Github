using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVRequisitiondtl : IBusinessLogic
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddINVRequisitiondtl()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = null;
		}
        public ProcessAddINVRequisitiondtl(DbTransaction tran)
        {
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVRequisitiondtlInsertData _proc=new INVRequisitiondtlInsertData();
            _proc.INV_REQUISITIONDTL = this.INV_REQUISITIONDTL;
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

