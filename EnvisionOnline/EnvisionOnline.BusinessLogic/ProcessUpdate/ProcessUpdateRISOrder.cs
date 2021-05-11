using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISOrder : IBusinessLogic
    {
        public RIS_ORDER RIS_ORDER { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISOrder(bool useTrans)
        {
            RIS_ORDER = new RIS_ORDER();
        }
        public void Invoke()
        {
            RISOrderUpdateData _proc = new RISOrderUpdateData();
            _proc.RIS_ORDER = RIS_ORDER;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);

        }
    }
}
