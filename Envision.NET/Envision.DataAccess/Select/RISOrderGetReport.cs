using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderGetReport : DataAccessBase
    {
        public RISOrderGetReport()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectOrderReport;
        }

        public DataSet GetData(string HN, int OrderId, int OrgId)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@HN", HN),
                Parameter("@ORDER_ID", OrderId),
                Parameter("@ORG_ID", new GBLEnvVariable().OrgID),
            };
            return this.ExecuteDataSet();
        }
    }
}
