using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RisRiskIncidentUsersInsert : DataAccessBase
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public RisRiskIncidentUsersInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTUSERS_INSERT;
        }
        public void InsertData()
        {
            ParameterList = this.BuildParameters();
            ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@INCIDENT_ID", RIS_RISKINCIDENTUSERS.INCIDENT_ID),
                                            Parameter("@EMP_ID", RIS_RISKINCIDENTUSERS.EMP_ID),
                                            Parameter("@ORG_ID", RIS_RISKINCIDENTUSERS.ORG_ID),
                                            Parameter("@CREATED_BY", RIS_RISKINCIDENTUSERS.CREATED_BY)
                                       };
            return parameters;
        }
    }
}
