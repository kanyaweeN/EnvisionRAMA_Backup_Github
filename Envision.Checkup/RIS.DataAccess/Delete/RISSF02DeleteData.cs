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
    public class RISSF02DeleteData : DataAccessBase
    {
        private RISSF02Data  _obj;

        private OBJInsertDataParameters _objinsertdataparameters;

        public RISSF02DeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF02_Delete.ToString();
        }

        public void Delete()
        {
            _objinsertdataparameters = new OBJInsertDataParameters(RISSF02Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _objinsertdataparameters.Parameters);

        }

        public RISSF02Data RISSF02Data
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }

    public class OBJInsertDataParameters
    {
        private RISSF02Data _obj;
        private SqlParameter[] _parameters;

        public OBJInsertDataParameters(RISSF02Data obj)
        {
            RISSF02Data = obj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ICD_ID"		,  RISSF02Data.ICD_ID)
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
