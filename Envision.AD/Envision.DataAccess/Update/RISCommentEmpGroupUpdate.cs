using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISCommentEmpGroupUpdate : DataAccessBase
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }

        public RISCommentEmpGroupUpdate()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
        }

        public void UpdateGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_Update;
            ParameterList = buildParameterForUpdateGroup();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameterForUpdateGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@GROUP_ID"	    , RIS_COMMENTSYSTEM_GROUP.GROUP_ID ) ,
                Parameter( "@GROUP_NAME"	, RIS_COMMENTSYSTEM_GROUP.GROUP_NAME ) ,
                Parameter( "@GROUP_DESC"	, RIS_COMMENTSYSTEM_GROUP.GROUP_DESC ) ,
                Parameter( "@GROUP_TAG"	    , RIS_COMMENTSYSTEM_GROUP.GROUP_TAG ) ,
                Parameter( "@LAST_MODIFIED_BY"	, RIS_COMMENTSYSTEM_GROUP.LAST_MODIFIED_BY ) ,
            };
            return parameters;
        }
    }
}
