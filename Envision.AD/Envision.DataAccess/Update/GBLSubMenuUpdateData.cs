using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLSubMenuUpdateData : DataAccessBase
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }

        public GBLSubMenuUpdateData()
        {
            GBL_SUBMENU = new GBL_SUBMENU();
            StoredProcedureName = StoredProcedure.GBLSubMenu_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENU.MenuUID ) ,
                Parameter( "@txtSubUID"	, GBL_SUBMENU.SUBMENU_UID ) ,
                Parameter( "@txtSubClassName"	, GBL_SUBMENU.SUBMENU_CLASS_NAME ) ,
                Parameter( "@txtSubNameUser"	, GBL_SUBMENU.SUBMENU_NAME_USER ) ,
                Parameter( "@txtSubType"	, GBL_SUBMENU.SUBMENU_TYPE ) ,
                Parameter( "@txtSubNameSys"	, GBL_SUBMENU.SUBMENU_NAME_SYS ) ,
                Parameter( "@txtDesc"	, GBL_SUBMENU.DESCR ) ,
                Parameter( "@cmbParent"	, GBL_SUBMENU.PARENT ) ,
                Parameter( "@txtSlno"	, GBL_SUBMENU.SL_NO ) ,
                Parameter( "@chkActive"	, GBL_SUBMENU.IS_ACTIVE ) ,
                Parameter( "@chkView"	, GBL_SUBMENU.CAN_VIEW ) ,
                Parameter( "@chkRemove"	, GBL_SUBMENU.CAN_REMOVE ) ,
                Parameter( "@chkCreate"	, GBL_SUBMENU.CAN_CREATE ) ,
                Parameter( "@chkModify"	, GBL_SUBMENU.CAN_CREATE ) ,
                Parameter( "@chkAddToHome"	, GBL_SUBMENU.ADD_TO_HOME ) ,

				Parameter( "@OrgID"        , GBL_SUBMENU.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENU.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_SUBMENU.CREATED_ON ) ,
                Parameter( "@ModifiedBy" , GBL_SUBMENU.LAST_MODIFIED_BY ),
	            Parameter( "@ModifiedOn" , GBL_SUBMENU.LAST_MODIFIED_ON ),
				Parameter( "@SubMenuID"	    , GBL_SUBMENU.SUBMENU_ID ) ,
                                      };
            return parameters;
        }
    }
}
