using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLSubMenuInsertData : DataAccessBase
    {
        private GBLSubMenu _gblsubmenu;
       
        private GBLSubMenuInsertDataParameters _gblsubmenuinsertdataparameters;

        public GBLSubMenuInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenu_Insert.ToString();
        }

        public void Add()
        {
            _gblsubmenuinsertdataparameters = new GBLSubMenuInsertDataParameters(GBLSubMenu);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblsubmenuinsertdataparameters.Parameters);

        }

        public GBLSubMenu GBLSubMenu
        {
            get { return _gblsubmenu; }
            set { _gblsubmenu = value; }
        }
    }

    public class GBLSubMenuInsertDataParameters
    {
        private GBLSubMenu _gblsubmenu;
        private SqlParameter[] _parameters;

        public GBLSubMenuInsertDataParameters(GBLSubMenu gblsubmenu)
        {
            GBLSubMenu = gblsubmenu;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@txtUID"	, GBLSubMenu.MenuUID ) ,
                new SqlParameter( "@txtSubUID"	, GBLSubMenu.SubMenuUID ) ,
                new SqlParameter( "@txtSubClassName"	, GBLSubMenu.SubMenuClassName ) ,
                new SqlParameter( "@txtSubNameUser"	, GBLSubMenu.SubMenuNameUser ) ,
                new SqlParameter( "@txtSubType"	, GBLSubMenu.SubMenuType ) ,
                new SqlParameter( "@txtSubNameSys"	, GBLSubMenu.SubMenuNameSys ) ,
                new SqlParameter( "@txtDesc"	, GBLSubMenu.SubMenuDesc ) ,
                new SqlParameter( "@cmbParent"	, GBLSubMenu.SubMenuParent ) ,
                new SqlParameter( "@txtSlno"	, GBLSubMenu.SubMenuSlNo ) ,
                new SqlParameter( "@chkActive"	, GBLSubMenu.SubMenuIsActive ) ,
                new SqlParameter( "@chkView"	, GBLSubMenu.SubMenuCanView ) ,
                new SqlParameter( "@chkRemove"	, GBLSubMenu.SubMenuCanRemove ) ,
                new SqlParameter( "@chkCreate"	, GBLSubMenu.SubMenuCanCreate ) ,
                new SqlParameter( "@chkModify"	, GBLSubMenu.SubMenuCanModify ) ,
                new SqlParameter( "@chkAddToHome"	, GBLSubMenu.SubMenuAddToHome ) ,

				new SqlParameter( "@OrgID"        , GBLSubMenu.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLSubMenu.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLSubMenu.CreatedOn ) ,
                new SqlParameter( "@ModifiedBy" , GBLSubMenu.ModifiedBy ),
	            new SqlParameter( "@ModifiedOn" , GBLSubMenu.ModifiedOn ),
			};

            Parameters = parameters;
        }

        public GBLSubMenu GBLSubMenu
        {
            get { return _gblsubmenu; }
            set { _gblsubmenu = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
