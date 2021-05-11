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

namespace RIS.DataAccess.Delete
{
    public class RISSF09DeleteData : DataAccessBase
    {
        private RISSF09Data  _obj;

        private OBJInsertDataParameters1 _objinsertdataparameters;

        public RISSF09DeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF09_Delete.ToString();
        }

        public void Delete()
        {
            _objinsertdataparameters = new OBJInsertDataParameters1(RISSF09Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _objinsertdataparameters.Parameters);

        }

        public RISSF09Data RISSF09Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }

    public class OBJInsertDataParameters1
    {
        private RISSF09Data _obj;
        private SqlParameter[] _parameters;

        public OBJInsertDataParameters1(RISSF09Data obj)
        {
            RISSF09Data = obj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@EXAM_TYPE_ID"		,  RISSF09Data.EXAM_TYPE_ID)
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
