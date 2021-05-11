using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBL_MENUDeleteData : DataAccessBase
    {
        public GBL_MENU GBL_MENU { get; set; }


        public GBL_MENUDeleteData()
        {
            GBL_MENU = new GBL_MENU();
            StoredProcedureName = StoredProcedure.GBLMenu_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@MenuID"		,  GBL_MENU.MENU_ID)
                                       };
            return parameters;
        }
    }
}
