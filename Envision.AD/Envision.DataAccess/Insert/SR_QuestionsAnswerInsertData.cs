using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_QuestionsAnswerInsertData : DataAccessBase
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public SR_QuestionsAnswerInsertData() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Insert;
        }

        public void Add()
        {

            ParameterList = buildParameter();
            //DataTable dtt = ExecuteDataTable();
            //return Convert.ToInt32(dtt.Rows[0][0].ToString());
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter pAnswer = Parameter();
            pAnswer.ParameterName = "@ANSWER";
            if (string.IsNullOrEmpty(SR_QUESTIONSANSWERS.ANSWER))
                pAnswer.Value = DBNull.Value;
            else
                pAnswer.Value = SR_QUESTIONSANSWERS.ANSWER;

            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	    , SR_QUESTIONSANSWERS.ACCESSION_NO) ,
				Parameter( "@Q_ID"              , SR_QUESTIONSANSWERS.Q_ID) ,
                //Parameter( "@Q_TYPE_ID"         , SR_QUESTIONSANSWERS.Q_TYPE_ID) ,
                Parameter( "@PART_ID"         , SR_QUESTIONSANSWERS.PART_ID) ,
                //Parameter( "@QUESTION_TEXT"     , SR_QUESTIONSANSWERS.QUESTION_TEXT) ,
                //Parameter( "@LABEL"             , SR_QUESTIONSANSWERS.LABEL),
                //Parameter( "@SPACE_BEGIN"       , SR_QUESTIONSANSWERS.SPACE_BEGIN),
                //Parameter( "@ANSWER"            , SR_QUESTIONSANSWERS.ANSWER),
                //pAnswer,
                //Parameter( "@IS_DEFAULT"        , SR_QUESTIONSANSWERS.IS_DEFAULT),
                //Parameter( "@IS_BOLD"           , SR_QUESTIONSANSWERS.IS_BOLD),
                //Parameter( "@IS_ITALIC"         , SR_QUESTIONSANSWERS.IS_ITALIC),
                //Parameter( "@IS_UNDERLINE"      , SR_QUESTIONSANSWERS.IS_UNDERLINE),
                Parameter( "@ORG_ID"	        , SR_QUESTIONSANSWERS.ORG_ID ), 
                Parameter( "@CREATED_BY"	    , SR_QUESTIONSANSWERS.CREATED_BY ), 
			};
            return parameters;
        }
    }
}
