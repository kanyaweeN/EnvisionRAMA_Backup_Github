using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class HL7MonitoringSelectData : DataAccessBase
    {
        public HL7Monitoring HL7Monitoring { get; set; }

        public HL7MonitoringSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HL7Monitoring;
            HL7Monitoring = new HL7Monitoring();
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
                                                     Parameter( "@SP_Types"	        , HL7Monitoring.SpType ),
                                                     Parameter( "@MSG_TYPE"		    , HL7Monitoring.MsgType ) ,
				                                     Parameter( "@ORG_ID"           , HL7Monitoring.OrgID ),
                                                     Parameter( "@FROM_DATE"        , HL7Monitoring.FromDate),
				                                     Parameter( "@TO_DATE"          , HL7Monitoring.ToDate)
                                       };
            return parameters;
        }
    }
}
