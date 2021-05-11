using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLSubMenuInsertData : DataAccessBase
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }

        public GBLSubMenuInsertData()
        {
            GBL_SUBMENU = new GBL_SUBMENU();
            StoredProcedureName = StoredProcedure.GBLSubMenu_Insert;
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
            if (GBL_SUBMENU.CREATED_ON == null)
                CreatedOn.Value = DBNull.Value;
            else
                CreatedOn.Value = GBL_SUBMENU.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENU.CREATED_ON;

            DbParameter ModifiedOn = Parameter();
            ModifiedOn.ParameterName = "@ModifiedOn";
            if (GBL_SUBMENU.LAST_MODIFIED_ON == null)
                ModifiedOn.Value = DBNull.Value;
            else
                ModifiedOn.Value = GBL_SUBMENU.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : GBL_SUBMENU.LAST_MODIFIED_ON;


            DbParameter[] parameters ={
                Parameter( "@txtUID"	, GBL_SUBMENU.MenuUID ) ,
                Parameter( "@txtSubUID"	, GBL_SUBMENU.SUBMENU_UID ) ,
                Parameter( "@txtSubClassName"	, GBL_SUBMENU.SUBMENU_CLASS_NAME ) ,
                Parameter( "@txtSubNameUser"	, GBL_SUBMENU.SUBMENU_NAME_USER ) ,
                Parameter( "@txtSubType"	, GBL_SUBMENU.SUBMENU_TYPE ) ,
                Parameter( "@txtSubNameSys"	, GBL_SUBMENU.SUBMENU_NAME_SYS) ,
                Parameter( "@txtDesc"	, GBL_SUBMENU.DESCR ) ,
                Parameter( "@cmbParent"	, GBL_SUBMENU.PARENT ) ,
                Parameter( "@txtSlno"	, GBL_SUBMENU.SL_NO ) ,
                Parameter( "@chkActive"	, GBL_SUBMENU.IS_ACTIVE ) ,
                Parameter( "@chkView"	, GBL_SUBMENU.CAN_VIEW ) ,
                Parameter( "@chkRemove"	, GBL_SUBMENU.CAN_REMOVE ) ,
                Parameter( "@chkCreate"	, GBL_SUBMENU.CAN_CREATE ) ,
                Parameter( "@chkModify"	, GBL_SUBMENU.CAN_MODIFY ) ,
                Parameter( "@chkAddToHome"	, GBL_SUBMENU.ADD_TO_HOME ) ,

				Parameter( "@OrgID"        , GBL_SUBMENU.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_SUBMENU.CREATED_BY ) ,
				CreatedOn ,
                Parameter( "@ModifiedBy" , GBL_SUBMENU.LAST_MODIFIED_BY ),
	            ModifiedOn,
            };
            return parameters;
        }
    }
}
