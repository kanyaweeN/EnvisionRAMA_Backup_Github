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
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;


namespace RIS.DataAccess.Select
{
    public class ReportStatusSelectData : DataAccessBase
    {
        private HL7Monitoring _hl7data;
        private ReportStatusSelectDataParameters _hl7selectdataparameters;

        public ReportStatusSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ResultStatusChange.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _hl7selectdataparameters = new ReportStatusSelectDataParameters(HL7Monitoring);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _hl7selectdataparameters.Parameters);
            return ds;

        }

        public HL7Monitoring HL7Monitoring
        {
            get { return _hl7data; }
            set { _hl7data = value; }
        }
    }

    public class ReportStatusSelectDataParameters
    {
        private HL7Monitoring _hl7data;
        private SqlParameter[] _parameters;

        public ReportStatusSelectDataParameters(HL7Monitoring hl7data)
        {
            HL7Monitoring = hl7data;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, HL7Monitoring.SpType ),
                new SqlParameter( "@MSG_TYPE"		    , HL7Monitoring.MsgType ) ,
				new SqlParameter( "@ORG_ID"        , HL7Monitoring.OrgID ),
                new SqlParameter( "@FROM_DATE"        , HL7Monitoring.FromDate),
				new SqlParameter( "@TO_DATE"        , HL7Monitoring.ToDate)
				
		    };

            Parameters = parameters;
        }

        public HL7Monitoring HL7Monitoring
        {
            get { return _hl7data; }
            set { _hl7data = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
