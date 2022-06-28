using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class SRTemplateUpdate : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }
        public SRTemplateUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Update;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameter();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameter()
        {
            DbParameter param = Parameter();
            param.ParameterName = "@BP_ID";
            if (SR_TEMPLATE.BP_ID < 1)
                param.Value = DBNull.Value;
            else
                param.Value = SR_TEMPLATE.BP_ID;
            DbParameter[] parameter = { 
                                        Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                        Parameter("@TEMPLATE_NAME", SR_TEMPLATE.TEMPLATE_NAME),
                                        Parameter("@IS_ACTIVE", SR_TEMPLATE.IS_ACTIVE),
                                        Parameter("@EXAM_ID", SR_TEMPLATE.EXAM_ID),
                                        //Parameter("@BP_ID", SR_TEMPLATE.BP_ID),
                                        param,
                                        Parameter("@DESCRIPTION", SR_TEMPLATE.DESCRIPTION),
                                        Parameter("@RSNA_URL", SR_TEMPLATE.RSNA_URL),
                                        Parameter("@LANG_ID", SR_TEMPLATE.LANG_ID),
                                        Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID),
                                        Parameter("@LAST_MODIFIED_BY", SR_TEMPLATE.USER_ID)
                                    };
            return parameter;
        }
    }
}
