using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISModalitytypeUpdateData : DataAccessBase
    {
        public RIS_MODALITYTYPE RIS_MODALITYTYPE { get; set; }

        public RISModalitytypeUpdateData()
        {
            RIS_MODALITYTYPE = new RIS_MODALITYTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYTYPE_Update;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@TYPE_ID",RIS_MODALITYTYPE.TYPE_ID),
                Parameter("@TYPE_UID",RIS_MODALITYTYPE.TYPE_UID),
                Parameter("@TYPE_NAME",RIS_MODALITYTYPE.TYPE_NAME),
                Parameter("@TYPE_NAME_ALIAS",RIS_MODALITYTYPE.TYPE_NAME_ALIAS),
                Parameter("@DESCR",RIS_MODALITYTYPE.DESCR),
                Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
                                      };
            return parameters;
        }
    }
}

