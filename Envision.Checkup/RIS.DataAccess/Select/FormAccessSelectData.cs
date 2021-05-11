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
    public class FormAccessSelectData : DataAccessBase
    {

        private FormAccessSelectDataParameters _alertselectdataparameters;

        public FormAccessSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_SetFormAccess.ToString();
        }

        public DataSet Get()
        {

            DataSet ds;
            _alertselectdataparameters = new FormAccessSelectDataParameters();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _alertselectdataparameters.Parameters);
            return ds;

        }

       
    }

    public class FormAccessSelectDataParameters
    {
       
        private SqlParameter[] _parameters;

        public FormAccessSelectDataParameters()
        {
          Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@FormID"	, new GBLEnvVariable().CurrentFormID),
                new SqlParameter( "@EmpID"		    , new GBLEnvVariable().UserID),
                new SqlParameter( "@OrgID"		    , new GBLEnvVariable().OrgID)
               					
				
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
