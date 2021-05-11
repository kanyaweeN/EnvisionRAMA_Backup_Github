using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISOrder : IBusinessLogic
	{
        public RIS_ORDER RIS_ORDER { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessDeleteRISOrder()
		{
            RIS_ORDER = new RIS_ORDER();
            Transaction = null;
		}
		
		public void Invoke()
		{
            RIS_ORDERDeleteData _proc = new RIS_ORDERDeleteData();
            _proc.RIS_ORDER = RIS_ORDER;
			_proc.Delete();
		}
	}
}

