using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_ITEMDeleteData : DataAccessBase
    {
        public INV_ITEM INV_ITEM{get;set;}

        public INV_ITEMDeleteData()
        {
            INV_ITEM = new INV_ITEM();
            StoredProcedureName = StoredProcedure.Prc_INV_ITEM_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ITEM_ID",INV_ITEM.ITEM_ID)
                                     };
            return parameters;
        }
    }
}
