using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_TemplatePartInsertData : DataAccessBase
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public SR_TemplatePartInsertData() {
            SR_TEMPLATEPART = new SR_TEMPLATEPART();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Insert;
        }
        public int Add()
        {
            ParameterList = buildParameter();
            DataTable dtt = ExecuteDataTable();
            return Convert.ToInt32(dtt.Rows[0][0].ToString());
        }

        private DbParameter[] buildParameter()
        {

            DbParameter[] parameters =
		    {
                Parameter( "@PART_NAME"	, SR_TEMPLATEPART.PART_NAME) ,
				Parameter( "@TEMPLATE_ID"     , SR_TEMPLATEPART.TEMPLATE_ID) ,
				Parameter( "@SL"	    , SR_TEMPLATEPART.SL ) ,
                Parameter( "@ORG_ID"        , SR_TEMPLATEPART.ORG_ID),
                Parameter( "@CREATED_BY"	, SR_TEMPLATEPART.CREATED_BY ), 
			};
            return parameters;
        }
    }
}
