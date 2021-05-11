using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLSubMenuDeleteData : DataAccessBase
    {
        private GBLSubMenu _gblsubmenu;

        private GBLSubMenuInsertDataParameters _gblsubmenuinsertdataparameters;

        public GBLSubMenuDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenu_Delete.ToString();
        }

        public void Delete()
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
				new SqlParameter( "@SubMenuID"		,  GBLSubMenu.SubMenuID),
                new SqlParameter( "@MenuID"		,  GBLSubMenu.MenuID),
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
