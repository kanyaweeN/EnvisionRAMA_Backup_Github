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
    public class AlertSelectData : DataAccessBase
    {
       
        private AlertSelectDataParameters _alertselectdataparameters;

        public AlertSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.AlertObjects_Select.ToString();
        }

        public DataSet Get(string uid)
        {
            int sp=3;
            string uids = uid;
            if (uids == "")
            {
                sp = 1;
                
            }
            DataSet ds;
            _alertselectdataparameters = new AlertSelectDataParameters(sp,uids,0);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _alertselectdataparameters.Parameters);
            return ds;

        }

        public DataSet Get2(int uid)
        {
            int sp = 2;
            int ids = uid;
            
            DataSet ds;
            _alertselectdataparameters = new AlertSelectDataParameters(sp, null,ids);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _alertselectdataparameters.Parameters);
            return ds;

        }


        
    }

    public class AlertSelectDataParameters
    {
        int sp;
        string uid;
        int dtlid;
        private SqlParameter[] _parameters;

        public AlertSelectDataParameters(int spno, string uidno, int dtl_id)
        {
            sp = spno;
            uid = uidno;
            dtlid = dtl_id;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, sp),
                new SqlParameter( "@UdID"		    , uid ),
                new SqlParameter( "@DTL_ID"		    , dtlid ),
 
					
				
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
