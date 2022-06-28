using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class SessionSelectData : DataAccessBase
    {
        public SessionSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_CheckSession;
        }

        public DataSet Get(int userid, int sptype)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(userid, sptype);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int user, int sp)
        {
            DbParameter[] parameters ={			
                Parameter( "@SP_TYPE"	, sp ),
                Parameter( "@EMP_ID"	, user ),
				Parameter( "@ORG_ID"	, new GBLEnvVariable().OrgID  )
			};
            return parameters;
        }

    }
}
