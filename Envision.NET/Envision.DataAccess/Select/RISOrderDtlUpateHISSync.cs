using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISOrderDtlUpateHISSync : DataAccessBase
    {
        public RISOrderDtlUpateHISSync()
        {
            this.StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_UpdateHisSync;
        }

        public void UpdateHisSync(string accessionNo, string hisSync, string hisAck, int orgId)
        {
            this.ParameterList = new DbParameter[] 
            {
                Parameter("@ACCESSION_NO", accessionNo),
                Parameter("@HIS_SYNC", hisSync),
                Parameter("@HIS_ACK", hisAck),
                Parameter("@ORG_ID", orgId),                
            };
            this.ExecuteNonQuery();
        }
    }
}
