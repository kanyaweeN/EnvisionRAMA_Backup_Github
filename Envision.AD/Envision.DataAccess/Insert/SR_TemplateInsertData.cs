using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_TemplateInsertData : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public SR_TemplateInsertData() {
            SR_TEMPLATE = new SR_TEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Insert;
        }
        public int Add()
        {

            ParameterList = buildParameter();
            DataTable dtt = ExecuteDataTable();
            return Convert.ToInt32(dtt.Rows[0][0].ToString());
        }

        private DbParameter[] buildParameter()
        {
            DbParameter param4 = Parameter();
            param4.ParameterName = "@BP_ID";
            if (SR_TEMPLATE.BP_ID == 0)
                param4.Value = DBNull.Value;
            else
                param4.Value = SR_TEMPLATE.BP_ID;

            DbParameter[] parameters =
		    {
                Parameter( "@TEMPLATE_NAME"	, SR_TEMPLATE.TEMPLATE_NAME) ,
				Parameter( "@IS_ACTIVE"     , SR_TEMPLATE.IS_ACTIVE) ,
				Parameter( "@EXAM_ID"	    , SR_TEMPLATE.EXAM_ID ) ,
                param4,//Parameter( "@BP_ID"	        , SR_TEMPLATE.BP_ID ) ,
				Parameter( "@DESCRIPTION"   , SR_TEMPLATE.DESCRIPTION ) ,
				Parameter( "@RSNA_URL"	    , SR_TEMPLATE.RSNA_URL ), 
                Parameter( "@LANG_ID"	    , SR_TEMPLATE.LANG_ID ), 
                Parameter( "@ORG_ID"        , SR_TEMPLATE.ORG_ID),
                Parameter( "@CREATED_BY"	    , SR_TEMPLATE.USER_ID ), 
			};
            return parameters;
        }

    }
}
