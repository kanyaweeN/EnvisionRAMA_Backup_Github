using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantRoleSelectDataByRole : DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }

        public GBLGrantRoleSelectDataByRole()
        {
            GBL_GRANTROLE = new GBL_GRANTROLE();
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_SelectByRole;
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
				                                     Parameter("@Roleid", GBL_GRANTROLE.ROLE_ID),
                                       };
            return parameters;
        }
    }
}
