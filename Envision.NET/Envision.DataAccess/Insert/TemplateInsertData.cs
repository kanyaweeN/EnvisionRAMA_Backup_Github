using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class TemplateInsertData : DataAccessBase
    {
        public RIS_EXAMRESULTTEMPLATE RIS_EXAMRESULTTEMPLATE { get; set; }

        public TemplateInsertData()
        {
            RIS_EXAMRESULTTEMPLATE = new RIS_EXAMRESULTTEMPLATE();
            StoredProcedureName = StoredProcedure.Prc_Template_Insert;
        }

        public void Add()
        {
        
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter() {
            DbParameter[] parameters =
		    {
				Parameter( "@EXAM_ID"	        , RIS_EXAMRESULTTEMPLATE.EXAM_ID)       ,
                Parameter( "@TEMPLATE_NAME"	    , RIS_EXAMRESULTTEMPLATE.TEMPLATE_NAME) ,
				Parameter( "@TEMPLATE_TEXT"     , RIS_EXAMRESULTTEMPLATE.TEMPLATE_TEXT) ,
				Parameter( "@TEMPLATE_TYPE"	    , RIS_EXAMRESULTTEMPLATE.TEMPLATE_TYPE ) ,
				Parameter( "@AUTO_APPLY"	    , RIS_EXAMRESULTTEMPLATE.AUTO_APPLY ) ,
				Parameter( "@ORG_ID"		    , RIS_EXAMRESULTTEMPLATE.ORG_ID ) ,
				Parameter( "@CREATED_BY"	    , RIS_EXAMRESULTTEMPLATE.CREATED_BY ), 
                Parameter( "@SHARE_WITH"	    , RIS_EXAMRESULTTEMPLATE.SHARE_WITH ), 

			};
            return parameters;
        }
    }
}
