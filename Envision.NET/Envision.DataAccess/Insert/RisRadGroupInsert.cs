using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RisRadGroupInsert : DataAccessBase
    {
        public RIS_PRGROUP RIS_PRGROUP { get; set; }
        public RIS_PRGROUPDTL RIS_PRGROUPDTL { get; set; }

        public RisRadGroupInsert()
        {
            RIS_PRGROUP = new RIS_PRGROUP();
            RIS_PRGROUPDTL = new RIS_PRGROUPDTL();
        }

        public int Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_Insert;
            ParameterList = buildParameter();
            return Convert.ToInt32(ExecuteScalar().ToString());
        }

        public void AddEmpToGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUPDTL_Insert;
            ParameterList = buildParameterForEmpToGroup();
            ExecuteNonQuery();
        }


        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_NAME"	, RIS_PRGROUP.PR_GROUP_NAME ) ,
                Parameter( "@ORG_ID"	    , RIS_PRGROUP.ORG_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_PRGROUP.CREATED_BY ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForEmpToGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_ID"	    , RIS_PRGROUPDTL.PR_GROUP_ID ) ,
                Parameter( "@RAD_ID"	    , RIS_PRGROUPDTL.RAD_ID ) ,
                Parameter( "@ORG_ID"	    , RIS_PRGROUP.ORG_ID ) ,
                Parameter( "@CREATED_BY"	, RIS_PRGROUPDTL.CREATED_BY ) ,
            };
            return parameters;
        }
    }
}
