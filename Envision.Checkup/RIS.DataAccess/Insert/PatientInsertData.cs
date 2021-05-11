/*
 * Project	: RIS
 *
 * Author   : Tossapol Anchaleechamaikorn
 * eMail    : yod.jim@gmail.com
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
    public class PatientInsertData : DataAccessBase
    {
        private RISPatstatus _gbpatient;

        private PatientInsertDataParameters _patientinsertdataparameters;

        public PatientInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF04_Insert.ToString();
        }

        public void Add()
        {
            _patientinsertdataparameters = new PatientInsertDataParameters(RISPatstatus);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _patientinsertdataparameters.Parameters);

        }

        public RISPatstatus RISPatstatus
        {
            get { return _gbpatient; }
            set { _gbpatient = value; }
        }
    }

    public class PatientInsertDataParameters
    {
        private RISPatstatus _gbpatient;
        private SqlParameter[] _parameters;

        public PatientInsertDataParameters(RISPatstatus gbpatient)
        {
            RISPatstatus = gbpatient;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@STATUS_UID"	, RISPatstatus.STATUS_UID ) ,
				new SqlParameter( "@STATUS_TEXT"        , RISPatstatus.STATUS_TEXT ) ,
				new SqlParameter( "@IsActive"	, RISPatstatus.IsActive ) ,
				new SqlParameter( "@OrgID"	    , RISPatstatus.ORG_ID ) ,
				new SqlParameter( "@CreatedBy"		, RISPatstatus.CREATED_BY ) 

			};

            Parameters = parameters;
        }

        public RISPatstatus RISPatstatus
        {
            get { return _gbpatient; }
            set { _gbpatient = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
