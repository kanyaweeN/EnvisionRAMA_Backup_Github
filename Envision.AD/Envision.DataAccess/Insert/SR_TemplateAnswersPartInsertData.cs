using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_TemplateAnswersPartInsertData :DataAccessBase
    {
        public SR_TEMPLATEANSWERSPART SR_TEMPLATEANSWERSPART { get; set; }

        public SR_TemplateAnswersPartInsertData() {
            SR_TEMPLATEANSWERSPART = new SR_TEMPLATEANSWERSPART();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEANSWERSPART_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters =
		    {
                Parameter( "@ACCESSION_NO"	  , SR_TEMPLATEANSWERSPART.ACCESSION_NO) ,
                Parameter( "@TEMPLATE_ID"	  , SR_TEMPLATEANSWERSPART.TEMPLATE_ID) ,
				Parameter( "@ORG_ID"          , SR_TEMPLATEANSWERSPART.ORG_ID) ,
				Parameter( "@CREATED_BY"	  , SR_TEMPLATEANSWERSPART.USER_ID ), 
			};
            return parameters;
        }

    }
}
