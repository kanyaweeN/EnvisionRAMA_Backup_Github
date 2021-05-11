using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class XrayReqDeleteData : DataAccessBase
    {

        public XRAYREQ XRAYREQ { get; set; }

        public XrayReqDeleteData()
        {
            XRAYREQ = new XRAYREQ();
            StoredProcedureName = StoredProcedure.Prc_ONLXrayreq_Delete;
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
                                        Parameter("@LAST_MODIFIED_BY",XRAYREQ.LAST_MODIFIED_BY),
                                        Parameter("@REASON",XRAYREQ.REASON)
                                     };
            return parameters;
        }
    }
}

