using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISPatstatusUpdateData : DataAccessBase
    {
        public RIS_PATSTATUS RIS_PATSTATUS { get; set; }

        public RISPatstatusUpdateData()
        {
            RIS_PATSTATUS = new RIS_PATSTATUS();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATSTATUS_Update;
        }
        public bool Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@STATUS_ID",RIS_PATSTATUS.STATUS_ID)
                ,Parameter("@STATUS_UID",RIS_PATSTATUS.STATUS_UID)
                ,Parameter("@STATUS_TEXT",RIS_PATSTATUS.STATUS_TEXT)
                ,Parameter("@IS_ACTIVE",RIS_PATSTATUS.IS_ACTIVE)
                ,Parameter("@ORG_ID",RIS_PATSTATUS.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_PATSTATUS.LAST_MODIFIED_BY)
                ,Parameter("@IS_DEFAULT",RIS_PATSTATUS.IS_DEFAULT)
                                      };
            return parameters;
        }
    }
}
