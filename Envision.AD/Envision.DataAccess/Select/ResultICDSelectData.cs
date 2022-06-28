using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ResultICDSelectData : DataAccessBase
    {
        public ResultEntryICD ResultEntryICD { get; set; }

        public ResultICDSelectData()
        {
            ResultEntryICD = new ResultEntryICD();
            StoredProcedureName = StoredProcedure.Prc_ResultEntry_ICD;
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
                                                     Parameter( "@SP_TYPE"	, ResultEntryICD.SpType ),
                                                     Parameter( "@ICD_ID"		    , ResultEntryICD.IcdID ) ,
				                                     Parameter( "@HN"        , ResultEntryICD.PatientID ),
                                                     Parameter( "@ORDER_NO"        , ResultEntryICD.OrderNo ),
                                                     Parameter( "@ACCESSION_NO"        , ResultEntryICD.AccessionNo ),
                                                     Parameter( "@ORDER_RESULT_FLAG"        , ResultEntryICD.ResultFlag ),
                                                     Parameter( "@ORG_ID"        , ResultEntryICD.OrgID ),
                                                     Parameter( "@CREATED_BY"        , ResultEntryICD.CreatedBy )
                                       };
            return parameters;
        }
    }
}
