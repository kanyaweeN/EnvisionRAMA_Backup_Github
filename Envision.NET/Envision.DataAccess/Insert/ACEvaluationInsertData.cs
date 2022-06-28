using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
   public  class ACEvaluationInsertData: DataAccessBase 
    {
              public AC_EVALUATION AC_EVALUATION { get; set; }
        int _id = 0;
        public ACEvaluationInsertData()
		{
            AC_EVALUATION = new AC_EVALUATION();
            StoredProcedureName = StoredProcedure.Prc_AC_EVALUATION_Insert_New;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter _EVALUATION_ID = Parameter("@EVALUATION_ID", AC_EVALUATION.EVALUATION_ID);
            _EVALUATION_ID.Direction = ParameterDirection.Output;

            DbParameter _GRADE_ID = Parameter();
            _GRADE_ID.ParameterName = "@GRADE_ID";
            if (AC_EVALUATION.GRADE_ID == null)
                _GRADE_ID.Value = DBNull.Value;
            else
                _GRADE_ID.Value = AC_EVALUATION.GRADE_ID == 0 ? (object)DBNull.Value : AC_EVALUATION.GRADE_ID;

            DbParameter[] parameters ={
_EVALUATION_ID
,Parameter("@ASSIGNMENT_ID",AC_EVALUATION.ASSIGNMENT_ID)
,Parameter("@REPORT_TYPE",AC_EVALUATION.REPORT_TYPE)
,Parameter("@REPORT_TEXT",AC_EVALUATION.REPORT_TEXT)
,Parameter("@COMMENTS",AC_EVALUATION.COMMENTS)
,Parameter("@EVALUATED_BY",AC_EVALUATION.EVALUATED_BY)
,Parameter("@IS_CLINICALLY_SIGNIFICANT",AC_EVALUATION.IS_CLINICALLY_SIGNIFICANT)
,_GRADE_ID
//,Parameter("@GRADE_ID",AC_EVALUATION.GRADE_ID)
,Parameter("@ORG_ID",AC_EVALUATION.ORG_ID)
,Parameter("@CREATED_BY",AC_EVALUATION.CREATED_BY)
//,Parameter("@CREATED_ON",AC_CLASS.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_EVALUATION.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",AC_CLASS.LAST_MODIFIED_ON)
,Parameter("@LANGUAGE_OF_REPORT",AC_EVALUATION.LANGUAGE_OF_REPORT)
,Parameter("@LANGUAGE_OF_REPORT_COMMENTS",AC_EVALUATION.LANGUAGE_OF_REPORT_COMMENTS)
,Parameter("@RESULT_STATUS",AC_EVALUATION.RESULT_STATUS)
            };
            return parameters;
        }
    }
}
