using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Insert
{
    public class SR_QuestionDtlInsertData : DataAccessBase
    {
       public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }
       public SR_QuestionDtlInsertData()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTL_Insert;
        }
        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            DataTable dtt = this.ExecuteDataTable();
            if (dtt.Rows.Count > 0)
                this.SR_QUESTIONSDTL.Q_ID_DTL = Convert.ToInt32(dtt.Rows[0][0].ToString());
            //this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
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
                                            Parameter("@Q_ID", this.SR_QUESTIONSDTL.Q_ID),
                                            Parameter("@LABEL", this.SR_QUESTIONSDTL.LABEL),
                                            Parameter("@DEFAULT_VALUE", this.SR_QUESTIONSDTL.DEFAULT_VALUE),
                                            Parameter("@IS_DEFAULT", this.SR_QUESTIONSDTL.IS_DEFAULT),
                                            Parameter("@HAS_CHILD", this.SR_QUESTIONSDTL.HAS_CHILD),
                                            Parameter("@IMG_POSITION", this.SR_QUESTIONSDTL.IMG_POSITION),
                                            pImageData,
                                            Parameter("@ORG_ID", this.SR_QUESTIONSDTL.ORG_ID),
                                            Parameter("@CREATED_BY", this.SR_QUESTIONSDTL.CREATED_BY),
                                            Parameter("@PROP1", this.SR_QUESTIONSDTL.PROP1),
                                            Parameter("@TEXT_SIZSE", this.SR_QUESTIONSDTL.TEXT_SIZE),
                                       };
            return parameters;
        }
    }
}
