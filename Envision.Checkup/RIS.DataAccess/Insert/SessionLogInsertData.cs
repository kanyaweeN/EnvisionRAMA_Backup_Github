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
    public class SessionLogInsertData : DataAccessBase
    {
        private GBLSessionLog _gblsession;

        private SessionLogInsertDataParameters _sessionloginsertdataparameters;

        public SessionLogInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_SessionLog_IN_OUT.ToString();
        }

        public void Add()
        {
            _sessionloginsertdataparameters = new SessionLogInsertDataParameters(GBLSessionLog);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _sessionloginsertdataparameters.Parameters);

        }

        public GBLSessionLog GBLSessionLog
        {
            get { return _gblsession; }
            set { _gblsession = value; }
        }
    }

    public class SessionLogInsertDataParameters
    {
        private GBLSessionLog _gblsession;
        private SqlParameter[] _parameters;

        public SessionLogInsertDataParameters(GBLSessionLog gblsession)
        {
            GBLSessionLog = gblsession;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@SP_TYPE"	, GBLSessionLog.SPType ) ,
				new SqlParameter( "@SESSION_GUID"        , GBLSessionLog.SessionGUID ) ,
				new SqlParameter( "@SUBMENU_ID"	, GBLSessionLog.SubmenuID ) ,
				new SqlParameter( "@ORG_ID"	    , GBLSessionLog.OrgID ) ,
				new SqlParameter( "@CREATED_BY"		, GBLSessionLog.CreatedBy ) ,
				              
                
			};

            Parameters = parameters;
        }

        public GBLSessionLog GBLSessionLog
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
