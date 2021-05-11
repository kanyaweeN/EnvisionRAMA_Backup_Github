using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISPatstatus : IBusinessLogic
    {

        private DataSet _resultset;
        private int action = 0;
        public ProcessGetRISPatstatus()
        {
            action = 0;
        }
        public ProcessGetRISPatstatus(bool is_active)
        {
            if (is_active)
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
            else
            {

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

