using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class ManageGroupsDeleteData : DataAccessBase
    {
        public GBL_GROUP GBL_GROUP { get; set; }

        public ManageGroupsDeleteData()
        {
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_Delete;
            GBL_GROUP = new GBL_GROUP();
        }

        public void Set()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Set(DbTransaction tran)
        {
            Transaction = tran;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@Gid",GBL_GROUP.GROUP_ID)
                                     };
            return parameters;
        }
    }
}
