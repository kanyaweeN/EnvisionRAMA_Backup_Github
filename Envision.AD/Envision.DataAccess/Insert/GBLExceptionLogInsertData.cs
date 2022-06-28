/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLExceptionLogInsertData : DataAccessBase
    {
        public GBL_EXCEPTIONLOG GBL_EXCEPTIONLOG { get; set; }

        public GBLExceptionLogInsertData()
        {
            GBL_EXCEPTIONLOG = new GBL_EXCEPTIONLOG();
            StoredProcedureName = StoredProcedure.Prc_GBLExceptionLog;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@EXC_TYPE"	, GBL_EXCEPTIONLOG.EXC_TYPE) ,
				Parameter( "@EXC_TEXT"        , GBL_EXCEPTIONLOG.EXC_TEXT ) ,
				Parameter( "@EXC_IP"	, GBL_EXCEPTIONLOG.EXC_IP ) ,
				Parameter( "@EXC_PC_NAME"	    , GBL_EXCEPTIONLOG.EXC_PC_NAME ) ,
				Parameter( "@CURRENT_FORM_ID"		, GBL_EXCEPTIONLOG.CURRENT_FORM_ID) ,
				Parameter( "@CURRENT_LANG_ID"	    , GBL_EXCEPTIONLOG.CURRENT_LANG_ID ),
                Parameter( "@CONNECTED_EMP_ID"		    , GBL_EXCEPTIONLOG.CONNECTED_EMP_ID) ,
				Parameter( "@ORG_ID"        , GBL_EXCEPTIONLOG.ORG_ID ) ,
				Parameter( "@CREATED_BY"	, GBL_EXCEPTIONLOG.CREATED_BY )
            };
            return parameters;
        }
    }
}
