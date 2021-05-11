using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class HRTitleSelectData : DataAccessBase
    {
        public HRTitleSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_TITLE_Select;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          //Parameter("@ORG_ID"	, new GBLEnvVariable().OrgID  )
                                       };
            return parameters;
        }
    }
}