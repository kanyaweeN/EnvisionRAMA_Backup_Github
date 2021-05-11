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
    public class AuthLevelSelectData : DataAccessBase
    {
        private AuthSelectDataParameters _authselectdataparameters;
        private int _empid;
        public AuthLevelSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_RadiologistAuthLevel.ToString();
        }

        public DataSet Get(int emp)
        {
            _empid = emp;
            DataSet ds;
            _authselectdataparameters = new AuthSelectDataParameters(_empid);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _authselectdataparameters.Parameters);
            return ds;

        }


    }

    public class AuthSelectDataParameters
    {

        private SqlParameter[] _parameters;

        public AuthSelectDataParameters(int emp)
        {
            Build(emp);
        }

        private void Build(int emp)
        {


            SqlParameter[] parameters =
		    {
                new SqlParameter( "@EMP_ID" , emp ),
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
