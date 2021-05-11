using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLEmployeeSelectData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public GBLEmployeeSelectData()
        {
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.GBLEmployee_GetAccount;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetSchedule() {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.GBLEmpSchedule_Select;
            ParameterList = buildParameterSchedule();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                    Parameter("@Authlevelid", HR_EMP.AUTH_LEVEL_ID),
                                                    Parameter("@Unitid",      HR_EMP.UNIT_ID)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameterSchedule()
        {
            DbParameter[] parameters = { 
                                                    Parameter("@EMP_ID",      HR_EMP.EMP_ID)
                                       };
            return parameters;
        }
    }
}
