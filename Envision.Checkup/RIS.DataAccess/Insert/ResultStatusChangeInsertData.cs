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
    public class ResultStatusChangeInsertData : DataAccessBase
    {
        private HL7Monitoring _temp;

        private ResultStatusInsertDataParameters _resultdataparameters;

        public ResultStatusChangeInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ResultStatusChangeLog.ToString();
        }

        public void Add()
        {
            _resultdataparameters = new ResultStatusInsertDataParameters(HL7Monitoring);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _resultdataparameters.Parameters);

        }

        public HL7Monitoring HL7Monitoring
        {
            get { return _temp; }
            set { _temp = value; }
        }
    }

    public class ResultStatusInsertDataParameters
    {
        private HL7Monitoring _temp;
        private SqlParameter[] _parameters;

        public ResultStatusInsertDataParameters(HL7Monitoring template)
        {
            HL7Monitoring = template;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@HN"	, HL7Monitoring.PatientID ) ,
                new SqlParameter( "@ORDER_ID"	, HL7Monitoring.OrderID ) ,
				new SqlParameter( "@ACCESSION_NO"        , HL7Monitoring.AccessionNo ) ,
				new SqlParameter( "@EXAM_ID"	, HL7Monitoring.ExamID ) ,
				new SqlParameter( "@ORGINAL_STATUS"	    , HL7Monitoring.OriginalStatus) ,
				new SqlParameter( "@CHANGED_STATUS"		, HL7Monitoring.ChangeStatus ) ,
				new SqlParameter( "@REQUEST_BY"	    , HL7Monitoring.RequestBy ), 
                new SqlParameter( "@CHNAGE_PC"	    , HL7Monitoring.ChangePC ), 
                new SqlParameter( "@ORG_ID"	    , HL7Monitoring.OrgID ),
                new SqlParameter( "@CREATED_BY"	    , HL7Monitoring.CreatedBy ),
                new SqlParameter( "@HL7_TEXT"	    , HL7Monitoring.Hl7Text ),

			};

            Parameters = parameters;
        }

        public HL7Monitoring HL7Monitoring
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
