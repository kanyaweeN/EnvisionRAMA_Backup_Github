using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISModalitytypeSelectData : DataAccessBase 
	{
		public  RISModalitytypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYTYPE_Select;
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
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
			};
            return parameters;
        }
	}
}

