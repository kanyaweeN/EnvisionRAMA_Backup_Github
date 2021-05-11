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
    public class ProcessGetHRAccount : IBusinessLogic
    {
        public HR_EMP HR_EMP { get; set; }
        private DataSet _resultset;

        public ProcessGetHRAccount()
        {
            HR_EMP = new HR_EMP();
        }

        public void Invoke()
        {
            HRAccountSelectData HRdata = new HRAccountSelectData();
            HRdata.HR_EMP = HR_EMP;
            ResultSet = HRdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}