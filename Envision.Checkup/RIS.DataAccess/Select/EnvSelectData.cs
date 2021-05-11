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
    public class EnvSelectData : DataAccessBase
    {
        private EnvSelectDataParameters _envselectdataparameters;

        public EnvSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLEnv.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _envselectdataparameters = new EnvSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _envselectdataparameters.Parameters);
            return ds;
        }
    }

    public class EnvSelectDataParameters
    {

        private SqlParameter[] _parameters;

        public EnvSelectDataParameters()
        {
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
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
