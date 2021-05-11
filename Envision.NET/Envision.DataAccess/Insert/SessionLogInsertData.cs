using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class SessionLogInsertData : DataAccessBase
    {
        public GBL_SESSIONLOG GBL_SESSIONLOG { get; set; }

        public SessionLogInsertData()
        {
            GBL_SESSIONLOG = new GBL_SESSIONLOG();
            StoredProcedureName = StoredProcedure.Prc_SessionLog_IN_OUT;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter() {
            DbParameter[] parameters =
		    {
				Parameter( "@SP_TYPE"	            , GBL_SESSIONLOG.SP_TYPE ) ,
				Parameter( "@SESSION_GUID"          , GBL_SESSIONLOG.SESSION_GUID ) ,
				Parameter( "@SUBMENU_ID"	        , GBL_SESSIONLOG.SUBMENU_ID ) ,
				Parameter( "@ORG_ID"	            , GBL_SESSIONLOG.ORG_ID) ,
				Parameter( "@CREATED_BY"		    , GBL_SESSIONLOG.CREATED_BY) ,
			};
            return parameters;
        }
    }
}
