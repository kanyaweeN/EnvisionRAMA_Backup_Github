using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class ResultICDSelectData : DataAccessBase
    {
        private ResultEntryICD _result;
        private ResultICDSelectDataParameters _examResultSelectDataParameters;

        public ResultICDSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ResultEntry_ICD.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _examResultSelectDataParameters = new ResultICDSelectDataParameters(ResultEntryICD);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _examResultSelectDataParameters.Parameters);
            return ds;
        }
        public ResultEntryICD ResultEntryICD
        {
            get { return _result; }
            set { _result = value; }
        }
    }

    public class ResultICDSelectDataParameters
    {
        private ResultEntryICD _result;
        private SqlParameter[] _parameters;

        public ResultICDSelectDataParameters(ResultEntryICD result)
        {
            ResultEntryICD = result;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_TYPE"	, ResultEntryICD.SpType ),
                new SqlParameter( "@ICD_ID"		    , ResultEntryICD.IcdID ) ,
				new SqlParameter( "@HN"        , ResultEntryICD.PatientID ),
                new SqlParameter( "@ORDER_NO"        , ResultEntryICD.OrderNo ),
                new SqlParameter( "@ACCESSION_NO"        , ResultEntryICD.AccessionNo ),
                new SqlParameter( "@ORDER_RESULT_FLAG"        , ResultEntryICD.ResultFlag ),
                new SqlParameter( "@ORG_ID"        , ResultEntryICD.OrgID ),
                new SqlParameter( "@CREATED_BY"        , ResultEntryICD.CreatedBy )
				
				
		    };

            Parameters = parameters;
        }

        public ResultEntryICD ResultEntryICD
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
