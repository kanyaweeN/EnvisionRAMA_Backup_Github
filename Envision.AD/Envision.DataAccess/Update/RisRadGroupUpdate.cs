using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RisRadGroupUpdate : DataAccessBase
    {
        public RIS_PRGROUP RIS_PRGROUP { get; set; }

        public RisRadGroupUpdate()
        {
            RIS_PRGROUP = new RIS_PRGROUP();
        }

        public void UpdateGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_Update;
            ParameterList = buildParameterForUpdateGroup();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameterForUpdateGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_ID"	    , RIS_PRGROUP.PR_GROUP_ID ) ,
                Parameter( "@PR_GROUP_NAME"	    , RIS_PRGROUP.PR_GROUP_NAME ) ,
                Parameter( "@ORG_ID"	        , RIS_PRGROUP.ORG_ID ) ,
                Parameter( "@LAST_MODIFIED_BY"	, RIS_PRGROUP.LAST_MODIFIED_BY ) ,
            };
            return parameters;
        }
    }
}
