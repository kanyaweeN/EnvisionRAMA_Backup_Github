using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class GBLGeneralDtlUpdateData: DataAccessBase
    {
        public GBL_GENERALDTL GBL_GENERALDTL { get; set; }

        public GBLGeneralDtlUpdateData()
        {
            GBL_GENERALDTL = new GBL_GENERALDTL();
            StoredProcedureName = StoredProcedure.Prc_GBL_GENERALDTL_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@GEN_DTL_ID",GBL_GENERALDTL.GEN_DTL_ID),
                Parameter("@GEN_ID",GBL_GENERALDTL.GEN_ID),
                Parameter("@GEN_TEXT",GBL_GENERALDTL.GEN_TEXT),
                Parameter("@GEN_TITLE",GBL_GENERALDTL.GEN_TITLE),
                Parameter("@IS_ACTIVE",GBL_GENERALDTL.IS_ACTIVE),
                Parameter("@IS_UPDATED",GBL_GENERALDTL.IS_UPDATED),
                Parameter("@IS_DELETED",GBL_GENERALDTL.IS_DELETED),
                Parameter("@ORG_ID",GBL_GENERALDTL.ORG_ID),
                Parameter("@LAST_MODIFIED_BY",GBL_GENERALDTL.LAST_MODIFIED_BY),
            
                                      };
            return parameters;
        }
    }
}
