using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLNotificationDeleteData: DataAccessBase 
	{
        public GBL_NOTIFICATION GBL_NOTIFICATION { get; set; }

        public GBLNotificationDeleteData()
		{
            GBL_NOTIFICATION = new GBL_NOTIFICATION();
            StoredProcedureName = StoredProcedure.Prc_GBL_Notification_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@NOTIFICATION_ID", GBL_NOTIFICATION.NOTIFICATION_ID) 
                                       };
            return parameters;
        }
	}
}

