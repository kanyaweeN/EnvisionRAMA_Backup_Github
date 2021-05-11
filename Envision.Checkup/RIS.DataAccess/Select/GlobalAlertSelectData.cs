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


namespace RIS.DataAccess.Select
{
    public class GlobalAlertSelectData : DataAccessBase
    {
        private GBLAlert _gblalert;
        private GlobalAlertSelectDataParameters _alertselectdataparameters;

        public GlobalAlertSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ShowAlert.ToString();
        }

        public DataSet Get()
        {
           
            DataSet ds;
            _alertselectdataparameters = new GlobalAlertSelectDataParameters(GBLAlert);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _alertselectdataparameters.Parameters);
            return ds;

        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }

        

    }

    public class GlobalAlertSelectDataParameters
    {
        private GBLAlert _gblalert;
        private SqlParameter[] _parameters;

        public GlobalAlertSelectDataParameters(GBLAlert gblalert)
        {
            GBLAlert = gblalert;
           Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@AltUID"	, GBLAlert.AlertUID),
                new SqlParameter( "@LangID"		    , GBLAlert.LangID),
               					
				
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
