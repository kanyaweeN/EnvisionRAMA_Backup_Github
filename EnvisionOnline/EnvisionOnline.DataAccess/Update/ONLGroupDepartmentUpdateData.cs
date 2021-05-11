using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class ONLGroupDepartmentUpdateData: DataAccessBase
    {
        public ONL_GROUPDEPARTMENT ONL_GROUPDEPARTMENT { get; set; }

        public ONLGroupDepartmentUpdateData()
        {
            ONL_GROUPDEPARTMENT = new ONL_GROUPDEPARTMENT();
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPDEPARTMENT_Update;
        }
        public void Update()
        {
            DbParameter[] parameters ={
                Parameter("@GDEPT_ID",ONL_GROUPDEPARTMENT.GDEPT_ID),
                Parameter("@GDEPT_TEXT",ONL_GROUPDEPARTMENT.GDEPT_TEXT),
                Parameter("@GDEPT_TYPE",ONL_GROUPDEPARTMENT.GDEPT_TYPE),
                Parameter("@LAST_MODIFIED_BY",ONL_GROUPDEPARTMENT.LAST_MODIFIED_BY),
            };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
