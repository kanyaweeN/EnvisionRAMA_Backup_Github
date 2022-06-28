using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISNursesDataSelectData : DataAccessBase
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
		public  RISNursesDataSelectData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
			StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATA_Select;
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
            DbParameter[] parameters ={			
                Parameter("@SELECTCASE",RIS_NURSESDATA.SELECTCASE)
                ,Parameter("@ACCESSION_NO",RIS_NURSESDATA.ACCESSION_NO)
                ,Parameter("@NURSE_DATA_UK_ID", RIS_NURSESDATA.NURSE_DATA_UK_ID)
                ,Parameter("@HN", RIS_NURSESDATA.HN)
			};
            return parameters;
        }
	}
}
