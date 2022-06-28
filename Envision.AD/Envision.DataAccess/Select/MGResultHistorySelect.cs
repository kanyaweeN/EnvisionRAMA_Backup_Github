using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGResultHistorySelect : DataAccessBase
    {
        public MGResultHistorySelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_GetResultHisory;
        }
        public DataSet GetData(int RegId)
        {
            DataSet ds = null;
            this.ParameterList = this.BuildPamaters(RegId);
            ds = this.ExecuteDataSet();
            return ds;
        }

        private DbParameter[] BuildPamaters(int RegId)
        {
            DbParameter[] parameters = { 
                                            Parameter("@REG_ID", RegId)
                                       };
            return parameters;
        }
    }
}
