using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLSubMenuObjectsInsertData : DataAccessBase
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }

        public GBLSubMenuObjectsInsertData()
        {
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjects_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter CreatedOn = Parameter();
            CreatedOn.ParameterName = "@CreatedOn";
            if (GBL_SUBMENUOBJECT.CREATED_ON == null)
                CreatedOn.Value = DBNull.Value;
            else
                CreatedOn.Value = GBL_SUBMENUOBJECT.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENUOBJECT.CREATED_ON;

            DbParameter ModifiedOn = Parameter();
            ModifiedOn.ParameterName = "@ModifiedOn";
            if (GBL_SUBMENUOBJECT.LAST_MODIFIED_ON == null)
                ModifiedOn.Value = DBNull.Value;
            else
                ModifiedOn.Value = GBL_SUBMENUOBJECT.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENUOBJECT.LAST_MODIFIED_ON;


            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENUOBJECT.SubMenuUID ) ,
                Parameter( "@ObjectType"	, GBL_SUBMENUOBJECT.OBJECT_TYPE) ,
                Parameter( "@ObjectName"	, GBL_SUBMENUOBJECT.OBJECT_NAME) ,
                Parameter( "@OrgID"        , GBL_SUBMENUOBJECT.ORG_ID) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENUOBJECT.CREATED_BY) ,
				CreatedOn ,
                Parameter( "@ModifiedBy" , GBL_SUBMENUOBJECT.LAST_MODIFIED_BY),
	            ModifiedOn,
            };
            return parameters;
        }
    }
}
