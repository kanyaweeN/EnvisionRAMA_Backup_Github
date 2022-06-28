using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISContrastDtlDeleteData: DataAccessBase 
    {
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }

        public RISContrastDtlDeleteData()
		{
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTDTL_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@CONTRASTDTL_ID",RIS_CONTRASTDTL.CONTRASTDTL_ID),
                                     };
            return parameters;
        }
    }
}
