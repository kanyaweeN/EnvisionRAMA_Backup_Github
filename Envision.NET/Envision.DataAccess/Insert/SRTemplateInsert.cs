using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class SRTemplateInsert : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }
        public SRTemplateInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Insert;
        }

        public void InsertData()
        {
            this.ParameterList = this.BuildParameter();
            DataTable dtt = this.ExecuteDataTable();
            if (dtt.Rows.Count > 0)
            {
                this.SR_TEMPLATE.TEMPLATE_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());
            }
        }

        private System.Data.Common.DbParameter[] BuildParameter()
        {
            DbParameter param = Parameter();
            param.ParameterName = "@BP_ID";
            if (SR_TEMPLATE.BP_ID < 1)
                param.Value = DBNull.Value;
            else
                param.Value = SR_TEMPLATE.BP_ID;
            DbParameter[] paramters = { 
                                            Parameter("@TEMPLATE_NAME", SR_TEMPLATE.TEMPLATE_NAME),
                                            Parameter("@IS_ACTIVE", SR_TEMPLATE.IS_ACTIVE),
                                            Parameter("@EXAM_ID", SR_TEMPLATE.EXAM_ID),
                                            //Parameter("@BP_ID", SR_TEMPLATE.BP_ID),
                                            param,
                                            Parameter("@DESCRIPTION", SR_TEMPLATE.DESCRIPTION),
                                            Parameter("@RSNA_URL", SR_TEMPLATE.RSNA_URL),
                                            Parameter("@LANG_ID", SR_TEMPLATE.LANG_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID),
                                            Parameter("@CREATED_BY", SR_TEMPLATE.USER_ID)

                                      };
            return paramters;
        }
    }
}
