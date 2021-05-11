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

namespace RIS.DataAccess.Update
{
    public class RISSF02UpdateData : DataAccessBase
    {
        private RISSF02Data _obj;

        private RISSF02UpdateDataParameters _objinsertdataparameters;

        public RISSF02UpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF02_Update.ToString();
        }

        public void Add()
        {
            _objinsertdataparameters = new RISSF02UpdateDataParameters(RISSF02Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _objinsertdataparameters.Parameters);

        }

        public RISSF02Data RISSF02Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }

    public class RISSF02UpdateDataParameters
    {
        private RISSF02Data _obj;
        private SqlParameter[] _parameters;

        public RISSF02UpdateDataParameters(RISSF02Data obj)
        {
            RISSF02Data = obj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ICD_ID"	, RISSF02Data.ICD_ID) ,
				new SqlParameter( "@ICD_UID"	, RISSF02Data.ICD_UID ) ,
				new SqlParameter( "@ICD_DESC"        , RISSF02Data.ICD_DESC ) ,
				new SqlParameter( "@ICD_VERSION"	, RISSF02Data.ICD_VERSION  ) ,
				new SqlParameter( "@ORG_ID"	    , RISSF02Data.ORG_ID ) ,
				new SqlParameter( "@IS_DELETED"		, RISSF02Data.IS_DELETED ) ,
				new SqlParameter( "@IS_UPDATE"		, RISSF02Data.IS_UPDATE ) ,
				new SqlParameter( "@LASTMODIFIED_BY"		, RISSF02Data.LASTMODIFIED_BY ) ,
			};

            Parameters = parameters;
        }

        public RISSF02Data RISSF02Data
        {
            get { return _obj; }
            set { _obj = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
