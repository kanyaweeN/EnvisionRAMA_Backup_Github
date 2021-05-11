using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ResultEntyReportSelectData : DataAccessBase
    {
        public ReportParameters ReportParameters
        {
            get;set;
        }
        
        public ResultEntyReportSelectData()
        {
            ReportParameters = new ReportParameters();
            StoredProcedureName = StoredProcedure.Prc_ReportExamResult;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                     Parameter( "@SP_TYPE"	, ReportParameters.SpType ),
                                                     Parameter( "@ACCESSION_NO"		    , ReportParameters.AccessionNo ) ,
				                                     Parameter( "@ORG_ID"        , ReportParameters.OrgID )
                                       };
            return parameters;
        }
    }
}
