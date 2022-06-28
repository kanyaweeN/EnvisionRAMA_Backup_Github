using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISModalityexamUpdateData : DataAccessBase 
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }

		public  RISModalityexamUpdateData()
		{
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void UpdateOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_ONL_Update;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param = Parameter();
            param.ParameterName = "@LAST_MODIFIED_ON";
            if (RIS_MODALITYEXAM.LAST_MODIFIED_ON == null)
                param.Value = DBNull.Value;
            else
                param.Value = RIS_MODALITYEXAM.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_MODALITYEXAM.LAST_MODIFIED_ON;

            DbParameter paramOn = Parameter();
            paramOn.ParameterName = "@CREATED_ON";
            if (RIS_MODALITYEXAM.CREATED_ON == null)
                paramOn.Value = DBNull.Value;
            else
                paramOn.Value = RIS_MODALITYEXAM.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_MODALITYEXAM.CREATED_ON;

            DbParameter[] parameters ={
                Parameter("@MODALITY_EXAM_ID",RIS_MODALITYEXAM.MODALITY_EXAM_ID),
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID),
                Parameter("@EXAM_ID",RIS_MODALITYEXAM.EXAM_ID),
                Parameter("@TECH_BYPASS",RIS_MODALITYEXAM.TECH_BYPASS),
                Parameter("@QA_BYPASS",RIS_MODALITYEXAM.QA_BYPASS),
                Parameter("@IS_ACTIVE",RIS_MODALITYEXAM.IS_ACTIVE),
                Parameter("@IS_DEFAULT_MODALITY",RIS_MODALITYEXAM.IS_DEFAULT_MODALITY),
                Parameter("@IS_UPDATED",RIS_MODALITYEXAM.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_MODALITYEXAM.IS_DELETED),
                Parameter("@ORG_ID",RIS_MODALITYEXAM.ORG_ID),
                Parameter("@CREATED_BY",RIS_MODALITYEXAM.CREATED_BY),
                paramOn,
                Parameter("@LAST_MODIFIED_BY",RIS_MODALITYEXAM.LAST_MODIFIED_BY),
                param
                                      };
            return parameters;
        }
	}
}

