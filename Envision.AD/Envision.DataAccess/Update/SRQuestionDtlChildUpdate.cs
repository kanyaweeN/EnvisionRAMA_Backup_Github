using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class SRQuestionDtlChildUpdate : DataAccessBase
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public SRQuestionDtlChildUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTLCHILD_Update;
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

            if (this.SR_QUESTIONSDTLCHILD.IMG_DATA != null)
                pImageData.Value = this.SR_QUESTIONSDTLCHILD.IMG_DATA;
            else
                pImageData.Value = DBNull.Value;

            DbParameter[] parameters = { 
                                            Parameter("@Q_ID_DTL_CHD", SR_QUESTIONSDTLCHILD.Q_ID_DTL_CHD),
                                            Parameter("@Q_TYPE_ID", SR_QUESTIONSDTLCHILD.Q_TYPE_ID),
                                            Parameter("@LABEL", SR_QUESTIONSDTLCHILD.LABEL),
                                            Parameter("@DEFAULT_VALUE", SR_QUESTIONSDTLCHILD.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", SR_QUESTIONSDTLCHILD.IS_DEFAULT),
                                            Parameter("@IMG_POSITION", SR_QUESTIONSDTLCHILD.IMG_POSITION),
                                            pImageData,
                                            Parameter("@PROP1", SR_QUESTIONSDTLCHILD.PROP1),
                                            Parameter("@QUESTION_SIDE", SR_QUESTIONSDTLCHILD.QUESION_SIDE),
                                            Parameter("@TEXT_SIZE", SR_QUESTIONSDTLCHILD.TEXT_SIZE),
                                            Parameter("@ORG_ID", SR_QUESTIONSDTLCHILD.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", SR_QUESTIONSDTLCHILD.LAST_MODIFIED_BY),
                                       };
            return parameters;
        }
    }
}
