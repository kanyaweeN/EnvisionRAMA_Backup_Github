using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
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
