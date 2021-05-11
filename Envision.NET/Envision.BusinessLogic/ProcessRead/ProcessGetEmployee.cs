using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetEmployee : IBusinessLogic
    {
        private DataSet _dataresult;
        public HR_EMP HR_EMP { get; set; }

        public ProcessGetEmployee() {
            HR_EMP = new HR_EMP();
            _dataresult = new DataSet();
        }
        public void Invoke()
        {
            GBLEmployeeSelectData EMPdata = new GBLEmployeeSelectData();
            EMPdata.HR_EMP = HR_EMP;
            DataResult = EMPdata.Get(); 
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }

        public DataSet GetSchedule() {
            GBLEmployeeSelectData EMPdata = new GBLEmployeeSelectData();
            EMPdata.HR_EMP = HR_EMP;
            DataSet ds = new DataSet();
            ds = EMPdata.GetSchedule();
            return ds;
        }
    }
}
