using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVRequisition : IBusinessLogic
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddINVRequisition()
		{
            INV_REQUISITION = new INV_REQUISITION();
            Transaction = null;
		}
        public ProcessAddINVRequisition(DbTransaction tran)
        {
            INV_REQUISITION = new INV_REQUISITION();
            Transaction = tran;
        }
		public void Invoke()
		{
            INVRequisitionInsertData _proc = new INVRequisitionInsertData();
            _proc.INV_REQUISITION = this.INV_REQUISITION;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
            this.INV_REQUISITION.REQUISITION_ID = _proc.GetID();
		}
	}
}

