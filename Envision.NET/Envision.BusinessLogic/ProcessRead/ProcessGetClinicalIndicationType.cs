using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetClinicalIndicationType
    {
        public ProcessGetClinicalIndicationType()
        {
        }

        public DataSet GetClinicalIndicationType(int org_id, int emp_id)
        {
            ProcessGetRISClinicalindicationtype processClinicalindicationtype = new ProcessGetRISClinicalindicationtype();
            return processClinicalindicationtype.getData(org_id, emp_id);
        }
    }
}
