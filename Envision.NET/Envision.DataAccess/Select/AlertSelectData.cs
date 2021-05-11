using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class AlertSelectData : DataAccessBase
    {
       

        public AlertSelectData()
        {
            StoredProcedureName = StoredProcedure.AlertObjects_Select;
        }

        public DataSet Get(string uid)
        {
            int sp=3;
            string uids = uid;
            if (uids == "")
            {
                sp = 1;
                
            }
            DataSet ds = new DataSet();
            ParameterList = buildParameter(sp, uids, 0);
            ds = ExecuteDataSet();
            return ds;

        }

        public DataSet Get2(int uid)
        {
            int sp = 2;
            int ids = uid;
            DataSet ds = new DataSet();
            ParameterList = buildParameter(sp, null, ids);
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter(int spno, string uidno, int dtl_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@SP_Types",spno),
                                          Parameter("@UdID",uidno),
                                          Parameter("@DTL_ID",dtl_id),
                                       };
            return parameters;
        }
        
    }
}
