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

namespace Envision.DataAccess.Insert
{
	public class INVAuthorizationInsertData : DataAccessBase 
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }

		public  INVAuthorizationInsertData()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
			StoredProcedureName = StoredProcedure.Prc_INV_AUTHORIZATION_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@PR_ID",INV_AUTHORIZATION.PR_ID)
,Parameter("@ITEM_ID",INV_AUTHORIZATION.ITEM_ID)
,Parameter("@EMP_ID",INV_AUTHORIZATION.EMP_ID)
,Parameter("@QTY",INV_AUTHORIZATION.QTY)
,Parameter("@ORG_ID",INV_AUTHORIZATION.ORG_ID)
,Parameter("@CREATED_BY",INV_AUTHORIZATION.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_AUTHORIZATION.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

