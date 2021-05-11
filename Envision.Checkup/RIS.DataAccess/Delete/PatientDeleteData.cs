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

namespace RIS.DataAccess.Delete
{
    public class PatientDeleteData : DataAccessBase
    {
        private RISPatstatus _patient;

        private PatientInsertDataParameters _patientinsertdataparameters;

        public PatientDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF04_Delete.ToString();
        }

        public void Delete()
        {
            _patientinsertdataparameters = new PatientInsertDataParameters(RISPatstatus);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _patientinsertdataparameters.Parameters);

        }

        public RISPatstatus RISPatstatus
        {
            get { return _patient; }
            set { _patient = value; }
        }
    }

    public class PatientInsertDataParameters
    {
        private RISPatstatus _patient;
        private SqlParameter[] _parameters;

        public PatientInsertDataParameters(RISPatstatus patient)
        {
            RISPatstatus = patient;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@STATUS_ID"		,  RISPatstatus.STATUS_ID)
			};

            Parameters = parameters;
        }

        public RISPatstatus RISPatstatus
        {
            get { return _patient; }
            set { _patient = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
