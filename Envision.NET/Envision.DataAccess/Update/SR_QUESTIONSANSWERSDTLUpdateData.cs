using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class SR_QUESTIONSANSWERSDTLUpdateData : DataAccessBase 
    {
        public SR_QUESTIONSANSWERSDTL SR_QUESTIONSANSWERSDTL { get; set; }

        public SR_QUESTIONSANSWERSDTLUpdateData() {
            SR_QUESTIONSANSWERSDTL = new SR_QUESTIONSANSWERSDTL();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERSDTL_Update;
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
                Parameter( "@ACCESSION_NO"	, SR_QUESTIONSANSWERSDTL.ACCESSION_NO) ,
                Parameter( "@Q_ID"	        , SR_QUESTIONSANSWERSDTL.Q_ID) ,
                Parameter( "@Q_ID_DTL"	    , SR_QUESTIONSANSWERSDTL.Q_ID_DTL) ,
				Parameter( "@ANSWER"        , SR_QUESTIONSANSWERSDTL.ANSWER) 
			};
            return parameters;
        }
    }
}
