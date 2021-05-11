using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLGrantObjectDeleteData :DataAccessBase
    {
        public string GrantID { get; set; }

        public GBLGrantObjectDeleteData()
        {
            GrantID = "0";
            StoredProcedureName = StoredProcedure.GBLGrantObject_Delete;
        }

        public void Get()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
       
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@p_modify_by"	,  new GBLEnvVariable().UserID),
                                            Parameter("@p_orgid"		,  new GBLEnvVariable().OrgID),
                                            Parameter("@p_delete"		,  Int32.Parse(GrantID))
                                       };
            return parameters;
        }
    }
}
