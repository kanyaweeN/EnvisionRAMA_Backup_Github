using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.DataAccess.Select
{
    public class HolidaySelectData : DataAccessBase
    {
        public HolidaySelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_Holiday_Select;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
