using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultFilterRadInsertData: DataAccessBase 
	{
        public RIS_EXAMRESULT_FILTERRAD RIS_EXAMRESULT_FILTERRAD { get; set; }
        public RISExamresultFilterRadInsertData()
		{
            RIS_EXAMRESULT_FILTERRAD = new RIS_EXAMRESULT_FILTERRAD();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERRAD_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={
                Parameter("@EMP_ID",RIS_EXAMRESULT_FILTERRAD.EMP_ID)
                ,Parameter("@FILTER_ID",RIS_EXAMRESULT_FILTERRAD.FILTER_ID)
                ,Parameter("@CREATED_BY",RIS_EXAMRESULT_FILTERRAD.CREATED_BY)
            };
            return parameters;
        }
	}
}