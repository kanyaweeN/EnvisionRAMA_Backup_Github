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
    public class ProcessCheckSession : IBusinessLogic
    {

        private DataSet _resultset;

        public ProcessCheckSession()
        {

        }

        public void Invoke()
        {
            
        }

        public void Invoke(int userid, int sptype)
        {
            SessionSelectData sessiondata = new SessionSelectData();
            ResultSet = sessiondata.Get(userid, sptype);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
