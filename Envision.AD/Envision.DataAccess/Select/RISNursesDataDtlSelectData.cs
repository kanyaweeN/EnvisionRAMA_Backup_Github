using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISNursesDataDtlSelectData : DataAccessBase
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        public RISNursesDataDtlSelectData()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATADTL_Select;
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
                Parameter("@selectcase",RIS_NURSESDATADTL.SELECTCASE)
                ,Parameter("@NURSE_DATA_UK_ID", RIS_NURSESDATADTL.NURSE_DATA_UK_ID)
			};
            return parameters;
        }
	}
}
