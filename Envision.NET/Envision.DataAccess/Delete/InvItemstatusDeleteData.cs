using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class InvItemstatusDeleteData : DataAccessBase
    {
        public INV_ITEMSTATUS INV_ITEMSTATUS {get;set;}

        public InvItemstatusDeleteData()
        {
            INV_ITEMSTATUS = new INV_ITEMSTATUS();
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMSTATUS_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ITEMSTATUS_ID",INV_ITEMSTATUS.ITEMSTATUS_ID),
                                     };
            return parameters;
        }
    }
}
