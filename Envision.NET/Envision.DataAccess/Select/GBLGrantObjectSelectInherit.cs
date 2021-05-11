using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantObjectSelectInherit : DataAccessBase
    {
        public string UUID
        {
            get;
            set;
        }
        public int Type
        {
            get;
            set;
        }

        public GBLGrantObjectSelectInherit()
        {
            UUID="0";
            Type=0;
            StoredProcedureName = StoredProcedure.GBLGrantObject_Inherit;
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
                                                 Parameter( "@p_uuid", Int32.Parse(UUID)),
				                                 Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID ),
                                                 Parameter( "@p_type"	,Type)
                                       };
            return parameters;
        }
        
    }
}
