using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class HRAccountUpdateData : DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public HRAccountUpdateData()
        {
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_UpdateAccount;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@USER_NAME"         ,   HR_EMP.USER_NAME   ),
                Parameter( "@PWD"        ,   HR_EMP.PWD  ),
                Parameter( "@SECURITY_QUESTION"        ,   HR_EMP.SECURITY_QUESTION  ),
                Parameter( "@SECURITY_ANSWER"        ,   HR_EMP.SECURITY_ANSWER  ),
                                      };
            return parameters;
        }
    }
}
