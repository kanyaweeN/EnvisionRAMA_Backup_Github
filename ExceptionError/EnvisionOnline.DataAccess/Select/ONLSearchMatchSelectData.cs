using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ONLSearchMatchSelectData: DataAccessBase
    {

        public ONLSearchMatchSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_SearchMatch_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();

                ParameterList = buildParameter();
                ds = ExecuteDataSet();

            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			

			};
            return parameters;
        }
    }
}
