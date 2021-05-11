using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_REQUISITIONDeleteData : DataAccessBase 
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }

        public INV_REQUISITIONDeleteData()
		{
            INV_REQUISITION = new INV_REQUISITION();
            StoredProcedureName = StoredProcedure.Prc_INV_REQUISITION_Delete;
		}
	
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@REQUISITION_ID",INV_REQUISITION.REQUISITION_ID),
                                     };
            return parameters;
        }
	}
}

