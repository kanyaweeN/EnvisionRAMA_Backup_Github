using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class MGBreastMarkDtlDelete : DataAccessBase
    {
        public MG_BREASTMARKDTL MG_BREASTMARKDTL { get; set; } 
        public DbTransaction Trans { get; set; }
        public MGBreastMarkDtlDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKDTL_DELETE;
        }
        public void DeleteData(bool isUseTransaction, int mode)
        {
            this.ParameterList = this.BuildParameters(mode);
            if (isUseTransaction && (Transaction != null))
                this.Transaction = this.Trans;
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters(int mode)
        {
            DbParameter[] parameters = { 
                                            Parameter("@BREAST_MARKDTL_ID", MG_BREASTMARKDTL.BREAST_MARKDTL_ID),
                                            Parameter("@BREAST_MARK_ID", MG_BREASTMARKDTL.BREAST_MARK_ID),
                                            Parameter("@MODE", mode)
                                       };

            return parameters;
        }
    }
}
