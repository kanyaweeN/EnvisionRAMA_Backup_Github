using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLGeneralDtlDeleteData : DataAccessBase 
	{
        public GBL_GENERALDTL GBL_GENERALDTL { get; set; }

        public GBLGeneralDtlDeleteData()
		{
            GBL_GENERALDTL = new GBL_GENERALDTL();
            StoredProcedureName = StoredProcedure.Prc_GBL_GENERALDTL_Delete;
		}
		
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@GEN_DTL_ID", GBL_GENERALDTL.GEN_DTL_ID) 
                                       };
            return parameters;
        }
	}
}

