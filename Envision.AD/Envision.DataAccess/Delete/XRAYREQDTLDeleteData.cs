using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class XRAYREQDTLDeleteData : DataAccessBase 
    {
        public XRAYREQDTL XRAYREQDTL { get; set; }

        public XRAYREQDTLDeleteData()
        {
            this.XRAYREQDTL = new XRAYREQDTL();
            StoredProcedureName = StoredProcedure.Prc_XRAYREQDTL_CancelWithReason;
        }
        public bool Delete()
        {
            ParameterList = new DbParameter[] 
                            {
                                Parameter("@ORDER_ID",XRAYREQDTL.ORDER_ID)
                                ,Parameter("@EXAM_ID",XRAYREQDTL.EXAM_ID)
                                ,Parameter("@REASON",XRAYREQDTL.REASON)
                                ,Parameter("@IS_DELETED",XRAYREQDTL.IS_DELETED)
                                ,Parameter("@LAST_MODIFIED_BY",XRAYREQDTL.LAST_MODIFIED_BY)
                            };
            ExecuteNonQuery();
            return true;
        }
    }
}
