using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvItemtypeUpdateData : DataAccessBase
    {
        public INV_ITEMTYPE INV_ITEMTYPE { get; set; }

        public InvItemtypeUpdateData()
        {
            INV_ITEMTYPE = new INV_ITEMTYPE();
            this.StoredProcedureName = StoredProcedure.Prc_INV_ITEMTYPE_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@ITEMTYPE_ID",INV_ITEMTYPE.ITEMTYPE_ID),
                                Parameter("@ITEMTYPE_UID",INV_ITEMTYPE.ITEMTYPE_UID),
                                Parameter("@ITEMTYPE_NAME",INV_ITEMTYPE.ITEMTYPE_NAME),
                                Parameter("@ITEMTYPE_DESC",INV_ITEMTYPE.ITEMTYPE_DESC),
                                Parameter("@ORG_ID",INV_ITEMTYPE.ORG_ID),
                                      };
            return parameters;
        }
    }
}
