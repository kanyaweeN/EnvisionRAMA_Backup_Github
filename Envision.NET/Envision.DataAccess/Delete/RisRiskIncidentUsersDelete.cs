using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class RisRiskIncidentUsersDelete : DataAccessBase
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public RisRiskIncidentUsersDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTUSERS_DELETE;
        }
        public void DeleteData(int mode)
        {
            ParameterList = this.BuildParameters(mode);
            ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters(int mode)
        {
            DbParameter[] parameters = { 
                                            Parameter("@INCIDENT_ID", RIS_RISKINCIDENTUSERS.INCIDENT_ID),
                                            Parameter("@EMP_ID", RIS_RISKINCIDENTUSERS.EMP_ID),
                                            Parameter("@MODE", mode)
                                       };
            return parameters;
        }
    }
}
