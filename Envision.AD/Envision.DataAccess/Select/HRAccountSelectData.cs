using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class HRAccountSelectData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public HRAccountSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_GetAccount;
            HR_EMP = new HR_EMP();
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
                                            Parameter("@Username",HR_EMP.Username)
                                       };
            return parameters;
        }
    }
}
