using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common.Common;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISOrderGetReport : DataAccessBase
    {
        public RISOrderGetReport()
        {
            
        }

        public DataSet GetData(string HN, int OrderId, int OrgId)
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_SelectOrderReport;
            this.ParameterList = new DbParameter[] { 
                Parameter("@HN", HN),
                Parameter("@ORDER_ID", OrderId),
                Parameter("@ORG_ID", OrgId),
            };
            return this.ExecuteDataSet();
        }
        public DataSet GetDataOnline(string HN, int OrderId, int OrgId)
        {
            this.StoredProcedureName = StoredProcedure.Prc_XRAYREQ_SelectOrderReport;
            this.ParameterList = new DbParameter[] { 
                Parameter("@HN", HN),
                Parameter("@ORDER_ID", OrderId),
                Parameter("@ORG_ID", OrgId),
            };
            return this.ExecuteDataSet();
        }
    }
}
