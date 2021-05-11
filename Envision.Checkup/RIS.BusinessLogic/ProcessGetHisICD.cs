using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetHisICD : IBusinessLogic
    {
        private DataSet result;

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            HisICDSelectData _proc = new HisICDSelectData();
            result = _proc.GetData();
        }
    }
}
