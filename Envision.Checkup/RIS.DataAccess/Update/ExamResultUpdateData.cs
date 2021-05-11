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

namespace RIS.DataAccess.Update
{
    public class ExamResultUpdateData : DataAccessBase
    {
        private ExamResultUpdate _temp;

        private ResultUpdateDataParameters _resultdataparameters;

        public ExamResultUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ExamResult_Update.ToString();
        }

        public void Update()
        {
            _resultdataparameters = new ResultUpdateDataParameters(ExamResultUpdate);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _resultdataparameters.Parameters);

        }

        public ExamResultUpdate ExamResultUpdate
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }

    public class ResultUpdateDataParameters
    {
        private ExamResultUpdate _temp;
        private SqlParameter[] _parameters;

        public ResultUpdateDataParameters(ExamResultUpdate template)
        {
            ExamResultUpdate = template;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ACCESSION_NO"	, ExamResultUpdate.AccessionNo ) ,
                new SqlParameter( "@@RESULT_STATUS"	, ExamResultUpdate.ResultStatus ) ,
				new SqlParameter( "@@RESULT_TEXT_HTML"        , ExamResultUpdate.ResultTextHtml ) ,
				new SqlParameter( "@@LAST_MODIFIED_BY"	, ExamResultUpdate.LastModifiedBy ) ,
				new SqlParameter( "@@HL7_TEXT"	    , ExamResultUpdate.Hl7Text) ,
				new SqlParameter( "@@HL7_SEND"		, ExamResultUpdate.Hl7Send ) ,
				new SqlParameter( "@RESULT_TEXT_PLAIN"	    , ExamResultUpdate.ResultTextPlain),

			};

            Parameters = parameters;
        }

        public ExamResultUpdate ExamResultUpdate
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
