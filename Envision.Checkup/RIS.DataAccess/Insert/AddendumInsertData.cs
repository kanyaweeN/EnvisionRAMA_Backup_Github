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
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class AddendumInsertData : DataAccessBase
    {
        private ExamAddendum _temp;

        private AddendumInsertDataParameters _addendumdataparameters;

        public AddendumInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Addendum_Insert.ToString();
        }

        public void Add()
        {
            _addendumdataparameters = new AddendumInsertDataParameters(ExamAddendum);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _addendumdataparameters.Parameters);

        }

        public ExamAddendum ExamAddendum
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }

    public class AddendumInsertDataParameters
    {
        private ExamAddendum _temp;
        private SqlParameter[] _parameters;

        public AddendumInsertDataParameters(ExamAddendum template)
        {
            ExamAddendum = template;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ORDER_ID"	, ExamAddendum.OrderID ) ,
                new SqlParameter( "@EXAM_ID"	, ExamAddendum.ExamID ) ,
				new SqlParameter( "@ACCESSION_NO"        , ExamAddendum.AccessionNo ) ,
				new SqlParameter( "@NOTE_TEXT"	, ExamAddendum.NoteText ) ,
                new SqlParameter( "@NOTE_TEXT_RTF"	, ExamAddendum.RESULT_TEXT_RTF ) ,
				new SqlParameter( "@NOTE_BY"	    , ExamAddendum.NoteBy ) ,
				new SqlParameter( "@ORG_ID"		, ExamAddendum.OrgID ) ,
				new SqlParameter( "@HL7_TEXT"	    , ExamAddendum.Hl7Text ), 
              

			};

            Parameters = parameters;
        }

        public ExamAddendum ExamAddendum
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
