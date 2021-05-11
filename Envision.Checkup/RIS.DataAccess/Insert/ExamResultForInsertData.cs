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
    public class ExamResultForInsertData : DataAccessBase
    {
        private ExamResultSave _temp;

        private ResultForInsertDataParameters _resultdataparameters;

        public ExamResultForInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ExamResultFor_Insert.ToString();
        }

        public void Add()
        {
            _resultdataparameters = new ResultForInsertDataParameters(ExamResultSave);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _resultdataparameters.Parameters);

        }

        public ExamResultSave ExamResultSave
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }

    public class ResultForInsertDataParameters
    {
        private ExamResultSave _temp;
        private SqlParameter[] _parameters;

        public ResultForInsertDataParameters(ExamResultSave template)
        {
            ExamResultSave = template;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ORDER_ID"	, ExamResultSave.OrderId ) ,
                new SqlParameter( "@EXAM_ID"	, ExamResultSave.ExamId ) ,
				new SqlParameter( "@ACCESSION_NO"        , ExamResultSave.AccessionNo ) ,
				new SqlParameter( "@RESULT_TEXT_HTML"	, ExamResultSave.ResultTextHtml ) ,
				new SqlParameter( "@RESULT_STATUS"	    , ExamResultSave.ResultStatus) ,
				new SqlParameter( "@ORG_ID"		, ExamResultSave.OrgID ) ,
				new SqlParameter( "@CREATED_BY"	    , ExamResultSave.CreatedBy ), 
                new SqlParameter( "@FINALIZED_BY"	    , ExamResultSave.FinalizedBy), 
                new SqlParameter( "@HL7_TEXT"	    , ExamResultSave.Hl7Text ), 
                new SqlParameter( "@HL7_SEND"	    , ExamResultSave.Hl7Send ),
                new SqlParameter( "@RESULT_TEXT_PLAIN"	    , ExamResultSave.ResultTextPlain ),

			};

            Parameters = parameters;
        }

        public ExamResultSave ExamResultSave
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
