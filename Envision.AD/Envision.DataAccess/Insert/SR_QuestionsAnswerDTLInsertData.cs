using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_QuestionsAnswerDTLInsertData : DataAccessBase
    {
        public SR_QUESTIONSANSWERSDTL SR_QUESTIONSANSWERSDTL { get; set; }

        public SR_QuestionsAnswerDTLInsertData() {
            SR_QUESTIONSANSWERSDTL = new SR_QUESTIONSANSWERSDTL();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERSDTL_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter pAnswer = Parameter();
            pAnswer.ParameterName = "@ANSWER";
            if (string.IsNullOrEmpty(SR_QUESTIONSANSWERSDTL.ANSWER))
                pAnswer.Value = DBNull.Value;
            else
                pAnswer.Value = SR_QUESTIONSANSWERSDTL.ANSWER;

            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	    , SR_QUESTIONSANSWERSDTL.ACCESSION_NO) ,
				Parameter( "@Q_ID"              , SR_QUESTIONSANSWERSDTL.Q_ID) ,
                Parameter( "@Q_ID_DTL"          , SR_QUESTIONSANSWERSDTL.Q_ID_DTL) ,
                pAnswer,
                Parameter( "@ORG_ID"	        , SR_QUESTIONSANSWERSDTL.ORG_ID ), 
                Parameter( "@CREATED_BY"	    , SR_QUESTIONSANSWERSDTL.CREATED_BY ), 
			};
            return parameters;
        }
    }
}
