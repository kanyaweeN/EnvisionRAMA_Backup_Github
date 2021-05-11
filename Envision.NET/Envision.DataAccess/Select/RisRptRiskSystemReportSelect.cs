using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RisRptRiskSystemReportSelect : DataAccessBase
    {
        public RisRptRiskSystemReportSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_rptRiskSystemReport;
        }
        public DataSet GetData(string catelog, int mode, int top_n, int orgId, DateTime from_dt, DateTime to_dt)
        {
            this.ParameterList = this.BuildParameters(catelog, mode, top_n, orgId, from_dt, to_dt);
            DataSet ds = new DataSet();
            ds = this.ExecuteDataSet();
            return ds;
        }

        private DbParameter[] BuildParameters(string catelog, int mode, int top_n, int orgId, DateTime from_dt, DateTime to_dt)
        {
            DbParameter fromDtParameter = null;
            if (from_dt == DateTime.MinValue)
                fromDtParameter = Parameter("@FROM_DT", DBNull.Value);
            else
                fromDtParameter = Parameter("@FROM_DT", from_dt);

            DbParameter toDtParameter = null;
            if (to_dt == DateTime.MinValue)
                toDtParameter = Parameter("@TO_DT", DBNull.Value);
            else
                toDtParameter = Parameter("@TO_DT", to_dt);

            DbParameter[] parameters = { 
                                            Parameter("@CATELOG", catelog),
                                            Parameter("@MODE", mode),
                                            Parameter("@TOP_N", top_n),
                                            fromDtParameter,
                                            toDtParameter,
                                            Parameter("@ORG_ID", orgId)
                                       };
            return parameters;
        }
    }
}
