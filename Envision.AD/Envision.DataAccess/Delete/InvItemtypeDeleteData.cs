using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_ITEMTYPEDeleteData : DataAccessBase
    {
        public INV_ITEMTYPE INV_ITEMTYPE { get; set; }

        public INV_ITEMTYPEDeleteData()
        {
            INV_ITEMTYPE = new INV_ITEMTYPE();
            StoredProcedureName = StoredProcedure.Prc_INV_ITEMTYPE_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ITEMTYPE_ID",INV_ITEMTYPE.ITEMTYPE_ID),
                                     };
            return parameters;
        }
       
    }
}
