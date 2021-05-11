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
    public class ProcessGetGBLEnv : IBusinessLogic
    {

        private DataSet _resultset;

        public ProcessGetGBLEnv()
        {

        }

        public void Invoke()
        {
            EnvSelectData envdata = new EnvSelectData();
            ResultSet = envdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}
