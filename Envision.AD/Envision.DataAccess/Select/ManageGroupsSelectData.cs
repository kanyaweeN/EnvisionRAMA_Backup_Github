using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ManageGroupsSelectData : DataAccessBase
    {
        public GBL_GROUP GBL_GROUP { get; set; }

        public ManageGroupsSelectData()
        {
            GBL_GROUP = new GBL_GROUP();
            StoredProcedureName = StoredProcedure.Prc_ManageGroups_Select;
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
                                                    Parameter( "@GroupType"	    , GBL_GROUP.GROUP_TYPE ),
                                       };
            return parameters;
        }
    }
}
