using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISSessionAppCountSelectData : DataAccessBase
    {

        public RISSessionAppCountSelectData()
        {
        }
        public DataSet GetData(string query, DateTime date_start, DateTime date_end)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(date_start,date_end);
            ds = ExecuteDataSetByString(query);
            return ds;
        }
        private DbParameter[] buildParameter(DateTime date_start,DateTime date_end)
        {
            DbParameter[] parameters ={			
                 Parameter("@APP_DATE_START",date_start)
                ,Parameter("@APP_DATE_END",date_end)
			};
            return parameters;
        }
    }
}
