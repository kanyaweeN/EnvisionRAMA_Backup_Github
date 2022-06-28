using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_QuestionDtlChildInsertData : DataAccessBase
    {
      public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }
      public SR_QuestionDtlChildInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTLCHILD_Insert;
        }

        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
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
                                            Parameter("@Q_ID", this.SR_QUESTIONSDTLCHILD.Q_ID),
                                            Parameter("@Q_ID_DTL", this.SR_QUESTIONSDTLCHILD.Q_ID_DTL),
                                            Parameter("@Q_TYPE_ID", this.SR_QUESTIONSDTLCHILD.Q_TYPE_ID),
                                            Parameter("@LABEL", this.SR_QUESTIONSDTLCHILD.LABEL),
                                            Parameter("@DEFAULT_VALUE", this.SR_QUESTIONSDTLCHILD.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", this.SR_QUESTIONSDTLCHILD.IS_DEFAULT),
                                            Parameter("@IMG_POSITION", this.SR_QUESTIONSDTLCHILD.IMG_POSITION),
                                            pImageData,
                                            Parameter("@PROP1", this.SR_QUESTIONSDTLCHILD.PROP1),
                                            Parameter("@QUESTION_SIDE", this.SR_QUESTIONSDTLCHILD.QUESION_SIDE),
                                            Parameter("@TEXT_SIZE", this.SR_QUESTIONSDTLCHILD.TEXT_SIZE),
                                            Parameter("@ORG_ID", this.SR_QUESTIONSDTLCHILD.ORG_ID),
                                            Parameter("@CREATED_BY", this.SR_QUESTIONSDTLCHILD.CREATED_BY),
                                       };
            return parameters;
        }
    }
}
