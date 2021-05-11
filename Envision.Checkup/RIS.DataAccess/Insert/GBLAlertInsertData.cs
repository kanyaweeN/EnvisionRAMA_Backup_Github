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
    public class GBLAlertInsertData : DataAccessBase
    {
        private GBLAlert _gblalert;
       
        private GBLAlertInsertDataParameters _gblalertinsertdataparameters;

        public GBLAlertInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLAlert_Insert.ToString();
        }

        public void Add()
        {
            _gblalertinsertdataparameters = new GBLAlertInsertDataParameters(GBLAlert);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblalertinsertdataparameters.Parameters);

        }

        public GBLAlert GBLAlert
        {
            get { return _gblalert; }
            set { _gblalert = value; }
        }
    }

    public class GBLAlertInsertDataParameters
    {
        private GBLAlert _gblalert;
        private SqlParameter[] _parameters;

        public GBLAlertInsertDataParameters(GBLAlert gblalert)
        {
            GBLAlert = gblalert;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@AlertUID"	, GBLAlert.AlertUID ) ,
				new SqlParameter( "@OrgID"        , GBLAlert.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLAlert.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLAlert.CreatedOn ) ,
				new SqlParameter( "@ModifiedBy"		, GBLAlert.ModifiedBy ) ,
				new SqlParameter( "@ModifiedOn"	    , GBLAlert.ModifiedOn ),
                new SqlParameter( "@LangID"		    , GBLAlert.LangID ) ,
				new SqlParameter( "@AlertText"        , GBLAlert.AlertText ) ,
				new SqlParameter( "@AlertType"	, GBLAlert.AlertType ) ,
				new SqlParameter( "@IsActive"	    , GBLAlert.IsActive ) ,
				new SqlParameter( "@AlertTitle"		, GBLAlert.AlertTitle ) ,
				new SqlParameter( "@AlertButton"	    , GBLAlert.AlertButton ),
                new SqlParameter( "@CaptionButton1"	, GBLAlert.CaptionButton1 ) ,
				new SqlParameter( "@CaptionButton2"	    , GBLAlert.CaptionButton2 ) ,
				new SqlParameter( "@CaptionButton3"		, GBLAlert.CaptionButton3 ) ,
                new SqlParameter( "@AlertID"		,  GBLAlert.AlertID),
                new SqlParameter( "@DefaultBtn"		,  GBLAlert.DefaultBtn),
                new SqlParameter( "@TimeSec"		,  GBLAlert.TimeSec),

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
