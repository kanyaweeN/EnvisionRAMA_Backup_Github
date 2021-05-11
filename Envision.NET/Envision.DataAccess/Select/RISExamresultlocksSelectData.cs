using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresultlocksSelectData : DataAccessBase 
	{
        public RIS_EXAMRESULTLOCK RIS_EXAMRESULTLOCK { get; set; }

		public  RISExamresultlocksSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTLOCKS_Select;
            RIS_EXAMRESULTLOCK = new RIS_EXAMRESULTLOCK();
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataSet GetData_DateRange()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameter()
        {
            DateTime fd = RIS_EXAMRESULTLOCK.FROM_DATE <= DateTime.MinValue ? DateTime.Now : RIS_EXAMRESULTLOCK.FROM_DATE;
            DateTime td = RIS_EXAMRESULTLOCK.TO_DATE <= DateTime.MinValue ? DateTime.Now : RIS_EXAMRESULTLOCK.TO_DATE;


            DbParameter[] parameters = { 
                                              Parameter("@MODE",RIS_EXAMRESULTLOCK.MODE),
                                              Parameter("@FROM_DATE",fd),
                                              Parameter("@TO_DATE",td),
                                       };
            return parameters;
        }
	}
}

