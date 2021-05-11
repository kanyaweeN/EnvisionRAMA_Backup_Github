using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class ONLGroupExamTypeDeleteData: DataAccessBase
    {
        public ONLGroupExamTypeDeleteData()
        {
        }

        public void Delete(int gtype_id)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAMTYPE_Delete;
            DbParameter[] parameters = { 
                                           Parameter("@GTYPE_ID", gtype_id),
                                       };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}