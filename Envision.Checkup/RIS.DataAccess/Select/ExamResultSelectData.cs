using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class ExamResultSelectData : DataAccessBase
    {
        private CheckExamResult _result;
        private ExamResultSelectDataParameters _examResultSelectDataParameters;

        public ExamResultSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_CheckExamResult.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _examResultSelectDataParameters = new ExamResultSelectDataParameters(CheckExamResult);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _examResultSelectDataParameters.Parameters);
            return ds;
        }
        public CheckExamResult CheckExamResult
        {
            get { return _result; }
            set { _result = value; }
        }
    }

    public class ExamResultSelectDataParameters
    {
        private CheckExamResult _result;
        private SqlParameter[] _parameters;

        public ExamResultSelectDataParameters(CheckExamResult result)
        {
            CheckExamResult = result;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, CheckExamResult.SpType ),
                new SqlParameter( "@ACCESSION_NO"		    , CheckExamResult.AccessionNo ) ,
				new SqlParameter( "@ASSIGNED_TO"        , CheckExamResult.AssignedTO ),
                new SqlParameter( "@ASSIGNED_BY"        , CheckExamResult.AssignedBy )
				
				
		    };

            Parameters = parameters;
        }

        public CheckExamResult CheckExamResult
        {
            get { return _result; }
            set { _result = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
