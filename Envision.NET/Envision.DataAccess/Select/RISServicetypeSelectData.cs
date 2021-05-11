using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISServicetypeSelectData : DataAccessBase 
	{
        private bool selectAll;
		public  RISServicetypeSelectData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_SERVICETYPE_Select;
            selectAll = false;
		}
        public RISServicetypeSelectData(bool selectAll)
        {
            if(selectAll)
                StoredProcedureName = StoredProcedure.Prc_RIS_SERVICETYPE_SelectAll;
            else
                StoredProcedureName = StoredProcedure.Prc_RIS_SERVICETYPE_Select;
            this.selectAll = selectAll;
        }
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            if (selectAll)
            {
                ds = ExecuteDataSet();
            }
            else
            {
                ParameterList = buildParameter();
                ds = ExecuteDataSet();
            }
            
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

