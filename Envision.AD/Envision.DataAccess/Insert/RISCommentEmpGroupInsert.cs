using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISCommentEmpGroupInsert : DataAccessBase
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public RISCommentEmpGroupInsert()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
            RIS_COMMENTSYSTEM_GROUPDTL = new RIS_COMMENTSYSTEM_GROUPDTL();
        }

        public int Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_Insert;
            ParameterList = buildParameter();
            return Convert.ToInt32(ExecuteScalar().ToString());
        }

        public void AddEmpToGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUPDTL_Insert;
            ParameterList = buildParameterForEmpToGroup();
            ExecuteNonQuery();
        }
        

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@GROUP_NAME"	, RIS_COMMENTSYSTEM_GROUP.GROUP_NAME ) ,
                Parameter( "@GROUP_DESC"	, RIS_COMMENTSYSTEM_GROUP.GROUP_DESC ) ,
                Parameter( "@GROUP_TAG"	, RIS_COMMENTSYSTEM_GROUP.GROUP_TAG ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEM_GROUP.CREATED_BY ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForEmpToGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@GROUP_ID"	, RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID ) ,
                Parameter( "@EMP_ID"	, RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_COMMENTSYSTEM_GROUPDTL.CREATED_BY ) ,
            };
            return parameters;
        }
    }
}
