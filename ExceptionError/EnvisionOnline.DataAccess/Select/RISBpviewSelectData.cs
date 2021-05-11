using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISBpviewSelectData : DataAccessBase
    {
        public RISBpviewSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEW_Select;
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          //Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                                       };
            return parameters;
        }
    }
}
