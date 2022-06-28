using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantObjectSelectData : DataAccessBase
    {
         public string UUID{get;set;}

        public GBLGrantObjectSelectData()
        {
            UUID = string.Empty;
            StoredProcedureName = StoredProcedure.GBLGrantObject_Select;
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
                                             Parameter( "@p_uuid"	        , UUID ),
                                             Parameter( "@p_orgid"		    , new GBLEnvVariable().OrgID ) ,
                                       };
            return parameters;
        }
    }
}
