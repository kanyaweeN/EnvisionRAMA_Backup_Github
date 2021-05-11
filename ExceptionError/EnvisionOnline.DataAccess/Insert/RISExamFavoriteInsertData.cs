using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Insert
{
    public class RISExamFavoriteInsertData : DataAccessBase
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }
        public RISExamFavoriteInsertData()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMFAVORITE_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                Parameter("@EXAM_ID",RIS_EXAMFAVORITE.EXAM_ID),
            Parameter("@EMP_ID",RIS_EXAMFAVORITE.EMP_ID),
            Parameter("@SL_NO",RIS_EXAMFAVORITE.SL_NO),
            Parameter("@ORG_ID",RIS_EXAMFAVORITE.ORG_ID),
            Parameter("@CREATED_BY",RIS_EXAMFAVORITE.CREATED_BY),
                
			            };
            return parameters;
        }
    }
}
