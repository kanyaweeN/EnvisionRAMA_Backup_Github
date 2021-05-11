using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicalindicationtype : IBusinessLogic
    {
        private DataSet _resultset;

        public ProcessGetRISClinicalindicationtype()
        {

        }

        public void Invoke()
        {
        }

        public DataSet getData(int org_id, int emp_id)
        {
            RISClinicalindicationtypeSelectData data = new RISClinicalindicationtypeSelectData();
            return ResultSet = data.Get(org_id, emp_id);
        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
