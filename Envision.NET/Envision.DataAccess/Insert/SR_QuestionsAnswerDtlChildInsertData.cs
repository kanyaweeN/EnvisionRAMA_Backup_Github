using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_QuestionsAnswerDtlChildInsertData : DataAccessBase
    {
        public SR_QUESTIONSANSWERSDTLCHILD SR_QUESTIONSANSWERSDTLCHILD { get; set; }
        public SR_QuestionsAnswerDtlChildInsertData(){
            SR_QUESTIONSANSWERSDTLCHILD = new SR_QUESTIONSANSWERSDTLCHILD();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERSDTLCHILD_Insert;
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
            if (string.IsNullOrEmpty(SR_QUESTIONSANSWERSDTLCHILD.ANSWER))
                pAnswer.Value = DBNull.Value;
            else
                pAnswer.Value = SR_QUESTIONSANSWERSDTLCHILD.ANSWER;

            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	    , SR_QUESTIONSANSWERSDTLCHILD.ACCESSION_NO) ,
				Parameter( "@Q_ID"              , SR_QUESTIONSANSWERSDTLCHILD.Q_ID) ,
                Parameter( "@Q_ID_DTL"          , SR_QUESTIONSANSWERSDTLCHILD.Q_ID_DTL) ,
                Parameter( "@Q_ID_DTL_CHD"          , SR_QUESTIONSANSWERSDTLCHILD.Q_ID_DTL_CHD) ,
                pAnswer,
                Parameter( "@ORG_ID"	        , SR_QUESTIONSANSWERSDTLCHILD.ORG_ID ), 
                Parameter( "@CREATED_BY"	    , SR_QUESTIONSANSWERSDTLCHILD.CREATED_BY ), 
			};
            return parameters;
        }
    }
}
