using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVPr : IBusinessLogic
	{
        public INV_PR INV_PR { get; set; }
        public DbTransaction Transaction { get; set; }


		public ProcessDeleteINVPr()
		{
            INV_PR = new INV_PR();
            Transaction = null;
		}
		
		public void Invoke()
		{
            INV_PRDeleteData _proc = new INV_PRDeleteData();
            _proc.INV_PR = INV_PR;
			_proc.Delete();
		}
	}
}

