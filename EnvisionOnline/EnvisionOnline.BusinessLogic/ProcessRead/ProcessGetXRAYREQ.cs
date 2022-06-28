using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetXRAYREQ : IBusinessLogic
    {
        public XRAYREQ XRAYREQ { get; set; }
        private DataSet result;

        public ProcessGetXRAYREQ()
        {
            XRAYREQ = new XRAYREQ();
            result = new DataSet();
        }
        public void Invoke()
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
        }

        public DataTable GetBusyCase(int xrayreq_id)
        {
            XRAYREQSelectData _proc = new XRAYREQSelectData();
            return _proc.GetBusyCase(xrayreq_id);
        }
    }
}
