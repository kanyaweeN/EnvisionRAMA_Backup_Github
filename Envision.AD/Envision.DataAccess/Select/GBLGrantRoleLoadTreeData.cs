using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantRoleLoadTreeData : DataAccessBase
    {
       

        public GBLGrantRoleLoadTreeData()
        {
            StoredProcedureName = StoredProcedure.GBLGrantRole_LoadTree;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }

        public int Type
        {
            get;
            set;
        }
        public int SubType
        {
            get;
            set;
        }
        public int ParentId
        {
            get;
            set;
        }
        public int ChildId
        {
            get;
            set;
        }
        public string Search
        {
            get;
            set;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
				                                     Parameter("@p_type", Type),
                                                     Parameter("@p_sub_type", SubType),
                                                     Parameter("@p_pid",ParentId),
                                                     Parameter("@p_cid",ChildId),
                                                     Parameter("@p_search",Search),
				                                     Parameter( "@p_orgid"	, new GBLEnvVariable().OrgID )
                                       };
            return parameters;
        }
    }
}
