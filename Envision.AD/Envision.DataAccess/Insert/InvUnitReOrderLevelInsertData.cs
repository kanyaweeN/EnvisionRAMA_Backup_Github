using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvUnitReOrderLevelInsertData : DataAccessBase
    {
        public INV_UNITREORDERLEVEL INV_UNITREORDERLEVEL { get; set; }

        public InvUnitReOrderLevelInsertData()
        {
            INV_UNITREORDERLEVEL = new INV_UNITREORDERLEVEL();
            this.StoredProcedureName = StoredProcedure.Prc_INV_UNITREORDERLEVEL_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                                Parameter("@UNIT_ID",INV_UNITREORDERLEVEL.UNIT_ID),
                                Parameter("@ITEM_ID",INV_UNITREORDERLEVEL.ITEM_ID),
                                Parameter("@REORDER_DAYS",INV_UNITREORDERLEVEL.REORDER_DAYS),
                                Parameter("@REORDER_QTY",INV_UNITREORDERLEVEL.REORDER_QTY),
                                Parameter("@ORG_ID",INV_UNITREORDERLEVEL.ORG_ID),
			            };
            return parameters;
        }
    }
}
