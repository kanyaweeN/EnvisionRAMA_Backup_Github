using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class GBLNotificationUpdateData: DataAccessBase
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }
        public GBLNotificationUpdateData()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
            StoredProcedureName = StoredProcedure.Prc_GBL_Notification_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@NOTIFICATION_ID"	, GBL_NOTIFICATION.NOTIFICATION_ID ) ,
                Parameter( "@NOTIFICATION_UID"	, GBL_NOTIFICATION.NOTIFICATION_UID ) ,
                Parameter( "@NOTIFICATION_DESC"	, GBL_NOTIFICATION.NOTIFICATION_DESC ) ,
                Parameter( "@SUBJECT"	, GBL_NOTIFICATION.SUBJECT ) ,
                Parameter( "@NOTIFICATION_EMP_ID"	, GBL_NOTIFICATION.NOTIFICATION_EMP_ID ) ,
                Parameter( "@LAST_MODIFIED_BY"	, GBL_NOTIFICATION.LAST_MODIFIED_BY ) ,
                                      };
            return parameters;
        }
    }
}
