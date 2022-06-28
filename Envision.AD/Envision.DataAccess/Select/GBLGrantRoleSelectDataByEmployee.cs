using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLGrantRoleSelectDataByEmployee : DataAccessBase
    {
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }    

        public GBLGrantRoleSelectDataByEmployee()
        {
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_SelectByEmployee;

        }
        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetAD()
        {
            StoredProcedureName = StoredProcedure.Prc_GBLGrantRole_AD_SelectByEmployee;

            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
				                                     Parameter("@Empid", GBL_GRANTROLE.EMP_ID),
                                       };
            return parameters;
        }
    }
}
