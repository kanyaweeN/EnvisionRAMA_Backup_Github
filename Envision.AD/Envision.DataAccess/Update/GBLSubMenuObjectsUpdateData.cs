using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLSubMenuObjectsUpdateData : DataAccessBase
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }

        public GBLSubMenuObjectsUpdateData()
        {
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
            StoredProcedureName = StoredProcedure.GBLSubMenuObjects_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENUOBJECT.SubMenuUID ) ,
                Parameter( "@ObjectID"	, GBL_SUBMENUOBJECT.OBJECT_ID ) ,
                Parameter( "@ObjectType"	, GBL_SUBMENUOBJECT.OBJECT_TYPE ) ,
                Parameter( "@ObjectName"	, GBL_SUBMENUOBJECT.OBJECT_NAME ) ,
                Parameter( "@OrgID"        , GBL_SUBMENUOBJECT.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENUOBJECT.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_SUBMENUOBJECT.CREATED_ON ) ,
                Parameter( "@ModifiedBy" , GBL_SUBMENUOBJECT.LAST_MODIFIED_BY ),
	            Parameter( "@ModifiedOn" , GBL_SUBMENUOBJECT.LAST_MODIFIED_ON ),
                                      };
            return parameters;
        }
    }
}
