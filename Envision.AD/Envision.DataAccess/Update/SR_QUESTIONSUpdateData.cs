using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class SR_QUESTIONSUpdateData : DataAccessBase 
    {
        public SR_QUESTIONS SR_QUESTIONS { get; set; }

        public SR_QUESTIONSUpdateData() {
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONS_Update;
            SR_QUESTIONS = new SR_QUESTIONS();
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
                Parameter( "@Q_ID"	        , SR_QUESTIONS.Q_ID) ,
				Parameter( "@Q_TYPE_ID"     , SR_QUESTIONS.Q_TYPE_ID) ,
				Parameter( "@LABEL"	        , SR_QUESTIONS.LABEL) ,
                Parameter( "@DEFAULT_VALUE"	, SR_QUESTIONS.DEFAULT_VALUE ) ,
				Parameter( "@IS_DEFAULT"    , SR_QUESTIONS.IS_DEFAULT ) ,
				Parameter( "@ORG_ID"        , SR_QUESTIONS.ORG_ID),
                Parameter( "@LAST_MODIFIED_BY"	, SR_QUESTIONS.LAST_MODIFIED_BY ), 
			};
            return parameters;
        }
    }
}
