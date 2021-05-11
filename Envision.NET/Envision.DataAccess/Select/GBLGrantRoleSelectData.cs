using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantRoleSelectData : DataAccessBase
    {
        public GBLGrantRoleSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_Select;
        }
        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

    }
}
