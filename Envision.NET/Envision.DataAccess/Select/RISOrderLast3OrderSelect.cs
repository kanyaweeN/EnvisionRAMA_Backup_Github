using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISOrderLast3OrderSelect : DataAccessBase
    {
        public RISOrderLast3OrderSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDER_Get3LastOrder;
        }

        public DataSet GetData(int regId, int orgId)
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@REG_ID", regId)
                , Parameter("@ORG_ID", orgId)
            };
            return this.ExecuteDataSet();
        }
    }
}
