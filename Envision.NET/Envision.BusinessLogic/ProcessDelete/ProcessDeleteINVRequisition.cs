using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVRequisition : IBusinessLogic
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVRequisition()
		{
            INV_REQUISITION = new INV_REQUISITION();
            Transaction = null;
		}
		
		public void Invoke()
		{
            INV_REQUISITIONDeleteData _proc = new INV_REQUISITIONDeleteData();
            _proc.INV_REQUISITION = INV_REQUISITION;
			_proc.Delete();
		}
	}
}

