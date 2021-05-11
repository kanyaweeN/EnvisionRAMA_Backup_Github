using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Delete
{
    public class GBLMenuDeleteData : DataAccessBase
    {
        private GBLMenu _gblmenu;

        private GBLMenuInsertDataParameters _gblmenuinsertdataparameters;

        public GBLMenuDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLMenu_Delete.ToString();
        }

        public void Delete()
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
				new SqlParameter( "@MenuID"		,  GBLMenu.MenuID)
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
