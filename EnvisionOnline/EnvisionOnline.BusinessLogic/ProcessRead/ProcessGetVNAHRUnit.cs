using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetVNAHRUnit : IBusinessLogic
    {
        private DataSet result;
        public ProcessGetVNAHRUnit()
        {
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {

        }
        public DataSet CheckUnit(string unit_uid)
        {
            VNAHrUnitSelectData _proc = new VNAHrUnitSelectData();
            return _proc.CheckUnit(unit_uid);
        }
    }
}
