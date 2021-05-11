using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using RIS.DataAccess;
using RIS.Common.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderGetReport : DataAccessBase
    {
        public RISOrderGetReport()
        {
            this.StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_SelectOrderReport.ToString();
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
