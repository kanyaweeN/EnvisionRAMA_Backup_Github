using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class GBLEmployeeDeleteData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }
        public GBLEmployeeDeleteData()
        {
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.GBLEmployee_DeleteAccount;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Delete(DbTransaction tran) {
            Transaction = tran;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                        Parameter("@EmpID"		, HR_EMP.EMP_ID)
                                       };
            return parameters;
        }
       
    }
}
