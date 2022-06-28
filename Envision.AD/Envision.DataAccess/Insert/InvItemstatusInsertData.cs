using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvItemstatusInsertData : DataAccessBase
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS { get; set; }

        public InvItemstatusInsertData()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
            this.StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTATUS_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                            Parameter("@ITEMSTATUS_UID",INV_ITEMSTATUS.ITEMSTATUS_UID),
                            Parameter("@ITEMSTATUS_NAME",INV_ITEMSTATUS.ITEMSTATUS_NAME),
                            Parameter("@ORG_ID",INV_ITEMSTATUS.ORG_ID),
            };
            return parameters;
        }

    }
}
