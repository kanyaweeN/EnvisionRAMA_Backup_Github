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
    public class ProcessGetRadiologistAuthLevel : IBusinessLogic
    {
        public static int _empid=0;
        private DataSet _resultset;

        public ProcessGetRadiologistAuthLevel()
        {

        }
        public void Invoke()
        {
        }
        public void AuthLevel(int emp)
        {
            _empid = emp;
            AuthLevelSelectData envdata = new AuthLevelSelectData();
            ResultSet = envdata.Get(_empid);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
