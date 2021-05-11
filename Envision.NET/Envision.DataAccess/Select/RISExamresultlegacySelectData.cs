using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISExamresultlegacySelectData : DataAccessBase 
	{
        public RIS_EXAMRESULTLEGACY RIS_EXAMRESULTLEGACY { get; set; }

		public  RISExamresultlegacySelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTLEGACY_Select;
            RIS_EXAMRESULTLEGACY = new RIS_EXAMRESULTLEGACY();
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        public DataTable GetArchive()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTLEGACY_Select;
            DataTable ds = new DataTable();
            ParameterList = buildParameter();
            ds = ExecuteDataTable();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                 Parameter("@MODE",RIS_EXAMRESULTLEGACY.MODE),
                                                 Parameter("@HN",RIS_EXAMRESULTLEGACY.HN),
                                                 Parameter("@FROM_DATE",RIS_EXAMRESULTLEGACY.FROM_DATE ),
                                                 Parameter("@TO_DATE",RIS_EXAMRESULTLEGACY.TO_DATE),
                                       };
            return parameters;
        }
	}
	
}

