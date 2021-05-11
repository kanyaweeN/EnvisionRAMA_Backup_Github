using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
	public class INV_PODeleteData : DataAccessBase 
	{
        public INV_PO INV_PO { get; set; }

        public INV_PODeleteData()
		{
            INV_PO = new INV_PO();
            StoredProcedureName = StoredProcedure.Prc_INV_PO_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@PO_ID",INV_PO.PO_ID),
                                     };
            return parameters;
        }
	}
}

