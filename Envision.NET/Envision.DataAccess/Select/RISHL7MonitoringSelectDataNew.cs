using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISHL7MonitoringSelectDataNew : DataAccessBase
    {
        public HL7Monitoring HL7Monitoring { get; set; }
        public RISHL7MonitoringSelectDataNew()
        {
            HL7Monitoring = new HL7Monitoring();
            StoredProcedureName = StoredProcedure.Prc_RIS_ResendBilling;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
			return ds;
		}
        public DataSet GetData_PlaymentChecking_forAIMC()
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_PaymentChecking_Select_forAIMC;
            ParameterList = buildParameter_PlaymentChecking();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DbParameter FROM_DATE = Parameter();
            FROM_DATE.ParameterName = "@FROM_DATE";
            if (HL7Monitoring.FromDate == DateTime.MinValue)
                FROM_DATE.Value = DBNull.Value;
            else
                FROM_DATE.Value = HL7Monitoring.FromDate;

            DbParameter TO_DATE = Parameter();
            TO_DATE.ParameterName = "@TO_DATE";
            if (HL7Monitoring.ToDate == DateTime.MinValue)
                TO_DATE.Value = DBNull.Value;
            else
                TO_DATE.Value = HL7Monitoring.ToDate;

            DbParameter[] parameters ={			
				Parameter( "@SP_Types"	, HL7Monitoring.SpType ),
                Parameter( "@MSG_TYPE"		    , HL7Monitoring.MsgType ) ,
				Parameter( "@ORG_ID"        , HL7Monitoring.OrgID ),
                FROM_DATE,
				TO_DATE
			};
            return parameters;
        }
        private DbParameter[] buildParameter_PlaymentChecking()
        {
            DbParameter FROM_DATE = Parameter();
            FROM_DATE.ParameterName = "@FROM_DATE";
            if (HL7Monitoring.FromDate == DateTime.MinValue)
                FROM_DATE.Value = DBNull.Value;
            else
                FROM_DATE.Value = HL7Monitoring.FromDate;

            DbParameter TO_DATE = Parameter();
            TO_DATE.ParameterName = "@TO_DATE";
            if (HL7Monitoring.ToDate == DateTime.MinValue)
                TO_DATE.Value = DBNull.Value;
            else
                TO_DATE.Value = HL7Monitoring.ToDate;

            DbParameter[] parameters ={			
				Parameter( "@SP_Types"	, HL7Monitoring.SpType ),
                Parameter( "@MSG_TYPE"		    , HL7Monitoring.MsgType ) ,
				Parameter( "@ORG_ID"        , HL7Monitoring.OrgID ),
                FROM_DATE,
				TO_DATE
			};
            return parameters;
        }
    
    }
}
