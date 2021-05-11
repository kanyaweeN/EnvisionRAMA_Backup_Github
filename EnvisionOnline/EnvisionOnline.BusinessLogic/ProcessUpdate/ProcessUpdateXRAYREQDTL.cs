using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateXRAYREQDTL : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateXRAYREQDTL()
        {
            XRAYREQ = new XRAYREQ();
        }
        public void Invoke()
        {
            XRAYREQDTLUpdateData _proc = new XRAYREQDTLUpdateData();
            _proc.XRAYREQ = this.XRAYREQ;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
        }
    }
}
