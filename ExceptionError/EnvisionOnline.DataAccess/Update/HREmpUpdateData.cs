using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class HREmpUpdateData: DataAccessBase
    {
        public HR_EMP HR_EMP { get; set; }

        public HREmpUpdateData()
        {
            HR_EMP = new HR_EMP();
            StoredProcedureName = StoredProcedure.Prc_HR_EMP_UpdateRole;
        }
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@EMP_ID",HR_EMP.EMP_ID),
                Parameter("@JOB_TYPE",HR_EMP.JOB_TYPE),
            };
            return parameters;
        }
    }
}

