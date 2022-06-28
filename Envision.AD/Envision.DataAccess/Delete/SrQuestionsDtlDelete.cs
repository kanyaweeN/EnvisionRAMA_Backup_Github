using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class SrQuestionsDtlDelete : DataAccessBase
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }
        public SrQuestionsDtlDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTL_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameter = { 
                                            Parameter("@Q_ID_DTL", SR_QUESTIONSDTL.Q_ID_DTL),
                                            Parameter("@ORG_ID", SR_QUESTIONSDTL.ORG_ID),
                                      };
            return parameter;
        }
    }
}
