using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrder : IBusinessLogic
    {
        public RIS_ORDER RIS_ORDER { get; set; }
        public DbTransaction Transaction { get; set; }
        //private DbTransaction tran;

        public ProcessAddRISOrder()
        {
            RIS_ORDER = new RIS_ORDER();
            Transaction = null;
        }

        public void Invoke()
        {
            RIS_ORDERInsertData _proc = new RIS_ORDERInsertData();
            _proc.RIS_ORDER = RIS_ORDER;
            if (Transaction == null)
                RIS_ORDER.ORDER_ID = _proc.Add();
            else
                RIS_ORDER.ORDER_ID = _proc.Add(Transaction);
        }
    }
}
