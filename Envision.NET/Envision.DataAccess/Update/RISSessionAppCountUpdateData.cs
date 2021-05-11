using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISSessionAppCountUpdateData: DataAccessBase
    {
        public RIS_SESSIONAPPCOUNT RIS_SESSIONAPPCOUNT { get; set; }

        public RISSessionAppCountUpdateData()
        {
            RIS_SESSIONAPPCOUNT = new RIS_SESSIONAPPCOUNT();
            StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONAPPCOUNT_UpdateIsBlock;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@APP_DATE"         ,  RIS_SESSIONAPPCOUNT.APP_DATE  ),
                Parameter( "@MODALITY_ID"         ,  RIS_SESSIONAPPCOUNT.MODALITY_ID  ),
                Parameter( "@SESSION_ID"         ,  RIS_SESSIONAPPCOUNT.SESSION_ID  ),
                Parameter( "@IS_BLOCK"         ,  RIS_SESSIONAPPCOUNT.IS_BLOCKED  ),
                                      };
            return parameters;
        }
    }
}
