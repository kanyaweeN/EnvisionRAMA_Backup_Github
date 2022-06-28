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
    public class ExamResultForInsertData : DataAccessBase
    {
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }

        public ExamResultForInsertData()
        {
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
            StoredProcedureName = StoredProcedure.Prc_ExamResultFor_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@ORDER_ID"	, RIS_EXAMRESULT.ORDER_ID ) ,
                Parameter( "@EXAM_ID"	, RIS_EXAMRESULT.EXAM_ID ) ,
				Parameter( "@ACCESSION_NO"        , RIS_EXAMRESULT.ACCESSION_NO ) ,
				Parameter( "@RESULT_TEXT_HTML"	, RIS_EXAMRESULT.RESULT_TEXT_HTML ) ,
				Parameter( "@RESULT_STATUS"	    , RIS_EXAMRESULT.RESULT_STATUS) ,
				Parameter( "@ORG_ID"		, RIS_EXAMRESULT.ORG_ID ) ,
				Parameter( "@CREATED_BY"	    , RIS_EXAMRESULT.CREATED_BY ), 
                Parameter( "@FINALIZED_BY"	    , RIS_EXAMRESULT.FINALIZED_BY), 
                Parameter( "@HL7_TEXT"	    , RIS_EXAMRESULT.HL7_TEXT ), 
                Parameter( "@HL7_SEND"	    , RIS_EXAMRESULT.HL7_SEND ),
                Parameter( "@RESULT_TEXT_PLAIN"	    , RIS_EXAMRESULT.RESULT_TEXT_PLAIN ),
            };
            return parameters;
        }
    }
}
