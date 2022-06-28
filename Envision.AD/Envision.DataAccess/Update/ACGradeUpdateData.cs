using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class ACGradeUpdateData : DataAccessBase 
    {
        public AC_GRADE AC_GRADE { get; set; }

        public ACGradeUpdateData()
		{
            AC_GRADE = new AC_GRADE();
			StoredProcedureName = StoredProcedure.Prc_AC_GRADE_Update;
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
Parameter("@GRADE_ID",AC_GRADE.GRADE_ID)
,Parameter("@GRADE_LABEL",AC_GRADE.GRADE_LABEL)
,Parameter("@GRADE_VALUE",AC_GRADE.GRADE_VALUE)
,Parameter("@ORG_ID",AC_GRADE.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",AC_GRADE.LAST_MODIFIED_BY)
,Parameter("@SEND_MESSAGE",AC_GRADE.SEND_MESSAGE)

                                      };
            return parameters;
        }
    }
}
