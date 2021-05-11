using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class SR_TEMPLATEUpdateData : DataAccessBase 
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public SR_TEMPLATEUpdateData() {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Update;
            SR_TEMPLATE = new SR_TEMPLATE();
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter param4 = Parameter();
            param4.ParameterName = "@BP_ID";
            if (SR_TEMPLATE.BP_ID == 0)
                param4.Value = DBNull.Value;
            else
                param4.Value = SR_TEMPLATE.BP_ID;

            DbParameter[] parameter = { 
                                        Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                        Parameter("@TEMPLATE_NAME", SR_TEMPLATE.TEMPLATE_NAME),
                                        Parameter("@IS_ACTIVE", SR_TEMPLATE.IS_ACTIVE),
                                        Parameter("@EXAM_ID", SR_TEMPLATE.EXAM_ID),
                                        param4,
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
