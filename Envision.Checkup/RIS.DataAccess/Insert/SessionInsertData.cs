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
    public class SessionInsertData : DataAccessBase
    {
        private GBLSession _gblsession;

        private SessionInsertDataParameters _sessioninsertdataparameters;

        public SessionInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_CreateNewSession.ToString();
        }

        public void Add()
        {
            _sessioninsertdataparameters = new SessionInsertDataParameters(GBLSession);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _sessioninsertdataparameters.Parameters);

        }

        public GBLSession GBLSession
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }
    }

    public class SessionInsertDataParameters
    {
        private GBLSession _gblsession;
        private SqlParameter[] _parameters;

        public SessionInsertDataParameters(GBLSession gblsession)
        {
            GBLSession = gblsession;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@SESSION_GUID"	, GBLSession.SessionGUID ) ,
				new SqlParameter( "@EMP_ID"        , GBLSession.EmpID ) ,
				new SqlParameter( "@ORG_ID"	, GBLSession.OrgID ) ,
				new SqlParameter( "@IP_ADDR_CURR"	    , GBLSession.IpAddress ) ,
				new SqlParameter( "@LOGON_TYPE"		, GBLSession.LogonType ) ,
				new SqlParameter( "@SESSION_STAT"	    , GBLSession.LogonStatus ),
               
                
			};

            Parameters = parameters;
        }

        public GBLSession GBLSession
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
