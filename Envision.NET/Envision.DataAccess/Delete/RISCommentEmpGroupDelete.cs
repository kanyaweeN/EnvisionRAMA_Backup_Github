using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISCommentEmpGroupDelete : DataAccess.DataAccessBase
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public RISCommentEmpGroupDelete()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
            RIS_COMMENTSYSTEM_GROUPDTL = new RIS_COMMENTSYSTEM_GROUPDTL();
        }

        public void DeleteEmp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUPDTL_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        public void DeleteGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_Delete;
            ParameterList = buildParameterForDeleteGroup();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@GROUP_ID"	, RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForDeleteGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@GROUP_ID"	, RIS_COMMENTSYSTEM_GROUP.GROUP_ID ) ,
            };
            return parameters;
        }
    }
}
