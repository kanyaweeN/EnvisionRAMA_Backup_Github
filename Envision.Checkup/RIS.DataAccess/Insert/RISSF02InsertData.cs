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
    public class RISSF02InsertData : DataAccessBase
    {
        private RISSF02Data  _gbobj;

        private SF02InsertDataParameters _sf02insertdataparameters;

        public RISSF02InsertData()
        {
            StoredProcedureName = StoredProcedure.Name.PRC_RIS_SF02_Insert.ToString();
        }

        public void Add()
        {
            _sf02insertdataparameters = new SF02InsertDataParameters(RISSF02Data);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _sf02insertdataparameters.Parameters);

        }

        public RISSF02Data RISSF02Data
        {
            get { return _gbobj; }
            set { _gbobj = value; }
        }
    }

    public class SF02InsertDataParameters
    {
        private RISSF02Data  _gbobj;
        private SqlParameter[] _parameters;

        public SF02InsertDataParameters(RISSF02Data gbobj)
        {
            RISSF02Data = gbobj;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@ICD_UID"	, RISSF02Data.ICD_UID ) ,
				new SqlParameter( "@ICD_DESC"        , RISSF02Data.ICD_DESC ) ,
				new SqlParameter( "@ICD_VERSION"	, RISSF02Data.ICD_VERSION ) ,
				new SqlParameter( "@IS_UPDATE"	    , RISSF02Data.IS_UPDATE ) ,
				new SqlParameter( "@IS_DELETED"		, RISSF02Data.IS_DELETED ), 
				new SqlParameter( "@OrgID"	    , RISSF02Data.ORG_ID ) ,
				new SqlParameter( "@CreatedBy"		, RISSF02Data.CREATED_BY ) 

			};

            Parameters = parameters;
        }

        public RISSF02Data RISSF02Data
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
