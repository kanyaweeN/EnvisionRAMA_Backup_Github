using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateXRAYREQ : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateXRAYREQ()
        {
            XRAYREQ = new XRAYREQ();
        }
        public void Invoke()
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.XRAYREQ = this.XRAYREQ;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
        }
        public void Delete()
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.XRAYREQ = this.XRAYREQ;
            _proc.Delete();
        }
        public void updateLockCase(int order_id, string is_busy, int busy_by)
        {
            XRAYREQUpdateData _proc = new XRAYREQUpdateData();
            _proc.updateLockCase(order_id, is_busy, busy_by);
        }
    }
}
