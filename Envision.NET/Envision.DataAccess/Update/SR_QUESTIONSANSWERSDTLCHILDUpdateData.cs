using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class SR_QUESTIONSANSWERSDTLCHILDUpdateData : DataAccessBase 
    {
        public SR_QUESTIONSANSWERSDTLCHILD SR_QUESTIONSANSWERSDTLCHILD { get; set; }

        public SR_QUESTIONSANSWERSDTLCHILDUpdateData() {
            SR_QUESTIONSANSWERSDTLCHILD = new SR_QUESTIONSANSWERSDTLCHILD();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSANSWERSDTLCHILD_Update;
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
                Parameter( "@ACCESSION_NO"	, SR_QUESTIONSANSWERSDTLCHILD.ACCESSION_NO) ,
                Parameter( "@Q_ID"	        , SR_QUESTIONSANSWERSDTLCHILD.Q_ID) ,
                Parameter( "@Q_ID_DTL"	    , SR_QUESTIONSANSWERSDTLCHILD.Q_ID_DTL) ,
                Parameter( "@Q_ID_DTL_CHD"	, SR_QUESTIONSANSWERSDTLCHILD.Q_ID_DTL_CHD) ,
				Parameter( "@ANSWER"        , SR_QUESTIONSANSWERSDTLCHILD.ANSWER) 
			};
            return parameters;
        }
    }
}
