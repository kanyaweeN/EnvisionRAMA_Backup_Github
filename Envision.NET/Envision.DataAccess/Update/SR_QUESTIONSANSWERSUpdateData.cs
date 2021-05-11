using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class SR_QUESTIONSANSWERSUpdateData : DataAccessBase 
    {
        public SR_QUESTIONSANSWERS SR_QUESTIONSANSWERS { get; set; }

        public SR_QUESTIONSANSWERSUpdateData() {
            SR_QUESTIONSANSWERS = new SR_QUESTIONSANSWERS();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Update;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	, SR_QUESTIONSANSWERS.ACCESSION_NO) ,
                Parameter( "@Q_ID"	        , SR_QUESTIONSANSWERS.Q_ID) ,
				Parameter( "@ANSWER"        , SR_QUESTIONSANSWERS.ANSWER) 
			};
            return parameters;
        }

        public void ClearAnswer() {
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERS_Clear ;
            ParameterList = buildParameterClear();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameterClear()
        {
            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	, SR_QUESTIONSANSWERS.ACCESSION_NO) ,
                //Parameter( "@Q_ID"	        , SR_QUESTIONSANSWERS.Q_ID) ,
                //Parameter( "@ANSWER"        , SR_QUESTIONSANSWERS.ANSWER) 
			};
            return parameters;
        }
    }
}
