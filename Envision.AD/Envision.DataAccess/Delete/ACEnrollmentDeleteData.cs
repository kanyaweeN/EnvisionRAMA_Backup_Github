using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class ACEnrollmentDeleteData : DataAccessBase 
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }

          public ACEnrollmentDeleteData()
		{
            AC_ENROLLMENT = new AC_ENROLLMENT();
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ENROLL_ID",AC_ENROLLMENT.ENROLL_ID),
                                     };
            return parameters;
        }
    }
}
