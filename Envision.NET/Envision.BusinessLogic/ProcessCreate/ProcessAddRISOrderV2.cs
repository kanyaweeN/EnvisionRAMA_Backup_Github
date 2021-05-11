using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderV2 : IBusinessLogic
    {
        public RIS_ORDER RIS_ORDER{get;set;}
        public DbTransaction Transaction { get; set; }
        //private DbTransaction tran;

        public ProcessAddRISOrderV2()
		{
            RIS_ORDER = new RIS_ORDER();
            Transaction = null;
		}
	
		public void Invoke()
		{
            RISOrderInsertV2 _proc = new RISOrderInsertV2();
            _proc.RIS_ORDER = RIS_ORDER;
            if (Transaction == null)
                RIS_ORDER.ORDER_ID = _proc.Add();
            else
                RIS_ORDER.ORDER_ID = _proc.Add(Transaction);
		}
    }
}
