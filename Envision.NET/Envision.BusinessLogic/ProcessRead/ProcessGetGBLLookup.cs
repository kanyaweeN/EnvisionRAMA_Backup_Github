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
    public class ProcessGetGBLLookup : IBusinessLogic
    {
        private string _qry;
        private DataSet _resultset;

        public ProcessGetGBLLookup(string qry)
        {
            _qry = qry;
        }

        public void Invoke()
        {
            GBLLookupSelectData lookupdata = new GBLLookupSelectData();
            ResultSet = lookupdata.Get(_qry);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        

    }
}
