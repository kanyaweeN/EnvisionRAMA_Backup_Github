using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class InvUnitReOrderLevelSelectData : DataAccessBase
    {

        public InvUnitReOrderLevelSelectData()
        {
            this.StoredProcedureName = StoredProcedure.Prc_INV_UNITREORDERLEVEL_Select;
        }

        public DataSet Query()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
