using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetHRTitle : IBusinessLogic
    {

        private DataSet _resultset;

        public ProcessGetHRTitle()
        {

        }

        public void Invoke()
        {
            HRTitleSelectData data = new HRTitleSelectData();
            ResultSet = data.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }



    }
}