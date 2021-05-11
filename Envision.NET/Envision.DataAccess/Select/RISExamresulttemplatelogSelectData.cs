using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresulttemplatelogSelectData : DataAccessBase 
	{
        public RIS_EXAMRESULTTEMPLATELOG RIS_EXAMRESULTTEMPLATELOG { get; set; }
		public  RISExamresulttemplatelogSelectData()
		{
            RIS_EXAMRESULTTEMPLATELOG = new RIS_EXAMRESULTTEMPLATELOG();
			StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTEMPLATELOG_Select;
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
                Parameter("@FROMDATE",RIS_EXAMRESULTTEMPLATELOG.FROMDATE)
                ,Parameter("@TODATE",RIS_EXAMRESULTTEMPLATELOG.TODATE)
                                       };
            return parameters;
        }
	}
}

