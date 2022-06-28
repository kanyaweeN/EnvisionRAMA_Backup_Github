using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RisRadGroupDelete : DataAccessBase
    {
        public RIS_PRGROUP RIS_PRGROUP { get; set; }
        public RIS_PRGROUPDTL RIS_PRGROUPDTL { get; set; }

        public RisRadGroupDelete()
        {
            RIS_PRGROUP = new RIS_PRGROUP();
            RIS_PRGROUPDTL = new RIS_PRGROUPDTL();
        }

        public void DeleteEmp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUPDTL_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        public void DeleteGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_Delete;
            ParameterList = buildParameterForDeleteGroup();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_ID"	, RIS_PRGROUPDTL.PR_GROUP_ID ) ,
            };
            return parameters;
        }

        private DbParameter[] buildParameterForDeleteGroup()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_ID"	, RIS_PRGROUP.PR_GROUP_ID ) ,
            };
            return parameters;
        }
    }
}
