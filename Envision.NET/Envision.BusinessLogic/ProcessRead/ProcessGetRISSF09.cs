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
    public class ProcessGetRISSF09 : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetRISSF09()
        {

        }

        public void Invoke()
        {
            RISSF09SelectData proddata = new RISSF09SelectData();
            ResultSet = proddata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

       

    }
}
