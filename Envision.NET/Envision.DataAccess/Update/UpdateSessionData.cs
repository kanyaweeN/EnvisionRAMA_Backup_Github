using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class UpdateSessionData : DataAccessBase
    {
       
        public GBL_SESSION GBL_SESSION { get; set; }

        public UpdateSessionData()
        {
            GBL_SESSION = new GBL_SESSION();
            StoredProcedureName = StoredProcedure.Prc_CloseSession;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@SESSION_GUID"	, GBL_SESSION.SESSION_GUID ) ,
                Parameter( "@SESSION_STAT"	, GBL_SESSION.SESSION_STAT) ,
                                      };
            return parameters;
        }
    }
}
