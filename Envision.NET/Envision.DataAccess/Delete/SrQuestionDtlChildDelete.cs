using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class SrQuestionDtlChildDelete : DataAccessBase
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public SrQuestionDtlChildDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTLCHILD_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@Q_ID_DTL_CHD", SR_QUESTIONSDTLCHILD.Q_ID_DTL_CHD),
                                            Parameter("@ORG_ID", SR_QUESTIONSDTLCHILD.ORG_ID)
                                       };
            return parameters;
        }
    }
}
