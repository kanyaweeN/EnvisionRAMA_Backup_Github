using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISExamresultFilterRadDeleteData: DataAccessBase
    {
        public RIS_EXAMRESULT_FILTERRAD RIS_EXAMRESULT_FILTERRAD { get; set; }
        public RISExamresultFilterRadDeleteData()
		{
            RIS_EXAMRESULT_FILTERRAD = new RIS_EXAMRESULT_FILTERRAD();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERRAD_Delete;
		}
       
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@EMP_ID",RIS_EXAMRESULT_FILTERRAD.EMP_ID) ,
                                       };
            return parameters;
        }
	}
}
