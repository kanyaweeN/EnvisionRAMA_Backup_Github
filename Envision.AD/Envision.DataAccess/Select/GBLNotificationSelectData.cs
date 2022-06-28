using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLNotificationSelectData: DataAccessBase
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }
        public GBLNotificationSelectData()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
            StoredProcedureName = StoredProcedure.Prc_GBL_Notification_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param6 = Parameter();
            param6.ParameterName = "@NOTIFICATION_DATE";
            if (GBL_NOTIFICATION.CREATED_ON == null)
                param6.Value = DBNull.Value;
            else
                param6.Value = GBL_NOTIFICATION.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_NOTIFICATION.CREATED_ON;

            DbParameter[] parameters = { 
                                          Parameter("@MODE"	, GBL_NOTIFICATION.MODE  ),
                                          param6,
                                          Parameter("@NOTIFICATION_ID"	, GBL_NOTIFICATION.NOTIFICATION_ID  ),
                                       };
            return parameters;
        }
    }
}
