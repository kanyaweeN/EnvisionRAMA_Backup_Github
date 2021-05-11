using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISAutoMergeConfigUpdate : DataAccessBase
    {
        public RIS_AUTOMERGECONFIG RIS_AUTOMERGECONFIG { get; set; }
        public RISAutoMergeConfigUpdate()
        {
            RIS_AUTOMERGECONFIG = new RIS_AUTOMERGECONFIG();
            StoredProcedureName = StoredProcedure.RIS_AutoMergeConfig_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                            Parameter("@config_name",RIS_AUTOMERGECONFIG.CONFIG_NAME)
                                           , Parameter("@merger_unit_id",RIS_AUTOMERGECONFIG.merger_unit_id)
                                           , Parameter("@merger_exam_id", RIS_AUTOMERGECONFIG.merger_exam_id)
                                           , Parameter("@mergee_unit_id", RIS_AUTOMERGECONFIG.mergee_unit_id)
                                           , Parameter("@mergee_exam_id", RIS_AUTOMERGECONFIG.mergee_exam_id)
                                           , Parameter("@auto_apply", RIS_AUTOMERGECONFIG.AUTO_APPLY)
                                           , Parameter("@is_active", RIS_AUTOMERGECONFIG.IS_ACTIVE)
                                           , Parameter("@Last_modified_by", RIS_AUTOMERGECONFIG.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
    }
}
