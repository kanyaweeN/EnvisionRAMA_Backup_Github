using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetHRUnit : IBusinessLogic
    {
        public HR_UNIT HR_UNIT { get; set; }
        private DataSet result;
        public ProcessGetHRUnit()
        {
            HR_UNIT = new HR_UNIT();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            HRUnitSelectData _proc = new HRUnitSelectData(true);
            _proc.HR_UNIT = this.HR_UNIT;
            result = _proc.GetData();
        }
    }
}
