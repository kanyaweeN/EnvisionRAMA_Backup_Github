using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinictypeSelectData : DataAccessBase
    {
        public RISClinictypeSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICTYPE_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}

