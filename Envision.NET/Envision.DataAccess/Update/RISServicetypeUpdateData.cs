using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISServicetypeUpdateData : DataAccessBase 
	{
        public RIS_SERVICETYPE RIS_SERVICETYPE { get; set; }

		public  RISServicetypeUpdateData()
		{
            RIS_SERVICETYPE = new RIS_SERVICETYPE();
			StoredProcedureName = StoredProcedure.Prc_RIS_SERVICETYPE_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@SERVICE_TYPE_ID",RIS_SERVICETYPE.SERVICE_TYPE_ID),
                Parameter("@SERVICE_TYPE_UID",RIS_SERVICETYPE.SERVICE_TYPE_UID),
                Parameter("@IS_UPDATED",RIS_SERVICETYPE.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_SERVICETYPE.IS_DELETED),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                Parameter("@IS_ACTIVE",RIS_SERVICETYPE.IS_ACTIVE),
                Parameter("@SERVICE_TYPE_TEXT",RIS_SERVICETYPE.SERVICE_TYPE_TEXT)
                                      };
            return parameters;
        }
	}
}

