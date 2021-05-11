using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class ONLGroupExamDeleteData: DataAccessBase
    {
        public ONLGroupExamDeleteData()
        {
        }

        public void Delete(int gtype_id)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAM_Delete;
            DbParameter[] parameters = { 
                                           Parameter("@GTYPE_ID", gtype_id),
                                       };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void DeleteByID(int gexam_id)
        {
            StoredProcedureName = StoredProcedure.Prc_ONL_GROUPEXAM_DeleteByGExamID;
            DbParameter[] parameters = { 
                                           Parameter("@GEXAM_ID", gexam_id),
                                       };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
    }
}