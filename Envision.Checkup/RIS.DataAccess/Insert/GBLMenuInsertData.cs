using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLMenuInsertData : DataAccessBase
    {
        private GBLMenu _gblmenu;
       
        private GBLMenuInsertDataParameters _gblmenuinsertdataparameters;

        public GBLMenuInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLMenu_Insert.ToString();
        }

        public void Add()
        {
            _gblmenuinsertdataparameters = new GBLMenuInsertDataParameters(GBLMenu);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblmenuinsertdataparameters.Parameters);

        }

        public GBLMenu GBLMenu
        {
            get { return _gblmenu; }
            set { _gblmenu = value; }
        }
    }

    public class GBLMenuInsertDataParameters
    {
        private GBLMenu _gblmenu;
        private SqlParameter[] _parameters;

        public GBLMenuInsertDataParameters(GBLMenu gblmenu)
        {
            GBLMenu = gblmenu;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@MenuUID"	, GBLMenu.MenuUID ) ,
                new SqlParameter( "@MenuName"        , GBLMenu.MenuName ) ,
				new SqlParameter( "@MenuNameSpace"	, GBLMenu.MenuNameSpace ) ,
                new SqlParameter( "@MenuDesc"		, GBLMenu.MenuDesc ) ,
				new SqlParameter( "@MenuParent"	    , GBLMenu.MenuParent ),
                new SqlParameter( "@MenuSlNo"	, GBLMenu.MenuSLNo ) ,
                new SqlParameter( "@MenuIsActive"	    , GBLMenu.MenuIsActive ) ,
				new SqlParameter( "@OrgID"        , GBLMenu.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLMenu.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLMenu.CreatedOn ) ,
                new SqlParameter( "@ModifiedBy" , GBLMenu.ModifiedBy ),
	            new SqlParameter( "@ModifiedOn" , GBLMenu.ModifiedOn ),
				new SqlParameter( "@MenuID"	    , GBLMenu.MenuID ) ,
                new SqlParameter( "@MenuICon"	    , GBLMenu.MenuICon ) ,
			};

            Parameters = parameters;
        }

        public GBLMenu GBLMenu
        {
            get { return _gblmenu; }
            set { _gblmenu = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
