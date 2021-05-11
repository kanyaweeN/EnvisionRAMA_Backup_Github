using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISAuthlevel : IBusinessLogic
    {
        private DataSet result;
        public ProcessGetRISAuthlevel()
        {

        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISAuthlevelSelectData _proc = new RISAuthlevelSelectData();
            result = _proc.GetData();
        }
    }
}
