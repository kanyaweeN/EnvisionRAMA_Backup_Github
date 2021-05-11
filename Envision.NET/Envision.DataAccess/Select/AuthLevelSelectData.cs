using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class AuthLevelSelectData : DataAccessBase
    {
        public int EMP_ID{get;set;}

        public AuthLevelSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RadiologistAuthLevel;
        }

        public DataSet Get(int emp)
        {
            EMP_ID = emp;
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;

        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID",EMP_ID),
                                          Parameter("@ORG_ID",new GBLEnvVariable().OrgID ),
                                       };
            return parameters;
        }
    }
}
