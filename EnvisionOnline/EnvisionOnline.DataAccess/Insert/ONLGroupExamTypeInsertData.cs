using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class ONLGroupExamTypeInsertData: DataAccessBase
    {
        public ONL_GROUPEXAMTYPE ONL_GROUPEXAMTYPE { get; set; }
        public ONLGroupExamTypeInsertData()
        {
            ONL_GROUPEXAMTYPE = new ONL_GROUPEXAMTYPE();
        }
        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAMTYPE_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={		
	             Parameter("@GTYPE_TEXT",ONL_GROUPEXAMTYPE.GTYPE_TEXT)
                 ,Parameter("@GDEPT_ID",ONL_GROUPEXAMTYPE.GDEPT_ID)
                 ,Parameter("@CREATED_BY",ONL_GROUPEXAMTYPE.CREATED_BY)
			};
            return parameters;
        }
    }
}
