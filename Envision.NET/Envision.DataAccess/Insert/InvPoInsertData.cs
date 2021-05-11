//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class INVPoInsertData : DataAccessBase 
	{
        public INV_PO INV_PO { get; set; }
        int _id = 0;
		public  INVPoInsertData()
		{
            INV_PO = new INV_PO();
			StoredProcedureName = StoredProcedure.Prc_INV_PO_Insert;
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
            DbParameter param1 = Parameter("@PO_ID", INV_PO.PR_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
param1
,Parameter("@PO_UID",INV_PO.PO_UID)
,Parameter("@PR_ID",INV_PO.PR_ID)
,Parameter("@VENDOR_ID",INV_PO.VENDOR_ID)
,Parameter("@TOC",INV_PO.TOC)
,Parameter("@ORG_ID",INV_PO.ORG_ID)
,Parameter("@CREATED_BY",INV_PO.CREATED_BY)
,Parameter("@LAST_MODIFIED_BY",INV_PO.LAST_MODIFIED_BY)
            };
            return parameters;
        }
	}
}

