using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetSRUserPreference : IBusinessLogic
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }
        public DataTable Result { get; set; }

        public ProcessGetSRUserPreference() {
            SR_USERPREFERENCE = new SR_USERPREFERENCE();
            Result = null;
        }

        public void Invoke()
        {
            SRUserPreferenceSelectData proc = new SRUserPreferenceSelectData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            Result = proc.GetData();
        }

        public DataTable GetByEmpId() {
            SRUserPreferenceSelectData proc = new SRUserPreferenceSelectData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            return proc.GetDataByEmpId();
        }
        public DataTable GetExamData()
        {
            SRUserPreferenceSelectData proc = new SRUserPreferenceSelectData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            return proc.GetExamData();
        }
    }
}
