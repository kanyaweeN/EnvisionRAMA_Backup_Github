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

namespace RIS.DataAccess.Update
{
    public class PatientUpdateData : DataAccessBase
    {
        private RISPatstatus _patstatus;

        private RISPatstatusInsertDataParameters _patstatusinsertdataparameters;

        public PatientUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF04_Update.ToString();
        }

        public void Add()
        {
            _patstatusinsertdataparameters = new RISPatstatusInsertDataParameters(RISPatstatus);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _patstatusinsertdataparameters.Parameters);

        }

        public RISPatstatus RISPatstatus
        {
            get { return _patstatus; }
            set { _patstatus = value; }
        }
    }

    public class RISPatstatusInsertDataParameters
    {
        private RISPatstatus _patstatus;
        private SqlParameter[] _parameters;

        public RISPatstatusInsertDataParameters(RISPatstatus patstatus)
        {
            RISPatstatus = patstatus;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@STATUS_ID"	, RISPatstatus.STATUS_ID ) ,
				new SqlParameter( "@STATUS_UID"	, RISPatstatus.STATUS_UID ) ,
				new SqlParameter( "@STATUS_TEXT"        , RISPatstatus.STATUS_TEXT ) ,
				new SqlParameter( "@IsActive"	, RISPatstatus.IsActive  ) ,
				new SqlParameter( "@OrgID"	    , RISPatstatus.ORG_ID ) ,
				new SqlParameter( "@LAST_MODIFIED_BY"		, RISPatstatus.LAST_MODIFIED_BY ) ,
			};

            Parameters = parameters;
        }

        public RISPatstatus RISPatstatus
        {
            get { return _patstatus; }
            set { _patstatus = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
