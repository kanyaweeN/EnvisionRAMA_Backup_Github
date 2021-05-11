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
    public class RISSF09UpdateData : DataAccessBase
    {
        private RISSF09Data _obj;

        private RISSF09UpdateDataParameters _objinsertdataparameters;

        public RISSF09UpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF09_Update.ToString();
        }

        public void Add()
        {
            _objinsertdataparameters = new RISSF09UpdateDataParameters(RISSF09Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _objinsertdataparameters.Parameters);

        }

        public RISSF09Data RISSF09Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }

    public class RISSF09UpdateDataParameters
    {
        private RISSF09Data _obj;
        private SqlParameter[] _parameters;

        public RISSF09UpdateDataParameters(RISSF09Data obj)
        {
            RISSF09Data = obj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EXAM_TYPE_ID"	, RISSF09Data.EXAM_TYPE_ID ) ,
				new SqlParameter( "@EXAM_TYPE_UID"	, RISSF09Data.EXAM_TYPE_UID  ) ,
				new SqlParameter( "@EXAM_TYPE_TEXT"        , RISSF09Data.EXAM_TYPE_TEXT  ) ,
				new SqlParameter( "@IsActive"	, RISSF09Data.IS_ACTIVE ) ,
				new SqlParameter( "@OrgID"	    , RISSF09Data.ORG_ID ) ,
				new SqlParameter( "@LASTMODIFIED_BY"		, RISSF09Data.LASTMODIFIED_BY ) ,
			};

            Parameters = parameters;
        }

        public RISSF09Data RISSF09Data
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
