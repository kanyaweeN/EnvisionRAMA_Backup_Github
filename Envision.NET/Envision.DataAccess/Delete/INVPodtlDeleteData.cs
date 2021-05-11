using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_PODTLDeleteData : DataAccessBase 
	{
        public INV_PODTL INV_PODTL { get; set; }

        public INV_PODTLDeleteData()
		{
            INV_PODTL = new INV_PODTL();
            StoredProcedureName = StoredProcedure.Prc_INV_PODTL_Delete;
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
                                         Parameter("@PO_ID",INV_PODTL.PO_ID),
                                         Parameter("@ITEM_ID",INV_PODTL.ITEM_ID),
                                     };
            return parameters;
        }
	}
}

