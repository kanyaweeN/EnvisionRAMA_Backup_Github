using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
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
