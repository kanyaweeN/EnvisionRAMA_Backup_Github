using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessGetEmployee : IBusinessLogic
    {
        private DataSet _dataresult;
        private GBLEmployee _data;

        public ProcessGetEmployee() { }
        public void Invoke()
        {
            GBLEmployeeSelectData EMPdata = new GBLEmployeeSelectData();
            EMPdata.GBLEmployee = GBLEmployee;
            DataResult = EMPdata.Get(); 
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }

        public GBLEmployee GBLEmployee
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
