using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ManageGroupsTableSelectData : DataAccessBase
    {
        public GBL_GROUP GBL_GROUP { get; set; }

        public ManageGroupsTableSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_SelectGroupsTable;
            GBL_GROUP = new GBL_GROUP();
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
                                                    Parameter( "@Gid"	    , GBL_GROUP.GROUP_ID ),
                                       };
            return parameters;
        }
    }
}
