using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_TXNUNITDeleteData : DataAccessBase
    {
        public INV_TXNUNIT INV_TXNUNIT { get; set; }

        public INV_TXNUNITDeleteData()
        {
            INV_TXNUNIT = new INV_TXNUNIT();
            this.StoredProcedureName = StoredProcedure.Prc_INV_TXNUNIT_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@TXN_UNIT_ID",INV_TXNUNIT.TXN_UNIT_ID)
                                     };
            return parameters;
        }
       
    }
}
