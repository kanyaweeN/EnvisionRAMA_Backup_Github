using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class SRQuestionsInsert : DataAccessBase
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }
        public SRQuestionsInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONS_Insert;
        }
        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            DataTable dtt = this.ExecuteDataTable();
            if (dtt.Rows.Count > 0)
            {
                this.SR_QUESTIONS.Q_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());
            }
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] _parameters = { 
                                            Parameter("@Q_TYPE_ID", this.SR_QUESTIONS.Q_TYPE_ID),
                                            Parameter("@PART_ID", this.SR_QUESTIONS.PART_ID),
                                            Parameter("@QUESTION_TEXT", this.SR_QUESTIONS.QUESTION_TEXT),
                                            Parameter("@QUESTION_SIDE", this.SR_QUESTIONS.QUESTION_SIDE),
                                            Parameter("@SPACE_BEGIN", this.SR_QUESTIONS.SPACE_BEGIN),
                                            Parameter("@IS_BOLD", this.SR_QUESTIONS.IS_BOLD),
                                            Parameter("@IS_ITALIC", this.SR_QUESTIONS.IS_ITALIC),
                                            Parameter("@IS_UNDERLINE", this.SR_QUESTIONS.IS_UNDERLINE),
                                            Parameter("@LABEL", this.SR_QUESTIONS.LABEL),
                                            Parameter("@DEFAULT_VALUE", this.SR_QUESTIONS.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", this.SR_QUESTIONS.IS_DEFAULT),
                                            Parameter("@ORG_ID", this.SR_QUESTIONS.ORG_ID),
                                            Parameter("@CREATED_BY", this.SR_QUESTIONS.CREATED_BY),
                                            Parameter("@APPEND_NEXT", this.SR_QUESTIONS.APPEND_NEXT),
                                        };
            return _parameters;
        }
    }
}
