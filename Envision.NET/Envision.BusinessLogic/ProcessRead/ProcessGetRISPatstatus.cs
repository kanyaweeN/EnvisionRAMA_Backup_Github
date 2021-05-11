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
    public class ProcessGetRISPatstatus : IBusinessLogic
    {
        
        private DataSet _resultset;
        private int action = 0;
        public ProcessGetRISPatstatus()
        {
            action = 0;
        }
        public ProcessGetRISPatstatus(bool flag) {
            if (flag)
                action = 1;
            else
                action = 0;
        }

        public void Invoke()
        {
            if (action == 0)
            {
                PatientSelectData proddata = new PatientSelectData();
                ResultSet = proddata.Get();
            }
            else {

                RISPatstatusSelectData prodData = new RISPatstatusSelectData();
                ResultSet = prodData.GetData();
            }
           
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

       

    }
}
