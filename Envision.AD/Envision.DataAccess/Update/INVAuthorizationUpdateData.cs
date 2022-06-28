//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    14/01/2552 02:19:18
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class INVAuthorizationUpdateData : DataAccessBase 
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }

		public  INVAuthorizationUpdateData()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
			StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();        
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@AUTH_ID",INV_AUTHORIZATION.AUTH_ID)
,Parameter("@EMP_ID",INV_AUTHORIZATION.EMP_ID)
,Parameter("@QTY",INV_AUTHORIZATION.QTY)
,Parameter("@LAST_MODIFIED_BY",INV_AUTHORIZATION.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

