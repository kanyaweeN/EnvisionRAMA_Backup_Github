using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvItemstatusUpdateData : DataAccessBase
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS { get; set; }

        public InvItemstatusUpdateData()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
            this.StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTATUS_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@ITEMSTATUS_ID",INV_ITEMSTATUS.ITEMSTATUS_ID),
                                Parameter("@ITEMSTATUS_UID",INV_ITEMSTATUS.ITEMSTATUS_UID),
                                Parameter("@ITEMSTATUS_NAME",INV_ITEMSTATUS.ITEMSTATUS_NAME),
                                Parameter("@ORG_ID",INV_ITEMSTATUS.ORG_ID),
                                      };
            return parameters;
        }
    }
}
