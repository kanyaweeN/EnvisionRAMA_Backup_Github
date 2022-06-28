using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class InvVendorInsertData : DataAccessBase
    {
        public INV_VENDOR INV_VENDOR { get; set; }

        public InvVendorInsertData()
        {
            INV_VENDOR = new INV_VENDOR();
            this.StoredProcedureName = StoredProcedure.Prc_INV_VENDOR_Insert;
        }

        public void Insert()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                            Parameter("@VENDOR_UID",INV_VENDOR.VENDOR_UID),
                            Parameter("@VENDOR_NAME",INV_VENDOR.VENDOR_NAME),
                            Parameter("@ORG_ID",INV_VENDOR.ORG_ID),
			            };
            return parameters;
        }
    }
}
