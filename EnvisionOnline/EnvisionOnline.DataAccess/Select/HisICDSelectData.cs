using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class HisICDSelectData : DataAccessBase
    {
        public HisICDSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HIS_ICD_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
