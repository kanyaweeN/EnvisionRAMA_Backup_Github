using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_AUTHORIZATIONDeleteData : DataAccessBase 
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }

        public INV_AUTHORIZATIONDeleteData()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Delete;
		}
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Delete(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@AUTH_ID",INV_AUTHORIZATION.AUTH_ID)
                                     };
            return parameters;
        }
	}
}

