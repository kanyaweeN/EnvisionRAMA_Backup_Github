using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISInsurancetype : IBusinessLogic
    {
        private DataSet result;
        private int ORG_ID;
        public ProcessGetRISInsurancetype(int org_id)
        {
            ORG_ID = org_id;
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISInsurancetypeSelectData _proc = new RISInsurancetypeSelectData();
            result = _proc.GetData(ORG_ID);
        }
    }
}
