using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class ONLGroupExamInsertData: DataAccessBase
    {
        public ONLGroupExamInsertData()
        {
        }
        public void Add(int gExamTypeID, int exam_id)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAM_Insert;
            DbParameter[] parameters ={		
	             Parameter("@GTYPE_ID",gExamTypeID)
                 ,Parameter("@EXAM_ID",exam_id)
			};
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}
