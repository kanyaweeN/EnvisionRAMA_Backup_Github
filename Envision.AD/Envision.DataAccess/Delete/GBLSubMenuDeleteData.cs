using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class GBL_SUBMENUDeleteData : DataAccessBase
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }

        public GBL_SUBMENUDeleteData()
        {
            GBL_SUBMENU=new GBL_SUBMENU();
            StoredProcedureName = StoredProcedure.GBLSubMenu_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter() {
            DbParameter[] parameters={
                                         Parameter("@SubMenuID",GBL_SUBMENU.SUBMENU_ID),
                                         Parameter("@MenuID",GBL_SUBMENU.MENU_ID)
                                     };
            return parameters;
        }
    }
}
