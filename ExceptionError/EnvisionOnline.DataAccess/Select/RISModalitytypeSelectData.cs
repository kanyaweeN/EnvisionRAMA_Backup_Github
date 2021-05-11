using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISModalitytypeSelectData : DataAccessBase
    {
        public RISModalitytypeSelectData(bool is_online)
        {

            StoredProcedureName = is_online ? StoredProcedure.Prc_RIS_MODALITYTYPE_SelectOnline : StoredProcedure.Prc_RIS_MODALITYTYPE_Select;
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
                Parameter("@ORG_ID",1)
			};
            return parameters;
        }
    }
}

