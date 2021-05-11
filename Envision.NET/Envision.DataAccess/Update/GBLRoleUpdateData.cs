using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLRoleUpdateData : DataAccessBase
    {
        public GBLRole GBLRole { get; set; }

        public GBLRoleUpdateData()
        {
            GBLRole = new GBLRole();
            StoredProcedureName = StoredProcedure.GBLRole_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@RoleID"	, GBLRole.RoleID ) ,
                Parameter( "@RoleUID"	, GBLRole.RoleUID) ,
                Parameter( "@RoleName"	, GBLRole.RoleName ) ,
                Parameter( "@RoleDesc"	, GBLRole.RoleDesc ) ,
                Parameter( "@IsActive"	, GBLRole.IsActive ) ,
                Parameter( "@RoleDTLID"	, GBLRole.RoleDTLId ) ,
                Parameter( "@SubMenuUID"	, GBLRole.SubMenuUID ) ,
                Parameter( "@CanView"	, GBLRole.CanView ) ,
                Parameter( "@CanRemove"	, GBLRole.CanRemove ) ,
                Parameter( "@CanCreate"	, GBLRole.CanCreate ) ,
                Parameter( "@CanModify"	, GBLRole.CanModify ) ,
                Parameter( "@OrgID"        , GBLRole.OrgID ) ,
				Parameter( "@CreatedBy"	, GBLRole.CreatedBy ) ,
				Parameter( "@CreatedOn"	    , GBLRole.CreatedOn ) ,
                Parameter( "@ModifiedBy" , GBLRole.ModifiedBy ),
	            Parameter( "@ModifiedOn" , GBLRole.ModifiedOn ),
                                      };
            return parameters;
        }
    }
}
