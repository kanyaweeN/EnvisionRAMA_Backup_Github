using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLNotificationInsertData: DataAccessBase
    {
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }
        public GBLNotificationInsertData()
        {
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
            StoredProcedureName = StoredProcedure.Prc_GBL_Notification_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@NOTIFICATION_UID"	, GBL_NOTIFICATION.NOTIFICATION_UID ) ,
                Parameter( "@NOTIFICATION_DESC"	, GBL_NOTIFICATION.NOTIFICATION_DESC ) ,
                Parameter( "@SUBJECT"	, GBL_NOTIFICATION.SUBJECT ) ,
                Parameter( "@NOTIFICATION_EMP_ID"	, GBL_NOTIFICATION.NOTIFICATION_EMP_ID ) ,
                Parameter( "@CREATED_BY"	, GBL_NOTIFICATION.CREATED_BY ) ,
            };
            return parameters;
        }

    }
}
