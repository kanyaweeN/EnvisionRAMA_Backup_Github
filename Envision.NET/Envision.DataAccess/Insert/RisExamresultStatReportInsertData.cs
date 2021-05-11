using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class RisExamresultStatReportInsertData : DataAccessBase
    {
        public RIS_EXAMRESULTSTATREPORT RIS_EXAMRESULTSTATREPORT { get; set; }

        public RisExamresultStatReportInsertData()
        {
            RIS_EXAMRESULTSTATREPORT = new RIS_EXAMRESULTSTATREPORT();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSTATREPORT_Insert_New;
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
				Parameter( "@ORDER_ID"	            , RIS_EXAMRESULTSTATREPORT.ORDER_ID ) ,
                Parameter( "@EXAM_ID"	            , RIS_EXAMRESULTSTATREPORT.EXAM_ID) ,
				Parameter( "@ACCESSION_NO"          , RIS_EXAMRESULTSTATREPORT.ACCESSION_NO ) ,
				Parameter( "@NOTE_TEXT"	            , RIS_EXAMRESULTSTATREPORT.NOTE_TEXT) ,
                Parameter( "@NOTE_TEXT_RTF"	        , RIS_EXAMRESULTSTATREPORT.NOTE_TEXT_RTF ) ,
                Parameter( "@NOTE_TEXT_HTML"	        , RIS_EXAMRESULTSTATREPORT.NOTE_TEXT_HTML ) ,
				Parameter( "@NOTE_BY"	            , RIS_EXAMRESULTSTATREPORT.NOTE_BY ) ,
				Parameter( "@ORG_ID"		        , RIS_EXAMRESULTSTATREPORT.ORG_ID) ,
				Parameter( "@HL7_TEXT"	            , RIS_EXAMRESULTSTATREPORT.HL7_TEXT ), 
			};
            return parameters;
        }
      
    }
}
