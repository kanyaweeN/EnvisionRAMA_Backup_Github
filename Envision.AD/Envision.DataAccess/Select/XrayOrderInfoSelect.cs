using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class XrayOrderInfoSelect : DataAccessBase
    {
        public XrayOrderInfoSelect()
        {
            //this.StoredProcedureName = StoredProcedure.Prc_XRAY_GetOrderInfo;
            this.StoredProcedureName = StoredProcedure.Prc_XRAY_GetOrderInfo2;
        }
        
        public DataSet GetOrderInfo(int orderId, int orgId)
        {
            this.ParameterList = new DbParameter[] { 
                Parameter("@ORDER_ID", orderId),
                Parameter("@ORG_ID", orgId),
            };
            return this.ExecuteDataSet();
        }
    }
}
