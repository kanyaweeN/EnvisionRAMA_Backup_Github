using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACGradeInsertData : DataAccessBase 
    {
        public AC_GRADE AC_GRADE { get; set; }
        int _id = 0;
        public ACGradeInsertData()
		{
            AC_GRADE = new AC_GRADE();
			StoredProcedureName = StoredProcedure.Prc_AC_GRADE_Insert;
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
            DbParameter _GRADE_ID = Parameter("@GRADE_ID", AC_GRADE.GRADE_ID);
            _GRADE_ID.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
_GRADE_ID
,Parameter("@GRADE_LABEL",AC_GRADE.GRADE_LABEL)
,Parameter("@GRADE_VALUE",AC_GRADE.GRADE_VALUE)
,Parameter("@ORG_ID",AC_GRADE.ORG_ID)
,Parameter("@CREATED_BY",AC_GRADE.CREATED_BY)
//,Parameter("@CREATED_ON",AC_YEAR.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_GRADE.LAST_MODIFIED_BY)
,Parameter("@SEND_MESSAGE", this.AC_GRADE.SEND_MESSAGE)
            };
            return parameters;
        }
    }
}
