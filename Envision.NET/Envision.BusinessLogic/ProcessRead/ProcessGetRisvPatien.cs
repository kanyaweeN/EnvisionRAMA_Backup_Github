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
