using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;


namespace Envision.DataAccess.Update
{
    public class ACEvaluationUpdateData : DataAccessBase 
    {
        public AC_EVALUATION AC_EVALUATION { get; set; }

                public ACEvaluationUpdateData()
		{
            AC_EVALUATION = new AC_EVALUATION();
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {

            DbParameter[] parameters ={
Parameter("@ASSIGNMENT_ID",AC_EVALUATION.ASSIGNMENT_ID)
,Parameter("@EVALUATED_BY",AC_EVALUATION.EVALUATED_BY)
,Parameter("@GRADE_ID",AC_EVALUATION.GRADE_ID)
,Parameter("@IS_CLINICALLY_SIGNIFICANT",AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT)
,Parameter("@COMMENTS",AC_EVALUATION.COMMENTS)
,Parameter("@LAST_MODIFIED_BY",AC_EVALUATION.LAST_MODIFIED_BY)
,Parameter("@LANGUAGE_OF_REPORT",AC_EVALUATION.LANGUAGE_OF_REPORT)
,Parameter("@LANGUAGE_OF_REPORT_COMMENTS",AC_EVALUATION.LANGUAGE_OF_REPORT_COMMENTS)
                                      };
            return parameters;
        }
    }
}
