using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class XRAYREQSelectData : DataAccessBase
    {
        public XRAYREQ XRAYREQ { get; set; }
        public DataSet Result { get; set; }

        public XRAYREQSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_XRAYREQ_SelectBusyCase;
            XRAYREQ = new XRAYREQ();
        }
        public DataTable GetBusyCase(int xrayreq_id)
        {
            DataTable ds = new DataTable();
            ParameterList = new DbParameter[] { 
                                                Parameter("@XRAYREQ_ID",xrayreq_id)
                                                };
            ds = ExecuteDataTable();
            return ds;
        }
    }
}
