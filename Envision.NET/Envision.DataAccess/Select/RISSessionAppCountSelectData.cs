using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISSessionAppCountSelectData: DataAccessBase
    {
            public RIS_SESSIONAPPCOUNT RIS_SESSIONAPPCOUNT { get; set; }

            public RISSessionAppCountSelectData()
            {
                RIS_SESSIONAPPCOUNT = new RIS_SESSIONAPPCOUNT();
                StoredProcedureName = StoredProcedure.Prc_RIS_SESSIONAPPCOUNT_SelectIsBlock;
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
                                                Parameter( "@APP_DATE"     ,RIS_SESSIONAPPCOUNT.APP_DATE),
                                       };
                return parameters;
            }
    }
}
