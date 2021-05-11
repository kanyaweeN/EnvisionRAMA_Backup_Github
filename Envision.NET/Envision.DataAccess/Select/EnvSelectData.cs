using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class EnvSelectData : DataAccessBase
    {
        public EnvSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_GBLEnv;
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
            DbParameter[] parameters = { 
                                          Parameter("@ORG_ID"	, new GBLEnvVariable().OrgID  )
                                       };
            return parameters;
        }
    }
}
