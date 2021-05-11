using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class INV_VENDORDeleteData : DataAccessBase
    {
        public INV_VENDOR INV_VENDOR { get; set; }

        public INV_VENDORDeleteData()
        {
            INV_VENDOR = new INV_VENDOR();
            StoredProcedureName = StoredProcedure.Prc_INV_VENDOR_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@VENDOR_ID",INV_VENDOR.VENDOR_ID)
                                     };
            return parameters;
        }
    }
}
