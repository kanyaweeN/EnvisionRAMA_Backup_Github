/*
 * Project	: RIS
 *
 * Author   : Tossapol Anchaleechamaikorn
 * eMail    : yod.jim@gmail.com
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
    public class RISSF09InsertData : DataAccessBase
    {
        private RISSF09Data  _gbobj;

        private SF09InsertDataParameters _sf09insertdataparameters;

        public RISSF09InsertData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF09_Insert.ToString();
        }

        public void Add()
        {
            _sf09insertdataparameters = new SF09InsertDataParameters(RISSF09Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _sf09insertdataparameters.Parameters);

        }

        public RISSF09Data RISSF09Data
        {
            get { return _gbobj; }
            set { _gbobj = value; }
        }
    }

    public class SF09InsertDataParameters
    {
        private RISSF09Data  _gbobj;
        private SqlParameter[] _parameters;

        public SF09InsertDataParameters(RISSF09Data gbobj)
        {
            RISSF09Data = gbobj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EXAM_TYPE_UID"	, RISSF09Data.EXAM_TYPE_UID ) ,
				new SqlParameter( "@EXAM_TYPE_TEXT"        , RISSF09Data.EXAM_TYPE_TEXT ) ,
				new SqlParameter( "@IsActive nvarchar"	, RISSF09Data.IS_ACTIVE ) ,
				new SqlParameter( "@OrgID"	    , RISSF09Data.ORG_ID ) ,
				new SqlParameter( "@CreatedBy"		, RISSF09Data.CREATED_BY ) 

			};

            Parameters = parameters;
        }

        public RISSF09Data RISSF09Data
        {
            get { return _gbobj; }
            set { _gbobj = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
