using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class SessionInsertData : DataAccessBase
    {
        public GBL_SESSION GBL_SESSION { get; set; }

        public SessionInsertData()
        {
            GBL_SESSION = new GBL_SESSION();
            StoredProcedureName = StoredProcedure.Prc_CreateNewSession2;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter() {
            DbParameter[] parameters =
		    {
				Parameter( "@SESSION_GUID"	    , GBL_SESSION.SESSION_GUID) ,
				Parameter( "@EMP_ID"            , GBL_SESSION.EMP_ID) ,
				Parameter( "@ORG_ID"	        , GBL_SESSION.ORG_ID) ,
				Parameter( "@IP_ADDR_CURR"	    , GBL_SESSION.IP_ADDR_CURR ) ,
				Parameter( "@LOGON_TYPE"		, GBL_SESSION.LOGON_TYPE ) ,
				Parameter( "@SESSION_STAT"	    , GBL_SESSION.SESSION_STAT ),
                Parameter( "@OS_NAME"		    , GBL_SESSION.OS_NAME ) ,
				Parameter( "@PROD_VERSION"	    , GBL_SESSION.PROD_VERSION ),
			};
            return parameters;
        }
    }
}
