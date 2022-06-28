using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RISExamresultFilterworklistDeleteData : DataAccessBase 
	{
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }

        public RISExamresultFilterworklistDeleteData()
		{
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_FILTERWORKLIST_Delete;
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
                                           Parameter("@FILTER_ID", RIS_EXAMRESULT_FILTERWORKLIST.FILTER_ID) 
                                       };
            return parameters;
        }
	}
}

