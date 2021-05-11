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

namespace Envision.DataAccess.Update
{
    public class ExamResultUpdateData : DataAccessBase
    {
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }

        public ExamResultUpdateData()
        {
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
            StoredProcedureName = StoredProcedure.Prc_ExamResult_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@ACCESSION_NO"	, RIS_EXAMRESULT.ACCESSION_NO ) ,
                Parameter( "@RESULT_STATUS"	, RIS_EXAMRESULT.RESULT_STATUS ) ,
				Parameter( "@RESULT_TEXT_HTML"        , RIS_EXAMRESULT.RESULT_TEXT_HTML ) ,
				Parameter( "@LAST_MODIFIED_BY"	, RIS_EXAMRESULT.LAST_MODIFIED_BY ) ,
				Parameter( "@HL7_TEXT"	    , RIS_EXAMRESULT.HL7_TEXT) ,
				Parameter( "@HL7_SEND"		, RIS_EXAMRESULT.HL7_SEND ) ,
				Parameter( "@RESULT_TEXT_PLAIN"	    , RIS_EXAMRESULT.RESULT_TEXT_PLAIN),
                                      };
            return parameters;
        }
    }
}
