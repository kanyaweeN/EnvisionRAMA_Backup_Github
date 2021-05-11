using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class XrayReqdtlDeleteData : DataAccessBase
    {

        public XRAYREQ XRAYREQ { get; set; }

        public XrayReqdtlDeleteData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_ONLXrayreqdtl_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@ORDER_ID",XRAYREQ.ORDER_ID),
                                        Parameter("@EXAM_ID",XRAYREQ.EXAM_ID),
                                        Parameter("@LAST_MODIFIED_BY",XRAYREQ.LAST_MODIFIED_BY)
                                     };
            return parameters;
        }
    }
}
