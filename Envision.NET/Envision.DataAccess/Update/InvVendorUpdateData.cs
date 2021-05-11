using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class InvVendorUpdateData : DataAccessBase
    {
        public INV_VENDOR INV_VENDOR { get; set; }

        public InvVendorUpdateData()
        {
            INV_VENDOR = new INV_VENDOR();
            this.StoredProcedureName = StoredProcedure.Prc_INV_VENDOR_Update;
        }

        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                Parameter("@VENDOR_ID",INV_VENDOR.VENDOR_ID),
                                Parameter("@VENDOR_UID",INV_VENDOR.VENDOR_UID),
                                Parameter("@VENDOR_NAME",INV_VENDOR.VENDOR_NAME),
                                Parameter("@ORG_ID",INV_VENDOR.ORG_ID),
                                      };
            return parameters;
        }
    }
}
