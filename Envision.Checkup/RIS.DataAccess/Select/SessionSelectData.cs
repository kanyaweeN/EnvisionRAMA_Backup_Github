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
    public class SessionSelectData : DataAccessBase
    {
        private SessionSelectDataParameters _sessionselectdataparameters;

        public SessionSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_CheckSession.ToString();
        }

        public DataSet Get(int userid, int sptype)
        {
            DataSet ds;
            _sessionselectdataparameters = new SessionSelectDataParameters(userid, sptype);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _sessionselectdataparameters.Parameters);
            return ds;

        }


    }

    public class SessionSelectDataParameters
    {

        private SqlParameter[] _parameters;

        public SessionSelectDataParameters(int usrid, int sptype)
        {
            Build(usrid, sptype);
        }

        private void Build(int user, int sp)
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter( "@SP_TYPE"	, sp ),
                new SqlParameter( "@EMP_ID"	, user ),
				new SqlParameter( "@ORG_ID"	, new GBLEnvVariable().OrgID  )
             				
		    };

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
