using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISExamFavoriteDeleteData : DataAccessBase
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }

        public RISExamFavoriteDeleteData()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMFAVORITE_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@EXAM_ID",RIS_EXAMFAVORITE.EXAM_ID),
            Parameter("@EMP_ID",RIS_EXAMFAVORITE.EMP_ID),
            Parameter("@ORG_ID",RIS_EXAMFAVORITE.ORG_ID)
                                     };
            return parameters;
        }
    }
}
