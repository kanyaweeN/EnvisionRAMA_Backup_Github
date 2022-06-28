using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RISContrastLotUpdateData: DataAccessBase
    {
        public RIS_CONTRASTLOT RIS_CONTRASTLOT { get; set; }

        public RISContrastLotUpdateData()
        {
            RIS_CONTRASTLOT = new RIS_CONTRASTLOT();
            this.StoredProcedureName = StoredProcedure.Prc_RIS_CONTRASTLOT_Update;
        }

        public void UpdateData()
        {
            this.ParameterList = new DbParameter[]{
                Parameter("@LOT_ID", this.RIS_CONTRASTLOT.LOT_ID),
                Parameter("@LOT_UID", this.RIS_CONTRASTLOT.LOT_UID),
                Parameter("@LOT_TEXT", this.RIS_CONTRASTLOT.LOT_TEXT),
                Parameter("@IS_ACTIVE", this.RIS_CONTRASTLOT.IS_ACTIVE),
                Parameter("@LAST_MODIFIED_BY", this.RIS_CONTRASTLOT.LAST_MODIFIED_BY),
            };
            this.ExecuteNonQuery();
        }
    }
}
