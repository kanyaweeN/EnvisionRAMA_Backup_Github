using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISExamType : IBusinessLogic
    {
        private DataSet result;

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISExamTypeSelectData _proc = new RISExamTypeSelectData();
            result = _proc.GetData();
        }
    }
}
