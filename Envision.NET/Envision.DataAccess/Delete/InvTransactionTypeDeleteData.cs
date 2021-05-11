using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_TRANSACTIONTYPEDeleteData : DataAccessBase
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE{get;set;}

        public INV_TRANSACTIONTYPEDeleteData()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_INV_TRANSACTIONTYPE_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@TRANSACTIONTYPE_ID",INV_TRANSACTIONTYPE.TRANSACTIONTYPE_ID)
                                     };
            return parameters;
        }
       
    }
}
