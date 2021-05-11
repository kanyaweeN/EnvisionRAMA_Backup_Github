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
    public class GBLAlertDeleteData : DataAccessBase
    {
        private GBLAlert _gblalert;

        private GBLAlertInsertDataParameters _gblalertinsertdataparameters;

        public GBLAlertDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLAlert_Delete.ToString();
        }

        public void Delete()
        {
            _gblalertinsertdataparameters = new GBLAlertInsertDataParameters(GBLAlert);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblalertinsertdataparameters.Parameters);

        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }
    }

    public class GBLAlertInsertDataParameters
    {
        private GBLAlert _gblalert;
        private SqlParameter[] _parameters;

        public GBLAlertInsertDataParameters(GBLAlert gblalert)
        {
            GBLAlert = gblalert;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@AlertID"		,  GBLAlert.AlertID)
			};

            Parameters = parameters;
        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
