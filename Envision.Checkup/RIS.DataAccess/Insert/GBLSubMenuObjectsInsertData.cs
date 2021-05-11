using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLSubMenuObjectsInsertData : DataAccessBase
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        
       
        private GBLSubMenuObjectsInsertDataParameters _gblsubmenuobjectsinsertdataparameters;

        public GBLSubMenuObjectsInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLSubMenuObjects_Insert.ToString();
        }

        public void Add()
        {
            _gblsubmenuobjectsinsertdataparameters = new GBLSubMenuObjectsInsertDataParameters(GBLSubMenuObjects);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblsubmenuobjectsinsertdataparameters.Parameters);

        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }
    }

    public class GBLSubMenuObjectsInsertDataParameters
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        private SqlParameter[] _parameters;

        public GBLSubMenuObjectsInsertDataParameters(GBLSubMenuObjects gblsubmenuobjects)
        {
            GBLSubMenuObjects = gblsubmenuobjects;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@txtUID"	, GBLSubMenuObjects.SubMenuUID ) ,
                new SqlParameter( "@ObjectType"	, GBLSubMenuObjects.ObjectType ) ,
                new SqlParameter( "@ObjectName"	, GBLSubMenuObjects.ObjectName ) ,
                new SqlParameter( "@OrgID"        , GBLSubMenuObjects.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLSubMenuObjects.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLSubMenuObjects.CreatedOn ) ,
                new SqlParameter( "@ModifiedBy" , GBLSubMenuObjects.ModifiedBy ),
	            new SqlParameter( "@ModifiedOn" , GBLSubMenuObjects.ModifiedOn ),
			};

            Parameters = parameters;
        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
