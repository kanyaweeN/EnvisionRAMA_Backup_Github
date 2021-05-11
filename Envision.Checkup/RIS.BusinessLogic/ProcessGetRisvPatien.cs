using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRisvPatien : IBusinessLogic
    {
        DataSet _dataresult;

        public ProcessGetRisvPatien()
        { 
        
        }

        public void Invoke()
        {
            RisvPatienSelectData rispatien = new RisvPatienSelectData();
            DataResult = rispatien.Select();
        }

        public DataSet GetResult()
        {
            Invoke();
            return DataResult;
        }

        public DataSet DataResult
        {
            get { return _dataresult; }
            set { _dataresult = value; }
        }
    }
}
