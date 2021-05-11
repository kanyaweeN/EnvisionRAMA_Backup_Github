using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class AddendumInsertData : DataAccessBase
    {
        public RIS_EXAMRESULTNOTE RIS_EXAMRESULTNOTE { get; set; }

        public AddendumInsertData()
        {
            RIS_EXAMRESULTNOTE = new RIS_EXAMRESULTNOTE();
            StoredProcedureName = StoredProcedure.Prc_Addendum_Insert;
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
				Parameter( "@ORDER_ID"	            , RIS_EXAMRESULTNOTE.ORDER_ID ) ,
                Parameter( "@EXAM_ID"	            , RIS_EXAMRESULTNOTE.EXAM_ID) ,
				Parameter( "@ACCESSION_NO"          , RIS_EXAMRESULTNOTE.ACCESSION_NO ) ,
				Parameter( "@NOTE_TEXT"	            , RIS_EXAMRESULTNOTE.NOTE_TEXT) ,
                Parameter( "@NOTE_TEXT_RTF"	        , RIS_EXAMRESULTNOTE.NOTE_TEXT_RTF ) ,
				Parameter( "@NOTE_BY"	            , RIS_EXAMRESULTNOTE.NOTE_BY ) ,
				Parameter( "@ORG_ID"		        , RIS_EXAMRESULTNOTE.ORG_ID) ,
				Parameter( "@HL7_TEXT"	            , RIS_EXAMRESULTNOTE.HL7_TEXT ), 
			};
            return parameters;
        }
      
    }
}
