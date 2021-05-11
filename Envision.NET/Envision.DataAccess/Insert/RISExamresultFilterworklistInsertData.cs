using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultFilterworklistInsertData: DataAccessBase 
	{
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }
        public RISExamresultFilterworklistInsertData()
		{
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERWORKLIST_Insert;
		}
		public bool Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@FILTER_NAME",RIS_EXAMRESULT_FILTERWORKLIST.FILTER_NAME),
Parameter("@FILTER_DETAIL",RIS_EXAMRESULT_FILTERWORKLIST.FILTER_DETAIL),
Parameter("@CRAETED_BY",RIS_EXAMRESULT_FILTERWORKLIST.CRAETED_BY),
            };
            return parameters;
        }
	}
}