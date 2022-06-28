using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RisRiskIncidentUsersSelect : DataAccessBase
    {
        public RIS_RISKINCIDENTUSERS RIS_RISKINCIDENTUSERS { get; set; }
        public RisRiskIncidentUsersSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_RISKINCIDENTUSERS_SELECT;
        }
        public DataSet GetData(int mode)
        {
            ParameterList = this.BuildParameters(mode);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] BuildParameters(int mode)
        {
            DbParameter[] parameters = { 
                                            Parameter("@MODE", mode),
                                            Parameter("@INCIDENT_ID", RIS_RISKINCIDENTUSERS.INCIDENT_ID),
                                            Parameter("@ORG_ID", RIS_RISKINCIDENTUSERS.ORG_ID)
                                       };
            return parameters;
        }
    }
}
