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
    public class ProcessGetRISSF02 : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetRISSF02()
        {

        }

        public void Invoke()
        {
            RISSF02SelectData proddata = new RISSF02SelectData();
            ResultSet = proddata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

       

    }
}
