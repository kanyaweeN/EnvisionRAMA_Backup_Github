//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    23/12/2551 12:15:50
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class INVPrInsertData : DataAccessBase 
	{
        public INV_PR INV_PR { get; set; }
        int _id = 0;
		public  INVPrInsertData()
		{
            INV_PR = new INV_PR();
			StoredProcedureName = StoredProcedure.Prc_INV_PR_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@PR_ID", INV_PR.PR_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
param1
,Parameter("@PR_UID",INV_PR.PR_UID)
,Parameter("@GENERATED_BY",INV_PR.GENERATED_BY)
,Parameter("@ORG_ID",INV_PR.ORG_ID)
,Parameter("@CREATED_BY",INV_PR.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_PR.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

