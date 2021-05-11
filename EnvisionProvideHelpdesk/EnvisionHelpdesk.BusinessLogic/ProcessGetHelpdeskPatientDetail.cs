using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionHelpdesk.DataAccess.Select;

namespace EnvisionHelpdesk.BusinessLogic
{
    public class ProcessGetHelpdeskPatientDetail
    {

        public ProcessGetHelpdeskPatientDetail()
        {
        }
        public DataSet getDatabyHN(string hn)
        {
            HelpdeskPatientDetailSelectData prc = new HelpdeskPatientDetailSelectData();
            return prc.getDatabyHN(hn);
        }
    }

}
