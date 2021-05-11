using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISAuthlevelSelectData : DataAccessBase
    {
        public RISAuthlevelSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_AUTHLEVEL_Select;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
