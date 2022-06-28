using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_PRDTLDeleteData : DataAccessBase 
	{
        public INV_PRDTL INV_PRDTL { get; set; }

        public INV_PRDTLDeleteData()
		{
            INV_PRDTL = new INV_PRDTL();
            StoredProcedureName = StoredProcedure.Prc_INV_PRDTL_Delete;
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
                                         Parameter("@PR_ID",INV_PRDTL.PR_ID),
                                         Parameter("@ITEM_ID",INV_PRDTL.ITEM_ID)
                                     };
            return parameters;
        }
	}
}

