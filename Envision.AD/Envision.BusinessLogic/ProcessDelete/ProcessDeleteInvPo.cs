using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVPo : IBusinessLogic
	{
        public INV_PO INV_PO { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVPo()
		{
            INV_PO = new INV_PO();
            Transaction = null;
		}
		
		public void Invoke()
		{
            INV_PODeleteData proc = new INV_PODeleteData();
            proc.INV_PO = INV_PO;
            proc.Delete();
		}
	}
}

