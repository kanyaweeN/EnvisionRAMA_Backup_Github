using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACEnrollmentInsertData : DataAccessBase 
    {
        public AC_ENROLLMENT AC_ENROLLMENT { get; set; }
        int _id = 0;
        public ACEnrollmentInsertData()
		{
            AC_ENROLLMENT = new AC_ENROLLMENT();
			StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_Insert;
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
            DbParameter _ENROLL_ID = Parameter("@ENROLL_ID", AC_ENROLLMENT.ENROLL_ID);
            _ENROLL_ID.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
_ENROLL_ID
,Parameter("@ENROLL_UID",AC_ENROLLMENT.ENROLL_UID)
,Parameter("@YEAR_ID",AC_ENROLLMENT.YEAR_ID)
,Parameter("@CLASS_ID",AC_ENROLLMENT.CLASS_ID)
,Parameter("@EMP_ID",AC_ENROLLMENT.EMP_ID)
,Parameter("@IS_ACTIVE",AC_ENROLLMENT.IS_ACTIVE)
,Parameter("@ORG_ID",AC_ENROLLMENT.ORG_ID)
,Parameter("@CREATED_BY",AC_ENROLLMENT.CREATED_BY)
//,Parameter("@CREATED_ON",AC_ENROLLMENT.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_ENROLLMENT.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",AC_ENROLLMENT.LAST_MODIFIED_ON)
            };
            return parameters;
        }
    }
}
