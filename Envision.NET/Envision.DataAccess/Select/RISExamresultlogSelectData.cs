using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresultlogSelectData : DataAccessBase 
	{
        public RIS_EXAMRESULTLOG RIS_EXAMRESULTLOG { get; set; }

		public  RISExamresultlogSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTLOG_Select;
            RIS_EXAMRESULTLOG = new RIS_EXAMRESULTLOG();
		}
	
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                              Parameter("@FROM_DATE",RIS_EXAMRESULTLOG.FROM_DATE),
                                              Parameter("@TO_DATE",RIS_EXAMRESULTLOG.TO_DATE),
                                       };
            return parameters;
        }
	}
}

