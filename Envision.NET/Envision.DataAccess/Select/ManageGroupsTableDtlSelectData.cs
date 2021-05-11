using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ManageGroupsTableDtlSelectData : DataAccessBase
    {
        public GBL_GROUP GBL_GROUP { get; set; }
        public ManageGroupsTableDtlSelectData()
        {
            GBL_GROUP = new GBL_GROUP();
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_SelectGroupsDtlTable;
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
