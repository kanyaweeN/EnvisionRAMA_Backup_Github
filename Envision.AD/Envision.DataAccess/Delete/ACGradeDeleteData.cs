using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class ACGradeDeleteData : DataAccessBase 
    {
          public AC_GRADE AC_GRADE { get; set; }

          public ACGradeDeleteData()
		{
            AC_GRADE = new AC_GRADE();
            StoredProcedureName = StoredProcedure.Prc_AC_GRADE_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@GRADE_ID",AC_GRADE.GRADE_ID),
                                     };
            return parameters;
        }
    }
}
