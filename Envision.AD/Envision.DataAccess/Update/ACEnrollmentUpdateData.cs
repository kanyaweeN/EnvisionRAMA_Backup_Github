using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class ACEnrollmentUpdateData : DataAccessBase 
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }

          public ACEnrollmentUpdateData()
		{
            AC_ENROLLMENT = new AC_ENROLLMENT();
			StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_Update;
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
Parameter("@ENROLL_ID",AC_ENROLLMENT.ENROLL_ID)
,Parameter("@ENROLL_UID",AC_ENROLLMENT.ENROLL_UID)
,Parameter("@YEAR_ID",AC_ENROLLMENT.YEAR_ID)
,Parameter("@CLASS_ID",AC_ENROLLMENT.CLASS_ID)
,Parameter("@EMP_ID",AC_ENROLLMENT.EMP_ID)
,Parameter("@IS_ACTIVE",AC_ENROLLMENT.IS_ACTIVE)
,Parameter("@ORG_ID",AC_ENROLLMENT.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",AC_ENROLLMENT.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }

        private DbParameter[] buildParameterByAck(int Id)
        {
            DbParameter[] parameters ={
                                        Parameter("@ASSIGNEMENT_ID",Id),
                                      };
            return parameters;
        }
        public void UpdateAck(int Id)
        {
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_UpdateAck;
            ParameterList = buildParameterByAck(Id);
            ExecuteNonQuery();
        }
    }
}
