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
    public class GBLExceptionLogInsertData : DataAccessBase
    {
        private GBLException _gblexception;

        private GBLExceptionLogInsertDataParameters _gblexceptionloginsertdataparameters;

        public GBLExceptionLogInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_GBLExceptionLog.ToString();
        }

        public void Add()
        {
            _gblexceptionloginsertdataparameters = new GBLExceptionLogInsertDataParameters(GBLException);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblexceptionloginsertdataparameters.Parameters);

        }

        public GBLException GBLException
        {
            get { return _gblexception; }
            set { _gblexception = value; }
        }
    }

    public class GBLExceptionLogInsertDataParameters
    {
        private GBLException _gblexception;
        private SqlParameter[] _parameters;

        public GBLExceptionLogInsertDataParameters(GBLException gblexception)
        {
            GBLException = gblexception;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EXC_TYPE"	, GBLException.EXC_TYPE) ,
				new SqlParameter( "@EXC_TEXT"        , GBLException.EXC_TEXT ) ,
				new SqlParameter( "@EXC_IP"	, GBLException.EXC_IP ) ,
				new SqlParameter( "@EXC_PC_NAME"	    , GBLException.EXC_PC_NAME ) ,
				new SqlParameter( "@CURRENT_FORM_ID"		, GBLException.CURRENT_FORM_ID) ,
				new SqlParameter( "@CURRENT_LANG_ID"	    , GBLException.CURRENT_LANG_ID ),
                new SqlParameter( "@CONNECTED_EMP_ID"		    , GBLException.CONNECTED_EMP_ID) ,
				new SqlParameter( "@ORG_ID"        , GBLException.ORG_ID ) ,
				new SqlParameter( "@CREATED_BY"	, GBLException.CREATED_BY )
				
			};

            Parameters = parameters;
        }

        public GBLException GBLException
        {
            get { return _gblexception; }
            set { _gblexception = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
