using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class MGBreastMarkDelete : DataAccessBase
    {
        public MG_BREASTMARK MG_BREASTMARK { get; set; } 
        public DbTransaction Trans { get; set; }
        public MGBreastMarkDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARK_DELETE;
        }
        public void DeleteData(bool isUseTransaction)
        {
            this.ParameterList = this.BuildParameters();
            if (isUseTransaction && (Transaction != null))
                this.Transaction = this.Trans;
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@BREAST_MARK_ID", MG_BREASTMARK.BREAST_MARK_ID)
                                       };

            return parameters;
        }
    }
}
