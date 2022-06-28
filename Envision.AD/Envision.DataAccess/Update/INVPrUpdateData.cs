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

namespace Envision.DataAccess.Update
{
	public class INVPrUpdateData : DataAccessBase 
	{
        public INV_PR INV_PR { get; set; }

		public  INVPrUpdateData()
		{
            INV_PR = new INV_PR();
			StoredProcedureName = StoredProcedure.Prc_INV_PR_Update;
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
Parameter("@PR_ID",INV_PR.PR_ID)
,Parameter("@PR_UID",INV_PR.PR_UID)
,Parameter("@LAST_MODIFIED_BY",INV_PR.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

