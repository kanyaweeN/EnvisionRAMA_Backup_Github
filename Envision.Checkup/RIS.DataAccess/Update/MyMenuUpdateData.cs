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
using RIS.Common.Common;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class MymenuUpdateData : DataAccessBase
    {

        int submenu;
        string active;
        private MyMenuInsertDataParameters _gblalertinsertdataparameters;

        public MymenuUpdateData(int uid, string status)
        {
            submenu = uid;
            active = status;
            StoredProcedureName = StoredProcedure.Name.Prc_MyMenu_Update.ToString();
        }

        public void Update()
        {
            _gblalertinsertdataparameters = new MyMenuInsertDataParameters(submenu,active);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblalertinsertdataparameters.Parameters);

        }

        
    }

    public class MyMenuInsertDataParameters
    {
        int submenuid;
        string active;
        private SqlParameter[] _parameters;

        public MyMenuInsertDataParameters(int uid,string status)
        {
            submenuid = uid;
            active = status;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EMP_ID"	, new GBLEnvVariable().UserID),
				new SqlParameter( "@SUBMENU_ID"        , submenuid ) ,
				new SqlParameter( "@IsActive"	    , active ) ,
				new SqlParameter( "@ModifiedBy"		, new GBLEnvVariable().UserID )		

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
