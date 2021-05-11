using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_REQUISITIONDTLDeleteData : DataAccessBase 
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }

        public INV_REQUISITIONDTLDeleteData()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITIONDTL_Delete;
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
                                         Parameter("@REQUISITION_ID",INV_REQUISITIONDTL.REQUISITION_ID),
                                         Parameter("@ITEM_ID",INV_REQUISITIONDTL.ITEM_ID)
                                     };
            return parameters;
        }
	}
}

