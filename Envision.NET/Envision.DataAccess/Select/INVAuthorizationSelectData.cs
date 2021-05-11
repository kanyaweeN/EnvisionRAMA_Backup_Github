using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class INVAuthorizationSelectData : DataAccessBase 
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }

		public  INVAuthorizationSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Select;
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
            DbParameter[] parameters = { 
                                                Parameter("@PR_ID",INV_AUTHORIZATION.PR_ID)
                                       };
            return parameters;
        }
	}
}

