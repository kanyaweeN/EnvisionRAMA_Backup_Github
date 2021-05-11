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
    public class ProcessGetFormAccess : IBusinessLogic
    {
        
        private DataSet _resultset;

        public ProcessGetFormAccess()
        {

        }

        public void Invoke()
        {
            FormAccessSelectData accessdata = new FormAccessSelectData();
            ResultSet = accessdata.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        

    }
}
