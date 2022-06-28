using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class SRQuestionsDtlUpdate : DataAccessBase
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }
        public SRQuestionsDtlUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTL_Update;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter pImageData = Parameter();
            pImageData.DbType = System.Data.DbType.Binary;
            pImageData.Direction = System.Data.ParameterDirection.Input;
            pImageData.ParameterName = "@IMG_DATA";

            if (this.SR_QUESTIONSDTL.IMG_DATA != null)
                pImageData.Value = this.SR_QUESTIONSDTL.IMG_DATA;
            else
                pImageData.Value = DBNull.Value;

            DbParameter[] parameters = { 
                                            Parameter("@Q_ID_DTL", SR_QUESTIONSDTL.Q_ID_DTL),
                                            Parameter("@LABEL", SR_QUESTIONSDTL.LABEL),
                                            Parameter("@DEFAULT_VALUE", SR_QUESTIONSDTL.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", SR_QUESTIONSDTL.IS_DEFAULT),
                                            Parameter("@HAS_CHILD", SR_QUESTIONSDTL.HAS_CHILD),
                                            Parameter("@IMG_POSITION", SR_QUESTIONSDTL.IMG_POSITION),
                                            pImageData,
                                            Parameter("@ORG_ID", SR_QUESTIONSDTL.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", SR_QUESTIONSDTL.LAST_MODIFIED_BY),
                                            Parameter("@PROP1", SR_QUESTIONSDTL.PROP1),
                                            Parameter("@TEXT_SIZE", SR_QUESTIONSDTL.TEXT_SIZE),
                                       };
            return parameters;
        }
    }
}
