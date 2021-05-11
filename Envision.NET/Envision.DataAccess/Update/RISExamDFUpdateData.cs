using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamDFUpdateData : DataAccessBase 
	{
        public RIS_EXAMDF RIS_EXAMDF { get; set; }

        public RISExamDFUpdateData()
		{
            RIS_EXAMDF = new RIS_EXAMDF();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMDF_Update;
		}

        public void UpdateData()
		{
            ParameterList = new DbParameter[] 
            {
                Parameter("@EXAM_DF_ID",RIS_EXAMDF.EXAM_DF_ID),
                Parameter("@EXAM_ID",RIS_EXAMDF.EXAM_ID),
                Parameter("@SL_NO",RIS_EXAMDF.SL_NO),
                Parameter("@JOB_TYPE",RIS_EXAMDF.JOB_TYPE),
                Parameter("@CLINIC_TYPE",RIS_EXAMDF.CLINIC_TYPE),
                Parameter("@DF",RIS_EXAMDF.DF),
                Parameter("@ORG_ID",RIS_EXAMDF.ORG_ID),
                Parameter("@CREATED_BY",RIS_EXAMDF.CREATED_BY),
                //Parameter("@CREATED_ON",RIS_EXAMDF.CREATED_ON),
                Parameter("@LAST_UPDATED_BY",RIS_EXAMDF.LAST_UPDATED_BY),
                //Parameter("@LAST_UPDATED_ON",RIS_EXAMDF.LAST_UPDATED_ON),
                Parameter("@IS_DELETED",RIS_EXAMDF.IS_DELETED),
                Parameter("@IS_ACTIVE",RIS_EXAMDF.IS_ACTIVE),
            };
            ExecuteNonQuery();
		}
        public void UpdateDataIsDeleted()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMDF_UpdateIsDeleted;
            ParameterList = new DbParameter[] 
            {
                Parameter("@EXAM_DF_ID",RIS_EXAMDF.EXAM_DF_ID),
                Parameter("@IS_DELETED",RIS_EXAMDF.IS_DELETED),
            };
            ExecuteNonQuery();
        }
	}
}

