using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Update
{
    public class SR_TEMPLATEPARTUpdateData : DataAccessBase 
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public SR_TEMPLATEPARTUpdateData() {
            SR_TEMPLATEPART = new SR_TEMPLATEPART();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
                Parameter( "@PART_ID"	, SR_TEMPLATEPART.PART_ID) ,
                Parameter( "@PART_NAME"	, SR_TEMPLATEPART.PART_NAME) ,
				Parameter( "@TEMPLATE_ID"     , SR_TEMPLATEPART.TEMPLATE_ID) ,
				Parameter( "@SL"	    , SR_TEMPLATEPART.SL ) ,
                Parameter( "@ORG_ID"        , SR_TEMPLATEPART.ORG_ID),
                Parameter( "@LAST_MODIFIED_BY"	, SR_TEMPLATEPART.LAST_MODIFIED_BY ), 
			};
            return parameters;
        }
    }
}
