using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class ONLGroupDepartmentDeleteData: DataAccessBase
    {
        public ONLGroupDepartmentDeleteData()
        {
        }

        public void Delete(int gdept_id)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPDEPARTMENT_Delete;
            DbParameter[] parameters = { 
                                           Parameter("@GDEPT_ID", gdept_id),
                                       };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}