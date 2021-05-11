using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class GBLRoleInsertData : DataAccessBase
    {
        private GBLRole _gblrole;
        
       
        private GBLRoleInsertDataParameters _gblroleinsertdataparameters;

        public GBLRoleInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLRole_Insert.ToString();
        }

        public void Add()
        {
            _gblroleinsertdataparameters = new GBLRoleInsertDataParameters(GBLRole);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblroleinsertdataparameters.Parameters);

        }

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }
    }

    public class GBLRoleInsertDataParameters
    {
        private GBLRole _gblrole;
        private SqlParameter[] _parameters;

        public GBLRoleInsertDataParameters(GBLRole gblrole)
        {
            GBLRole = gblrole;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
                new SqlParameter( "@RoleID"	, GBLRole.RoleID ) ,
                new SqlParameter( "@RoleUID"	, GBLRole.RoleUID) ,
                new SqlParameter( "@RoleName"	, GBLRole.RoleName ) ,
                new SqlParameter( "@RoleDesc"	, GBLRole.RoleDesc ) ,
                new SqlParameter( "@IsActive"	, GBLRole.IsActive ) ,
                new SqlParameter( "@RoleDTLID"	, GBLRole.RoleDTLId ) ,
                new SqlParameter( "@SubMenuUID"	, GBLRole.SubMenuUID ) ,
                new SqlParameter( "@CanView"	, GBLRole.CanView ) ,
                new SqlParameter( "@CanRemove"	, GBLRole.CanRemove ) ,
                new SqlParameter( "@CanCreate"	, GBLRole.CanCreate ) ,
                new SqlParameter( "@CanModify"	, GBLRole.CanModify ) ,
                new SqlParameter( "@OrgID"        , GBLRole.OrgID ) ,
				new SqlParameter( "@CreatedBy"	, GBLRole.CreatedBy ) ,
				new SqlParameter( "@CreatedOn"	    , GBLRole.CreatedOn ) ,
                new SqlParameter( "@ModifiedBy" , GBLRole.ModifiedBy ),
	            new SqlParameter( "@ModifiedOn" , GBLRole.ModifiedOn ),
			};

            Parameters = parameters;
        }

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
