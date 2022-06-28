using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RIS_AutoMergeExam_Insert : DataAccessBase
    {
        public RIS_AUTOMERGECONFIG RIS_AUTOMERGECONFIG { get; set; }
        public RIS_AutoMergeExam_Insert()
		{
            RIS_AUTOMERGECONFIG = new RIS_AUTOMERGECONFIG();
			StoredProcedureName = StoredProcedure.Prc_RIS_AUTOMERGECONFIG_INSERT;
		}
        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                                           Parameter("@merger_unit_id",RIS_AUTOMERGECONFIG.mergee_unit_id)
                                           , Parameter("@merger_exam_id", RIS_AUTOMERGECONFIG.merger_exam_id)
                                           , Parameter("@mergee_unit_id", RIS_AUTOMERGECONFIG.mergee_unit_id)
                                           , Parameter("@mergee_exam_id", RIS_AUTOMERGECONFIG.mergee_exam_id)
                                           , Parameter("@Auto_Apply", RIS_AUTOMERGECONFIG.AUTO_APPLY)
                                           , Parameter("@Config_Name", RIS_AUTOMERGECONFIG.CONFIG_NAME)
                                           , Parameter("@Is_Active", RIS_AUTOMERGECONFIG.IS_ACTIVE)
                                           , Parameter("@Org_id", RIS_AUTOMERGECONFIG.ORG_ID)
                                           , Parameter("@Created_by", RIS_AUTOMERGECONFIG.CREATED_BY)
			            };
            return parameters;
        }

    }
}