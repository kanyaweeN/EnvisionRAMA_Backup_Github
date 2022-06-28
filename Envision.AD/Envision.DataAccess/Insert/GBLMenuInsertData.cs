using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLMenuInsertData : DataAccessBase
    {
        public GBL_MENU GBL_MENU { get; set; }
        public GBLMenuInsertData()
        {
            GBL_MENU = new GBL_MENU();
            StoredProcedureName = StoredProcedure.GBLMenu_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@MenuUID"	, GBL_MENU.MENU_UID ) ,
                Parameter( "@MenuName"        , GBL_MENU.MENU_NAME ) ,
				Parameter( "@MenuNameSpace"	, GBL_MENU.MENU_NAMESPACE ) ,
                Parameter( "@MenuDesc"		, GBL_MENU.DESCR ) ,
				Parameter( "@MenuParent"	    , GBL_MENU.PARENT ),
                Parameter( "@MenuSlNo"	, GBL_MENU.SL_NO ) ,
                Parameter( "@MenuIsActive"	    , GBL_MENU.IS_ACTIVE ) ,
				Parameter( "@OrgID"        , GBL_MENU.ORG_ID ) ,
				Parameter( "@CreatedBy"	, GBL_MENU.CREATED_BY ) ,
				Parameter( "@CreatedOn"	    , GBL_MENU.CREATED_ON ) ,
                Parameter( "@ModifiedBy" , GBL_MENU.LAST_MODIFIED_BY ),
	            Parameter( "@ModifiedOn" , GBL_MENU.LAST_MODIFIED_ON ),
				Parameter( "@MenuID"	    , GBL_MENU.MENU_ID ) ,
                Parameter( "@MenuICon"	    , GBL_MENU.MENU_ICON ) ,
            };
            return parameters;
        }
    }
}
