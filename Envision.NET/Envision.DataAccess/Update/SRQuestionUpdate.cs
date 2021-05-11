using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class SRQuestionUpdate : DataAccessBase
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }

        public SRQuestionUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONS_Update;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameter = { 
                                            Parameter("@Q_ID", SR_QUESTIONS.Q_ID),
                                            Parameter("@Q_TYPE_ID", SR_QUESTIONS.Q_TYPE_ID),
                                            Parameter("@PART_ID", SR_QUESTIONS.PART_ID),
                                            Parameter("@QUESTION_TEXT", SR_QUESTIONS.QUESTION_TEXT),
                                            Parameter("@QUESTION_SIDE", SR_QUESTIONS.QUESTION_SIDE),
                                            Parameter("@SPACE_BEGIN", SR_QUESTIONS.SPACE_BEGIN),
                                            Parameter("@IS_BOLD", SR_QUESTIONS.IS_BOLD),
                                            Parameter("@IS_ITALIC", SR_QUESTIONS.IS_ITALIC),
                                            Parameter("@IS_UNDERLINE", SR_QUESTIONS.IS_UNDERLINE),
                                            Parameter("@LABEL", SR_QUESTIONS.LABEL),
                                            Parameter("@DEFAULT_VALUE", SR_QUESTIONS.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", SR_QUESTIONS.IS_DEFAULT),
                                            Parameter("@ORG_ID", SR_QUESTIONS.ORG_ID),
                                            Parameter("@APPEND_NEXT", SR_QUESTIONS.APPEND_NEXT),
                                            Parameter("@LAST_MODIFIED_BY", SR_QUESTIONS.LAST_MODIFIED_BY),
                                      };
            return parameter;
        }
    }
}
