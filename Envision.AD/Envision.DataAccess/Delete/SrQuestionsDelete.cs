using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class SrQuestionsDelete : DataAccessBase
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }
        public SrQuestionsDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONS_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameter = { 
                                            Parameter("@Q_ID", SR_QUESTIONS.Q_ID),
                                            Parameter("@ORG_ID", SR_QUESTIONS.ORG_ID),
                                      };
            return parameter;
        }
    }
}
