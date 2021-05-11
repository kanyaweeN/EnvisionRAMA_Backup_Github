using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ReportStatusSelectData : DataAccessBase
    {
        public HL7Monitoring HL7Monitoring { get; set; }
        public ReportStatusSelectData()
        {
            HL7Monitoring = new HL7Monitoring();
            StoredProcedureName = StoredProcedure.Prc_ResultStatusChange;
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
                                                     Parameter( "@SP_Types"	, HL7Monitoring.SpType ),
                                                     Parameter( "@MSG_TYPE"		    , HL7Monitoring.MsgType ) ,
				                                     Parameter( "@ORG_ID"        , HL7Monitoring.OrgID ),
                                                     Parameter( "@FROM_DATE"        , HL7Monitoring.FromDate),
				                                     Parameter( "@TO_DATE"        , HL7Monitoring.ToDate)
                                       };
            return parameters;
        }

        public DataSet GetLog(string accession)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_RESULTSTATUSCHANGELOG_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                                     Parameter( "@ACCESSION_NO"	, accession ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
