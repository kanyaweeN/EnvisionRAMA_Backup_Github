using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class ONLGroupExamTypeUpdateData: DataAccessBase
    {
        public ONL_GROUPEXAMTYPE ONL_GROUPEXAMTYPE { get; set; }

        public ONLGroupExamTypeUpdateData()
        {
            ONL_GROUPEXAMTYPE = new ONL_GROUPEXAMTYPE();
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAMTYPE_Update;
        }
        public void Update()
        {
            DbParameter[] parameters ={
                Parameter("@GTYPE_ID",ONL_GROUPEXAMTYPE.GTYPE_ID),
                Parameter("@GTYPE_TEXT",ONL_GROUPEXAMTYPE.GTYPE_TEXT),
                Parameter("@GDEPT_ID",ONL_GROUPEXAMTYPE.GDEPT_ID),
                Parameter("@LAST_MODIFIED_BY",ONL_GROUPEXAMTYPE.LAST_MODIFIED_BY),
            };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
