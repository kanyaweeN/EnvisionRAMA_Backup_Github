using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamlogSelectData : DataAccessBase 
	{
        public RIS_EXAMLOG RIS_EXAMLOG { get; set; }

		public  RISExamlogSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMLOG_Select;
            RIS_EXAMLOG = new RIS_EXAMLOG();
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
                                             Parameter("@FROMDATE",RIS_EXAMLOG.FROM_DATE),
                                             Parameter("@TODATE",RIS_EXAMLOG.TO_DATE),
                                       };
            return parameters;
        }
	}
}

