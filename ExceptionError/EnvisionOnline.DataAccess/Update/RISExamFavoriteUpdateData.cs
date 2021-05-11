using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Update
{
    public class RISExamFavoriteUpdateData: DataAccessBase
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }
        public RISExamFavoriteUpdateData()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMFAVORITE_UPDATE;
        }
        public void update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",RIS_EXAMFAVORITE.EXAM_ID),
            Parameter("@EMP_ID",RIS_EXAMFAVORITE.EMP_ID),
            Parameter("@SL_NO",RIS_EXAMFAVORITE.SL_NO)
			            };
            return parameters;
        }
    }
}
