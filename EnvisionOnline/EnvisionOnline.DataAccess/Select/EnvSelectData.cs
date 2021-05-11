using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
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
                                          Parameter("@ORG_ID"	, 1  )
                                       };
            return parameters;
        }
    }
}
